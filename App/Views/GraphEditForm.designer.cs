namespace GraphEditor.App.Views
{
    partial class GraphEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавлениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свободноеПеремещениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьВершинуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьДугуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьВершинуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьДугуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьВесToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.конструкторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.zoomComboBox = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.добавлениеToolStripMenuItem,
            this.конструкторToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(787, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.закрытьToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.создатьToolStripMenuItem.Text = "Создать";
            this.создатьToolStripMenuItem.Click += new System.EventHandler(this.создатьToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Enabled = false;
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Enabled = false;
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // добавлениеToolStripMenuItem
            // 
            this.добавлениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.свободноеПеремещениеToolStripMenuItem,
            this.добавитьВершинуToolStripMenuItem,
            this.добавитьДугуToolStripMenuItem,
            this.удалитьВершинуToolStripMenuItem,
            this.удалитьДугуToolStripMenuItem,
            this.изменитьВесToolStripMenuItem});
            this.добавлениеToolStripMenuItem.Enabled = false;
            this.добавлениеToolStripMenuItem.Name = "добавлениеToolStripMenuItem";
            this.добавлениеToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.добавлениеToolStripMenuItem.Text = "Правка";
            // 
            // свободноеПеремещениеToolStripMenuItem
            // 
            this.свободноеПеремещениеToolStripMenuItem.Name = "свободноеПеремещениеToolStripMenuItem";
            this.свободноеПеремещениеToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.свободноеПеремещениеToolStripMenuItem.Text = "Свободное перемещение";
            this.свободноеПеремещениеToolStripMenuItem.Click += new System.EventHandler(this.свободноеПеремещениеToolStripMenuItem_Click);
            // 
            // добавитьВершинуToolStripMenuItem
            // 
            this.добавитьВершинуToolStripMenuItem.Name = "добавитьВершинуToolStripMenuItem";
            this.добавитьВершинуToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.добавитьВершинуToolStripMenuItem.Text = "Добавить вершину";
            this.добавитьВершинуToolStripMenuItem.Click += new System.EventHandler(this.добавитьВершинуToolStripMenuItem_Click);
            // 
            // добавитьДугуToolStripMenuItem
            // 
            this.добавитьДугуToolStripMenuItem.Name = "добавитьДугуToolStripMenuItem";
            this.добавитьДугуToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.добавитьДугуToolStripMenuItem.Text = "Добавить дугу";
            this.добавитьДугуToolStripMenuItem.Click += new System.EventHandler(this.добавитьДугуToolStripMenuItem_Click);
            // 
            // удалитьВершинуToolStripMenuItem
            // 
            this.удалитьВершинуToolStripMenuItem.Name = "удалитьВершинуToolStripMenuItem";
            this.удалитьВершинуToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.удалитьВершинуToolStripMenuItem.Text = "Удалить вершину";
            this.удалитьВершинуToolStripMenuItem.Click += new System.EventHandler(this.удалитьВершинуToolStripMenuItem_Click);
            // 
            // удалитьДугуToolStripMenuItem
            // 
            this.удалитьДугуToolStripMenuItem.Name = "удалитьДугуToolStripMenuItem";
            this.удалитьДугуToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.удалитьДугуToolStripMenuItem.Text = "Удалить дугу";
            this.удалитьДугуToolStripMenuItem.Click += new System.EventHandler(this.удалитьДугуToolStripMenuItem_Click);
            // 
            // изменитьВесToolStripMenuItem
            // 
            this.изменитьВесToolStripMenuItem.Name = "изменитьВесToolStripMenuItem";
            this.изменитьВесToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.изменитьВесToolStripMenuItem.Text = "Изменить вес";
            this.изменитьВесToolStripMenuItem.Click += new System.EventHandler(this.изменитьВесToolStripMenuItem_Click);
            // 
            // конструкторToolStripMenuItem
            // 
            this.конструкторToolStripMenuItem.Enabled = false;
            this.конструкторToolStripMenuItem.Name = "конструкторToolStripMenuItem";
            this.конструкторToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.конструкторToolStripMenuItem.Text = "Конструктор";
            this.конструкторToolStripMenuItem.Click += new System.EventHandler(this.конструкторToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 61);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(787, 462);
            this.tabControl1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.zoomComboBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(787, 37);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Масштаб:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "%";
            // 
            // zoomComboBox
            // 
            this.zoomComboBox.FormattingEnabled = true;
            this.zoomComboBox.Items.AddRange(new object[] {
            "25",
            "50",
            "75",
            "100",
            "150",
            "200"});
            this.zoomComboBox.Location = new System.Drawing.Point(73, 9);
            this.zoomComboBox.Name = "zoomComboBox";
            this.zoomComboBox.Size = new System.Drawing.Size(70, 21);
            this.zoomComboBox.TabIndex = 0;
            this.zoomComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // GraphEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 523);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GraphEditForm";
            this.Text = "GraphEdit";
            this.Load += new System.EventHandler(this.GraphEditForm_Load);
            this.ResizeBegin += new System.EventHandler(this.GraphEditForm_ResizeBegin);
            this.Resize += new System.EventHandler(this.GraphEditForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem добавлениеToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem добавитьВершинуToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem добавитьДугуToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem удалитьВершинуToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem удалитьДугуToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem изменитьВесToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem свободноеПеремещениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem конструкторToolStripMenuItem;
        private System.Windows.Forms.ComboBox zoomComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;

    }
}

