using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public sealed class ChessBoard : Sprite
    {
        public ChessPiece[,] Grid = new ChessPiece[8,8];
        public ChessBoard(Texture2D tex, Rectangle pos, Color color, float rotation, Vector2 origin)
            : base(tex, pos, color, rotation, origin)
        {

        }
        public override void Update(GameTime gameTime)
        {
            
            throw new NotImplementedException();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Grid[i, j] != null)
                    {
                        Vector2 ScreenPos = Grid[i, j].BoardPos.ToVector2();
                        spriteBatch.Draw(GameScreen.ChessPiecesTex, new Vector2(50 + (ScreenPos.X*75), (ScreenPos.Y*75)), Grid[i, j].IsBlack ? Color.Black : Color.White);
                    }
                }
            }

            base.Draw(spriteBatch);
        }

    }
}
