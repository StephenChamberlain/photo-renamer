using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace photo_renamer
{
    public partial class MainForm : Form, IRenamerCallback
    {
        private readonly string pattern = @"\d{4}-\d{2}-\d{2} \d{2}.\d{2}.\d{2}";
        private readonly string datetimePattern = "yyyy-MM-dd hh.mm.ss";
        private readonly string logFileDatetimePattern = "yyyy-MM-dd_hh-mm-ss";

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
                Renamer renamer = new Renamer(pattern, datetimePattern, this);
                renamer.ProcessDirectory(DirectoryTextBox.Text);
                WriteLog();
            }
        }

        void IRenamerCallback.AddProcessViewItem(string originalName, string newName)
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
