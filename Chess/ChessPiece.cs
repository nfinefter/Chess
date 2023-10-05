using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
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

        public Point BoardPos;
        public bool IsBlack;
        public PieceType Type;
        public ChessPiece(Point boardPos, PieceType pieceType, bool isBlack)
        {
            Type = pieceType;
            BoardPos = boardPos;
            IsBlack = isBlack;
        }

    }
}
