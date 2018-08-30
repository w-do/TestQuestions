using System;

namespace Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter three integers:");

            try
            {
                var sideOne = int.Parse(Console.ReadLine());
                var sideTwo = int.Parse(Console.ReadLine());
                var sideThree = int.Parse(Console.ReadLine());

                Console.WriteLine(TriangleChecker.GetTriangleType(sideOne, sideTwo, sideThree));
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }

            Console.ReadLine();
        }
    }
}
