namespace PlotThoseLines
{
    partial class SerieSelector
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            checkBox1 = new CheckBox();
            changeColorButton1 = new ChangeColorButton();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(3, 11);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(18, 17);
            checkBox1.TabIndex = 0;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // changeColorButton1
            // 
            changeColorButton1.Location = new Point(253, 3);
            changeColorButton1.Name = "changeColorButton1";
            changeColorButton1.Size = new Size(56, 30);
            changeColorButton1.TabIndex = 1;
            changeColorButton1.Text = "changeColorButton1";
            changeColorButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 8);
            label1.Name = "label1";
            label1.Size = new Size(52, 21);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // button1
            // 
            button1.Location = new Point(315, 3);
            button1.Name = "button1";
            button1.Size = new Size(25, 30);
            button1.TabIndex = 3;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = true;
            // 
            // SerieSelector
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(changeColorButton1);
            Controls.Add(checkBox1);
            Name = "SerieSelector";
            Size = new Size(344, 38);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBox1;
        private ChangeColorButton changeColorButton1;
        private Label label1;
        private Button button1;
    }
}
