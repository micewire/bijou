
using System.ComponentModel;

/// SO SORRY for the bad, unorganised, confusing-variable-names code, i literally made this in
/// like an hour just to fix my need of this specific software.
namespace Bijou
{
    partial class NoteWindow
    {
        private System.ComponentModel.IContainer components = null;


        #region Windows Form Designer generated code


        private void InitializeComponent()
        {
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(NoteWindow));
            textBox1 = new TextBox();
            panel1 = new Panel();
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            selectFontToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            fontDialog1 = new FontDialog();
            panel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.AcceptsReturn = true;
            textBox1.AcceptsTab = true;
            textBox1.AllowDrop = true;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Dock = DockStyle.Fill;
            textBox1.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(0, 0);
            textBox1.Margin = new Padding(5);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Write something, dechuwa!";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(304, 144);
            textBox1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(textBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(304, 144);
            panel1.TabIndex = 1;
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Bijou";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { selectFontToolStripMenuItem, exitToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(133, 48);
            // 
            // selectFontToolStripMenuItem
            // 
            selectFontToolStripMenuItem.Name = "selectFontToolStripMenuItem";
            selectFontToolStripMenuItem.Size = new Size(132, 22);
            selectFontToolStripMenuItem.Text = "Select Font";
            selectFontToolStripMenuItem.Click += selectFontToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(132, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // fontDialog1
            // 
            fontDialog1.ShowColor = true;
            // 
            // NoteWindow
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 144);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(320, 180);
            Name = "NoteWindow";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Bijou";
            TopMost = true;
            Load += NoteWindow_Load_1;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                SaveTextToFile();
                this.Hide();
            }
        }

        private void SaveTextToFile()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(docPath, "bijou.txt");

            File.WriteAllText(filePath, textBox1.Text);
        }


        private void NoteWindow_Load_1(object sender, EventArgs e)
        {
            AdjustWindowPosition();
            LoadTextFromFile();
            LoadFontSetting();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Visible = !Visible;
            AdjustWindowPosition();
        }

        private void selectFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = textBox1.Font;
            fontDialog1.Color = textBox1.ForeColor;
            fontDialog1.ShowDialog();
            textBox1.Font = fontDialog1.Font;
            textBox1.ForeColor = fontDialog1.Color;
            SaveFontSetting();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AdjustWindowPosition()
        {
            Rectangle screenBounds = Screen.PrimaryScreen.Bounds;
            Rectangle workArea = Screen.PrimaryScreen.WorkingArea;

            int x = 0, y = 0;

            
            if (workArea.Top > screenBounds.Top)
            {
                x = workArea.Right - this.Width - 10; 
                y = workArea.Top + 10;
            }
            else if (workArea.Left > screenBounds.Left) 
            {
                x = workArea.Left + 10;
                y = workArea.Bottom - this.Height - 10; 
            }
            else if (workArea.Right < screenBounds.Right) 
            {
                x = workArea.Right - this.Width - 10;
                y = workArea.Bottom - this.Height - 10;
            }
            else 
            {
                x = workArea.Right - this.Width - 10; 
                y = workArea.Bottom - this.Height - 10;
            }

            this.Location = new Point(x, y);
        }

        private void LoadTextFromFile()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(docPath, "bijou.txt");

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "Write something, dechuwa~!");
            }

            textBox1.Text = File.ReadAllText(filePath);
        }

        private void SaveFontSetting()
        {
            Properties.Settings.Default.SavedFont = textBox1.Font;
            Properties.Settings.Default.SavedColor = textBox1.ForeColor;
            Properties.Settings.Default.Save();
        }

        private void LoadFontSetting()
        {
            if (Properties.Settings.Default.SavedFont != null)
            {
                textBox1.Font = Properties.Settings.Default.SavedFont;
            }

            textBox1.ForeColor = Properties.Settings.Default.SavedColor;
            
        }
        #endregion

        private TextBox textBox1;
        private Panel panel1;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem selectFontToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private FontDialog fontDialog1;
      
    }
}