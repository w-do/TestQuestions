using System.Collections.Generic;
using System.Linq;

namespace Triangle
{
    class TriangleChecker
    {
        public static string GetTriangleType(int sideOne, int sideTwo, int sideThree)
        {
            if (!IsPolygon(new List<int> { sideOne, sideTwo, sideThree }))
            {
                return "Not a valid triangle";
            }

            if (sideOne == sideTwo && sideTwo == sideThree)
            {
                return "Equilateral";
            }

            if (sideOne == sideTwo ||
                sideOne == sideThree ||
                sideThree == sideOne)
            {
                return "Isosceles";
            }

            // If a valid triangle is not an equilateral or isoscelese triangle, it must be a scalene triangle
            return "Scalene";
        }

        private static bool IsPolygon(IList<int> sides)
        {
            if (!sides.Any())
            {
                return false;
            }

            // Originally this was "IsTriangle" but I realized the following two checks should apply to any polygon
            // Note - consider refactoring this out later if you have time

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
