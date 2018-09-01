using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class SinglyLinkedList<T>
    {
        public LinkedListItem<T> Head { get; set; }

        public SinglyLinkedList(LinkedListItem<T> head)
        {
            Head = head;
        }

        public SinglyLinkedList(IList<T> values)
        {
            if (!values.Any())
            {
                return;
            }

            Head = new LinkedListItem<T>(values.First());
            var prev = Head;

            for (var i = 1; i < values.Count(); i++)
            {
                prev.Next = new LinkedListItem<T>(values[i]);
            }
        }

        public void AddItem(LinkedListItem<T> item)
        {
            if (Head == null)
            {
                Head = item;
            }

            var last = Head;

            while (last.Next != null)
            {
                last = last.Next;
            }

            last.Next = item;
        }

        public LinkedList<T> GetFromEnd(int distanceFromEnd)
        {
            throw new NotImplementedException();
        }
    }
}
