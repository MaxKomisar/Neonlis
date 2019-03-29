using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Neonlis2game
{
    class Particle
    {
             public Texture2D Texture { get; set; }        // Текстура нашей частички
        public Vector2 Position { get; set; }        // Позиция частички
        public Vector2 Velocity { get; set; }        // Скорость частички
        public float Angle { get; set; }            // Угол поворота частички
        public float AngularVelocity { get; set; }    // Угловая скорость
       // public Vector4 Color { get; set; }            // Цвет частички
        public float Size { get; set; }                // Размеры
        public float SizeVel { get; set; }		// Скорость уменьшения размера
        public float AlphaVel { get; set; }		// Скорость уменьшения альфы
        public int TTL { get; set; }                // Время жизни частички

        public Particle(Texture2D texture, Vector2 position, Vector2 velocity,
            float angle, float angularVelocity, float size, int ttl, float sizeVel, float alphaVel) // конструктор
        {
            Texture = texture;
            Position = position;
            Velocity = velocity;
            Angle = angle;
            //Color = color;
            AngularVelocity = angularVelocity;
            Size = size;
            SizeVel = sizeVel;
            AlphaVel = alphaVel;
            TTL = ttl;
        }

        public void Update() // цикл обновления
        {
            TTL--; // уменьшаем время жизни

            // Меняем параметры в соответствии с скоростями
            Position += Velocity;
            Angle += AngularVelocity;
            Size += SizeVel;

          //  Color = new Vector4(Color.X, Color.Y, Color.Z, Color.W - AlphaVel);
            // убавляем цвет. Кстати, цвет записан в Vector4, а не в Color, потому что: Color.R/G/B имеет тип Byte (от 0x00 до 0xFF), чтобы не проделывать лишней трансформации, используем float и Vector4

        }
        


        public void Draw(SpriteBatch spriteBatch)
        {
            
                Rectangle sourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height); // область из текстуры: вся
                Vector2 origin = new Vector2(Texture.Width / 2, Texture.Height / 2); // центр

             
                    spriteBatch.Draw(Texture,Position, sourceRectangle, Color.White,
                        Angle, origin, Size, SpriteEffects.None, 0); // акт прорисовки
             
        }

    }
}
