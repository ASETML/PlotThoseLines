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
using System.Reflection.Metadata.Ecma335;
using System.Data.SQLite;
using OpenTK.Graphics.ES11;

namespace PlotThoseLines
{
    public partial class ImportForm : Form
    {
        private string _filename;
        private string _savefilename;
        public event EventHandler SeriesImported;
        public ImportForm()
        {
            InitializeComponent();
        }

        private bool ImportFile()
        {
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
                                string cell = row[col].ToString();
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

                    Program.series.AddRange(importedSeries.Skip(2).SkipLast(2).ToList());
                    Program.series = Program.series.GroupBy(s => s.Name + s.YaxisValue.Count).Select(s => s.Last()).ToList();

                    SaveFile.Save();

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

        private void buttonImportFile_Click(object sender, EventArgs e)
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

            this.labeImportFile.Text = String.IsNullOrEmpty(this._filename) ? "Choisir un fichier" : this._filename;
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            bool success = ImportFile();
            if (success)
            {
                SeriesImported.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            else
            {
                this.labelError.Text = "Erreur lors de l'import du fichier: mauvais format de fichier";
            }
        }

        private void buttonRestoreFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "/snapshots";
            openFileDialog.Filter = "All files (*.*)|*.*|Sql files (*.sql)|*.sql";
            openFileDialog.FilterIndex = 2;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                this._savefilename = openFileDialog.FileName;
            }

            this.labelRestoreFile.Text = String.IsNullOrEmpty(this._savefilename) ? "Choisir un fichier" : this._savefilename;
        }

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            LoadingModal loader = new LoadingModal();
            loader.Show();

            Program.series.Clear();
            string connectionString = "Data Source=ptl.db;Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            new SQLiteCommand("DELETE FROM points", connection).ExecuteNonQuery();
            new SQLiteCommand("DELETE FROM series", connection).ExecuteNonQuery();

            string[] importSql = File.ReadAllLines(this._savefilename);

            importSql.ToList().ForEach(x => Trace.WriteLine(x));
            importSql.ToList().ForEach(x => new SQLiteCommand(x, connection).ExecuteNonQuery());
            SaveFile.Load();
            connection.Close();

            loader.Close();

            SeriesImported.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
