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
            menuStrip1.Size = new Size(800, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(80, 29);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // серверToolStripMenuItem
            // 
            серверToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { запуститьToolStripMenuItem, остановитьToolStripMenuItem });
            серверToolStripMenuItem.Name = "серверToolStripMenuItem";
            серверToolStripMenuItem.Size = new Size(89, 29);
            серверToolStripMenuItem.Text = "Сервер";
            серверToolStripMenuItem.Click += серверToolStripMenuItem_Click;
            // 
            // запуститьToolStripMenuItem
            // 
            запуститьToolStripMenuItem.Name = "запуститьToolStripMenuItem";
            запуститьToolStripMenuItem.Size = new Size(209, 34);
            запуститьToolStripMenuItem.Text = "Запустить";
            запуститьToolStripMenuItem.Click += запуститьToolStripMenuItem_Click;
            // 
            // остановитьToolStripMenuItem
            // 
            остановитьToolStripMenuItem.Name = "остановитьToolStripMenuItem";
            остановитьToolStripMenuItem.Size = new Size(209, 34);
            остановитьToolStripMenuItem.Text = "Остановить";
            // 
            // textBox1
            // 
            textBox1.HideSelection = false;
            textBox1.Location = new Point(0, 36);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 0;
            textBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
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
