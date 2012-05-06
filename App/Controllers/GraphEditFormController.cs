using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MagicLibrary.MVC;
using GraphEditor.App.Views;
using System.IO;

namespace GraphEditor.App.Controllers
{
    public class GraphEditFormController : Controller
    {
        public GraphEditForm MainView { get { return View as GraphEditForm; } set { View = value; } }

        public GraphEditFormController(string name, GraphEditForm view)
            : base(name)
        {
            View = view;
        }

        public void SaveAction()
        {
            MainView.saveFileDialog1.FileName = MainView.tabControl1.SelectedTab.Text;
            if (MainView.saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MainView.selectedGraph.MainController.SaveGraph(MainView.saveFileDialog1.FileName);
                FileInfo fInfo = new FileInfo(MainView.saveFileDialog1.FileName);
                MainView.tabControl1.SelectedTab.Text = fInfo.Name;
            }
        }

        public void SelectRadioButton(RadioButton r)
        {
            if (!r.Checked)
            {
                return;
            }

            foreach (var rb in this.MainView.radioGroup)
            {
                if (r == rb.Key)
                {
                    this.SetAction(rb.Value);
                    continue;
                }
                rb.Key.Checked = false;
            }
        }

        public void OpenAction()
        {
            if (MainView.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                GraphView newG = this.NewGraphView();
                MainView.Graphs.Add(newG);
                TabPage page = new TabPage(this.MainView.newGraphName + MainView.count++);
                newG.Control.ClientSize = MainView.tabControl1.ClientSize;
                page.Controls.Add(newG.Control);
                page.AutoScroll = true;
                page.Scroll += new ScrollEventHandler(page_Scroll);
                MainView.tabControl1.TabPages.Add(page);
                MainView.tabControl1.SelectedIndex = MainView.tabControl1.TabCount - 1;

                if (MainView.selectedGraph.MainController.OpenGraph(MainView.openFileDialog1.FileName))
                {
                    page.Text = MainView.openFileDialog1.SafeFileName;
                    MainView.GraphMenuEnable = true;
                    MainView.Refresh();
                }
                else
                {
                    MainView.tabControl1.TabPages.Remove(page);
                    MessageBox.Show("Invalid file format!");
                }
            }
        }

        public void CreateAction()
        {
            //MainView.graphs.Add(new GraphView(new TabPage("Новый граф " + MainView.count++)));
            GraphView newG = this.NewGraphView();
            MainView.Graphs.Add(newG);
            TabPage page = new TabPage(MainView.newGraphName + MainView.count++);
            newG.Control.ClientSize = MainView.tabControl1.ClientSize;
            page.Controls.Add(newG.Control);
            page.AutoScroll = true;
            page.Scroll += new ScrollEventHandler(page_Scroll);
            MainView.tabControl1.TabPages.Add(page);
            MainView.tabControl1.SelectedIndex = MainView.tabControl1.TabCount - 1;
            MainView.GraphMenuEnable = true;
        }

        public virtual GraphView NewGraphView()
        {
            return new GraphView(new PictureBox());
        }

        public void page_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type.HasFlag(ScrollEventType.SmallIncrement) && e.OldValue == e.NewValue && !e.Type.HasFlag(ScrollEventType.ThumbTrack))
            {
                if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                    MainView.selectedGraph.Control.Size = new System.Drawing.Size(MainView.selectedGraph.Control.Size.Width + 20, MainView.selectedGraph.Control.Size.Height);
                if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
                    MainView.selectedGraph.Control.Size = new System.Drawing.Size(MainView.selectedGraph.Control.Size.Width, MainView.selectedGraph.Control.Size.Height + 20);
            }
        }

        public void CloseAction()
        {
            MainView.tabControl1.TabPages.Remove(MainView.tabControl1.SelectedTab);
            if (MainView.tabControl1.TabCount == 0)
                MainView.GraphMenuEnable = false;
        }

        public void SetAction(GraphEditAction graphEditAction)
        {
            MainView.selectedGraph.SelectAction(graphEditAction);
            MainView.Refresh();
        }
    }
}
