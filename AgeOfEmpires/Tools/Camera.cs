using Microsoft.Xna.Framework.Graphics;

namespace AgeOfEmpires
{
    public class Camera {
        public Viewport viewport { set; get; }
        public int Width { set; get; }
        public int Height { set; get; }
        public int Speed { set; get; }
        public int X;
        public int Y;
        public Camera(int w,int h) {
            X = 100;
            Y = 100;
            this.Speed = 16;
            viewport = new Viewport(0,0,w,h);
            this.Width = w;
            this.Height = h;
            
        }

        public void MoveUp() {
            this.Y += this.Speed;
            this.Height -= this.Speed;
        }
        public void MoveDown()
        {
            this.Y -= this.Speed;
            this.Height += this.Speed;
        }
        public void MoveLeft()
        {
            this.X += this.Speed;
            this.Width -= this.Speed;
        }
        public void MoveRight()
        {
            this.X -= this.Speed;
            this.Width += this.Speed;
        }

        public void Update() {
            this.viewport = new Viewport(this.X,this.Y,this.Width,this.Height);
        }


    }
}
