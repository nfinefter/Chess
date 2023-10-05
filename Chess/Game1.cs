
global using HelperLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Chess
{
    public enum Textures
    {
        ChessBoard,
        ChessPieces,
        King,
        Queen,
        Bishop,
        Knight,
        Rook,
        Pawn
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public static GameScreen Game;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public static Rectangle GameDimensions;
          

        protected override void Initialize()
        {

            Game = new GameScreen();
            ScreenManager.Instance.Init((Screenum.Game, Game));

            ScreenManager.Instance.currentScreen = Screenum.Game;

            Game.ChessBoardTex = Content.Load<Texture2D>("chessBoard");
            GameScreen.ChessPiecesTex = Content.Load<Texture2D>("chessPieces");

            graphics.PreferredBackBufferWidth = Game.ChessBoardTex.Width / 2;
            graphics.PreferredBackBufferHeight = Game.ChessBoardTex.Height / 2;

            graphics.ApplyChanges();

            GameDimensions = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            ContentManager<Textures>.Instance[Textures.ChessBoard] = Game.ChessBoardTex;
            ContentManager<Textures>.Instance[Textures.ChessPieces] = GameScreen.ChessPiecesTex;

            Game.Begin();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ScreenManager.Instance.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            ScreenManager.Instance.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}