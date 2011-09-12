using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphEditor.App.Models
{
    /// <summary>
    /// Ориентированный граф - все рёбра имеют направление,
    /// голову (конечная вершина) и хвост (начальная вершина) и называются дугами.
    /// </summary>
    public class DirectedGraph : IGraph
    {
        /// <summary>
        /// Список вершин
        /// </summary>
        private List<Vertex> Vertices { get; set; }

        /// <summary>
        /// Список дуг
        /// </summary>
        private List<Arc> Arcs { get; set; }

        public DirectedGraph()
        {
            Vertices = new List<Vertex>();
            Arcs = new List<Arc>();
        }

        public int Order
        {
            get { return Vertices.Count; }
        }

        public int Size
        {
            get { return Arcs.Count; }
        }

        public object[] VerticesValues
        {
            get
            {
                object[] values = new object[Vertices.Count];
                int i = 0;
                Vertices.ForEach(v => values[i++] = v.Value);
                return values;
            }
        }

        public IVertex this[object vertexValue]
        {
            get
            {
                return Vertices.Find(v => v.Value == vertexValue);
            }
        }

        public IEdge this[object uValue, object vValue]
        {
            get
            {
                return Arcs.Find(e =>
                    e.Head.Value == uValue && e.Tail.Value == vValue);
            }
        }

        public void AddVertex(object vertexValue)
        {
            ModificationStatus status = !Vertices.Exists(v => v.Value == vertexValue) ? ModificationStatus.Successful : ModificationStatus.AlreadyExist;

            VerticesModifiedEventArgs e = new VerticesModifiedEventArgs(status, this[vertexValue]);
            if (OnAddVertex != null)
                OnAddVertex(this, e);

            if (e.Status == ModificationStatus.Successful)
                Vertices.Add(new Vertex(this, vertexValue));
        }

        public void RemoveVertex(object vertexValue)
        {
            ModificationStatus status = Vertices.Exists(v => v.Value == vertexValue) ? ModificationStatus.Successful : ModificationStatus.NotExist;

            VerticesModifiedEventArgs e = new VerticesModifiedEventArgs(status, this[vertexValue]);
            if (OnRemoveVertex != null)
                OnRemoveVertex(this, e);

            if (e.Status == ModificationStatus.Successful)
            {
                RemoveAllArcs(vertexValue);
                Vertices.RemoveAll(v => v.Value == vertexValue);
            }
        }

        /// <summary>
        /// Скрываем метод "Добавить ребро", чтобы переименовать его в "Добавить дугу"
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        void IGraph.AddEdge(object u, object v)
        {
            ModificationStatus status = !Arcs.Exists(a => a.Tail == u && a.Head == v) ? ModificationStatus.Successful : ModificationStatus.AlreadyExist;
            Arc arc = new Arc(this, u, v);
            EdgesModifiedEventArgs e = new EdgesModifiedEventArgs(status, arc);
            if (OnAddEdge != null)
                OnAddEdge(this, e);
            if (e.Status == ModificationStatus.Successful)
                Arcs.Add(arc);
        }

        /// <summary>
        /// Добавление дуги
        /// </summary>
        /// <param name="head">Голова</param>
        /// <param name="tail">Хвост</param>
        public void AddArc(object head, object tail)
        {
            ((IGraph)this).AddEdge(head, tail);
        }

        /// <summary>
        /// Скрываем метод "Удалить ребро", чтобы переименовать его в "Удалить дугу"
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        void IGraph.RemoveEdge(object u, object v)
        {
            Arc arc = Arcs.Find(a =>
                                a.Tail.Value == u && a.Head.Value == v);
            ModificationStatus status = arc != null ? ModificationStatus.Successful : ModificationStatus.NotExist;
            EdgesModifiedEventArgs eArgs = new EdgesModifiedEventArgs(status, arc);
            if (OnRemoveEdge != null)
                OnRemoveEdge(this, eArgs);

            if (eArgs.Status == ModificationStatus.Successful)
            Arcs.Remove(arc);
        }

        /// <summary>
        /// Удаление дуги
        /// </summary>
        /// <param name="head">Голова</param>
        /// <param name="tail">Хвост</param>
        public void RemoveArc(object head, object tail)
        {
            ((IGraph)this).RemoveEdge(head, tail);
        }

        /// <summary>
        /// Скрываем метод "Удалить рёбра"
        /// </summary>
        /// <param name="vertexValue"></param>
        void IGraph.RemoveEdges(object vertexValue)
        {
            Arcs.FindAll(a => a.Head.Value == vertexValue || a.Tail.Value == vertexValue)
                .ForEach(arc => RemoveArc(arc.Head.Value,arc.Tail.Value));
        }

        /// <summary>
        /// Удаление всех дуг, входящих и выходящих из вершины
        /// </summary>
        /// <param name="vertexValue">"Содержимое вершины</param>
        public void RemoveAllArcs(object vertexValue)
        {
            ((IGraph)this).RemoveEdges(vertexValue);
        }

        /// <summary>
        /// Удаление всех дуг, для которых вершина является хвостом
        /// </summary>
        /// <param name="vertexValue">"Содержимое вершины"</param>
        public void RemoveOutArcs(object vertexValue)
        {
            Arcs.FindAll(a => a.Tail.Value == vertexValue)
                .ForEach(arc => RemoveArc(arc.Head.Value, arc.Tail.Value));
        }

        /// <summary>
        /// Удаление всех дуг, для которых вершина является головой
        /// </summary>
        /// <param name="vertexValue"></param>
        public void RemoveInArcs(object vertexValue)
        {
            Arcs.FindAll(a => a.Head.Value == vertexValue)
                .ForEach(arc => RemoveArc(arc.Head.Value, arc.Tail.Value));
        }


        public event EventHandler OnAddVertex;

        public event EventHandler OnRemoveVertex;

        public event EventHandler OnAddEdge;

        public event EventHandler OnRemoveEdge;


        public IVertex GetVertex(Predicate<IVertex> match)
        {
            throw new NotImplementedException();
        }

        public IEdge GetEdge(Predicate<IEdge> match)
        {
            throw new NotImplementedException();
        }
    }
}
