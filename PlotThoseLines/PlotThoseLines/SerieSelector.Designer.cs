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
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.changeColorButton = new PlotThoseLines.ChangeColorButton();
            this.labelSerieName = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(2, 8);
            this.checkBox.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(15, 14);
            this.checkBox.TabIndex = 0;
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // changeColorButton
            // 
            this.changeColorButton.Location = new System.Drawing.Point(367, 4);
            this.changeColorButton.Margin = new System.Windows.Forms.Padding(2);
            this.changeColorButton.Name = "changeColorButton";
            this.changeColorButton.Size = new System.Drawing.Size(28, 21);
            this.changeColorButton.TabIndex = 1;
            this.changeColorButton.Text = "changeColorButton1";
            this.changeColorButton.UseVisualStyleBackColor = true;
            // 
            // labelSerieName
            // 
            this.labelSerieName.AutoSize = true;
            this.labelSerieName.Location = new System.Drawing.Point(21, 6);
            this.labelSerieName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSerieName.Name = "labelSerieName";
            this.labelSerieName.Size = new System.Drawing.Size(38, 15);
            this.labelSerieName.TabIndex = 2;
            this.labelSerieName.Text = "label1";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(399, 4);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(19, 21);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "X";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // SerieSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.labelSerieName);
            this.Controls.Add(this.changeColorButton);
            this.Controls.Add(this.checkBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SerieSelector";
            this.Size = new System.Drawing.Size(420, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox checkBox;
        private ChangeColorButton changeColorButton;
        private Label labelSerieName;
        private Button buttonDelete;
    }
}
