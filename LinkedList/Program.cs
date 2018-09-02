using System;
using System.Collections.Generic;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var intValues = new List<int>();
            var stringValues = new List<string>();
            var startDate = DateTime.Parse("1900-01-01");

            for (var i = 1; i <= 100; i++)
            {
                intValues.Add(i);
                stringValues.Add(startDate.AddYears(i).ToShortDateString());
            }

            var intLinkedList = new SinglyLinkedList<int>(intValues);
            var stringLinkedList = new SinglyLinkedList<string>(stringValues);

            var fifthIntNodeFromEnd = intLinkedList.GetFromEnd(5);
            var fifthStringNodeFromEnd = stringLinkedList.GetFromEnd(5);

            Console.WriteLine(fifthIntNodeFromEnd.Value);
            Console.WriteLine(fifthStringNodeFromEnd.Value);

            Console.ReadLine();
        }
    }
}
