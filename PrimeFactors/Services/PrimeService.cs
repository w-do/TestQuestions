using PrimeFactors.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PrimeFactors.Services
{
    public class PrimeService : IPrimeService
    {
        private int _highestKnownInt;
        private IList<int> _primes;

        public PrimeService()
        {
            _primes = new List<int> { 2 };
            _highestKnownInt = 2;
        }

        public bool IsPrime(int number)
        {
            if (_highestKnownInt < number)
            {
                CalculatePrimesUpTo(number);
            }

            return _primes.Contains(number);
        }

        public IList<int> GetPrimesUpTo(int number)
        {
            if (number > _highestKnownInt)
            {
                CalculatePrimesUpTo(number);
            }

            return _primes.Where(x => x <= number).ToList();
        }

        private void CalculatePrimesUpTo(int number)
        {
            for (var i = _highestKnownInt + 1; i < number; i++)
            {
                _highestKnownInt = i;

                if (!_primes.Any(x => i % x == 0))
                {
                    _primes.Add(i);
                }
            }
        }
    }
}
