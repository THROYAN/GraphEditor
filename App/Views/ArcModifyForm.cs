using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MagicLibrary.MathUtils.Graphs;

using GraphEditor.App.Models;

namespace GraphEditor.App.Views
{
    public partial class ArcModifyForm : Form
    {
        public bool Succesful = false;
        public IArcWrapper ArcWrapper { get; set; }

        public ArcModifyForm(IArcWrapper arcWrapper)
        {
            InitializeComponent();
            this.ArcWrapper = arcWrapper.Clone() as IArcWrapper;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ArcWrapper.Head = this.ArcWrapper.graphWrapper.VertexWrappers.Find(v => v.Vertex.Value.Equals(this.headComboBox.SelectedItem));
            this.ArcWrapper.Tail = this.ArcWrapper.graphWrapper.VertexWrappers.Find(v => v.Vertex.Value.Equals(this.tailComboBox.SelectedItem));

            this.ArcWrapper.Weight = Convert.ToDouble(this.weightNumericUpDown.Value);

            this.Succesful = true;
            Close();
        }

        private void ArcModifyForm_Load(object sender, EventArgs e)
        {
            this.headComboBox.Items.Clear();
            this.tailComboBox.Items.Clear();

            this.headComboBox.Items.AddRange(this.ArcWrapper.graphWrapper.Graph.GetVertices().Select(v => v.Value).ToArray());
            this.tailComboBox.Items.AddRange(this.ArcWrapper.graphWrapper.Graph.GetVertices().Select(v => v.Value).ToArray());

            this.headComboBox.SelectedItem = this.ArcWrapper.Head.Vertex.Value;
            this.tailComboBox.SelectedItem = this.ArcWrapper.Tail.Vertex.Value;

            this.weightNumericUpDown.Value = Convert.ToDecimal(this.ArcWrapper.Weight);

            if (!(this.ArcWrapper.Edge is WeightedArc))
                this.weightNumericUpDown.Enabled = false;
        }
    }
}
