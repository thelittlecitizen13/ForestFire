using System.Collections.Generic;

namespace ForestFire
{
    public class Forest
    {
        public Tree[,] TreeMatriza { get; set; }
        public Forest(Tree[,] trees)
        {
            TreeMatriza = trees;
        }
        public void FillForest()
        {
            TreeFactory factory = new TreeFactory();
            for (int x = 0; x < TreeMatriza.GetLength(0); x++)
            {
                for (int y = 0; y < TreeMatriza.GetLength(1); y++)
                {
                    TreeMatriza[x, y] = factory.CreateTree();
                }
            }
            updateNearTrees();
        }
        private List<Tree> getNearTrees(int xCoordinate, int yCoordinate)
        {
            List<Tree> nearTrees = new List<Tree>();
            for (int x = xCoordinate-1; x<=xCoordinate+1; x++)
            {

                for (int y = yCoordinate - 1; y <= yCoordinate + 1; y++)
                {
                    if (x != xCoordinate && y != yCoordinate)
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
            }
            return nearTrees;
        }
        private void updateNearTrees()
        {
            for (int x = 0; x < TreeMatriza.GetLength(0); x++)
            {
                for (int y = 0; y < TreeMatriza.GetLength(1); y++)
                {
                    TreeMatriza[x, y].NearTrees = getNearTrees(x, y);
                }
            }
        }
    }
}
