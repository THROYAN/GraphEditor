using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MagicLibrary.MathUtils.Graphs;

namespace GraphEditor.App.Models
{
    public interface IGraphWrapper
    {
        IGraph Graph { get; set; }

        List<IArcWrapper> ArcWrappers { get; set; }
        List<IVertexWrapper> VertexWrappers { get; set; }

        void CopyTo(IGraphWrapper graphWrapper);

        /// <summary>
        /// Создаёт неполную копию обёртки
        /// </summary>
        /// <returns></returns>
        object Clone();

        void EditGraph();
    }
}
