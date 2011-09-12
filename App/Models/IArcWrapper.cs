using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MagicLibrary.MathUtils.Graphs;

namespace GraphEditor.App.Models
{
    public interface IArcWrapper
    {
        IGraphWrapper graphWrapper { get; set; }

        IEdge Edge { get; set; }

        double Weight { get; set; }
        IVertexWrapper Head { get; set; }
        IVertexWrapper Tail { get; set; }

        bool Hit(float x, float y);

        void EditArc();

        bool EqualsEdges(IEdge edge);

        object Clone();
        void CopyTo(IArcWrapper arcWrapper);
    }
}
