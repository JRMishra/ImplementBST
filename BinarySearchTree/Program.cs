﻿using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Binary Search Tree");

            BstBuilder<int> bst = new BstBuilder<int>();
            bst.AddData(10);
            bst.AddData(12);
            bst.AddData(4);
            bst.AddData(7);
            bst.AddData(5);
            bst.AddData(20);
            bst.AddData(22);

            bst.Display(bst.rootNode);
            Console.WriteLine($"\nDeepth of Bst : {bst.CheckDeepth()}");
            Console.WriteLine($"Total number of elements {bst.NumberOfElements}");

            bst.SearchValue(4);
            bst.SearchValue(11);
        }
    }
}
