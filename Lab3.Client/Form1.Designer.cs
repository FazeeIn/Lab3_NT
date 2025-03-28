namespace Lab3.Client
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
            соединениеToolStripMenuItem = new ToolStripMenuItem();
            подключитьсяToolStripMenuItem = new ToolStripMenuItem();
            отключитьсяToolStripMenuItem = new ToolStripMenuItem();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { выходToolStripMenuItem, соединениеToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(4, 1, 0, 1);
            menuStrip1.Size = new Size(560, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(54, 22);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // соединениеToolStripMenuItem
            // 
            соединениеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { подключитьсяToolStripMenuItem, отключитьсяToolStripMenuItem });
            соединениеToolStripMenuItem.Name = "соединениеToolStripMenuItem";
            соединениеToolStripMenuItem.Size = new Size(86, 22);
            соединениеToolStripMenuItem.Text = "Соединение";
            // 
            // подключитьсяToolStripMenuItem
            // 
            подключитьсяToolStripMenuItem.Name = "подключитьсяToolStripMenuItem";
            подключитьсяToolStripMenuItem.Size = new Size(156, 22);
            подключитьсяToolStripMenuItem.Text = "Подключиться";
            подключитьсяToolStripMenuItem.Click += подключитьсяToolStripMenuItem_Click;
            // 
            // отключитьсяToolStripMenuItem
            // 
            отключитьсяToolStripMenuItem.Name = "отключитьсяToolStripMenuItem";
            отключитьсяToolStripMenuItem.Size = new Size(156, 22);
            отключитьсяToolStripMenuItem.Text = "Отключиться";
            отключитьсяToolStripMenuItem.Click += отключитьсяToolStripMenuItem_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(0, 22);
            textBox1.Margin = new Padding(2);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(553, 219);
            textBox1.TabIndex = 1;
            textBox1.TabStop = false;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(0, 242);
            textBox2.Margin = new Padding(2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(470, 23);
            textBox2.TabIndex = 1;
            textBox2.KeyDown += textBox2_KeyDown;
            // 
            // button1
            // 
            button1.Location = new Point(473, 242);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(78, 23);
            button1.TabIndex = 2;
            button1.Text = "Отправить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2);
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
        private ToolStripMenuItem соединениеToolStripMenuItem;
        private ToolStripMenuItem подключитьсяToolStripMenuItem;
        private ToolStripMenuItem отключитьсяToolStripMenuItem;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
    }
}
