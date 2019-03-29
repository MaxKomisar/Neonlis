using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Neonlis2game
{
  public class BonusItems : gBaseClass
    {
      public Vector4 ColorAlpha { get; set; }
      
      public int velocityY = 1;
      public BonusItems(Game game, ref Texture2D _sprTexture,
            Vector2 _sprPosition, Rectangle _sprRectangle, int x_c, int y_c)
          : base(game, ref _sprTexture, _sprPosition, _sprRectangle, x_c, y_c)
      {
         
      }

      // Drope Item
      public override void Update(GameTime gameTime)
      {
          this.sprPosition.Y++;
          base.Update(gameTime);
      }
     
    }

  public class BonusItems1 : gBaseClass
  {
      public Vector4 ColorAlpha { get; set; }

      public int velocityY = 1;
      public BonusItems1(Game game, ref Texture2D _sprTexture,
            Vector2 _sprPosition, Rectangle _sprRectangle, int x_c, int y_c)
          : base(game, ref _sprTexture, _sprPosition, _sprRectangle, x_c, y_c)
      {

      }

      // Drope Item
      public override void Update(GameTime gameTime)
      {
          this.sprPosition.Y++;
          base.Update(gameTime);
      }

  }

  public class BonusItems2 : gBaseClass
  {
      public Vector4 ColorAlpha { get; set; }

      public int velocityY = 1;
      public BonusItems2(Game game, ref Texture2D _sprTexture,
            Vector2 _sprPosition, Rectangle _sprRectangle, int x_c, int y_c)
          : base(game, ref _sprTexture, _sprPosition, _sprRectangle, x_c, y_c)
      {

      }

      // Drope Item
      public override void Update(GameTime gameTime)
      {
          this.sprPosition.Y++;
          base.Update(gameTime);
      }

  }
}
