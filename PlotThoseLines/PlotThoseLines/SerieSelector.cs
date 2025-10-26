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
        public event EventHandler SerieChanged;
        public SerieSelector(Serie s)
        {
            this._serie = s;
            InitializeComponent();

            this.changeColorButton.BindSerie(this._serie);
            this.checkBox.Checked = this._serie.IsDisplayed;

            if (this._serie.XaxisValue.Count > 0)
            {
                this.labelSerieName.Text = this._serie.Name + " " + this._serie.XaxisValue.First() + " - " + this._serie.XaxisValue.Last();
            }

            this.checkBox.CheckedChanged += CheckedChanged;
            this.changeColorButton.ColorChanged += CheckedChanged;
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            Program.series.Where(s => s.Id == this._serie.Id).First().IsDisplayed = this.checkBox.Checked;
            this._serie.IsDisplayed = this.checkBox.Checked;
            SaveFile.UpdateSerieCheck(this._serie);
            SerieChanged.Invoke(this, EventArgs.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Voulez vous vraiment supprimmer la série {this._serie.Name + " " + this._serie.XaxisValue.First() + " - " + this._serie.XaxisValue.Last()} ?", "Confirmer la suppression", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Program.series.Remove(this._serie);
                SerieChanged.Invoke(this, EventArgs.Empty);
                SaveFile.DeleteSerie(this._serie);
                this.Dispose();
            }
        }
    }
}
