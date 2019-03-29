using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Neonlis2game
{
     public class gBaseClass : Microsoft.Xna.Framework.DrawableGameComponent
        {
            public Texture2D sprTexture;
            public Vector2 sprPosition;
            public Rectangle sprRectangle;

            public int ScaleX = 1;
            public gBaseClass(Game game, ref Texture2D _sprTexture,
                Vector2 _sprPosition, Rectangle _sprRectangle, int X_Coord, int Y_Coord)
                : base(game)
            {
                sprTexture = _sprTexture;
                
                //Здесь производится перевод индекса элемента массива
                //в координаты на игровом экране
                //Так как спрайты имеют различные размеры, для их размещения на экране
                //используются коэффициенты X_Coord и Y_Coord
                sprPosition.X = _sprPosition.X * X_Coord + 16;
                sprPosition.Y = _sprPosition.Y * Y_Coord;
                sprRectangle = _sprRectangle;
            }

           
        

            public override void Draw(GameTime gameTime)
            {
                SpriteBatch sprBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
                sprBatch.Draw(sprTexture, sprPosition, Color.White);
                base.Draw(gameTime);
            }
         
        }
}
