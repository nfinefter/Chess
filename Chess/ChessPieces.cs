using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public sealed class Knight : ChessPiece
    {
        public Knight(Point pos, PieceType pieceType, bool isBlack) : base(pos, pieceType, isBlack)
        {

        }

        public override List<Point> Move(ChessPiece[,] Grid)
        {
            return PossibleMoves;
        }
    }
    public sealed class Rook : ChessPiece
    {
        public bool HasMoved = false;
        public Rook(Point pos, PieceType pieceType, bool isBlack) : base(pos, pieceType, isBlack)
        {
        }

        public override List<Point> Move(ChessPiece[,] Grid)
        {
            for (int i = 1; i < Grid.GetLength(0); i++)
            {

                if (BoardPos.Y + i < Grid.GetLength(0))
                {
                    PossibleMoves.Add(new Point(BoardPos.X, BoardPos.Y + i));

                    if (Grid[BoardPos.X, BoardPos.Y + i] != null)
                    {
                        if (Grid[BoardPos.X, BoardPos.Y + i].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Point(BoardPos.X, BoardPos.Y + i));
                        }
                        break;
                    }

                }

            }
            for (int i = 1; i < Grid.GetLength(0); i++)
            {

                if (BoardPos.X + i < Grid.GetLength(0))
                {
                    PossibleMoves.Add(new Point(BoardPos.X + i, BoardPos.Y));

                    if (Grid[BoardPos.X + i, BoardPos.Y] != null)
                    {
                        if (Grid[BoardPos.X + i, BoardPos.Y].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Point(BoardPos.X + i, BoardPos.Y));
                        }
                        break;
                    }

                }

            }
            for (int i = 1; i < Grid.GetLength(0); i++)
            {

                if (BoardPos.Y - i >= 0)
                {
                    PossibleMoves.Add(new Point(BoardPos.X, BoardPos.Y - i));

                    if (Grid[BoardPos.X, BoardPos.Y - i] != null)
                    {
                        if (Grid[BoardPos.X, BoardPos.Y - i].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Point(BoardPos.X, BoardPos.Y - i));
                        }
                        break;
                    }

                }

            }
            for (int i = 1; i < Grid.GetLength(0); i++)
            {

                if (BoardPos.X - i >= 0)
                {
                    PossibleMoves.Add(new Point(BoardPos.X - i, BoardPos.Y));

                    if (Grid[BoardPos.X - i, BoardPos.Y] != null)
                    {
                        if (Grid[BoardPos.X - i, BoardPos.Y].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Point(BoardPos.X - i, BoardPos.Y));
                        }
                        break;
                    }

                }

            }


            return PossibleMoves;
        }
    }
    public sealed class King : ChessPiece
    {
        public bool HasMoved = false;
        public King(Point pos, PieceType pieceType, bool isBlack) : base(pos, pieceType, isBlack)
        {
        }

        public override List<Point> Move(ChessPiece[,] Grid)
        {
            return PossibleMoves;
        }
    }
    public sealed class Queen : ChessPiece
    {

        public Queen(Point pos, PieceType pieceType, bool isBlack) : base(pos, pieceType, isBlack)
        {
        }

        public override List<Point> Move(ChessPiece[,] Grid)
        {
            for (int i = 1; i < Grid.GetLength(0); i++)
            {

                if (BoardPos.Y + i < Grid.GetLength(0))
                {
                    PossibleMoves.Add(new Point(BoardPos.X, BoardPos.Y + i));

                    if (Grid[BoardPos.X, BoardPos.Y + i] != null)
                    {
                        if (Grid[BoardPos.X, BoardPos.Y + i].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Point(BoardPos.X, BoardPos.Y + i));
                        }
                        break;
                    }

                }

            }
            for (int i = 1; i < Grid.GetLength(0); i++)
            {

                if (BoardPos.X + i < Grid.GetLength(0))
                {
                    PossibleMoves.Add(new Point(BoardPos.X + i, BoardPos.Y));

                    if (Grid[BoardPos.X + i, BoardPos.Y] != null)
                    {
                        if (Grid[BoardPos.X + i, BoardPos.Y].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Point(BoardPos.X + i, BoardPos.Y));
                        }
                        break;
                    }

                }

            }
            for (int i = 1; i < Grid.GetLength(0); i++)
            {

                if (BoardPos.Y - i >= 0)
                {
                    PossibleMoves.Add(new Point(BoardPos.X, BoardPos.Y - i));

                    if (Grid[BoardPos.X, BoardPos.Y - i] != null)
                    {
                        if (Grid[BoardPos.X, BoardPos.Y - i].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Point(BoardPos.X, BoardPos.Y - i));
                        }
                        break;
                    }

                }

            }
            for (int i = 1; i < Grid.GetLength(0); i++)
            {

                if (BoardPos.X - i >= 0)
                {
                    PossibleMoves.Add(new Point(BoardPos.X - i, BoardPos.Y));

                    if (Grid[BoardPos.X - i, BoardPos.Y] != null)
                    {
                        if (Grid[BoardPos.X - i, BoardPos.Y].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Point(BoardPos.X - i, BoardPos.Y));
                        }
                        break;
                    }

                }

            }
            for (int i = 1; i < Grid.GetLength(0); i++)
            {

                if (BoardPos.Y + i < Grid.GetLength(0) && BoardPos.X + i < Grid.GetLength(0))
                {
                    PossibleMoves.Add(new Point(BoardPos.X + i, BoardPos.Y + i));

                    if (Grid[BoardPos.X + i, BoardPos.Y + i] != null)
                    {
                        if (Grid[BoardPos.X + i, BoardPos.Y + i].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Point(BoardPos.X + i, BoardPos.Y + i));
                        }
                        break;
                    }

                }

            }
            for (int i = 1; i < Grid.GetLength(0); i++)
            {
                if (BoardPos.Y - i >= 0 && BoardPos.X + i < Grid.GetLength(0))
                {
                    PossibleMoves.Add(new Point(BoardPos.X + i, BoardPos.Y - i));

                    if (Grid[BoardPos.X + i, BoardPos.Y - i] != null)
                    {
                        if (Grid[BoardPos.X + i, BoardPos.Y - i].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Point(BoardPos.X + i, BoardPos.Y - i));
                        }
                        break;
                    }
                }
            }
            for (int i = 1; i < Grid.GetLength(0); i++)
            {
                if (BoardPos.Y + i < Grid.GetLength(0) && BoardPos.X - i >= 0)
                {
                    PossibleMoves.Add(new Point(BoardPos.X - i, BoardPos.Y + i));

                    if (Grid[BoardPos.X - i, BoardPos.Y + i] != null)
                    {
                        if (Grid[BoardPos.X - i, BoardPos.Y + i].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Point(BoardPos.X - i, BoardPos.Y + i));
                        }
                        break;
                    }
                }
            }
            for (int i = 1; i < Grid.GetLength(0); i++)
            {
                if (BoardPos.Y - i >= 0 && BoardPos.X - i >= 0)
                {
                    PossibleMoves.Add(new Point(BoardPos.X - i, BoardPos.Y - i));

                    if (Grid[BoardPos.X - i, BoardPos.Y - i] != null)
                    {
                        if (Grid[BoardPos.X - i, BoardPos.Y - i].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Point(BoardPos.X - i, BoardPos.Y - i));
                        }
                        break;
                    }
                }
            }

            return PossibleMoves;
        }
    }
    public sealed class Bishop : ChessPiece
    {
        public Bishop(Point pos, PieceType pieceType, bool isBlack) : base(pos, pieceType, isBlack)
        {
        }

        public override List<Point> Move(ChessPiece[,] Grid)
        {
            
            for (int i = 1; i < Grid.GetLength(0); i++)
            {

                if (BoardPos.Y + i < Grid.GetLength(0) && BoardPos.X + i < Grid.GetLength(0))
                {
                    PossibleMoves.Add(new Point(BoardPos.X + i, BoardPos.Y + i));

                    if (Grid[BoardPos.X + i, BoardPos.Y + i] != null)
                    {
                        if (Grid[BoardPos.X + i, BoardPos.Y + i].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Point(BoardPos.X + i, BoardPos.Y + i));
                        }
                        break;
                    }
                    
                }
              
            }
            for (int i = 1; i < Grid.GetLength(0); i++)
            {
                if (BoardPos.Y - i >= 0 && BoardPos.X + i < Grid.GetLength(0))
                {
                    PossibleMoves.Add(new Point(BoardPos.X + i, BoardPos.Y - i));

                    if (Grid[BoardPos.X + i, BoardPos.Y - i] != null)
                    {
                        if (Grid[BoardPos.X + i, BoardPos.Y - i].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Point(BoardPos.X + i, BoardPos.Y - i));
                        }
                        break;
                    }
                }
            }
            for (int i = 1; i < Grid.GetLength(0); i++)
            {
                if (BoardPos.Y + i < Grid.GetLength(0) && BoardPos.X - i >= 0)
                {
                    PossibleMoves.Add(new Point(BoardPos.X - i, BoardPos.Y + i));

                    if (Grid[BoardPos.X - i, BoardPos.Y + i] != null)
                    {
                        if (Grid[BoardPos.X - i, BoardPos.Y + i].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Point(BoardPos.X - i, BoardPos.Y + i));
                        }
                        break;
                    }
                }
            }
            for (int i = 1; i < Grid.GetLength(0); i++)
            {
                if (BoardPos.Y - i >= 0 && BoardPos.X - i >= 0)
                {
                    PossibleMoves.Add(new Point(BoardPos.X - i, BoardPos.Y - i));

                    if (Grid[BoardPos.X - i, BoardPos.Y - i] != null)
                    {
                        if (Grid[BoardPos.X - i, BoardPos.Y - i].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Point(BoardPos.X - i, BoardPos.Y - i));
                        }
                        break;
                    }
                }
            }

            return PossibleMoves;
        }
    }
    public sealed class Pawn : ChessPiece
    {
        public bool HasMoved = false;
        public Pawn(Point pos, PieceType pieceType, bool isBlack) : base(pos, pieceType, isBlack)
        {
        }

        public override List<Point> Move(ChessPiece[,] Grid)
        {

            if (!HasMoved)
            {
                if (BoardPos.Y + 2 < Grid.GetLength(0) && Grid[BoardPos.X, BoardPos.Y + 1] == null && Grid[BoardPos.X, BoardPos.Y + 2] == null && IsBlack)
                {
                    PossibleMoves.Add(new Point(BoardPos.X, BoardPos.Y + 2));
                }
                if (BoardPos.Y - 2 >= 0 && Grid[BoardPos.X, BoardPos.Y - 1] == null && Grid[BoardPos.X, BoardPos.Y - 2] == null && !IsBlack)
                {
                    PossibleMoves.Add(new Point(BoardPos.X, BoardPos.Y - 2));
                }
            }
            

            if (BoardPos.Y + 1 < Grid.GetLength(0) && Grid[BoardPos.X, BoardPos.Y + 1] == null && IsBlack)
            {
                PossibleMoves.Add(new Point(BoardPos.X, BoardPos.Y + 1));
            }
            if (BoardPos.Y - 1 >= 0 && Grid[BoardPos.X, BoardPos.Y - 1] == null && !IsBlack)
            {
                PossibleMoves.Add(new Point(BoardPos.X, BoardPos.Y - 1));
            }

            if (BoardPos.X - 1 >= 0 && BoardPos.Y - 1 >= 0 && Grid[BoardPos.X - 1, BoardPos.Y - 1] != null && !IsBlack && Grid[BoardPos.X -1, BoardPos.Y - 1].IsBlack != IsBlack)
            {
                PossibleMoves.Add(new Point(BoardPos.X - 1, BoardPos.Y - 1));
            }
            if (BoardPos.X + 1 < Grid.GetLength(0) && BoardPos.Y - 1 >= 0 && Grid[BoardPos.X + 1, BoardPos.Y - 1] != null && !IsBlack && Grid[BoardPos.X + 1, BoardPos.Y - 1].IsBlack != IsBlack)
            {
                PossibleMoves.Add(new Point(BoardPos.X + 1, BoardPos.Y - 1));
            }

            if (BoardPos.X - 1 >= 0 && BoardPos.Y + 1 < Grid.GetLength(0) && Grid[BoardPos.X - 1, BoardPos.Y + 1] != null && IsBlack && Grid[BoardPos.X - 1, BoardPos.Y + 1].IsBlack != IsBlack)
            {
                PossibleMoves.Add(new Point(BoardPos.X - 1, BoardPos.Y + 1));
            }
            if (BoardPos.X + 1 < Grid.GetLength(0) && BoardPos.Y + 1 < Grid.GetLength(0) && Grid[BoardPos.X + 1, BoardPos.Y + 1] != null && IsBlack && Grid[BoardPos.X + 1, BoardPos.Y + 1].IsBlack != IsBlack)
            {
                PossibleMoves.Add(new Point(BoardPos.X + 1, BoardPos.Y + 1));
            }


            return PossibleMoves;
        }
    }
}
