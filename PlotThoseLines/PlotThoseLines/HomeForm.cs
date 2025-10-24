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
        //Find closest point to mouse
        //ScottPlot.Plottables.Scatter MyScatter;
        public HomeForm()
        {
            Series.series = new List<Serie>();
            SaveFile.Load();
            timer_refresh = new System.Windows.Forms.Timer();
            timer_refresh.Interval = 250;
            timer_refresh.Tick += timer_refresh_Tick;
            timer_refresh.Start();

            Series.series.Add(new Serie("s1", new List<double> { 1, 2, 3, 4 }, new List<double> { 4, 5, 6, 7 }));

            InitializeComponent();

            /*ScottPlot.Plottables.Crosshair MyCrosshair = formsPlot1.Plot.Add.Crosshair(0, 0);
            MyCrosshair.IsVisible = false;
            MyCrosshair.MarkerShape = MarkerShape.OpenCircle;
            MyCrosshair.MarkerSize = 15;

            formsPlot1.MouseMove += (s, e) =>
            {
                Pixel mousePixel = new(e.Location.X, e.Location.Y);
                Coordinates mouseLocation = formsPlot1.Plot.GetCoordinates(mousePixel);
                if (formsPlot1.Plot.PlottableList.Count !> 0)
                {
                    DataPoint nearest = MyScatter.Data.GetNearest(mouseLocation, formsPlot1.Plot.LastRender);
                    // place the crosshair over the highlighted point
                    if (nearest.IsReal)
                    {
                        MyCrosshair.IsVisible = true;
                        MyCrosshair.Position = nearest.Coordinates;
                        formsPlot1.Refresh();
                        Text = $"Selected Index={nearest.Index}, X={nearest.X:0.##}, Y={nearest.Y:0.##}";
                    }

                    // hide the crosshair when no point is selected
                    if (!nearest.IsReal && MyCrosshair.IsVisible)
                    {
                        MyCrosshair.IsVisible = false;
                        formsPlot1.Refresh();
                        Text = $"No point selected";
                    }
                }
            };*/

            PlotForm();
        }

        /// <summary>
        /// Reload the form when it get Focus -> for example, when the ImportForm is Closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GotFocus(object sender, EventArgs e)
        {
            //TODO: stocker la dernière liste importée: si elle est différente, recharger le plot, sinon rien
            PlotForm();
        }

        public void PlotForm()
        {
            formsPlot1.Plot.Clear();
            Series.series.Where(s => s.IsDisplayed && s.YaxisValue.Count > 0).ToList().ForEach(s => formsPlot1.Plot.Add.Scatter(s.XaxisValue, s.YaxisValue, s.Color));
            //formsPlot1.Plot.Axes.AutoScale();
            formsPlot1.Refresh();
            //TEMP
            flowLayoutPanel1.Controls.Clear();
            Series.series.ForEach(s => flowLayoutPanel1.Controls.Add(new SerieSelector(s)));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImportForm importForm = new ImportForm();
            importForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JunctionForm junctionForm = new JunctionForm();
            junctionForm.Show();
        }

        private void timer_refresh_Tick(object sender, EventArgs e)
        {
            Trace.WriteLine(DateTime.Now.ToString());
            PlotForm();
        }
    }
}
