using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using MagicLibrary.MathUtils.Graphs;
using MagicLibrary.MathUtils;
using MagicLibrary.Graphic;

using GraphEditor.App.Views;

namespace GraphEditor.App.Models
{
    [Serializable]
    public class WFArcWrapper : IArcWrapper
    {
        public int SelectedPointWidth { get; set; }

        public IGraphWrapper graphWrapper { get; set; }

        public IEdge Edge
        {
            get
            {
                if (vertices[0] == null || vertices[1] == null)
                    return null;
                if(this.graphWrapper.Graph is DirectedGraph)
                    return (this.graphWrapper.Graph as DirectedGraph)[vertices[0].Value, vertices[1].Value];
                return this.graphWrapper.Graph[vertices[0].Value, vertices[1].Value];
            }
            set
            {
                if (this.graphWrapper.Graph is DirectedGraph)
                    (this.graphWrapper.Graph as DirectedGraph)[vertices[0].Value, vertices[1].Value].Vertices = value.Vertices;
                else
                    this.graphWrapper.Graph[vertices[0].Value, vertices[1].Value].Vertices = value.Vertices;
                //this.graphWrapper.Graph[vertices[0].Value, vertices[1].Value].Vertices = value.Vertices;

                this.vertices = value.Vertices;

                if (value is WeightedArc)
                    this.Weight = (value as WeightedArc).Weight;
            }
        }

        public bool EqualsEdges(IEdge edge)
        {
            return edge.Vertices.Equals(this.vertices);
        }

        private IVertex[] vertices;

        public PointF[] Points { get; set; }

        private List<int> splinePointsIndexes { get; set; }

        public virtual string Text
        {
            get
            {
                var m = this.graphWrapper.Graph.GetType().GetMethod("GetArcFlow", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                double? f = null;
                if (m != null)
                {
                    f = m.Invoke(this.graphWrapper.Graph, new[] { this.Edge }) as double?;
                }
                return f == null ? this.Weight.ToString() : String.Format("{0}/{1}", f, this.Weight);
            }
        }

        public double Weight
        {
            get
            {
                if (Edge is WeightedArc)
                    return (Edge as WeightedArc).Weight;
                else
                    return 1;
            }
            set
            {
                if (Edge is WeightedArc)
                    (Edge as WeightedArc).Weight = value;
            }
        }

        public RectangleF TextRectangleF(Graphics g)
        {
            PointF tail = (Tail as WFVertexWrapper).Center, head = new PointF();
            if (Head != null)
            {
                head = (Head as WFVertexWrapper).Center;
                if (Points != null && Points.Length > 0)
                {
                    tail = Points.Last();
                }
            }
            else
            {
                if (Points != null && Points.Length > 0)
                {
                    if (Points.Length > 1)
                    {
                        tail = Points[Points.Length - 2];
                    }
                    head = Points.Last();
                }
            }

            SizeF s = g.MeasureString(this.Text, new Font("Arial", 8));

            return new RectangleF(
                            new PointF(
                                tail.X + (head.X - tail.X) / 3 - s.Width / 2,
                                tail.Y + (head.Y - tail.Y) / 3 - s.Height / 2
                                ),
                                s
                            );
        }
        public Rectangle TextRectangle(Graphics g)
        {
            RectangleF r = TextRectangleF(g);
            return new Rectangle((int)r.X, (int)r.Y, (int)r.Width, (int)r.Height);
        }

        public RectangleF PointRectangle(PointF p)
        {
            int width = SelectedPointWidth;

            return (new RectangleF(MGraphic.T(-width / 2, -width / 2) * p, new Size(width, width)));
        }

        public RectangleF PointRectangle(PointF p, int width)
        {
            return (new RectangleF(MGraphic.T(-width / 2, -width / 2) * p, new Size(width, width)));
        }

        public RectangleF PointRectangle(int index)
        {
            int width = SelectedPointWidth;
            //RectangleConverter r = new RectangleConverter();

            return Points == null
                    ? new Rectangle()
                        : Points.Length <= index
                            ? new Rectangle()
                                : 
              //                  (Rectangle)r.ConvertTo(
                                    (new RectangleF(MGraphic.T(-width / 2, -width / 2) * Points[index], new Size(width, width)))
                //                , (new Rectangle()).GetType())
            ;
        }

        public IVertexWrapper Tail
        {
            get
            {
                return graphWrapper.VertexWrappers.Find(v => v.Vertex.Equals(vertices[0]));//Edge == null ? graphWrapper.VertexWrappers.Find(v => v.Vertex.Value.Equals(vertices[0].Value)) : Edge.Vertices[0] == null ? null : graphWrapper.VertexWrappers.Find(v => v.Vertex.Value.Equals(Edge.Vertices[0].Value));
            }
            set
            {
                this.Edge.Vertices[0] = value.Vertex;
                this.vertices[0] = value.Vertex;
            }
        }

        public IVertexWrapper Head
        {
            get { return graphWrapper.VertexWrappers.Find(v => v.Vertex.Equals(vertices[1])); }//return Edge == null || Edge.Vertices[1] == null ? null : graphWrapper.VertexWrappers.Find(v => v.Vertex.Value.Equals(Edge.Vertices[1].Value)); }
            set
            {
                this.Edge.Vertices[1] = value.Vertex;
                this.vertices[1] = value.Vertex;
            }
        }

        public WFArcWrapper(IGraphWrapper graphWrapper, IEdge edge)
        {
            if(edge.Graph != graphWrapper.Graph)
                throw new Exception("Invalid argument - edge or graphWrapper. Method - WFArcWrapper.constructor(IGraphWrapper,IEdge)");

            this.SelectedPointWidth = 10;
            
            this.graphWrapper = graphWrapper;

            this.vertices = edge.Vertices;

            this.splinePointsIndexes = new List<int>();
        }

        public virtual void Draw(Graphics g, Pen p)
        {
            WFVertexWrapper tail = Tail as WFVertexWrapper;
            WFVertexWrapper head = Head as WFVertexWrapper;
            PointF[] arrow = new PointF[3] {
                                                new PointF(-10,5),
                                                new PointF(0,0),
                                                new PointF(-10,-5)
                                            };
            double angle;
            Matrix dM;

            List<PointF> pl = new List<PointF>();

            if (Points != null && Points.Length > 0)
            {
                angle = -Math.Atan2(tail.Center.Y - Points[0].Y, Points[0].X - tail.Center.X);
                PointF popravka = new PointF((float)Math.Cos(angle) * tail.Size.Width / 2,
                                     (float)Math.Sin(angle) * tail.Size.Height / 2);

                //g.DrawLine(p, MGraphic.T(popravka.X, popravka.Y) * tail.Center, Points[0]);
                pl.Add(MGraphic.T(popravka.X, popravka.Y) * tail.Center);

                //for (int i = 0; i < Points.Length - 1; i++)
                //    g.DrawLine(p, Points[i], Points[i + 1]);
                pl.AddRange(Points);
                try
                {
                    angle = -Math.Atan2(Points[Points.Length - 1].Y - head.Center.Y, head.Center.X - Points[Points.Length - 1].X);
                    popravka = new PointF((float)Math.Cos(angle) * head.Size.Width / 2,
                                     (float)Math.Sin(angle) * head.Size.Height / 2);
                    dM =
                           MGraphic.T(head.Center.X - popravka.X, head.Center.Y - popravka.Y)
                         * MGraphic.R(angle * 180 / Math.PI)
                    ;

                    //g.DrawLine(p, Points[Points.Length - 1], dM * new PointF(0,0));
                    pl.Add(dM * new PointF(0, 0));
                    
                    g.DrawLines(p, dM * arrow);
                }
                catch { }

                //g.DrawLines(p, pl.ToArray());

                PointF start = pl[0];
                List<PointF> spline = new List<PointF>();
                spline.Add(start);
                for (int i = 1; i < pl.Count; i++)
                {
                    spline.Add(pl[i]);
                    if (!IsSpline(i - 1))
                    {
                        //spline.Add(pl[i]);
                        if (spline.Count != 1)
                        {
                            MGraphic.DrawSpline(g, p, spline.ToArray());
                        }
                        else
                        {
                            g.DrawLine(p, start, pl[i]);
                        }
                        spline.Clear();
                        spline.Add(pl[i]);
                        start = pl[i];
                    }
                }
                //MGraphic.DrawSpline(g, p, pl.ToArray(), 0.01);
                //if(Points.Length > 1)
                //    g.DrawLines(p, Points);
            }
            else
            {
                angle = -Math.Atan2(tail.Center.Y - head.Center.Y, head.Center.X - tail.Center.X);
                PointF popravka = new PointF((float)Math.Cos(angle) * head.Size.Width / 2,
                                         (float)Math.Sin(angle) * head.Size.Height / 2);
                //g.DrawLine(p, MGraphic.T(popravka.X, popravka.Y) * tail.Center, MGraphic.T(-popravka.X, -popravka.Y) * head.Center);
                dM =
                           MGraphic.T(head.Center.X - popravka.X, head.Center.Y - popravka.Y)
                         * MGraphic.R(angle * 180 / Math.PI)
                 ;
                popravka = new PointF((float)Math.Cos(angle) * tail.Size.Width / 2,
                                     (float)Math.Sin(angle) * tail.Size.Height / 2);

                g.DrawLines(p, dM * arrow);
                //g.DrawLine(p, MGraphic.T(popravka.X, popravka.Y) * tail.Center, dM * (new PointF(0, 0)));
                pl.Add(MGraphic.T(popravka.X, popravka.Y) * tail.Center);
                pl.Add(dM * (new PointF(0, 0)));

                g.DrawLines(p, pl.ToArray());
            }
            
            var rect = TextRectangle(g);
            if ((this.Edge is WeightedArc && (this.Edge as WeightedArc).Weight != 1) || !(this.Edge is WeightedArc))
            {
                g.FillRectangle(Brushes.White, rect);
                g.DrawString(
                            this.Text,
                            new Font("Arial", 8),
                            Brushes.Black,
                            rect.Location
                            );
            }
        }

        public void Draw(Graphics g, Pen p, bool drawPoints, Matrix m)
        {
            Draw(g, p, m);
            if (drawPoints && Points != null)
            {
                Points.ToList().ForEach(pt =>
                    //g.DrawEllipse(p,
                    //        PointRectangle(pt)
                    //)
                    MGraphic.DrawEllipse(g,p,PointRectangle(pt),m)
                );
            }
        }

        public void Draw(Graphics g, Pen p, bool drawPoints)
        {
            Draw(g, p);
            if (drawPoints && Points != null)
            {
                Points.ToList().ForEach(pt =>
                    g.DrawEllipse(p,
                            PointRectangle(pt)
                    )
                );
            }
        }

        public void Draw(Graphics g, Pen p, Matrix m)
        {
            WFVertexWrapper tail = Tail as WFVertexWrapper;
            WFVertexWrapper head = Head as WFVertexWrapper;
            PointF[] arrow = new PointF[3] {
                                                new PointF(-10,5),
                                                new PointF(0,0),
                                                new PointF(-10,-5)
                                            };
            double angle;
            Matrix dM;

            List<PointF> pl = new List<PointF>();

            if (Points != null && Points.Length > 0)
            {
                angle = -Math.Atan2(tail.Center.Y - Points[0].Y, Points[0].X - tail.Center.X);
                PointF popravka = new PointF((float)Math.Cos(angle) * tail.Size.Width / 2,
                                     (float)Math.Sin(angle) * tail.Size.Height / 2);

                //g.DrawLine(p, MGraphic.T(popravka.X, popravka.Y) * tail.Center, Points[0]);
                pl.Add(MGraphic.T(popravka.X, popravka.Y) * tail.Center);

                //for (int i = 0; i < Points.Length - 1; i++)
                //    g.DrawLine(p, Points[i], Points[i + 1]);
                pl.AddRange(Points);
                try
                {
                    angle = -Math.Atan2(Points[Points.Length - 1].Y - head.Center.Y, head.Center.X - Points[Points.Length - 1].X);
                    popravka = new PointF((float)Math.Cos(angle) * head.Size.Width / 2,
                                     (float)Math.Sin(angle) * head.Size.Height / 2);
                    dM =
                           MGraphic.T(head.Center.X - popravka.X, head.Center.Y - popravka.Y)
                         * MGraphic.R(angle * 180 / Math.PI)
                    ;

                    //g.DrawLine(p, Points[Points.Length - 1], dM * new PointF(0,0));
                    pl.Add(dM * new PointF(0, 0));

                    g.DrawLines(p, m * dM * arrow);
                }
                catch { }

                //g.DrawLines(p, m * pl.ToArray());
                // 0 - tail, (pl.Count - 1) - head
                PointF start = pl[0];
                List<PointF> spline = new List<PointF>();
                spline.Add(start);
                for (int i = 1; i < pl.Count; i++)
                {
                    spline.Add(pl[i]);
                    if (!IsSpline(i - 1))
                    {
                        //spline.Add(pl[i]);
                        if (spline.Count != 1)
                        {
                            MGraphic.DrawSpline(g, p, spline.ToArray(), m);
                        }
                        else
                        {
                            g.DrawLine(p, start, pl[i]);
                        }
                        spline.Clear();
                        spline.Add(pl[i]);
                        start = pl[i];
                    }
                }
                //MGraphic.DrawSpline(g, p, pl.ToArray(), 0.01);
                //if(Points.Length > 1)
                //    g.DrawLines(p, Points);
            }
            else
            {
                angle = -Math.Atan2(tail.Center.Y - head.Center.Y, head.Center.X - tail.Center.X);
                PointF popravka = new PointF((float)Math.Cos(angle) * head.Size.Width / 2,
                                         (float)Math.Sin(angle) * head.Size.Height / 2);
                //g.DrawLine(p, MGraphic.T(popravka.X, popravka.Y) * tail.Center, MGraphic.T(-popravka.X, -popravka.Y) * head.Center);
                dM =
                           MGraphic.T(head.Center.X - popravka.X, head.Center.Y - popravka.Y)
                         * MGraphic.R(angle * 180 / Math.PI)
                 ;
                popravka = new PointF((float)Math.Cos(angle) * tail.Size.Width / 2,
                                     (float)Math.Sin(angle) * tail.Size.Height / 2);

                g.DrawLines(p, m * dM * arrow);
                //g.DrawLine(p, MGraphic.T(popravka.X, popravka.Y) * tail.Center, dM * (new PointF(0, 0)));
                pl.Add(MGraphic.T(popravka.X, popravka.Y) * tail.Center);
                pl.Add(dM * (new PointF(0, 0)));

                g.DrawLines(p, m * pl.ToArray());
            }


            var rect = TextRectangle(g);

            if ((this.Edge is WeightedArc && (this.Edge as WeightedArc).Weight != 1) || (!(this.Edge is WeightedArc) && this.Edge != null))
            {
                g.DrawString(
                            this.Text,
                            new Font("Arial", 8),
                            Brushes.Black,
                            m * rect.Location
                            );
            }
        }

        public bool Hit(float x, float y)
        {
            double eps = 5;
            WFVertexWrapper head = Head as WFVertexWrapper, tail = Tail as WFVertexWrapper;
            if (Points != null && Points.Length > 0)
            {
                if (HitLine(tail.Center, Points[0], new PointF(x, y), eps))
                    return true;
                for (int i = 0; i < Points.Length - 1; i++)
                {
                    if (HitLine(Points[i], Points[i + 1], new PointF(x, y), eps))
                        return true;
                }
                return HitLine(Points[Points.Length - 1], head.Center, new PointF(x, y), eps);
            }
            else
            {
                return HitLine(tail.Center, head.Center, new PointF(x, y), eps);
            }

            //return WeightRectangleF(Graphics.FromImage(new Bitmap(1,1))).Contains(x, y);
        }

        public bool HitLine(PointF p1, PointF p2, PointF p, double eps)
        {
            //RectangleF r = new RectangleF(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y), Math.Abs(p1.X - p2.X), Math.Abs(p1.Y - p2.Y));
            //return Math.Abs(p1.X * p2.X + p1.Y * p2.Y - p.X * (p1.X + p2.X - p.X) - p.Y * (p1.Y + p2.Y - p.Y)) <= eps;
//#warning ПЕРЕПИСАТЬ!!!!! НЕ РАБОТАЕТ НА ВЕРТИКАЛЬНЫХ ЛИНИЯХ!!
            //return Math.Abs((p.Y - p1.Y) / (p2.Y - p1.Y) - (p.X - p1.X) / (p2.X - p1.X)) < eps && r.Contains(p);

            //R =
            //(Cx-Ax)(Bx-Ax) + (Cy-Ay)(By-Ay)
            //------------------------------
            //(sqrt((Bx-Ax)^2 + (By-Ay)^2))^2
            double R = ((p.X - p1.X) * (p2.X - p1.X) + (p.Y - p1.Y) * (p2.Y - p1.Y))
                            /
                        Math.Pow(Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2)),2);

            if (!(0 <= R && R <= 1))
                return false;
            //D =
            //(Ay-Cy)(Bx-Ax)-(Ax-Cx)(By-Ay)
            //-----------------------------
            //sqrt((Bx-Ax)^2 + (By-Ay)^2)
            double D = ((p1.Y - p.Y) * (p2.X - p1.X) - (p1.X - p.X) * (p2.Y - p1.Y))
                            /
                        Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
            return Math.Abs(D) < eps;
        }

        public void AddPointOnLine(PointF p)
        {
            double eps = 5;
            WFVertexWrapper head = Head as WFVertexWrapper, tail = Tail as WFVertexWrapper;
            if (Points != null && Points.Length > 0)
            {
                if (HitLine(tail.Center, Points[0], p, eps))
                {
                    this.AddPoint(0, p);
                    return;
                }
                for (int i = 0; i < Points.Length - 1; i++)
                {
                    if (HitLine(Points[i], Points[i + 1], p, eps))
                    {
                        this.AddPoint(i + 1, p);
                        return;
                    }
                }
                this.AddPoint(Points.Length, p);
            }
            else
            {
                Points = new PointF[] { p };
            }
        }

        public void AddPoint(int index, PointF p)
        {
            List<PointF> ps = this.Points.ToList();
            ps.Insert(index, p);
            this.Points = ps.ToArray();

            // refresh splined points
            for (int i = 0; i < this.splinePointsIndexes.Count; i++)
            {
                if (this.splinePointsIndexes[i] >= index)
                {
                    this.splinePointsIndexes[i]++;
                }
            }
        }

        public virtual int HitPoint(float x, float y)
        {
            if (Points == null || Points.Length == 0)
                return -1;
            return Points.ToList().FindIndex(p =>
                PointRectangle(p).Contains(x, y));
        }

        public void SetSplinePoint(int index)
        {
            this.splinePointsIndexes.Add(index);
        }

        public void SetNormalPoint(int index)
        {
            this.splinePointsIndexes.Remove(index);
        }

        public bool IsSpline(int index)
        {
            return this.splinePointsIndexes.Contains(index);
        }

        public void TogglePoint(int index)
        {
            if (IsSpline(index))
            {
                this.SetNormalPoint(index);
            }
            else
            {
                this.SetSplinePoint(index);
            }
        }

        public void RemoveArcPointAt(int index)
        {
            List<PointF> ps = new List<PointF>(this.Points);
            ps.RemoveAt(index);
            this.Points = ps.ToArray();
            this.SetNormalPoint(index);
            // refresh splined points
            for (int i = 0; i < this.splinePointsIndexes.Count; i++)
            {
                if (this.splinePointsIndexes[i] > index)
                {
                    this.splinePointsIndexes[i]--;
                }
            }
        }


        public virtual void EditArc()
        {
            ArcModifyForm am = new ArcModifyForm(this);
            am.ShowDialog();
            if (am.Succesful)
            {
                am.ArcWrapper.CopyTo(this);// as MagicLibrary.MathUtils.Graphs.Vertex;
            }
        }


        public object Clone()
        {
            return new WFArcWrapper(this.graphWrapper, this.Edge) { Points = this.Points, splinePointsIndexes = this.splinePointsIndexes };
        }

        public void CopyTo(IArcWrapper arcWrapper)
        {
            arcWrapper.graphWrapper = this.graphWrapper;
            (arcWrapper as WFArcWrapper).vertices = this.vertices;
            (arcWrapper as WFArcWrapper).splinePointsIndexes = this.splinePointsIndexes;
            (arcWrapper as WFArcWrapper).SelectedPointWidth = this.SelectedPointWidth;
            (arcWrapper as WFArcWrapper).Points = this.Points;
        }
    }
}
