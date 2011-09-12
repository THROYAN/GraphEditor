using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GraphEditor.App.Models;

namespace GraphEditor.App.Views
{
    public interface IGraphConstructor
    {
        bool Succesful { get; set; }
        WFGraphWrapper GraphWrapper { get; set; }
    }
}
