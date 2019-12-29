namespace DroBoUpload
{
    partial class DroBoUpload
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DroBoUpload));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAccessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signWithCodeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.labelPleaseAu = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSign = new System.Windows.Forms.Button();
            this.textToken = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.textFolderName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Highlight;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.uploadToolStripMenuItem,
            this.downloadToolStripMenuItem,
            this.newFolderToolStripMenuItem,
            this.addAccessToolStripMenuItem,
            this.signWithCodeToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1285, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(62, 29);
            this.loginToolStripMenuItem.Text = "Sign";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // uploadToolStripMenuItem
            // 
            this.uploadToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            this.uploadToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
            this.uploadToolStripMenuItem.Text = "Upload";
            this.uploadToolStripMenuItem.Click += new System.EventHandler(this.uploadToolStripMenuItem_Click);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(114, 29);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // newFolderToolStripMenuItem
            // 
            this.newFolderToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
            this.newFolderToolStripMenuItem.Size = new System.Drawing.Size(122, 29);
            this.newFolderToolStripMenuItem.Text = "New folder";
            this.newFolderToolStripMenuItem.Click += new System.EventHandler(this.newFolderToolStripMenuItem_Click);
            // 
            // addAccessToolStripMenuItem
            // 
            this.addAccessToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.addAccessToolStripMenuItem.Name = "addAccessToolStripMenuItem";
            this.addAccessToolStripMenuItem.Size = new System.Drawing.Size(122, 29);
            this.addAccessToolStripMenuItem.Text = "Add access";
            this.addAccessToolStripMenuItem.Click += new System.EventHandler(this.addAccessToolStripMenuItem_Click);
            // 
            // signWithCodeToolStripMenuItem1
            // 
            this.signWithCodeToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.Window;
            this.signWithCodeToolStripMenuItem1.Name = "signWithCodeToolStripMenuItem1";
            this.signWithCodeToolStripMenuItem1.Size = new System.Drawing.Size(155, 29);
            this.signWithCodeToolStripMenuItem1.Text = "Sign with code";
            this.signWithCodeToolStripMenuItem1.Click += new System.EventHandler(this.signWithCodeToolStripMenuItem1_Click);
            // 
            // labelPleaseAu
            // 
            this.labelPleaseAu.AutoSize = true;
            this.labelPleaseAu.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelPleaseAu.ForeColor = System.Drawing.SystemColors.Window;
            this.labelPleaseAu.Location = new System.Drawing.Point(15, 54);
            this.labelPleaseAu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPleaseAu.Name = "labelPleaseAu";
            this.labelPleaseAu.Size = new System.Drawing.Size(376, 25);
            this.labelPleaseAu.TabIndex = 2;
            this.labelPleaseAu.Text = "Remember! You must authorize yourself!";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.buttonSign);
            this.panel1.Controls.Add(this.textToken);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(736, 50);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(527, 78);
            this.panel1.TabIndex = 3;
            this.panel1.Visible = false;
            // 
            // buttonSign
            // 
            this.buttonSign.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonSign.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSign.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonSign.Location = new System.Drawing.Point(348, 36);
            this.buttonSign.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSign.Name = "buttonSign";
            this.buttonSign.Size = new System.Drawing.Size(175, 38);
            this.buttonSign.TabIndex = 6;
            this.buttonSign.Text = "Sign";
            this.buttonSign.UseVisualStyleBackColor = false;
            this.buttonSign.Click += new System.EventHandler(this.buttonSign_Click);
            // 
            // textToken
            // 
            this.textToken.Location = new System.Drawing.Point(111, 4);
            this.textToken.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textToken.Name = "textToken";
            this.textToken.Size = new System.Drawing.Size(411, 22);
            this.textToken.TabIndex = 5;
            this.textToken.Text = "Your key...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(20, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Token:";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(20, 138);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(621, 429);
            this.listBox1.TabIndex = 4;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "insert name";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "insert name";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(20, 578);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1248, 28);
            this.progressBar1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonCreate);
            this.panel2.Controls.Add(this.textFolderName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(17, 86);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(584, 42);
            this.panel2.TabIndex = 6;
            this.panel2.Visible = false;
            // 
            // buttonCreate
            // 
            this.buttonCreate.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonCreate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonCreate.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonCreate.Location = new System.Drawing.Point(409, 0);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(175, 38);
            this.buttonCreate.TabIndex = 7;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = false;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // textFolderName
            // 
            this.textFolderName.Location = new System.Drawing.Point(149, 6);
            this.textFolderName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textFolderName.Name = "textFolderName";
            this.textFolderName.Size = new System.Drawing.Size(247, 22);
            this.textFolderName.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(-1, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Folder name:";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(661, 138);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(27, 25);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(608, 423);
            this.webBrowser1.TabIndex = 7;
            this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser1_Navigated);
            // 
            // DroBoUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(1285, 622);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelPleaseAu);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DroBoUpload";
            this.Text = "DroBoUpload Manager";
            this.Load += new System.EventHandler(this.DroBoUpload_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.Label labelPleaseAu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSign;
        private System.Windows.Forms.TextBox textToken;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripMenuItem newFolderToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.TextBox textFolderName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStripMenuItem signWithCodeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addAccessToolStripMenuItem;
    }
}

