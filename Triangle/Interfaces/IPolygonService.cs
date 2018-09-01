using System.Collections.Generic;

namespace Triangle.Interfaces
{
    public interface IPolygonService
    {
        bool IsPolygon(IList<int> sides);
    }
}
