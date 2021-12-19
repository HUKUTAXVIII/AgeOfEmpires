using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgeOfEmpires
{
    public enum Dir { 
        FRONT,
        BACK,
        LEFT,
        RIGHT,
        NONE
    }

    public class Person
    {
        public Color Skin { set; get; }
        public Rectangle Rect { set; get; }
        public List<Point> Way { set; get; }
        public Dir dir { set; get; }
        public int Speed { set; get; }

        public Person()
        {
            Rect = new Rectangle(0,0,GameParams.CellSize, GameParams.CellSize);
            Way = new List<Point>();
            dir = Dir.NONE;
        }
        public Person(int x,int y):this()
        {
            Rect = new Rectangle(x, y, GameParams.CellSize, GameParams.CellSize);
            
        }

        public void Move() {

            if (this.Way.Count!=0) {

                if (this.Rect.X > Way.Last().X) {
                    Rect = new Rectangle(Rect.X - this.Speed, Rect.Y, Rect.Width, Rect.Height);
                }

                if (this.Rect.X < Way.Last().X)
                {
                    Rect = new Rectangle(Rect.X + this.Speed, Rect.Y, Rect.Width, Rect.Height);
                }

                if (this.Rect.Y > Way.Last().Y)
                {
                    Rect = new Rectangle(Rect.X, Rect.Y + this.Speed, Rect.Width, Rect.Height);
                }

                if (this.Rect.Y > Way.Last().Y)
                {
                    Rect = new Rectangle(Rect.X, Rect.Y - this.Speed, Rect.Width, Rect.Height);
                }

                if (this.Rect.Intersects(new Rectangle(Way.Last().X, Way.Last().Y, 8, 8))) {
                    this.Way.Clear();
                }
            }
        }



    }
}
