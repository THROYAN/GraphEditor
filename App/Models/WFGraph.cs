using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using MagicLibrary.MathUtils.Graphs;

namespace GraphEditor.App.Models
{
    public class WFGraph : WeightedGraph
    {
        public Size DefaultVertexSize { get; set; }

        private int counter { get; set; }
        private PointF[] currentPoints { get; set; }
        private PointF currentCoords { get; set; }

        public WFGraph()
            : base()
        {
            DefaultVertexSize = new Size(20, 20);
            currentCoords = new PointF();

            OnAddEdge += new EventHandler(WFGraph_OnAddEdge);
            OnAddVertex += new EventHandler(WFGraph_OnAddVertex);
        }

        void WFGraph_OnAddVertex(object sender, EventArgs e)
        {
            VerticesModifiedEventArgs args = e as VerticesModifiedEventArgs;

            if (args.Status == ModificationStatus.Successful)
            {
                args.Vertex = new WFVertexWrapper(sender as IGraph, args.VertexValue as string, currentCoords);
            }
        }

        void WFGraph_OnAddEdge(object sender, EventArgs e)
        {
            EdgesModifiedEventArgs args = e as EdgesModifiedEventArgs;

            if (args.Status == ModificationStatus.Successful)
            {
                args.Edge = new WFArcWrapper(sender as IGraph, args.u as string, args.v as string, (args.Edge as WeightedArc).Weight) { Points = currentPoints };
            }
        }

        public void AddVertex(string name, PointF coords)
        {
            currentCoords = coords;
            AddVertex(name);
            currentCoords = new PointF();
        }

        public void AddVertex(PointF coords)
        {
            AddVertex("P" + counter++, coords);
        }

        public void AddArc(string tailName, string headName, PointF[] points)
        {
            currentPoints = points;
            AddArc(tailName, headName);
            currentPoints = null;
        }

        public void AddArc(string tailName, string headName, double weight, PointF[] points)
        {
            currentPoints = points;
            AddArc(tailName, headName, weight);
            currentPoints = null;
        }

        public WFVertexWrapper this[string name]
        {
            get
            {
                return GetVertex(v => v.Value as string == name) as WFVertexWrapper;
            }
        }
        public WFVertexWrapper this[int vertexIndex]
        {
            get
            {
                return GetVertices(v => true)[vertexIndex] as WFVertexWrapper;
            }
        }
    }
}
