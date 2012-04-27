using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GraphEditor.App.Models;

namespace GraphEditor.App.Views
{
    public partial class VertexModifyForm : Form
    {
        public bool Succesful = false;
        public IVertexWrapper VertexWrapper { get; set; }
        public VertexModifyForm(IVertexWrapper vertexWrapper)
        {
            this.VertexWrapper = vertexWrapper.Clone() as IVertexWrapper;

            InitializeComponent();
        }

        private void VertexModifyForm_Load(object sender, EventArgs e)
        {
            vertexNameTextBox.Text = VertexWrapper.Name;
            xTextBox.Text = (VertexWrapper as WFVertexWrapper).Coords.X.ToString();
            yTextBox.Text = (VertexWrapper as WFVertexWrapper).Coords.Y.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
#warning Записывается постоянно текст! и при изменении вершины учитываются дуги этой вершины
            VertexWrapper.VertexValue = vertexNameTextBox.Text;
            float x;
            float y;
            if (!float.TryParse(xTextBox.Text, out x))
            {
                x = (VertexWrapper as WFVertexWrapper).Coords.X;
            }
            if (!float.TryParse(yTextBox.Text, out y))
            {
                y = (VertexWrapper as WFVertexWrapper).Coords.Y;
            }

            (VertexWrapper as WFVertexWrapper).Coords = new PointF(x, y);
            Succesful = true;
            Close();
        }
    }
}
