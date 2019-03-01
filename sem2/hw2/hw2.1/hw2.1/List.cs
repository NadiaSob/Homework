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

        Node GetNode(int position)
        {
            Node current = head;
            for (var i = 1; i < position; ++i)
            {
                current = current.Next;
            }
            return current;
        }

        public void AddElement(int position, int data)
        {
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
        }

        public void DeleteElement(int position)
        {
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
        }

        public int GetData(int position)
        {
            Node node = GetNode(position);
            return node.Data;
        }

        public void SetData(int position, int data)
        {
            Node node = GetNode(position);
            node.Data = data;
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
