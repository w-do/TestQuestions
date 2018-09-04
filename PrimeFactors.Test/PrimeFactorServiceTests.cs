using PrimeFactors.Services;
using System.Linq;
using Xunit;

namespace PrimeFactors.Test
{
    public class PrimeFactorServiceTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2147483648)]
        public void GetPrimeFactors_InvalidNumber_ReturnsEmptyList(int number)
        {
            var primeFactorService = new PrimeFactorService(new PrimeService());

            var result = primeFactorService.GetPrimeFactors(number);

            Assert.Empty(result);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(32749)]
        [InlineData(2147483647)]
        public void GetPrimeFactors_PrimeNumber_ReturnsListContainingOnlyInput(int number)
        {
            var primeFactorService = new PrimeFactorService(new PrimeService());

            var result = primeFactorService.GetPrimeFactors(number);

            Assert.Equal(number, result.ToList().Single());
        }

        [Theory]
        [InlineData(4)]
        [InlineData(64)]
        [InlineData(65498)]
        [InlineData(2147117569)]
        [InlineData(2147483646)]
        public void GetPrimeFactors_CompositeNumber_ReturnsCorrectPrimeFactors(int number)
        {
            var primeService = new PrimeService();
            var primeFactorService = new PrimeFactorService(primeService);

            var result = primeFactorService.GetPrimeFactors(number);

            Assert.Equal(number, result.Aggregate(1, (x, y) => x * y));
            Assert.All(result, x => primeService.IsPrime(x));
        }
    }
}
