using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Neonlis2game
{
    class Backgrounds
    {
       public Texture2D texture;
       public  Rectangle rectangle;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
    
    class Scrolling : Backgrounds
    {
        public Scrolling(Texture2D newTexture,Rectangle newRactangle)
        {
            texture = newTexture;
            rectangle = newRactangle;
        }

        public void Update()
        {
            //rectangle.X -= 3;
        }
    }
}
