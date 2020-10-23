using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    class BstBuilder<T> where T : IComparable
    {
        public BinaryNode<T> rootNode;
        public BinaryNode<T> parentNode;
        public int NumberOfElements { get; private set; } = 0;

        public BstBuilder()
        {
            rootNode = null;
            parentNode = null;
        }

        public void AddData(T data)
        {
            if (rootNode == null)
            {
                rootNode = new BinaryNode<T>(data);
                NumberOfElements++;
            }
            else
            {
                BinaryNode<T> node = new BinaryNode<T>(data);
                BinaryNode<T> temp = parentNode;
                if (data.CompareTo(rootNode.data) < 0)
                {
                    if (temp.lChild == null)
                    {
                        temp.lChild = node;
                        NumberOfElements++;
                    }
                    else
                    {
                        parentNode = temp.lChild;
                        AddData(data);
                    }
                }
                else
                {
                    if (temp.rChild == null)
                    {
                        temp.rChild = node;
                        NumberOfElements++;
                    }  
                    else
                    {
                        parentNode = temp.rChild;
                        AddData(data);
                    }
                }
            }
            parentNode = rootNode;
        }

        public void Display(BinaryNode<T> parent)
        {
            Console.WriteLine($"Parent : {parent.data}");

            if (parent.lChild != null)
                Console.WriteLine($"Left : {parent.lChild.data}");
            
            if (parent.rChild != null)
                Console.WriteLine($"Right : {parent.rChild.data}");

            if (parent.lChild != null)
                Display(parent.lChild);

            if (parent.rChild != null)
                Display(parent.rChild);

        }

        public int CheckDeepth()
        {
            BinaryNode<T> temp = rootNode;
            int maxSize = 0;
            Stack<BinaryNode<T>> stack = new Stack<BinaryNode<T>>();

            while (temp != null || stack.Count != 0)
            {
                int size = 0;
                while (temp != null)
                {
                    stack.Push(temp);
                    temp = temp.lChild;
                    size++;
                }
                temp = stack.Pop();

                temp = temp.rChild;
                maxSize = maxSize < size ? size : maxSize;
            }
            return maxSize - 1;
        }
    }
}
