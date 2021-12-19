using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgeOfEmpires
{
    public class Stone
    {
        public Rectangle Rect { set; get; }
        public int HP { set; get; }
        public bool Visible { set; get; }
        public Stone()
        {
            Rect = new Rectangle(0, 0, GameParams.CellSize, GameParams.CellSize);
            HP = 25;
        }
        public Stone(int x, int y)
        {
            Rect = new Rectangle(x, y, GameParams.CellSize, GameParams.CellSize);
            HP = 25;
        }

        public Rectangle ToRect()
        {

            return new Rectangle(Rect.X, Rect.Y, Rect.Width, Rect.Height);
        }



    }
}
