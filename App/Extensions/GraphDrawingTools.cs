using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using MagicLibrary.MathUtils;
using MagicLibrary.Graphic;

using GraphEditor.App.Models;

namespace GraphEditor.App.Extensions2
{
    public static class GraphDrawingTools
    {
        public static void DrawVertex(this Graphics g, Pen p, WFVertexWrapper v)
        {
            RectangleF r = new RectangleF(v.Coords, v.Size);
            g.FillEllipse(
                            Brushes.White,
                            r
                         );
            g.DrawEllipse(
                            p,
                            r
                         );
            g.DrawString(
                v.Name,
                new Font("Arial", 8),
                Brushes.Blue,
                r.Left,
                r.Bottom
            );
        }

        public static void DrawArc(this Graphics g, Pen p, WFArcWrapper a)
        {
            PointF[] arrow = new PointF[3] {
                                                new PointF(-10,-5),
                                                new PointF(0,0),
                                                new PointF(-10,5)
                                            };
            double angle;
            Matrix dM;
            if (a.Points != null && a.Points.Length > 0)
            {
                angle = -Math.Atan2(tail.Coords.Y - a.Points[0].Y, a.Points[0].X - tail.Coords.X);
                PointF popravka = new PointF((float)Math.Cos(angle) * tail.Size.Width / 2,
                                     (float)Math.Sin(angle) * tail.Size.Height / 2);
                g.DrawLine(p, MGraphic.T(popravka.X, popravka.Y) * tail.Coords, a.Points[0]);
                for (int i = 0; i < a.Points.Length - 1; i++)
                    g.DrawLine(p, a.Points[i], a.Points[i + 1]);
                try
                {
                    angle = -Math.Atan2(a.Points[a.Points.Length - 1].Y - head.Coords.Y, head.Coords.X - a.Points[a.Points.Length - 1].X);
                    popravka = new PointF((float)Math.Cos(angle) * head.Size.Width / 2,
                                     (float)Math.Sin(angle) * head.Size.Height / 2);
                    g.DrawLine(p, a.Points[a.Points.Length - 1], MGraphic.T(-popravka.X, -popravka.Y) * head.Coords);
                    dM =
                           MGraphic.T(head.Coords.X - popravka.X, head.Coords.Y - popravka.Y)
                         * MGraphic.R(angle * 180 / Math.PI)
                    ;
                    g.DrawLines(p, dM * arrow);
                }
                catch { }
            }
            else
            {
                //angle = -Math.Atan2(a.Tail.Coords.Y - a.Head.Coords.Y, a.Head.Coords.X - a.Tail.Coords.X);
                //PointF popravka = new PointF((float)Math.Cos(angle) * a.Head.Size.Width / 2,
                //                         (float)Math.Sin(angle) * a.Head.Size.Height / 2);
                //g.DrawLine(p, MGraphic.T(popravka.X, popravka.Y) * a.Tail.Coords, MGraphic.T(-popravka.X, -popravka.Y) * a.Head.Coords);
                //dM =
                //           MGraphic.T(a.Head.Coords.X - popravka.X, a.Head.Coords.Y - popravka.Y)
                //         * MGraphic.R(angle * 180 / Math.PI)
                // ;    
                //g.DrawLines(p, dM * arrow);
                g.DrawLine(p, tail.Center, head.Center);
            }
        }

        //public static void DrawEdge(this Graphics g, Pen p, Edge e, List<PointF> a.Points)
        //{
        //    //if (a.Points != null && a.Points.Length > 0)
        //    //{
        //    //    g.DrawLines(p, a.Points.ToArray());
        //    //}
        //    //else
        //    //{
        //    //    double angle = -Math.Atan2(e.Tail.Coords.Y - a.Head.Coords.Y, a.Head.Coords.X - a.Tail.Coords.X);
        //    //    PointF popravka = new PointF((float)Math.Cos(angle) * a.Head.Size.Width / 2,
        //    //                             (float)Math.Sin(angle) * a.Head.Size.Height / 2);
        //    //    g.DrawLine(p, MGraphic.T(popravka.X, popravka.Y) * a.Tail.Coords, MGraphic.T(-popravka.X, -popravka.Y) * a.Head.Coords);
        //    //    dM =
        //    //               MGraphic.T(a.Head.Coords.X - popravka.X, a.Head.Coords.Y - popravka.Y)
        //    //             * MGraphic.R(angle * 180 / Math.PI)
        //    //     ;
        //    //    g.DrawLines(p, dM * arrow);
        //    //}
        //}

        public static void DrawGraph(this Graphics g, Pen p, WFGraphWrapper graphManager)
        {
            graphManager.Graph.GetEdges(e => true).ForEach(edge => g.DrawArc(p, edge as WFArcWrapper));
            graphManager.Graph.GetVertices(v => true).ForEach(vertex => g.DrawVertex(p, vertex as WFVertexWrapper));
        }
    }
}
