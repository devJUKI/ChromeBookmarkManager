namespace BookmarkManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SelectFileBtn = new Guna.UI2.WinForms.Guna2Button();
            this.filePathLabel = new System.Windows.Forms.Label();
            this.ConfirmFileBtn = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("LEMON MILK", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(38, 12);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(333, 31);
            this.guna2HtmlLabel1.TabIndex = 1;
            this.guna2HtmlLabel1.Text = "Chrome Bookmark Manager";
            // 
            // SelectFileBtn
            // 
            this.SelectFileBtn.AutoRoundedCorners = true;
            this.SelectFileBtn.BorderRadius = 19;
            this.SelectFileBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SelectFileBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SelectFileBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SelectFileBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SelectFileBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SelectFileBtn.ForeColor = System.Drawing.Color.White;
            this.SelectFileBtn.Location = new System.Drawing.Point(129, 116);
            this.SelectFileBtn.Name = "SelectFileBtn";
            this.SelectFileBtn.Size = new System.Drawing.Size(150, 40);
            this.SelectFileBtn.TabIndex = 2;
            this.SelectFileBtn.Text = "Select file";
            this.SelectFileBtn.Click += new System.EventHandler(this.SelectFileBtn_Click);
            // 
            // filePathLabel
            // 
            this.filePathLabel.AutoEllipsis = true;
            this.filePathLabel.Location = new System.Drawing.Point(12, 85);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(384, 23);
            this.filePathLabel.TabIndex = 3;
            this.filePathLabel.Text = "Choose your Chrome bookmarks file";
            this.filePathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConfirmFileBtn
            // 
            this.ConfirmFileBtn.AutoRoundedCorners = true;
            this.ConfirmFileBtn.BorderRadius = 19;
            this.ConfirmFileBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ConfirmFileBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ConfirmFileBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ConfirmFileBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ConfirmFileBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ConfirmFileBtn.ForeColor = System.Drawing.Color.White;
            this.ConfirmFileBtn.Location = new System.Drawing.Point(129, 186);
            this.ConfirmFileBtn.Name = "ConfirmFileBtn";
            this.ConfirmFileBtn.Size = new System.Drawing.Size(150, 40);
            this.ConfirmFileBtn.TabIndex = 4;
            this.ConfirmFileBtn.Text = "Confirm";
            this.ConfirmFileBtn.Click += new System.EventHandler(this.ConfirmFileBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 281);
            this.Controls.Add(this.ConfirmFileBtn);
            this.Controls.Add(this.filePathLabel);
            this.Controls.Add(this.SelectFileBtn);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chrome Bookmark Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button SelectFileBtn;
        private System.Windows.Forms.Label filePathLabel;
        private Guna.UI2.WinForms.Guna2Button ConfirmFileBtn;
    }
}

