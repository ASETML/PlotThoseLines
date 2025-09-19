namespace PlotThoseLines
{
    public partial class HomeForm : Form
    {
        List<Serie> series = new List<Serie>();

        public HomeForm()
        {
            InitializeComponent();

            double[] dataX = { 1, 2, 3, 4, 5 };
            double[] dataY = { 1, 4, 9, 16, 25 };

            double[] dx = { 1, 2, 3, 5, 50, -5 };
            double[] dy = { 10, 9, 8, 12, -10, 25 };

            series.Add(new Serie("1", dataX, dataY));
            series.Add(new Serie("2", dx, dy));
            PlotForm();

            formsPlot1.Plot.Add.Scatter(dataX, dataY);
            formsPlot1.Plot.Add.Scatter(dx, dy);

        }

        private void PlotForm()
        {
            series.ForEach(s => formsPlot1.Plot.Add.Scatter(s.XaxisValue, s.YaxisValue));
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
