using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using MagicLibrary.MathUtils.Graphs;

using GraphEditor.App.Views;

namespace GraphEditor.App.Models
{
    [Serializable]
    public class WFGraphWrapper : IGraphWrapper
    {
        public List<IArcWrapper> ArcWrappers { get; set; }
        public List<IVertexWrapper> VertexWrappers { get; set; }

        public Size DefaultVertexSize { get; set; }

        private int counter { get; set; }
        protected PointF[] currentPoints { get; set; }
        protected PointF currentCoords { get; set; }

        public IGraph Graph { get; set; }

        public WFGraphWrapper()
        {
            Graph = new WeightedGraph();
            DefaultVertexSize = new Size(20, 20);
            currentCoords = new PointF();
            VertexWrappers = new List<IVertexWrapper>();
            ArcWrappers = new List<IArcWrapper>();

            WFGraphWrapper.SetDefaultEventHandlers(this);
        }

        public WFGraphWrapper(IGraph graph)
        {
            Graph = graph;

            DefaultVertexSize = new Size(20, 20);
            currentCoords = new PointF();
            VertexWrappers = new List<IVertexWrapper>();
            ArcWrappers = new List<IArcWrapper>();
            Random r = new Random();

            foreach (var item in this.Graph.GetVertices())
            {
                this.VertexWrappers.Add(new WFVertexWrapper(this, item) { SizeF = this.DefaultVertexSize, Coords = new PointF(r.Next(1, 500), r.Next(1, 400)) });
            }
            foreach (var e in this.Graph.GetEdges())
            {
                this.ArcWrappers.Add(new WFArcWrapper(this, e));
            }

            WFGraphWrapper.SetDefaultEventHandlers(this);
        }

        public static void SetDefaultEventHandlers( WFGraphWrapper graphWrapper )
        {
            var graph = graphWrapper.Graph;
            graphWrapper.ClearMyEventHandlers();
            //graph.OnAddEdge += new EventHandler<EdgesModifiedEventArgs>(graphWrapper.Graph_OnAddEdge);
            //graph.OnAddVertex += new EventHandler<VerticesModifiedEventArgs>(graphWrapper.Graph_OnAddVertex);
            //graph.OnRemoveEdge += new EventHandler<EdgesModifiedEventArgs>(graphWrapper.Graph_OnRemoveEdge);
            //graph.OnRemoveVertex += new EventHandler<VerticesModifiedEventArgs>(graphWrapper.Graph_OnRemoveVertex);
            graph.OnVertexAdded += new EventHandler<VerticesModifiedEventArgs>(graphWrapper.graph_OnVertexAdded);
            graph.OnVertexRemoved+=new EventHandler<VerticesModifiedEventArgs>(graphWrapper.graph_OnVertexRemoved);
            graph.OnEdgeRemoved+=new EventHandler<EdgesModifiedEventArgs>(graphWrapper.graph_OnEdgeRemoved);
            graph.OnEdgeAdded+=new EventHandler<EdgesModifiedEventArgs>(graphWrapper.graph_OnEdgeAdded);
        }

        void graph_OnVertexAdded(object sender, VerticesModifiedEventArgs e)
        {
            if (e.Status == ModificationStatus.Successful)
            {
                VertexWrappers.Add(new WFVertexWrapper(this, e.Vertex) { Size = DefaultVertexSize, Center = currentCoords });
            }
            if (e.Status == ModificationStatus.AlreadyExist)
            {
                this.counter++;
            }
        }

        void graph_OnVertexRemoved(object sender, VerticesModifiedEventArgs e)
        {
            if (e.Status == ModificationStatus.Successful)
            {
                VertexWrappers.RemoveAll(v => v.EqualsVetices(e.Vertex));
            }
        }

        void graph_OnEdgeRemoved(object sender, EdgesModifiedEventArgs e)
        {
            if (e.Status == ModificationStatus.Successful)
            {
                ArcWrappers.RemoveAll(a => a.EqualsEdges(e.Edge));
            }
        }

        void graph_OnEdgeAdded(object sender, EdgesModifiedEventArgs e)
        {
            if (e.Status == ModificationStatus.Successful)
            {
                ArcWrappers.Add(new WFArcWrapper(this, e.Edge) { Points = currentPoints });
            }
        }

        public void AddVertex(string name, PointF coords)
        {
            currentCoords = coords;
            Graph.AddVertex(name);
            currentCoords = new PointF();
        }

        public void AddVertex(PointF coords)
        {
            AddVertex("V" + this.counter++, coords);
        }

        public void AddEdge(string tailName, string headName, PointF[] points)
        {
            currentPoints = points;
            Graph.AddEdge(tailName, headName);
            currentPoints = null;
        }

        public void AddArc(string tailName, string headName, double weight, PointF[] points)
        {
            currentPoints = points;
            if (Graph is WeightedGraph)
            {
                (Graph as WeightedGraph).AddArc(tailName, headName, weight);

            }
            else
            {
                if (Graph is WeightedBiGraph)
                {
                    (Graph as WeightedBiGraph).AddArc(tailName, headName, weight);
                }
                else
                {
                    Graph.AddEdge(tailName, headName);
                }
            }
            currentPoints = null;
        }

        public WFVertexWrapper this[object val]
        {
            get
            {
                return VertexWrappers.Find(v => v.Vertex.Value.Equals(val)) as WFVertexWrapper;
            }
        }
        
        public WFArcWrapper this[object tail, object head]
        {
            get
            {
                return ArcWrappers.Find(e => (e as WFArcWrapper).Tail.VertexValue.Equals(tail) &&
                                          (e as WFArcWrapper).Head.VertexValue.Equals(head)) as WFArcWrapper;
            }
        }

        public virtual void Draw(Graphics g, Pen p)
        {
            ArcWrappers.ForEach(edge => (edge as WFArcWrapper).Draw(g,p));
            VertexWrappers.ForEach(vertex => (vertex as WFVertexWrapper).Draw(g,p));
        }

        public virtual void Draw(Graphics g, Pen p, MagicLibrary.MathUtils.Matrix m)
        {
            ArcWrappers.ForEach(edge => (edge as WFArcWrapper).Draw(g, p, m));
            VertexWrappers.ForEach(vertex => (vertex as WFVertexWrapper).Draw(g, p, m));
        }

        public virtual void CopyTo(IGraphWrapper graphWrapper)
        {
            graphWrapper.ArcWrappers = new List<IArcWrapper>(this.ArcWrappers);
            graphWrapper.VertexWrappers = new List<IVertexWrapper>(this.VertexWrappers);

            this.Graph.CopyTo(graphWrapper.Graph);

            graphWrapper.VertexWrappers.ForEach(v => v.graphWrapper = graphWrapper);

            foreach (var arcWrapper in graphWrapper.ArcWrappers)
            {
                arcWrapper.Edge = graphWrapper.Graph[arcWrapper.Edge.Vertices[0].Value, arcWrapper.Edge.Vertices[1].Value];
                arcWrapper.graphWrapper = graphWrapper;
            }

            (graphWrapper as WFGraphWrapper).counter = this.counter;
            (graphWrapper as WFGraphWrapper).DefaultVertexSize = new Size(this.DefaultVertexSize.Width, this.DefaultVertexSize.Height);
            

            WFGraphWrapper.SetDefaultEventHandlers(graphWrapper as WFGraphWrapper);
        }

        public virtual void ClearMyEventHandlers()
        {
            Type graphType = this.Graph.GetType();
            while (graphType != null && graphType.GetMethod("SetDefaultEventHandlers") == null)
            {
                graphType = graphType.BaseType;
            }
            graphType.GetMethod("SetDefaultEventHandlers").Invoke(null, new object[] { this.Graph });
        }

        public virtual object Clone()
        {
            var gw = new WFGraphWrapper();

            this.CopyTo(gw);
            WFGraphWrapper.SetDefaultEventHandlers(this);

            gw.Graph = this.Graph.Clone() as IGraph;
            WFGraphWrapper.SetDefaultEventHandlers(gw);

            
            return gw;
        }

        public virtual void EditGraph()
        {
            IGraphConstructor gc;
            if (this.Graph is BiGraph)
                gc = new BiGraphConstructorForm(this);
            else
                gc = new GraphConstructorForm(this);
            (gc as Form).ShowDialog();

            if (gc.Succesful)
            {
                //gc.GraphWrapper.CopyTo(this.selectedGraph.graphWrapper);
                //this.selectedGraph.graphWrapper = gc.GraphWrapper.Clone() as WFGraphWrapper;
                gc.GraphWrapper.CopyTo(this);
            }
        }
    }
}
