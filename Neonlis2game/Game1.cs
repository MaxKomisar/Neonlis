using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Neonlis2game.Menu_System;
using Windows.Storage;
using Microsoft.Xna.Framework.Input.Touch;
using Windows.ApplicationModel.Store;
using Windows.Phone.UI.Input;


namespace Neonlis2game
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

      


        Vector2 startButtonPosWXGA = new Vector2(300, 500);
        Rectangle startBattonRectWXGA;

        Vector2 menuPos = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.TitleSafeArea.Bottom,GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.TitleSafeArea.Center.X + 150);
        
        Vector2 menuPos1 = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.TitleSafeArea.Bottom, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.TitleSafeArea.Center.X + 100);
        
        Vector2 menuPos2 = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.TitleSafeArea.Bottom, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.TitleSafeArea.Center.X + 200);



        int Height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        //=== >> GAME PARAMS << ===
        bool isBatBollCreate = false;
        bool isBlocksCreate = false;
        Random rand;
        ParticleController particleSystem;
        BonusItems bonusItem;
        //Прямоугольник для фона
        Rectangle recBack = new Rectangle(0, 0, 480, 800);
        //Прямоугольник для "блока"
        Rectangle recBrick = new Rectangle(0, 0, 70, 50);
        //Прямоугольник для "мяча"
        Rectangle recBall = new Rectangle(0, 0, 10, 10);
        //Прямоугольник для биты
        Rectangle recBat = new Rectangle(0,GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 35, 200, 10);

        Rectangle recPart = new Rectangle(0, 0, 20, 20);
        // Timer 
        int timerCount;
        int VelocityY;
        // == >> END GAME PARAMS << ==
        //   ================
        //  ===+++============
        //   =+++++====+++++=
        //    =+++==[]======
        //     =====][=====
        //      ==========
        //      [][][][][]
        //      ==========
        //       ========
        // all right reserved Max Komisar ENERGO BOSS studio 2016
       
        public int ScrrenWidth { get; set; }
        public int ScreenHeight { get; set; }
      

        GameState gameState;
        SkinBat selectBatSkin;
        BuyMess buyMessage;
        LockChose stateItem;
        SkinBoll selectBollSkin;

        Random randomColor = new Random();
       
        Rectangle RecBackground;
        Scrolling Background1;
        Scrolling Background2;
      
      
        SoundEffect explosionSoundEffect;
        SoundEffect collisionSoundEffect;
       
        Rectangle hScoreRect;
      
        public static int Score = 0;
        float time = 1;
        int Level = 1;
        int Lifes = 3;
        int currentLevel = 0;
        int HScore = 200;
        ApplicationDataContainer ScoreHigh = ApplicationData.Current.LocalSettings;
        ApplicationDataContainer Neoin = ApplicationData.Current.LocalSettings;
        // Control store storage
        ApplicationDataContainer buyItem_1 = ApplicationData.Current.LocalSettings;
        ApplicationDataContainer buyItem_2 = ApplicationData.Current.LocalSettings;
        ApplicationDataContainer buyItem_3 = ApplicationData.Current.LocalSettings;
        ApplicationDataContainer buyItem_4 = ApplicationData.Current.LocalSettings;
        ApplicationDataContainer buyItem_5 = ApplicationData.Current.LocalSettings;
        ApplicationDataContainer item_Chose = ApplicationData.Current.LocalSettings;
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
     
        Rectangle defaultBollRect = new Rectangle(405,220,200,150);
        Rectangle defaultBatRect = new Rectangle(600, 220, 200, 150);
        Rectangle buyNeonRect = new Rectangle(600, 65, 200, 150);
        Rectangle buyBatRect_1 = new Rectangle(5,65,200,150);
        Rectangle buyBatRect_2 = new Rectangle(205,65,200,150);
        Rectangle buyBatRect_3 = new Rectangle(405,65,200,150);
        Rectangle buyBollrect_1 = new Rectangle(5,220,200,150);
        Rectangle buyBollRect_2 = new Rectangle(205,220,200,150);

        Vector2 startGameVect = new Vector2(300,100);
        int neon;


        // Skin BAT & BOLL player
      

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            ScreenHeight = graphics.PreferredBackBufferHeight;
            ScrrenWidth = graphics.PreferredBackBufferWidth;
        }

        protected void InitializeSave()
        {
            Object neonCoin = Neoin.Values["kwdiu23n9f0"];
            Object valueBuyitemSave_1 = buyItem_1.Values["item_1"];
            Object valueBuyitemSave_2 = buyItem_2.Values["item_2"];
            Object valueBuyitemSave_3 = buyItem_3.Values["item_3"];
            Object valueBuyitemSave_4 = buyItem_4.Values["item_4"];
            Object valueBuyitemSave_5 = buyItem_5.Values["item_5"];
            object valueCheckItem = item_Chose.Values["item_1_check"];
            object valueCheckItem2 = item_Chose.Values["item_2_check"];
            object valueCheckItem3 = item_Chose.Values["item_3_check"];
            object valueCheckItem4 = item_Chose.Values["item_4_check"];
            object valueCheckItem5 = item_Chose.Values["item_5_check"];
            object valueCheckItem6 = item_Chose.Values["defBat"];
            object valueCheckItem7 = item_Chose.Values["defBoll"];
            Object value = localSettings.Values["exampleSetting"];

            if (neonCoin == null) { Neoin.Values["kwdiu23n9f0"] = 0; }
            if (value == null) { localSettings.Values["exampleSetting"] = 0;}
            if (valueBuyitemSave_1 == null){buyItem_1.Values["item_1"] = 0;}
            if (valueBuyitemSave_2 == null){buyItem_2.Values["item_2"] = 0;}
            if (valueBuyitemSave_3 == null){buyItem_3.Values["item_3"] = 0;}
            if (valueBuyitemSave_4 == null){buyItem_4.Values["item_4"] = 0;}
            if (valueBuyitemSave_5 == null){buyItem_5.Values["item_5"] = 0;}

            if (valueCheckItem == null) { item_Chose.Values["item_1_check"] = 0; }
            if (valueCheckItem2 == null) { item_Chose.Values["item_2_check"] = 0; }
            if (valueCheckItem3 == null) { item_Chose.Values["item_3_check"] = 0; }
            if (valueCheckItem4 == null) { item_Chose.Values["item_4_check"] = 0; }
            if (valueCheckItem5 == null) { item_Chose.Values["item_5_check"] = 0; }
            if (valueCheckItem6 == null) { item_Chose.Values["defBat"] = 1; }
            if (valueCheckItem7 == null) { item_Chose.Values["defBoll"] = 1; }
        }

        protected override void Initialize()
        {
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft;
            InitializeSave();
          startBattonRectWXGA  = new Rectangle(300,500,200,100);
            particleSystem = new ParticleController();
            rand = new Random();
            Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            base.Initialize();
        }

        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            if(e.Handled == true)
            {
             gameState = GameState.store;
                
            }
        }

        protected void Save()
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            localSettings.Values.Remove("exampleSetting");
            localSettings.Values["exampleSetting"] = Score;
        }
        protected void Load()
        {
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Object value = localSettings.Values["exampleSetting"];
            //  testScore = value.ToString();
        }
      
       public void AddSprites(byte[,] RenderLayer)
        {

            if (isBlocksCreate == false)
            {
                if (GraphicsDevice.Viewport.Width == 800 && GraphicsDevice.Viewport.Height == 480)
                {

                    for (int i = 0; i < 13; i++)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            if (RenderLayer[i, j] == 1)
                                Components.Add(new Brick1(this, ref LoadClass.txtBrick1, new Vector2(j, i + 2), recBrick, 64, 16));
                            if (RenderLayer[i, j] == 2)
                                Components.Add(new Brick6(this, ref LoadClass.texturebrick6, new Vector2(j, i + 2), recBrick, 64, 16));
                            if (RenderLayer[i, j] == 3)
                                Components.Add(new Brick3(this, ref LoadClass.textureBrick3, new Vector2(j, i + 2), recBrick, 64, 16));
                            if (RenderLayer[i, j] == 4)
                                Components.Add(new Brick4(this, ref LoadClass.textureBrick4, new Vector2(j, i + 2), recBrick, 64, 16));
                            if (RenderLayer[i, j] == 5)
                                Components.Add(new Brick5(this, ref LoadClass.textureBrick5, new Vector2(j, i + 2), recBrick, 64, 16));
                            // Brick2 not destroy
                        }
                    }
                    isBlocksCreate = true;
                }
                else if (GraphicsDevice.Viewport.Width == 1280 && GraphicsDevice.Viewport.Height == 768)
                {

                    for (int i = 0; i < 13; i++)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            if (RenderLayer[i, j] == 1)
                                Components.Add(new Brick1(this, ref LoadClass.txtBrick1, new Vector2(j + 4, i + 6), recBrick, 64, 16));
                            if (RenderLayer[i, j] == 2)
                                Components.Add(new Brick6(this, ref LoadClass.texturebrick6, new Vector2(j + 4, i + 6), recBrick, 64, 16));
                            if (RenderLayer[i, j] == 3)
                                Components.Add(new Brick3(this, ref LoadClass.textureBrick3, new Vector2(j + 4, i + 6), recBrick, 64, 16));
                            if (RenderLayer[i, j] == 4)
                                Components.Add(new Brick4(this, ref LoadClass.textureBrick4, new Vector2(j + 4, i + 6), recBrick, 64, 16));
                            if (RenderLayer[i, j] == 5)
                                Components.Add(new Brick5(this, ref LoadClass.textureBrick5, new Vector2(j + 4, i + 6), recBrick, 64, 16));
                            // Brick2 not destroy
                        }
                    }
                    isBlocksCreate = true; 
                }
                else if (GraphicsDevice.Viewport.Width == 1280 && GraphicsDevice.Viewport.Height == 720)
                {


                    for (int i = 0; i < 13; i++)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            if (RenderLayer[i, j] == 1)
                                Components.Add(new Brick1(this, ref LoadClass.txtBrick1, new Vector2(j + 4, i + 6), recBrick, 64, 16));
                            if (RenderLayer[i, j] == 2)
                                Components.Add(new Brick6(this, ref LoadClass.texturebrick6, new Vector2(j + 4, i + 6), recBrick, 64, 16));
                            if (RenderLayer[i, j] == 3)
                                Components.Add(new Brick3(this, ref LoadClass.textureBrick3, new Vector2(j + 4, i + 6), recBrick, 64, 16));
                            if (RenderLayer[i, j] == 4)
                                Components.Add(new Brick4(this, ref LoadClass.textureBrick4, new Vector2(j + 4, i + 6), recBrick, 64, 16));
                            if (RenderLayer[i, j] == 5)
                                Components.Add(new Brick5(this, ref LoadClass.textureBrick5, new Vector2(j + 4, i + 6), recBrick, 64, 16));
                            // Brick2 not destroy
                        }
                    }
                    isBlocksCreate = true; 


                }
                else if (GraphicsDevice.Viewport.Width == 1920 && GraphicsDevice.Viewport.Height == 1080)
                {

                    for (int i = 0; i < 13; i++)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            if (RenderLayer[i, j] == 1)
                                Components.Add(new Brick1(this, ref LoadClass.txtBrick1, new Vector2(j + 9, i + 9), recBrick, 64, 16));
                            if (RenderLayer[i, j] == 2)
                                Components.Add(new Brick6(this, ref LoadClass.texturebrick6, new Vector2(j + 9, i + 9), recBrick, 64, 16));
                            if (RenderLayer[i, j] == 3)
                                Components.Add(new Brick3(this, ref LoadClass.textureBrick3, new Vector2(j + 9, i + 9), recBrick, 64, 16));
                            if (RenderLayer[i, j] == 4)
                                Components.Add(new Brick4(this, ref LoadClass.textureBrick4, new Vector2(j + 9, i + 9), recBrick, 64, 16));
                            if (RenderLayer[i, j] == 5)
                                Components.Add(new Brick5(this, ref LoadClass.textureBrick5, new Vector2(j + 9, i + 9), recBrick, 64, 16));
                            // Brick2 not destroy
                        }
                    }
                    isBlocksCreate = true; 
                }
            }
            else
            {}
        }

        void addBallAndBAts()
        {
            if (isBatBollCreate == false)
            {
                Components.Add(new Ball(this, ref LoadClass.skinBollTexture, new Vector2(550, 360), recBall, 1, 1));
                Components.Add(new Bat(this, ref LoadClass.skinTexture, new Vector2(300, GraphicsDevice.Viewport.Height - 60), recBat, 1, 1));
                isBatBollCreate = true;
            }else
            {
                
            }
        }

        /// <summary>
        /// Load files for you game;
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
           
            Services.AddService(typeof(SpriteBatch), spriteBatch);
            LoadClass.LoadContentAsistens(Content);
            Background1 = new Scrolling(Content.Load<Texture2D>("Background1"), new Rectangle(0, 0, ScrrenWidth, ScreenHeight));
            Background2 = new Scrolling(Content.Load<Texture2D>("Background1"), new Rectangle(ScrrenWidth, 0, ScrrenWidth, ScreenHeight));
            explosionSoundEffect = Content.Load<SoundEffect>("Explosion13");
            MediaPlayer.Play(LoadClass.gameBackgroundSong);
            MediaPlayer.IsRepeating = true;
           
        }
        protected override void UnloadContent()
        {
            Content.Unload();
        }
        protected override void Update(GameTime gameTime)
        {
            
            TouchCollection touchLocations = TouchPanel.GetState();
            if (gameState == GameState.Menu)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                { Exit(); }
            }else if(gameState == GameState.store)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                { gameState = GameState.Menu; }
            }
            else if (gameState == GameState.HighScore)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                { gameState = GameState.Menu; }
            }
            else if (gameState == GameState.Game)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                { gameState = GameState.Menu; }

            }
            else if (gameState == GameState.about)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                { gameState = GameState.Menu; }
            }

            foreach (TouchLocation touchLocation in touchLocations)
            {
                if (gameState == GameState.Menu)
                {
                    GamePadState padState = GamePad.GetState(PlayerIndex.One);
                    if (padState.Buttons.Back == ButtonState.Pressed)
                    {
                        gameState = GameState.Game;
                    }
            
                if (GraphicsDevice.Viewport.Width == 800 && GraphicsDevice.Viewport.Height == 480)
                {

                    if (touchLocation.Position.Y > 300 && touchLocation.Position.Y < 350 && touchLocation.Position.X > 350 && touchLocation.Position.X < 500)
                    {
                        gameState = GameState.Game;
                        switch (selectBollSkin)
                        {
                            case SkinBoll.Origin:
                                LoadClass.skinBollTexture = LoadClass.txtBall;
                                break;
                            case SkinBoll.RedStar:
                                LoadClass.skinBollTexture = LoadClass.bollRedStar;
                                break;
                            case SkinBoll.YellowBable:
                                LoadClass.skinBollTexture = LoadClass.bollYellowBable;
                                break;
                        }
                        switch (selectBatSkin)
                        {
                            case SkinBat.Origin:
                                LoadClass.skinTexture = LoadClass.txtBat;
                                break;
                            case SkinBat.RedSun:
                                LoadClass.skinTexture = LoadClass.batRedSun;
                                break;
                            case SkinBat.MegaGreen:
                                LoadClass.skinTexture = LoadClass.batMegaGreen;
                                break;
                            case SkinBat.FastYellow:
                                LoadClass.skinTexture = LoadClass.batFastYellow;
                                break;
                        }
                        RecBackground = new Rectangle(0, 0, ScrrenWidth, ScreenHeight);
                    }
                    else if (touchLocation.Position.Y > 360 && touchLocation.Position.Y < 400 && touchLocation.Position.X > 350 && touchLocation.Position.X < 500)
                    {
                        gameState = GameState.HighScore;
                    }
                    else if (touchLocation.Position.Y > 410 && touchLocation.Position.Y < 480 && touchLocation.Position.X > 740 && touchLocation.Position.X < 800)
                    { gameState = GameState.about; }
                    else
                        if (touchLocation.Position.Y >= 410 && touchLocation.Position.Y <= 480 && touchLocation.Position.X >= 350 && touchLocation.Position.X <= 500)
                        {
                            gameState = GameState.store;
                        }
                }
                else if (GraphicsDevice.Viewport.Width == 1280 && GraphicsDevice.Viewport.Height == 768)
                {
                    if (touchLocation.Position.Y > 200 && touchLocation.Position.Y < 400 && touchLocation.Position.X > 500 && touchLocation.Position.X < 700)
                    {
                        gameState = GameState.Game;
                        switch (selectBollSkin)
                        {
                            case SkinBoll.Origin:
                                LoadClass.skinBollTexture = LoadClass.txtBall;
                                break;
                            case SkinBoll.RedStar:
                                LoadClass.skinBollTexture = LoadClass.bollRedStar;
                                break;
                            case SkinBoll.YellowBable:
                                LoadClass.skinBollTexture = LoadClass.bollYellowBable;
                                break;
                        }
                        switch (selectBatSkin)
                        {
                            case SkinBat.Origin:
                                LoadClass.skinTexture = LoadClass.txtBat;
                                break;
                            case SkinBat.RedSun:
                                LoadClass.skinTexture = LoadClass.batRedSun;
                                break;
                            case SkinBat.MegaGreen:
                                LoadClass.skinTexture = LoadClass.batMegaGreen;
                                break;
                            case SkinBat.FastYellow:
                                LoadClass.skinTexture = LoadClass.batFastYellow;
                                break;
                        }
                        RecBackground = new Rectangle(0, 0, ScrrenWidth, ScreenHeight);
                    }
                    else if (touchLocation.Position.Y > 450 && touchLocation.Position.Y < 550 && touchLocation.Position.X > 500 && touchLocation.Position.X < 700)
                    {
                        gameState = GameState.HighScore;
                    }
                    else

                        if (touchLocation.Position.Y > 600 && touchLocation.Position.Y < 768 && touchLocation.Position.X > 1000 && touchLocation.Position.X < 1280)

                        { gameState = GameState.about; }
                        else

                            if (touchLocation.Position.Y >= 500 && touchLocation.Position.Y <= 700 && touchLocation.Position.X >= 500 && touchLocation.Position.X <= 700)
                            {
                                gameState = GameState.store;
                            }



                    if (gameState == GameState.about)
                    {
                        if (touchLocation.Position.Y > 600 && touchLocation.Position.Y < 768 && touchLocation.Position.X > 0 && touchLocation.Position.X < 400)
                        {
                            gameState = GameState.Menu;
                        }
                    }
                    if (gameState == GameState.HighScore)
                    {
                        if (touchLocation.Position.Y > 600 && touchLocation.Position.Y < 768 && touchLocation.Position.X > 0 && touchLocation.Position.X < 400)
                        {
                            gameState = GameState.Menu;
                        }

                    }
                    if (gameState == GameState.store)
                    {
                        if (touchLocation.Position.Y > 600 && touchLocation.Position.Y < 768 && touchLocation.Position.X > 0 && touchLocation.Position.X < 400)
                        {
                            gameState = GameState.Menu;
                        }

                    }
                }
                else if (GraphicsDevice.Viewport.Width == 1280 && GraphicsDevice.Viewport.Height == 720)
                {

                    if (touchLocation.Position.Y > 200 && touchLocation.Position.Y < 400 && touchLocation.Position.X > 500 && touchLocation.Position.X < 700)
                    {
                        gameState = GameState.Game;
                        switch (selectBollSkin)
                        {
                            case SkinBoll.Origin:
                                LoadClass.skinBollTexture = LoadClass.txtBall;
                                break;
                            case SkinBoll.RedStar:
                                LoadClass.skinBollTexture = LoadClass.bollRedStar;
                                break;
                            case SkinBoll.YellowBable:
                                LoadClass.skinBollTexture = LoadClass.bollYellowBable;
                                break;
                        }
                        switch (selectBatSkin)
                        {
                            case SkinBat.Origin:
                                LoadClass.skinTexture = LoadClass.txtBat;
                                break;
                            case SkinBat.RedSun:
                                LoadClass.skinTexture = LoadClass.batRedSun;
                                break;
                            case SkinBat.MegaGreen:
                                LoadClass.skinTexture = LoadClass.batMegaGreen;
                                break;
                            case SkinBat.FastYellow:
                                LoadClass.skinTexture = LoadClass.batFastYellow;
                                break;
                        }
                        RecBackground = new Rectangle(0, 0, ScrrenWidth, ScreenHeight);
                    }
                    else if (touchLocation.Position.Y > 450 && touchLocation.Position.Y < 550 && touchLocation.Position.X > 500 && touchLocation.Position.X < 700)
                    {
                        gameState = GameState.HighScore;
                    }
                    else

                        if (touchLocation.Position.Y > 600 && touchLocation.Position.Y < 768 && touchLocation.Position.X > 1000 && touchLocation.Position.X < 1280)

                        { gameState = GameState.about; }
                        else

                            if (touchLocation.Position.Y >= 500 && touchLocation.Position.Y <= 700 && touchLocation.Position.X >= 500 && touchLocation.Position.X <= 700)
                            {
                                gameState = GameState.store;
                            }



                    if (gameState == GameState.about)
                    {
                        if (touchLocation.Position.Y > 600 && touchLocation.Position.Y < 768 && touchLocation.Position.X > 0 && touchLocation.Position.X < 400)
                        {
                            gameState = GameState.Menu;
                        }
                    }
                    if (gameState == GameState.HighScore)
                    {
                        if (touchLocation.Position.Y > 600 && touchLocation.Position.Y < 768 && touchLocation.Position.X > 0 && touchLocation.Position.X < 400)
                        {
                            gameState = GameState.Menu;
                        }

                    }
                    if (gameState == GameState.store)
                    {
                        if (touchLocation.Position.Y > 600 && touchLocation.Position.Y < 768 && touchLocation.Position.X > 0 && touchLocation.Position.X < 400)
                        {
                            gameState = GameState.Menu;
                        }

                    }
                }
                else if (GraphicsDevice.Viewport.Width == 1920 && GraphicsDevice.Viewport.Height == 1080)
                {

                    if (touchLocation.Position.Y > 200 && touchLocation.Position.Y < 660 && touchLocation.Position.X > 700 && touchLocation.Position.X < 1100)
                    {
                        gameState = GameState.Game;
                        switch (selectBollSkin)
                        {
                            case SkinBoll.Origin:
                                LoadClass.skinBollTexture = LoadClass.txtBall;
                                break;
                            case SkinBoll.RedStar:
                                LoadClass.skinBollTexture = LoadClass.bollRedStar;
                                break;
                            case SkinBoll.YellowBable:
                                LoadClass.skinBollTexture = LoadClass.bollYellowBable;
                                break;
                        }
                        switch (selectBatSkin)
                        {
                            case SkinBat.Origin:
                                LoadClass.skinTexture = LoadClass.txtBat;
                                break;
                            case SkinBat.RedSun:
                                LoadClass.skinTexture = LoadClass.batRedSun;
                                break;
                            case SkinBat.MegaGreen:
                                LoadClass.skinTexture = LoadClass.batMegaGreen;
                                break;
                            case SkinBat.FastYellow:
                                LoadClass.skinTexture = LoadClass.batFastYellow;
                                break;
                        }
                        RecBackground = new Rectangle(0, 0, ScrrenWidth, ScreenHeight);
                    }
                    else if (touchLocation.Position.Y > 550 && touchLocation.Position.Y < 650 && touchLocation.Position.X > 700 && touchLocation.Position.X < 1100)
                    {
                        gameState = GameState.HighScore;
                    }
                    else
                        
                        if (touchLocation.Position.Y > 700 && touchLocation.Position.Y < 850 && touchLocation.Position.X > 1800 && touchLocation.Position.X < 1920)
                    { gameState = GameState.about; }
                    else

                        if (touchLocation.Position.Y >= 900 && touchLocation.Position.Y <= 1080 && touchLocation.Position.X >= 750 && touchLocation.Position.X <= 1100)
                        {
                            gameState = GameState.store;
                        }



                    if (gameState == GameState.about)
                    {
                        if (touchLocation.Position.Y > 700 && touchLocation.Position.Y < 1080 && touchLocation.Position.X > 0 && touchLocation.Position.X < 400)
                        {
                            gameState = GameState.Menu;
                        }
                    }
                    if (gameState == GameState.HighScore)
                    {
                        if (touchLocation.Position.Y > 700 && touchLocation.Position.Y < 1080 && touchLocation.Position.X > 0 && touchLocation.Position.X < 400)
                        {
                            gameState = GameState.Menu;
                        }

                    }
                    if (gameState == GameState.store)
                    {
                        if (touchLocation.Position.Y > 700 && touchLocation.Position.Y < 1080 && touchLocation.Position.X > 0 && touchLocation.Position.X < 400)
                        {
                            gameState = GameState.Menu;
                        }

                    }

                }




                 
                }

               
                if (gameState == GameState.about)
                {
                    if (touchLocation.Position.Y > 400 && touchLocation.Position.Y < 480 && touchLocation.Position.X > 0 && touchLocation.Position.X < 100 )
                    {
                        gameState = GameState.Menu;
                        
                    }
                }
                if (gameState == GameState.HighScore)
                {
                    if (touchLocation.Position.Y > 400 && touchLocation.Position.Y < 480 && touchLocation.Position.X > 0 && touchLocation.Position.X < 100)
                    {
                        gameState = GameState.Menu;
                    }

                    if (touchLocation.Position.X >= LoadClass.backButton.Bounds.X && touchLocation.Position.Y >= LoadClass.backButton.Bounds.Y)
                    {
                        gameState = GameState.Menu;
                    }
                }


                ///////// BEGIN STORE LOGIC /////////////////////////////////////////////////////////////////
                if (gameState == GameState.store)
                {StoreControlSystem();}
                ////// END STORE LOGIC /////////////////////////////////////////////////////////////////////////////
                if (gameState == GameState.Game_Over)
                {}

            }

            if(gameState == GameState.Game)
                {
                    
                    VelocityY--;
                    particleSystem.Update(gameTime);

                    Object value = localSettings.Values["exampleSetting"];
                    int HScore = (int)value;
                if(Score <= HScore)
                {
                    localSettings.Values["exampleSetting"] = Score;
                }



                    
                time -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if(time <= 0)
                    {
                    isBlocksCreate = false;
                    isBatBollCreate = false;

                    currentLevel++;
                    Level++;
                    if (currentLevel < 71)
                        addLevel(currentLevel);
                    if (currentLevel == 71)
                    {
                        currentLevel = 1;
                        addLevel(currentLevel);
                    }
                   
                    if (currentLevel >= 2)
                    {
                        neon += 20;
                        Neoin.Values["kwdiu23n9f0"] = neon;
                    }
                    
                    addBallAndBAts();
                    time = 20000f *  ((float)currentLevel * 0.9f);
                    }



                    //addBallAndBAts();
                    if (Bat.getItem == true)
                    {
                        Components.Add(new Ball_bonus(this, ref LoadClass.txtBall, new Vector2(Ball.cordsPos.X + 50, Ball.cordsPos.Y + 40), recBall, 1, 1));
                        Components.Add(new Ball_bonus(this, ref LoadClass.txtBall, new Vector2(Ball.cordsPos.X + 10, Ball.cordsPos.Y + 20), recBall, 1, 1));
                        Bat.getItem = false;}
                    if (Ball.isCollide == true)
                    {
                        particleSystem.EngineRocket(new Vector2(Ball.cordsPos.X, Ball.cordsPos.Y), LoadClass.particleUnityYellow);
                        if (rand.Next(1, 12) == 1)
                        {
                            Components.Add(new BonusItems(this, ref LoadClass.textureBonusTriangle, new Vector2(Ball.cordsPos.X, Ball.cordsPos.Y), recBall, 1, 1));
                        }
                        Ball.isCollide = false; }
                    if (Ball.isCollideB3 == true)
                    {
                        particleSystem.EngineRocket(new Vector2(Ball.cordsPos.X, Ball.cordsPos.Y), LoadClass.particleUnityGreen);
                        if (rand.Next(1, 12) == 1)
                        {
                            Components.Add(new BonusItems(this, ref LoadClass.textureBonusTriangle, new Vector2(Ball.cordsPos.X, Ball.cordsPos.Y), recBall, 1, 1));
                        }
                        Ball.isCollideB3 = false;
                    }
                    if (Ball.isCollideB4 == true)
                    {
                        particleSystem.EngineRocket(new Vector2(Ball.cordsPos.X, Ball.cordsPos.Y), LoadClass.particleUnityViolet);
                        if (rand.Next(1, 12) == 1)
                        {
                            Components.Add(new BonusItems(this, ref LoadClass.textureBonusTriangle, new Vector2(Ball.cordsPos.X, Ball.cordsPos.Y), recBall, 1, 1));
                        }
                        Ball.isCollideB4 = false;
                    }
                    if (Ball.isCollideB5 == true)
                    {
                        particleSystem.EngineRocket(new Vector2(Ball.cordsPos.X, Ball.cordsPos.Y), LoadClass.particleunityOrange);
                        if (rand.Next(1, 12) == 1)
                        {
                            Components.Add(new BonusItems(this, ref LoadClass.textureBonusTriangle, new Vector2(Ball.cordsPos.X, Ball.cordsPos.Y), recBall, 1, 1));
                        }
                        Ball.isCollideB5 = false;}
                    if (Ball.isCollideB6 == true)
                    {
                        particleSystem.EngineRocket(new Vector2(Ball.cordsPos.X, Ball.cordsPos.Y), LoadClass.particleUnityBlue);
                        if (rand.Next(1, 12) == 1)
                        {
                            Components.Add(new BonusItems(this, ref LoadClass.textureBonusTriangle, new Vector2(Ball.cordsPos.X, Ball.cordsPos.Y), recBall, 1, 1));
                        }
                        Ball.isCollideB6 = false;}

                    base.Update(gameTime);

                
                }
           
        }


        internal async void BuyNeon()
        {
            try
            {
                PurchaseResults purchaseResults = await CurrentApp.RequestProductPurchaseAsync("10000 neoin");
                if(purchaseResults.Status == ProductPurchaseStatus.Succeeded)
                {
                    ///////////////////get 10000 neoin;
                    int currentNeon = 10000;
                    neon = neon + currentNeon;
                    Neoin.Values["kwdiu23n9f0"] = neon;
                }
            }
            catch (Exception)
            {
                //Log("Unable to buy Product 1.", NotifyType.ErrorMessage);
            }
        }
        internal void addLevel(int currentLvl)
        {
            Components.Clear();
           
            switch (currentLvl)
            {
                case 1:
                    AddSprites(LevelList.Level1);
                    break;
                case 2:
                    AddSprites(LevelList.Level2);
                    break;
                case 3:
                    AddSprites(LevelList.Level3);
                    break;
                case 4:
                    AddSprites(LevelList.Level4);
                    break;
                case 5:
                    AddSprites(LevelList.Level5);
                    break;
                case 6:
                    AddSprites(LevelList.Level6);
                    break;
                case 7:
                    AddSprites(LevelList.Level7);
                    break;
                case 8:
                    AddSprites(LevelList.Level8);
                    break;
                case 9:
                    AddSprites(LevelList.Level9);
                    break;
                case 10:
                    AddSprites(LevelList.Level10);
                    break;
                case 11:
                    AddSprites(LevelList.Level11);
                    break;
                case 12:
                    AddSprites(LevelList.Level12);
                    break;
                case 13:
                    AddSprites(LevelList.Level13);
                    break;
                case 14:
                    AddSprites(LevelList.Level14);
                    break;
                case 15:
                    AddSprites(LevelList.Level15);
                    break;
                case 16:
                    AddSprites(LevelList.Level16);
                    break;
                case 17:
                    AddSprites(LevelList.Level17);
                    break;
                case 18:
                    AddSprites(LevelList.Level18);
                    break;
                case 19:
                    AddSprites(LevelList.Level19);
                    break;
                case 20:
                    AddSprites(LevelList.Level20);
                    break;
                case 21:
                    AddSprites(LevelList.Level21);
                    break;
                case 22:
                    AddSprites(LevelList.Level22);
                    break;
                case 23:
                    AddSprites(LevelList.Level23);
                    break;
                case 24:
                    AddSprites(LevelList.Level24);
                    break;
                case 25:
                    AddSprites(LevelList.Level25);
                    break;
                case 26:
                    AddSprites(LevelList.Level26);
                    break;
                case 27:
                    AddSprites(LevelList.Level27);
                    break;
                case 28:
                    AddSprites(LevelList.Level28);
                    break;
                case 29:
                    AddSprites(LevelList.Level29);
                    break;
                case 30:
                    AddSprites(LevelList.Level30);
                    break;
                case 31:
                    AddSprites(LevelList.Level31);
                    break;
                case 32:
                    AddSprites(LevelList.Level32);
                    break;
                case 33:
                    AddSprites(LevelList.Level33);
                    break;
                case 34:
                    AddSprites(LevelList.Level34);
                    break;
                case 35:
                    AddSprites(LevelList.Level35);
                    break;
                case 36:
                    AddSprites(LevelList.Level36);
                    break;
                case 37:
                    AddSprites(LevelList.Level37);
                    break;
                case 38:
                    AddSprites(LevelList.Level38);
                    break;
                case 39:
                    AddSprites(LevelList.Level39);
                    break;
                case 40:
                    AddSprites(LevelList.Level40);
                    break;
                case 41:
                    AddSprites(LevelList.Level41);
                    break;
                case 42:
                    AddSprites(LevelList.Level42);
                    break;
                case 43:
                    AddSprites(LevelList.Level43);
                    break;
                case 44:
                    AddSprites(LevelList.Level44);
                    break;
                case 45:
                    AddSprites(LevelList.Level45);
                    break;
                case 46:
                    AddSprites(LevelList.Level46);
                    break;
                case 47:
                    AddSprites(LevelList.Level47);
                    break;
                case 48:
                    AddSprites(LevelList.Level48);
                    break;
                case 49:
                    AddSprites(LevelList.Level49);
                    break;
                case 50:
                    AddSprites(LevelList.Level50);
                    break;
                case 51:
                    AddSprites(LevelList.Level51);
                    break;
                case 52:
                    AddSprites(LevelList.Level52);
                    break;
                case 53:
                    AddSprites(LevelList.Level53);
                    break;
                case 54:
                    AddSprites(LevelList.Level54);
                    break;
                case 55:
                    AddSprites(LevelList.Level55);
                    break;
                case 56:
                    AddSprites(LevelList.Level56);
                    break;
                case 57:
                    AddSprites(LevelList.Level57);
                    break;
                case 58:
                    AddSprites(LevelList.Level58);
                    break;
                case 59:
                    AddSprites(LevelList.Level59);
                    break;
                case 60:
                    AddSprites(LevelList.Level60);
                    break;
                case 61:
                    AddSprites(LevelList.Level61);
                    break;
                case 62:
                    AddSprites(LevelList.Level62);
                    break;
                case 63:
                    AddSprites(LevelList.Level63);
                    break;
                case 64:
                    AddSprites(LevelList.Level64);
                    break;
                case 65:
                    AddSprites(LevelList.Level65);
                    break;
                case 66:
                    AddSprites(LevelList.Level66);
                    break;
                case 67:
                    AddSprites(LevelList.Level67);
                    break;
                case 68:
                    AddSprites(LevelList.Level68);
                    break;
                case 69:
                    AddSprites(LevelList.Level69);
                    break;
                case 70:
                    AddSprites(LevelList.Level70);
                    break;
            }
        }
      
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();//SpriteSortMode.Immediate,null,null,null,null,null,scale);

            if (gameState == GameState.Game)
            {
             Background1.Draw(spriteBatch);
             particleSystem.Draw(spriteBatch);

spriteBatch.DrawString(LoadClass.Font, "Next level :  " + time.ToString(), new Vector2(1, graphics.PreferredBackBufferHeight - 25), Color.Yellow);
spriteBatch.DrawString(LoadClass.Font, "Level :  " + Level.ToString(), new Vector2(250, graphics.PreferredBackBufferHeight - 25), Color.Yellow);
spriteBatch.DrawString(LoadClass.Font, "Score :  " + Score.ToString(), new Vector2(370, graphics.PreferredBackBufferHeight - 25), Color.Yellow);
spriteBatch.DrawString(LoadClass.Font, "Neoin :  " + Neoin.Values["kwdiu23n9f0"].ToString(), new Vector2(550, graphics.PreferredBackBufferHeight - 25), Color.Yellow);

               base.Draw(gameTime);
               
            }
            else if (gameState == GameState.Menu)
            {
                spriteBatch.Draw(LoadClass.background, new Rectangle(0, 0, ScrrenWidth, ScreenHeight), Color.White);

               
                
                
            }
            else if (gameState == GameState.HighScore)
            {
               
               
                    spriteBatch.Draw(LoadClass.backButton, new Vector2(10, 560), Color.White);
                    spriteBatch.Draw(LoadClass.HscoreBack, new Rectangle(0, 0, ScrrenWidth, ScreenHeight), Color.White);
                    Object value = localSettings.Values["exampleSetting"];
                    spriteBatch.DrawString(LoadClass.Font, "You High Score:" + value.ToString(), new Vector2((spriteBatch.GraphicsDevice.Viewport.Width / 2) - 100, (spriteBatch.GraphicsDevice.Viewport.Height / 2) - 70), Color.Yellow);
                

            }
            else if (gameState == GameState.Game_Over)
            {
                // Draw Game Over 
                spriteBatch.Draw(LoadClass.GameOvertexture, new Rectangle(0, 0, ScrrenWidth, ScreenHeight), Color.White);
                
                //spriteBatch.DrawString(Font, "Press Enter for return to game", new Vector2((ScrrenWidth / 2) - 160, ((ScreenHeight - 50) / 2) + 150), Color.White);
                //spriteBatch.DrawString(Font, "      You score: " + Score.ToString(), new Vector2((ScrrenWidth / 2) - 160, ((ScreenHeight / 2) - 75) + 150), Color.White);
                //spriteBatch.DrawString(Font, "   You High score: " + ScoreHigh.Values["exampleSetting"].ToString(), new Vector2((ScrrenWidth / 2) - 160, ((ScreenHeight / 2) - 50) + 150), Color.White);
            }else if(gameState == GameState.store)
            {

                spriteBatch.Draw(LoadClass.storeBackground, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                spriteBatch.Draw(LoadClass.buyNeonlis, buyNeonRect, Color.White);
                spriteBatch.Draw(LoadClass.buyBat_1, buyBatRect_1, Color.White);
                spriteBatch.Draw(LoadClass.buyBat_2, buyBatRect_2, Color.White);
                spriteBatch.Draw(LoadClass.buyBat_3, buyBatRect_3, Color.White);
                spriteBatch.Draw(LoadClass.buyBoll_1, buyBollrect_1, Color.White);
                spriteBatch.Draw(LoadClass.buyBoll_2, buyBollRect_2, Color.White);
                spriteBatch.Draw(LoadClass.defaultBat, defaultBatRect, Color.White);
                spriteBatch.Draw(LoadClass.defaultBoll, defaultBollRect, Color.White);

                if(item_Chose.Values["item_1_check"].ToString() == "1")
                { spriteBatch.Draw(LoadClass.chosItem, new Rectangle(buyBatRect_1.X, buyBatRect_1.Y, 200, 150), Color.White); }
                if(item_Chose.Values["item_3_check"].ToString() == "1")
                { spriteBatch.Draw(LoadClass.chosItem, new Rectangle(buyBatRect_3.X, buyBatRect_3.Y, 200, 150), Color.White); }
                if(item_Chose.Values["item_2_check"].ToString() == "1")
                { spriteBatch.Draw(LoadClass.chosItem, new Rectangle(buyBatRect_2.X, buyBatRect_2.Y, 200, 150), Color.White); }
                if(item_Chose.Values["item_4_check"].ToString() == "1")
                { spriteBatch.Draw(LoadClass.chosItem, new Rectangle(buyBollrect_1.X, buyBollrect_1.Y, 200, 150), Color.White); }
                if(item_Chose.Values["item_5_check"].ToString() == "1")
                { spriteBatch.Draw(LoadClass.chosItem, new Rectangle(buyBollRect_2.X, buyBollRect_2.Y, 200, 150), Color.White); }



                if (item_Chose.Values["defBat"].ToString() == "1")
                {
                    spriteBatch.Draw(LoadClass.chosItem, new Rectangle(defaultBatRect.X, defaultBatRect.Y, 200, 150), Color.White);
                }
                if(item_Chose.Values["defBoll"].ToString() == "1")
                {
                    spriteBatch.Draw(LoadClass.chosItem, new Rectangle(defaultBollRect.X, defaultBollRect.Y, 200, 150), Color.White);
                }
              

                //Locked item
                if(buyItem_3.Values["item_3"].ToString() == "0")
                { spriteBatch.Draw(LoadClass.lockedItem, new Rectangle(buyBatRect_3.X, buyBatRect_3.Y, 200, 150), Color.White); }
                if(buyItem_2.Values["item_2"].ToString() == "0")
                { spriteBatch.Draw(LoadClass.lockedItem, new Rectangle(buyBatRect_2.X, buyBatRect_2.Y, 200, 150), Color.White); }
                if(buyItem_1.Values["item_1"].ToString() == "0")
                { spriteBatch.Draw(LoadClass.lockedItem, new Rectangle(buyBatRect_1.X, buyBatRect_1.Y, 200, 150), Color.White); }
                if(buyItem_4.Values["item_4"].ToString() == "0")
                { spriteBatch.Draw(LoadClass.lockedItem, new Rectangle(buyBollrect_1.X, buyBollrect_1.Y, 200, 150), Color.White); }
                if(buyItem_5.Values["item_5"].ToString() == "0")
                { spriteBatch.Draw(LoadClass.lockedItem, new Rectangle(buyBollRect_2.X, buyBollRect_2.Y, 200, 150), Color.White); }

                TouchCollection tC = TouchPanel.GetState();
                foreach (TouchLocation tL in tC)
                {
                    switch (buyMessage)
                    {
                        case BuyMess.succsses:
                            spriteBatch.DrawString(LoadClass.Font, "SUCCESS", new Vector2(tL.Position.X, tL.Position.Y), Color.Yellow);

                            buyMessage = BuyMess.none;
                            break;
                        case BuyMess.fatal:
                            spriteBatch.DrawString(LoadClass.Font, "You do not have neoins", new Vector2(tL.Position.X + VelocityY, tL.Position.Y), Color.Yellow, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
                            buyMessage = BuyMess.none;
                            break;
                        case BuyMess.none:
                            break;
                    }
                }

                spriteBatch.DrawString(LoadClass.Font, "NEOIN: " + Neoin.Values["kwdiu23n9f0"].ToString(), new Vector2(10, 10), Color.Yellow);
            }
            else if(gameState == GameState.about)
            {
                spriteBatch.Draw(LoadClass.aboutScreen, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
            }
            spriteBatch.End();
            
        }
        internal void StoreControlSystem()
        {
            TouchCollection touchLocations = TouchPanel.GetState();
            foreach (TouchLocation touchLocation in touchLocations)
            {
                if (touchLocation.Position.Y > 400 && touchLocation.Position.Y < 480 && touchLocation.Position.X > 0 && touchLocation.Position.X < 100)
                {
                    gameState = GameState.Menu;
                }

                if (touchLocation.Position.X >= buyNeonRect.X && touchLocation.Position.X <= buyNeonRect.Width + buyNeonRect.X && touchLocation.Position.Y >= buyNeonRect.Y && touchLocation.Position.Y <= buyNeonRect.Height + buyNeonRect.Y)
                {
                    try
                    {
                        BuyNeon();
                    }
                    catch
                    {

                    }
                }


                // BAT 1 ==================================================================
          if (touchLocation.Position.X >= buyBatRect_1.X && touchLocation.Position.X <= buyBatRect_1.X + buyBatRect_1.Width && touchLocation.Position.Y >= buyBatRect_1.Y && touchLocation.Position.Y <= buyBatRect_1.Y + buyBatRect_1.Height)
          {
              if (buyItem_1.Values["item_1"].ToString() == "0")
              {
                  if (neon >= 50000)
                  {
                      neon -= 50000;
                      buyMessage = BuyMess.succsses;
                      selectBatSkin = SkinBat.MegaGreen;
                      buyItem_1.Values["item_1"] = 1;
                  }
                  else { buyMessage = BuyMess.fatal; }
              }
              if(buyItem_1.Values["item_1"].ToString() == "1")
                     {
                            item_Chose.Values["item_1_check"] = 1;
                            item_Chose.Values["defBat"] = 0;
                            item_Chose.Values["item_2_check"] = 0;
                            item_Chose.Values["item_3_check"] = 0;
                           selectBatSkin = SkinBat.MegaGreen;
                    }
                  
                }
                /////////////////////////////////////////////////////////////////////////
                // BAT 2 ==================================================================
                if (touchLocation.Position.X >= buyBatRect_2.X && touchLocation.Position.X <= buyBatRect_2.X + buyBatRect_2.Width && touchLocation.Position.Y >= buyBatRect_2.Y && touchLocation.Position.Y <= buyBatRect_2.Y + buyBatRect_2.Height)
                {
                    if (buyItem_2.Values["item_2"].ToString() == "0")
                    {
                        if (neon >= 20000)
                        {
                            neon -= 20000;
                            buyMessage = BuyMess.succsses;
                            selectBatSkin = SkinBat.FastYellow;
                            buyItem_2.Values["item_2"] = 1;
                        }
                        else { buyMessage = BuyMess.fatal; }
                    }
                    
                    if (buyItem_2.Values["item_2"].ToString() == "1")
                    {
                        item_Chose.Values["item_1_check"] = 0;
                        item_Chose.Values["defBat"] = 0;
                        item_Chose.Values["item_2_check"] = 1;
                        item_Chose.Values["item_3_check"] = 0;
                        selectBatSkin = SkinBat.FastYellow;
                    }
                  
                }

                if (touchLocation.Position.X >= buyBatRect_3.X && touchLocation.Position.X <= buyBatRect_3.X + buyBatRect_3.Width && touchLocation.Position.Y >= buyBatRect_3.Y && touchLocation.Position.Y <= buyBatRect_3.Y + buyBatRect_3.Height)
                {
                    if (buyItem_3.Values["item_3"].ToString() == "0")
                    {
                        if (neon >= 100000)
                        {
                            neon -= 100000;
                            buyMessage = BuyMess.succsses;
                            selectBatSkin = SkinBat.RedSun;
                            buyItem_3.Values["item_3"] = 1;

                        }
                        else { buyMessage = BuyMess.fatal; }
                    }
                    if(buyItem_3.Values["item_3"].ToString() == "1")
                    {
                        item_Chose.Values["item_1_check"] = 0;
                        item_Chose.Values["item_2_check"] = 0;
                        item_Chose.Values["item_3_check"] = 1;
                        item_Chose.Values["defBat"] = 0;
                        selectBatSkin = SkinBat.RedSun;
                    }
                }

                if(touchLocation.Position.X >= defaultBatRect.X && touchLocation.Position.X <= defaultBatRect.X + defaultBatRect.Width && touchLocation.Position.Y >= defaultBatRect.Y && touchLocation.Position.Y < defaultBatRect.Y + defaultBatRect.Height)
                {
                    item_Chose.Values["defBat"] = 1;
                    selectBatSkin = SkinBat.Origin;
                    item_Chose.Values["item_1_check"] = 0; 
                    item_Chose.Values["item_2_check"] = 0;
                    item_Chose.Values["item_3_check"] = 0; 
                   
                }
                ////////////BOLL chose Blokc////////////////////
                if(touchLocation.Position.X >= defaultBollRect.X && touchLocation.Position.X <= defaultBollRect.X + defaultBollRect.Width && touchLocation.Position.Y >= defaultBollRect.Y && touchLocation.Position.Y <= defaultBollRect.Y + defaultBollRect.Height)
                {

                    item_Chose.Values["defBoll"] = 1;
                    item_Chose.Values["item_4_check"] = 0;
                    item_Chose.Values["item_5_check"] = 0;
                    selectBollSkin = SkinBoll.Origin;
                }
                if(touchLocation.Position.X >= buyBollrect_1.X && touchLocation.Position.X <= buyBollrect_1.X + buyBollrect_1.Width && touchLocation.Position.Y >= buyBollrect_1.Y && touchLocation.Position.Y <= buyBollrect_1.Height + buyBollrect_1.Y)
                {
                    if (buyItem_4.Values["item_4"].ToString() == "0")
                    {
                        if(neon >= 10000)
                        {
                            neon -= 10000;
                            buyMessage = BuyMess.succsses;
                            selectBollSkin = SkinBoll.YellowBable;
                            buyItem_4.Values["item_4"] = 1;

                        }
                        else { buyMessage = BuyMess.fatal; }
                    }
                    if (buyItem_4.Values["item_4"].ToString() == "1")
                    {
                        item_Chose.Values["defBoll"] = 0;
                        item_Chose.Values["item_4_check"] = 1;
                        item_Chose.Values["item_5_check"] = 0;
                        selectBollSkin = SkinBoll.YellowBable;
                    }
                }
                if(touchLocation.Position.X >= buyBollRect_2.X && touchLocation.Position.X <= buyBollRect_2.X + buyBollRect_2.Width && touchLocation.Position.Y >= buyBollRect_2.Y && touchLocation.Position.Y <= buyBollRect_2.Y + buyBollRect_2.Height)
                {
                    if(buyItem_5.Values["item_5"].ToString() == "0")
                    {
                        if(neon >= 35000)
                        {
                            neon -= 35000;
                            buyMessage = BuyMess.succsses;
                            selectBollSkin = SkinBoll.RedStar;
                            buyItem_5.Values["item_5"] = 1;
                        }
                        else { buyMessage = BuyMess.fatal; }
                    }
                    if(buyItem_5.Values["item_5"].ToString() == "1")
                    {
                        item_Chose.Values["defBoll"] = 0;
                        item_Chose.Values["item_4_check"] = 0;
                        item_Chose.Values["item_5_check"] = 1;
                        selectBollSkin = SkinBoll.RedStar;
                    }
                }


            }
        }


       
    }
}
