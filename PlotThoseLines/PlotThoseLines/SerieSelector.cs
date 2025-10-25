using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace PlotThoseLines
{
    public partial class SerieSelector : UserControl
    {
        private Serie _serie;
        public event EventHandler SerieCheckedChanged;
        public event EventHandler SerieRemoved;
        public SerieSelector(Serie s)
        {
            this._serie = s;
            InitializeComponent();

            this.changeColorButton1.BindSerie(this._serie);
            this.checkBox1.Checked = this._serie.IsDisplayed;

            if (this._serie.XaxisValue.Count > 0)
            {
                this.label1.Text = this._serie.Name + " " + this._serie.XaxisValue.First() + " - " + this._serie.XaxisValue.Last();
            }

            this.checkBox1.CheckedChanged += CheckedChanged;
            this.changeColorButton1.ColorChanged += CheckedChanged;
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            Series.series.Where(s => s.Id == this._serie.Id).First().IsDisplayed = this.checkBox1.Checked;
            this._serie.IsDisplayed = this.checkBox1.Checked;
            SaveFile.UpdateSerieCheck(this._serie);
            SerieCheckedChanged.Invoke(this, new SerieEventArgs(_serie));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Voulez vous vraiment supprimmer la série {this._serie.Name + " " + this._serie.XaxisValue.First() + " - " + this._serie.XaxisValue.Last()} ?", "Confirmer la suppression", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Series.series.Remove(this._serie);
                SerieRemoved.Invoke(this, EventArgs.Empty);
                SaveFile.DeleteSerie(this._serie);
                this.Dispose();
            }
        }
    }
}
