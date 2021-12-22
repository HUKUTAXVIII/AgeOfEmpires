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
        public int Step { set; get; }

        public Person()
        {
            Rect = new Rectangle(0,0,GameParams.CellSize, GameParams.CellSize);
            Way = new List<Point>();
            dir = Dir.NONE;
            this.Speed = 4;
            Step = 0;
        }
        public Person(int x,int y):this()
        {
            Rect = new Rectangle(x, y, (int)(GameParams.CellSize/2), (int)(GameParams.CellSize/1.5));
            
        }

        public void Move() {

            if (this.Way.Count!=0) {

                if (this.Rect.X > Way.First().X) {
                    Rect = new Rectangle(Rect.X - this.Speed, Rect.Y, Rect.Width, Rect.Height);
                    dir = Dir.LEFT;
                }
                else if (this.Rect.X < Way.First().X)
                {
                    Rect = new Rectangle(Rect.X + this.Speed, Rect.Y, Rect.Width, Rect.Height);
                    dir = Dir.RIGHT;
                }
                else if(this.Rect.Y < Way.First().Y)
                {
                    Rect = new Rectangle(Rect.X, Rect.Y + this.Speed, Rect.Width, Rect.Height);
                    dir = Dir.FRONT;
                }
                else if(this.Rect.Y > Way.First().Y)
                {
                    Rect = new Rectangle(Rect.X, Rect.Y - this.Speed, Rect.Width, Rect.Height);
                    dir = Dir.BACK;
                }

                Step++;
                if (Step > 10) {
                    Step = 0;
                }

                if (this.Rect.Intersects(new Rectangle(Way.First().X-3, Way.First().Y-3, 8, 8))) {
                    this.Way.Clear();
                }
            }
        }



    }
}
