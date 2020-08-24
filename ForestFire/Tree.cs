using System.Collections.Generic;

namespace ForestFire
{
    public class Tree
    {
        public int LifePoints{ get; set; }
        public char Status { get; set; }
        public List<Tree> NearTrees { get; set; }
        public Tree(int lifePoints)
        {
            LifePoints = lifePoints;
            Status = 'o';
            NearTrees = new List<Tree>();
        }
        public void Burn()
        {
            LifePoints--;
            if (LifePoints == 0)
                Status = '.';
            else
                Status = 'X';
        }
        public bool IsBurned()
        {
            return Status == '.';
        }
        
    }
}
