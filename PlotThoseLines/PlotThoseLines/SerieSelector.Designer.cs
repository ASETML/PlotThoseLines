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
            checkBox = new CheckBox();
            changeColorButton = new ChangeColorButton();
            labelSerieName = new Label();
            buttonDelete = new Button();
            SuspendLayout();
            // 
            // checkBox
            // 
            checkBox.AutoSize = true;
            checkBox.Location = new Point(3, 11);
            checkBox.Name = "checkBox";
            checkBox.Size = new Size(18, 17);
            checkBox.TabIndex = 0;
            checkBox.UseVisualStyleBackColor = true;
            // 
            // changeColorButton
            // 
            changeColorButton.Location = new Point(253, 3);
            changeColorButton.Name = "changeColorButton";
            changeColorButton.Size = new Size(56, 30);
            changeColorButton.TabIndex = 1;
            changeColorButton.Text = "changeColorButton1";
            changeColorButton.UseVisualStyleBackColor = true;
            // 
            // labelSerieName
            // 
            labelSerieName.AutoSize = true;
            labelSerieName.Location = new Point(27, 8);
            labelSerieName.Name = "labelSerieName";
            labelSerieName.Size = new Size(52, 21);
            labelSerieName.TabIndex = 2;
            labelSerieName.Text = "label1";
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(315, 3);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(25, 30);
            buttonDelete.TabIndex = 3;
            buttonDelete.Text = "X";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += button1_Click;
            // 
            // SerieSelector
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonDelete);
            Controls.Add(labelSerieName);
            Controls.Add(changeColorButton);
            Controls.Add(checkBox);
            Name = "SerieSelector";
            Size = new Size(344, 38);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBox;
        private ChangeColorButton changeColorButton;
        private Label labelSerieName;
        private Button buttonDelete;
    }
}
