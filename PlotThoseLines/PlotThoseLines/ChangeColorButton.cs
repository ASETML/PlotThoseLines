using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlotThoseLines
{
    partial class ChangeColorButton : Button
    {
        private Serie _serie;

        public ChangeColorButton()
        {
            InitializeComponent();
        }

        protected override void OnClick(EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            colorDialog.Color = this._serie.Color.ToSDColor();
            colorDialog.ShowDialog();

            Series.series.First(s => s.Id == this._serie.Id).ChangeColor(colorDialog.Color);
            this.BackColor = _serie.Color.ToSDColor();
            this.ForeColor = _serie.Color.ToSDColor();
        }

        public void BindSerie(Serie s)
        {
            this._serie = s;
            this.BackColor = _serie.Color.ToSDColor();
            this.ForeColor = _serie.Color.ToSDColor();
        }
    }
}