namespace LinkedList
{
    public class LinkedListItem<T>
    {
        public T Value { get; set; }
        public LinkedListItem<T> Next { get; set; }

        public LinkedListItem(T value)
        {
            Value = value;
        }
    }
}
