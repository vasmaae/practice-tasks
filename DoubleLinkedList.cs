using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_2
{
    internal class DoubleLinkedList<T>
    {
        private Node<T>? head { get; set; }
        private Node<T>? tail { get; set; }

        private int numElems;

        public DoubleLinkedList()
        {
            head = null;
            tail = null;
            numElems = 0;
        }

        public void AddLast(T value)
        {
            Node<T> node = new Node<T>(value);
            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.next = node;
                node.prev = tail;
            }
            tail = node;
            numElems++;
        }

        public void AddFirst(T value)
        {
            Node<T> node = new Node<T>(value);
            if (numElems == 0)
            {
                head = node;
                tail = head;
            }
            else
            {
                head.prev = node;
                node.next = head;
            }
            head = node;
            numElems++;
        }

        public bool RemoveHead()
        {
            if (numElems == 0)
            {
                return false;
            }
            if (head == tail)
            {
                head = tail = null;
            }
            else
            {
                head = head.next;
                head.prev = null;
            }
            numElems--;
            return true;
        }

        public bool RemoveTail()
        {
            if (numElems == 0)
            {
                return false;
            }
            if (head == tail)
            {
                tail = head = null;
            }
            else
            {
                tail = tail.prev;
                tail.next = null;
            }
            numElems--;
            return true;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            numElems = 0;
        }

        public T? getHead()
        {
            if (head == null) return default;
            return head.data;
        }

        public T? getTail()
        {
            if (tail == null) return default;
            return tail.data;
        }

        public Node<T>? getHeadPointer()
        {
            return head;
        }

        public int getSize()
        {
            return numElems;
        }

        public bool isEmpty()
        {
            return numElems == 0;
        }

        public override string ToString()
        {
            string res = "";
            Node<T>? curr = head;
            while (curr != null)
            {
                res += curr.data.ToString() + " ";
                curr = curr.next;
            }
            return res;
        }
    }

    public class Node<T>
    {
        public Node<T>? next { get; set; }
        public Node<T>? prev { get; set; }
        public T data { get; set; }

        public Node(T data)
        {
            this.data = data;
        }
    }
}
