﻿using PrimeFactors.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PrimeFactors.Services
{
    public class PrimeService : IPrimeService
    {
        private IList<int> _knownPrimes;
        private int _highestKnownInt;

        public PrimeService()
        {
            _knownPrimes = new List<int> { 2 };
            _highestKnownInt = 2;
        }

        public bool IsPrime(int number)
        {
            if (_highestKnownInt < number)
            {
                CheckForPrimesUpTo(number);
            }

            return _knownPrimes.Contains(number);
        }

        public IList<int> GetPrimesUpTo(int number)
        {
            if (number > _highestKnownInt)
            {
                CheckForPrimesUpTo(number);
            }

            return _knownPrimes.Where(x => x <= number).ToList();
        }

        private void CheckForPrimesUpTo(int number)
        {
            for (var i = _highestKnownInt + 1; i <= number; i++)
            {
                _highestKnownInt = i;

                if (!_knownPrimes.Any(x => i % x == 0))
                {
                    _knownPrimes.Add(i);
                }
            }
        }
    }
}
