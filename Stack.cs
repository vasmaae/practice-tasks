using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_2
{
    public class Stack
    {
        private DoubleLinkedList<int?> list;
        int numElems;

        public Stack()
        {
            list = new DoubleLinkedList<int?>();
            numElems = 0;
        }

        public void push(int elem)
        {
            list.AddFirst(elem);
            numElems++;
        }

        public int? pop()
        {
            int? elem = list.getHead();
            if (elem == null) return null;
            list.RemoveHead();
            numElems--;
            return elem;
        }

        public override string ToString()
        {
            string res = "";
            Node<int?>? curr = list.getHeadPointer();
            while (curr != null)
            {
                res += curr.data.ToString() + " ";
                curr = curr.next;
            }
            return res;
        }
    }
}
