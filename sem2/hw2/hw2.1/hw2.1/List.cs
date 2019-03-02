using System;

namespace hw2._1
{
    public class List
    {
        private class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }

            public Node(int data, Node next)
            {
                Data = data;
                Next = next;
            }
        }

        private Node head;
        public int Size { get; private set; }

        public List()
        {
        }

        public bool IsEmpty() => head == null;

        private bool IsCorrectPositionToAdd(int position) => position > 0 && position <= Size + 1;

        private bool IsCorrectPosition(int position) => position > 0 && position <= Size;

        private Node GetNode(int position)
        {
            Node current = head;
            for (var i = 1; i < position; ++i)
            {
                current = current.Next;
            }
            return current;
        }

        public bool AddElement(int position, int data)
        {
            if (!IsCorrectPositionToAdd(position))
            {
                return false;
            }

            var newNode = new Node(data, null);

            if (position == 1)
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                var current = GetNode(position - 1);
                newNode.Next = current.Next;
                current.Next = newNode;
            }
            ++Size;
            return true;
        }

        public bool DeleteElement(int position)
        {
            if (!IsCorrectPosition(position))
            {
                return false;
            }

            if (position == 1)
            {
                head = head.Next;
            }
            else
            {
                Node current = GetNode(position - 1);
                current.Next = current.Next.Next;
            }
            --Size;
            return true;
        }

        public int GetData(int position)
        {
            if (!IsCorrectPosition(position))
            {
                return ' ';
            }
            Node node = GetNode(position);
            return node.Data;
        }

        public bool SetData(int position, int data)
        {
            if (!IsCorrectPosition(position))
            {
                return false;
            }

            Node node = GetNode(position);
            node.Data = data;
            return true;
        }

        public void PrintList()
        {
            Node current = head;
            while(current != null)
            {
                Console.Write($"{current.Data} ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
}
