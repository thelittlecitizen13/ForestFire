using System;
using System.Collections.Generic;

namespace ForestFire
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class Forest
    {
        public Tree[,] TreeMatriza { get; set; }
        public Forest(Tree[,] trees)
        {
            TreeMatriza = trees;
        }
        public void FillForest()
        {

        }
        public List<Tree> GetNearTrees(int xCoordinate, int yCoordinate)
        {
            List<Tree> nearTrees = new List<Tree>();
            for (int x = xCoordinate-1; x<=xCoordinate+1; x++)
            {
                for (int y = yCoordinate - 1; y <= yCoordinate + 1; y++)
                {
                    try
                    {
                        Tree t1 = TreeMatriza[x, y];
                        if (t1 != null)
                            nearTrees.Add(t1);
                    }
                    catch
                    {

                    }
                }
            }
            return nearTrees;
        }
    }
}
