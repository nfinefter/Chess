using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public struct Move
    {
        [Flags]
        public enum Type
        {
            None = 0,
            EnPassant = 1,
            Castling = 2
        }
        public Point Destination;
        public Type Property;

        public Move(Point destination, Type property = Type.None)
        {
            Destination = destination;
            Property = property;
        }
    }
    public abstract class ChessPiece
    {
        public enum PieceType
        {
            Queen,
            King,
            Rook,
            Bishop,
            Knight,
            Pawn
        }
        public List<Move> Moves = new List<Move>();
        public Point BoardPos;
        public bool IsBlack;
        public PieceType Type;
        public ChessPiece(Point boardPos, PieceType pieceType, bool isBlack)
        {
            Type = pieceType;
            BoardPos = boardPos;
            IsBlack = isBlack;
        }

        public abstract List<Move> Move(ChessPiece[,] Grid);

    }
}
