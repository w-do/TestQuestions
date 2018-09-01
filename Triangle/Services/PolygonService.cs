using System.Collections.Generic;
using System.Linq;
using Triangle.Interfaces;

namespace Triangle
{
    public class PolygonService : IPolygonService
    {
        public bool IsPolygon(IList<int> sides)
        {
            if (!sides.Any())
            {
                return false;
            }

            // Originally this was "IsTriangle" but I realized the following two checks should apply to any polygon

            // no invalid sides
            if (sides.Any(x => x <= 0))
            {
                return false;
            }

            var orderedSides = sides.OrderByDescending(x => x);

            var largestSide = orderedSides.First();
            var sumOfRemainingSides = orderedSides.Sum() - largestSide;

            if (largestSide >= sumOfRemainingSides)
            {
                return false;
            }

            return true;
        }
    }
}
