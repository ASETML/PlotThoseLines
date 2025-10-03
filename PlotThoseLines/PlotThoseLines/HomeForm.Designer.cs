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
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            checkedListBox1 = new CheckedListBox();
            SuspendLayout();
            // 
            // formsPlot1
            // 
            formsPlot1.DisplayScale = 1F;
            formsPlot1.Location = new Point(143, 12);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(645, 426);
            formsPlot1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(6, 386);
            button1.Name = "button1";
            button1.Size = new Size(131, 23);
            button1.TabIndex = 1;
            button1.Text = "Importer / Restaurer";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(6, 415);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Joindre";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new Point(87, 415);
            button3.Name = "button3";
            button3.Size = new Size(50, 23);
            button3.TabIndex = 3;
            button3.Text = "f(x)";
            button3.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(6, 12);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(131, 364);
            checkedListBox1.TabIndex = 4;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(checkedListBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(formsPlot1);
            Name = "HomeForm";
            Text = "Plot Those Lines - Accueil";
            Activated += GotFocus;
            ResumeLayout(false);
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private Button button1;
        private Button button2;
        private Button button3;
        private CheckedListBox checkedListBox1;
    }
}
