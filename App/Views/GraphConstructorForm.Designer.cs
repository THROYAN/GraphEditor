namespace GraphEditor.App.Views
{
    partial class GraphConstructorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.verticesCounter = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.verticesComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.incidentsGrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.verticesCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.incidentsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // verticesCounter
            // 
            this.verticesCounter.Location = new System.Drawing.Point(133, 12);
            this.verticesCounter.Name = "verticesCounter";
            this.verticesCounter.Size = new System.Drawing.Size(40, 20);
            this.verticesCounter.TabIndex = 0;
            this.verticesCounter.ValueChanged += new System.EventHandler(this.verticesCount_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Количество вершин:";
            // 
            // verticesComboBox
            // 
            this.verticesComboBox.FormattingEnabled = true;
            this.verticesComboBox.Location = new System.Drawing.Point(200, 11);
            this.verticesComboBox.Name = "verticesComboBox";
            this.verticesComboBox.Size = new System.Drawing.Size(121, 21);
            this.verticesComboBox.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(327, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Редактировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // incidentsGrid
            // 
            this.incidentsGrid.AllowUserToAddRows = false;
            this.incidentsGrid.AllowUserToDeleteRows = false;
            this.incidentsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.incidentsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.incidentsGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.incidentsGrid.Location = new System.Drawing.Point(0, 38);
            this.incidentsGrid.Name = "incidentsGrid";
            this.incidentsGrid.Size = new System.Drawing.Size(689, 384);
            this.incidentsGrid.TabIndex = 4;
            this.incidentsGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.incidentsGrid_CellEndEdit);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // GraphConstructorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 422);
            this.Controls.Add(this.incidentsGrid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.verticesComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.verticesCounter);
            this.Name = "GraphConstructorForm";
            this.Text = "GraphConstructor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GraphConstructorForm_FormClosing);
            this.Load += new System.EventHandler(this.GraphConstructorForm_Load);
            this.Resize += new System.EventHandler(this.GraphConstructorForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.verticesCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.incidentsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.NumericUpDown verticesCounter;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox verticesComboBox;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataGridView incidentsGrid;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}