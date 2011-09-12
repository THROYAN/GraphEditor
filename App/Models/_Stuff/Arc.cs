using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphEditor.App.Models
{
    public class Arc : IEdge
    {
        public IGraph Graph { get; set; }

        IVertex[] IEdge.Vertices { get; set; }

        /// <summary>
        /// "Голова" дуги - вершина, в которую входит дуга
        /// </summary>
        public IVertex Head
        {
            get
            {
                return ((IEdge)this).Vertices[0];
            }
            set
            {
                ((IEdge)this).Vertices[0] = value;
            }
        }

        /// <summary>
        /// "Хвост" дуги - вершина, из которой исходит дуга
        /// </summary>
        public IVertex Tail
        {
            get
            {
                return ((IEdge)this).Vertices[1];
            }
            set
            {
                ((IEdge)this).Vertices[1] = value;
            }
        }

        public Arc(IGraph graph, object head, object tail)
        {
            this.Graph = graph;
            ((IEdge)this).Vertices = new IVertex[2];
            this.Head = this.Graph[head];
            this.Tail = this.Graph[tail];
        }
    }
}
