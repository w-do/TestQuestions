using System.Collections.Generic;
using Triangle.Enumerations;
using Triangle.Interfaces;

namespace Triangle.Services
{
    public class TriangleService : ITriangleService
    {
        private readonly IPolygonService _polygonService;

        public TriangleService(IPolygonService polygonService)
        {
            _polygonService = polygonService;
        }

        public TriangleType GetTriangleType(int sideOne, int sideTwo, int sideThree)
        {
            if (!_polygonService.IsPolygon(new List<int> { sideOne, sideTwo, sideThree }))
            {
                return TriangleType.NotAValidTriangle;
            }

            if (sideOne == sideTwo && sideTwo == sideThree)
            {
                return TriangleType.Equilateral;
            }

            if (sideOne == sideTwo ||
                sideTwo == sideThree ||
                sideThree == sideOne)
            {
                return TriangleType.Isosceles;
            }

            return TriangleType.Scalene;
        }

    }
}
