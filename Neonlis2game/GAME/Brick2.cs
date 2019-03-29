using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Neonlis2game
{
    public class Brick2 : gBaseClass
    {
        public Brick2(Game game, ref Texture2D _sprTexture,
            Vector2 _sprPosition, Rectangle _sprRectangle, int x_c, int y_c)
            : base(game, ref _sprTexture, _sprPosition, _sprRectangle, x_c, y_c)
        {

        }

    }
}
