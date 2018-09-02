using PrimeFactors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeFactors.Services
{
    public class PrimeFactorService : IPrimeFactorService
    {
        private readonly IPrimeService _primeService;

        public PrimeFactorService(IPrimeService primeService)
        {
            _primeService = primeService;
        }

        public IEnumerable<int> GetPrimeFactors(int number)
        {
            if (number < 2)
            {
                return new List<int>();
            }

            var squareRoot = (int)Math.Sqrt(number);
            var primes = _primeService.GetPrimesUpTo(squareRoot);

            return PrimeFactorize(number, primes);
        }

        private IEnumerable<int> PrimeFactorize(int number, IList<int> primes)
        {
            // base case
            // if list of primes is exhausted, our remaining number is either 1 or a prime
            if (!primes.Any())
            {
                return number == 1
                    ? new List<int>()
                    : new List<int> { number };
            }

            var prime = primes.First();

            if (number % prime == 0)
            {
                // prime factor found
                var factors = new List<int> { prime };
                factors.AddRange(PrimeFactorize(number / prime, primes));
                return factors;
            }

            // not a prime factor, so remove and try the next
            primes.Remove(prime);

            return PrimeFactorize(number, primes);
        }
    }
}
