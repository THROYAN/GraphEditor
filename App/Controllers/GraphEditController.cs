using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

using MagicLibrary.MVC;

using GraphEditor.App.Models;
using GraphEditor.App.Views;

namespace GraphEditor.App.Controllers
{
    public class GraphEditController : Controller
    {
        public GraphEditController(GraphView view, string name)
            : base(name)
        {
            View = view;
        }

        /// <summary>
        /// Вид
        /// </summary>
        private GraphView geView { get { return View as GraphView; } }

        public void ViewLoad()
        {
            geView.graphWrapper = new WFGraphWrapper( new MagicLibrary.MathUtils.Graphs.WeightedBiGraph() );
            geView.points = new List<PointF>();
            geView.action = GraphEditActions.AddVertex;
            geView.selectedVertexIndex = -1;
            geView.selectionVertexIndex = -1;
            geView.selectionArcIndex = -1;
            geView.selectionArcPointIndex = -1;
            geView.selectedArcPointIndex = -1;
            geView.action = GraphEditActions.Edit;
        }

        /// <summary>
        /// Если мышка выделяет вершину, то изменяется соотвествующая переменная на виде. (С перерисовской).
        /// </summary>
        /// <param name="coords">Координаты мышки.</param>
        public void SelectVertex(PointF coords)
        {
            int temp = geView.selectionVertexIndex;
            geView.selectionVertexIndex = GetSelectedVertexIndex(coords);
            if (geView.selectionVertexIndex != temp)
                geView.Refresh();
        }

        /// <summary>
        /// Добавление вершины, если не выбрана другая вершина.
        /// </summary>
        /// <param name="coords">Координаты мышки</param>
        public void AddVertexIfSelected(PointF coords)
        {
            if (geView.selectionVertexIndex == -1)
            {
                this.AddVertex(coords);

                SizeF newS = new SizeF(geView.Control.ClientSize.Width,geView.Control.ClientSize.Height);

                if (coords.X + geView.graphWrapper.DefaultVertexSize.Width > newS.Width)
                {
                    newS.Width = coords.X + geView.graphWrapper.DefaultVertexSize.Width;
                }
                if (coords.Y + geView.graphWrapper.DefaultVertexSize.Height > newS.Height)
                {
                    newS.Height = coords.X + geView.graphWrapper.DefaultVertexSize.Height;
                }
                geView.Control.ClientSize = new Size((int)newS.Width, (int)newS.Height);
            }
            geView.selectionVertexIndex = -1;
        }

        public virtual void AddVertex(PointF coords)
        {
            geView.graphWrapper.AddVertex(geView.TransformationMatrix.Reverse() * coords);
        }

        /// <summary>
        /// Возвращает вершину, которая выбрана мышкой. Может быть null.
        /// </summary>
        /// <param name="coords">Координаты мышки.</param>
        /// <returns>Вершина</returns>
        public IVertexWrapper GetSelectedVertex(PointF coords)
        {
            //geView.Debug(
            //    geView.TransformationMatrix.Reverse().ToString() + "\n______\n" +
            //    geView.TransformationMatrix.ToString()
            //);
            PointF p = geView.TransformationMatrix.Reverse() * coords;
            return geView.graphWrapper.VertexWrappers.Find(v => v.Hit(p.X, p.Y)) as IVertexWrapper;
        }

        public int GetSelectedVertexIndex(PointF coords)
        {
            IVertexWrapper v = GetSelectedVertex(coords);
            return geView.graphWrapper.VertexWrappers.IndexOf(v);
        }

        /// <summary>
        /// Добавление дуги между двумя вершинами или добавление точки дуги.
        /// </summary>
        /// <param name="coords">Координаты мышки.</param>
        public void AddArcAction(Point coords)
        {
            if (geView.selectionVertexIndex != -1 && geView.selectedVertexIndex != -1)
            {
                geView.points.RemoveAt(geView.points.Count - 1);

                this.AddArc(coords);

                geView.points.Clear();
                geView.action = GraphEditActions.AddArcSelectFirstVertex;
                geView.selectedVertexIndex = -1;
            }
            else if (geView.selectedVertexIndex != -1)
            {
                geView.points.Add(geView.TransformationMatrix.Reverse() * coords);
            }
        }

        public virtual void AddArc(Point coords)
        {
            geView.graphWrapper.AddArc(geView.graphWrapper.VertexWrappers[geView.selectedVertexIndex].Name, geView.graphWrapper.VertexWrappers[geView.selectionVertexIndex].Name, 1, geView.points.ToArray());
        }

        /// <summary>
        /// Запоминает выбранную вершину, которая выделена мышкой, как хвост будущей дуги.
        /// После чего пользователь будет выбирать вторую вершину - голову дуги.
        /// </summary>
        public void SelectFirstVertex()
        {
            if (geView.selectionVertexIndex != -1)
            {
                geView.selectedVertexIndex = geView.selectionVertexIndex;
                geView.action = GraphEditActions.AddArcSelectSecondVertex;
            }
        }

        public int GetSelectedArcPointIndex(Point coords)
        {
            int res = -1;

            PointF p = geView.TransformationMatrix.Reverse() * coords;

            geView.graphWrapper.ArcWrappers.ForEach(delegate(IArcWrapper a)
            {
                int index = (a as WFArcWrapper).HitPoint(p.X, p.Y);
                if (index != -1)
                {
                    res = index;
                    return;
                }
            });
            return res;
        }

        public void SelectArcPoint(Point coords)
        {
            int temp = geView.selectionArcPointIndex;
            geView.selectionArcPointIndex = GetSelectedArcPointIndex(coords);

            int temp1 = geView.selectionArcIndex;
            PointF p = geView.TransformationMatrix.Reverse() * coords;

            if (geView.selectionArcIndex == -1)
                geView.selectionArcIndex = geView.graphWrapper.ArcWrappers.FindIndex(a => (a as WFArcWrapper).HitPoint(p.X, p.Y) != -1);

            if (geView.selectionArcPointIndex != temp || geView.selectionArcIndex != temp1)
                geView.Refresh();
        }

        /// <summary>
        /// Это вообще дерьмо
        /// </summary>
        /// <param name="coords"></param>
        public void GraphEdit(Point coords)
        {
            switch (geView.action)
            {
                case GraphEditActions.Edit:
                    //If the vertex wasn't selected,
                    if (geView.selectedVertexIndex == -1)
                    {
                        if (geView.selectedArcPointIndex == -1)
                        {
                            geView.selectedVertexIndex = GetSelectedVertexIndex(coords);
                            if (geView.selectedVertexIndex == -1 && geView.selectedArcPointIndex == -1)
                            {
                                geView.selectedArcPointIndex = GetSelectedArcPointIndex(coords);
                                if (geView.selectedArcPointIndex == -1)
                                {
                                    geView.Control.ContextMenu = null;
                                    //this.StartDrag(coords);
                                }
                            }
                            else
                            {
                                geView.selectedArcPointIndex = -1;
                            }
                        }
                        else
                        {
                            geView.selectedArcPointIndex = -1;
                        }
                    }
                    //If the vertex was selected and user clicked, the vertex makes unselected.
                    else
                        geView.selectedVertexIndex = -1;
                    break;
                case GraphEditActions.AddVertex:
                    AddVertexIfSelected(coords);
                    break;
                case GraphEditActions.AddArcSelectFirstVertex:
                    SelectFirstVertex();
                    break;
                case GraphEditActions.AddArcSelectSecondVertex:
                    AddArcAction(coords);
                    break;
                case GraphEditActions.RemoveVertex:
                    RemoveSelectedVertex();
                    break;
                case GraphEditActions.RemoveArc:
                    RemoveSelectedArc(coords);
                    break;
                case GraphEditActions.ChangeArcWeight:
                    SetArcWeight(coords);
                    break;
                case GraphEditActions.SomethingElse:
                    DoSomethingElse(coords);
                    break;
            }
            geView.Refresh();
        }

        public virtual void DoSomethingElse(PointF coords) { }
        public virtual void DoSomethingElseDinamic(PointF coords) { }

        public void RemoveSelectedVertex()
        {
            if (geView.selectionVertexIndex != -1)
            {
                geView.graphWrapper.Graph.RemoveVertex(geView.graphWrapper.VertexWrappers[geView.selectionVertexIndex].Name);
                geView.selectionVertexIndex = -1;
                geView.Refresh();
            }
        }

        public void SetArcWeight(Point p)
        {
            IArcWrapper arc = GetSelectedArc(p);
            if (arc != null)
            {
                arc.Weight = geView.SetArcWeightForm(arc.Weight);
                geView.Refresh();
            }
        }

        public void SetArcWeight()
        {
            IArcWrapper arc = geView.graphWrapper.ArcWrappers[geView.selectionArcIndex];
            if (arc != null)
            {
                //arc.Weight = geView.SetArcWeightForm(arc.Weight);
                arc.EditArc();

                geView.Refresh();
            }
        }

        public void RemoveSelectedArc(Point coords)
        {
            IArcWrapper arc = GetSelectedArc(coords);
            if (arc != null)
            {
                geView.graphWrapper.Graph.RemoveEdge(arc.Tail.Name, arc.Head.Name);
                geView.selectionArcIndex = -1;
                geView.Refresh();
            }
        }

        public void RemoveSelectedArc()
        {
            IArcWrapper arc = geView.graphWrapper.ArcWrappers[geView.selectionArcIndex];
            if (arc != null)
            {
                geView.graphWrapper.Graph.RemoveEdge(arc.Tail.Name, arc.Head.Name);
                geView.selectionArcIndex = -1;
                geView.Refresh();
            }
        }

        public IArcWrapper GetSelectedArc(Point coords)
        {
            PointF p = geView.TransformationMatrix.Reverse() * coords;

            return geView.graphWrapper.ArcWrappers.Find(e => e.Hit(p.X, p.Y));
        }

        public int GetSelectedArcIndex(Point coords)
        {
            return geView.graphWrapper.ArcWrappers.IndexOf(GetSelectedArc(coords));
        }

        public void SelectArc(Point point)
        {
            int temp = geView.selectionArcIndex;
            geView.selectionArcIndex = geView.graphWrapper.ArcWrappers.IndexOf(GetSelectedArc(point));
            if (geView.selectionArcIndex != temp)
                geView.Refresh();
        }

        public void SelectItems(Point mCoords)
        {
            geView.mCoords = mCoords;
            switch (geView.action)
            {
                case GraphEditActions.Edit:
                    // Если пользователь не перемещает вершину
                    if (geView.selectedVertexIndex == -1)
                    {
                        // Если пользователь не перемещает точку
                        if (geView.selectedArcPointIndex == -1)
                        {

                            SelectVertex(mCoords);

                            // Если он навёл мышкой на вершину, то устанавливаем меню для вершины
                            if (geView.selectionVertexIndex != -1)
                            {
                                geView.selectionArcIndex = -1;
                                geView.Control.ContextMenu = geView.menus["Вершина"];
                            }
                            // Если нет, то возможно выбрал дугу или точку
                            else
                            {
                                SelectArcPoint(mCoords);

                                // If arcPoint was selected, use that contextmenu
                                if (geView.selectionArcPointIndex != -1)
                                {
                                    if ((geView.graphWrapper.ArcWrappers[geView.selectionArcIndex] as WFArcWrapper).IsSpline(geView.selectionArcPointIndex))
                                    {
                                        geView.Control.ContextMenu = geView.menus["Загнутая точка дуги"];
                                    }
                                    else
                                    {
                                        geView.Control.ContextMenu = geView.menus["Точка дуги"];
                                    }
                                }
                                // Else, select the arc
                                else
                                {
                                    SelectArc(mCoords);
                                    // If arc was selected, use arcContextmenu
                                    if (geView.selectionArcIndex != -1)
                                    {
                                        geView.Control.ContextMenu = geView.menus["Дуга"];
                                    }
                                    //Else, move the field
                                    else
                                    {
                                        //this.Drag(mCoords);
                                        geView.Control.ContextMenu = null;
                                    }
                                }
                            }
                        }
                        // Перемещает точку
                        else
                        {
                            (geView.graphWrapper.ArcWrappers[geView.selectionArcIndex] as WFArcWrapper).Points[geView.selectedArcPointIndex] = this.geView.TransformationMatrix.Reverse() * mCoords;
                            geView.Refresh();
                        }
                    }
                    // Перемещает вершину
                    else
                    {
                        
                        (geView.graphWrapper.VertexWrappers[geView.selectedVertexIndex] as WFVertexWrapper).Center = geView.TransformationMatrix.Reverse() * mCoords;
                        geView.Refresh();
                    }
                    break;
                case GraphEditActions.RemoveVertex:
                case GraphEditActions.AddArcSelectFirstVertex:
                    SelectVertex(mCoords);
                    break;
                case GraphEditActions.AddArcSelectSecondVertex:
                    SelectVertex(mCoords);
                    if (geView.points == null)
                    {
                        geView.points = new List<PointF>();
                    }
                    if (geView.points.Count == 0)
                    {
                        geView.points.Add(geView.TransformationMatrix.Reverse() * mCoords);
                    }
                    else if (geView.selectedVertexIndex != -1 && geView.selectionVertexIndex == -1)
                    {
                        geView.points[geView.points.Count - 1] = geView.TransformationMatrix.Reverse() * mCoords;
                        geView.Refresh();
                    }
                    break;
                case GraphEditActions.AddVertex:
                    geView.selectionVertexIndex = GetSelectedVertexIndex(mCoords);
                    break;
                case GraphEditActions.RemoveArc:
                case GraphEditActions.ChangeArcWeight:
                    SelectArc(mCoords);
                    break;
                case GraphEditActions.SomethingElse:
                    DoSomethingElseDinamic(mCoords);
                    break;
            }
        }

        public void SaveGraph(string path)
        {
            StreamWriter sw = new StreamWriter(path, false);
            BinaryFormatter bw = new BinaryFormatter();
            bw.Serialize(sw.BaseStream, geView.graphWrapper);
            geView.Control.Text = new FileInfo(path).Name;
            sw.Close();
        }

        public virtual bool OpenGraph(string path)
        {
            try
            {
                StreamReader sr = new StreamReader(path);
                BinaryFormatter bw = new BinaryFormatter();
                geView.graphWrapper = bw.Deserialize(sr.BaseStream) as WFGraphWrapper;
                geView.Control.Text = new FileInfo(path).Name;
                sr.BaseStream.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void RenameSelectedVertex()
        {
            IVertexWrapper v = geView.graphWrapper.VertexWrappers[geView.selectionVertexIndex];
            v.EditVertex();
            geView.Refresh();
            //v.Name = geView.RenameVertexForm(v.Name);

        }

        internal void DeleteSelectedArcPoint()
        {
            WFArcWrapper slArc = (geView.graphWrapper.ArcWrappers[geView.selectionArcIndex] as WFArcWrapper);
            //List<PointF> ps = new List<PointF>(slArc.Points);
            //ps.RemoveAt(geView.selectionArcPointIndex);
            //slArc.Points = ps.ToArray();
            slArc.RemoveArcPointAt(geView.selectionArcPointIndex);
            geView.Refresh();
        }

        public void AddPoint(Point point)
        {
            PointF p = this.geView.TransformationMatrix.Reverse() * point;

            (this.geView.graphWrapper.ArcWrappers[this.geView.selectionArcIndex] as WFArcWrapper).AddPointOnLine(p);
            geView.Refresh();
        }

        public void TogglePointType()
        {
            if (this.geView.selectionArcPointIndex != -1)
            {
                (this.geView.graphWrapper.ArcWrappers[this.geView.selectionArcIndex] as WFArcWrapper).TogglePoint(
                    this.geView.selectionArcPointIndex
                    );
                this.geView.Refresh();
            }
        }

        public void Drag(Point mCoords)
        {
            geView.Control.ContextMenu = null;
            if (geView.move)
            {
                geView.Transpanation =
                    MagicLibrary.Graphic.MGraphic.T(-geView.MoveFrom.X, -geView.MoveFrom.Y)
                    * MagicLibrary.Graphic.MGraphic.T(mCoords)
                    * geView.Transpanation;
                geView.MoveFrom = mCoords;
                geView.Refresh();
            }
        }

        public void EndDrag(Point mCoords)
        {
            Drag(mCoords);
            geView.move = false;
        }

        public void StartDrag(Point mCoords)
        {
            geView.move = true;
            geView.MoveFrom = mCoords;
        }

        public void SetEditAction(GraphEditActions graphEditAction)
        {
            this.geView.Control.ContextMenu = null;
            this.geView.action = graphEditAction;
        }
    }
}
