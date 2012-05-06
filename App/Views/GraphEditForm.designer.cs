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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphEditForm));
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.zoomComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.moveRadioButton = new System.Windows.Forms.RadioButton();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.addVertexRadioButton = new System.Windows.Forms.RadioButton();
            this.addArcRadioButton = new System.Windows.Forms.RadioButton();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.removeVertexRadioButton = new System.Windows.Forms.RadioButton();
            this.removeArcRadioButton = new System.Windows.Forms.RadioButton();
            this.changeWeightRadioButton = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
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
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.создатьToolStripMenuItem.Text = "Создать";
            this.создатьToolStripMenuItem.Click += new System.EventHandler(this.создатьToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Enabled = false;
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Enabled = false;
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
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
            this.добавлениеToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.добавлениеToolStripMenuItem.Text = "Правка";
            // 
            // свободноеПеремещениеToolStripMenuItem
            // 
            this.свободноеПеремещениеToolStripMenuItem.Name = "свободноеПеремещениеToolStripMenuItem";
            this.свободноеПеремещениеToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.свободноеПеремещениеToolStripMenuItem.Text = "Свободное перемещение";
            this.свободноеПеремещениеToolStripMenuItem.Click += new System.EventHandler(this.свободноеПеремещениеToolStripMenuItem_Click);
            // 
            // добавитьВершинуToolStripMenuItem
            // 
            this.добавитьВершинуToolStripMenuItem.Name = "добавитьВершинуToolStripMenuItem";
            this.добавитьВершинуToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.добавитьВершинуToolStripMenuItem.Text = "Добавить вершину";
            this.добавитьВершинуToolStripMenuItem.Click += new System.EventHandler(this.добавитьВершинуToolStripMenuItem_Click);
            // 
            // добавитьДугуToolStripMenuItem
            // 
            this.добавитьДугуToolStripMenuItem.Name = "добавитьДугуToolStripMenuItem";
            this.добавитьДугуToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.добавитьДугуToolStripMenuItem.Text = "Добавить дугу";
            this.добавитьДугуToolStripMenuItem.Click += new System.EventHandler(this.добавитьДугуToolStripMenuItem_Click);
            // 
            // удалитьВершинуToolStripMenuItem
            // 
            this.удалитьВершинуToolStripMenuItem.Name = "удалитьВершинуToolStripMenuItem";
            this.удалитьВершинуToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.удалитьВершинуToolStripMenuItem.Text = "Удалить вершину";
            this.удалитьВершинуToolStripMenuItem.Click += new System.EventHandler(this.удалитьВершинуToolStripMenuItem_Click);
            // 
            // удалитьДугуToolStripMenuItem
            // 
            this.удалитьДугуToolStripMenuItem.Name = "удалитьДугуToolStripMenuItem";
            this.удалитьДугуToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.удалитьДугуToolStripMenuItem.Text = "Удалить дугу";
            this.удалитьДугуToolStripMenuItem.Click += new System.EventHandler(this.удалитьДугуToolStripMenuItem_Click);
            // 
            // изменитьВесToolStripMenuItem
            // 
            this.изменитьВесToolStripMenuItem.Name = "изменитьВесToolStripMenuItem";
            this.изменитьВесToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.изменитьВесToolStripMenuItem.Text = "Изменить вес";
            this.изменитьВесToolStripMenuItem.Click += new System.EventHandler(this.изменитьВесToolStripMenuItem_Click);
            // 
            // конструкторToolStripMenuItem
            // 
            this.конструкторToolStripMenuItem.Enabled = false;
            this.конструкторToolStripMenuItem.Name = "конструкторToolStripMenuItem";
            this.конструкторToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
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
            this.tabControl1.Location = new System.Drawing.Point(0, 62);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(787, 461);
            this.tabControl1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(787, 38);
            this.panel1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.zoomComboBox);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(787, 38);
            this.splitContainer1.SplitterDistance = 169;
            this.splitContainer1.TabIndex = 7;
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
            this.zoomComboBox.Location = new System.Drawing.Point(73, 10);
            this.zoomComboBox.Name = "zoomComboBox";
            this.zoomComboBox.Size = new System.Drawing.Size(70, 21);
            this.zoomComboBox.TabIndex = 0;
            this.zoomComboBox.Text = "100";
            this.zoomComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Масштаб:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "%";
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.moveRadioButton);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(614, 38);
            this.splitContainer2.SplitterDistance = 36;
            this.splitContainer2.TabIndex = 0;
            // 
            // moveRadioButton
            // 
            this.moveRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.moveRadioButton.AutoSize = true;
            this.moveRadioButton.BackColor = System.Drawing.SystemColors.Control;
            this.moveRadioButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("moveRadioButton.BackgroundImage")));
            this.moveRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.moveRadioButton.Checked = true;
            this.moveRadioButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.moveRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Blue;
            this.moveRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveRadioButton.Location = new System.Drawing.Point(3, 6);
            this.moveRadioButton.Name = "moveRadioButton";
            this.moveRadioButton.Size = new System.Drawing.Size(28, 25);
            this.moveRadioButton.TabIndex = 6;
            this.moveRadioButton.TabStop = true;
            this.moveRadioButton.Text = "   ";
            this.moveRadioButton.UseVisualStyleBackColor = false;
            this.moveRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.addVertexRadioButton);
            this.splitContainer3.Panel1.Controls.Add(this.addArcRadioButton);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(574, 38);
            this.splitContainer3.SplitterDistance = 71;
            this.splitContainer3.TabIndex = 1;
            // 
            // addVertexRadioButton
            // 
            this.addVertexRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.addVertexRadioButton.AutoSize = true;
            this.addVertexRadioButton.BackColor = System.Drawing.SystemColors.Control;
            this.addVertexRadioButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addVertexRadioButton.BackgroundImage")));
            this.addVertexRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addVertexRadioButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.addVertexRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Blue;
            this.addVertexRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addVertexRadioButton.Location = new System.Drawing.Point(3, 6);
            this.addVertexRadioButton.Name = "addVertexRadioButton";
            this.addVertexRadioButton.Size = new System.Drawing.Size(28, 25);
            this.addVertexRadioButton.TabIndex = 4;
            this.addVertexRadioButton.Text = "   ";
            this.addVertexRadioButton.UseVisualStyleBackColor = false;
            this.addVertexRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // addArcRadioButton
            // 
            this.addArcRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.addArcRadioButton.AutoSize = true;
            this.addArcRadioButton.BackColor = System.Drawing.SystemColors.Control;
            this.addArcRadioButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addArcRadioButton.BackgroundImage")));
            this.addArcRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addArcRadioButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.addArcRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.addArcRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addArcRadioButton.Location = new System.Drawing.Point(37, 7);
            this.addArcRadioButton.Name = "addArcRadioButton";
            this.addArcRadioButton.Size = new System.Drawing.Size(28, 25);
            this.addArcRadioButton.TabIndex = 5;
            this.addArcRadioButton.Text = "   ";
            this.addArcRadioButton.UseVisualStyleBackColor = false;
            this.addArcRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // splitContainer4
            // 
            this.splitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.IsSplitterFixed = true;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.removeVertexRadioButton);
            this.splitContainer4.Panel1.Controls.Add(this.removeArcRadioButton);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.changeWeightRadioButton);
            this.splitContainer4.Size = new System.Drawing.Size(499, 38);
            this.splitContainer4.SplitterDistance = 70;
            this.splitContainer4.TabIndex = 2;
            // 
            // removeVertexRadioButton
            // 
            this.removeVertexRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.removeVertexRadioButton.AutoSize = true;
            this.removeVertexRadioButton.BackColor = System.Drawing.SystemColors.Control;
            this.removeVertexRadioButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("removeVertexRadioButton.BackgroundImage")));
            this.removeVertexRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.removeVertexRadioButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.removeVertexRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Blue;
            this.removeVertexRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeVertexRadioButton.Location = new System.Drawing.Point(3, 6);
            this.removeVertexRadioButton.Name = "removeVertexRadioButton";
            this.removeVertexRadioButton.Size = new System.Drawing.Size(28, 25);
            this.removeVertexRadioButton.TabIndex = 6;
            this.removeVertexRadioButton.Text = "   ";
            this.removeVertexRadioButton.UseVisualStyleBackColor = false;
            this.removeVertexRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // removeArcRadioButton
            // 
            this.removeArcRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.removeArcRadioButton.AutoSize = true;
            this.removeArcRadioButton.BackColor = System.Drawing.SystemColors.Control;
            this.removeArcRadioButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("removeArcRadioButton.BackgroundImage")));
            this.removeArcRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.removeArcRadioButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.removeArcRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Blue;
            this.removeArcRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeArcRadioButton.Location = new System.Drawing.Point(37, 6);
            this.removeArcRadioButton.Name = "removeArcRadioButton";
            this.removeArcRadioButton.Size = new System.Drawing.Size(28, 25);
            this.removeArcRadioButton.TabIndex = 6;
            this.removeArcRadioButton.Text = "   ";
            this.removeArcRadioButton.UseVisualStyleBackColor = false;
            this.removeArcRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // changeWeightRadioButton
            // 
            this.changeWeightRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.changeWeightRadioButton.AutoSize = true;
            this.changeWeightRadioButton.BackColor = System.Drawing.SystemColors.Control;
            this.changeWeightRadioButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("changeWeightRadioButton.BackgroundImage")));
            this.changeWeightRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.changeWeightRadioButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.changeWeightRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Blue;
            this.changeWeightRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeWeightRadioButton.Location = new System.Drawing.Point(3, 5);
            this.changeWeightRadioButton.Name = "changeWeightRadioButton";
            this.changeWeightRadioButton.Size = new System.Drawing.Size(28, 25);
            this.changeWeightRadioButton.TabIndex = 6;
            this.changeWeightRadioButton.Text = "   ";
            this.changeWeightRadioButton.UseVisualStyleBackColor = false;
            this.changeWeightRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // GraphEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 523);
            this.Controls.Add(this.splitContainer1);
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
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
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
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        public System.Windows.Forms.ComboBox zoomComboBox;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.RadioButton addArcRadioButton;
        public System.Windows.Forms.RadioButton moveRadioButton;
        public System.Windows.Forms.RadioButton removeArcRadioButton;
        public System.Windows.Forms.RadioButton removeVertexRadioButton;
        public System.Windows.Forms.RadioButton addVertexRadioButton;
        public System.Windows.Forms.RadioButton changeWeightRadioButton;
        public System.Windows.Forms.SplitContainer splitContainer2;
        public System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.SplitContainer splitContainer3;
        public System.Windows.Forms.SplitContainer splitContainer4;

    }
}

