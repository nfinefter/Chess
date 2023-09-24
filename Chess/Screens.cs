using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class MenuScreen : Screen
    {
        public override void Begin()
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override Screenum Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
    public class GameScreen : Screen
    {

        public Texture2D ChessBoardTex;
        public Texture2D ChessPiecesTex;

        public ChessBoard chessBoard;

        public Dictionary<Textures, Rectangle> sprites = new Dictionary<Textures, Rectangle>()
        {
            [Textures.Queen] = new Rectangle(4, 6, 52, 48),
            [Textures.King] = new Rectangle(67, 7, 47, 47),
            [Textures.Rook] = new Rectangle(132, 10, 38, 42),
            [Textures.Knight] = new Rectangle(188, 8, 45, 44),
            [Textures.Bishop] = new Rectangle(247, 7, 46, 46),
            [Textures.Pawn] = new Rectangle(315, 69, 33, 43),
        };
        public override void Begin()
        { 
            chessBoard = new ChessBoard(ChessBoardTex, Game1.GameDimensions, Color.White, 0, Vector2.Zero);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            
            chessBoard.Draw(spriteBatch);

            spriteBatch.End();
        }

        public override Screenum Update(GameTime gameTime)
        {
            return Screenum.Game;
        }
    }
}
