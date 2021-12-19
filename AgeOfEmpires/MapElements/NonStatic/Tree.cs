using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgeOfEmpires
{
    public class Tree
    {
        public Rectangle Rect { set; get; }
        public int Origin;
        public int HP { set; get; }
        public bool Visible { set; get; }
        public Tree()
        {
            Rect = new Rectangle(0,0,GameParams.CellSize, GameParams.CellSize*2);
            Origin = GameParams.CellSize;
            HP = 25;
        }
        public Tree(int x,int y)
        {
            Origin = GameParams.CellSize;
            Rect = new Rectangle(x, y-Origin, GameParams.CellSize, GameParams.CellSize * 2);
            HP = 25;
        }

        public Rectangle GetRect() {

            return new Rectangle(Rect.X,Rect.Y+Origin,Rect.Width,Rect.Height-Origin);
        }



    }
}
