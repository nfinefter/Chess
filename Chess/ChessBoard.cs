using Microsoft.Xna.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public sealed class ChessBoard : GameObject
    {
        public override Vector2 Origin => throw new NotImplementedException();
       
        public override Rectangle? SourceRectangle => throw new NotImplementedException();
       
        public ChessBoard(Rectangle pos, Color color, float rotation)
            : base(pos, color, rotation)
        {

        }
        public override void Update(GameTime gameTime)
        {
            
            throw new NotImplementedException();
        }

    
    }
}
