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
        private Serie _serie; //La série dont il faut changer la couleur
        public event EventHandler ColorChanged; //Evenement lorsque la couleur à été changéee

        public ChangeColorButton()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Open the color picker and change the serie color
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClick(EventArgs e)
        {
            //Color picker
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            colorDialog.Color = this._serie.Color.ToSDColor();
            colorDialog.ShowDialog();

            //Change la couleur de la série
            Program.series.First(s => s.Id == this._serie.Id).ChangeColor(colorDialog.Color);
            SaveFile.UpdateSerieColor(this._serie);

            //Change la couleur du bouton
            this.BackColor = _serie.Color.ToSDColor();
            this.ForeColor = _serie.Color.ToSDColor();
            ColorChanged.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Link a serie to this control
        /// </summary>
        /// <param name="s"></param>
        public void BindSerie(Serie s)
        {
            this._serie = s;
            this.BackColor = _serie.Color.ToSDColor();
            this.ForeColor = _serie.Color.ToSDColor();
        }
    }
}