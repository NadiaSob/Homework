using System;

namespace hw2._1
{
    public class List
    {
        private class Node
        {
            public int data { get; set; }
            public Node next { get; set; }

            public Node(int data, Node next)
            {
                this.data = data;
                this.next = next;
            }
        }

        private Node head;
        public int size { get; private set; }

        public List()
        {
        }

        public bool IsEmpty() => head == null;

        Node GetNode(int position)
        {
            Node current = head;
            for (var i = 1; i < position; ++i)
            {
                current = current.next;
            }
            return current;
        }

        public void AddElement(int position, int data)
        {
            var newNode = new Node(data, null);

            if (position == 1)
            {
                newNode.next = head;
                head = newNode;
            }
            else
            {
                var current = GetNode(position - 1);
                newNode.next = current.next;
                current.next = newNode;
            }
            ++size;
        }

        public void DeleteElement(int position)
        {
            if (position == 1)
            {
                head = head.next;
            }
            else
            {
                Node current = GetNode(position - 1);
                current.next = current.next.next;
            }
            --size;
        }

        public int GetData(int position)
        {
            Node node = GetNode(position);
            return node.data;
        }

        public void SetData(int position, int data)
        {
            Node node = GetNode(position);
            node.data = data;
        }

        public void PrintList()
        {
            Node current = head;
            while(current != null)
            {
                Console.Write($"{current.data} ");
                current = current.next;
            }
            Console.WriteLine();
        }
    }
}
