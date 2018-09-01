using Xunit;

namespace Triangle.Test
{
    public class GetTriangleTypeTests
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(-1, -1, -1)]
        [InlineData(3, 0, 2)]
        [InlineData(4, 5, -6)]
        [InlineData(1, 0, -1)]
        public void GetTriangleType_ZeroOrNegativeSides_ReturnsInvalidTriangle(int sideOne, int sideTwo, int sideThree)
        {
            var triangleService = new TriangleService(new PolygonService());

            var result = triangleService.GetTriangleType(sideOne, sideTwo, sideThree);

            Assert.Equal("Not a valid triangle", result);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(10, 3, 4)]
        [InlineData(1, 6, 2)]
        public void GetTriangleType_LargestSideExceedsSumOfOthers_ReturnsInvalidTriangle(int sideOne, int sideTwo, int sideThree)
        {
            var triangleService = new TriangleService(new PolygonService());

            var result = triangleService.GetTriangleType(sideOne, sideTwo, sideThree);

            Assert.Equal("Not a valid triangle", result);
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(5, 5, 5)]
        [InlineData(600, 600, 600)]
        public void GetTriangleType_ThreePositiveSides_ReturnsEquilateral(int sideOne, int sideTwo, int sideThree)
        {
            var triangleService = new TriangleService(new PolygonService());

            var result = triangleService.GetTriangleType(sideOne, sideTwo, sideThree);

            Assert.Equal("Equilateral", result);
        }

        [Theory]
        [InlineData(2, 2, 1)]
        [InlineData(10, 3, 10)]
        [InlineData(20, 11, 11)]
        public void GetTriangleType_ExactlyTwoEqualSides_ReturnsIsosceles(int sideOne, int sideTwo, int sideThree)
        {
            var triangleService = new TriangleService(new PolygonService());

            var result = triangleService.GetTriangleType(sideOne, sideTwo, sideThree);

            Assert.Equal("Isosceles", result);
        }

        [Theory]
        [InlineData(2, 3, 4)]
        [InlineData(100, 55, 150)]
        [InlineData(30, 15, 25)]
        public void GetTriangleType_NoEqualSides_ReturnsScalene(int sideOne, int sideTwo, int sideThree)
        {
            var triangleService = new TriangleService(new PolygonService());

            var result = triangleService.GetTriangleType(sideOne, sideTwo, sideThree);

            Assert.Equal("Scalene", result);
        }

        [Theory]
        [InlineData(2147483647, 2147483647, 2147483647)]
        public void GetTriangleType_LargeEquilateral_ReturnsEquilateral(int sideOne, int sideTwo, int sideThree)
        {
            var triangleService = new TriangleService(new PolygonService());

            var result = triangleService.GetTriangleType(sideOne, sideTwo, sideThree);

            Assert.Equal("Equilateral", result);
        }
    }
}
