namespace AgeOfEmpires
{
    public class Wood : Block
    {
        public Wood() : base(0, 0)
        {
            Moveable = false;
        }
        public Wood(int x, int y) : base(x, y)
        {
            Moveable = false;
        }
        public override string ToString()
        {
            return "Tree";
        }
    }
}
