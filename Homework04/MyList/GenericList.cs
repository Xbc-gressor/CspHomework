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
        private Node<T> head;
        private Node<T> tail;
        public Node<T> Head
        {
            get => head;
        }
        public GenericList()
        {
            tail = head = null;
        }
        public GenericList(T[] tList)
        {
            tail = head = null;
            foreach(T val in tList)
            {
                Add(val);
            }
        }

        public void Add(T t)
        {
            Node<T> newNode = new Node<T>(t);
            if (tail == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
        }

        public void Foreach(Action<T> action)
        {
            
            Node<T> nowNode = head;
            while( nowNode != null )
            {
                action(nowNode.Data);
                nowNode = nowNode.Next;
               
            }

        }
    }
}
