using ScottPlot;
using ScottPlot.AxisPanels;
using ScottPlot.Plottables;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PlotThoseLines
{
    partial class HomeForm : Form
    {
        //Find closest point to mouse
        //ScottPlot.Plottables.Scatter MyScatter;
        public HomeForm()
        {
            Series.series = new List<Serie>();
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

            double[] dataX = { 1, 2, 3, 4, 5 };
            double[] dataY = { 1, 4, 9, 16, 25 };

            double[] dx = { 1, 2, 3, 5, 50, -5 };
            double[] dy = { 10, 9, 8, 12, -10, 25 };

            //Series.series.Add(new Serie("1", dataX.ToList(), dataY.ToList()));
            //Series.series.Add(new Serie("2", dx.ToList(), dy.ToList()));

            PlotForm();

            //Binding à la checkbox seulement après ajout des données
            //((ListBox)this.checkedListBox1).DataSource = Series.series;
            ((ListBox)this.checkedListBox1).DisplayMember = "Name";
            ((ListBox)this.checkedListBox1).ValueMember = "IsDisplayed";
            checkedListBox1.Items.Add(new Serie("1", dataX.ToList(), dataY.ToList()));
            checkedListBox1.Items.Add(new Serie("2", dx.ToList(), dy.ToList()));
            var x = checkedListBox1.Items;

            //Coche les élèments par défaut https://stackoverflow.com/questions/7485631/winforms-how-to-bind-the-checkbox-item-of-a-checkedlistbox-with-databinding
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                Serie obj = (Serie)checkedListBox1.Items[i];
                checkedListBox1.SetItemChecked(i, obj.IsDisplayed);
            }
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

        private void PlotForm()
        {
            Series.series.Where(s => s.IsDisplayed && s.YaxisValue.Count > 0).ToList().ForEach(s => formsPlot1.Plot.Add.Scatter(s.XaxisValue, s.YaxisValue));
            formsPlot1.Plot.Axes.AutoScale();
            formsPlot1.Refresh();
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
    }
}
