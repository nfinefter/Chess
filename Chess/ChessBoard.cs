using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Extended;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public sealed class ChessBoard : Sprite
    {
        public bool WhiteTurn = true;
        public bool InCheck = false;

        public ChessPiece[,] Grid = new ChessPiece[8, 8];
        public ChessBoard(Texture2D tex, Rectangle pos, Color color, float rotation, Vector2 origin)
            : base(tex, pos, color, rotation, origin)
        {

        }
        public override void Update(GameTime gameTime)
        {

            throw new NotImplementedException();
        }

        public Point FindKing(bool isWhite)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Grid[i, j] != null && Grid[i, j].Type == ChessPiece.PieceType.King && Grid[i, j].IsBlack == !isWhite)
                    {
                        return new Point(i, j);
                    }
                }
            }
            return new Point();
        }
        public bool IsInCheck(bool isWhite)
        {
            Point KingPos = FindKing(isWhite);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Grid[i, j] != null)
                    {
                        var moves = Grid[i, j].Move(Grid);
                        if (moves.Contains(KingPos))
                        {
                            return true;
                        }
                    }                
                }

            }
            return false;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {

            base.Draw(spriteBatch);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Grid[i, j] != null)
                    {
                        Point ScreenPos = Grid[i, j].BoardPos;
                        spriteBatch.Draw(GameScreen.ChessPiecesTex, new Rectangle(50 + ScreenPos.X * 75, ScreenPos.Y * 75, 50, 50), GameScreen.PieceToSprite[Grid[i, j].Type].Item2, Grid[i, j].IsBlack ? Color.Black : Color.White);
                        //spriteBatch.Draw(GameScreen.ChessPiecesTex, new Vector2(50 + (ScreenPos.X*75), (ScreenPos.Y*75)), Grid[i, j].IsBlack ? Color.Black : Color.White);
                    }
                }
            }



        }

    }
}
