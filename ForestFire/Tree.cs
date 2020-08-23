namespace ForestFire
{
    public class Tree
    {
        public int LifePoints{ get; set; }
        public char Status { get; set; }
        public Tree(int lifePoints)
        {
            LifePoints = lifePoints;
            Status = 'o';
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
