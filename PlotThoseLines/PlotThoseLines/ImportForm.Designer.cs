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
            labelImport = new Label();
            labelRestore = new Label();
            buttonImport = new Button();
            buttonRestore = new Button();
            buttonClose = new Button();
            labeImportFile = new Label();
            labelError = new Label();
            buttonImportFile = new Button();
            buttonRestoreFile = new Button();
            labelRestoreFile = new Label();
            SuspendLayout();
            // 
            // labelImport
            // 
            labelImport.AutoSize = true;
            labelImport.Location = new Point(39, 34);
            labelImport.Margin = new Padding(4, 0, 4, 0);
            labelImport.Name = "labelImport";
            labelImport.Size = new Size(162, 21);
            labelImport.TabIndex = 0;
            labelImport.Text = "Importer des données";
            // 
            // labelRestore
            // 
            labelRestore.AutoSize = true;
            labelRestore.Location = new Point(553, 34);
            labelRestore.Margin = new Padding(4, 0, 4, 0);
            labelRestore.Name = "labelRestore";
            labelRestore.Size = new Size(245, 21);
            labelRestore.TabIndex = 1;
            labelRestore.Text = "Importer un fichier de sauvegarde";
            // 
            // buttonImport
            // 
            buttonImport.Location = new Point(66, 120);
            buttonImport.Margin = new Padding(4);
            buttonImport.Name = "buttonImport";
            buttonImport.Size = new Size(96, 32);
            buttonImport.TabIndex = 2;
            buttonImport.Text = "Importer";
            buttonImport.UseVisualStyleBackColor = true;
            buttonImport.Click += buttonImport_Click;
            // 
            // buttonRestore
            // 
            buttonRestore.Location = new Point(612, 120);
            buttonRestore.Margin = new Padding(4);
            buttonRestore.Name = "buttonRestore";
            buttonRestore.Size = new Size(96, 32);
            buttonRestore.TabIndex = 3;
            buttonRestore.Text = "Restaurer";
            buttonRestore.UseVisualStyleBackColor = true;
            buttonRestore.Click += buttonRestore_Click;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(15, 581);
            buttonClose.Margin = new Padding(4);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(96, 32);
            buttonClose.TabIndex = 4;
            buttonClose.Text = "Retour";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // labeImportFile
            // 
            labeImportFile.AutoSize = true;
            labeImportFile.Location = new Point(66, 77);
            labeImportFile.Margin = new Padding(4, 0, 4, 0);
            labeImportFile.Name = "labeImportFile";
            labeImportFile.Size = new Size(128, 21);
            labeImportFile.TabIndex = 5;
            labeImportFile.Text = "Choisir un fichier";
            labeImportFile.Click += buttonImportFile_Click;
            // 
            // labelError
            // 
            labelError.AutoSize = true;
            labelError.Location = new Point(414, 368);
            labelError.Margin = new Padding(4, 0, 4, 0);
            labelError.Name = "labelError";
            labelError.Size = new Size(0, 21);
            labelError.TabIndex = 7;
            // 
            // buttonImportFile
            // 
            buttonImportFile.BackgroundImage = Properties.Resources.folder_solid_full_small;
            buttonImportFile.Location = new Point(23, 71);
            buttonImportFile.Margin = new Padding(4);
            buttonImportFile.Name = "buttonImportFile";
            buttonImportFile.Size = new Size(35, 32);
            buttonImportFile.TabIndex = 8;
            buttonImportFile.UseVisualStyleBackColor = true;
            buttonImportFile.Click += buttonImportFile_Click;
            // 
            // buttonRestoreFile
            // 
            buttonRestoreFile.BackgroundImage = Properties.Resources.folder_solid_full_small;
            buttonRestoreFile.Location = new Point(569, 71);
            buttonRestoreFile.Margin = new Padding(4);
            buttonRestoreFile.Name = "buttonRestoreFile";
            buttonRestoreFile.Size = new Size(35, 32);
            buttonRestoreFile.TabIndex = 10;
            buttonRestoreFile.UseVisualStyleBackColor = true;
            buttonRestoreFile.Click += buttonRestoreFile_Click;
            // 
            // labelRestoreFile
            // 
            labelRestoreFile.AutoSize = true;
            labelRestoreFile.Location = new Point(612, 77);
            labelRestoreFile.Margin = new Padding(4, 0, 4, 0);
            labelRestoreFile.Name = "labelRestoreFile";
            labelRestoreFile.Size = new Size(128, 21);
            labelRestoreFile.TabIndex = 9;
            labelRestoreFile.Text = "Choisir un fichier";
            labelRestoreFile.Click += buttonRestoreFile_Click;
            // 
            // ImportForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 630);
            Controls.Add(buttonRestoreFile);
            Controls.Add(labelRestoreFile);
            Controls.Add(buttonImportFile);
            Controls.Add(labelError);
            Controls.Add(labeImportFile);
            Controls.Add(buttonClose);
            Controls.Add(buttonRestore);
            Controls.Add(buttonImport);
            Controls.Add(labelRestore);
            Controls.Add(labelImport);
            Margin = new Padding(4);
            Name = "ImportForm";
            Text = "ImportForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelImport;
        private Label labelRestore;
        private Button buttonImport;
        private Button buttonRestore;
        private Button buttonClose;
        private Label labeImportFile;
        private Label labelError;
        private Button buttonImportFile;
        private Button buttonRestoreFile;
        private Label labelRestoreFile;
    }
}