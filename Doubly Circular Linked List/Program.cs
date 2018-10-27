using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubly_Circular_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyCircularLinkedList<int> list = new DoublyCircularLinkedList<int>();

            for (int i = 0; i < 10; i++)
            {                
                list.AddLast(i + 1);
            }

            foreach (var item in list)
            {

            }
        }
    }
}
