using System;
using System.IO;
using System.Text.RegularExpressions;

namespace photo_renamer
{
    interface IRenamerCallback
    {
        void AddProcessViewItem(string originalName, string newName);
    }

    class Renamer
    {
        private readonly string pattern;
        private readonly string datetimePattern;
        private readonly IRenamerCallback callback;

        public Renamer(string pattern, string datetimePattern, IRenamerCallback callback)
        {
            this.pattern = pattern;
            this.datetimePattern = datetimePattern;
            this.callback = callback;
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

                callback.AddProcessViewItem(path, newName);
            }
            else
            {
                callback.AddProcessViewItem(path, "<rename unnecessary>");
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

            while (File.Exists(newPath))
            {
                // Apparently the file already exists; log in the process view and add 1 to the name
                newName = File.GetLastWriteTime(path).ToString(datetimePattern) + "(" + fileExistsCounter + ")" + extension;
                callback.AddProcessViewItem(newPath, "Already exists, trying " + newName);
                newPath = Path.Combine(parentDirectory.FullName, newName);
                fileExistsCounter++;
            }

            return newPath;
        }
    }
}
