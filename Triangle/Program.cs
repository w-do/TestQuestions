using System;
using Triangle.Services;

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

                var triangleService = new TriangleService(new PolygonService());

                Console.WriteLine(triangleService.GetTriangleType(sideOne, sideTwo, sideThree));
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }

            Console.ReadLine();
        }
    }
}
