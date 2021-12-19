namespace AgeOfEmpires
{
    public class Sand : Block
    {
        public Sand() : base(0, 0)
        {
            Moveable = true;
        }
        public Sand(int x, int y) : base(x, y)
        {
            Moveable = true;
        }
        public override string ToString()
        {
            return "Sand";
        }
    }
}
