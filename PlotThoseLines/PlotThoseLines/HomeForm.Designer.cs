namespace PlotThoseLines
{
    partial class HomeForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.plot = new ScottPlot.WinForms.FormsPlot();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnJoin = new System.Windows.Forms.Button();
            this.btnFunction = new System.Windows.Forms.Button();
            this.checkboxList = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // plot
            // 
            this.plot.DisplayScale = 1F;
            this.plot.Location = new System.Drawing.Point(437, 12);
            this.plot.Name = "plot";
            this.plot.Size = new System.Drawing.Size(645, 426);
            this.plot.TabIndex = 0;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(6, 386);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(131, 23);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "Importer / Restaurer";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // btnJoin
            // 
            this.btnJoin.Enabled = false;
            this.btnJoin.Location = new System.Drawing.Point(6, 415);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(75, 23);
            this.btnJoin.TabIndex = 2;
            this.btnJoin.Text = "Joindre";
            this.btnJoin.UseVisualStyleBackColor = true;
            // 
            // btnFunction
            // 
            this.btnFunction.Enabled = false;
            this.btnFunction.Location = new System.Drawing.Point(87, 415);
            this.btnFunction.Name = "btnFunction";
            this.btnFunction.Size = new System.Drawing.Size(50, 23);
            this.btnFunction.TabIndex = 3;
            this.btnFunction.Text = "f(x)";
            this.btnFunction.UseVisualStyleBackColor = true;
            // 
            // checkboxList
            // 
            this.checkboxList.AutoScroll = true;
            this.checkboxList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.checkboxList.Location = new System.Drawing.Point(6, 12);
            this.checkboxList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkboxList.Name = "checkboxList";
            this.checkboxList.Size = new System.Drawing.Size(426, 363);
            this.checkboxList.TabIndex = 6;
            this.checkboxList.WrapContents = false;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 450);
            this.Controls.Add(this.checkboxList);
            this.Controls.Add(this.btnFunction);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.plot);
            this.Name = "HomeForm";
            this.Text = "Plot Those Lines - Accueil";
            this.ResumeLayout(false);

        }

        #endregion

        private ScottPlot.WinForms.FormsPlot plot;
        private Button btnImport;
        private Button btnJoin;
        private Button btnFunction;
        private FlowLayoutPanel checkboxList;
    }
}
