using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Neonlis2game
{
    public class Ball_bonus : gBaseClass
    {
        //для хранения границ экрана
        public static bool isCollide = false;
        public static bool isCollideB3 = false;
        public static bool isCollideB4 = false;
        public static bool isCollideB5 = false;
        public static bool isCollideB6 = false;
        public static Vector2 cordsPos;
        Rectangle scrBounds;
        //скорость мяча
        public Vector2 speed;
        Random rand = new Random();

        public Ball_bonus(Game game, ref Texture2D _sprTexture,
            Vector2 _sprPosition, Rectangle _sprRectangle, int x_c, int y_c)
            : base(game, ref _sprTexture, _sprPosition, _sprRectangle, x_c, y_c)
        {
            speed = new Vector2(3, -3);
            scrBounds = new Rectangle(16, 0,
              game.Window.ClientBounds.Width - 16,
              game.Window.ClientBounds.Height);
           
        }

        //Проверка на столкновение с границами экрана
        void Check()
        {
            if (sprPosition.X < scrBounds.Left)
            {
                sprPosition.X = scrBounds.Left;
                RandomiseSpeed();
                speed.X *= -1;
            }
            if (sprPosition.X > scrBounds.Width - sprRectangle.Width)
            {
                sprPosition.X = scrBounds.Width - sprRectangle.Width;
                RandomiseSpeed();
                speed.X *= -1;
            }
            if (sprPosition.Y < scrBounds.Top)
            {
                sprPosition.Y = scrBounds.Top;
                RandomiseSpeed();
                speed.Y *= -1;
            }
            if (sprPosition.Y > scrBounds.Height - sprRectangle.Height)
            {
                this.Dispose();
            }

        }

        //Проверка на столкновение с объектом
        bool IsCollideWithObject(gBaseClass spr)
        {
            return (this.sprPosition.X + this.sprRectangle.Width > spr.sprPosition.X &&
                        this.sprPosition.X < spr.sprPosition.X + spr.sprRectangle.Width &&
                        this.sprPosition.Y + this.sprRectangle.Height > spr.sprPosition.Y &&
                        this.sprPosition.Y < spr.sprPosition.Y + spr.sprRectangle.Height);


        }
        //Процедуры случайного изменения скорости при контакте с объектами
        //Для всех объектов - скорость может либо возрасти, либо упасть
        void RandomiseSpeed()
        {
            speed.Y += (float)((rand.NextDouble() - rand.NextDouble()) * 0.4);
            speed.X += (float)((rand.NextDouble() - rand.NextDouble()) * 0.4);
        }
        //Для объектов типа Brick1 скорость лишь растет
        void RandomiseSpeedB1()
        {
            speed.Y += (float)(0.5 * Math.Sign(speed.Y) * Math.Abs(((rand.NextDouble() - rand.NextDouble()))));
            speed.X += (float)(0.5 * Math.Sign(speed.X) * Math.Abs(((rand.NextDouble() - rand.NextDouble()))));
        }
        //Проверка на столкновения
        public void IsCollide()
        {
            gBaseClass FindObj = null;
            Bat FindedBat;
            foreach (gBaseClass spr in Game.Components)
            {
             

                if (IsCollideWithObject(spr))
                {
                    //Если столкнулись с блоком Brick1
                    if (spr.GetType() == (typeof(Brick1)))
                    {
                        isCollide = true;
                        cordsPos.X = this.sprPosition.X;
                        cordsPos.Y = this.sprPosition.Y;
                      
                        // delete object
                        spr.Dispose();
                        spr.sprRectangle = Rectangle.Empty;
                        spr.Visible = false;
                        spr.sprPosition = Vector2.Zero;
                        spr.Enabled = false;
                        
                        //Изменим скорость
                        RandomiseSpeedB1();
                        //Обратим скорость
                        speed *= -1;
                    }
                    if(spr.GetType() == (typeof(Brick3)))
                    {
                        isCollideB3 = true;
                        cordsPos.X = this.sprPosition.X;
                        cordsPos.Y = this.sprPosition.Y;
                        spr.Dispose();
                        spr.sprRectangle = Rectangle.Empty;
                        spr.Visible = false;
                        spr.sprPosition = Vector2.Zero;
                        spr.Enabled = false;

                        //Изменим скорость
                        RandomiseSpeedB1();
                        //Обратим скорость
                        speed *= -1;
                    }
                    if (spr.GetType() == (typeof(Brick4)))
                    {
                        isCollideB4 = true;
                        cordsPos.X = this.sprPosition.X;
                        cordsPos.Y = this.sprPosition.Y;
                        spr.Dispose();
                        spr.sprRectangle = Rectangle.Empty;
                        spr.Visible = false;
                        spr.sprPosition = Vector2.Zero;
                        spr.Enabled = false;

                        //Изменим скорость
                        RandomiseSpeedB1();
                        //Обратим скорость
                        speed *= -1;
                    }
                    if (spr.GetType() == (typeof(Brick5)))
                    {
                        isCollideB5 = true;
                        cordsPos.X = this.sprPosition.X;
                        cordsPos.Y = this.sprPosition.Y;
                        spr.Dispose();
                        spr.sprRectangle = Rectangle.Empty;
                        spr.Visible = false;
                        spr.sprPosition = Vector2.Zero;
                        spr.Enabled = false;

                        //Изменим скорость
                        RandomiseSpeedB1();
                        //Обратим скорость
                        speed *= -1;
                    }
                    if (spr.GetType() == (typeof(Brick6)))
                    {
                        isCollideB6 = true;
                        cordsPos.X = this.sprPosition.X;
                        cordsPos.Y = this.sprPosition.Y;
                        spr.Dispose();
                        spr.sprRectangle = Rectangle.Empty;
                        spr.Visible = false;
                        spr.sprPosition = Vector2.Zero;
                        spr.Enabled = false;

                        //Изменим скорость
                        RandomiseSpeedB1();
                        //Обратим скорость
                        speed *= -1;
                    }
                    //Если столкнулись с блоком 2
                    //обращаем скорость
                    if (spr.GetType() == (typeof(Brick2)))
                    {
                        speed *= -1;
                    }
                    //если столкнулись с битой
                    if (spr.GetType() == (typeof(Bat)))
                    {
                        FindedBat = (Bat)spr;
                        RandomiseSpeed();
                        //Если бита двигалась влево
                        //Мяч отразится от нее влево
                        if (FindedBat.direction)
                        {
                            speed.Y = Math.Abs(speed.Y);
                            speed.X = Math.Abs(speed.X);
                            speed *= -1;
                        }
                        //Если двигалась вправо
                        //отразится вправо
                        else
                        {
                            speed.Y = Math.Abs(speed.Y);
                            speed.X = Math.Abs(speed.X);
                            speed.Y *= -1;
                        }


                    }

                }
            }
            //Если был найден блок Block1
            if (FindObj != null)
            {
                //Уничтожить его
                FindObj.Dispose();
                FindObj = null;
            }

        }

        public override void Update(GameTime gameTime)
        {


            //gameTime.ElapsedGameTime.TotalMilliseconds;

            //Переместить мяч в соответствии со скоростью
            this.sprPosition += this.speed;
            //Ограничить скорость мяча 10 пикселями
            if (speed.Y > 10) speed.Y = (float)10;
            if (speed.Y < -10) speed.Y = (float)-10;
            if (speed.X > 10) speed.X = (float)10;
            if (speed.X < -10) speed.X = (float)-10;
            //Проверить столкновение с границами
            Check();
            //проверить столкновение с объектами
            IsCollide();
            base.Update(gameTime);
        }
    }
}
