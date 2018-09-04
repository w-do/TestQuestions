using System.Collections.Generic;
using System.Linq;

namespace LinkedList
{
    public class SinglyLinkedList<T>
    {
        public SinglyLinkedListNode<T> Head { get; set; }

        public SinglyLinkedList() { }

        public SinglyLinkedList(SinglyLinkedListNode<T> head)
        {
            Head = head;
        }

        public SinglyLinkedList(IList<T> values)
        {
            if (!values.Any())
            {
                return;
            }

            Head = new SinglyLinkedListNode<T>(values.First());
            var prev = Head;

            for (var i = 1; i < values.Count(); i++)
            {
                prev.Next = new SinglyLinkedListNode<T>(values[i]);
                prev = prev.Next;
            }
        }

        public SinglyLinkedListNode<T> GetFromEnd(int distanceFromEnd)
        {
            if (distanceFromEnd < 1 || Head == null)
            {
                return null;
            }

            var current = Head;
            var lastXNodes = new Queue<SinglyLinkedListNode<T>>();
            lastXNodes.Enqueue(Head);

            while (current.Next != null)
            {
                current = current.Next;

                lastXNodes.Enqueue(current);

                if (lastXNodes.Count > distanceFromEnd)
                {
                    lastXNodes.Dequeue();
                }
            }

            if (lastXNodes.Count == distanceFromEnd)
            {
                return lastXNodes.Dequeue();
            }

            return null;
        }
    }
}
