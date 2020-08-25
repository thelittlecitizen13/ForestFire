using System;
using System.Collections.Generic;
using System.Threading;

namespace ForestFire
{
    public delegate void BurnTree(Forest forest);
    public delegate void ChangeTreeStatus();
    public class Forest
    {
        public Tree[,] TreeMatriza { get; set; }
        private event ChangeTreeStatus _doneBurning;
        public event BurnTree BurnTrees;
        public Forest(Tree[,] trees)
        {
            TreeMatriza = trees;
            FillForest();
        }
        public void Run(int times, int xCoordinate, int yCoordinate)
        {
            TreeMatriza[xCoordinate, yCoordinate].Burn(this);
            PrintForest();
            for (int i = 0; i < times; i++)
            {
                BurnTrees?.Invoke(this);
                PrintForest();
                _doneBurning?.Invoke();
                Thread.Sleep(2500);
            }
        }
        public void FillForest()
        {
            TreeFactory factory = new TreeFactory();
            for (int x = 0; x < TreeMatriza.GetLength(0); x++)
            {
                for (int y = 0; y < TreeMatriza.GetLength(1); y++)
                {
                    TreeMatriza[x, y] = factory.CreateTree();
                    _doneBurning += TreeMatriza[x, y].DoneBurningRound;
                }
            }
            updateNearTrees();
        }
        private List<Tree> getNearTrees(int xCoordinate, int yCoordinate)
        {
            List<Tree> nearTrees = new List<Tree>();
            for (int x = xCoordinate-1; x<=xCoordinate+1; x++)
            {
                Random rand = new Random();
                for (int y = yCoordinate - 1; y <= yCoordinate + 1; y++)
                {
                    try
                    {
                        Tree t1 = TreeMatriza[x, y];
                        int chance = rand.Next(0, 100);
                        if (t1 != null && chance <= 70)
                            nearTrees.Add(t1);
                    }
                    catch
                    {

                    }
                }
            }
            return nearTrees;
        }
        private void updateNearTrees()
        {
            for (int x = 0; x < TreeMatriza.GetLength(0); x++)
            {
                for (int y = 0; y < TreeMatriza.GetLength(1); y++)
                {
                    TreeMatriza[x, y].UpdateNearTrees(getNearTrees(x, y), this);
                }
            }
        }
        public void PrintForest()
        {
            for (int x = 0; x < TreeMatriza.GetLength(0); x++)
            {
                for (int y = 0; y < TreeMatriza.GetLength(1); y++)
                {
                    System.Console.Write(TreeMatriza[x,y].Status + " ");
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine();
        }
    }
}
