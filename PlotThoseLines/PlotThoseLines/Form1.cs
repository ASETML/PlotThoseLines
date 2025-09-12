namespace PlotThoseLines
{
    public partial class Form1 : Form
    {

        public Form1()
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
    }
}
