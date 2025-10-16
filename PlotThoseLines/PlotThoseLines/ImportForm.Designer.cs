namespace PlotThoseLines
{
    partial class ImportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label3 = new Label();
            errorLabel = new Label();
            button4 = new Button();
            button5 = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 34);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(162, 21);
            label1.TabIndex = 0;
            label1.Text = "Importer des données";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(553, 34);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(245, 21);
            label2.TabIndex = 1;
            label2.Text = "Importer un fichier de sauvegarde";
            // 
            // button1
            // 
            button1.Location = new Point(66, 120);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(96, 32);
            button1.TabIndex = 2;
            button1.Text = "Importer";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(612, 120);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(96, 32);
            button2.TabIndex = 3;
            button2.Text = "Restaurer";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(15, 581);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(96, 32);
            button3.TabIndex = 4;
            button3.Text = "Retour";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(66, 77);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(128, 21);
            label3.TabIndex = 5;
            label3.Text = "Choisir un fichier";
            label3.Click += button4_Click;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.Location = new Point(414, 368);
            errorLabel.Margin = new Padding(4, 0, 4, 0);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(0, 21);
            errorLabel.TabIndex = 7;
            // 
            // button4
            // 
            button4.BackgroundImage = Properties.Resources.folder_solid_full_small;
            button4.Location = new Point(23, 71);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Size = new Size(35, 32);
            button4.TabIndex = 8;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackgroundImage = Properties.Resources.folder_solid_full_small;
            button5.Location = new Point(569, 71);
            button5.Margin = new Padding(4);
            button5.Name = "button5";
            button5.Size = new Size(35, 32);
            button5.TabIndex = 10;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(612, 77);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(128, 21);
            label4.TabIndex = 9;
            label4.Text = "Choisir un fichier";
            // 
            // ImportForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 630);
            Controls.Add(button5);
            Controls.Add(label4);
            Controls.Add(button4);
            Controls.Add(errorLabel);
            Controls.Add(label3);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4);
            Name = "ImportForm";
            Text = "ImportForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label3;
        private Label errorLabel;
        private Button button4;
        private Button button5;
        private Label label4;
    }
}