using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace Neonlis2game
{
    public class Bat : gBaseClass
    {
        Rectangle scrBounds;
        //True для движения биты влево и False - вправо
        public bool direction;
        Texture2D tex;
        public static bool getItem = false;
        public static bool getItem1 = false;
        public static bool getItem2 = false;
        public Bat(Game game, ref Texture2D _sprTexture,
            Vector2 _sprPosition, Rectangle _sprRectangle, int x_c, int y_c)
            : base(game, ref _sprTexture, _sprPosition, _sprRectangle, x_c, y_c)
        {
            scrBounds = new Rectangle(16, 0,
              game.Window.ClientBounds.Width - 16,
              game.Window.ClientBounds.Height);
            tex =  this.sprTexture;
            direction = true;
        }

        int currentTimeLife = 0;
        public override void Update(GameTime gameTime)
        {
           // RemoveBallBonus();

           /////
            currentTimeLife += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
           
            List<Ball_bonus> balls = Game.Components.OfType<Ball_bonus>().ToList();

            foreach (Ball_bonus ball in balls)
            {
                if (currentTimeLife >= 10000)
                {
                    Game.Components.Remove(ball);
                    if (currentTimeLife > 10000)
                        currentTimeLife = 0;
                }
            }




            gBaseClass FindObj = null;

            foreach (gBaseClass spr in Game.Components)
            {
                if (IsCollideWithObject(spr))
                {
                    //Если столкнулись с блоком Brick1
                    if (spr.GetType() == (typeof(BonusItems)))
                    {
                        spr.Dispose();
                        spr.sprRectangle = Rectangle.Empty;
                        spr.Visible = false;
                        spr.sprPosition = Vector2.Zero;
                        spr.Enabled = false;
                        getItem = true;

                    }
                    if (spr.GetType() == (typeof(BonusItems1)))
                    {
                        spr.Dispose();
                        spr.sprRectangle = Rectangle.Empty;
                        spr.Visible = false;
                        spr.sprPosition = Vector2.Zero;
                        spr.Enabled = false;
                        getItem1 = true;

                    }
                    if (spr.GetType() == (typeof(BonusItems2)))
                    {
                        spr.Dispose();
                        spr.sprRectangle = Rectangle.Empty;
                        spr.Visible = false;
                        spr.sprPosition = Vector2.Zero;
                        spr.Enabled = false;
                        getItem2 = true;
                        
                    }
                }

            }
            if (FindObj != null)
            {
                //Уничтожить его
                FindObj.Dispose();
                FindObj = null;
            }



            TouchCollection touchLocations = TouchPanel.GetState();
            foreach (TouchLocation touchLocation in touchLocations)
            {
                //При касании экрана или при перемещении
                if (touchLocation.State == TouchLocationState.Pressed || touchLocation.State == TouchLocationState.Moved)
                {
                    //Узнаем направление движения объекта
                    if (sprPosition.X + 48 < touchLocation.Position.X)
                    {
                        direction = false;
                    }
                    else
                    {
                        direction = true;
                    }
                    sprPosition.X = touchLocation.Position.X - 48;
                    //if (touchLocation.Position.X > 0 && touchLocation.Position.X < 100)
                    //{
                    //    this.sprPosition.X -= 8;
                    //    direction = false;

                    //}
                    //if (touchLocation.Position.X > 700 && touchLocation.Position.X < 800)
                    //{
                    //    this.sprPosition.X += 8;
                    //    direction = true;
                    //}
                }
                //if (touchLocation.State == TouchLocationState.Pressed)
                //{
                   
                    
                 
                //}
                    //Установим объект, по оси Х, таким образом, чтобы
                //    //точка касания приходилась на середину объекта
                //    

                //}
             
            }
            KeyboardState keyState = Keyboard.GetState();

            if(keyState.IsKeyDown(Keys.A))
            {
                this.sprPosition.X -= 8;
                direction = true;
            }
            if(keyState.IsKeyDown(Keys.S))
            { 
                this.sprPosition.X += 8;
                direction = false;
            }
            //проверка на столкновение с границами экрана

            Check();

            base.Update(gameTime);
        }
        //Процедура проверки столкновения с левой
        //и правой границами экрана
        void Check()
        {
            if (sprPosition.X < scrBounds.Left)
            {
                sprPosition.X = scrBounds.Left;

            }
            if (sprPosition.X > scrBounds.Width - sprRectangle.Width)
            {
                sprPosition.X = scrBounds.Width - sprRectangle.Width;

            }


            
        }


        bool IsCollideWithObject(gBaseClass spr)
        {
            return (this.sprPosition.X + this.sprRectangle.Width > spr.sprPosition.X &&
                        this.sprPosition.X < spr.sprPosition.X + spr.sprRectangle.Width &&
                        this.sprPosition.Y + this.sprRectangle.Height > spr.sprPosition.Y &&
                        this.sprPosition.Y < spr.sprPosition.Y + spr.sprRectangle.Height);
        }
        
   

    }
}
