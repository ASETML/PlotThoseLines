using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Data.SQLite;

namespace PlotThoseLines
{
    public partial class ImportForm : Form
    {
        private string _filename;
        public ImportForm()
        {
            InitializeComponent();
        }

        private bool ImportFile()
        {
            if (!File.Exists("ptl.db"))
            {
                File.Create("ptl.db").Close();
            }
            string connectionString = "Data Source=ptl.db;Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            Directory.CreateDirectory("snapshots");
            DateTime now = DateTime.Now;
            string x = $"snapshots\\ptl-{now.Year}-{now.Month}-{now.Day}-{now.Hour}-{now.Minute}-{now.Second}.db";
            File.Copy("ptl.db", x);

            try
            {
                connection.Open();
                Console.WriteLine("Connected to SQLite!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            string createSeriesTableSql = "CREATE TABLE IF NOT EXISTS series (Id INTEGER PRIMARY KEY, Name TEXT, IsDisplayed BOOLEAN, Color TEXT)";
            string createPointsTableSql = "CREATE TABLE IF NOT EXISTS points (X FLOAT, Y FLOAT, Serie INTEGER, FOREIGN KEY(Serie) REFERENCES series(Id))";

            SQLiteCommand createSeriesTableCommand = new SQLiteCommand(createSeriesTableSql, connection);
            SQLiteCommand createPointsTableCommand = new SQLiteCommand(createPointsTableSql, connection);

            try
            {
                connection.Open();
                createSeriesTableCommand.ExecuteNonQuery();
                createPointsTableCommand.ExecuteNonQuery();
                //insertCommand.ExecuteNonQuery();
                Console.WriteLine("Table created and data inserted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            try
            {
                FileStream stream = File.Open(this._filename, FileMode.Open, FileAccess.Read);

                IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                try
                {
                    DataSet content = reader.AsDataSet();
                    DataTable table = content.Tables[0];

                    List<Serie> importedSeries = new List<Serie>();

                    //DataRow et DataColumn ne supportes pas le .ForEach
                    // On all tables' rows
                    List<Double> XaxisValue = table.Rows[0].ItemArray.ToList().Skip(1).Select(x => double.Parse(x.ToString())).ToList();
                    foreach (DataRow row in table.Rows)
                    {
                        Serie s = new Serie(row[0].ToString(), XaxisValue, new List<double>());
                        // On all tables' columns
                        foreach (DataColumn col in table.Columns)
                        {
                            if (col.Ordinal != 0)
                            {

                                var cell = row[col].ToString();
                                if (cell != "")
                                {
                                    if (cell != "no data")
                                    {
                                        s.YaxisValue.Add(double.Parse(cell));
                                    }
                                    else
                                    {
                                        s.YaxisValue.Add(0);
                                    }
                                }
                            }

                        }
                        importedSeries.Add(s);
                    }

                    Series.series.AddRange(importedSeries.Skip(2).SkipLast(2).ToList());

                    Action<(double, double), int> SavePoint = (t, i) =>
                    {
                        string insertPointSql = "INSERT INTO points (X, Y, Serie) VALUES (@x, @y, @serie)";
                        SQLiteCommand insertPointCommand = new SQLiteCommand(insertPointSql, connection);
                        insertPointCommand.Parameters.AddWithValue("@x", t.Item1);
                        insertPointCommand.Parameters.AddWithValue("@y", t.Item2);
                        insertPointCommand.Parameters.AddWithValue("@serie", i);
                        insertPointCommand.ExecuteNonQuery();
                    };

                    Action<Serie> SaveSerie = s =>
                    {
                        string insertSerieSql = "INSERT INTO series (Id, Name, IsDisplayed, Color) VALUES (@id, @name, @display, @color)";
                        SQLiteCommand insertSerieCommand = new SQLiteCommand(insertSerieSql, connection);
                        insertSerieCommand.Parameters.AddWithValue("@id", s.Id);
                        insertSerieCommand.Parameters.AddWithValue("@name", s.Name);
                        insertSerieCommand.Parameters.AddWithValue("@display", s.IsDisplayed);
                        insertSerieCommand.Parameters.AddWithValue("@color", s.Color.ToStringRGBA());
                        insertSerieCommand.ExecuteNonQuery();

                        List<(double, double)> values = s.XaxisValue.Zip(s.YaxisValue).ToList();
                        values.ForEach(x => SavePoint(x, s.Id));
                    };

                    connection.Open();
                    Series.series.ForEach(s => SaveSerie(s));
                    connection.Close();

                    reader.Close();
                    stream.Close();
                    return true;
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e);
                    reader.Close();
                    stream.Close();
                    return false;
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                return false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool success = ImportFile();
            if (success)
            {
                this.Close();
            }
            else
            {
                this.errorLabel.Text = "Erreur lors de l'import du fichier: mauvais format de fichier";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "All files (*.*)|*.*|Excel files (*.xls)|*.xls";
            openFileDialog.FilterIndex = 2;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                this._filename = openFileDialog.FileName;
            }

            this.label3.Text = String.IsNullOrEmpty(this._filename) ? "Choisir un fichier" : this._filename;
        }
    }
}
