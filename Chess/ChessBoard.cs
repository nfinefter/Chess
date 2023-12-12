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
                            //KingPos is 4, 7 but the Queen when it should be 5, 6 after being killed by the king basically it is missing after the simulation.
                        }
                    }
                }

            }
            return false;
        }
        public bool IsInCheckMate(bool isWhite)
        {
            Point KingPos = FindKing(isWhite);

            List<Point> moves = new List<Point>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Grid[i, j] != null && Grid[i, j].IsBlack == !isWhite)
                    {
                        moves.AddRange(Grid[i, j].Move(Grid));
                        if (!IsInCheckPostSimulation(moves, Grid[i, j]))
                        {
                            return false;
                        }
                        moves.Clear();
                    }
                }
            }

            return true;
        }
        public bool IsInCheckPostSimulation(List<Point> Moves, ChessPiece Piece)
        {
            bool checkMate = true;
            foreach (var move in Moves)
            {
                var tempBoardPos = Piece.BoardPos;
                ChessPiece tempPiece = Grid[move.X, move.Y];
                Point tempGridPos = new Point(move.X, move.Y);

                Piece.BoardPos = new Point(move.X, move.Y);
                Grid[move.X, move.Y] = Piece;

                var tempPreviousPos = Grid[Piece.BoardPos.X, Piece.BoardPos.Y];

                Grid[Piece.BoardPos.X, Piece.BoardPos.Y] = null;

                if (!IsInCheck(!Piece.IsBlack))
                {
                    checkMate = false;
                }

                Grid[Piece.BoardPos.X, Piece.BoardPos.Y] = tempPreviousPos;

                Piece.BoardPos = tempBoardPos;
                Grid[tempGridPos.X, tempGridPos.Y] = tempPiece;
            }

            return checkMate;
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
