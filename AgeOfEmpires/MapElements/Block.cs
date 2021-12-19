using Microsoft.Xna.Framework;

namespace AgeOfEmpires
{
    public class Block{
        public Rectangle Rect { set; get; }
        public bool Moveable { set; get; }
        public bool Visible { set; get; }
        public Block(int x,int y)
        {
            Rect = new Rectangle(x,y, GameParams.CellSize, GameParams.CellSize);
            Visible = false;
        }
        public Block(int x, int y,int size)
        {
            Rect = new Rectangle(x, y, size, size);
            Visible = false;
        }
        public Block(int x, int y, int width,int height)
        {
            Rect = new Rectangle(x, y, width, height);
            Visible = false;
        }
    }
}
