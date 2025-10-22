using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotThoseLines
{
    public static class SaveFile
    {
        public static void Load()
        {
            string connectionString = "Data Source=ptl.db;Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            //Restore series from savefile
            string createSeriesTableSql = "CREATE TABLE IF NOT EXISTS series (Id INTEGER PRIMARY KEY, Name TEXT, IsDisplayed BOOLEAN, Color TEXT)";
            string createPointsTableSql = "CREATE TABLE IF NOT EXISTS points (X FLOAT, Y FLOAT, Serie INTEGER, FOREIGN KEY(Serie) REFERENCES series(Id))";

            SQLiteCommand createSeriesTableCommand = new SQLiteCommand(createSeriesTableSql, connection);
            SQLiteCommand createPointsTableCommand = new SQLiteCommand(createPointsTableSql, connection);

            connection.Open();
            createSeriesTableCommand.ExecuteNonQuery();
            createPointsTableCommand.ExecuteNonQuery();
            string sql = "SELECT * FROM series JOIN points ON series.Id = points.Serie";
            SQLiteCommand command = new SQLiteCommand(sql, connection);

            SQLiteDataReader reader = command.ExecuteReader();
            try
            {
                // Check if rows are returned
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int Id = reader.GetInt32("Id");
                        string Name = reader.GetString("Name");
                        string IsDisplayed = reader.GetString("IsDisplayed");;
                        string Color = reader.GetString("Color");
                        double X = reader.GetDouble("X");
                        double Y = reader.GetDouble("Y");
                        if (Series.series.Where(s => s.Id == Id).Count() == 0)
                        {
                            Series.series.Add(new Serie(Id, Name, Boolean.Parse(IsDisplayed), Color));
                        }
                        else
                        {
                            Series.series.Where(s => s.Id == Id).First().XaxisValue.Add(X);
                            Series.series.Where(s => s.Id == Id).First().YaxisValue.Add(Y);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();
            }

            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            finally
            {
                reader.Close();
                connection.Close();
            }
        }

        public static void Save()
        {
            string connectionString = "Data Source=ptl.db;Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);

            Directory.CreateDirectory("snapshots");
            DateTime now = DateTime.Now;
            string saveFileName = $"snapshots\\ptl-{now.Year}-{now.Month}-{now.Day}-{now.Hour}-{now.Minute}-{now.Second}.sql";

            try
            {
                if (!File.Exists("ptl.db"))
                {
                    File.Create("ptl.db").Close();
                }

                Action<(double, double), int> SavePoint = (t, i) =>
                {
                    string insertPointSql = $"INSERT INTO points (X, Y, Serie) VALUES ('{t.Item1}', '{t.Item2}', '{i}')";
                    SQLiteCommand insertPointCommand = new SQLiteCommand(insertPointSql, connection);
                    insertPointCommand.ExecuteNonQuery();
                    string[] sqlArray = new string[1] { insertPointSql + ";"};
                    File.AppendAllLines(saveFileName, sqlArray);
                };

                Action<Serie> SaveSerie = s =>
                {
                    string insertSerieSql = $"INSERT INTO series (Id, Name, IsDisplayed, Color) VALUES ('{s.Id}', '{s.Name}', '{s.IsDisplayed}', '{s.Color.ToStringRGBA()}')";
                    SQLiteCommand insertSerieCommand = new SQLiteCommand(insertSerieSql, connection);
                    insertSerieCommand.ExecuteNonQuery();

                    string[] sqlArray = new string[1] { insertSerieSql + ";" };
                    File.AppendAllLines(saveFileName, sqlArray);

                    List<(double, double)> values = s.XaxisValue.Zip(s.YaxisValue).ToList();
                    values.ForEach(x => SavePoint(x, s.Id));
                };

                connection.Open();
                new SQLiteCommand("DELETE FROM points", connection).ExecuteNonQuery();
                new SQLiteCommand("DELETE FROM series", connection).ExecuteNonQuery();

                Series.series.ForEach(s => SaveSerie(s));
                connection.Close();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
