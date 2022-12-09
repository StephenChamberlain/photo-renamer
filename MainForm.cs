using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace photo_renamer
{
    public partial class MainForm : Form
    {
        private string pattern = @"\d{4}-\d{2}-\d{2} \d{2}.\d{2}.\d{2}";
        private string datetimePattern = "yyyy-MM-dd hh.mm.ss";
        private string logFileDatetimePattern = "yyyy-MM-dd_hh-mm-ss";

        public MainForm()
        {
            InitializeComponent();
        }

        private void DirectoryButton_Click(object sender, EventArgs e)
        {
            if (OpenDirectoryDialog.ShowDialog() == DialogResult.OK)
            {
                ProcessView.Items.Clear();
                DirectoryTextBox.Text = OpenDirectoryDialog.SelectedPath;                
            }
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(DirectoryTextBox.Text))
            {
                ProcessDirectory(DirectoryTextBox.Text);
                WriteLog();
            }
        }

        public void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                ProcessFile(fileName);
            }

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
            {
                ProcessDirectory(subdirectory);
            }
        }

        public void ProcessFile(string path)
        {
            var originalName = Path.GetFileName(path);

            if (NeedsRenaming(originalName))
            {
                var newName = GetNewPath(path);
                
                System.IO.File.Move(path, newName);

                AddProcessViewItem(path, newName);
            } 
            else
            {
                AddProcessViewItem(path, "<rename unnecessary>");
            }
        }

        private bool NeedsRenaming(string originalName)
        {
            var nameWithoutExtension = originalName.Substring(0, originalName.LastIndexOf("."));
            return !Regex.IsMatch(nameWithoutExtension, pattern, RegexOptions.IgnoreCase);            
        }

        private string GetNewPath(string path)
        {
            string originalName = Path.GetFileName(path);            
            var extension = originalName.Substring(originalName.LastIndexOf("."));
            var parentDirectory = Directory.GetParent(path);
            var newName = File.GetLastWriteTime(path).ToString(datetimePattern) + extension;
            var newPath = Path.Combine(parentDirectory.FullName, newName);
            int fileExistsCounter = 1;

            while(File.Exists(newPath))
            {
                // Apparently the file already exists; log in the process view and add 1 to the name
                newName = File.GetLastWriteTime(path).ToString(datetimePattern) + "(" + fileExistsCounter + ")" + extension;
                AddProcessViewItem(newPath, "Already exists, trying " + newName);
                newPath = Path.Combine(parentDirectory.FullName, newName);
                fileExistsCounter++;
            }

            return newPath;
        }

        private void AddProcessViewItem(String originalName, string newName)
        {
            string[] properties = new string[2];
            properties[0] = originalName;
            properties[1] = newName;
            ListViewItem item = new ListViewItem(properties);
            ProcessView.Items.Add(item);
        }

        private void WriteLog()
        {
            var listViewItems = string.Join("\n", from item in ProcessView.Items.Cast<ListViewItem>()
                             select item.Text + @" -> " + item.SubItems[1].Text
            );

            string[] content = new string[2];
            content[0] = "Photo renamer log, ran at " + DateTime.Now + "\n\n";
            content[1] = listViewItems;

            var logFilePath = DateTime.Now.ToString(logFileDatetimePattern) + "-photo-renamer.log";
            Console.WriteLine("Log file: " + logFilePath);
            File.WriteAllLines(logFilePath, content);
        }
    }
}
