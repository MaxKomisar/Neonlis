using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Neonlis2game
{
  public static class LoadClass
    {
    public static Texture2D txtBrick1;
    public static Texture2D txtBrick2;
    public static Texture2D txtBat;
    public static Texture2D txtBall;
    public static Texture2D textureBrick3;
    public static Texture2D textureBrick4;
    public static Texture2D textureBrick5;
    public static Texture2D texturebrick6;
    public static Texture2D particleUnityBlue;
    public static Texture2D particleUnityGreen;
    public static Texture2D particleUnityRed;
    public static Texture2D particleUnityYellow;
    public static Texture2D particleUnityViolet;
    public static Texture2D particleunityOrange;
    public static Texture2D textureBonusTriangle;
    public static Texture2D textureBonusReflect;
    public static Texture2D textureBonusPlusWidthBat;
    public static Texture2D HscoreBack;
    public static Texture2D background;
    public static Texture2D aboutScreen;
    public static Texture2D GameOvertexture;
    public static Texture2D buyNeonlis;
    public static Texture2D storeBackground;
    public static Texture2D buyBat_1;
    public static Texture2D buyBat_2;
    public static Texture2D buyBat_3;
    public static Texture2D buyBoll_1;
    public static Texture2D buyBoll_2;
    public static Texture2D defaultBoll;
    public static Texture2D defaultBat;
    public static Texture2D chosItem;
    public static Texture2D lockedItem;
    public static Texture2D skinTexture;
    public static Texture2D skinBollTexture;
    public static Texture2D batRedSun;
    public static Texture2D batFastYellow;
    public static Texture2D batMegaGreen;
    public static Texture2D bollRedStar;
    public static Texture2D bollYellowBable;
    public static SoundEffect collisionSoundEffect;
    public static Song gameBackgroundSong;
    public static SpriteFont Font;
    public static Texture2D startGameTexture;
    public static Texture2D backButton;

     public static void LoadContentAsistens(ContentManager content)
    {
        backButton = content.Load<Texture2D>(CONSTGame.backButton);
        startGameTexture = content.Load<Texture2D>(CONSTGame.menuStartGame);
        txtBrick1 = content.Load<Texture2D>(CONSTGame.Brick1);
        txtBrick2 = content.Load<Texture2D>(CONSTGame.Brick2);
        txtBall = content.Load<Texture2D>(CONSTGame.ball);
        particleUnityBlue = content.Load<Texture2D>(CONSTGame.smoke);
        particleUnityGreen = content.Load<Texture2D>(CONSTGame.smoke_green);
        particleunityOrange = content.Load<Texture2D>(CONSTGame.smoke_orange);
        particleUnityRed = content.Load<Texture2D>(CONSTGame.smoke_red);
        particleUnityViolet = content.Load<Texture2D>(CONSTGame.smoke_violet);
        particleUnityYellow = content.Load<Texture2D>(CONSTGame.smoke_yellow);
        textureBrick3 = content.Load<Texture2D>(CONSTGame.Brick3);
        textureBrick4 = content.Load<Texture2D>(CONSTGame.Brick4);
        textureBrick5 = content.Load<Texture2D>(CONSTGame.Brick5);
        texturebrick6 = content.Load<Texture2D>(CONSTGame.Brick6);
        textureBonusTriangle = content.Load<Texture2D>(CONSTGame.tryBonus);
        textureBonusPlusWidthBat = content.Load<Texture2D>(CONSTGame.sizeplusBonus);
        textureBonusReflect = content.Load<Texture2D>(CONSTGame.reflect_Bonus);
        txtBat = content.Load<Texture2D>(CONSTGame.bat);
        background = content.Load<Texture2D>(CONSTGame.Menu_Screen);
        HscoreBack = content.Load<Texture2D>(CONSTGame.HighScore);
        GameOvertexture = content.Load<Texture2D>(CONSTGame.game_over);
        aboutScreen = content.Load<Texture2D>(CONSTGame.About_screen);
        storeBackground = content.Load<Texture2D>(CONSTGame.Store);
        buyNeonlis = content.Load<Texture2D>(CONSTGame.buy_10k);
        buyBat_1 = content.Load<Texture2D>(CONSTGame.batgreen);
        buyBat_2 = content.Load<Texture2D>(CONSTGame.batyellow);
      //  buyBat_3 = content.Load<Texture2D>("storen/batyred");
        buyBoll_1 = content.Load<Texture2D>("storen/ballyellow");
        buyBoll_2 = content.Load<Texture2D>("storen/ballred");
        buyBat_3 = content.Load<Texture2D>(CONSTGame.batyred);
        //buyBoll_1 = content.Load<Texture2D>("storen/ballyellow");
        //=buyBoll_2 = content.Load<Texture2D>("storen/ballred");
        batFastYellow = content.Load<Texture2D>(CONSTGame.bat_4);
        batMegaGreen = content.Load<Texture2D>(CONSTGame.bat_3);
        batRedSun = content.Load<Texture2D>(CONSTGame.bat_2);
        bollRedStar = content.Load<Texture2D>(CONSTGame.Ball_3);
        bollYellowBable = content.Load<Texture2D>(CONSTGame.Ball_2);
        defaultBat = content.Load<Texture2D>(CONSTGame.batdef);
        defaultBoll = content.Load<Texture2D>(CONSTGame.bolldef);
        chosItem = content.Load<Texture2D>(CONSTGame.chose);
        lockedItem = content.Load<Texture2D>(CONSTGame.Lock);
        Font = content.Load<SpriteFont>(CONSTGame.fontGame);
        gameBackgroundSong = content.Load<Song>(CONSTGame.dubstepLight);
        collisionSoundEffect = content.Load<SoundEffect>(CONSTGame.sCifi048);

    }
    }
}
