namespace AgeOfEmpires
{
    public class Water : Block
    {
        public Water() : base(0, 0)
        {
            Moveable = false;
        }
        public Water(int x, int y) : base(x, y)
        {
            Moveable = false;
        }
        public override string ToString()
        {
            return "Water";
        }
    }
}
