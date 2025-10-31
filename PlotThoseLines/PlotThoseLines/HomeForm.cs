using ScottPlot;
using ScottPlot.AxisPanels;
using ScottPlot.Plottables;
using System.Data.SQLite;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PlotThoseLines
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            //Chargement des séries depuis le fichier de sauvegarde
            Program.series = new List<Serie>();
            SaveFile.Load();

            InitializeComponent();

            //Affichage des données
            InstanciateCheckboxList();
            PlotForm();
        }

        /// <summary>
        /// Bind every serie to a SerieSelector and add it to the list
        /// </summary>
        private void InstanciateCheckboxList()
        {
            checkboxList.Controls.Clear();
            Program.series.ForEach(s => checkboxList.Controls.Add(new SerieSelector(s)));
            //On écoute l'évènement pour recharger le graphique lorsqu'une série est modifier (checkbox et/ou couleur)
            foreach (SerieSelector s in checkboxList.Controls)
            {
                s.SerieChanged += SerieChanged;
            }
        }

        /// <summary>
        /// Plot the graph when new series have been imported
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeriesImported(object sender, EventArgs e)
        {
            InstanciateCheckboxList();
            PlotForm();
            plot.Plot.Axes.AutoScale();
            plot.Refresh();
        }

        /// <summary>
        /// Display the series on the plot
        /// </summary>
        public void PlotForm()
        {
            plot.Plot.Clear();
            //Affiche seulement les series qui ont des valeurs et qui sont cochées
            Program.series.Where(s => s.IsDisplayed && s.YaxisValue.Count > 0).ToList().ForEach(s => plot.Plot.Add.Scatter(s.XaxisValue, s.YaxisValue, s.Color));
            plot.Refresh();
        }

        /// <summary>
        /// Plot the form when a serie has been shown/hidden, its color was changed or it was deleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerieChanged(object sender, EventArgs e)
        {
            PlotForm();
        }

        /// <summary>
        /// Open the import form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            ImportForm importForm = new ImportForm();
            importForm.SeriesImported += SeriesImported;
            importForm.Show();
        }

        /// <summary>
        /// Open the join form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJoin_Click(object sender, EventArgs e)
        {
            JunctionForm junctionForm = new JunctionForm();
            junctionForm.Show();
        }
    }
}
