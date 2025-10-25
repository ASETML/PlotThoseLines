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
            flowLayoutPanel1.Controls.Clear();
            Series.series.ForEach(s => flowLayoutPanel1.Controls.Add(new SerieSelector(s)));
            foreach (SerieSelector s in flowLayoutPanel1.Controls)
            {
                s.SerieCheckedChanged += GotFocus;
                s.SerieRemoved += SerieRemoved;
            }
            PlotForm();
        }

        /// <summary>
        /// Reload the form when it get Focus -> for example, when the ImportForm is Closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GotFocus(object sender, EventArgs e)
        {
            PlotForm();
        }

        public void PlotForm()
        {
            formsPlot1.Plot.Clear();
            Series.series.Where(s => s.IsDisplayed && s.YaxisValue.Count > 0).ToList().ForEach(s => formsPlot1.Plot.Add.Scatter(s.XaxisValue, s.YaxisValue, s.Color));
            formsPlot1.Plot.Axes.AutoScale();
            formsPlot1.Refresh();
        }

        private void SerieRemoved(object sender, EventArgs e)
        {
            PlotForm();
            SaveFile.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImportForm importForm = new ImportForm();
            importForm.SeriesImported += GotFocus;
            importForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JunctionForm junctionForm = new JunctionForm();
            junctionForm.Show();
        }
    }
}
