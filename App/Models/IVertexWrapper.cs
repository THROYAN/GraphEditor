using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MagicLibrary.MathUtils.Graphs;

namespace GraphEditor.App.Models
{
    public interface IVertexWrapper
    {
        IGraphWrapper graphWrapper { get; set; }
        IVertex Vertex { get; set; }
        string Name { get; set; }
        object VertexValue { get; set; }

        bool Hit(float x, float y);

        void EditVertex();

        void CopyTo(IVertexWrapper vertexWrapper);

        object Clone();

        bool EqualsVetices(IVertex vertex);
    }
}
