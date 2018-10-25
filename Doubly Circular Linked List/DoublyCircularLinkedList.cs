using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubly_Circular_Linked_List
{
    public class DoublyCircularLinkedList<T>
    {
        public class Node
        {
            public T Value;
            public Node Next;
            public Node Prev;
            public DoublyCircularLinkedList<T> List;

            public Node(T value, DoublyCircularLinkedList<T> list = null, Node next = null, Node prev = null)
            {
                Value = value;
                Next = next;
                Prev = prev;
                List = list;
            }

        }

        Node Head;
        Node Tail
        {
            get
            {
                return Head.Prev;
            }
        }
        public int Count = 0;

        //Prev & next on ANY node should NEVER be null

        //AddFirst
        //AddLast
        //AddBefore
        //AddAfter
        //Remove
        //RemoveFirst
        //RemoveLast
        //bool Contains
        //Node Find
        //Node FindLast
        //Clear

        public void AddFirst(T value)
        {
            //if (Head == null)
            //{
            //    Head = new Node(value, this, Head, Head);
            //}
            //else
            //{
            //    Node temp = new Node(value, this, Head, Tail);
            //    Tail.Next = temp;
            //    Head.Prev = temp; //tail would have changed if this runs first
            //    Head = temp;
            //}
            //Count++;
            AddLast(value);
            Head = Tail;
        }

        public void AddLast(T value)
        {
            if (Head == null)
            {
                Head = new Node(value, this, Head, Head);
            }
            else
            {
                Node temp = new Node(value, this, Head, Tail);
                Tail.Next = temp;
                Head.Prev = temp;
            }
            Count++;
        }

        public void AddBefore(T value, Node nodeBefore)
        {
            if (nodeBefore.List != this)
            {
                throw new ArgumentException("nodeBefore does not belong to this list");
            }

            Node temp = new Node(value, this, nodeBefore, nodeBefore.Prev);

            nodeBefore.Prev.Next = temp;
            nodeBefore.Prev = temp;

            if (nodeBefore == Head)
            {
                Head = temp;
            }
            Count++;
        }

        public void AddBefore(T value, T nodeItem)
        {
            Node nodeBefore = Find(nodeItem);
            AddBefore(value, nodeBefore);
        }

        public void AddAfter(T value, Node nodeAfter)
        {
            if (nodeAfter.List != this)
            {
                throw new ArgumentException("nodeAfter does not belong to this list");
            }

            Node temp = new Node(value, this, nodeAfter.Next, nodeAfter);

            nodeAfter.Next.Prev = temp;
            nodeAfter.Next = temp;

            Count++;
        }

        public void AddAfter(T value, T nodeItem)
        {
            Node nodeAfter = Find(nodeItem);
            AddAfter(value, nodeAfter);
        }

        public bool RemoveFirst()
        {
            if (Head == null)
            {
                return false;
            }
            else
            {
                Tail.Next = Head.Next;
                Head.Next.Prev = Tail;
                Head = Head.Next;
                Count--;
                return true;
            }
        }

        public bool RemoveLast()
        {
            if (Head == null)
            {
                return false;
            }
            else
            {
                Tail.Prev = Head;
                Head.Prev = Tail.Prev;
                Count--;
                return true;
            }
        }

        public void Clear()
        {
            Head = null;
            Count = 0;
        }

        public bool Contains(T value) // You really just pass in Node.value
        {
            return Find(value) != null;
        }

        public Node Find(T item)
        {
            if (Head == null)
            {
                return null;
            }
            Node temp = Head;
            while (!temp.Value.Equals(item))
            {
                temp = temp.Next;
                if (temp == Head)
                {
                    return null;
                }
            }
            return temp;
        }

        public Node FindLast(T item)
        {
            if (Head == null)
            {
                return null;
            }
            Node temp = Head;
            while (!temp.Value.Equals(item))
            {
                temp = temp.Prev;
                if (temp == Head)
                {
                    return null;
                }
            }
            return temp;
        }
    }
}
