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
