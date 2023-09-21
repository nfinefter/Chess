using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public sealed class Knight : ChessPiece
    {
        public Knight(Texture2D tex, Rectangle pos, Color color, float rotation, Vector2 origin) : base(tex, pos, color, rotation, origin)
        {
        }
    }
    public sealed class Rook : ChessPiece
    {
        public Rook(Texture2D tex, Rectangle pos, Color color, float rotation, Vector2 origin) : base(tex, pos, color, rotation, origin)
        {
        }
    }
    public sealed class King : ChessPiece
    {
        public King(Texture2D tex, Rectangle pos, Color color, float rotation, Vector2 origin) : base(tex, pos, color, rotation, origin)
        {
        }
    }
    public sealed class Queen : ChessPiece
    {
        public Queen(Texture2D tex, Rectangle pos, Color color, float rotation, Vector2 origin) : base(tex, pos, color, rotation, origin)
        {
        }
    }
    public sealed class Bishop : ChessPiece
    {
        public Bishop(Texture2D tex, Rectangle pos, Color color, float rotation, Vector2 origin) : base(tex, pos, color, rotation, origin)
        {
        }
    }

    public sealed class Pawn : ChessPiece
    {
        public Pawn(Texture2D tex, Rectangle pos, Color color, float rotation, Vector2 origin) : base(tex, pos, color, rotation, origin)
        {
        }
    }
}
