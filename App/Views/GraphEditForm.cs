using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MagicLibrary.MVC.WinForms;
using MagicLibrary.MathUtils.Graphs;

using GraphEditor.App.Models;
using GraphEditor.App.Controllers;

using Microsoft.VisualBasic;

namespace GraphEditor.App.Views
{
    public partial class GraphEditForm : WinFormView
    {
        private int _tabsHeight;
        public int count { get; set; }


        [NonSerialized]
        public List<GraphView> Graphs;

        public GraphView selectedGraph { get { return Graphs.Find(g => g.Control.Parent == tabControl1.SelectedTab); } }

        public GraphEditFormController MainController
        {
            get { return GetController("MainController") as GraphEditFormController; }
            set { Controllers.RemoveAll(c => c.Name == value.Name); AddController(value); }
        }

        public GraphEditForm()
        {
            InitializeComponent();
            Controllers.Add(new GraphEditFormController("MainController", this));

            Graphs = new List<GraphView>();
            count = 1;
        }

        private void добавитьВершинуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainController.SetAction(GraphEditActions.AddVertex);
        }

        private void добавитьДугуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainController.SetAction(GraphEditActions.AddArcSelectFirstVertex);
        }

        private void удалитьВершинуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainController.SetAction(GraphEditActions.RemoveVertex);
        }

        private void удалитьДугуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainController.SetAction(GraphEditActions.RemoveArc);
        }

        private void изменитьВесToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainController.SetAction(GraphEditActions.ChangeArcWeight);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainController.SaveAction();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainController.OpenAction();
        }

        private void GraphEditForm_Load(object sender, EventArgs e)
        {
            if (this.Graphs.Count == 0)
            {
                GraphMenuEnable = false;
            }
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainController.CreateAction();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainController.CloseAction();
        }

        public virtual bool GraphMenuEnable
        {
            set
            {
                закрытьToolStripMenuItem.Enabled = value;
                сохранитьToolStripMenuItem.Enabled = value;
                добавлениеToolStripMenuItem.Enabled = value;
                конструкторToolStripMenuItem.Enabled = value;
                panel1.Enabled = value;
            }
        }

        private void свободноеПеремещениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainController.SetAction(GraphEditActions.Edit);
        }

        private void конструкторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.selectedGraph.graphWrapper.EditGraph();

            if (this.selectedGraph.graphWrapper.Graph.Order > 0)
            {
                Size s = new System.Drawing.Size(
                    Math.Max(this.selectedGraph.graphWrapper.VertexWrappers.Max(v => (v as WFVertexWrapper).SelectionRectangle.Right), selectedGraph.Control.Parent.Width),
                    Math.Max(this.selectedGraph.graphWrapper.VertexWrappers.Max(v => (v as WFVertexWrapper).SelectionRectangle.Bottom), selectedGraph.Control.Parent.Height)
                );
                selectedGraph.Control.ClientSize = s;
            }
            Refresh();
        }

        private void GraphEditForm_Resize(object sender, EventArgs e)
        {
            this.tabControl1.Height = this.Height - this._tabsHeight;
        }

        private void GraphEditForm_ResizeBegin(object sender, EventArgs e)
        {
            this._tabsHeight = this.Height - this.tabControl1.Height;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            double temp;
            if (!Double.TryParse(zoomComboBox.Text, out temp))
            {
                temp = this.selectedGraph.Scaling * 100;
            }
            this.selectedGraph.Scaling = temp / 100;
            this.selectedGraph.Refresh();
        }

        public string newGraphName = "Новый граф";
    }
}
