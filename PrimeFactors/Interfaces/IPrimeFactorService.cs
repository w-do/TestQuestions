using System.Collections.Generic;

namespace PrimeFactors.Interfaces
{
    interface IPrimeFactorService
    {
        IEnumerable<int> GetPrimeFactors(int number);
    }
}
