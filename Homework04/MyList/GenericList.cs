using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }
    class GenericList<T>
    {

        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }
        public GenericList()
        {
            Tail = Head = null;
        }
        public GenericList(T[] tList)
        {
            Tail = Head = null;
            foreach(T val in tList)
            {
                Add(val);
            }
        }

        public void Add(T t)
        {
            Node<T> newNode = new Node<T>(t);
            if (Tail == null)
            {
                Head = Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }
        }

        public void Foreach(Action<T> action)
        {
            if (action == null)
            {
                throw new ArgumentException("代理为空");
            }
            Node<T> nowNode = Head;
            while( nowNode != null )
            {
                action(nowNode.Data);
                nowNode = nowNode.Next;
               
            }

        }
    }
}
