namespace Lab3_NT
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        [Obsolete]
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            выходToolStripMenuItem = new ToolStripMenuItem();
            серверToolStripMenuItem = new ToolStripMenuItem();
            запуститьToolStripMenuItem = new ToolStripMenuItem();
            остановитьToolStripMenuItem = new ToolStripMenuItem();
            textBox1 = new TextBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { выходToolStripMenuItem, серверToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(4, 1, 0, 1);
            menuStrip1.Size = new Size(560, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(54, 22);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // серверToolStripMenuItem
            // 
            серверToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { запуститьToolStripMenuItem, остановитьToolStripMenuItem });
            серверToolStripMenuItem.Name = "серверToolStripMenuItem";
            серверToolStripMenuItem.Size = new Size(59, 22);
            серверToolStripMenuItem.Text = "Сервер";
            // 
            // запуститьToolStripMenuItem
            // 
            запуститьToolStripMenuItem.Name = "запуститьToolStripMenuItem";
            запуститьToolStripMenuItem.Size = new Size(138, 22);
            запуститьToolStripMenuItem.Text = "Запустить";
            запуститьToolStripMenuItem.Click += запуститьToolStripMenuItem_Click;
            // 
            // остановитьToolStripMenuItem
            // 
            остановитьToolStripMenuItem.Name = "остановитьToolStripMenuItem";
            остановитьToolStripMenuItem.Size = new Size(138, 22);
            остановитьToolStripMenuItem.Text = "Остановить";
            // 
            // textBox1
            // 
            textBox1.HideSelection = false;
            textBox1.Location = new Point(0, 22);
            textBox1.Margin = new Padding(2, 2, 2, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(106, 23);
            textBox1.TabIndex = 0;
            textBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(textBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2, 2, 2, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem серверToolStripMenuItem;
        private ToolStripMenuItem запуститьToolStripMenuItem;
        private ToolStripMenuItem остановитьToolStripMenuItem;
        private TextBox textBox1;
    }
}
