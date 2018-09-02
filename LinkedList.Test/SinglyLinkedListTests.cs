using System.Collections.Generic;
using Xunit;

namespace LinkedList.Test
{
    public class SinglyLinkedListTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-357786)]
        [InlineData(-2147483648)]
        public void GetFromEnd_NonPositiveDistanceFromEnd_ReturnsNull(int distanceFromEnd)
        {
            var intValues = new List<int>();
            var stringValues = new List<string>();

            for (var i = 0; i < 100; i++)
            {
                intValues.Add(i);
                stringValues.Add(i.ToString());
            }

            var intLinkedList = new SinglyLinkedList<int>(intValues);
            var stringLinkedList = new SinglyLinkedList<string>(stringValues);


            var intNode = intLinkedList.GetFromEnd(distanceFromEnd);
            var stringNode = stringLinkedList.GetFromEnd(distanceFromEnd);


            Assert.Null(intNode);
            Assert.Null(stringNode);
        }

        [Theory]
        [InlineData(-2147483648)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2147483647)]
        public void GetFromEnd_EmptyLinkedList_ReturnsNull(int distanceFromEnd)
        {
            var intLinkedList = new SinglyLinkedList<int>();
            var stringLinkedList = new SinglyLinkedList<string>();

            var intNode = intLinkedList.GetFromEnd(distanceFromEnd);
            var stringNode = stringLinkedList.GetFromEnd(distanceFromEnd);

            Assert.Null(intNode);
            Assert.Null(stringNode);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(999)]
        [InlineData(1000)]
        public void GetFromEnd_DistanceFromEndLessThanLengthOfList_ReturnsCorrectNode(int distanceFromEnd)
        {
            var intValues = new List<int>();
            var stringValues = new List<string>();

            for (var i = 0; i < 1000; i++)
            {
                intValues.Add(i);
                stringValues.Add(i.ToString());
            }

            var intLinkedList = new SinglyLinkedList<int>(intValues);
            var stringLinkedList = new SinglyLinkedList<string>(stringValues);


            var intNode = intLinkedList.GetFromEnd(distanceFromEnd);
            var stringNode = stringLinkedList.GetFromEnd(distanceFromEnd);


            Assert.Equal(intValues[1000 - distanceFromEnd], intNode.Value);
            Assert.Equal(stringValues[1000 - distanceFromEnd], stringNode.Value);
        }
    }
}
