using System;
using System.Net.Http.Headers;

namespace ForestFire
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree[,] trees = new Tree[20, 20];
            Forest forest = new Forest(trees);
            forest.PrintForest();
            forest.Run(50, 10, 10);
        }
    }
}
