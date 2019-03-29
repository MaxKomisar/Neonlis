using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Neonlis2game
{
    public class Brick1 : gBaseClass
    {
        public static Vector2 pos;

        public Brick1(Game game, ref Texture2D _sprTexture,
            Vector2 _sprPosition, Rectangle _sprRectangle, int x_c, int y_c)
           
            : base(game, ref _sprTexture, _sprPosition, _sprRectangle, x_c, y_c)
        {
            pos.X = x_c;
            pos.Y = y_c;
        }

        
    }
    public class Brick3 : gBaseClass
    {

         public static Vector2 pos;

        public Brick3(Game game, ref Texture2D _sprTexture,
            Vector2 _sprPosition, Rectangle _sprRectangle, int x_c, int y_c)
           
            : base(game, ref _sprTexture, _sprPosition, _sprRectangle, x_c, y_c)
        {
            pos.X = x_c;
            pos.Y = y_c;
        }
    }
    public class Brick4 : gBaseClass
    {

        public static Vector2 pos;

        public Brick4(Game game, ref Texture2D _sprTexture,
            Vector2 _sprPosition, Rectangle _sprRectangle, int x_c, int y_c)

            : base(game, ref _sprTexture, _sprPosition, _sprRectangle, x_c, y_c)
        {
            pos.X = x_c;
            pos.Y = y_c;
        }
    }
    public class Brick5 : gBaseClass
    {

        public static Vector2 pos;

        public Brick5(Game game, ref Texture2D _sprTexture,
            Vector2 _sprPosition, Rectangle _sprRectangle, int x_c, int y_c)

            : base(game, ref _sprTexture, _sprPosition, _sprRectangle, x_c, y_c)
        {
            pos.X = x_c;
            pos.Y = y_c;
        }
    }
    public class Brick6 : gBaseClass
    {

        public static Vector2 pos;

        public Brick6(Game game, ref Texture2D _sprTexture,
            Vector2 _sprPosition, Rectangle _sprRectangle, int x_c, int y_c)

            : base(game, ref _sprTexture, _sprPosition, _sprRectangle, x_c, y_c)
        {
            pos.X = x_c;
            pos.Y = y_c;
        }

       
    }
}
