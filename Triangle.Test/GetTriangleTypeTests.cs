using System.Collections.Generic;
using Xunit;

namespace Triangle.Test
{
    public class GetTriangleTypeTests
    {
        [Theory]
        [InlineData(0, 0, 0)] // all zeroes
        [InlineData(-1, -1, -1)] // all negatives
        [InlineData(-2147483647, -2147483647, -2147483647)]
        [InlineData(3, 0, 2)] // one zero
        [InlineData(4, 5, -6)] // one negative
        [InlineData(1, 0, -1)] // one of each
        [InlineData(1, 2, 3)] // largest side equals smaller sides
        [InlineData(3, 3, 10)] // largest side exceeds smaller sides
        public void GetTriangleType_ImpossibleSides_ReturnsInvalidTriangle(int sideOne, int sideTwo, int sideThree)
        {
            var triangleService = new TriangleService(new PolygonService());

            var results = new List<string>
            {
                triangleService.GetTriangleType(sideOne, sideTwo, sideThree),
                triangleService.GetTriangleType(sideOne, sideThree, sideTwo),
                triangleService.GetTriangleType(sideTwo, sideOne, sideThree),
                triangleService.GetTriangleType(sideTwo, sideThree, sideOne),
                triangleService.GetTriangleType(sideThree, sideOne, sideTwo),
                triangleService.GetTriangleType(sideThree, sideTwo, sideOne)
            };

            foreach (var result in results)
            {
                Assert.Equal("Not a valid triangle", result);
            }
        }

        [Theory]
        [InlineData(1, 1, 1)] // smallest valid equilateral
        [InlineData(600, 600, 600)]
        [InlineData(2147483647, 2147483647, 2147483647)] // max int
        public void GetTriangleType_ThreeEqualSides_ReturnsEquilateral(int sideOne, int sideTwo, int sideThree)
        {
            var triangleService = new TriangleService(new PolygonService());

            var results = new List<string>
            {
                triangleService.GetTriangleType(sideOne, sideTwo, sideThree),
                triangleService.GetTriangleType(sideOne, sideThree, sideTwo),
                triangleService.GetTriangleType(sideTwo, sideOne, sideThree),
                triangleService.GetTriangleType(sideTwo, sideThree, sideOne),
                triangleService.GetTriangleType(sideThree, sideOne, sideTwo),
                triangleService.GetTriangleType(sideThree, sideTwo, sideOne)
            };

            foreach (var result in results)
            {
                Assert.Equal("Equilateral", result);
            }
        }

        [Theory]
        [InlineData(2, 2, 1)] // unique side is smallest
        [InlineData(3, 2, 2)] // unique side is largest
        [InlineData(2147483647, 2147483647, 2147483646)] // largest isoceles with valid ints
        [InlineData(2147483647, 2147483647, 1)] // min and max sides
        public void GetTriangleType_ExactlyTwoEqualSides_ReturnsIsosceles(int sideOne, int sideTwo, int sideThree)
        {
            var triangleService = new TriangleService(new PolygonService());

            var results = new List<string>
            {
                triangleService.GetTriangleType(sideOne, sideTwo, sideThree),
                triangleService.GetTriangleType(sideOne, sideThree, sideTwo),
                triangleService.GetTriangleType(sideTwo, sideOne, sideThree),
                triangleService.GetTriangleType(sideTwo, sideThree, sideOne),
                triangleService.GetTriangleType(sideThree, sideOne, sideTwo),
                triangleService.GetTriangleType(sideThree, sideTwo, sideOne)
            };

            foreach (var result in results)
            {
                Assert.Equal("Isosceles", result);
            }
        }

        [Theory]
        [InlineData(2, 3, 4)] // smallest valid scalene
        [InlineData(507, 379, 422)]
        [InlineData(2147483647, 2147483646, 2147483645)] // largest valid scalene
        [InlineData(2147483647, 2147483646, 2)]
        public void GetTriangleType_NoEqualSides_ReturnsScalene(int sideOne, int sideTwo, int sideThree)
        {
            var triangleService = new TriangleService(new PolygonService());

            var results = new List<string>
            {
                triangleService.GetTriangleType(sideOne, sideTwo, sideThree),
                triangleService.GetTriangleType(sideOne, sideThree, sideTwo),
                triangleService.GetTriangleType(sideTwo, sideOne, sideThree),
                triangleService.GetTriangleType(sideTwo, sideThree, sideOne),
                triangleService.GetTriangleType(sideThree, sideOne, sideTwo),
                triangleService.GetTriangleType(sideThree, sideTwo, sideOne)
            };

            foreach (var result in results)
            {
                Assert.Equal("Scalene", result);
            }
        }
    }
}
