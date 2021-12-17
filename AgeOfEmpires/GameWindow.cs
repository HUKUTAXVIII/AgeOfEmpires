using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        }
        public void MoveDown()
        {
            this.Y -= this.Speed;
        }
        public void MoveLeft()
        {
            this.X += this.Speed;
        }
        public void MoveRight()
        {
            this.X -= this.Speed;
        }

        public void Update() {
            this.viewport = new Viewport(this.X,this.Y,this.Width,this.Height);
        }


    }

    public class GameWindow : Game
    {
        Texture2D grassTexture;
        Texture2D waterTexture;
        Texture2D dirtTexture;
        Texture2D rockTexture;
        Texture2D treeTexture;
        Texture2D sandTexture;
        Camera camera;

        public GameWindow()
        {
            GameParams.Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            camera = new Camera(this.Window.ClientBounds.Width, this.Window.ClientBounds.Height);
            
            

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            GameParams.SB = new SpriteBatch(GraphicsDevice);

            grassTexture = Content.Load<Texture2D>("Grass");
            waterTexture = Content.Load<Texture2D>("Water");
            dirtTexture = Content.Load<Texture2D>("Dirt");
            rockTexture = Content.Load<Texture2D>("Rock");
            treeTexture = Content.Load<Texture2D>("Tree");
            sandTexture = Content.Load<Texture2D>("Sand");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            var mouse = Mouse.GetState();

            if (mouse.X < 20) {
                camera.MoveLeft();
                Window.Title = "Left";
            }
            if (mouse.X > Window.ClientBounds.Width-20)
            {
                camera.MoveRight();
                Window.Title = "Right";
            }
            if (mouse.Y < 20)
            {
                camera.MoveUp();
                Window.Title = "Up";
            }
            if (mouse.Y > Window.ClientBounds.Height - 20)
            {
                Window.Title = "Down";
                camera.MoveDown();
            }
            this.camera.Update();

            // TODO: Add your update logic here
            GameParams.Graphics.GraphicsDevice.Viewport = camera.viewport;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            GameParams.SB.Begin();
            GameParams.SB.Draw(grassTexture, new Rectangle(0,0,32,32),Color.White);
            GameParams.SB.Draw(waterTexture, new Rectangle(32, 0, 32, 32), Color.White);
            GameParams.SB.Draw(dirtTexture , new Rectangle(64, 0, 32, 32), Color.White);
            GameParams.SB.Draw(rockTexture , new Rectangle(0, 32, 32, 32), Color.White);
            GameParams.SB.Draw(treeTexture , new Rectangle(32, 32, 32, 32), Color.White);
            GameParams.SB.Draw(sandTexture , new Rectangle(64, 32, 32, 32), Color.White);
            GameParams.SB.End();

            base.Draw(gameTime);
        }
    }
}
