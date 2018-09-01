using System.Collections.Generic;
using Triangle.Interfaces;

namespace Triangle
{
    public class TriangleService
    {
        private readonly IPolygonService _polygonService;

        public TriangleService(IPolygonService polygonService)
        {
            _polygonService = polygonService;
        }

        public string GetTriangleType(int sideOne, int sideTwo, int sideThree)
        {
            if (!_polygonService.IsPolygon(new List<int> { sideOne, sideTwo, sideThree }))
            {
                return "Not a valid triangle";
            }

            if (sideOne == sideTwo && sideTwo == sideThree)
            {
                return "Equilateral";
            }

            if (sideOne == sideTwo ||
                sideTwo == sideThree ||
                sideThree == sideOne)
            {
                return "Isosceles";
            }

            return "Scalene";
        }

    }
}
