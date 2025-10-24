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
            components = new System.ComponentModel.Container();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            timer_refresh = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // formsPlot1
            // 
            formsPlot1.DisplayScale = 1F;
            formsPlot1.Location = new Point(372, 17);
            formsPlot1.Margin = new Padding(4);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(829, 596);
            formsPlot1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(8, 540);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(168, 32);
            button1.TabIndex = 1;
            button1.Text = "Importer / Restaurer";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(8, 581);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(96, 32);
            button2.TabIndex = 2;
            button2.Text = "Joindre";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new Point(112, 581);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(64, 32);
            button3.TabIndex = 3;
            button3.Text = "f(x)";
            button3.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(8, 17);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(357, 508);
            flowLayoutPanel1.TabIndex = 6;
            flowLayoutPanel1.WrapContents = false;
            // 
            // timer_refresh
            // 
            timer_refresh.Tick += timer_refresh_Tick;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1198, 630);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(formsPlot1);
            Margin = new Padding(4);
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
        private FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Timer timer_refresh;
    }
}
