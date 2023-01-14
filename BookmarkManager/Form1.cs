using System;
using System.IO;
using System.Windows.Forms;

namespace BookmarkManager
{
    public partial class Form1 : Form
    {
        private string filePath;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void SelectFileBtn_Click(object sender, EventArgs e) {
            // TODO: Check if Chrome's bookmark file can only be html
            // and add filters after that

            using (OpenFileDialog ofd = new OpenFileDialog()) {
                if (ofd.ShowDialog() == DialogResult.OK) {
                    filePath = ofd.FileName;
                    filePathLabel.Text = filePath;
                }
            }
        }

        private void ConfirmFileBtn_Click(object sender, EventArgs e) {
            Hide();

            string[] lines = File.ReadAllLines(filePath);
            Folder root = new Folder().Parse(lines);

            new BookmarkEditForm(root).Show();
        }
    }
}
