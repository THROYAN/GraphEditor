using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using MagicLibrary.MathUtils.Graphs;

using GraphEditor.App.Views;

namespace GraphEditor.App.Models
{
    [Serializable]
    public class WFVertexWrapper : IVertexWrapper
    {
        public IGraphWrapper graphWrapper { get; set; }

        private object vertexValue;

        public IVertex Vertex
        {
            get
            {
                return this.graphWrapper.Graph[this.vertexValue];
            }
            set
            {
                value.CopyTo(this.graphWrapper.Graph[this.vertexValue]);
                this.vertexValue = value.Value;
                //this.graphWrapper.Graph[this.vertexName].Value = value.Value;
            }
        }

        public string Name
        {
            get { return this.Vertex.Value as string; }
            set
            {
                IVertex v = this.Vertex;
                v.Value = value;
                this.vertexValue = v.Value;
            }
        }

        public bool EqualsVetices(IVertex vertex)
        {
            return this.vertexValue == vertex.Value;
        }

        public PointF Coords { get; set; }

        public PointF Center
        {
            get { return new PointF(Coords.X + SizeF.Width / 2, Coords.Y + SizeF.Height / 2); }
            set { Coords = new PointF(value.X - SizeF.Width / 2, value.Y - SizeF.Height / 2); }
        }

        public Point Position { get { return new Point((int)Coords.X,(int)Coords.Y); } set { Coords = value; } }

        public SizeF SizeF{ get; set; }

        public Size Size { get { return new Size((int)SizeF.Width, (int)SizeF.Height); } set { SizeF = value; } }

        public Rectangle Rectangle
        {
            get { return new Rectangle(Position, Size); }
            set
            {
                Position = value.Location;
                Size = value.Size;
            }
        }

        public virtual Rectangle SelectionRectangle
        {
            get { return Rectangle.Inflate(Rectangle, 4, 4); }
        }

        public RectangleF RectangleF
        {
            get
            {
                return new RectangleF(Coords, Size);
            }
            set
            {
                Coords = value.Location;
                SizeF = value.Size;
            }
        }

        public WFVertexWrapper(IGraphWrapper graphWrapper,IVertex vertex)
        {
            this.graphWrapper = graphWrapper;
            vertexValue = vertex.Value;
            if ( graphWrapper.Graph != vertex.Graph )
                throw new Exception( "Invalid argument - vertex or graphWrapper. Method - WFVertexWrapper.constructor(IGraphWrapper,IVertex)" );
        }

        //public WFVertexWrapper(IGraphWrapper graphWrapper, string name)
        //{
        //    Vertex = new Vertex(graphWrapper.Graph, name);
        //    Coords = new PointF();
        //    Size = new Size();
        //}

        //public WFVertexWrapper(IGraphWrapper graphWrapper, string name, PointF coords)
        //{
        //    Vertex = new Vertex(graphWrapper.Graph, name);
        //    Coords = coords;
        //    Size = new Size();
        //}

        public virtual void Draw(Graphics g, Pen p)
        {
            RectangleF r = RectangleF;
            g.FillEllipse(
                            Brushes.White,
                            r
                         );
            g.DrawEllipse(
                            p,
                            r
                         );
            g.DrawString(
                Name,
                new Font("Arial", 8),
                Brushes.Blue,
                r.Right,
                r.Bottom
            );
        }

        public virtual void Draw(Graphics g, Pen p, MagicLibrary.MathUtils.Matrix m)
        {
            RectangleF r = RectangleF;
            MagicLibrary.Graphic.MGraphic.DrawFillEllipse(g,
                            Brushes.White,
                            r,
                            m
                         );
            MagicLibrary.Graphic.MGraphic.DrawEllipse(g,
                            p,
                            r,
                            m
                         );
            g.DrawString(
                Name,
                new Font("Arial", 8),
                Brushes.Blue,
                m * new PointF(r.Right, r.Bottom)
            );
        }

        public virtual bool Hit(float x, float y)
        {
            return RectangleF.Contains(x, y);
        }


        public virtual void EditVertex()
        {
            VertexModifyForm vm = new VertexModifyForm(this);
            vm.ShowDialog();
            if (vm.Succesful)
            {
                vm.VertexWrapper.CopyTo(this);// as MagicLibrary.MathUtils.Graphs.Vertex;
            }
        }


        public virtual void CopyTo(IVertexWrapper vertexWrapper)
        {
            WFVertexWrapper wrapper = vertexWrapper as WFVertexWrapper;
            wrapper.Coords = this.Coords;
            wrapper.SizeF = this.SizeF;
            wrapper.vertexValue = this.vertexValue;
            wrapper.graphWrapper = this.graphWrapper;
        }

        public virtual object Clone()
        {
            return new WFVertexWrapper(this.graphWrapper, this.Vertex)
                        {
                            Coords = this.Coords,
                            SizeF = this.SizeF
                        }
            ;
        }
    }
}
