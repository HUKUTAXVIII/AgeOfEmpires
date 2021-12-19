namespace AgeOfEmpires
{
    public class Rock : Block
    {
        public Rock() : base(0, 0)
        {
            Moveable = true;
        }
        public Rock(int x, int y) : base(x, y)
        {
            Moveable = true;
        }
        public override string ToString()
        {
            return "Rock";
        }
    }
}
