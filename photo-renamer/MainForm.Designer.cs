
namespace photo_renamer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.FilenamePatternLabel = new System.Windows.Forms.Label();
            this.FilenamePatternTextBox = new System.Windows.Forms.TextBox();
            this.DirectoryButton = new System.Windows.Forms.Button();
            this.DirectoryTextBox = new System.Windows.Forms.TextBox();
            this.OpenDirectoryDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.RenameButton = new System.Windows.Forms.Button();
            this.ProcessView = new System.Windows.Forms.ListView();
            this.OriginalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NewName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // FilenamePatternLabel
            // 
            this.FilenamePatternLabel.AutoSize = true;
            this.FilenamePatternLabel.Location = new System.Drawing.Point(12, 9);
            this.FilenamePatternLabel.Name = "FilenamePatternLabel";
            this.FilenamePatternLabel.Size = new System.Drawing.Size(86, 13);
            this.FilenamePatternLabel.TabIndex = 0;
            this.FilenamePatternLabel.Text = "Filename Pattern";
            // 
            // FilenamePatternTextBox
            // 
            this.FilenamePatternTextBox.Enabled = false;
            this.FilenamePatternTextBox.Location = new System.Drawing.Point(104, 6);
            this.FilenamePatternTextBox.Name = "FilenamePatternTextBox";
            this.FilenamePatternTextBox.Size = new System.Drawing.Size(453, 20);
            this.FilenamePatternTextBox.TabIndex = 1;
            this.FilenamePatternTextBox.Text = "YYYY-MM-DD hh.mm.ss";
            // 
            // DirectoryButton
            // 
            this.DirectoryButton.Location = new System.Drawing.Point(15, 41);
            this.DirectoryButton.Name = "DirectoryButton";
            this.DirectoryButton.Size = new System.Drawing.Size(83, 23);
            this.DirectoryButton.TabIndex = 2;
            this.DirectoryButton.Text = "Directory";
            this.DirectoryButton.UseVisualStyleBackColor = true;
            this.DirectoryButton.Click += new System.EventHandler(this.DirectoryButton_Click);
            // 
            // DirectoryTextBox
            // 
            this.DirectoryTextBox.Location = new System.Drawing.Point(104, 41);
            this.DirectoryTextBox.Name = "DirectoryTextBox";
            this.DirectoryTextBox.Size = new System.Drawing.Size(453, 20);
            this.DirectoryTextBox.TabIndex = 3;
            this.DirectoryTextBox.Text = "C:\\Users\\steve\\Desktop\\test pics";
            // 
            // RenameButton
            // 
            this.RenameButton.Location = new System.Drawing.Point(208, 88);
            this.RenameButton.Name = "RenameButton";
            this.RenameButton.Size = new System.Drawing.Size(109, 52);
            this.RenameButton.TabIndex = 4;
            this.RenameButton.Text = "Rename!";
            this.RenameButton.UseVisualStyleBackColor = true;
            this.RenameButton.Click += new System.EventHandler(this.RenameButton_Click);
            // 
            // ProcessView
            // 
            this.ProcessView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.OriginalName,
            this.NewName});
            this.ProcessView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProcessView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ProcessView.HideSelection = false;
            this.ProcessView.Location = new System.Drawing.Point(0, 146);
            this.ProcessView.Name = "ProcessView";
            this.ProcessView.Size = new System.Drawing.Size(565, 304);
            this.ProcessView.TabIndex = 5;
            this.ProcessView.UseCompatibleStateImageBehavior = false;
            this.ProcessView.View = System.Windows.Forms.View.Details;
            // 
            // OriginalName
            // 
            this.OriginalName.Text = "Original Name";
            this.OriginalName.Width = 250;
            // 
            // NewName
            // 
            this.NewName.Text = "New Name";
            this.NewName.Width = 250;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 450);
            this.Controls.Add(this.ProcessView);
            this.Controls.Add(this.RenameButton);
            this.Controls.Add(this.DirectoryTextBox);
            this.Controls.Add(this.DirectoryButton);
            this.Controls.Add(this.FilenamePatternTextBox);
            this.Controls.Add(this.FilenamePatternLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Photo Renamer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FilenamePatternLabel;
        private System.Windows.Forms.TextBox FilenamePatternTextBox;
        private System.Windows.Forms.Button DirectoryButton;
        private System.Windows.Forms.TextBox DirectoryTextBox;
        private System.Windows.Forms.FolderBrowserDialog OpenDirectoryDialog;
        private System.Windows.Forms.Button RenameButton;
        private System.Windows.Forms.ListView ProcessView;
        private System.Windows.Forms.ColumnHeader OriginalName;
        private System.Windows.Forms.ColumnHeader NewName;
    }
}

