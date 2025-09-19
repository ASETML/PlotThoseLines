namespace PlotThoseLines
{
    public partial class HomeForm : Form
    {

        public HomeForm()
        {
            InitializeComponent();

            double[] dataX = { 1, 2, 3, 4, 5 };
            double[] dataY = { 1, 4, 9, 16, 25 };

            double[] dx = { 1, 2, 3, 5, 50 };
            double[] dy = { 10, 9, 8, 12, -10 };

            formsPlot1.Plot.Add.Scatter(dataX, dataY);
            formsPlot1.Plot.Add.Scatter(dx, dy);

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
