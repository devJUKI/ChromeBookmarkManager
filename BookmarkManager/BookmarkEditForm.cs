using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BookmarkManager
{
    public partial class BookmarkEditForm : Form
    {
        private Folder bookmarkFolder;
        private List<Folder> bookmarkFolders;
        
        private Folder currentFolder;
        private Bookmark currentBookmark;
        private int currentFolderIdx;
        private int currentBookmarkIdx;

        public BookmarkEditForm(Folder bookmarkFolder) {
            InitializeComponent();
            this.bookmarkFolder = bookmarkFolder;
            currentBookmarkIdx = 0;
            currentFolderIdx = 0;
            currentFolder = bookmarkFolder;
            currentBookmark = currentFolder.Bookmarks[currentBookmarkIdx];

            bookmarkFolders = MyObjectEnumerator.Enumerate(bookmarkFolder).ToList();
        }

        private void BookmarkEditForm_Load(object sender, EventArgs e) {
            UpdateBookmarkInfo();
        }

        private void BookmarkEditForm_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Up) {
                e.SuppressKeyPress = true;

                currentFolder.Bookmarks.RemoveAt(currentBookmarkIdx);

                if (currentBookmarkIdx < currentFolder.Bookmarks.Count)
                    currentBookmark = currentFolder.Bookmarks[currentBookmarkIdx];
                else
                    UpdateCurrentBookmark();

                UpdateBookmarkInfo();
            }
            else if (e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true;

                currentBookmark.Name = nameTextBox1.Text;

                UpdateCurrentBookmark();
                UpdateBookmarkInfo();
            } else if (e.KeyCode == Keys.Escape) {
                e.SuppressKeyPress = true;

                string exportString = bookmarkFolder.GetExportString();
                File.WriteAllText("testas.html", exportString);

                Environment.Exit(0);
            }
        }

        private void UpdateBookmarkInfo() {
            progressLabel.Text = $"{currentFolder.Name} - {currentBookmarkIdx + 1} / {currentFolder.Bookmarks.Count}";
            currentName.Text = $"Current: {currentBookmark.Name}";
            nameTextBox1.Text = currentBookmark.Name;
            nameTextBox1.Select(nameTextBox1.Text.Length, 0);
        }

        private void UpdateCurrentBookmark() {
            currentBookmarkIdx++;

            // Go to next folder
            if (currentBookmarkIdx >= currentFolder.Bookmarks.Count) {
                currentBookmarkIdx = 0;

                // Folder may not contain bookmarks
                do {
                    currentFolderIdx++;
                    if (currentFolderIdx >= bookmarkFolders.Count) {
                        string exportString = bookmarkFolder.GetExportString();
                        File.WriteAllText("testas.html", exportString);

                        Environment.Exit(0);
                    }
                }
                while (bookmarkFolders[currentFolderIdx].Bookmarks.Count == 0);

                currentFolder = bookmarkFolders[currentFolderIdx];
            }

            currentBookmark = currentFolder.Bookmarks[currentBookmarkIdx];
        }

        private void OpenWebsiteBtn_Click(object sender, EventArgs e) {
            if (currentBookmark.IsWebsite)
                Process.Start(currentBookmark.URL);
        }
    }

    public static class MyObjectEnumerator
    {
        public static IEnumerable<Folder> Enumerate(Folder root) {
            yield return root;

            if (root.Folders != null) {
                foreach (Folder child in root.Folders) {
                    foreach (Folder grandchild in Enumerate(child)) {
                        yield return grandchild;
                    }
                }
            }
        }
    }
}