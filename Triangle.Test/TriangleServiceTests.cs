using System.Collections.Generic;
using Triangle.Enumerations;
using Triangle.Services;
using Xunit;

namespace Triangle.Test
{
    public class TriangleServiceTests
    {
        [Theory]
        [InlineData(0, 0, 0)] // all zeroes
        [InlineData(-1, -1, -1)] // all negatives
        [InlineData(-2147483648, -2147483648, -2147483648)]
        [InlineData(3, 0, 2)] // one zero
        [InlineData(4, 5, -6)] // one negative
        [InlineData(1, 0, -1)] // one of each
        [InlineData(1, 2, 3)] // largest side equals smaller sides
        [InlineData(3, 3, 10)] // largest side exceeds smaller sides
        public void GetTriangleType_ImpossibleSides_ReturnsInvalidTriangle(int sideOne, int sideTwo, int sideThree)
        {
            var triangleService = new TriangleService(new PolygonService());

            var results = new List<TriangleType>
            {
                triangleService.GetTriangleType(sideOne, sideTwo, sideThree),
                triangleService.GetTriangleType(sideOne, sideThree, sideTwo),
                triangleService.GetTriangleType(sideTwo, sideOne, sideThree),
                triangleService.GetTriangleType(sideTwo, sideThree, sideOne),
                triangleService.GetTriangleType(sideThree, sideOne, sideTwo),
                triangleService.GetTriangleType(sideThree, sideTwo, sideOne)
            };

            Assert.All(results, x => Assert.Equal(TriangleType.NotAValidTriangle, x));
        }

        [Theory]
        [InlineData(1, 1, 1)] // smallest equilateral with int32 sides
        [InlineData(2147483647, 2147483647, 2147483647)] // largest equilateral with int32 sides
        [InlineData(600, 600, 600)] // something in between
        public void GetTriangleType_ThreeEqualSides_ReturnsEquilateral(int sideOne, int sideTwo, int sideThree)
        {
            var triangleService = new TriangleService(new PolygonService());

            var results = new List<TriangleType>
            {
                triangleService.GetTriangleType(sideOne, sideTwo, sideThree),
                triangleService.GetTriangleType(sideOne, sideThree, sideTwo),
                triangleService.GetTriangleType(sideTwo, sideOne, sideThree),
                triangleService.GetTriangleType(sideTwo, sideThree, sideOne),
                triangleService.GetTriangleType(sideThree, sideOne, sideTwo),
                triangleService.GetTriangleType(sideThree, sideTwo, sideOne)
            };

            Assert.All(results, x => Assert.Equal(TriangleType.Equilateral, x));
        }

        [Theory]
        [InlineData(2, 2, 1)] // unique side is smallest of the three
        [InlineData(3, 2, 2)] // unique side is largest of the three
        [InlineData(2147483647, 2147483647, 2147483646)] // largest isoceles with int32 sides
        [InlineData(2147483647, 2147483647, 1)] // min and max int32 sides
        public void GetTriangleType_ExactlyTwoEqualSides_ReturnsIsosceles(int sideOne, int sideTwo, int sideThree)
        {
            var triangleService = new TriangleService(new PolygonService());

            var results = new List<TriangleType>
            {
                triangleService.GetTriangleType(sideOne, sideTwo, sideThree),
                triangleService.GetTriangleType(sideOne, sideThree, sideTwo),
                triangleService.GetTriangleType(sideTwo, sideOne, sideThree),
                triangleService.GetTriangleType(sideTwo, sideThree, sideOne),
                triangleService.GetTriangleType(sideThree, sideOne, sideTwo),
                triangleService.GetTriangleType(sideThree, sideTwo, sideOne)
            };

            Assert.All(results, x => Assert.Equal(TriangleType.Isosceles, x));
        }

        [Theory]
        [InlineData(2, 3, 4)] // smallest scalene with int32 sides
        [InlineData(507, 379, 422)]
        [InlineData(2147483647, 2147483646, 2147483645)] // largest scalene with int32 sides
        [InlineData(2147483647, 2147483646, 2)]
        public void GetTriangleType_NoEqualSides_ReturnsScalene(int sideOne, int sideTwo, int sideThree)
        {
            var triangleService = new TriangleService(new PolygonService());

            var results = new List<TriangleType>
            {
                triangleService.GetTriangleType(sideOne, sideTwo, sideThree),
                triangleService.GetTriangleType(sideOne, sideThree, sideTwo),
                triangleService.GetTriangleType(sideTwo, sideOne, sideThree),
                triangleService.GetTriangleType(sideTwo, sideThree, sideOne),
                triangleService.GetTriangleType(sideThree, sideOne, sideTwo),
                triangleService.GetTriangleType(sideThree, sideTwo, sideOne)
            };

            Assert.All(results, x => Assert.Equal(TriangleType.Scalene, x));
        }
    }
}
