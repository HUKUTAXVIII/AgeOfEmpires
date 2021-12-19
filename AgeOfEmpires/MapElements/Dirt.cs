namespace AgeOfEmpires
{
    public class Dirt : Block {
        public Dirt():base(0,0)
        {
            Moveable = true;
        }
        public Dirt(int x,int y):base(x,y)
        {
            Moveable = true;
        }
        public override string ToString()
        {
            return "Dirt";
        }
    }
}
