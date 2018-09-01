using System.Collections.Generic;

namespace PrimeFactors.Interfaces
{
    public interface IPrimeService
    {
        bool IsPrime(int number);
        IList<int> GetPrimesUpTo(int number);
    }
}
