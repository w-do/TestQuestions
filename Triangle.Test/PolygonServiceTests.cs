using System.Collections.Generic;
using Triangle.Services;
using Xunit;

namespace Triangle.Test
{
    public class PolygonServiceTests
    {
        [Theory]
        [InlineData(new int[] { })]
        [InlineData(new int[] { 1 })]
        [InlineData(new int[] { 1, 1 })]
        public void IsPolygon_LessThanThreeSides_ReturnsFalse(IList<int> sides)
        {
            var polygonService = new PolygonService();

            var result = polygonService.IsPolygon(sides);

            Assert.False(result);
        }

        [Theory]
        [InlineData(new int[] { 1, 0, 1 })]
        [InlineData(new int[] { 1, -1, 1 })]
        [InlineData(new int[] { 1, 0, -1 })]
        [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, -1, 1 })]
        public void IsPolygon_OneOrMoreNonPositiveSides_ReturnsFalse(IList<int> sides)
        {
            var polygonService = new PolygonService();

            var result = polygonService.IsPolygon(sides);

            Assert.False(result);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 1 })]
        [InlineData(new int[] { 1, 3, 1, 1 })]
        [InlineData(new int[] { 2147483647, 4, 88, 3, 7, 7, 2, 8, 83, 7, 42, 1, 5, 6, 79 })]
        public void IsPolygon_PositiveButInvalidSides_ReturnsFalse(IList<int> sides)
        {
            var polygonService = new PolygonService();

            var result = polygonService.IsPolygon(sides);

            Assert.False(result);
        }

        [Theory]
        [InlineData(new int[] { 1, 1, 1 })]
        [InlineData(new int[] { 1, 1, 1, 1 })]
        [InlineData(new int[] { 100, 100, 100, 100, 100, 100 })]
        [InlineData(new int[] { 2147483647, 2147483647, 2147483647, 2147483647, 2147483647, 2147483647 })]
        [InlineData(new int[] { 8, 45, 90, 36, 38, 95, 41, 18, 87 })]
        public void IsPolygon_ValidSides_ReturnsTrue(IList<int> sides)
        {
            var polygonService = new PolygonService();

            var result = polygonService.IsPolygon(sides);

            Assert.True(result);
        }
    }
}
