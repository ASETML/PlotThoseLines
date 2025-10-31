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
        //Connection à la DB
        static string connectionString = "Data Source=ptl.db;Version=3;";
        static SQLiteConnection connection = new SQLiteConnection(connectionString);

        /// <summary>
        /// Load series from the database
        /// </summary>
        public static void Load()
        {
            //Création des tables si elles n'existent pas encore
            string createSeriesTableSql = "CREATE TABLE IF NOT EXISTS series (Id INTEGER PRIMARY KEY, Name TEXT, IsDisplayed BOOLEAN, Color TEXT)";
            string createPointsTableSql = "CREATE TABLE IF NOT EXISTS points (X FLOAT, Y FLOAT, Serie INTEGER, FOREIGN KEY(Serie) REFERENCES series(Id))";

            SQLiteCommand createSeriesTableCommand = new SQLiteCommand(createSeriesTableSql, connection);
            SQLiteCommand createPointsTableCommand = new SQLiteCommand(createPointsTableSql, connection);

            connection.Open();
            createSeriesTableCommand.ExecuteNonQuery();
            createPointsTableCommand.ExecuteNonQuery();

            //Récupération des séries dans la DB
            string sql = "SELECT * FROM series JOIN points ON series.Id = points.Serie";
            SQLiteCommand command = new SQLiteCommand(sql, connection);

            SQLiteDataReader reader = command.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Récupération des valeurs
                        int Id = reader.GetInt32("Id");
                        double X = reader.GetDouble("X");
                        double Y = reader.GetDouble("Y");

                        //Créer la série si elle n'existe pas encore
                        if (Program.series.Where(s => s.Id == Id).Count() == 0)
                        {
                            //Récupération des valeurs pour la création de la série
                            string Name = reader.GetString("Name");
                            string IsDisplayed = reader.GetString("IsDisplayed"); ;
                            string Color = reader.GetString("Color");

                            Program.series.Add(new Serie(Id, Name, Boolean.Parse(IsDisplayed), Color));
                        }

                        //Ajouter les valeurs à la série
                        Program.series.Where(s => s.Id == Id).First().XaxisValue.Add(X);
                        Program.series.Where(s => s.Id == Id).First().YaxisValue.Add(Y);
                    }
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

        /// <summary>
        /// Save series to the database
        /// </summary>
        public static void Save()
        {
            Directory.CreateDirectory("snapshots");
            DateTime now = DateTime.Now;
            string saveFileName = $"snapshots\\ptl-{now.Year}{now.Month}{now.Day}-{now.Hour}:{now.Minute}:{now.Second}.sql";

            try
            {
                if (!File.Exists("ptl.db"))
                {
                    File.Create("ptl.db").Close();
                }

                //Liste des commandes effectuée
                List<string> sqlCommands = new List<string>();

                //Insert les points dans la DB
                Action<(double, double), int> SavePoint = (t, i) =>
                {
                    string insertPointSql = $"INSERT INTO points (X, Y, Serie) VALUES ('{t.Item1}', '{t.Item2}', '{i}')";
                    SQLiteCommand insertPointCommand = new SQLiteCommand(insertPointSql, connection);
                    insertPointCommand.ExecuteNonQuery();
                    sqlCommands.Add(insertPointSql + ";");
                };

                //Insert les séries dans la DB
                Action<Serie> SaveSerie = s =>
                {
                    string insertSerieSql = $"INSERT INTO series (Id, Name, IsDisplayed, Color) VALUES ('{s.Id}', '{s.Name.ToString().Replace('\'', '"')}', '{s.IsDisplayed}', '{s.Color.ToStringRGBA()}')";
                    SQLiteCommand insertSerieCommand = new SQLiteCommand(insertSerieSql, connection);
                    insertSerieCommand.ExecuteNonQuery();

                    sqlCommands.Add(insertSerieSql + ";");

                    //Insert les points
                    List<(double, double)> values = s.XaxisValue.Zip(s.YaxisValue).ToList();
                    values.ForEach(x => SavePoint(x, s.Id));
                };

                connection.Open();
                new SQLiteCommand("DELETE FROM points", connection).ExecuteNonQuery();
                new SQLiteCommand("DELETE FROM series", connection).ExecuteNonQuery();

                Program.series.ForEach(s => SaveSerie(s));

                //Snapshot
                File.AppendAllLines(saveFileName, sqlCommands.ToArray());
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

        /// <summary>
        /// Change the serie IsDisplayed property in the database
        /// </summary>
        /// <param name="serie">The serie to update</param>
        public static void UpdateSerieCheck(Serie serie)
        {
            try
            {
                connection.Open();
                new SQLiteCommand($"UPDATE series SET IsDisplayed = '{serie.IsDisplayed}' WHERE Id = '{serie.Id}'", connection).ExecuteNonQuery();
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

        /// <summary>
        /// Change the serie color property in the database
        /// </summary>
        /// <param name="serie">The serie to update</param>
        public static void UpdateSerieColor(Serie serie)
        {
            try
            {
                connection.Open();
                new SQLiteCommand($"UPDATE series SET Color = '{serie.Color.ToStringRGBA()}' WHERE Id = '{serie.Id}'", connection).ExecuteNonQuery();
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

        /// <summary>
        /// Delete a serie from the database
        /// </summary>
        /// <param name="serie">The serie to delete</param>
        public static void DeleteSerie(Serie serie)
        {
            try
            {
                connection.Open();
                new SQLiteCommand($"DELETE FROM points WHERE Serie = '{serie.Id}'", connection).ExecuteNonQuery();
                new SQLiteCommand($"DELETE FROM series WHERE Id = '{serie.Id}'", connection).ExecuteNonQuery();
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
