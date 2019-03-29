using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Neonlis2game
{
    public class Block
    {
        public Texture2D textureBlock;
        public Rectangle rectangleBlock { get; set; }
        public Color color;
        //public Vector2 positionBlock;
        //int x_pos;
        //int y_pos;

        public Block(Texture2D texture, Rectangle rectangle)//,Vector2 position,int xpos,int ypos)
        {
            textureBlock = texture;
            rectangleBlock = rectangle;
            //positionBlock = position;
            //x_pos = xpos;
            //y_pos = ypos;
        }

        //public void Draw(SpriteBatch spritebatch)
        //{
     
        //    spritebatch.Draw(textureBlock, rectangleBlock, Color.LightSkyBlue);
     
        //}

    }
}
