using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GraphEditor.App.Models;

namespace GraphEditor.App.Views
{
    public partial class Form1 : GraphConstructorForm
    {
        public Form1(WFGraphWrapper g) : base(g)
        {
            InitializeComponent();
        }
    }
}
