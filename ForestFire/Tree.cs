using System;
using System.Collections.Generic;

namespace ForestFire
{
    public delegate void BurnNearTrees();
    public class Tree
    {
        public int LifePoints{ get; set; }
        public char Status { get; set; }
        private bool _currentlyBurning { get; set; }
        private bool _burnedThisRound { get; set; }
        public List<Tree> NearTrees { get; set; }
        public event BurnTree BurnTrees;
        public Tree(int lifePoints)
        {
            LifePoints = lifePoints;
            Status = 'o';
            NearTrees = new List<Tree>();
            _burnedThisRound = false;
            _currentlyBurning = false;
        }
        public void Burn(Forest forest)
        {
            if (IsBurned() || _burnedThisRound)
                return;
            LifePoints--;
            _currentlyBurning = true;
            _burnedThisRound = true;
            if (Status == 'o')
            {
                forest.BurnTrees += this.Burn;
                Status = 'X';
                return;
            }
            if (LifePoints == 0)
            { 
                Status = '.';
                return;
            }
            BurnTrees?.Invoke(forest);

        }
        public bool IsBurned()
        {
            return Status == '.';
        }
        public void UpdateNearTrees(List<Tree> nearTrees, Forest forest)
        {
            NearTrees = nearTrees;
            foreach (var t in NearTrees)
            {
                BurnTrees += t.Burn;
            }
        }
        public void DoneBurningRound()
        {
            _burnedThisRound = false;
        }
        
    }
}
