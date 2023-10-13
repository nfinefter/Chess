using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
    public sealed class Queen : ChessPiece
    {

        public Queen(Point pos, PieceType pieceType, bool isBlack) : base(pos, pieceType, isBlack)
        {
        }

        public override List<Point> Move(ChessPiece[,] Grid)
        {
            throw new NotImplementedException();
        }
    }
    public sealed class Bishop : ChessPiece
    {
        public Bishop(Point pos, PieceType pieceType, bool isBlack) : base(pos, pieceType, isBlack)
        {
        }

        public override List<Point> Move(ChessPiece[,] Grid)
        {
            throw new NotImplementedException();
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
            List<Point> PossibleMoves = new List<Point>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (!HasMoved)
                    {
                        if (Grid[BoardPos.X, BoardPos.Y + 2] == null && IsBlack)
                        {
                            PossibleMoves.Add(new Point(BoardPos.X, BoardPos.Y + 2));
                        }
                        else if (Grid[BoardPos.X, BoardPos.Y - 2] == null && !IsBlack)
                        {
                            PossibleMoves.Add(new Point(BoardPos.X, BoardPos.Y - 2));
                        }
                        HasMoved = true;
                    }


                    if (Grid[BoardPos.X, BoardPos.Y + 1] == null && IsBlack)
                    {
                        PossibleMoves.Add(new Point(BoardPos.X, BoardPos.Y + 1));
                    }
                    else if (Grid[BoardPos.X, BoardPos.Y - 1] == null && !IsBlack)
                    {
                        PossibleMoves.Add(new Point(BoardPos.X, BoardPos.Y - 1));
                    }
                    else if (Grid[BoardPos.X - 1, BoardPos.Y - 1] == null && !IsBlack)
                    {
                        PossibleMoves.Add(new Point(BoardPos.X - 1, BoardPos.Y - 1));
                    }
                    else if (Grid[BoardPos.X + 1, BoardPos.Y - 1] == null && !IsBlack)
                    {
                        PossibleMoves.Add(new Point(BoardPos.X + 1, BoardPos.Y - 1));
                    }
                    else if (Grid[BoardPos.X - 1, BoardPos.Y + 1] == null && IsBlack)
                    {
                        PossibleMoves.Add(new Point(BoardPos.X - 1, BoardPos.Y + 1));
                    }
                    else if (Grid[BoardPos.X + 1, BoardPos.Y + 1] == null && IsBlack)
                    {
                        PossibleMoves.Add(new Point(BoardPos.X + 1, BoardPos.Y + 1));
                    }
                }
            }
            return PossibleMoves;
        }
    }
}
