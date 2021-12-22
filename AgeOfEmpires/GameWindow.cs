using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace AgeOfEmpires
{

    public class Cell
    {
        public int Size { set; get; }
        public int X { set; get; }
        public int Y { set; get; }
        public string Type { set; get; }
    }

    public class GameWindow : Game
    {
        Texture2D grassTexture;
        Texture2D waterTexture;
        Texture2D dirtTexture;
        Texture2D rockTexture;
        Texture2D treeTexture;
        Texture2D sandTexture;

        Texture2D PL;
        Texture2D PR;
        Texture2D PS;

        Texture2D SL;
        Texture2D SR;
        Texture2D SS;

        Texture2D BL;

        Camera camera;

        
        List<Block> field = new List<Block>();
        List<Tree> trees = new List<Tree>();
        List<Stone> stones = new List<Stone>();

        List<Person> peoples = new List<Person>();

        public GameWindow()
        {
            GameParams.Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

         


            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            
            GameParams.Graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            GameParams.Graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            GameParams.Graphics.IsFullScreen = true;
            GameParams.Graphics.ApplyChanges();
            camera = new Camera(this.Window.ClientBounds.Width, this.Window.ClientBounds.Height);
            GameParams.CellSize = 64;

            string json = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"/NewMap.aoemap");

            var arr = JsonConvert.DeserializeObject<List<Cell>>(json);

            foreach (var item in arr)
            {
                item.X = (item.X / 16) * GameParams.CellSize;
                item.Y = (item.Y / 16) * GameParams.CellSize;
                switch (item.Type)
                {
                    case "Water":
                        this.field.Add(new Water(item.X,item.Y));
                        break;
                    case "Grass":
                        this.field.Add(new Grass(item.X, item.Y));
                        break;
                    case "Sand":
                        this.field.Add(new Sand(item.X, item.Y));
                        break;
                    case "Dirt":
                        this.field.Add(new Dirt(item.X, item.Y));
                        break;
                    case "Tree":
                        this.field.Add(new Grass(item.X, item.Y));
                        this.trees.Add(new Tree(item.X,item.Y));
                        break;
                    case "Rock":
                        this.field.Add(new Grass(item.X, item.Y));
                        this.stones.Add(new Stone(item.X, item.Y));
                        break;
                    default:
                        break;
                }
                
            }

            this.peoples.Add(new Person(800,800));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            GameParams.SB = new SpriteBatch(GraphicsDevice);

            grassTexture = Content.Load<Texture2D>("Grass");
            waterTexture = Content.Load<Texture2D>("Water");
            dirtTexture = Content.Load<Texture2D>("Dirt");
            rockTexture = Content.Load<Texture2D>("Stone");
            treeTexture = Content.Load<Texture2D>("Tree");
            sandTexture = Content.Load<Texture2D>("Sand");

            PL = Content.Load<Texture2D>("FL");
            PR = Content.Load<Texture2D>("FR");
            PS = Content.Load<Texture2D>("FS");

            SL = Content.Load<Texture2D>("SL");
            SR = Content.Load<Texture2D>("SR");
            SS = Content.Load<Texture2D>("SS");

            PL = Content.Load<Texture2D>("BL");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var mouse = Mouse.GetState();
            if (mouse.RightButton == ButtonState.Pressed) {
                for (int i = 0; i < this.peoples.Count; i++)
                {
                    this.peoples[i].Way.Clear();
                    this.peoples[i].Way.Add(new Point(mouse.X-camera.X, mouse.Y - camera.Y));
                }
            }
            for(int i=0;i<this.peoples.Count;i++)
            {
                this.peoples[i].Move();
            }

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
            GraphicsDevice.Clear(Color.Black);

            GameParams.SB.Begin();


            foreach (var item in this.field)
            {
                switch (item.ToString())
                {
                    case "Water":
                        GameParams.SB.Draw(waterTexture, item.Rect, Color.White);
                        
                        break;
                    case "Grass":
                        GameParams.SB.Draw(grassTexture, item.Rect, Color.White);
                        break;
                    case "Sand":
                        GameParams.SB.Draw(sandTexture, item.Rect, Color.White);
                        break;
                    case "Dirt":
                        GameParams.SB.Draw(dirtTexture, item.Rect, Color.White);
                        break;
                    default:
                        break;
                }
            }
            foreach (var item in this.trees)
            {
                GameParams.SB.Draw(treeTexture,item.Rect,Color.White);
            }
            foreach (var item in this.stones)
            {
                GameParams.SB.Draw(rockTexture, item.Rect, Color.White);
            }
            foreach (var item in this.peoples)
            {

                switch (item.dir)
                {
                    case Dir.FRONT:

                        if (item.Step >= 0 && item.Step <= 3)
                        {
                            GameParams.SB.Draw(this.PS, item.Rect, Color.White);
                        }
                        else if (item.Step > 3 && item.Step <= 6)
                        {
                            GameParams.SB.Draw(this.PR, item.Rect, Color.White);
                        }
                        else
                        {
                            GameParams.SB.Draw(this.PL, item.Rect, Color.White);
                        }

                        break;
                    case Dir.BACK:

                        if (item.Step >= 0 && item.Step <= 5)
                        {
                            GameParams.SB.Draw(this.PL, item.Rect, null, Color.White, 0, new Vector2(10, 16), SpriteEffects.FlipHorizontally, 0); 
                        }
                        else
                        {
                            GameParams.SB.Draw(this.PL, item.Rect, null, Color.White, 0, new Vector2(10, 16), SpriteEffects.None, 0);
                        }

                        break;
                    case Dir.LEFT:


                        if (item.Step >= 0 && item.Step <= 3)
                        {

                            GameParams.SB.Draw(this.SS, item.Rect, null, Color.White, 0, new Vector2(10, 16), SpriteEffects.FlipHorizontally, 0);
                        }
                        else if (item.Step > 3 && item.Step <= 6)
                        {

                            GameParams.SB.Draw(this.SR, item.Rect, null, Color.White, 0, new Vector2(10, 16), SpriteEffects.FlipHorizontally, 0);
                        }
                        else
                        {

                            GameParams.SB.Draw(this.SL, item.Rect, null, Color.White, 0, new Vector2(10, 16), SpriteEffects.FlipHorizontally, 0);
                        }




                       
                        break;
                    case Dir.RIGHT:
                        if (item.Step >= 0 && item.Step <= 3)
                        {
                            GameParams.SB.Draw(this.SS, item.Rect, null, Color.White, 0, new Vector2(10, 16), SpriteEffects.None, 0);
                        }
                        else if (item.Step > 3 && item.Step <= 6)
                        {
                            GameParams.SB.Draw(this.SR, item.Rect, null, Color.White, 0, new Vector2(10, 16), SpriteEffects.None, 0);
                        }
                        else
                        {
                            GameParams.SB.Draw(this.SL, item.Rect, null, Color.White, 0, new Vector2(10, 16), SpriteEffects.None, 0);
                        }




                        break;
                    case Dir.NONE:


                        if (item.Step >= 0 && item.Step <= 3)
                        {
                            GameParams.SB.Draw(this.PS, item.Rect, Color.White);
                        }
                        else if (item.Step > 3 && item.Step <= 6)
                        {
                            GameParams.SB.Draw(this.PR, item.Rect, Color.White);
                        }
                        else
                        {
                            GameParams.SB.Draw(this.PL, item.Rect, Color.White);
                        }


                        break;
                    default:
                        break;
                }

                

            }


            GameParams.SB.End();

            base.Draw(gameTime);
        }
    }
}
