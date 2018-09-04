using System;
using System.Collections.Generic;
using System.Linq;
using Triangle.Interfaces;

namespace Triangle.Services
{
    public class PolygonService : IPolygonService
    {
        public bool IsPolygon(IList<int> sides)
        {
            if (sides.Count < 3)
            {
                return false;
            }

            if (sides.Any(x => x <= 0))
            {
                return false;
            }

            var orderedSides = sides.Select(Convert.ToInt64).OrderByDescending(x => x);

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
