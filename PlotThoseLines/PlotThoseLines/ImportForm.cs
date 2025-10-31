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
        private string _filename; //Le nom du fichier à importer
        private string _savefilename; //Le nom du fichier à restaurer
        public event EventHandler SeriesImported; //Evenement pour indiquer que les séries ont été importée
        public ImportForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Import an excel file
        /// </summary>
        /// <returns>true if success, else false</returns>
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
                    //Première ligne du fichier: années des séries
                    List<Double> XaxisValue = table.Rows[0].ItemArray.ToList().Skip(1).Select(x => double.Parse(x.ToString())).ToList();

                    //Pour chaque ligne
                    foreach (DataRow row in table.Rows)
                    {
                        //Nom de la série
                        Serie s = new Serie(row[0].ToString(), XaxisValue, new List<double>());

                        //Pour chaque colonne
                        foreach (DataColumn col in table.Columns)
                        {
                            //Si ce n'est pas le nom de la série
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

                    //On enlève les 2 premières séries (en-tête et vide) et les deux dernières (vide et copyright)
                    Program.series.AddRange(importedSeries.Skip(2).SkipLast(2).ToList());

                    //Si deux séries ont le même nom et nombre d'élèment, on garde la dernière série ajoutée
                    Program.series = Program.series.GroupBy(s => s.Name + s.YaxisValue.Count).Select(s => s.Last()).ToList();

                    //On sauvegarde les données dans la DB
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

        /// <summary>
        /// Open the FileDialog to select the file to import
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Start the file import
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonImport_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_filename))
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
            else
            {
                this.labelError.Text = "Merci de choisir un fichier à importer";
            }
        }

        /// <summary>
        /// Open the FileDialog to select the file to restore
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Restore the selected file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRestore_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_savefilename))
            {
                //Spinner de chargement
                LoadingModal loader = new LoadingModal();
                loader.Show();

                //Supprimemr les séries existantes de la mémoire et de la DB
                Program.series.Clear();
                string connectionString = "Data Source=ptl.db;Version=3;";
                SQLiteConnection connection = new SQLiteConnection(connectionString);
                connection.Open();

                new SQLiteCommand("DELETE FROM points", connection).ExecuteNonQuery();
                new SQLiteCommand("DELETE FROM series", connection).ExecuteNonQuery();

                //Executer chaque commande du dump
                string[] importSql = File.ReadAllLines(this._savefilename);

                importSql.ToList().ForEach(x => Trace.WriteLine(x));
                importSql.ToList().ForEach(x => new SQLiteCommand(x, connection).ExecuteNonQuery());
                SaveFile.Load();
                connection.Close();

                loader.Close();

                SeriesImported.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            this.labelError.Text = "Merci de choisir un fichier à restaurer";
        }

        /// <summary>
        /// Close this forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
