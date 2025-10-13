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
            Directory.CreateDirectory("snapshots");
            DateTime now = DateTime.Now;
            string x = $"snapshots\\ptl-{now.Year}-{now.Month}-{now.Day}-{now.Hour}-{now.Minute}-{now.Second}.db";
            Trace.WriteLine(File.Exists("ptl.db") + x);
            File.Copy("ptl.db", x);
            string connectionString = "Data Source=ptl.db;Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);

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
            string createPointsTableSql = "CREATE TABLE IF NOT EXISTS points (Id INTEGER PRIMARY KEY, X FLOAT, Y FLOAT, Serie INTEGER, FOREIGN KEY(Serie) REFERENCES series(Id))";

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

                    Action<Serie> SaveSerie = s =>
                    {
                        string insertSql = "INSERT INTO series (Id, Name, IsDisplayed, Color) VALUES (@id, @name, @display, @color)";
                        SQLiteCommand insertCommand = new SQLiteCommand(insertSql, connection);
                        insertCommand.Parameters.AddWithValue("@id", s.Id);
                        insertCommand.Parameters.AddWithValue("@name", s.Name);
                        insertCommand.Parameters.AddWithValue("@display", s.IsDisplayed);
                        insertCommand.Parameters.AddWithValue("@color", s.Color.ToStringRGBA());
                        insertCommand.ExecuteNonQuery();
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
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                this._filename = openFileDialog.FileName;
            }

            this.label3.Text = String.IsNullOrEmpty(this._filename) ? "Choisir un fichier" : this._filename;
        }
    }
}
