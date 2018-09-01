using PrimeFactors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeFactors.Services
{
    public class PrimeFactorService
    {
        private readonly IPrimeService _primeService;

        public PrimeFactorService(IPrimeService primeService)
        {
            _primeService = primeService;
        }

        public IList<int> GetPrimeFactors(int number)
        {
            if (number < 2)
            {
                throw new ArgumentException();
            }

            var squareRoot = (int)Math.Sqrt(number);
            var primes = _primeService.GetPrimesUpTo(squareRoot);

            return PrimeFactorize(number, primes);
        }

        private List<int> PrimeFactorize(int number, IList<int> primes)
        {
            if (!primes.Any())
            {
                return number == 1
                    ? new List<int>()
                    : new List<int> { number };
            }

            var prime = primes.First();

            if (number % primes.First() == 0)
            {
                var factors = new List<int> { prime };
                factors.AddRange(PrimeFactorize(number / prime, primes));
                return factors;
            }

            primes.Remove(prime);

            return PrimeFactorize(number, primes);
        }
    }
}
