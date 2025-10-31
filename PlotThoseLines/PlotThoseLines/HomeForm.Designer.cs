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
            plot = new ScottPlot.WinForms.FormsPlot();
            btnImport = new Button();
            btnJoin = new Button();
            btnFunction = new Button();
            checkboxList = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // plot
            // 
            plot.DisplayScale = 1F;
            plot.Location = new Point(437, 12);
            plot.Name = "plot";
            plot.Size = new Size(645, 426);
            plot.TabIndex = 0;
            // 
            // btnImport
            // 
            btnImport.Location = new Point(6, 386);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(131, 23);
            btnImport.TabIndex = 1;
            btnImport.Text = "Importer / Restaurer";
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += btnImport_Click;
            // 
            // btnJoin
            // 
            btnJoin.Enabled = false;
            btnJoin.Location = new Point(6, 415);
            btnJoin.Name = "btnJoin";
            btnJoin.Size = new Size(75, 23);
            btnJoin.TabIndex = 2;
            btnJoin.Text = "Joindre";
            btnJoin.UseVisualStyleBackColor = true;
            btnJoin.Click += btnJoin_Click;
            // 
            // btnFunction
            // 
            btnFunction.Enabled = false;
            btnFunction.Location = new Point(87, 415);
            btnFunction.Name = "btnFunction";
            btnFunction.Size = new Size(50, 23);
            btnFunction.TabIndex = 3;
            btnFunction.Text = "f(x)";
            btnFunction.UseVisualStyleBackColor = true;
            // 
            // checkboxList
            // 
            checkboxList.AutoScroll = true;
            checkboxList.FlowDirection = FlowDirection.TopDown;
            checkboxList.Location = new Point(6, 12);
            checkboxList.Margin = new Padding(2);
            checkboxList.Name = "checkboxList";
            checkboxList.Size = new Size(426, 363);
            checkboxList.TabIndex = 6;
            checkboxList.WrapContents = false;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1091, 450);
            Controls.Add(checkboxList);
            Controls.Add(btnFunction);
            Controls.Add(btnJoin);
            Controls.Add(btnImport);
            Controls.Add(plot);
            Name = "HomeForm";
            Text = "Plot Those Lines - Accueil";
            ResumeLayout(false);

        }

        #endregion

        private ScottPlot.WinForms.FormsPlot plot;
        private Button btnImport;
        private Button btnJoin;
        private Button btnFunction;
        private FlowLayoutPanel checkboxList;
    }
}
