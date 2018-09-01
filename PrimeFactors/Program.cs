using PrimeFactors.Services;
using System;
using System.IO;
using System.Linq;

namespace PrimeFactors
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileContents = File.ReadAllText(@"..\..\..\numbers.txt");

            var numbers = fileContents.Split('\n')
                .Select(x => int.Parse(x))
                .ToList();

            var primeFactorService = new PrimeFactorService(new PrimeService());

            foreach (var number in numbers)
            {
                var primeFactors = primeFactorService.GetPrimeFactors(number);
                Console.WriteLine(string.Join(",", primeFactors));
            }

            Console.ReadLine();
        }
    }
}
