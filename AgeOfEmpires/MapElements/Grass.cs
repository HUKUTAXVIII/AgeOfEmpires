namespace AgeOfEmpires
{
    public class Grass : Block
    {
        public Grass() : base(0, 0)
        {
            Moveable = true;
        }
        public Grass(int x, int y) : base(x, y)
        {
            Moveable = true;
        }
        public override string ToString()
        {
            return "Grass";
        }
    }
}
