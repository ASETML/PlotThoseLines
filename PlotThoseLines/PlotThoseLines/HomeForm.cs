using System.Diagnostics;

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

            //Binding à la checkbox seulement après ajout des données
            ((ListBox)this.checkedListBox1).DataSource = series;
            ((ListBox)this.checkedListBox1).DisplayMember = "Name";
            ((ListBox)this.checkedListBox1).ValueMember = "IsDisplayed";

            foreach (var s in checkedListBox1.Items)
            {
                Trace.WriteLine(s);
            }

            //Coche les élèments par défaut https://stackoverflow.com/questions/7485631/winforms-how-to-bind-the-checkbox-item-of-a-checkedlistbox-with-databinding
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                Serie obj = (Serie)checkedListBox1.Items[i];
                checkedListBox1.SetItemChecked(i, obj.IsDisplayed);
            }
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
