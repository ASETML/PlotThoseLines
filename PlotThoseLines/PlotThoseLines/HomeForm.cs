using ScottPlot.AxisPanels;
using System.Diagnostics;

namespace PlotThoseLines
{
    partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();

            /*double[] dataX = { 1, 2, 3, 4, 5 };
            double[] dataY = { 1, 4, 9, 16, 25 };

            double[] dx = { 1, 2, 3, 5, 50, -5 };
            double[] dy = { 10, 9, 8, 12, -10, 25 };

            Series.AddSerie(new Serie("1", dataX.ToList(), dataY.ToList()));
            Series.AddSerie(new Serie("2", dx.ToList(), dy.ToList()));

            PlotForm();

            //Binding à la checkbox seulement après ajout des données
            ((ListBox)this.checkedListBox1).DataSource = Series.GetSeries();
            ((ListBox)this.checkedListBox1).DisplayMember = "Name";
            ((ListBox)this.checkedListBox1).ValueMember = "IsDisplayed";

            //Coche les élèments par défaut https://stackoverflow.com/questions/7485631/winforms-how-to-bind-the-checkbox-item-of-a-checkedlistbox-with-databinding
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                Serie obj = (Serie)checkedListBox1.Items[i];
                checkedListBox1.SetItemChecked(i, obj.IsDisplayed);
            }*/
        }

        private void PlotForm()
        {
            Series.GetSeries().ForEach(s => formsPlot1.Plot.Add.Scatter(s.XaxisValue, s.YaxisValue));
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

        private void button4_Click(object sender, EventArgs e)
        {
            PlotForm();
        }
    }
}
