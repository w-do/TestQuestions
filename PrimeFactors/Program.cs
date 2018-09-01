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
            //Console.WriteLine("Enter file path:");
            //var path = Console.ReadLine();
            //var fileContents = File.ReadAllText(path);

            var fileContents = File.ReadAllText(@"..\..\..\numbers.txt");
            var primeFactorService = new PrimeFactorService(new PrimeService());

            var primeFactorLists = fileContents.Split('\n')
                .Select(x => primeFactorService.GetPrimeFactors(int.Parse(x)));

            foreach(var list in primeFactorLists)
            {
                Console.WriteLine(string.Join(", ", list));
            }

            Console.ReadLine();
        }
    }
}
