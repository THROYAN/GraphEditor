using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using Microsoft.VisualBasic;

using MagicLibrary.MathUtils.Graphs;
using MagicLibrary.MVC.WinForms;
using GraphEditor.App.Models;
using GraphEditor.App.Controllers;

namespace GraphEditor.App.Views
{
    public class GraphView : WFControlView
    {
        public Point mCoords { get; set; }
        /// <summary>
        /// Обёртка графа
        /// </summary>
        public WFGraphWrapper graphWrapper { get; set; }

        /// <summary>
        /// Переменная, указывающая на действие, выбранное пользователем.
        /// В зависимости от значения этой переменной будут выполняться соответсвующие методы при нажатии и движении мыши.
        /// </summary>
        public GraphEditAction action;

        /// <summary>
        /// Индекс вершины, на которую пользователь навёл мышью.
        /// </summary>
        public int selectionVertexIndex;

        /// <summary>
        /// Индекс вершины, на которую пользователь нажал мышью.
        /// </summary>
        public int selectedVertexIndex;

        /// <summary>
        /// Индекс дуги, на которую пользователь навёл мышью.
        /// </summary>
        public int selectionArcIndex;

        /// <summary>
        /// Индекс точки выбранной дуги, на которую пользователь навёл крысой.
        /// </summary>
        public int selectionArcPointIndex;

        /// <summary>
        /// Индекс точки выбранной дуги, на которую пользователь нажал крысой.
        /// </summary>
        public int selectedArcPointIndex;

        /// <summary>
        /// Список точек для добавления и вывода дуг, состоящих из нескольких линий.
        /// </summary>
        public List<PointF> points;

        public double Scaling { get; set; }

        public PointF Transpanation { get; set; }

        public bool move = false;

        public PointF MoveFrom { get; set; }

        public Bitmap Bitmap { get; private set; }

        public GraphEditController MainController
        {
            get { return GetController("MainController") as GraphEditController; }
            set { Controllers.RemoveAll(c => c.Name == value.Name); AddController(value); }
        }

        public GraphView(Control control)
            : base(control)
        {
            #region Классное включение двойной буфферизации =))
                Control.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(Control, true, null);
            #endregion
                Control.Dock = DockStyle.Fill;

            Controllers.Add(new GraphEditController(this, "MainController"));
            MainController.ViewLoad();
            Scaling = 1;
            Transpanation = new PointF();

            menus = new Dictionary<string, ContextMenu>()
            {
                {"Вершина", new ContextMenu(new MenuItem[]{
                    new MenuItem("Редактор вершины",new EventHandler(RenameVertex)),
                    new MenuItem("Удалить вершину",new EventHandler(DeleteVertex)),
                })},
                {"Дуга", new ContextMenu(new MenuItem[]{
                    new MenuItem("Редактор дуги",new EventHandler(ChangeArcWeight)),
                    new MenuItem("Добавить точку",new EventHandler(AddPoint)),
                    new MenuItem("Удалить дугу",new EventHandler(DeleteArc)),
                })},
                {"Точка дуги", new ContextMenu(new MenuItem[]{
                    new MenuItem("Удалить точку",new EventHandler(DeletePoint)),
                    new MenuItem("Плавный поворот",new EventHandler(ChangePointType))
                })},
                {"Загнутая точка дуги", new ContextMenu(new MenuItem[]{
                    new MenuItem("Удалить точку",new EventHandler(DeletePoint)),
                    new MenuItem("Резкий поворот",new EventHandler(ChangePointType))
                })},
            };

            Control.Paint += new PaintEventHandler(DrawingGraph);
            Control.MouseMove += new MouseEventHandler(Control_MouseMove);
            Control.MouseClick += new MouseEventHandler(Control_MouseClick);
            Control.MouseDown += new MouseEventHandler(Control_MouseDown);
            Control.MouseUp += new MouseEventHandler(Control_MouseUp);

            Control.BackColor = Color.White;
            
            Control parent = Control.Parent;
            while(parent != null && parent.Focus())
            {
                parent = parent.Parent;
            }
            if(parent != null)
                parent.MouseWheel+=new MouseEventHandler(Control_MouseWheel);

            // Debug
            this.debugLabel = new Label() { Text ="",Name="debugLabel",AutoSize= true,BorderStyle = BorderStyle.FixedSingle };
            Control.Controls.Add(this.debugLabel);
        }

        void Control_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MainController.EndDrag(e.Location);
                this.Control.Cursor = Cursors.Default;
            }
        }

        void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MainController.StartDrag(e.Location);
                this.Control.Cursor = Cursors.NoMove2D;
            }
        }

        void Control_MouseWheel(object sender, MouseEventArgs e)
        {
            Scaling += e.Delta / 1200;
            Refresh();
        }

        void AddPoint(object sender, EventArgs e)
        {
            this.MainController.AddPoint(this.mCoords);
        }
        
        void DeletePoint(object sender, EventArgs e)
        {
            MainController.DeleteSelectedArcPoint();
        }

        void ChangePointType(object sender, EventArgs e)
        {
            MainController.TogglePointType();
        }

        void DeleteVertex(object sender, EventArgs e)
        {
            MainController.RemoveSelectedVertex();
        }

        void RenameVertex(object sender, EventArgs e)
        {
            MainController.RenameSelectedVertex();
        }

        void ChangeArcWeight(object sender, EventArgs e)
        {
            MainController.SetArcWeight();
        }

        void DeleteArc(object sender, EventArgs e)
        {
            MainController.RemoveSelectedArc();
        }

        void Control_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MainController.GraphEdit(e.Location);
        }

        void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                MainController.SelectItems(e.Location);
            else
                MainController.Drag(e.Location);
        }

        void DrawingGraph(object sender, PaintEventArgs e)
        {
            
            MagicLibrary.MathUtils.Matrix m = this.TransformationMatrix;

            e.Graphics.Transform = m.ToSystemMatrix();

            graphWrapper.Draw(e.Graphics, Pens.Black);

#warning гавнокод!
            #region Вывод куска дуги при добавлении
            if (selectedVertexIndex != -1 && points != null && points.Count > 0)
            {
                Arc wArc = new Arc(graphWrapper.Graph, graphWrapper.VertexWrappers[selectedVertexIndex].Name, null);
                WFArcWrapper arc = new WFArcWrapper(graphWrapper, wArc) { Points = points.ToArray() };
                arc.Draw(e.Graphics, Pens.Gray);
            }
            #endregion

            if (selectionVertexIndex != -1)
                //e.Graphics.DrawRectangle(
                //    Pens.Green,
                //    graphWrapper[selectionVertexIndex].SelectionRectangle
                //);
                e.Graphics.DrawRectangle(Pens.Green, (graphWrapper.VertexWrappers[selectionVertexIndex] as WFVertexWrapper).SelectionRectangle);

            if (selectedVertexIndex != -1)
                (graphWrapper.VertexWrappers[selectedVertexIndex] as WFVertexWrapper).Draw(e.Graphics, Pens.Green);

            if (selectionArcIndex != -1)
            {
                WFArcWrapper selArc = graphWrapper.ArcWrappers[selectionArcIndex] as WFArcWrapper;
                //e.Graphics.DrawRectangle(Pens.Red, selArc.WeightRectangle(e.Graphics));
                e.Graphics.DrawRectangle(Pens.Red, selArc.TextRectangle(e.Graphics));
                selArc.Draw(e.Graphics, Pens.Red, true);

                if (selectionArcPointIndex != -1)
                {
                    //e.Graphics.FillEllipse(Brushes.Azure,
                    //    selArc.Points[selectionArcPointIndex].X - 2,
                    //    selArc.Points[selectionArcPointIndex].Y - 2,
                    //    4,
                    //    4);
                    //e.Graphics.DrawEllipse(Pens.Black,
                    //    selArc.Points[selectionArcPointIndex].X - 2,
                    //    selArc.Points[selectionArcPointIndex].Y - 2,
                    //    4,
                    //    4);
                    e.Graphics.FillEllipse(Brushes.Azure, selArc.PointRectangle(selectionArcPointIndex));
                    e.Graphics.DrawEllipse(Pens.Black, selArc.PointRectangle(selectionArcPointIndex));
                    //MagicLibrary.Graphic.MGraphic.DrawFillEllipse(e.Graphics,Brushes.Azure, selArc.PointRectangle(selectionArcPointIndex));
                    //MagicLibrary.Graphic.MGraphic.DrawEllipse(e.Graphics,Pens.Black, selArc.PointRectangle(selectionArcPointIndex));
                }
            }
            
        }

        public double SetArcWeightForm(double weight)
        {
            string w = Interaction.InputBox("Введите вес дуги:", "Редактирование графа:", weight.ToString());

            try
            {
                return Convert.ToDouble(w);
            }
            catch
            {
                return weight;
            }
        }

        public string RenameVertexForm(string name)
        {
            return Interaction.InputBox("Введите новое имя:", "Редактирование вершины:", name);
        }

        public Dictionary<string,ContextMenu> menus { get; set; }

        public MagicLibrary.MathUtils.Matrix TransformationMatrix
        {
            get
            {
                return MagicLibrary.Graphic.MGraphic.S(Scaling, Scaling)
                                                * MagicLibrary.Graphic.MGraphic.T(Transpanation)
                ;
            }
        }

        public void Debug(string message)
        {
            this.debugLabel.Text = message;
        }

        private Label debugLabel { get; set; }

        public void SelectAction(GraphEditAction graphEditAction)
        {
            this.MainController.SetEditAction(graphEditAction);
        }
    }

    [Serializable]
    public enum GraphEditAction { AddVertex, AddArcSelectFirstVertex, AddArcSelectSecondVertex, RemoveArc, RemoveVertex, ChangeArcWeight, SomethingElse, Edit }
}
