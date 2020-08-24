using System;
using System.Collections.Generic;

namespace ForestFire
{
    public delegate void BurnNearTrees();
    public class Tree
    {
        public int LifePoints{ get; set; }
        public char Status { get; set; }
        public List<Tree> NearTrees { get; set; }
        public event BurnNearTrees BurnTrees;
        public Tree(int lifePoints)
        {
            LifePoints = lifePoints;
            Status = 'o';
            NearTrees = new List<Tree>();
        }
        public void Burn()
        {
            if (IsBurned())
                return;
            LifePoints--;
            if (LifePoints == 0)
                Status = '.';
            else
            {
                Status = 'X';
                BurnTrees?.Invoke();
            }
        }
        public bool IsBurned()
        {
            return Status == '.';
        }
        public void UpdateNearTrees()
        {
            foreach (var t in NearTrees)
            {
                BurnTrees += t.Burn;
            }
        }
        
    }
}
