using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace TheAnomalousYouthSquad_Game_try_1
{
    // Staes for the game
    enum GameStates { Intro, TitleScreen, Options, Credits, Game, LoadScreen, StoryIntro, PreBattle, GameOver, Instructions } 
    enum Round1States { NerdTurn, JockTurn, CheerTurn, EnemyTurn, Enemy2Turn }
    enum Round2States { EnemyTurn, JockTurn, NerdTurn, Enemy2Turn, CheertTurn }
    enum Round3States { CheerTurn, NerdTurn, EnemyTurn, JockTurn, Enemy2Turn, BossTurn }
    enum Round4States { Enemy2Turn, CheerTurn, EnemyTurn, NerdTurn, JockTurn }
    enum Round5States { NerdTurn, Enemy2Turn, JockTurn, EnemyTurn, CheerTurn }
    enum Round6States { Enemy3Turn, NerdTurn, Enemy2Turn, JockTurn, CheerTurn, EnemyTurn }
    enum Round7States { BossTurn, CheerTurn, NerdTurn, EnemyTurn, Enemy2Turn, JockTurn }
    enum Round8States { JockTurn, Enemy2Turn, Enemy3Turn, NerdTurn, EnemyTurn, CheerTurn }
    enum Round9States { NerdTurn, CheerTurn, Enemy2Turn, Enemy3Turn, JockTurn, EnemyTurn }
    enum Round10States { BossTurn, JockTurn, Enemy2Turn, CheerTurn, EnemyTurn, NerdTurn }

    enum DifficultyStates { Normal, Easy, Nightmare}

    // External tool = Windows form app that reads in files for the number of enemies and their stats for each level and sets them to enemy objects. It then stores them into a list for the level.

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Set up State variable
        GameStates gState;

        // State Variables
        Round1States round1State;
        Round2States round2State;
        Round3States round3State;
        Round4States round4State;
        Round5States round5State;
        Round6States round6State;
        Round7States round7State;
        Round8States round8State;
        Round9States round9State;
        Round10States round10State;

        // Difficulty state variable
        DifficultyStates dstate;

        // Round variable
        int round = 1;
        // Picture Properties for intro screen
        Texture2D bCircle;
        Texture2D gCircle;
        Texture2D pCircle;
        Texture2D wCircle;
        Vector2 BluePosition;
        Vector2 GreenPosition;
        Vector2 PurplePosition;
        Vector2 WhitePosition;

        // Font Properties
        SpriteFont font;

        // Background Pictures
        Texture2D GameBackground;
        Texture2D StreetBackgroundRound4;
        Texture2D StreetBackgroundRound5;
        Texture2D StreetBackgroundRound6;
        Texture2D StreetBackgroundRound7;
        Texture2D OvalOffice;
        Texture2D WhiteHouse;
        // Sound Effects for game
        SoundEffect TitleScreenMusic;


        // Variables for collision in intro screen
        Point BlueFrameSize = new Point(310, 310);
        Point GreenFrameSize = new Point(310, 310);
        Point PurpleFrameSize = new Point(310, 310);

        int BlueCollisionOffSet = 10;
        int GreenCollisionOffSet = 10;
        int PurpleCollisionOffSet = 10;

        // Menu buttons for title screen
        Texture2D StartButton;
        Texture2D OptionsButton;
        Texture2D CreditsButtons;
        Vector2 startBPosition;
        Vector2 creditsBPosition;
        Vector2 optionsBPosition;

        // Logo for Intro screen
        Texture2D Logo;
        Vector2 LogoPosition;

        // GameTitle for title screen
        Texture2D Title;
        Vector2 TitlePosition;

        // MouseState for TitleScreen
        MouseState mState;
        MouseState LastmState;

        // Values for mouse
        Point MousePosition;

        // Rectangles for title screen buttons
        Rectangle startArea;
        Rectangle optionsArea;
        Rectangle creditsArea;

        // Gamestate Background
        Texture2D gStateBackground;

        // Return Button for options and credit states
        Texture2D returnButton;
        Vector2 returnBPosition;

        // Make the character variables to test combat
        Cheerleader cheer = new Cheerleader(150, 10, 10, 10, true);
        Geek nerd = new Geek(350, 20, 20, 20, true);
        Jock football = new Jock(225, 20, 15, 15, true);

        // All of the int stat values that will be set by the files
        // Enemies for round 1
        int e1Round1Health = 0;
        int e1Round1Attack = 0;
        int e1Round1Defense = 0;
        int e1Round1Speed = 0;
        //
        int e2Round1Health = 0;
        int e2Round1Attack = 0;
        int e2Round1Defense = 0;
        int e2Round1Speed = 0;
        // Enemies for round 2
        int e1Round2Health = 0;
        int e1Round2Attack = 0;
        int e1Round2Defense = 0;
        int e1Round2Speed = 0;
        //
        int e2Round2Health = 0;
        int e2Round2Attack = 0;
        int e2Round2Defense = 0;
        int e2Round2Speed = 0;
        // Enemies for round 3
        int e1Round3Health = 0;
        int e1Round3Attack = 0;
        int e1Round3Defense = 0;
        int e1Round3Speed = 0;
        //
        int e2Round3Health = 0;
        int e2Round3Attack = 0;
        int e2Round3Defense = 0;
        int e2Round3Speed = 0;
        // Enemies for round 4
        int e1Round4Health = 0;
        int e1Round4Attack = 0;
        int e1Round4Defense = 0;
        int e1Round4Speed = 0;
        //
        int e2Round4Health = 0;
        int e2Round4Attack = 0;
        int e2Round4Defense = 0;
        int e2Round4Speed = 0;
        // Enemies for round 5
        int e1Round5Health = 0;
        int e1Round5Attack = 0;
        int e1Round5Defense = 0;
        int e1Round5Speed = 0;
        //
        int e2Round5Health = 0;
        int e2Round5Attack = 0;
        int e2Round5Defense = 0;
        int e2Round5Speed = 0;
        // Enemies for round 6
        int e1Round6Health = 0;
        int e1Round6Attack = 0;
        int e1Round6Defense = 0;
        int e1Round6Speed = 0;
        //
        int e2Round6Health = 0;
        int e2Round6Attack = 0;
        int e2Round6Defense = 0;
        int e2Round6Speed = 0;
        //
        int e3Round6Health = 0;
        int e3Round6Attack = 0;
        int e3Round6Defense = 0;
        int e3Round6Speed = 0;
        // Enemies for round 7
        int e1Round7Health = 0;
        int e1Round7Attack = 0;
        int e1Round7Defense = 0;
        int e1Round7Speed = 0;
        //
        int e2Round7Health = 0;
        int e2Round7Attack = 0;
        int e2Round7Defense = 0;
        int e2Round7Speed = 0;
        // Enemies for round 8
        int e1Round8Health = 0;
        int e1Round8Attack = 0;
        int e1Round8Defense = 0;
        int e1Round8Speed = 0;
        //
        int e2Round8Health = 0;
        int e2Round8Attack = 0;
        int e2Round8Defense = 0;
        int e2Round8Speed = 0;
        // 
        int e3Round8Health = 0;
        int e3Round8Attack = 0;
        int e3Round8Defense = 0;
        int e3Round8Speed = 0;
        // Enemies for round 9
        int e1Round9Health = 0;
        int e1Round9Attack = 0;
        int e1Round9Defense = 0;
        int e1Round9Speed = 0;
        //
        int e2Round9Health = 0;
        int e2Round9Attack = 0;
        int e2Round9Defense = 0;
        int e2Round9Speed = 0;
        //
        int e3Round9Health = 0;
        int e3Round9Attack = 0;
        int e3Round9Defense = 0;
        int e3Round9Speed = 0;
        // Enemies for round 10
        int e1Round10Health = 0;
        int e1Round10Attack = 0;
        int e1Round10Defense = 0;
        int e1Round10Speed = 0;
        //
        int e2Round10Health = 0;
        int e2Round10Attack = 0;
        int e2Round10Defense = 0;
        int e2Round10Speed = 0;

        // Round 1 Enemies
        Enemy e1Round1 = new Enemy(120, 10, 10, 10, true);
        Enemy e2Round1 = new Enemy(150, 10, 10, 10, true);

        // Round 2
        Enemy e1Round2 = new Enemy(130, 10, 10, 10, true);
        Enemy e2Round2 = new Enemy(145, 10, 10, 10, true);

        // Round 3
        Enemy e1Round3 = new Enemy(115, 10, 10, 10, true);
        Enemy e2Round3 = new Enemy(85, 10, 10, 10, true);
        Enemy bossRound3 = new Enemy(200, 10, 10, 10, true);

        // Round 4
        Enemy e1Round4 = new Enemy(120, 10, 10, 10, true);
        Enemy e2Round4 = new Enemy(75, 10, 10, 10, true);

        // Round 5
        Enemy e1Round5 = new Enemy(150, 10, 10, 10, true);
        Enemy e2Round5 = new Enemy(140, 10, 10, 10, true);

        // Round 6 
        Enemy e1Round6 = new Enemy(130, 10, 10, 10, true);
        Enemy e2Round6 = new Enemy(160, 10, 10, 10, true);
        Enemy e3Round6 = new Enemy(100, 10, 10, 10, true);

        // Round 7
        Enemy e1Round7 = new Enemy(145, 10, 10, 10, true);
        Enemy e2Round7 = new Enemy(125, 10, 10, 10, true);
        Enemy bossRound7 = new Enemy(100, 10, 10, 10, true);

        // Round 8 
        Enemy e1Round8 = new Enemy(120, 10, 10, 10, true);
        Enemy e2Round8 = new Enemy(60, 10, 10, 10, true);
        Enemy e3Round8 = new Enemy(80, 10, 10, 10, true);

        // Round 9
        Enemy e1Round9 = new Enemy(150, 10, 10, 10, true);
        Enemy e2Round9 = new Enemy(140, 10, 10, 10, true);
        Enemy e3Round9 = new Enemy(170, 10, 10, 10, true);

        // Round 10
        Enemy e1Round10 = new Enemy(170, 10, 10, 10, true);
        Enemy e2Round10 = new Enemy(210, 10, 10, 10, true);
        Enemy bossFinal = new Enemy(350, 10, 10, 10, true);

        // More test stuff
        List<Enemy> enemies;

        // Sprites for the characters and enemies
        Texture2D geek;
        Texture2D alien;
        Texture2D jock;
        Texture2D cheerLeader;
        Texture2D boss;
        Vector2 positionGeek;
        Vector2 positionAlien;
        Vector2 positionJock;
        Vector2 positionCheerLeader;
        //Vector2 positionBoss;
        // Sprites for the menu
        Texture2D geekMenu;
        Texture2D jockMenu;
        Texture2D cheerMenu;
        Vector2 geekMenuPosition;
        Vector2 jockMenuPosition;
        Vector2 cheerMenuPosition;

        // Earth sprite for the earth animations
        EarthSprite Earth;

        // Idle Sprites
        NerdIdleSprite IdleNerd;
        CheerIdleSprite IdleCheer;
        JockIdleSprite IdleJock;
        EnemyIdleSprite IdleEnemy;
        BossIdleSprite IdleBoss;
        Enemy2IdleSprite IdleEnemy2;
        Enemy3IdleSprite IdleEnemy3;
        JockTakeDamage DamageJock;
        GeekTakeDamage DamageGeek;
        CheerTakeDamage DamageCheer;
        RoundDisplay RDisplay;
        RoundDisplay2 RDisplay2;
        RoundDisplay3 RDisplay3;
        RoundDisplay4 RDisplay4;
        RoundDisplay5 RDisplay5;
        RoundDisplay6 RDisplay6;
        RoundDisplay7 RDisplay7;
        RoundDisplay8 RDisplay8;
        RoundDisplay9 RDisplay9;
        RoundDisplay10 RDisplay10;

        // Music for Game
        private Song GameTitleMusic;
        private Song GameCombatMusic;
        private Song GameLoadScreenMusic;


        int TitleMusicCounter = 960;
        int LoadScreenMusicCounter = 1440;
        int CombatMusicCouter = 1965;

        // Bool for if music is playing
        bool musicOn = true;

        // Buttons for options screen
        Texture2D EasyButton;
        Texture2D EasyButtonOff;
        Texture2D NormalButton;
        Texture2D NormalButtonOff;
        Texture2D NightmareButton;
        Texture2D NightmareButtonOff;
        Texture2D MusicOnButton;
        Texture2D MusicOffButton;

        // Text pictures for options screen
        Texture2D DifficultyText;
        Texture2D ToggleMusicText;

        // Pre-Battle Text
        Texture2D PreBattleText;
        Texture2D PreBattleText2;

        // Game Over Screen 
        Texture2D RoundReachedText;
        Texture2D Round1Text;
        Texture2D Round2Text;
        Texture2D Round3Text;
        Texture2D Round4Text;
        Texture2D Round5Text;
        Texture2D Round6Text;
        Texture2D Round7Text;
        Texture2D Round8Text;
        Texture2D Round9Text;
        Texture2D Round10Text;
        Texture2D GameOverText;

        int gameOverTimer = 0;

        int preBattleTimer = 0;

        int gameOverWidth = 0;
        int gameOverHeight = 0;

        int instructionsTimer = 0;

        // Instructions Screen
        Texture2D Instructions;

        // Round Display
        Texture2D RD1;
        Texture2D RD2;
        Texture2D RD3;
        Texture2D RD4;
        Texture2D RD5;
        Texture2D RD6;
        Texture2D RD7;
        Texture2D RD8;
        Texture2D RD9;
        Texture2D RD10;

        // Letters for story screen
        Texture2D hyphen;

        // Text for story
        Texture2D storyText1;
        Texture2D storyText2;
        Texture2D storyText3;
        Texture2D storyText4;
        Texture2D storyText5;
        Texture2D storyText6;
        Texture2D hello;
        Texture2D welcome;

        Texture2D credits;

        // Timer for story
        double StoryTimer = 0;
        // Story Menu
        Texture2D storyMenu;

        KeyboardState kState;

        // Collision Methos
        protected bool Collide()
        {
            // Drawing a rectangle around Blue Circle
            Rectangle BlueRect = new Rectangle(
                (int)BluePosition.X + BlueCollisionOffSet,
                (int)BluePosition.Y + BlueCollisionOffSet,
                BlueFrameSize.X - (BlueCollisionOffSet * 2),
                BlueFrameSize.Y - (BlueCollisionOffSet * 2));

            // Drawing a rectangle around the Green circle
            Rectangle GreenRect = new Rectangle(
                (int)GreenPosition.X + GreenCollisionOffSet,
                (int)GreenPosition.Y + GreenCollisionOffSet,
                GreenFrameSize.X - (GreenCollisionOffSet * 2),
                GreenFrameSize.Y - (GreenCollisionOffSet * 2));

            // Drawing a rectangle around the Purple circle
            Rectangle PurpleRect = new Rectangle(
                (int)PurplePosition.X + PurpleCollisionOffSet,
                (int)PurplePosition.Y + PurpleCollisionOffSet,
                PurpleFrameSize.X - (PurpleCollisionOffSet * 2),
                PurpleFrameSize.Y - (PurpleCollisionOffSet * 2));

            return BlueRect.Intersects(GreenRect);
        }
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Makes the screen Bigger
            graphics.PreferredBackBufferWidth = 1900;
            graphics.PreferredBackBufferHeight = 1000;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            // Assigning values to the vector2 
            BluePosition = new Vector2(0, 500);
            GreenPosition = new Vector2(1800, 500);
            PurplePosition = new Vector2(910, 0);
            WhitePosition = new Vector2(910, 500);
            startBPosition = new Vector2(790, 285);
            creditsBPosition = new Vector2(790, 425);
            optionsBPosition = new Vector2(790, 595);
            TitlePosition = new Vector2(276, 110);
            LogoPosition = new Vector2(780, 680);
            MousePosition = new Point(mState.X, mState.Y);

            startArea = new Rectangle((int)startBPosition.X, (int)startBPosition.Y, 256, 70); // Area for start button
            optionsArea = new Rectangle((int)optionsBPosition.X, (int)optionsBPosition.Y, 256, 70); // Area for options button
            creditsArea = new Rectangle((int)creditsBPosition.X, (int)creditsBPosition.Y, 256, 70); // Area for credits button

            returnBPosition = new Vector2(630, 680);

            // Test stuff
            enemies = new List<Enemy>();

            // Setting up the charcters
            positionGeek = new Vector2(310, 390);
            positionAlien = new Vector2(GraphicsDevice.Viewport.Width - 560, 320);
            positionJock = new Vector2(200, 360);
            positionCheerLeader = new Vector2(-40, 406);

            // Setting up Menus
            geekMenuPosition = new Vector2(0, 800);
            jockMenuPosition = new Vector2(0, 800);
            cheerMenuPosition = new Vector2(0, 800);

            if(dstate == DifficultyStates.Easy)
            {
                FileLoader();
            }
            else if(dstate == DifficultyStates.Normal)
            {
                FileLoader();
            }
            else
            {
                FileLoader();
            }

            e1Round1 = new Enemy(e1Round1Health, e1Round1Attack, e1Round1Defense, e1Round1Speed, true);
            e2Round1 = new Enemy(e2Round1Health, e2Round1Attack, e2Round1Defense, e2Round1Speed, true);

            e1Round2 = new Enemy(e1Round2Health, e1Round2Attack, e1Round2Defense, e1Round2Speed, true);
            e2Round2 = new Enemy(e2Round2Health, e1Round2Attack, e1Round2Defense, e1Round2Speed, true);

            // Round 3
            e1Round3 = new Enemy(e1Round3Health, e1Round3Attack, e1Round3Defense, e1Round3Speed, true);
            e2Round3 = new Enemy(e2Round3Health, e2Round3Attack, e2Round3Defense, e2Round3Speed, true);
            bossRound3 = new Enemy(200, 10, 10, 10, true);

            // Round 4
            e1Round4 = new Enemy(e1Round4Health, e1Round4Attack, e1Round4Defense, e1Round4Speed, true);
            e2Round4 = new Enemy(e2Round4Health, e2Round4Attack, e2Round4Defense, e2Round4Speed, true);

            // Round 5
            e1Round5 = new Enemy(e1Round5Health, e1Round5Attack, e1Round5Defense, e1Round5Speed, true);
            e2Round5 = new Enemy(e2Round5Health, e2Round5Attack, e2Round5Defense, e2Round5Speed, true);

            // Round 6 
            e1Round6 = new Enemy(e1Round6Health, e1Round6Attack, e1Round6Defense, e1Round6Speed, true);
            e2Round6 = new Enemy(e2Round6Health, e2Round6Attack, e2Round6Defense, e2Round6Speed, true);
            e3Round6 = new Enemy(e3Round6Health, e3Round6Attack, e3Round6Defense, e3Round6Speed, true);

            // Round 7
            e1Round7 = new Enemy(e1Round7Health, e1Round7Attack, e1Round7Defense, e1Round7Speed, true);
            e2Round7 = new Enemy(e2Round7Health, e2Round7Attack, e2Round7Defense, e2Round7Speed, true);
            bossRound7 = new Enemy(100, 10, 10, 10, true);

            // Round 8 
            e1Round8 = new Enemy(e1Round8Health, e1Round8Attack, e1Round8Defense, e1Round8Speed, true);
            e2Round8 = new Enemy(e2Round8Health, e2Round8Attack, e2Round8Defense, e2Round8Speed, true);
            e3Round8 = new Enemy(e3Round8Health, e3Round8Attack, e3Round8Defense, e3Round8Speed, true);

            // Round 9
            e1Round9 = new Enemy(e1Round9Health, e1Round9Attack, e1Round9Defense, e1Round9Speed, true);
            e2Round9 = new Enemy(e2Round9Health, e2Round9Attack, e2Round9Defense, e2Round9Speed, true);
            e3Round9 = new Enemy(e3Round9Health, e3Round9Attack, e3Round9Defense, e3Round9Speed, true);

            // Round 10
            e1Round10 = new Enemy(e1Round10Health, e1Round10Attack, e1Round10Defense, e1Round10Speed, true);
            e2Round10 = new Enemy(e2Round10Health, e2Round10Attack, e2Round10Defense, e2Round10Speed, true);
            bossFinal = new Enemy(350, 10, 10, 10, true);

            // Setting the Difficulty to be normal when the game starts
            dstate = DifficultyStates.Normal;

            // Make mouse curson appear on screen
            this.IsMouseVisible = true;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            // Load in circles for intro
            bCircle = Content.Load<Texture2D>("Test Circle 1(Blue)");
            gCircle = Content.Load<Texture2D>("Test Circle 4(Green)");
            pCircle = Content.Load<Texture2D>("Test Circle 1(Pink)");
            wCircle = Content.Load<Texture2D>("Test Circle 1(White)");

            // Load in font
            font = Content.Load<SpriteFont>("SpriteFont1");

            // Load in BackGround
            GameBackground = Content.Load<Texture2D>("Background for GDAPS Game");

            // Load in TitleMusic
            TitleScreenMusic = Content.Load<SoundEffect>("GameTitle Music");

            // Load in buttons
            StartButton = Content.Load<Texture2D>("StartButton");
            CreditsButtons = Content.Load<Texture2D>("CreditsButton");
            OptionsButton = Content.Load<Texture2D>("OptionsButton");

            // Title for game 
            Title = Content.Load<Texture2D>("GameTitle");

            // Logo for intro
            Logo = Content.Load<Texture2D>("GameLogo");

            // Load in gStateBackground
            gStateBackground = Content.Load<Texture2D>("Game State background");

            // Load in Return button
            returnButton = Content.Load<Texture2D>("Return Button");

            // Load in charcters sprites
            geek = Content.Load<Texture2D>("Geek Character");
            alien = Content.Load<Texture2D>("Alien Character");
            jock = Content.Load<Texture2D>("Jock Charcater for game");
            cheerLeader = Content.Load<Texture2D>("CheerLeader Charcter for game");
            boss = Content.Load<Texture2D>("Boss Charcater for game");

            // Load in Charcater Menus
            geekMenu = Content.Load<Texture2D>("Menu for game(Geek)");
            jockMenu = Content.Load<Texture2D>("Menu for game(Jock)");
            cheerMenu = Content.Load<Texture2D>("Menu for game(CheerLeader)");

            // Load in the rest of the background
            StreetBackgroundRound4 = Content.Load<Texture2D>("Streer background1");
            StreetBackgroundRound5 = Content.Load<Texture2D>("Street Background2");
            StreetBackgroundRound6 = Content.Load<Texture2D>("Street background3");
            StreetBackgroundRound7 = Content.Load<Texture2D>("Street background4");
            OvalOffice = Content.Load<Texture2D>("oval office background");
            WhiteHouse = Content.Load<Texture2D>("whitehouse background");

            // Loading in the EarthSprite
            Texture2D EarthPic = Content.Load<Texture2D>("Earth for game");
            Earth = new EarthSprite(EarthPic, new Point(214, 160), 13, 4, 4, 100);

            // Doing the animation for all the Idle charcters
            // Nerd Idle
            Texture2D newNerd = Content.Load<Texture2D>("game stuff irwin idle");
            IdleNerd = new NerdIdleSprite(newNerd, new Point(320, 770), 2, 1, 2, 550);

            // Jock Idle
            Texture2D newJock = Content.Load<Texture2D>("game stuff biff idle");
            IdleJock = new JockIdleSprite(newJock, new Point(365, 860), 2, 1, 2, 550);

            // Cheer Idle
            Texture2D newCheer = Content.Load<Texture2D>("game stuff brit idle");
            IdleCheer = new CheerIdleSprite(newCheer, new Point(500, 865), 2, 1, 2, 550);

            // Enemy Idle
            Texture2D newEnemy = Content.Load<Texture2D>("game stuff alien idle");
            IdleEnemy = new EnemyIdleSprite(newEnemy, new Point(970, 1013), 2, 1, 2, 350);
            IdleEnemy2 = new Enemy2IdleSprite(newEnemy, new Point(970, 1013), 2, 1, 2, 350);
            IdleEnemy3 = new Enemy3IdleSprite(newEnemy, new Point(970, 1013), 2, 1, 2, 350);

            // Boss Idle
            Texture2D newBoss = Content.Load<Texture2D>("game stuff boss idle");
            IdleBoss = new BossIdleSprite(newBoss, new Point(1000, 1218), 2, 1, 2, 450);

            Texture2D DJock = Content.Load<Texture2D>("game stuff jock damage");
            DamageJock = new JockTakeDamage(DJock, new Point(440, 873), 2, 1, 2, 300);

            Texture2D DGeek = Content.Load<Texture2D>("game stuff irwin damage");
            DamageGeek = new GeekTakeDamage(DGeek, new Point(390, 790), 2, 1, 2, 300);

            Texture2D DCheer = Content.Load<Texture2D>("game stuff brit damage");
            DamageCheer = new CheerTakeDamage(DCheer, new Point(490, 865), 2, 1, 2, 300);

            // Round Display animation
            RD1 = Content.Load<Texture2D>("SpriteSheet Round1 Display");
            RDisplay = new RoundDisplay(RD1, new Point(864, 200), 21, 4, 6, 150);
            RD2 = Content.Load<Texture2D>("SpriteSheet Round 2 Display");
            RDisplay2 = new RoundDisplay2(RD2, new Point(864, 200), 21, 4, 6, 150);
            RD3 = Content.Load<Texture2D>("SpriteSheet Round 3 Display");
            RDisplay3 = new RoundDisplay3(RD3, new Point(864, 200), 21, 4, 6, 150);
            RD4 = Content.Load<Texture2D>("SpriteSheet Round 4 Display");
            RDisplay4 = new RoundDisplay4(RD4, new Point(864, 200), 21, 4, 6, 150);
            RD5 = Content.Load<Texture2D>("SpriteSheet Round 5 Display");
            RDisplay5 = new RoundDisplay5(RD5, new Point(864, 200), 21, 4, 6, 150);
            RD6 = Content.Load<Texture2D>("SpriteSheet Round 6 Display");
            RDisplay6 = new RoundDisplay6(RD6, new Point(864, 200), 21, 4, 6, 150);
            RD7 = Content.Load<Texture2D>("SpriteSheet Round 7 Display");
            RDisplay7 = new RoundDisplay7(RD7, new Point(864, 200), 21, 4, 6, 150);
            RD8 = Content.Load<Texture2D>("SpriteSheet Round 8 Display");
            RDisplay8 = new RoundDisplay8(RD8, new Point(864, 200), 21, 4, 6, 150);
            RD9 = Content.Load<Texture2D>("SpriteSheet Round 9 Display");
            RDisplay9 = new RoundDisplay9(RD9, new Point(864, 200), 21, 4, 6, 150);
            RD10 = Content.Load<Texture2D>("SpriteSheet Round 10 Display");
            RDisplay10 = new RoundDisplay10(RD10, new Point(864, 200), 21, 4, 6, 150);

            // Load in Music
            GameTitleMusic = Content.Load<Song>("Game TitleScreen Music.wav");
            GameCombatMusic = Content.Load<Song>("Game Combat music.wav");
            GameLoadScreenMusic = Content.Load<Song>("Game LoadScreen Music1.wav");

            // Load in options screen buttons
            EasyButton = Content.Load<Texture2D>("Easy Button");
            EasyButtonOff = Content.Load<Texture2D>("Easy-Off Button");

            NormalButton = Content.Load<Texture2D>("Normal Button");
            NormalButtonOff = Content.Load<Texture2D>("Normal-Off Button");

            NightmareButton = Content.Load<Texture2D>("Nightmare Button");
            NightmareButtonOff = Content.Load<Texture2D>("Nightmare-Off Button");

            MusicOnButton = Content.Load<Texture2D>("Music-On Button");
            MusicOffButton = Content.Load<Texture2D>("Music-Off Button");

            // Load in Options Screen Text
            DifficultyText = Content.Load<Texture2D>("Difficulty Text");
            ToggleMusicText = Content.Load<Texture2D>("Toggle-Music Text");

            // Load in Pre-Battle Text;
            PreBattleText = Content.Load<Texture2D>("Pre-Battle Text");
            PreBattleText2 = Content.Load<Texture2D>("Pre-Battle Text-2");

            // Load in GameOver Scrren Text
            RoundReachedText = Content.Load<Texture2D>("Round Reached Text");
            Round1Text = Content.Load<Texture2D>("Round 1 text");
            Round2Text = Content.Load<Texture2D>("Round 2 Text");
            Round3Text = Content.Load<Texture2D>("Round 3 Text");
            Round4Text = Content.Load<Texture2D>("Round 4 Text");
            Round5Text = Content.Load<Texture2D>("Round 5 Text");
            Round6Text = Content.Load<Texture2D>("Round 6 Text");
            Round7Text = Content.Load<Texture2D>("Round 7 Text");
            Round8Text = Content.Load<Texture2D>("Round 8 Text");
            Round9Text = Content.Load<Texture2D>("Round 9 Text");
            Round10Text = Content.Load<Texture2D>("Round 10 Text");
            GameOverText = Content.Load<Texture2D>("Game Over text");

            // Load in all the letters for the story menu

            hyphen = Content.Load<Texture2D>("-");

            // Load in story menu
            storyMenu = Content.Load<Texture2D>("Story Menu");

            // Load in Text for Story
            storyText1 = Content.Load<Texture2D>("story");
            storyText2 = Content.Load<Texture2D>("more story");
            storyText3 = Content.Load<Texture2D>("story2");
            storyText4 = Content.Load<Texture2D>("story3");
            storyText5 = Content.Load<Texture2D>("story4");
            storyText6 = Content.Load<Texture2D>("story5");
            hello = Content.Load<Texture2D>("Hello");
            welcome = Content.Load<Texture2D>("Welcome");

            credits = Content.Load<Texture2D>("TAYSCredits");
            // Load in the Instructions
            Instructions = Content.Load<Texture2D>("I-Screen");
            MediaPlayer.IsRepeating = true;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            LastmState = mState;
            mState = Mouse.GetState();
            kState = Keyboard.GetState();
            // Update for each state
            switch (gState)
            {
                case GameStates.Intro:
                    UpdateIntro(gameTime);
                    break;

                case GameStates.TitleScreen:
                    UpdateTitleScreen(gameTime);
                    this.IsMouseVisible = true;
                    break;

                case GameStates.Options:
                    UpdateOptions(gameTime);
                    this.IsMouseVisible = true;
                    break;

                case GameStates.Credits:
                    UpdateCredits(gameTime);
                    this.IsMouseVisible = true;
                    break;

                case GameStates.Game:
                    UpdateGame(gameTime);
                    this.IsMouseVisible = true;
                    break;

                case GameStates.LoadScreen:
                    UpdateLoadScreen(gameTime);
                    break;

                case GameStates.StoryIntro:
                    UpdateStoryIntro(gameTime);
                    break;

                case GameStates.PreBattle:
                    UpdatePreBattle(gameTime);
                    break;

                case GameStates.GameOver:
                    UpdateGameOver(gameTime);
                    break;

                case GameStates.Instructions:
                    UpdateInstructions(gameTime);
                    break;
            }

            if(kState.IsKeyDown(Keys.Enter) == true)
            {
                gState = GameStates.TitleScreen;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);

            // Draw for each state
            switch (gState)
            {
                case GameStates.Intro:
                    DrawIntro(gameTime);
                    break;

                case GameStates.TitleScreen:
                    DrawTitleScreen(gameTime);
                    break;

                case GameStates.Options:
                    DrawOptions(gameTime);
                    break;

                case GameStates.Credits:
                    DrawCredits(gameTime);
                    break;

                case GameStates.Game:
                    DrawGame(gameTime);
                    break;

                case GameStates.LoadScreen:
                    DrawLoadScreen(gameTime);
                    break;

                case GameStates.StoryIntro:
                    DrawStoryIntro(gameTime);
                    break;

                case GameStates.PreBattle:
                    DrawPreBattle(gameTime);
                    break;

                case GameStates.GameOver:
                    DrawGameOver(gameTime);
                    break;

                case GameStates.Instructions:
                    DrawInstructions(gameTime);
                    break;
            }

        }

        // Update for the load screen

        // Update Methos for each state
        protected void UpdateIntro(GameTime gameTime)
        {
            TitleScreenMusic.Play();
            BluePosition.X += 2;
            GreenPosition.X -= 2;
            PurplePosition.Y += .95f;
            this.IsMouseVisible = false;

            // Collide If statement for intro
            if (Collide())
            {
                System.Threading.Thread.Sleep(2500);
                gState = GameStates.TitleScreen;
            }
        }

        protected void UpdateTitleScreen(GameTime gameTime)
        {
            if(musicOn == true)
            {
                if (TitleMusicCounter == 960)
                {
                    MediaPlayer.Play(GameTitleMusic);
                }
                TitleMusicCounter -= 1;
                if (TitleMusicCounter < 0)
                {
                    MediaPlayer.Play(GameTitleMusic);
                    TitleMusicCounter = 960;
                }
            }
            TitleScreenInput();
        }

        protected void UpdateOptions(GameTime gameTime)
        {
            if (TitleMusicCounter == 960)
            {
                MediaPlayer.Play(GameTitleMusic);
            }
            TitleMusicCounter -= 1;
            if (TitleMusicCounter < 0)
            {
                MediaPlayer.Play(GameTitleMusic);
                TitleMusicCounter = 960;
            }

            // For Easy Button
            if (mState.X >= 850 && mState.X <= 1100 && mState.Y >= 500 && mState.Y < 600 && mState.LeftButton == ButtonState.Pressed && LastmState.LeftButton != mState.LeftButton)
            {
                dstate = DifficultyStates.Easy;

                FileLoader();

                e1Round1 = new Enemy(e1Round1Health, e1Round1Attack, e1Round1Defense, e1Round1Speed, true);
                e2Round1 = new Enemy(e2Round1Health, e2Round1Attack, e2Round1Defense, e2Round1Speed, true);

                e1Round2 = new Enemy(e1Round2Health, e1Round2Attack, e1Round2Defense, e1Round2Speed, true);
                e2Round2 = new Enemy(e2Round2Health, e1Round2Attack, e1Round2Defense, e1Round2Speed, true);

                // Round 3
                e1Round3 = new Enemy(e1Round3Health, e1Round3Attack, e1Round3Defense, e1Round3Speed, true);
                e2Round3 = new Enemy(e2Round3Health, e2Round3Attack, e2Round3Defense, e2Round3Speed, true);
                bossRound3 = new Enemy(200, 10, 10, 10, true);

                // Round 4
                e1Round4 = new Enemy(e1Round4Health, e1Round4Attack, e1Round4Defense, e1Round4Speed, true);
                e2Round4 = new Enemy(e2Round4Health, e2Round4Attack, e2Round4Defense, e2Round4Speed, true);

                // Round 5
                e1Round5 = new Enemy(e1Round5Health, e1Round5Attack, e1Round5Defense, e1Round5Speed, true);
                e2Round5 = new Enemy(e2Round5Health, e2Round5Attack, e2Round5Defense, e2Round5Speed, true);

                // Round 6 
                e1Round6 = new Enemy(e1Round6Health, e1Round6Attack, e1Round6Defense, e1Round6Speed, true);
                e2Round6 = new Enemy(e2Round6Health, e2Round6Attack, e2Round6Defense, e2Round6Speed, true);
                e3Round6 = new Enemy(e3Round6Health, e3Round6Attack, e3Round6Defense, e3Round6Speed, true);

                // Round 7
                e1Round7 = new Enemy(e1Round7Health, e1Round7Attack, e1Round7Defense, e1Round7Speed, true);
                e2Round7 = new Enemy(e2Round7Health, e2Round7Attack, e2Round7Defense, e2Round7Speed, true);
                bossRound7 = new Enemy(100, 10, 10, 10, true);

                // Round 8 
                e1Round8 = new Enemy(e1Round8Health, e1Round8Attack, e1Round8Defense, e1Round8Speed, true);
                e2Round8 = new Enemy(e2Round8Health, e2Round8Attack, e2Round8Defense, e2Round8Speed, true);
                e3Round8 = new Enemy(e3Round8Health, e3Round8Attack, e3Round8Defense, e3Round8Speed, true);

                // Round 9
                e1Round9 = new Enemy(e1Round9Health, e1Round9Attack, e1Round9Defense, e1Round9Speed, true);
                e2Round9 = new Enemy(e2Round9Health, e2Round9Attack, e2Round9Defense, e2Round9Speed, true);
                e3Round9 = new Enemy(e3Round9Health, e3Round9Attack, e3Round9Defense, e3Round9Speed, true);

                // Round 10
                e1Round10 = new Enemy(e1Round10Health, e1Round10Attack, e1Round10Defense, e1Round10Speed, true);
                e2Round10 = new Enemy(e2Round10Health, e2Round10Attack, e2Round10Defense, e2Round10Speed, true);
                bossFinal = new Enemy(350, 10, 10, 10, true);
            }
            // For Normal Button
            if (mState.X >= 1200 && mState.X <= 1450 && mState.Y >= 500 && mState.Y < 600 && mState.LeftButton == ButtonState.Pressed && LastmState.LeftButton != mState.LeftButton)
            {
                dstate = DifficultyStates.Normal;
                FileLoader();

                e1Round1 = new Enemy(e1Round1Health, e1Round1Attack, e1Round1Defense, e1Round1Speed, true);
                e2Round1 = new Enemy(e2Round1Health, e2Round1Attack, e2Round1Defense, e2Round1Speed, true);

                e1Round2 = new Enemy(e1Round2Health, e1Round2Attack, e1Round2Defense, e1Round2Speed, true);
                e2Round2 = new Enemy(e2Round2Health, e1Round2Attack, e1Round2Defense, e1Round2Speed, true);

                // Round 3
                e1Round3 = new Enemy(e1Round3Health, e1Round3Attack, e1Round3Defense, e1Round3Speed, true);
                e2Round3 = new Enemy(e2Round3Health, e2Round3Attack, e2Round3Defense, e2Round3Speed, true);

                // Round 4
                e1Round4 = new Enemy(e1Round4Health, e1Round4Attack, e1Round4Defense, e1Round4Speed, true);
                e2Round4 = new Enemy(e2Round4Health, e2Round4Attack, e2Round4Defense, e2Round4Speed, true);

                // Round 5
                e1Round5 = new Enemy(e1Round5Health, e1Round5Attack, e1Round5Defense, e1Round5Speed, true);
                e2Round5 = new Enemy(e2Round5Health, e2Round5Attack, e2Round5Defense, e2Round5Speed, true);

                // Round 6 
                e1Round6 = new Enemy(e1Round6Health, e1Round6Attack, e1Round6Defense, e1Round6Speed, true);
                e2Round6 = new Enemy(e2Round6Health, e2Round6Attack, e2Round6Defense, e2Round6Speed, true);
                e3Round6 = new Enemy(e3Round6Health, e3Round6Attack, e3Round6Defense, e3Round6Speed, true);

                // Round 7
                e1Round7 = new Enemy(e1Round7Health, e1Round7Attack, e1Round7Defense, e1Round7Speed, true);
                e2Round7 = new Enemy(e2Round7Health, e2Round7Attack, e2Round7Defense, e2Round7Speed, true);

                // Round 8 
                e1Round8 = new Enemy(e1Round8Health, e1Round8Attack, e1Round8Defense, e1Round8Speed, true);
                e2Round8 = new Enemy(e2Round8Health, e2Round8Attack, e2Round8Defense, e2Round8Speed, true);
                e3Round8 = new Enemy(e3Round8Health, e3Round8Attack, e3Round8Defense, e3Round8Speed, true);

                // Round 9
                e1Round9 = new Enemy(e1Round9Health, e1Round9Attack, e1Round9Defense, e1Round9Speed, true);
                e2Round9 = new Enemy(e2Round9Health, e2Round9Attack, e2Round9Defense, e2Round9Speed, true);
                e3Round9 = new Enemy(e3Round9Health, e3Round9Attack, e3Round9Defense, e3Round9Speed, true);

                // Round 10
                e1Round10 = new Enemy(e1Round10Health, e1Round10Attack, e1Round10Defense, e1Round10Speed, true);
                e2Round10 = new Enemy(e2Round10Health, e2Round10Attack, e2Round10Defense, e2Round10Speed, true);
            }

            // For Nightmare Button
            if (mState.X >= 1550 && mState.X <= 1800 && mState.Y >= 500 && mState.Y < 600 && mState.LeftButton == ButtonState.Pressed && LastmState.LeftButton != mState.LeftButton)
            {
                dstate = DifficultyStates.Nightmare;
                FileLoader();

                e1Round1 = new Enemy(e1Round1Health, e1Round1Attack, e1Round1Defense, e1Round1Speed, true);
                e2Round1 = new Enemy(e2Round1Health, e2Round1Attack, e2Round1Defense, e2Round1Speed, true);

                e1Round2 = new Enemy(e1Round2Health, e1Round2Attack, e1Round2Defense, e1Round2Speed, true);
                e2Round2 = new Enemy(e2Round2Health, e1Round2Attack, e1Round2Defense, e1Round2Speed, true);

                // Round 3
                e1Round3 = new Enemy(e1Round3Health, e1Round3Attack, e1Round3Defense, e1Round3Speed, true);
                e2Round3 = new Enemy(e2Round3Health, e2Round3Attack, e2Round3Defense, e2Round3Speed, true);

                // Round 4
                e1Round4 = new Enemy(e1Round4Health, e1Round4Attack, e1Round4Defense, e1Round4Speed, true);
                e2Round4 = new Enemy(e2Round4Health, e2Round4Attack, e2Round4Defense, e2Round4Speed, true);

                // Round 5
                e1Round5 = new Enemy(e1Round5Health, e1Round5Attack, e1Round5Defense, e1Round5Speed, true);
                e2Round5 = new Enemy(e2Round5Health, e2Round5Attack, e2Round5Defense, e2Round5Speed, true);

                // Round 6 
                e1Round6 = new Enemy(e1Round6Health, e1Round6Attack, e1Round6Defense, e1Round6Speed, true);
                e2Round6 = new Enemy(e2Round6Health, e2Round6Attack, e2Round6Defense, e2Round6Speed, true);
                e3Round6 = new Enemy(e3Round6Health, e3Round6Attack, e3Round6Defense, e3Round6Speed, true);

                // Round 7
                e1Round7 = new Enemy(e1Round7Health, e1Round7Attack, e1Round7Defense, e1Round7Speed, true);
                e2Round7 = new Enemy(e2Round7Health, e2Round7Attack, e2Round7Defense, e2Round7Speed, true);

                // Round 8 
                e1Round8 = new Enemy(e1Round8Health, e1Round8Attack, e1Round8Defense, e1Round8Speed, true);
                e2Round8 = new Enemy(e2Round8Health, e2Round8Attack, e2Round8Defense, e2Round8Speed, true);
                e3Round8 = new Enemy(e3Round8Health, e3Round8Attack, e3Round8Defense, e3Round8Speed, true);

                // Round 9
                e1Round9 = new Enemy(e1Round9Health, e1Round9Attack, e1Round9Defense, e1Round9Speed, true);
                e2Round9 = new Enemy(e2Round9Health, e2Round9Attack, e2Round9Defense, e2Round9Speed, true);
                e3Round9 = new Enemy(e3Round9Health, e3Round9Attack, e3Round9Defense, e3Round9Speed, true);

                // Round 10
                e1Round10 = new Enemy(e1Round10Health, e1Round10Attack, e1Round10Defense, e1Round10Speed, true);
                e2Round10 = new Enemy(e2Round10Health, e2Round10Attack, e2Round10Defense, e2Round10Speed, true);
            }

            // For music Button
            if (mState.X >= 1200 && mState.X <= 1450 && mState.Y >= 95 && mState.Y < 200 && mState.LeftButton == ButtonState.Pressed && LastmState.LeftButton != mState.LeftButton && musicOn == true)
            {
                musicOn = false;
            }
            else if (mState.X >= 1200 && mState.X <= 1450 && mState.Y >= 95 && mState.Y < 200 && mState.LeftButton == ButtonState.Pressed && LastmState.LeftButton != mState.LeftButton && musicOn == false)
            {
                musicOn = true;
            }



            //GameTitleMusic.Play();
            ReturnButtonInput();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        protected void UpdateCredits(GameTime gameTime)
        {
            if (TitleMusicCounter == 960)
            {
                MediaPlayer.Play(GameTitleMusic);
            }
            TitleMusicCounter -= 1;
            if (TitleMusicCounter < 0)
            {
                MediaPlayer.Play(GameTitleMusic);
                TitleMusicCounter = 960;
            }

            //MediaPlayer.Play(GameTitleMusic);
            ReturnButtonInput();
        }

        protected void UpdateGame(GameTime gameTime)
        {
            TitleMusicCounter = 0;
           
            if (CombatMusicCouter == 1965)
            {
                MediaPlayer.Play(GameCombatMusic);
            }
            CombatMusicCouter -= 1;
            if (CombatMusicCouter <= 0)
            {
                MediaPlayer.Play(GameTitleMusic);
                CombatMusicCouter = 1965;
            }

            IdleNerd.Update(gameTime);
            IdleJock.Update(gameTime);
            IdleCheer.Update(gameTime);
            IdleBoss.Update(gameTime);
            IdleEnemy.Update(gameTime);
            IdleEnemy2.Update(gameTime);
            IdleEnemy3.Update(gameTime);

            // Switch statement for round1 turns
            if (round == 1)
            {
                if(musicOn == true)
                {
                    TitleMusicCounter = 0;

                    if (CombatMusicCouter == 1965)
                    {
                        MediaPlayer.Play(GameCombatMusic);
                    }
                    CombatMusicCouter -= 1;
                    if (CombatMusicCouter <= 0)
                    {
                        MediaPlayer.Play(GameCombatMusic);
                        CombatMusicCouter = 1965;
                    }
                }

                switch (round1State)
                {
                    case Round1States.NerdTurn:
                        if (nerd.GHealth != 0)
                        {
                            NerdCombat();
                        }
                        else if (nerd.GHealth == 0)
                        {
                            round1State = Round1States.EnemyTurn;
                        }
                        break;

                    case Round1States.EnemyTurn:
                        if (e1Round1.EHealth != 0)
                        {
                            enemyCombat();
                        }
                        else if (e1Round1.EHealth == 0)
                        {
                            round1State = Round1States.JockTurn;
                        }
                        break;
                    case Round1States.JockTurn:
                        if (football.JHealth != 0)
                        {
                            JockCombat();
                        }
                        else if (football.JHealth == 0)
                        {
                            round1State = Round1States.CheerTurn;
                        }
                        break;
                    case Round1States.CheerTurn:
                        if (cheer.CHealth != 0)
                        {
                            CheerCombat();
                        }
                        else if (cheer.CHealth == 0)
                        {
                            round1State = Round1States.Enemy2Turn;
                        }
                        break;
                    case Round1States.Enemy2Turn:
                        if (e2Round1.EHealth != 0)
                        {
                            enemyCombat2();
                        }
                        else if (e2Round1.EHealth == 0)
                        {
                            round1State = Round1States.NerdTurn;
                        }
                        break;

                }
                if (e1Round1.EHealth == 0 && e2Round1.EHealth == 0)
                {
                    gState = GameStates.LoadScreen;
                }
                if(nerd.GHealth == 0 && football.JHealth == 0 && cheer.CHealth == 0)
                {
                    gState = GameStates.GameOver;
                }
            }
            if (round == 2)
            {
                LoadScreenMusicCounter = 0;
            
                if (musicOn == true)
                {
                    TitleMusicCounter = 0;

                    if (CombatMusicCouter == 1965)
                    {
                        MediaPlayer.Play(GameCombatMusic);
                    }
                    CombatMusicCouter -= 1;
                    if (CombatMusicCouter <= 0)
                    {
                        MediaPlayer.Play(GameCombatMusic);
                        CombatMusicCouter = 1965;
                    }
                }

                // Switch for round2 turns
                switch (round2State)
                {
                    case Round2States.EnemyTurn:
                        if (e1Round2.EHealth != 0)
                        {
                            enemyCombat();
                        }
                        else if (e1Round2.EHealth == 0)
                        {
                            round2State = Round2States.JockTurn;
                        }
                        break;

                    case Round2States.JockTurn:
                        if (football.JHealth != 0)
                        {
                            JockCombat();
                        }
                        else if (football.JHealth == 0)
                        {
                            round2State = Round2States.NerdTurn;
                        }
                        break;
                    case Round2States.NerdTurn:
                        if (nerd.GHealth != 0)
                        {
                            NerdCombat();
                        }
                        else if (nerd.GHealth == 0)
                        {
                            round2State = Round2States.Enemy2Turn;
                        }
                        break;
                    case Round2States.Enemy2Turn:
                        if (e2Round2.EHealth != 0)
                        {
                            enemyCombat2();
                        }
                        else if (e2Round2.EHealth == 0)
                        {
                            round2State = Round2States.CheertTurn;
                        }
                        break;
                    case Round2States.CheertTurn:
                        if (cheer.CHealth != 0)
                        {
                            CheerCombat();
                        }
                        else if (cheer.CHealth == 0)
                        {
                            round2State = Round2States.EnemyTurn;
                        }
                        break;
                }
                if (e1Round2.EHealth == 0 && e2Round2.EHealth == 0)
                {
                    gState = GameStates.LoadScreen;
                }
                if (nerd.GHealth == 0 && football.JHealth == 0 && cheer.CHealth == 0)
                {
                    gState = GameStates.GameOver;
                }
            }

            if (round == 3)
            {

                LoadScreenMusicCounter = 0;

                if (musicOn == true)
                {
                    TitleMusicCounter = 0;

                    if (CombatMusicCouter == 1965)
                    {
                        MediaPlayer.Play(GameCombatMusic);
                    }
                    CombatMusicCouter -= 1;
                    if (CombatMusicCouter <= 0)
                    {
                        MediaPlayer.Play(GameCombatMusic);
                        CombatMusicCouter = 1965;
                    }
                }

                // Swtch statement for round 3
                switch (round3State)
                {
                    case Round3States.CheerTurn:
                        if (cheer.CHealth != 0)
                        {
                            CheerCombat();
                        }
                        else if (cheer.CHealth == 0)
                        {
                            round3State = Round3States.NerdTurn;
                        }
                        break;

                    case Round3States.NerdTurn:
                        if (nerd.GHealth != 0)
                        {
                            NerdCombat();
                        }
                        if (nerd.GHealth == 0)
                        {
                            round3State = Round3States.EnemyTurn;
                        }
                        break;
                    case Round3States.EnemyTurn:
                        if (e1Round3.EHealth != 0)
                        {
                            enemyCombat();
                        }
                        else if (e1Round3.EHealth == 0)
                        {
                            round3State = Round3States.JockTurn;
                        }
                        break;
                    case Round3States.JockTurn:
                        if (football.JHealth != 0)
                        {
                            JockCombat();
                        }
                        else if (football.JHealth == 0)
                        {
                            round3State = Round3States.Enemy2Turn;
                        }
                        break;
                    case Round3States.Enemy2Turn:
                        if (e2Round3.EHealth != 0)
                        {
                            enemyCombat2();
                        }
                        else if (e2Round3.EHealth == 0)
                        {
                            round3State = Round3States.BossTurn;
                        }
                        break;
                    case Round3States.BossTurn:
                        if (bossRound3.EHealth != 0)
                        {
                            BossCombat();
                        }
                        else if (bossRound3.EHealth == 0)
                        {
                            round3State = Round3States.CheerTurn;
                        }
                        break;
                }
                if (e1Round3.EHealth == 0 && e2Round3.EHealth == 0 && bossRound3.EHealth == 0)
                {
                    if (cheer.IsAlive == false)
                    {
                        cheer.IsAlive = true;
                    }
                    if (football.IsAlive == false)
                    {
                        football.IsAlive = true;
                    }
                    if (nerd.IsAlive == false)
                    {
                        nerd.IsAlive = true; ;
                    }

                    cheer.CHealth += 30;
                    nerd.GHealth += 30;
                    football.JHealth += 30;


                    if (cheer.CHealth > 150)
                    {
                        cheer.CHealth = 150;
                    }
                    if (football.JHealth > 225)
                    {
                        football.JHealth = 225;
                    }
                    if (nerd.GHealth > 350)
                    {
                        nerd.GHealth = 350;
                    }

                    gState = GameStates.LoadScreen;
                }
                if (nerd.GHealth == 0 && football.JHealth == 0 && cheer.CHealth == 0)
                {
                    gState = GameStates.GameOver;
                }
            }

            if (round == 4)
            {

                LoadScreenMusicCounter = 0;

                if (musicOn == true)
                {
                    TitleMusicCounter = 0;

                    if (CombatMusicCouter == 1965)
                    {
                        MediaPlayer.Play(GameCombatMusic);
                    }
                    CombatMusicCouter -= 1;
                    if (CombatMusicCouter <= 0)
                    {
                        MediaPlayer.Play(GameCombatMusic);
                        CombatMusicCouter = 1965;
                    }
                }

                // Swtch statement for round4
                switch (round4State)
                {
                    case Round4States.Enemy2Turn:
                        if (e2Round4.EHealth != 0)
                        {
                            enemyCombat2();
                        }
                        else if (e2Round4.EHealth == 0)
                        {
                            round4State = Round4States.CheerTurn;
                        }
                        break;

                    case Round4States.CheerTurn:
                        if (cheer.CHealth != 0)
                        {
                            CheerCombat();
                        }
                        else if (cheer.CHealth == 0)
                        {
                            round4State = Round4States.EnemyTurn;
                        }
                        break;
                    case Round4States.EnemyTurn:
                        if (e1Round4.EHealth != 0)
                        {
                            enemyCombat();
                        }
                        else if (e1Round4.EHealth == 0)
                        {
                            round4State = Round4States.NerdTurn;
                        }
                        break;
                    case Round4States.NerdTurn:
                        if (nerd.GHealth != 0)
                        {
                            NerdCombat();
                        }
                        else if (nerd.GHealth == 0)
                        {
                            round4State = Round4States.JockTurn;
                        }
                        break;
                    case Round4States.JockTurn:
                        if (football.JHealth != 0)
                        {
                            JockCombat();
                        }
                        else if (football.JHealth == 0)
                        {
                            round4State = Round4States.Enemy2Turn;
                        }
                        break;
                }
                if (e1Round4.EHealth == 0 && e2Round4.EHealth == 0)
                {
                    gState = GameStates.LoadScreen;
                }
                if (nerd.GHealth == 0 && football.JHealth == 0 && cheer.CHealth == 0)
                {
                    gState = GameStates.GameOver;
                }
            }
            if (round == 5)
            {

                LoadScreenMusicCounter = 0;

                if (musicOn == true)
                {
                    TitleMusicCounter = 0;

                    if (CombatMusicCouter == 1965)
                    {
                        MediaPlayer.Play(GameCombatMusic);
                    }
                    CombatMusicCouter -= 1;
                    if (CombatMusicCouter <= 0)
                    {
                        MediaPlayer.Play(GameCombatMusic);
                        CombatMusicCouter = 1965;
                    }
                }

                // Swtch stament for round 5
                switch (round5State)
                {
                    case Round5States.NerdTurn:
                        if (nerd.GHealth != 0)
                        {
                            NerdCombat();
                        }
                        else if (nerd.GHealth == 0)
                        {
                            round5State = Round5States.Enemy2Turn;
                        }
                        break;

                    case Round5States.Enemy2Turn:
                        if (e2Round5.EHealth != 0)
                        {
                            enemyCombat2();
                        }
                        else if (e2Round5.EHealth == 0)
                        {
                            round5State = Round5States.JockTurn;
                        }
                        break;
                    case Round5States.JockTurn:
                        if (football.JHealth != 0)
                        {
                            JockCombat();
                        }
                        else if (football.JHealth == 0)
                        {
                            round5State = Round5States.EnemyTurn;
                        }
                        break;
                    case Round5States.EnemyTurn:
                        if (e1Round5.EHealth != 0)
                        {
                            enemyCombat();
                        }
                        else if (e1Round5.EHealth == 0)
                        {
                            round5State = Round5States.CheerTurn;
                        }
                        break;
                    case Round5States.CheerTurn:
                        if (cheer.CHealth != 0)
                        {
                            CheerCombat();
                        }
                        else if (cheer.CHealth == 0)
                        {
                            round5State = Round5States.NerdTurn;
                        }
                        break;
                }
                if (e1Round5.EHealth == 0 && e2Round5.EHealth == 0)
                {
                    gState = GameStates.LoadScreen;
                }
                if (nerd.GHealth == 0 && football.JHealth == 0 && cheer.CHealth == 0)
                {
                    gState = GameStates.GameOver;
                }
            }

            if (round == 6)
            {

                LoadScreenMusicCounter = 0;

                if (musicOn == true)
                {
                    TitleMusicCounter = 0;

                    if (CombatMusicCouter == 1965)
                    {
                        MediaPlayer.Play(GameCombatMusic);
                    }
                    CombatMusicCouter -= 1;
                    if (CombatMusicCouter <= 0)
                    {
                        MediaPlayer.Play(GameCombatMusic);
                        CombatMusicCouter = 1965;
                    }
                }

                // Swtch statement for round6
                switch (round6State)
                {
                    case Round6States.Enemy3Turn:
                        if (e3Round6.EHealth != 0)
                        {
                            EnemyCombat3();
                        }
                        else if (e3Round6.EHealth == 0)
                        {
                            round6State = Round6States.NerdTurn;
                        }
                        break;

                    case Round6States.NerdTurn:
                        if (nerd.GHealth != 0)
                        {
                            NerdCombat();
                        }
                        else if (nerd.GHealth == 0)
                        {
                            round6State = Round6States.Enemy2Turn;
                        }
                        break;
                    case Round6States.Enemy2Turn:
                        if (e2Round6.EHealth != 0)
                        {
                            enemyCombat2();
                        }
                        else if (e2Round6.EHealth == 0)
                        {
                            round6State = Round6States.JockTurn;
                        }
                        break;
                    case Round6States.JockTurn:
                        if (football.JHealth != 0)
                        {
                            JockCombat();
                        }
                        else if (football.JHealth == 0)
                        {
                            round6State = Round6States.CheerTurn;
                        }
                        break;
                    case Round6States.CheerTurn:
                        if (cheer.CHealth != 0)
                        {
                            CheerCombat();
                        }
                        else if (cheer.CHealth == 0)
                        {
                            round6State = Round6States.EnemyTurn;
                        }
                        break;
                    case Round6States.EnemyTurn:
                        if (e1Round6.EHealth != 0)
                        {
                            enemyCombat();
                        }
                        else if (e1Round6.EHealth == 0)
                        {
                            round6State = Round6States.Enemy3Turn;
                        }
                        break;
                }
                if (e1Round6.EHealth == 0 && e2Round6.EHealth == 0 && e3Round6.EHealth == 0)
                {
                    gState = GameStates.LoadScreen;
                }
                if (nerd.GHealth == 0 && football.JHealth == 0 && cheer.CHealth == 0)
                {
                    gState = GameStates.GameOver;
                }
            }

            if (round == 7)
            {

                LoadScreenMusicCounter = 0;

                if (musicOn == true)
                {
                    TitleMusicCounter = 0;

                    if (CombatMusicCouter == 1965)
                    {
                        MediaPlayer.Play(GameCombatMusic);
                    }
                    CombatMusicCouter -= 1;
                    if (CombatMusicCouter <= 0)
                    {
                        MediaPlayer.Play(GameCombatMusic);
                        CombatMusicCouter = 1965;
                    }
                }

                // Swtch statement for round7
                switch (round7State)
                {
                    case Round7States.BossTurn:
                        if (bossRound7.EHealth != 0)
                        {
                            BossCombat();
                        }
                        else if (bossRound7.EHealth == 0)
                        {
                            round7State = Round7States.CheerTurn;
                        }
                        break;

                    case Round7States.CheerTurn:
                        if (cheer.CHealth != 0)
                        {
                            CheerCombat();
                        }
                        else if (cheer.CHealth <= 0)
                        {
                            round7State = Round7States.NerdTurn;
                        }
                        break;
                    case Round7States.NerdTurn:
                        if (nerd.GHealth != 0)
                        {
                            NerdCombat();
                        }
                        else if (nerd.GHealth <= 0)
                        {
                            round7State = Round7States.EnemyTurn;
                        }
                        break;
                    case Round7States.EnemyTurn:
                        if (e1Round7.EHealth != 0)
                        {
                            enemyCombat();
                        }
                        else if (e1Round7.EHealth <= 0)
                        {
                            round7State = Round7States.Enemy2Turn;
                        }
                        break;
                    case Round7States.Enemy2Turn:
                        if (e2Round7.EHealth != 0)
                        {
                            enemyCombat2();
                        }
                        else if (e2Round7.EHealth <= 0)
                        {
                            round7State = Round7States.JockTurn;
                        }
                        break;
                    case Round7States.JockTurn:
                        if (football.JHealth != 0)
                        {
                            JockCombat();
                        }
                        else if (football.JHealth <= 0)
                        {
                            round7State = Round7States.BossTurn;
                        }
                        break;
                }
                if (e1Round7.EHealth == 0 && e2Round7.EHealth == 0 && bossRound7.EHealth == 0)
                {
                    if (cheer.IsAlive == false)
                    {
                        cheer.IsAlive = true;
                    }
                    if (football.IsAlive == false)
                    {
                        football.IsAlive = true;
                    }
                    if (nerd.IsAlive == false)
                    {
                        nerd.IsAlive = true;
                    }

                    cheer.CHealth += 30;
                    nerd.GHealth += 30;
                    football.JHealth += 30;

                    if(cheer.CHealth > 150)
                    {
                        cheer.CHealth = 150;
                    }
                    if(football.JHealth > 225)
                    {
                        football.JHealth = 225;
                    }
                    if(nerd.GHealth > 350)
                    {
                        nerd.GHealth = 350;
                    }

                    gState = GameStates.LoadScreen;
                }
                if (nerd.GHealth == 0 && football.JHealth == 0 && cheer.CHealth == 0)
                {
                    gState = GameStates.GameOver;
                }
            }

            if (round == 8)
            {

                LoadScreenMusicCounter = 0;

                if (musicOn == true)
                {
                    TitleMusicCounter = 0;

                    if (CombatMusicCouter == 1965)
                    {
                        MediaPlayer.Play(GameCombatMusic);
                    }
                    CombatMusicCouter -= 1;
                    if (CombatMusicCouter <= 0)
                    {
                        MediaPlayer.Play(GameCombatMusic);
                        CombatMusicCouter = 1965;
                    }
                }

                // Swtch statement for round8
                switch (round8State)
                {
                    case Round8States.JockTurn:
                        if (football.JHealth != 0)
                        {
                            JockCombat();
                        }
                        else if (football.JHealth == 0)
                        {
                            round8State = Round8States.Enemy2Turn;
                        }
                        break;

                    case Round8States.Enemy2Turn:
                        if (e2Round8.EHealth != 0)
                        {
                            enemyCombat2();
                        }
                        else if (e2Round8.EHealth == 0)
                        {
                            round8State = Round8States.Enemy3Turn;
                        }
                        break;
                    case Round8States.Enemy3Turn:
                        if (e3Round8.EHealth != 0)
                        {
                            EnemyCombat3();
                        }
                        else if (e3Round8.EHealth == 0)
                        {
                            round8State = Round8States.NerdTurn;
                        }
                        break;
                    case Round8States.NerdTurn:
                        if (nerd.GHealth != 0)
                        {
                            NerdCombat();
                        }
                        else if (nerd.GHealth == 0)
                        {
                            round8State = Round8States.EnemyTurn;
                        }
                        break;
                    case Round8States.EnemyTurn:
                        if (e1Round8.EHealth != 0)
                        {
                            enemyCombat();
                        }
                        else if (e1Round8.EHealth == 0)
                        {
                            round8State = Round8States.CheerTurn;
                        }
                        break;
                    case Round8States.CheerTurn:
                        if (cheer.CHealth != 0)
                        {
                            CheerCombat();
                        }
                        else if (cheer.CHealth == 0)
                        {
                            round8State = Round8States.JockTurn;
                        }
                        break;
                }
                if (e1Round8.EHealth == 0 && e2Round8.EHealth == 0 && e3Round8.EHealth == 0)
                {
                    gState = GameStates.LoadScreen;
                }
                if (nerd.GHealth == 0 && football.JHealth == 0 && cheer.CHealth == 0)
                {
                    gState = GameStates.GameOver;
                }
            }

            if (round == 9)
            {

                LoadScreenMusicCounter = 0;

                if (musicOn == true)
                {
                    TitleMusicCounter = 0;

                    if (CombatMusicCouter == 1965)
                    {
                        MediaPlayer.Play(GameCombatMusic);
                    }
                    CombatMusicCouter -= 1;
                    if (CombatMusicCouter <= 0)
                    {
                        MediaPlayer.Play(GameCombatMusic);
                        CombatMusicCouter = 1965;
                    }
                }

                // Swtch statement for round 9
                switch (round9State)
                {
                    case Round9States.NerdTurn:
                        if (nerd.GHealth != 0)
                        {
                            NerdCombat();
                        }
                        else if (nerd.GHealth == 0)
                        {
                            round9State = Round9States.CheerTurn;
                        }
                        break;

                    case Round9States.CheerTurn:
                        if (cheer.CHealth != 0)
                        {
                            CheerCombat();
                        }
                        else if (cheer.CHealth == 0)
                        {
                            round9State = Round9States.Enemy2Turn;
                        }
                        break;
                    case Round9States.Enemy2Turn:
                        if (e2Round9.EHealth != 0)
                        {
                            enemyCombat2();
                        }
                        else if (e2Round9.EHealth == 0)
                        {
                            round9State = Round9States.Enemy3Turn;
                        }
                        break;
                    case Round9States.Enemy3Turn:
                        if (e3Round9.EHealth != 0)
                        {
                            EnemyCombat3();
                        }
                        else if (e3Round9.EHealth == 0)
                        {
                            round9State = Round9States.JockTurn;
                        }
                        break;
                    case Round9States.JockTurn:
                        if (football.JHealth != 0)
                        {
                            JockCombat();
                        }
                        else if (football.JHealth == 0)
                        {
                            round9State = Round9States.EnemyTurn;
                        }
                        break;
                    case Round9States.EnemyTurn:
                        if (e1Round9.EHealth != 0)
                        {
                            enemyCombat();
                        }
                        else if (e1Round9.EHealth == 0)
                        {
                            round9State = Round9States.NerdTurn;
                        }
                        break;
                }
                if (e1Round9.EHealth == 0 && e2Round9.EHealth == 0 && e3Round9.EHealth == 0)
                {
                    gState = GameStates.LoadScreen;
                }
                if (nerd.GHealth == 0 && football.JHealth == 0 && cheer.CHealth == 0)
                {
                    gState = GameStates.GameOver;
                }
            }
            if (round == 10)
            {

                LoadScreenMusicCounter = 0;

                if (musicOn == true)
                {
                    TitleMusicCounter = 0;

                    if (CombatMusicCouter == 1965)
                    {
                        MediaPlayer.Play(GameCombatMusic);
                    }
                    CombatMusicCouter -= 1;
                    if (CombatMusicCouter <= 0)
                    {
                        MediaPlayer.Play(GameCombatMusic);
                        CombatMusicCouter = 1965;
                    }
                }

                // Swtch statement for round10
                switch (round10State)
                {
                    case Round10States.BossTurn:
                        if (bossFinal.EHealth != 0)
                        {
                            BossCombat();
                        }
                        else if (bossFinal.EHealth == 0)
                        {
                            round10State = Round10States.JockTurn;
                        }
                        break;

                    case Round10States.JockTurn:
                        if (football.JHealth != 0)
                        {
                            JockCombat();
                        }
                        else if (football.JHealth == 0)
                        {
                            round10State = Round10States.Enemy2Turn;
                        }
                        break;
                    case Round10States.Enemy2Turn:
                        if (e2Round10.EHealth != 0)
                        {
                            enemyCombat2();
                        }
                        else if (e2Round10.EHealth == 0)
                        {
                            round10State = Round10States.CheerTurn;
                        }
                        break;
                    case Round10States.CheerTurn:
                        if (cheer.CHealth != 0)
                        {
                            CheerCombat();
                        }
                        else if (cheer.CHealth == 0)
                        {
                            round10State = Round10States.EnemyTurn;
                        }
                        break;
                    case Round10States.EnemyTurn:
                        if (e1Round10.EHealth != 0)
                        {
                            enemyCombat();
                        }
                        else if (e1Round10.EHealth == 0)
                        {
                            round10State = Round10States.NerdTurn;
                        }
                        break;
                    case Round10States.NerdTurn:
                        if (nerd.GHealth != 0)
                        {
                            NerdCombat();
                        }
                        else if (nerd.GHealth == 0)
                        {
                            round10State = Round10States.BossTurn;
                        }
                        break;
                }
                if (e1Round10.EHealth == 0 && e2Round10.EHealth == 0 && bossFinal.EHealth == 0)
                {
                    gState = GameStates.Credits;
                }
                if (nerd.GHealth == 0 && football.JHealth == 0 && cheer.CHealth == 0)
                {
                    gState = GameStates.GameOver;
                }
            }



        }
        protected void UpdateLoadScreen(GameTime gameTime)
        {
            if (LoadScreenMusicCounter == 1440)
            {
                MediaPlayer.Play(GameLoadScreenMusic);
            }
            LoadScreenMusicCounter -= 1;
            if (LoadScreenMusicCounter < 0)
            {
                MediaPlayer.Play(GameLoadScreenMusic);
                LoadScreenMusicCounter = 1440;
            }

            Earth.Update(gameTime);
            if (Earth.Loop == 3)
            {
                gState = GameStates.PreBattle;
                round++;
                Earth.Loop = 0;
                LoadScreenMusicCounter = 0;
                MediaPlayer.Stop();
                MediaPlayer.Play(GameCombatMusic);
            }
        }

        protected void UpdateStoryIntro(GameTime gameTime)
        {
            StoryTimer += .1;

            if(StoryTimer >= 261.50)
            {
                gState = GameStates.PreBattle;
                StoryTimer = 0;
            }
        }

        protected void UpdatePreBattle(GameTime gameTime)
        {
            preBattleTimer++;

            if(round == 1)
            {
                if (RDisplay.Stop == 0)
                {
                    RDisplay.UpdateRound1(gameTime);
                }
            }

            if(round == 2)
            {
                if (RDisplay2.Stop == 0)
                {
                    RDisplay2.Update(gameTime);
                }
            }

            if(round == 3)
            {
                if (RDisplay3.Stop == 0)
                {
                    RDisplay3.Update(gameTime);
                }

            }
            if(round == 4)
            {
                if (RDisplay4.Stop == 0)
                {
                    RDisplay4.Update(gameTime);
                }
            }
            if(round == 5)
            {
                if (RDisplay5.Stop == 0)
                {
                    RDisplay5.Update(gameTime);
                }

            }

            if(round == 6)
            {
                if (RDisplay6.Stop == 0)
                {
                    RDisplay6.Update(gameTime);
                }
            }

            if(round == 7)
            {
                if (RDisplay7.Stop == 0)
                {
                    RDisplay7.Update(gameTime);
                }
            }
            if(round == 8)
            {
                if (RDisplay8.Stop == 0)
                {
                    RDisplay8.Update(gameTime);
                }
            }

            if(round == 9)
            {
                if (RDisplay9.Stop == 0)
                {
                    RDisplay9.Update(gameTime);
                }
            }
            if(round == 10)
            {
                if (RDisplay10.Stop == 0)
                {
                    RDisplay10.Update(gameTime);
                }
            }

            if (preBattleTimer == 480)
            {
                gState = GameStates.Game;
                preBattleTimer = 0;
            }
        }

        protected void UpdateGameOver(GameTime gameTime)
        {
            gameOverTimer++;

            if(gameOverTimer < 360)
            {
                gameOverHeight += 2;
                gameOverWidth += 4;
            }

            if(gameOverTimer == 720)
            {
                gState = GameStates.Credits;
                gameOverTimer = 0;

                gameOverWidth = 0;
                gameOverHeight = 0;
            }
        }

        protected void UpdateInstructions(GameTime gameTime)
        {
            instructionsTimer++;

            if(instructionsTimer == 1200)
            {
                gState = GameStates.StoryIntro;
                instructionsTimer = 0;
            }
        }

        // Draw Methods for each state
        protected void DrawIntro(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            spriteBatch.Draw(bCircle, BluePosition, Color.White);
            spriteBatch.Draw(gCircle, GreenPosition, Color.White);
            spriteBatch.Draw(pCircle, PurplePosition, Color.White);
            spriteBatch.Draw(wCircle, WhitePosition, Color.White);

            spriteBatch.Draw(Logo, new Rectangle((int)LogoPosition.X, (int)LogoPosition.Y, 350, 300), Color.White);


            spriteBatch.End();
        }

        protected void DrawTitleScreen(GameTime gameTime)
        {
            spriteBatch.Begin();
            // Draws Background to the screen
            spriteBatch.Draw(GameBackground, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
            spriteBatch.Draw(Title, TitlePosition, Color.White);
            spriteBatch.Draw(StartButton, startBPosition, Color.White);
            spriteBatch.Draw(CreditsButtons, creditsBPosition, Color.White);
            spriteBatch.Draw(OptionsButton, optionsBPosition, Color.White);

            // Mouse Position test
            // spriteBatch.DrawString(font, "Current X position for mouse: " + mState.X + " Y: " + mState.Y, new Vector2(20, 50), Color.Black);
            spriteBatch.End();
        }


        protected void DrawOptions(GameTime gameTime)
        {
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.Green);
            spriteBatch.Draw(returnButton, returnBPosition, Color.White);

            if(dstate == DifficultyStates.Easy)
            {
                spriteBatch.Draw(EasyButton, new Rectangle((int)800, (int)400, 350, 300), Color.White);
            }
            else
            {
                spriteBatch.Draw(EasyButtonOff, new Rectangle((int)800, (int)400, 350, 300), Color.White);
            }
            if(dstate == DifficultyStates.Normal)
            {
                spriteBatch.Draw(NormalButton, new Rectangle((int)1150, (int)400, 350, 300), Color.White);
            }
            else
            {
                spriteBatch.Draw(NormalButtonOff, new Rectangle((int)1150, (int)400, 350, 300), Color.White);
            }
            if(dstate == DifficultyStates.Nightmare)
            {
                spriteBatch.Draw(NightmareButton, new Rectangle((int)1500, (int)400, 350, 300), Color.White);
            }
            else
            {
                spriteBatch.Draw(NightmareButtonOff, new Rectangle((int)1500, (int)400, 350, 300), Color.White);
            }

            if(musicOn == true)
            {
                spriteBatch.Draw(MusicOnButton, new Rectangle((int)1150, (int)0, 350, 300), Color.White);
            }
            else
            {
                spriteBatch.Draw(MusicOffButton, new Rectangle((int)1150, (int)0, 350, 300), Color.White);
            }

            spriteBatch.Draw(ToggleMusicText, new Rectangle((int)-80, (int)-280, 1000, 800), Color.White);

            spriteBatch.Draw(DifficultyText, new Rectangle((int)-155, (int)140, 1000, 800), Color.White);


            spriteBatch.DrawString(font, "Current X position for mouse: " + mState.X + " Y: " + mState.Y, new Vector2(20, 50), Color.Black);
            // Game intrutions for the player to see
            /*spriteBatch.DrawString(font, "Hello player, the game you are playing is a turn based action RPG set in the real world(but with a couple of changes)", new Vector2(GraphicsDevice.Viewport.Width / 4, 20), Color.Black);
            spriteBatch.DrawString(font, "The game is a point and click style type of game so thwe only thing that you are goping to need is a mouse and you wits!!!", new Vector2(GraphicsDevice.Viewport.Width / 4, 40), Color.Black);
            spriteBatch.DrawString(font, "As the player you will control three different types of characters that are all different and have unique stats.", new Vector2(GraphicsDevice.Viewport.Width / 4, 60), Color.Black);
            spriteBatch.DrawString(font, "Your mission is to defeat all the enemies that you find and defeat the boss to win the game and save the world", new Vector2(GraphicsDevice.Viewport.Width / 4, 80), Color.Black);*/
            spriteBatch.End();
        }

        protected void DrawCredits(GameTime gameTime)
        {
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.Black);
            // Writing the credits to the screen
            spriteBatch.Draw(credits, new Vector2(0, 0), Color.White);

            spriteBatch.Draw(returnButton, returnBPosition, Color.White);
            spriteBatch.End();
        }

        protected void DrawGame(GameTime gameTime)
        {
            spriteBatch.Begin();
            // Draw for round 1
            if (round == 1)
            {
                spriteBatch.Draw(gStateBackground, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                RDisplay.DrawRound1(gameTime, spriteBatch);

                if (nerd.IsAlive == true)
                {
                    //spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
                    IdleNerd.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Nerd Health: " + nerd.GHealth, new Vector2(510, 750), Color.Black);
                }
                if (e1Round1.IsAlive == true)
                {
                    //spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X, (int)positionAlien.Y, 600, 425), Color.White);
                    IdleEnemy2.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Enemy Health: " + e1Round1.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 340, 750), Color.Black);
                }
                if (e2Round1.IsAlive == true)
                {
                    //spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 400, (int)positionAlien.Y, 600, 425), Color.White);
                    IdleEnemy.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Enemy Health: " + e2Round1.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 700, 750), Color.Black);
                }
                if (football.IsAlive == true)
                {
                    //spriteBatch.Draw(jock, new Rectangle((int)positionJock.X, (int)positionJock.Y, 290, 400), Color.White);
                    IdleJock.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Jock Health: " + football.JHealth, new Vector2(270, 750), Color.Black);
                }
                if (cheer.IsAlive == true)
                {
                    //spriteBatch.Draw(cheerLeader, new Rectangle((int)positionCheerLeader.X, (int)positionCheerLeader.Y, 270, 350), Color.White);
                    IdleCheer.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "CheerLeader Health: " + cheer.CHealth, new Vector2(0, 750), Color.Black);
                }
                if (round1State == Round1States.NerdTurn)
                {
                    spriteBatch.Draw(geekMenu, geekMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + nerd.GAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.SpecialMax, new Vector2(969, 873), Color.Black);
                }
                else if (round1State == Round1States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + football.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + football.SpecialMax, new Vector2(969, 873), Color.Black);
                }
                else if (round1State == Round1States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.SpecialMax, new Vector2(969, 873), Color.Black);
                }
            }

            // Draw for round 2
            if (round == 2)
            {
                spriteBatch.Draw(gStateBackground, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                RDisplay2.Draw(gameTime, spriteBatch);

                if (nerd.IsAlive == true)
                {
                    //spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
                    IdleNerd.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Nerd Health: " + nerd.GHealth, new Vector2(510, 750), Color.Black);
                }
                if (e1Round2.IsAlive == true)
                {
                    //spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X, (int)positionAlien.Y, 600, 425), Color.White);
                    IdleEnemy2.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Enemy Health: " + e1Round2.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 340, 750), Color.Black);
                }
                if (e2Round2.IsAlive == true)
                {
                    //spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 400, (int)positionAlien.Y, 600, 425), Color.White);
                    IdleEnemy.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Enemy Health: " + e2Round2.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 700, 750), Color.Black);
                }
                if (football.IsAlive == true)
                {
                    //spriteBatch.Draw(jock, new Rectangle((int)positionJock.X, (int)positionJock.Y, 290, 400), Color.White);
                    IdleJock.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Jock Health: " + football.JHealth, new Vector2(270, 750), Color.Black);
                }
                if (cheer.IsAlive == true)
                {
                    //spriteBatch.Draw(cheerLeader, new Rectangle((int)positionCheerLeader.X, (int)positionCheerLeader.Y, 270, 350), Color.White);
                    IdleCheer.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "CheerLeader Health: " + cheer.CHealth, new Vector2(0, 750), Color.Black);
                }

                if (round2State == Round2States.NerdTurn)
                {
                    spriteBatch.Draw(geekMenu, geekMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + nerd.GAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.SpecialMax, new Vector2(969, 873), Color.Black);
                }
                else if (round2State == Round2States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + football.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + football.SpecialMax, new Vector2(969, 873), Color.Black);
                }
                else if (round2State == Round2States.CheertTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.SpecialMax, new Vector2(969, 873), Color.Black);
                }
            }

            // Draw for round 3
            if (round == 3)
            {
                spriteBatch.Draw(gStateBackground, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                RDisplay3.Draw(gameTime, spriteBatch);

                if (nerd.IsAlive == true)
                {
                    //spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
                    IdleNerd.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Nerd Health: " + nerd.GHealth, new Vector2(510, 750), Color.Black);
                }
                if (e1Round3.IsAlive == true)
                {
                    //spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 245, (int)positionAlien.Y + 200, 400, 225), Color.White);
                    IdleEnemy2.DrawMini(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Enemy Health: " + e1Round3.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 660, 750), Color.Black);
                }
                if (e2Round3.IsAlive == true)
                {
                    //spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 520, (int)positionAlien.Y + 200, 400, 225), Color.White);
                    IdleEnemy.DrawMini(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Enemy Health: " + e2Round3.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 940, 750), Color.Black);
                }
                if (football.IsAlive == true)
                {
                    //spriteBatch.Draw(jock, new Rectangle((int)positionJock.X, (int)positionJock.Y, 290, 400), Color.White);
                    IdleJock.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Jock Health: " + football.JHealth, new Vector2(270, 750), Color.Black);
                }
                if (cheer.IsAlive == true)
                {
                    //spriteBatch.Draw(cheerLeader, new Rectangle((int)positionCheerLeader.X, (int)positionCheerLeader.Y, 270, 350), Color.White);
                    IdleCheer.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "CheerLeader Health: " + cheer.CHealth, new Vector2(0, 750), Color.Black);
                }
                if (bossRound3.IsAlive == true)
                {
                    //spriteBatch.Draw(boss, new Rectangle((int)positionAlien.X - 80, (int)positionAlien.Y - 175, 700, 600), Color.White);
                    IdleBoss.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Boss Health: " + bossRound3.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 390, 750), Color.Black);
                }

                if (round3State == Round3States.NerdTurn)
                {
                    spriteBatch.Draw(geekMenu, geekMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + nerd.GAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.SpecialMax, new Vector2(969, 873), Color.Black);
                }
                else if (round3State == Round3States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + football.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + football.SpecialMax, new Vector2(969, 873), Color.Black);
                }
                else if (round3State == Round3States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.SpecialMax, new Vector2(969, 873), Color.Black);
                }
            }

            if (round == 4)
            {
                spriteBatch.Draw(StreetBackgroundRound4, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                RDisplay4.Draw(gameTime, spriteBatch);

                if (nerd.IsAlive == true)
                {
                    //spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
                    IdleNerd.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Nerd Health: " + nerd.GHealth, new Vector2(510, 750), Color.Black);
                }
                if (e1Round4.IsAlive == true)
                {
                    //spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X, (int)positionAlien.Y, 600, 425), Color.White);
                    IdleEnemy2.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Enemy Health: " + e1Round4.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 340, 750), Color.Black);
                }
                if (e2Round4.IsAlive == true)
                {
                    //spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 400, (int)positionAlien.Y, 600, 425), Color.White);
                    IdleEnemy.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Enemy Health: " + e2Round4.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 700, 750), Color.Black);
                }
                if (football.IsAlive == true)
                {
                    //spriteBatch.Draw(jock, new Rectangle((int)positionJock.X, (int)positionJock.Y, 290, 400), Color.White);
                    IdleJock.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Jock Health: " + football.JHealth, new Vector2(270, 750), Color.Black);
                }
                if (cheer.IsAlive == true)
                {
                    //spriteBatch.Draw(cheerLeader, new Rectangle((int)positionCheerLeader.X, (int)positionCheerLeader.Y, 270, 350), Color.White);
                    IdleCheer.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "CheerLeader Health: " + cheer.CHealth, new Vector2(0, 750), Color.Black);
                }

                if (round4State == Round4States.NerdTurn)
                {
                    spriteBatch.Draw(geekMenu, geekMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + nerd.GAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.SpecialMax, new Vector2(969, 873), Color.Black);
                }
                else if (round4State == Round4States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + football.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + football.SpecialMax, new Vector2(969, 873), Color.Black);
                }
                else if (round4State == Round4States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.SpecialMax, new Vector2(969, 873), Color.Black);
                }
            }

            if (round == 5)
            {
                spriteBatch.Draw(StreetBackgroundRound5, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                RDisplay5.Draw(gameTime, spriteBatch);

                if (nerd.IsAlive == true)
                {
                    //spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
                    IdleNerd.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Nerd Health: " + nerd.GHealth, new Vector2(510, 750), Color.Black);
                }
                if (e1Round5.IsAlive == true)
                {
                    //spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X, (int)positionAlien.Y, 600, 425), Color.White);
                    IdleEnemy2.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Enemy Health: " + e1Round5.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 340, 750), Color.Black);
                }
                if (e2Round5.IsAlive == true)
                {
                    //spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 400, (int)positionAlien.Y, 600, 425), Color.White);
                    IdleEnemy.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Enemy Health: " + e2Round5.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 700, 750), Color.Black);
                }
                if (football.IsAlive == true)
                {
                    //spriteBatch.Draw(jock, new Rectangle((int)positionJock.X, (int)positionJock.Y, 290, 400), Color.White);
                    IdleJock.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Jock Health: " + football.JHealth, new Vector2(270, 750), Color.Black);
                }
                if (cheer.IsAlive == true)
                {
                    //spriteBatch.Draw(cheerLeader, new Rectangle((int)positionCheerLeader.X, (int)positionCheerLeader.Y, 270, 350), Color.White);
                    IdleCheer.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "CheerLeader Health: " + cheer.CHealth, new Vector2(0, 750), Color.Black);
                }

                if (round5State == Round5States.NerdTurn)
                {
                    spriteBatch.Draw(geekMenu, geekMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + nerd.GAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.SpecialMax, new Vector2(969, 873), Color.Black);
                }
                else if (round5State == Round5States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + football.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + football.SpecialMax, new Vector2(969, 873), Color.Black);
                }
                else if (round5State == Round5States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.SpecialMax, new Vector2(969, 873), Color.Black);
                }
            }

            if (round == 6)
            {
                spriteBatch.Draw(StreetBackgroundRound6, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                RDisplay6.Draw(gameTime, spriteBatch);

                if (nerd.IsAlive == true)
                {
                    //spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
                    IdleNerd.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Nerd Health: " + nerd.GHealth, new Vector2(510, 750), Color.Black);
                }
                if (e1Round6.IsAlive == true)
                {
                    //spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 115, (int)positionAlien.Y - 120, 450, 550), Color.White);
                    IdleEnemy2.DrawTall(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Enemy Health 1: " + e1Round6.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 500, 750), Color.Black);
                }
                if (e2Round6.IsAlive == true)
                {
                    //spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 420, (int)positionAlien.Y - 120, 450, 550), Color.White);
                    IdleEnemy.DrawTall(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Enemy Health 2: " + e2Round6.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 820, 750), Color.Black);
                }
                if (football.IsAlive == true)
                {
                    //spriteBatch.Draw(jock, new Rectangle((int)positionJock.X, (int)positionJock.Y, 290, 400), Color.White);
                    IdleJock.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Jock Health: " + football.JHealth, new Vector2(270, 750), Color.Black);
                }
                if (cheer.IsAlive == true)
                {
                    //spriteBatch.Draw(cheerLeader, new Rectangle((int)positionCheerLeader.X, (int)positionCheerLeader.Y, 270, 350), Color.White);
                    IdleCheer.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "CheerLeader Health: " + cheer.CHealth, new Vector2(0, 750), Color.Black);
                }
                if (e3Round6.IsAlive == true)
                {
                    //spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X + 180, (int)positionAlien.Y - 120, 450, 550), Color.White);
                    IdleEnemy3.DrawTall(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Enemy Health 3: " + e3Round6.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 220, 750), Color.Black);
                }

                if (round6State == Round6States.NerdTurn)
                {
                    spriteBatch.Draw(geekMenu, geekMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + nerd.GAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.SpecialMax, new Vector2(969, 873), Color.Black);
                }
                else if (round6State == Round6States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + football.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + football.SpecialMax, new Vector2(969, 873), Color.Black);
                }
                else if (round6State == Round6States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.SpecialMax, new Vector2(969, 873), Color.Black);
                }
            }

            if (round == 7)
            {
                spriteBatch.Draw(StreetBackgroundRound7, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                RDisplay7.Draw(gameTime, spriteBatch);

                if (nerd.IsAlive == true)
                {
                    //spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
                    IdleNerd.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Nerd Health: " + nerd.GHealth, new Vector2(510, 750), Color.Black);
                }
                if (e1Round7.IsAlive == true)
                {
                    //spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 245, (int)positionAlien.Y + 200, 400, 225), Color.White);
                    IdleEnemy2.DrawMini(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Enemy Health: " + e1Round7.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 660, 750), Color.Black);
                }
                if (e2Round7.IsAlive == true)
                {
                    //spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 520, (int)positionAlien.Y + 200, 400, 225), Color.White);
                    IdleEnemy.DrawMini(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Enemy Health: " + e2Round7.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 940, 750), Color.Black);
                }
                if (football.IsAlive == true)
                {
                    //spriteBatch.Draw(jock, new Rectangle((int)positionJock.X, (int)positionJock.Y, 290, 400), Color.White);
                    IdleJock.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Jock Health: " + football.JHealth, new Vector2(270, 750), Color.Black);
                }
                if (cheer.IsAlive == true)
                {
                    //spriteBatch.Draw(cheerLeader, new Rectangle((int)positionCheerLeader.X, (int)positionCheerLeader.Y, 270, 350), Color.White);
                    IdleCheer.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "CheerLeader Health: " + cheer.CHealth, new Vector2(0, 750), Color.Black);
                }
                if (bossRound7.IsAlive == true)
                {
                    //spriteBatch.Draw(boss, new Rectangle((int)positionAlien.X - 80, (int)positionAlien.Y - 175, 700, 600), Color.White);
                    IdleBoss.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Boss Health: " + bossRound7.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 390, 750), Color.Black);
                }

                if (round7State == Round7States.NerdTurn)
                {
                    spriteBatch.Draw(geekMenu, geekMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + nerd.GAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.SpecialMax, new Vector2(969, 873), Color.Black);
                }
                else if (round7State == Round7States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + football.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + football.SpecialMax, new Vector2(969, 873), Color.Black);
                }
                else if (round7State == Round7States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.SpecialMax, new Vector2(969, 873), Color.Black);
                }
            }

            if (round == 8)
            {
                spriteBatch.Draw(StreetBackgroundRound7, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                RDisplay8.Draw(gameTime, spriteBatch);

                if (nerd.IsAlive == true)
                {
                    //spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
                    IdleNerd.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Nerd Health: " + nerd.GHealth, new Vector2(510, 750), Color.Black);
                }
                if (e1Round8.IsAlive == true)
                {
                    //spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 115, (int)positionAlien.Y - 120, 450, 550), Color.White);
                    IdleEnemy2.DrawTall(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Enemy Health 1: " + e1Round8.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 500, 750), Color.Black);
                }
                if (e2Round8.IsAlive == true)
                {
                    //spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 420, (int)positionAlien.Y - 120, 450, 550), Color.White);
                    IdleEnemy.DrawTall(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Enemy Health 2: " + e2Round8.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 820, 750), Color.Black);
                }
                if (football.IsAlive == true)
                {
                    //spriteBatch.Draw(jock, new Rectangle((int)positionJock.X, (int)positionJock.Y, 290, 400), Color.White);
                    IdleJock.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Jock Health: " + football.JHealth, new Vector2(270, 750), Color.Black);
                }
                if (cheer.IsAlive == true)
                {
                    //spriteBatch.Draw(cheerLeader, new Rectangle((int)positionCheerLeader.X, (int)positionCheerLeader.Y, 270, 350), Color.White);
                    IdleCheer.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "CheerLeader Health: " + cheer.CHealth, new Vector2(0, 750), Color.Black);
                }
                if (e3Round8.IsAlive == true)
                {
                    //spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X + 180, (int)positionAlien.Y - 120, 450, 550), Color.White);
                    IdleEnemy3.DrawTall(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Enemy Health 3: " + e3Round8.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 220, 750), Color.Black);
                }

                if (round8State == Round8States.NerdTurn)
                {
                    spriteBatch.Draw(geekMenu, geekMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + nerd.GAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.SpecialMax, new Vector2(969, 873), Color.Black);
                }
                else if (round8State == Round8States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + football.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + football.SpecialMax, new Vector2(969, 873), Color.Black);
                }
                else if (round8State == Round8States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.SpecialMax, new Vector2(969, 873), Color.Black);
                }
            }

            if (round == 9)
            {
                spriteBatch.Draw(WhiteHouse, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                RDisplay9.Draw(gameTime, spriteBatch);

                if (nerd.IsAlive == true)
                {
                    //spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
                    IdleNerd.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Nerd Health: " + nerd.GHealth, new Vector2(510, 750), Color.Black);
                }
                if (e1Round9.IsAlive == true)
                {
                    //spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 115, (int)positionAlien.Y - 120, 450, 550), Color.White);
                    IdleEnemy2.DrawTall(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Enemy Health 1: " + e1Round9.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 500, 750), Color.Black);
                }
                if (e2Round9.IsAlive == true)
                {
                    //spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 420, (int)positionAlien.Y - 120, 450, 550), Color.White);
                    IdleEnemy.DrawTall(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Enemy Health 2: " + e2Round9.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 820, 750), Color.Black);
                }
                if (football.IsAlive == true)
                {
                    //spriteBatch.Draw(jock, new Rectangle((int)positionJock.X, (int)positionJock.Y, 290, 400), Color.White);
                    IdleJock.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Jock Health: " + football.JHealth, new Vector2(270, 750), Color.Black);
                }
                if (cheer.IsAlive == true)
                {
                    //spriteBatch.Draw(cheerLeader, new Rectangle((int)positionCheerLeader.X, (int)positionCheerLeader.Y, 270, 350), Color.White);
                    IdleCheer.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "CheerLeader Health: " + cheer.CHealth, new Vector2(0, 750), Color.Black);
                }
                if (e3Round9.IsAlive == true)
                {
                    //spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X + 180, (int)positionAlien.Y - 120, 450, 550), Color.White);
                    IdleEnemy3.DrawTall(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Enemy Health 3: " + e3Round9.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 220, 750), Color.Black);
                }

                if (round9State == Round9States.NerdTurn)
                {
                    spriteBatch.Draw(geekMenu, geekMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + nerd.GAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.SpecialMax, new Vector2(969, 873), Color.Black);
                }
                else if (round9State == Round9States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + football.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + football.SpecialMax, new Vector2(969, 873), Color.Black);
                }
                else if (round9State == Round9States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.SpecialMax, new Vector2(969, 873), Color.Black);
                }
            }

            if (round == 10)
            {
                spriteBatch.Draw(OvalOffice, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                RDisplay10.Draw(gameTime, spriteBatch);

                if (nerd.IsAlive == true)
                {
                    //spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
                    IdleNerd.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Nerd Health: " + nerd.GHealth, new Vector2(510, 750), Color.Black);
                }
                if (e1Round10.IsAlive == true)
                {
                    //spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 245, (int)positionAlien.Y + 200, 400, 225), Color.White);
                    IdleEnemy2.DrawMini(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Enemy Health: " + e1Round10.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 660, 750), Color.Black);
                }
                if (e2Round10.IsAlive == true)
                {
                    //spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 520, (int)positionAlien.Y + 200, 400, 225), Color.White);
                    IdleEnemy.DrawMini(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Enemy Health: " + e2Round10.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 940, 750), Color.Black);
                }
                if (football.IsAlive == true)
                {
                    //spriteBatch.Draw(jock, new Rectangle((int)positionJock.X, (int)positionJock.Y, 290, 400), Color.White);
                    IdleJock.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Jock Health: " + football.JHealth, new Vector2(270, 750), Color.Black);
                }
                if (cheer.IsAlive == true)
                {
                    //spriteBatch.Draw(cheerLeader, new Rectangle((int)positionCheerLeader.X, (int)positionCheerLeader.Y, 270, 350), Color.White);
                    IdleCheer.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "CheerLeader Health: " + cheer.CHealth, new Vector2(0, 750), Color.Black);
                }
                if (bossFinal.IsAlive == true)
                {
                    //spriteBatch.Draw(boss, new Rectangle((int)positionAlien.X - 80, (int)positionAlien.Y - 175, 700, 600), Color.White);
                    IdleBoss.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Boss Health: " + bossFinal.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 390, 750), Color.Black);
                }

                if (round10State == Round10States.NerdTurn)
                {
                    spriteBatch.Draw(geekMenu, geekMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + nerd.GAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.SpecialMax, new Vector2(969, 873), Color.Black);
                }
                else if (round10State == Round10States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + football.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + football.SpecialMax, new Vector2(969, 873), Color.Black);
                }
                else if (round10State == Round10States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(445, 867), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(445, 910), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(445, 953), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CHealth, new Vector2(900, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CMaxHealth, new Vector2(969, 819), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.SpecialMeter, new Vector2(900, 873), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.SpecialMax, new Vector2(969, 873), Color.Black);
                }
            }
            //spriteBatch.DrawString(font, "Current X position for mouse: " + mState.X + " Y: " + mState.Y, new Vector2(20, 50), Color.Black);
            spriteBatch.End();
        }

        protected void DrawLoadScreen(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            Earth.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        protected void DrawStoryIntro(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            spriteBatch.Draw(storyMenu, new Rectangle(-200, 510,2300,600), Color.White);
            if(StoryTimer > .00 && StoryTimer <= .90 )
            {
                spriteBatch.Draw(hyphen, new Vector2(150, 775), Color.White);
            }
            else if(StoryTimer > 1.54 && StoryTimer <= 2.46)
            {
                spriteBatch.Draw(hyphen, new Vector2(150, 775), Color.White);
            }
            else if(StoryTimer > 3.52 && StoryTimer <= 3.96)
            {
                spriteBatch.Draw(hyphen, new Vector2(150, 775), Color.White);
            }
            else if(StoryTimer > 4.64 && StoryTimer <= 5.04)
            {
                spriteBatch.Draw(hyphen, new Vector2(150, 775), Color.White);
            }
            else if(StoryTimer > 5.70 && StoryTimer <= 6.00)
            {
                spriteBatch.Draw(hyphen, new Vector2(150, 775), Color.White);
            }
            if (StoryTimer > 6.62 && StoryTimer <= 7.10)
            {
                spriteBatch.Draw(hyphen, new Vector2(150, 775), Color.White);
            }
            else if (StoryTimer > 7.72 && StoryTimer <= 8.14)
            {
                spriteBatch.Draw(hyphen, new Vector2(150, 775), Color.White);
            }
            else if (StoryTimer > 8.76 && StoryTimer <= 9.10)
            {
                spriteBatch.Draw(hyphen, new Vector2(150, 775), Color.White);
            }
            else if (StoryTimer > 9.80 && StoryTimer <= 10.30)
            {
                spriteBatch.Draw(hyphen, new Vector2(150, 775), Color.White);
            }
            else if (StoryTimer > 10.90 && StoryTimer <= 11.40)
            {
                spriteBatch.Draw(hyphen, new Vector2(150, 775), Color.White);
            }


            if(StoryTimer > 11.50 && StoryTimer <= 35.00)
            {
                spriteBatch.Draw(hello, new Vector2(50, 525), Color.White);
            }

            if(StoryTimer > 36.00 && StoryTimer <= 55.00)
            {
                spriteBatch.Draw(welcome, new Vector2(150, 545), Color.White);
            }

            if(StoryTimer > 56.00 && StoryTimer <= 72.00)
            {
                spriteBatch.Draw(storyText1, new Vector2(150, 535), Color.White);
            }

            if(StoryTimer > 73.00 && StoryTimer <= 89.00)
            {
                spriteBatch.Draw(storyText2, new Vector2(150, 565), Color.White);
            }

            if(StoryTimer > 90.00 && StoryTimer <= 105.00)
            {
                spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X -700, (int)positionAlien.Y -200, 600, 450), Color.White);
                spriteBatch.Draw(storyText3, new Vector2(150, 535), Color.White);
            }

            if(StoryTimer > 106.00 && StoryTimer <= 121.00)
            {
                spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X -700, (int)positionAlien.Y -200, 600, 450), Color.White);
                spriteBatch.Draw(storyText4, new Vector2(150, 525), Color.White);
            }

            if (StoryTimer > 162.00 && StoryTimer <= 224.00)
            {
                spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X + 500, (int)positionGeek.Y - 200, 500, 375), Color.White);
                spriteBatch.Draw(jock, new Rectangle((int)positionJock.X + 500, (int)positionJock.Y - 200, 290, 400), Color.White);
                spriteBatch.Draw(cheerLeader, new Rectangle((int)positionCheerLeader.X + 500, (int)positionCheerLeader.Y -200, 270, 350), Color.White);
                spriteBatch.Draw(storyText5, new Vector2(150, 545), Color.White);
            }

            if (StoryTimer > 225.00 && StoryTimer <= 260.00)
            {
                spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X + 500, (int)positionGeek.Y - 200, 500, 375), Color.White);
                spriteBatch.Draw(jock, new Rectangle((int)positionJock.X + 500, (int)positionJock.Y -200, 290, 400), Color.White);
                spriteBatch.Draw(cheerLeader, new Rectangle((int)positionCheerLeader.X + 500, (int)positionCheerLeader.Y - 200, 270, 350), Color.White);
                spriteBatch.Draw(storyText6, new Vector2(150, 565), Color.White);
            }

            spriteBatch.End();
        }

        protected void DrawPreBattle(GameTime gameTime)
        {
            spriteBatch.Begin();

            if (round == 1)
            {
                spriteBatch.Draw(gStateBackground, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                if (nerd.IsAlive == true)
                {
                    IdleNerd.Draw(gameTime, spriteBatch);
                }
                if (e1Round1.IsAlive == true)
                {
                    IdleEnemy2.Draw(gameTime, spriteBatch);
                }
                if (e2Round1.IsAlive == true)
                {
                    IdleEnemy.Draw(gameTime, spriteBatch);
                }
                if (football.IsAlive == true)
                {
                    IdleJock.Draw(gameTime, spriteBatch);
                }
                if (cheer.IsAlive == true)
                {
                    IdleCheer.Draw(gameTime, spriteBatch);
                }
                
                RDisplay.DrawRound1(gameTime, spriteBatch);
            }
            if (round == 2)
            {
                spriteBatch.Draw(gStateBackground, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);


                if (nerd.IsAlive == true)
                {
                    IdleNerd.Draw(gameTime, spriteBatch);
                }
                if (e1Round2.IsAlive == true)
                {
                    IdleEnemy2.Draw(gameTime, spriteBatch);
                }
                if (e2Round2.IsAlive == true)
                {
                    IdleEnemy.Draw(gameTime, spriteBatch);
                }
                if (football.IsAlive == true)
                {
                    IdleJock.Draw(gameTime, spriteBatch);
                }
                if (cheer.IsAlive == true)
                {
                    IdleCheer.Draw(gameTime, spriteBatch);
                }

                RDisplay2.Draw(gameTime, spriteBatch);
            }
            if (round == 3)
            {
                spriteBatch.Draw(gStateBackground, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);


                if (nerd.IsAlive == true)
                {
                    IdleNerd.Draw(gameTime, spriteBatch);
                }
                if (e1Round3.IsAlive == true)
                {
                    IdleEnemy2.DrawMini(gameTime, spriteBatch);
                }
                if (e2Round3.IsAlive == true)
                {
                    IdleEnemy.DrawMini(gameTime, spriteBatch);
                }
                if (football.IsAlive == true)
                {
                    IdleJock.Draw(gameTime, spriteBatch);
                }
                if (cheer.IsAlive == true)
                {
                    IdleCheer.Draw(gameTime, spriteBatch);
                }
                if (bossRound3.IsAlive == true)
                {
                    IdleBoss.Draw(gameTime, spriteBatch);
                }
                RDisplay3.Draw(gameTime, spriteBatch);
            }
            if (round == 4)
            {
                spriteBatch.Draw(StreetBackgroundRound4, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);


                if (nerd.IsAlive == true)
                {
                    IdleNerd.Draw(gameTime, spriteBatch);
                }
                if (e1Round4.IsAlive == true)
                {
                    IdleEnemy2.Draw(gameTime, spriteBatch);
                }
                if (e2Round4.IsAlive == true)
                {
                    IdleEnemy.Draw(gameTime, spriteBatch);
                }
                if (football.IsAlive == true)
                {
                    IdleJock.Draw(gameTime, spriteBatch);
                }
                if (cheer.IsAlive == true)
                {
                    IdleCheer.Draw(gameTime, spriteBatch);
                }
                RDisplay4.Draw(gameTime, spriteBatch);
            }
            if (round == 5)
            {
                if (nerd.IsAlive == true)
                {
                    IdleNerd.Draw(gameTime, spriteBatch);
                }
                if (e1Round5.IsAlive == true)
                {
                    IdleEnemy2.Draw(gameTime, spriteBatch);
                }
                if (e2Round5.IsAlive == true)
                {
                    IdleEnemy.Draw(gameTime, spriteBatch);
                }
                if (football.IsAlive == true)
                {
                    IdleJock.Draw(gameTime, spriteBatch);
                }
                if (cheer.IsAlive == true)
                {
                    IdleCheer.Draw(gameTime, spriteBatch);
                }
                RDisplay5.Draw(gameTime, spriteBatch);
            }
            else if (round == 6)
            {
                spriteBatch.Draw(StreetBackgroundRound6, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);


                if (nerd.IsAlive == true)
                {
                    IdleNerd.Draw(gameTime, spriteBatch);
                }
                if (e1Round6.IsAlive == true)
                {
                    IdleEnemy2.DrawTall(gameTime, spriteBatch);
                }
                if (e2Round6.IsAlive == true)
                {
                    IdleEnemy.DrawTall(gameTime, spriteBatch);
                }
                if (football.IsAlive == true)
                {
                    IdleJock.Draw(gameTime, spriteBatch);
                }
                if (cheer.IsAlive == true)
                {
                    IdleCheer.Draw(gameTime, spriteBatch);
                }
                if (e3Round6.IsAlive == true)
                {
                    IdleEnemy3.DrawTall(gameTime, spriteBatch);
                }
                RDisplay6.Draw(gameTime, spriteBatch);
            }
            if (round == 7)
            {
                spriteBatch.Draw(StreetBackgroundRound7, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);


                if (nerd.IsAlive == true)
                {
                    IdleNerd.Draw(gameTime, spriteBatch);
                }
                if (e1Round7.IsAlive == true)
                {
                    IdleEnemy2.DrawMini(gameTime, spriteBatch);
                }
                if (e2Round7.IsAlive == true)
                {
                    IdleEnemy.DrawMini(gameTime, spriteBatch);
                }
                if (football.IsAlive == true)
                {
                    IdleJock.Draw(gameTime, spriteBatch);
                }
                if (cheer.IsAlive == true)
                {
                    IdleCheer.Draw(gameTime, spriteBatch);
                }
                if (bossRound7.IsAlive == true)
                {
                    IdleBoss.Draw(gameTime, spriteBatch);
                }
                RDisplay7.Draw(gameTime, spriteBatch);
            }
            if (round == 8)
            {
                spriteBatch.Draw(StreetBackgroundRound7, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                if (nerd.IsAlive == true)
                {
                    IdleNerd.Draw(gameTime, spriteBatch);
                }
                if (e1Round8.IsAlive == true)
                {
                    IdleEnemy2.DrawTall(gameTime, spriteBatch);
                }
                if (e2Round8.IsAlive == true)
                {
                    IdleEnemy.DrawTall(gameTime, spriteBatch);
                }
                if (football.IsAlive == true)
                {
                    IdleJock.Draw(gameTime, spriteBatch);
                }
                if (cheer.IsAlive == true)
                {
                    IdleCheer.Draw(gameTime, spriteBatch);
                }
                if (e3Round8.IsAlive == true)
                {
                    IdleEnemy3.DrawTall(gameTime, spriteBatch);
                }
                RDisplay8.Draw(gameTime, spriteBatch);
            }
            if (round == 9)
            {
                spriteBatch.Draw(WhiteHouse, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                if (nerd.IsAlive == true)
                {
                    IdleNerd.Draw(gameTime, spriteBatch);
                }
                if (e1Round9.IsAlive == true)
                {
                    IdleEnemy2.DrawTall(gameTime, spriteBatch);
                }
                if (e2Round9.IsAlive == true)
                {
                    IdleEnemy.DrawTall(gameTime, spriteBatch);
                }
                if (football.IsAlive == true)
                {
                    IdleJock.Draw(gameTime, spriteBatch);
                }
                if (cheer.IsAlive == true)
                {
                    IdleCheer.Draw(gameTime, spriteBatch);
                }
                if (e3Round9.IsAlive == true)
                {
                    IdleEnemy3.DrawTall(gameTime, spriteBatch);
                }
                RDisplay9.Draw(gameTime, spriteBatch);
            }
            if(round == 10)
            {
                spriteBatch.Draw(OvalOffice, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                if (nerd.IsAlive == true)
                {
                    IdleNerd.Draw(gameTime, spriteBatch);
                }
                if (e1Round10.IsAlive == true)
                {
                    IdleEnemy2.DrawMini(gameTime, spriteBatch);
                }
                if (e2Round10.IsAlive == true)
                {
                    IdleEnemy.DrawMini(gameTime, spriteBatch);
                }
                if (football.IsAlive == true)
                {
                    IdleJock.Draw(gameTime, spriteBatch);
                }
                if (cheer.IsAlive == true)
                {
                    IdleCheer.Draw(gameTime, spriteBatch);
                }
                if (bossFinal.IsAlive == true)
                {
                    IdleBoss.Draw(gameTime, spriteBatch);
                }
                RDisplay10.Draw(gameTime, spriteBatch);
            }

            if (preBattleTimer <= 180)
            {
                spriteBatch.Draw(PreBattleText, new Rectangle((int)90, (int)-150, 1600, 1200), Color.White);
            }
            else if (preBattleTimer > 181)
            {
                spriteBatch.Draw(PreBattleText2, new Rectangle((int)100, (int)-180, 1700, 1300), Color.White);
            }

            spriteBatch.End();
        }

        protected void DrawGameOver(GameTime gameTime)
        {
            spriteBatch.Begin();

            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Draw(GameOverText, new Rectangle((int)230,(int)-250, gameOverWidth,gameOverHeight), Color.White);

            if(gameOverTimer > 360)
            {
                spriteBatch.Draw(RoundReachedText, new Rectangle((int)50, (int)300, 900, 700), Color.White);

                if (round == 1)
                {
                    spriteBatch.Draw(Round1Text, new Rectangle((int)1000, (int)263, 900, 700), Color.White);
                }
                else if (round == 2)
                {
                    spriteBatch.Draw(Round2Text, new Rectangle((int)1000, (int)263, 900, 700), Color.White);
                }
                else if (round == 3)
                {
                    spriteBatch.Draw(Round3Text, new Rectangle((int)1000, (int)263, 900, 700), Color.White);
                }
                else if (round == 4)
                {
                    spriteBatch.Draw(Round4Text, new Rectangle((int)1000, (int)263, 900, 700), Color.White);
                }
                else if (round == 5)
                {
                    spriteBatch.Draw(Round5Text, new Rectangle((int)1000, (int)263, 900, 700), Color.White);
                }
                else if (round == 6)
                {
                    spriteBatch.Draw(Round6Text, new Rectangle((int)1000, (int)263, 900, 700), Color.White);
                }
                else if (round == 7)
                {
                    spriteBatch.Draw(Round7Text, new Rectangle((int)1000, (int)263, 900, 700), Color.White);
                }
                else if (round == 8)
                {
                    spriteBatch.Draw(Round8Text, new Rectangle((int)1000, (int)263, 900, 700), Color.White);
                }
                else if (round == 9)
                {
                    spriteBatch.Draw(Round9Text, new Rectangle((int)1000, (int)263, 900, 700), Color.White);
                }
                else
                {
                    spriteBatch.Draw(Round10Text, new Rectangle((int)1000, (int)263, 900, 700), Color.White);
                }
            }
            spriteBatch.End();
        }

        protected void DrawInstructions(GameTime gameTime)
        {
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Draw(Instructions, new Rectangle(400, 0, (int)1100,(int)1100), Color.White);
            spriteBatch.End();
        }

        protected void TitleScreenInput()
        {

            // If statement for start button click
            if (mState.X >= 792 && mState.X <= 1055 && mState.Y >= 285 && mState.Y < 370 && mState.LeftButton == ButtonState.Pressed && LastmState.LeftButton != mState.LeftButton)
            {
                MediaPlayer.Stop();
                gState = GameStates.Instructions;
            }
            // If statement for credits button click
            if (mState.X >= 792 && mState.X <= 1055 && mState.Y >= 425 && mState.Y < 520 && mState.LeftButton == ButtonState.Pressed && LastmState.LeftButton != mState.LeftButton)
            {
                MediaPlayer.Stop();
                gState = GameStates.Credits;
            }
            // if statement for options button click
            if (mState.X >= 792 && mState.X <= 1055 && mState.Y >= 595 && mState.Y < 680 && mState.LeftButton == ButtonState.Pressed && LastmState.LeftButton != mState.LeftButton)
            {
                MediaPlayer.Stop();
                gState = GameStates.Options;
            }
        }

        // Method that handles clicking the return button and changing the state to the title screen 
        protected void ReturnButtonInput()
        {
            if (mState.X >= 735 && mState.X <= 1165 && mState.Y >= 835 && mState.Y < 975 && mState.LeftButton == ButtonState.Pressed && LastmState.LeftButton != mState.LeftButton)
            {
                TitleMusicCounter = 0;
                gState = GameStates.TitleScreen;
            }
        }

        protected void enemyCombat()
        {
            Random rng = new Random();
            int num = rng.Next(101);

            if (round == 1)
            {

                if (num >= 0 && num <= 40)
                {
                    int attack = e1Round1.Attack();
                    nerd.GHealth = nerd.GHealth - attack;
                }
                else if (num >= 41 && num < 80)
                {
                    int attack = e1Round1.Attack();
                    football.JHealth = football.JHealth - attack;
                }
                else
                {
                    int attack = e1Round1.Attack();
                    cheer.CHealth = cheer.CHealth - attack;
                }

                if (nerd.GHealth <= 0)
                {
                    nerd.GHealth = 0;
                    nerd.IsAlive = false;
                }
                if (football.JHealth <= 0)
                {
                    football.JHealth = 0;
                    football.IsAlive = false;
                }
                if (cheer.CHealth <= 0)
                {
                    cheer.CHealth = 0;
                    cheer.IsAlive = false;
                }

                Thread.Sleep(3000);
                round1State = Round1States.JockTurn;
            }

            if (round == 2)
            {

                if (num >= 0 && num <= 40)
                {
                    int attack = e1Round2.Attack();
                    nerd.GHealth = nerd.GHealth - attack;
                }
                else if (num >= 41 && num < 80)
                {
                    int attack = e1Round2.Attack();
                    football.JHealth = football.JHealth - attack;
                }
                else
                {
                    int attack = e1Round2.Attack();
                    cheer.CHealth = cheer.CHealth - attack;
                }

                if (nerd.GHealth <= 0)
                {
                    nerd.GHealth = 0;
                    nerd.IsAlive = false;
                }
                if (football.JHealth <= 0)
                {
                    football.JHealth = 0;
                    football.IsAlive = false;
                }
                if (cheer.CHealth <= 0)
                {
                    cheer.CHealth = 0;
                    cheer.IsAlive = false;
                }

                Thread.Sleep(3000);
                round2State = Round2States.JockTurn;
            }
            if (round == 3)
            {

                if (num >= 0 && num <= 40)
                {
                    int attack = e1Round3.Attack();
                    nerd.GHealth = nerd.GHealth - attack;
                }
                else if (num >= 41 && num < 80)
                {
                    int attack = e1Round3.Attack();
                    football.JHealth = football.JHealth - attack;
                }
                else
                {
                    int attack = e1Round3.Attack();
                    cheer.CHealth = cheer.CHealth - attack;
                }

                if (nerd.GHealth <= 0)
                {
                    nerd.GHealth = 0;
                    nerd.IsAlive = false;
                }
                if (football.JHealth <= 0)
                {
                    football.JHealth = 0;
                    football.IsAlive = false;
                }
                if (cheer.CHealth <= 0)
                {
                    cheer.CHealth = 0;
                    cheer.IsAlive = false;
                }

                Thread.Sleep(3000);
                round3State = Round3States.JockTurn;
            }

            if (round == 4)
            {

                if (num >= 0 && num <= 40)
                {
                    int attack = e1Round4.Attack();
                    nerd.GHealth = nerd.GHealth - attack;
                }
                else if (num >= 41 && num < 80)
                {
                    int attack = e1Round4.Attack();
                    football.JHealth = football.JHealth - attack;
                }
                else
                {
                    int attack = e1Round4.Attack();
                    cheer.CHealth = cheer.CHealth - attack;
                }

                if (nerd.GHealth <= 0)
                {
                    nerd.GHealth = 0;
                    nerd.IsAlive = false;
                }
                if (football.JHealth <= 0)
                {
                    football.JHealth = 0;
                    football.IsAlive = false;
                }
                if (cheer.CHealth <= 0)
                {
                    cheer.CHealth = 0;
                    cheer.IsAlive = false;
                }

                Thread.Sleep(3000);
                round4State = Round4States.NerdTurn;
            }

            if (round == 5)
            {

                if (num >= 0 && num <= 40)
                {
                    int attack = e1Round5.Attack();
                    nerd.GHealth = nerd.GHealth - attack;
                }
                else if (num >= 41 && num < 80)
                {
                    int attack = e1Round5.Attack();
                    football.JHealth = football.JHealth - attack;
                }
                else
                {
                    int attack = e1Round5.Attack();
                    cheer.CHealth = cheer.CHealth - attack;
                }

                if (nerd.GHealth <= 0)
                {
                    nerd.GHealth = 0;
                    nerd.IsAlive = false;
                }
                if (football.JHealth <= 0)
                {
                    football.JHealth = 0;
                    football.IsAlive = false;
                }
                if (cheer.CHealth <= 0)
                {
                    cheer.CHealth = 0;
                    cheer.IsAlive = false;
                }

                Thread.Sleep(3000);
                round5State = Round5States.CheerTurn;
            }

            if (round == 6)
            {

                if (num >= 0 && num <= 40)
                {
                    int attack = e1Round6.Attack();
                    nerd.GHealth = nerd.GHealth - attack;
                }
                else if (num >= 41 && num < 80)
                {
                    int attack = e1Round6.Attack();
                    football.JHealth = football.JHealth - attack;
                }
                else
                {
                    int attack = e1Round6.Attack();
                    cheer.CHealth = cheer.CHealth - attack;
                }

                if (nerd.GHealth <= 0)
                {
                    nerd.GHealth = 0;
                    nerd.IsAlive = false;
                }
                if (football.JHealth <= 0)
                {
                    football.JHealth = 0;
                    football.IsAlive = false;
                }
                if (cheer.CHealth <= 0)
                {
                    cheer.CHealth = 0;
                    cheer.IsAlive = false;
                }

                Thread.Sleep(3000);
                round6State = Round6States.Enemy3Turn;
            }

            if (round == 7)
            {

                if (num >= 0 && num <= 40)
                {
                    int attack = e1Round7.Attack();
                    nerd.GHealth = nerd.GHealth - attack;
                }
                else if (num >= 41 && num < 80)
                {
                    int attack = e1Round7.Attack();
                    football.JHealth = football.JHealth - attack;
                }
                else
                {
                    int attack = e1Round7.Attack();
                    cheer.CHealth = cheer.CHealth - attack;
                }

                if (nerd.GHealth <= 0)
                {
                    nerd.GHealth = 0;
                    nerd.IsAlive = false;
                }
                if (football.JHealth <= 0)
                {
                    football.JHealth = 0;
                    football.IsAlive = false;
                }
                if (cheer.CHealth <= 0)
                {
                    cheer.CHealth = 0;
                    cheer.IsAlive = false;
                }

                Thread.Sleep(3000);
                round7State = Round7States.Enemy2Turn;
            }

            if (round == 8)
            {

                if (num >= 0 && num <= 40)
                {
                    int attack = e1Round8.Attack();
                    nerd.GHealth = nerd.GHealth - attack;
                }
                else if (num >= 41 && num < 80)
                {
                    int attack = e1Round8.Attack();
                    football.JHealth = football.JHealth - attack;
                }
                else
                {
                    int attack = e1Round8.Attack();
                    cheer.CHealth = cheer.CHealth - attack;
                }

                if (nerd.GHealth <= 0)
                {
                    nerd.GHealth = 0;
                    nerd.IsAlive = false;
                }
                if (football.JHealth <= 0)
                {
                    football.JHealth = 0;
                    football.IsAlive = false;
                }
                if (cheer.CHealth <= 0)
                {
                    cheer.CHealth = 0;
                    cheer.IsAlive = false;
                }

                Thread.Sleep(3000);
                round8State = Round8States.JockTurn;
            }

            if (round == 9)
            {

                if (num >= 0 && num <= 40)
                {
                    int attack = e1Round9.Attack();
                    nerd.GHealth = nerd.GHealth - attack;
                }
                else if (num >= 41 && num < 80)
                {
                    int attack = e1Round9.Attack();
                    football.JHealth = football.JHealth - attack;
                }
                else
                {
                    int attack = e1Round9.Attack();
                    cheer.CHealth = cheer.CHealth - attack;
                }

                if (nerd.GHealth <= 0)
                {
                    nerd.GHealth = 0;
                    nerd.IsAlive = false;
                }
                if (football.JHealth <= 0)
                {
                    football.JHealth = 0;
                    football.IsAlive = false;
                }
                if (cheer.CHealth <= 0)
                {
                    cheer.CHealth = 0;
                    cheer.IsAlive = false;
                }

                Thread.Sleep(3000);
                round9State = Round9States.NerdTurn;
            }

            if (round == 10)
            {

                if (num >= 0 && num <= 40)
                {
                    int attack = e1Round10.Attack();
                    nerd.GHealth = nerd.GHealth - attack;
                }
                else if (num >= 41 && num < 80)
                {
                    int attack = e1Round10.Attack();
                    football.JHealth = football.JHealth - attack;
                }
                else
                {
                    int attack = e1Round10.Attack();
                    cheer.CHealth = cheer.CHealth - attack;
                }

                if (nerd.GHealth <= 0)
                {
                    nerd.GHealth = 0;
                    nerd.IsAlive = false;
                }
                if (football.JHealth <= 0)
                {
                    football.JHealth = 0;
                    football.IsAlive = false;
                }
                if (cheer.CHealth <= 0)
                {
                    cheer.CHealth = 0;
                    cheer.IsAlive = false;
                }

                Thread.Sleep(3000);
                round10State = Round10States.NerdTurn;
            }
        }

        protected void enemyCombat2()
        {
            Random rng = new Random();
            int num = rng.Next(101);

            if (round == 1)
            {

                if (num >= 0 && num <= 40)
                {
                    int attack = e2Round1.Attack();
                    nerd.GHealth = nerd.GHealth - attack;
                }
                else if (num >= 41 && num < 80)
                {
                    int attack = e2Round1.Attack();
                    football.JHealth = football.JHealth - attack;
                }
                else
                {
                    int attack = e2Round1.Attack();
                    cheer.CHealth = cheer.CHealth - attack;
                }

                if (nerd.GHealth <= 0)
                {
                    nerd.GHealth = 0;
                    nerd.IsAlive = false;
                }
                if (football.JHealth <= 0)
                {
                    football.JHealth = 0;
                    football.IsAlive = false;
                }
                if (cheer.CHealth <= 0)
                {
                    cheer.CHealth = 0;
                    cheer.IsAlive = false;
                }

                Thread.Sleep(3000);
                round1State = Round1States.NerdTurn;
            }

            if (round == 2)
            {

                if (num >= 0 && num <= 40)
                {
                    int attack = e2Round2.Attack();
                    nerd.GHealth = nerd.GHealth - attack;
                }
                else if (num >= 41 && num < 80)
                {
                    int attack = e2Round2.Attack();
                    football.JHealth = football.JHealth - attack;
                }
                else
                {
                    int attack = e2Round2.Attack();
                    cheer.CHealth = cheer.CHealth - attack;
                }

                if (nerd.GHealth <= 0)
                {
                    nerd.GHealth = 0;
                    nerd.IsAlive = false;
                }
                if (football.JHealth <= 0)
                {
                    football.JHealth = 0;
                    football.IsAlive = false;
                }
                if (cheer.CHealth <= 0)
                {
                    cheer.CHealth = 0;
                    cheer.IsAlive = false;
                }

                Thread.Sleep(3000);
                round2State = Round2States.CheertTurn;
            }
            if (round == 3)
            {

                if (num >= 0 && num <= 40)
                {
                    int attack = e2Round3.Attack();
                    nerd.GHealth = nerd.GHealth - attack;
                }
                else if (num >= 41 && num < 80)
                {
                    int attack = e2Round3.Attack();
                    football.JHealth = football.JHealth - attack;
                }
                else
                {
                    int attack = e2Round3.Attack();
                    cheer.CHealth = cheer.CHealth - attack;
                }

                if (nerd.GHealth <= 0)
                {
                    nerd.GHealth = 0;
                    nerd.IsAlive = false;
                }
                if (football.JHealth <= 0)
                {
                    football.JHealth = 0;
                    football.IsAlive = false;
                }
                if (cheer.CHealth <= 0)
                {
                    cheer.CHealth = 0;
                    cheer.IsAlive = false;
                }

                Thread.Sleep(3000);
                round3State = Round3States.BossTurn;
            }

            if (round == 4)
            {

                if (num >= 0 && num <= 40)
                {
                    int attack = e2Round4.Attack();
                    nerd.GHealth = nerd.GHealth - attack;
                }
                else if (num >= 41 && num < 80)
                {
                    int attack = e2Round4.Attack();
                    football.JHealth = football.JHealth - attack;
                }
                else
                {
                    int attack = e2Round4.Attack();
                    cheer.CHealth = cheer.CHealth - attack;
                }

                if (nerd.GHealth <= 0)
                {
                    nerd.GHealth = 0;
                    nerd.IsAlive = false;
                }
                if (football.JHealth <= 0)
                {
                    football.JHealth = 0;
                    football.IsAlive = false;
                }
                if (cheer.CHealth <= 0)
                {
                    cheer.CHealth = 0;
                    cheer.IsAlive = false;
                }

                Thread.Sleep(3000);
                round4State = Round4States.CheerTurn;
            }

            if (round == 5)
            {

                if (num >= 0 && num <= 40)
                {
                    int attack = e2Round5.Attack();
                    nerd.GHealth = nerd.GHealth - attack;
                }
                else if (num >= 41 && num < 80)
                {
                    int attack = e2Round5.Attack();
                    football.JHealth = football.JHealth - attack;
                }
                else
                {
                    int attack = e2Round5.Attack();
                    cheer.CHealth = cheer.CHealth - attack;
                }

                if (nerd.GHealth <= 0)
                {
                    nerd.GHealth = 0;
                    nerd.IsAlive = false;
                }
                if (football.JHealth <= 0)
                {
                    football.JHealth = 0;
                    football.IsAlive = false;
                }
                if (cheer.CHealth <= 0)
                {
                    cheer.CHealth = 0;
                    cheer.IsAlive = false;
                }

                Thread.Sleep(3000);
                round5State = Round5States.JockTurn;
            }

            if (round == 6)
            {

                if (num >= 0 && num <= 40)
                {
                    int attack = e2Round6.Attack();
                    nerd.GHealth = nerd.GHealth - attack;
                }
                else if (num >= 41 && num < 80)
                {
                    int attack = e2Round6.Attack();
                    football.JHealth = football.JHealth - attack;
                }
                else
                {
                    int attack = e2Round6.Attack();
                    cheer.CHealth = cheer.CHealth - attack;
                }

                if (nerd.GHealth <= 0)
                {
                    nerd.GHealth = 0;
                    nerd.IsAlive = false;
                }
                if (football.JHealth <= 0)
                {
                    football.JHealth = 0;
                    football.IsAlive = false;
                }
                if (cheer.CHealth <= 0)
                {
                    cheer.CHealth = 0;
                    cheer.IsAlive = false;
                }

                Thread.Sleep(3000);
                round6State = Round6States.JockTurn;
            }

            if (round == 7)
            {

                if (num >= 0 && num <= 40)
                {
                    int attack = e2Round7.Attack();
                    nerd.GHealth = nerd.GHealth - attack;
                }
                else if (num >= 41 && num < 80)
                {
                    int attack = e2Round7.Attack();
                    football.JHealth = football.JHealth - attack;
                }
                else
                {
                    int attack = e2Round7.Attack();
                    cheer.CHealth = cheer.CHealth - attack;
                }

                if (nerd.GHealth <= 0)
                {
                    nerd.GHealth = 0;
                    nerd.IsAlive = false;
                }
                if (football.JHealth <= 0)
                {
                    football.JHealth = 0;
                    football.IsAlive = false;
                }
                if (cheer.CHealth <= 0)
                {
                    cheer.CHealth = 0;
                    cheer.IsAlive = false;
                }

                Thread.Sleep(3000);
                round7State = Round7States.JockTurn;
            }

            if (round == 8)
            {

                if (num >= 0 && num <= 40)
                {
                    int attack = e2Round8.Attack();
                    nerd.GHealth = nerd.GHealth - attack;
                }
                else if (num >= 41 && num < 80)
                {
                    int attack = e2Round8.Attack();
                    football.JHealth = football.JHealth - attack;
                }
                else
                {
                    int attack = e2Round8.Attack();
                    cheer.CHealth = cheer.CHealth - attack;
                }

                if (nerd.GHealth <= 0)
                {
                    nerd.GHealth = 0;
                    nerd.IsAlive = false;
                }
                if (football.JHealth <= 0)
                {
                    football.JHealth = 0;
                    football.IsAlive = false;
                }
                if (cheer.CHealth <= 0)
                {
                    cheer.CHealth = 0;
                    cheer.IsAlive = false;
                }

                Thread.Sleep(3000);
                round8State = Round8States.Enemy3Turn;
            }

            if (round == 9)
            {

                if (num >= 0 && num <= 40)
                {
                    int attack = e2Round9.Attack();
                    nerd.GHealth = nerd.GHealth - attack;
                }
                else if (num >= 41 && num < 80)
                {
                    int attack = e2Round9.Attack();
                    football.JHealth = football.JHealth - attack;
                }
                else
                {
                    int attack = e2Round9.Attack();
                    cheer.CHealth = cheer.CHealth - attack;
                }

                if (nerd.GHealth <= 0)
                {
                    nerd.GHealth = 0;
                    nerd.IsAlive = false;
                }
                if (football.JHealth <= 0)
                {
                    football.JHealth = 0;
                    football.IsAlive = false;
                }
                if (cheer.CHealth <= 0)
                {
                    cheer.CHealth = 0;
                    cheer.IsAlive = false;
                }

                Thread.Sleep(3000);
                round9State = Round9States.Enemy3Turn;
            }

            if (round == 10)
            {

                if (num >= 0 && num <= 40)
                {
                    int attack = e2Round10.Attack();
                    nerd.GHealth = nerd.GHealth - attack;
                }
                else if (num >= 41 && num < 80)
                {
                    int attack = e2Round10.Attack();
                    football.JHealth = football.JHealth - attack;
                }
                else
                {
                    int attack = e2Round10.Attack();
                    cheer.CHealth = cheer.CHealth - attack;
                }

                if (nerd.GHealth <= 0)
                {
                    nerd.GHealth = 0;
                    nerd.IsAlive = false;
                }
                if (football.JHealth <= 0)
                {
                    football.JHealth = 0;
                    football.IsAlive = false;
                }
                if (cheer.CHealth <= 0)
                {
                    cheer.CHealth = 0;
                    cheer.IsAlive = false;
                }

                Thread.Sleep(3000);
                round10State = Round10States.CheerTurn;
            }
        }

        protected void EnemyCombat3()
        {
            Random rng = new Random();
            int num = rng.Next(101);

            if (round == 6)
            {

                if (num >= 0 && num <= 40)
                {
                    int attack = e3Round6.Attack();
                    nerd.GHealth = nerd.GHealth - attack;
                }
                else if (num >= 41 && num < 80)
                {
                    int attack = e3Round6.Attack();
                    football.JHealth = football.JHealth - attack;
                }
                else
                {
                    int attack = e3Round6.Attack();
                    cheer.CHealth = cheer.CHealth - attack;
                }

                if (nerd.GHealth <= 0)
                {
                    nerd.GHealth = 0;
                    nerd.IsAlive = false;
                }
                if (football.JHealth <= 0)
                {
                    football.JHealth = 0;
                    football.IsAlive = false;
                }
                if (cheer.CHealth <= 0)
                {
                    cheer.CHealth = 0;
                    cheer.IsAlive = false;
                }

                Thread.Sleep(3000);
                round6State = Round6States.NerdTurn;
            }

            if (round == 8)
            {

                if (num >= 0 && num <= 40)
                {
                    int attack = e3Round8.Attack();
                    nerd.GHealth = nerd.GHealth - attack;
                }
                else if (num >= 41 && num < 80)
                {
                    int attack = e3Round8.Attack();
                    football.JHealth = football.JHealth - attack;
                }
                else
                {
                    int attack = e3Round8.Attack();
                    cheer.CHealth = cheer.CHealth - attack;
                }

                if (nerd.GHealth <= 0)
                {
                    nerd.GHealth = 0;
                    nerd.IsAlive = false;
                }
                if (football.JHealth <= 0)
                {
                    football.JHealth = 0;
                    football.IsAlive = false;
                }
                if (cheer.CHealth <= 0)
                {
                    cheer.CHealth = 0;
                    cheer.IsAlive = false;
                }

                Thread.Sleep(3000);
                round8State = Round8States.NerdTurn;
            }
            if (round == 9)
            {

                if (num >= 0 && num <= 40)
                {
                    int attack = e3Round9.Attack();
                    nerd.GHealth = nerd.GHealth - attack;
                }
                else if (num >= 41 && num < 80)
                {
                    int attack = e3Round9.Attack();
                    football.JHealth = football.JHealth - attack;
                }
                else
                {
                    int attack = e3Round9.Attack();
                    cheer.CHealth = cheer.CHealth - attack;
                }

                if (nerd.GHealth <= 0)
                {
                    nerd.GHealth = 0;
                    nerd.IsAlive = false;
                }
                if (football.JHealth <= 0)
                {
                    football.JHealth = 0;
                    football.IsAlive = false;
                }
                if (cheer.CHealth <= 0)
                {
                    cheer.CHealth = 0;
                    cheer.IsAlive = false;
                }

                Thread.Sleep(3000);
                round9State = Round9States.JockTurn;
            }
        }

        protected void BossCombat()
        {
            Random rng = new Random();
            int num = rng.Next(101);

            if (round == 3)
            {

                if (num >= 0 && num <= 40)
                {
                    int attack = bossRound3.Attack();
                    nerd.GHealth = nerd.GHealth - attack;
                }
                else if (num >= 41 && num < 80)
                {
                    int attack = bossRound3.Attack();
                    football.JHealth = football.JHealth - attack;
                }
                else
                {
                    int attack = bossRound3.Attack();
                    cheer.CHealth = cheer.CHealth - attack;
                }

                if (nerd.GHealth <= 0)
                {
                    nerd.GHealth = 0;
                    nerd.IsAlive = false;
                }
                if (football.JHealth <= 0)
                {
                    football.JHealth = 0;
                    football.IsAlive = false;
                }
                if (cheer.CHealth <= 0)
                {
                    cheer.CHealth = 0;
                    cheer.IsAlive = false;
                }

                Thread.Sleep(3000);
                round3State = Round3States.CheerTurn;
            }

            if (round == 7)
            {

                if (num >= 0 && num <= 40)
                {
                    int attack = bossRound7.Attack();
                    nerd.GHealth = nerd.GHealth - attack;
                }
                else if (num >= 41 && num < 80)
                {
                    int attack = bossRound7.Attack();
                    football.JHealth = football.JHealth - attack;
                }
                else
                {
                    int attack = bossRound7.Attack();
                    cheer.CHealth = cheer.CHealth - attack;
                }

                if (nerd.GHealth <= 0)
                {
                    nerd.GHealth = 0;
                    nerd.IsAlive = false;
                }
                if (football.JHealth <= 0)
                {
                    football.JHealth = 0;
                    football.IsAlive = false;
                }
                if (cheer.CHealth <= 0)
                {
                    cheer.CHealth = 0;
                    cheer.IsAlive = false;
                }

                Thread.Sleep(3000);
                round7State = Round7States.CheerTurn;
            }
            if (round == 10)
            {

                if (num >= 0 && num <= 40)
                {
                    int attack = bossFinal.Attack();
                    nerd.GHealth = nerd.GHealth - attack;
                }
                else if (num >= 41 && num < 80)
                {
                    int attack = bossFinal.Attack();
                    football.JHealth = football.JHealth - attack;
                }
                else
                {
                    int attack = bossFinal.Attack();
                    cheer.CHealth = cheer.CHealth - attack;
                }

                if (nerd.GHealth <= 0)
                {
                    nerd.GHealth = 0;
                    nerd.IsAlive = false;
                }
                if (football.JHealth <= 0)
                {
                    football.JHealth = 0;
                    football.IsAlive = false;
                }
                if (cheer.CHealth <= 0)
                {
                    cheer.CHealth = 0;
                    cheer.IsAlive = false;
                }

                Thread.Sleep(3000);
                round10State = Round10States.JockTurn;
            }
        }

        protected void NerdCombat()
        {
            //Button click for attacking
            if (mState.X >= 1545 && mState.X <= 1845 && mState.Y >= 815 && mState.Y < 900 && mState.LeftButton == ButtonState.Pressed && LastmState.LeftButton != mState.LeftButton)
            {
                nerd.SpecialMeter += 10;

                if (round == 1)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = nerd.Attack();
                    if (num >= 0 && num < 50)
                    {
                        e1Round1.EHealth = e1Round1.EHealth - attack;
                    }
                    else
                    {
                        e2Round1.EHealth = e2Round1.EHealth - attack;
                    }
                    if (e1Round1.EHealth <= 0)
                    {
                        e1Round1.EHealth = 0;
                        e1Round1.IsAlive = false;
                    }
                    if (e2Round1.EHealth <= 0)
                    {
                        e2Round1.EHealth = 0;
                        e2Round1.IsAlive = false;
                    };

                    round1State = Round1States.EnemyTurn;
                }

                if (round == 2)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = nerd.Attack();
                    if (num >= 0 && num < 50)
                    {
                        e1Round2.EHealth = e1Round2.EHealth - attack;
                    }
                    else
                    {
                        e2Round2.EHealth = e2Round2.EHealth - attack;
                    }
                    if (e1Round2.EHealth <= 0)
                    {
                        e1Round2.EHealth = 0;
                        e1Round2.IsAlive = false;
                    }
                    if (e2Round2.EHealth <= 0)
                    {
                        e2Round2.EHealth = 0;
                        e2Round2.IsAlive = false;
                    };

                    round2State = Round2States.Enemy2Turn;
                }

                if (round == 3)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = nerd.Attack();
                    if (num >= 0 && num <= 40)
                    {
                        e1Round3.EHealth = e1Round3.EHealth - attack;
                    }
                    else if (num >= 41 && num < 60)
                    {
                        e2Round3.EHealth = e2Round3.EHealth - attack;
                    }
                    else
                    {
                        bossRound3.EHealth = bossRound3.EHealth - attack;
                    }
                    if (e1Round3.EHealth <= 0)
                    {
                        e1Round3.EHealth = 0;
                        e1Round3.IsAlive = false;
                    }
                    if (e2Round3.EHealth <= 0)
                    {
                        e2Round3.EHealth = 0;
                        e2Round3.IsAlive = false;
                    }
                    if (bossRound3.EHealth <= 0)
                    {
                        bossRound3.EHealth = 0;
                        bossRound3.IsAlive = false;
                    }

                    round3State = Round3States.EnemyTurn;
                }

                if (round == 4)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = nerd.Attack();
                    if (num >= 0 && num < 50)
                    {
                        e1Round4.EHealth = e1Round4.EHealth - attack;
                    }
                    else
                    {
                        e2Round4.EHealth = e2Round4.EHealth - attack;
                    }
                    if (e1Round4.EHealth <= 0)
                    {
                        e1Round4.EHealth = 0;
                        e1Round4.IsAlive = false;
                    }
                    if (e2Round4.EHealth <= 0)
                    {
                        e2Round4.EHealth = 0;
                        e2Round4.IsAlive = false;
                    };

                    round4State = Round4States.JockTurn;
                }

                if (round == 5)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = nerd.Attack();
                    if (num >= 0 && num < 50)
                    {
                        e1Round5.EHealth = e1Round5.EHealth - attack;
                    }
                    else
                    {
                        e2Round5.EHealth = e2Round5.EHealth - attack;
                    }
                    if (e1Round5.EHealth <= 0)
                    {
                        e1Round5.EHealth = 0;
                        e1Round5.IsAlive = false;
                    }
                    if (e2Round5.EHealth <= 0)
                    {
                        e2Round5.EHealth = 0;
                        e2Round5.IsAlive = false;
                    };

                    round5State = Round5States.Enemy2Turn;
                }

                if (round == 6)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = nerd.Attack();
                    if (num >= 0 && num <= 40)
                    {
                        e1Round6.EHealth = e1Round6.EHealth - attack;
                    }
                    else if (num >= 41 && num < 60)
                    {
                        e2Round6.EHealth = e2Round6.EHealth - attack;
                    }
                    else
                    {
                        e3Round6.EHealth = e3Round6.EHealth - attack;
                    }
                    if (e1Round6.EHealth <= 0)
                    {
                        e1Round6.EHealth = 0;
                        e1Round6.IsAlive = false;
                    }
                    if (e2Round6.EHealth <= 0)
                    {
                        e2Round6.EHealth = 0;
                        e2Round6.IsAlive = false;
                    }
                    if (e3Round6.EHealth <= 0)
                    {
                        e3Round6.EHealth = 0;
                        e3Round6.IsAlive = false;
                    }

                    round6State = Round6States.Enemy2Turn;
                }

                if (round == 7)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = nerd.Attack();
                    if (num >= 0 && num <= 40)
                    {
                        e1Round7.EHealth = e1Round7.EHealth - attack;
                    }
                    else if (num >= 41 && num < 60)
                    {
                        e2Round7.EHealth = e2Round7.EHealth - attack;
                    }
                    else
                    {
                        bossRound7.EHealth = bossRound7.EHealth - attack;
                    }
                    if (e1Round7.EHealth <= 0)
                    {
                        e1Round7.EHealth = 0;
                        e1Round7.IsAlive = false;
                    }
                    if (e2Round7.EHealth <= 0)
                    {
                        e2Round7.EHealth = 0;
                        e2Round7.IsAlive = false;
                    }
                    if (bossRound7.EHealth <= 0)
                    {
                        bossRound7.EHealth = 0;
                        bossRound7.IsAlive = false;
                    }

                    round7State = Round7States.EnemyTurn;
                }

                if (round == 8)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = nerd.Attack();
                    if (num >= 0 && num <= 40)
                    {
                        e1Round8.EHealth = e1Round8.EHealth - attack;
                    }
                    else if (num >= 41 && num < 60)
                    {
                        e2Round8.EHealth = e2Round8.EHealth - attack;
                    }
                    else
                    {
                        e3Round8.EHealth = e3Round8.EHealth - attack;
                    }
                    if (e1Round8.EHealth <= 0)
                    {
                        e1Round8.EHealth = 0;
                        e1Round8.IsAlive = false;
                    }
                    if (e2Round8.EHealth <= 0)
                    {
                        e2Round8.EHealth = 0;
                        e2Round8.IsAlive = false;
                    }
                    if (e3Round8.EHealth <= 0)
                    {
                        e3Round8.EHealth = 0;
                        e3Round8.IsAlive = false;
                    }

                    round8State = Round8States.Enemy2Turn;
                }

                if (round == 9)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = nerd.Attack();
                    if (num >= 0 && num <= 40)
                    {
                        e1Round9.EHealth = e1Round9.EHealth - attack;
                    }
                    else if (num >= 41 && num < 60)
                    {
                        e2Round9.EHealth = e2Round9.EHealth - attack;
                    }
                    else
                    {
                        e3Round9.EHealth = e3Round9.EHealth - attack;
                    }
                    if (e1Round9.EHealth <= 0)
                    {
                        e1Round9.EHealth = 0;
                        e1Round9.IsAlive = false;
                    }
                    if (e2Round9.EHealth <= 0)
                    {
                        e2Round9.EHealth = 0;
                        e2Round9.IsAlive = false;
                    }
                    if (e3Round9.EHealth <= 0)
                    {
                        e3Round9.EHealth = 0;
                        e3Round9.IsAlive = false;
                    }

                    round9State = Round9States.CheerTurn;
                }

                if (round == 10)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = nerd.Attack();
                    if (num >= 0 && num <= 40)
                    {
                        e1Round10.EHealth = e1Round10.EHealth - attack;
                    }
                    else if (num >= 41 && num < 60)
                    {
                        e2Round10.EHealth = e2Round10.EHealth - attack;
                    }
                    else
                    {
                        bossFinal.EHealth = bossFinal.EHealth - attack;
                    }
                    if (e1Round10.EHealth <= 0)
                    {
                        e1Round10.EHealth = 0;
                        e1Round10.IsAlive = false;
                    }
                    if (e2Round10.EHealth <= 0)
                    {
                        e2Round10.EHealth = 0;
                        e2Round10.IsAlive = false;
                    }
                    if (bossFinal.EHealth <= 0)
                    {
                        bossFinal.EHealth = 0;
                        bossFinal.IsAlive = false;
                    }

                    round10State = Round10States.BossTurn;
                }
            }

            if (mState.X >= 1545 && mState.X <= 1845 && mState.Y >= 910 && mState.Y < 995 && mState.LeftButton == ButtonState.Pressed && LastmState.LeftButton != mState.LeftButton)
            {
                if (nerd.SpecialMeter >= 100)
                {
                    nerd.GAttack += 10;
                    nerd.SpecialMeter = 0;
                }
            }

        }

        protected void JockCombat()
        {
            //Button click for attacking
            if (mState.X >= 1545 && mState.X <= 1845 && mState.Y >= 815 && mState.Y < 900 && mState.LeftButton == ButtonState.Pressed && LastmState.LeftButton != mState.LeftButton)
            {
                football.SpecialMeter += 20;

                if (round == 1)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = football.Attack();
                    if (num >= 0 && num < 50)
                    {
                        e1Round1.EHealth = e1Round1.EHealth - attack;
                    }
                    else
                    {
                        e2Round1.EHealth = e2Round1.EHealth - attack;
                    }
                    if (e1Round1.EHealth <= 0)
                    {
                        e1Round1.EHealth = 0;
                        e1Round1.IsAlive = false;
                    }
                    if (e2Round1.EHealth <= 0)
                    {
                        e2Round1.EHealth = 0;
                        e2Round1.IsAlive = false;
                    };

                    round1State = Round1States.CheerTurn;
                }

                if (round == 2)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = football.Attack();
                    if (num >= 0 && num < 50)
                    {
                        e1Round2.EHealth = e1Round2.EHealth - attack;
                    }
                    else
                    {
                        e2Round2.EHealth = e2Round2.EHealth - attack;
                    }
                    if (e1Round2.EHealth <= 0)
                    {
                        e1Round2.EHealth = 0;
                        e1Round2.IsAlive = false;
                    }
                    if (e2Round2.EHealth <= 0)
                    {
                        e2Round2.EHealth = 0;
                        e2Round2.IsAlive = false;
                    };

                    round2State = Round2States.NerdTurn;
                }

                if (round == 3)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = football.Attack();
                    if (num >= 0 && num <= 40)
                    {
                        e1Round3.EHealth = e1Round3.EHealth - attack;
                    }
                    else if (num >= 41 && num < 60)
                    {
                        e2Round3.EHealth = e2Round3.EHealth - attack;
                    }
                    else
                    {
                        bossRound3.EHealth = bossRound3.EHealth - attack;
                    }
                    if (e1Round3.EHealth <= 0)
                    {
                        e1Round3.EHealth = 0;
                        e1Round3.IsAlive = false;
                    }
                    if (e2Round3.EHealth <= 0)
                    {
                        e2Round3.EHealth = 0;
                        e2Round3.IsAlive = false;
                    }
                    if (bossRound3.EHealth <= 0)
                    {
                        bossRound3.EHealth = 0;
                        bossRound3.IsAlive = false;
                    }

                    round3State = Round3States.Enemy2Turn;
                }

                if (round == 4)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = football.Attack();
                    if (num >= 0 && num < 50)
                    {
                        e1Round4.EHealth = e1Round4.EHealth - attack;
                    }
                    else
                    {
                        e2Round4.EHealth = e2Round4.EHealth - attack;
                    }
                    if (e1Round4.EHealth <= 0)
                    {
                        e1Round4.EHealth = 0;
                        e1Round4.IsAlive = false;
                    }
                    if (e2Round4.EHealth <= 0)
                    {
                        e2Round4.EHealth = 0;
                        e2Round4.IsAlive = false;
                    };

                    round4State = Round4States.Enemy2Turn;
                }

                if (round == 5)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = football.Attack();
                    if (num >= 0 && num < 50)
                    {
                        e1Round5.EHealth = e1Round5.EHealth - attack;
                    }
                    else
                    {
                        e2Round5.EHealth = e2Round5.EHealth - attack;
                    }
                    if (e1Round5.EHealth <= 0)
                    {
                        e1Round5.EHealth = 0;
                        e1Round5.IsAlive = false;
                    }
                    if (e2Round5.EHealth <= 0)
                    {
                        e2Round5.EHealth = 0;
                        e2Round5.IsAlive = false;
                    };

                    round5State = Round5States.EnemyTurn;
                }

                if (round == 6)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = football.Attack();
                    if (num >= 0 && num <= 40)
                    {
                        e1Round6.EHealth = e1Round6.EHealth - attack;
                    }
                    else if (num >= 41 && num < 60)
                    {
                        e2Round6.EHealth = e2Round6.EHealth - attack;
                    }
                    else
                    {
                        e3Round6.EHealth = e3Round6.EHealth - attack;
                    }
                    if (e1Round6.EHealth <= 0)
                    {
                        e1Round6.EHealth = 0;
                        e1Round6.IsAlive = false;
                    }
                    if (e2Round6.EHealth <= 0)
                    {
                        e2Round6.EHealth = 0;
                        e2Round6.IsAlive = false;
                    }
                    if (e3Round6.EHealth <= 0)
                    {
                        e3Round6.EHealth = 0;
                        e3Round6.IsAlive = false;
                    }

                    round6State = Round6States.CheerTurn;
                }

                if (round == 7)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = football.Attack();
                    if (num >= 0 && num <= 40)
                    {
                        e1Round7.EHealth = e1Round7.EHealth - attack;
                    }
                    else if (num >= 41 && num < 60)
                    {
                        e2Round7.EHealth = e2Round7.EHealth - attack;
                    }
                    else
                    {
                        bossRound7.EHealth = bossRound7.EHealth - attack;
                    }
                    if (e1Round7.EHealth <= 0)
                    {
                        e1Round7.EHealth = 0;
                        e1Round7.IsAlive = false;
                    }
                    if (e2Round7.EHealth <= 0)
                    {
                        e2Round7.EHealth = 0;
                        e2Round7.IsAlive = false;
                    }
                    if (bossRound7.EHealth <= 0)
                    {
                        bossRound7.EHealth = 0;
                        bossRound7.IsAlive = false;
                    }

                    round7State = Round7States.BossTurn;
                }

                if (round == 8)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = football.Attack();
                    if (num >= 0 && num <= 40)
                    {
                        e1Round8.EHealth = e1Round8.EHealth - attack;
                    }
                    else if (num >= 41 && num < 60)
                    {
                        e2Round8.EHealth = e2Round8.EHealth - attack;
                    }
                    else
                    {
                        e3Round8.EHealth = e3Round8.EHealth - attack;
                    }
                    if (e1Round8.EHealth <= 0)
                    {
                        e1Round8.EHealth = 0;
                        e1Round8.IsAlive = false;
                    }
                    if (e2Round8.EHealth <= 0)
                    {
                        e2Round8.EHealth = 0;
                        e2Round8.IsAlive = false;
                    }
                    if (e3Round8.EHealth <= 0)
                    {
                        e3Round8.EHealth = 0;
                        e3Round8.IsAlive = false;
                    }

                    round8State = Round8States.Enemy2Turn;
                }

                if (round == 9)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = football.Attack();
                    if (num >= 0 && num <= 40)
                    {
                        e1Round9.EHealth = e1Round9.EHealth - attack;
                    }
                    else if (num >= 41 && num < 60)
                    {
                        e2Round9.EHealth = e2Round9.EHealth - attack;
                    }
                    else
                    {
                        e3Round9.EHealth = e3Round9.EHealth - attack;
                    }
                    if (e1Round9.EHealth <= 0)
                    {
                        e1Round9.EHealth = 0;
                        e1Round9.IsAlive = false;
                    }
                    if (e2Round9.EHealth <= 0)
                    {
                        e2Round9.EHealth = 0;
                        e2Round9.IsAlive = false;
                    }
                    if (e3Round9.EHealth <= 0)
                    {
                        e3Round9.EHealth = 0;
                        e3Round9.IsAlive = false;
                    }

                    round9State = Round9States.EnemyTurn;
                }

                if (round == 10)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = football.Attack();
                    if (num >= 0 && num <= 40)
                    {
                        e1Round10.EHealth = e1Round10.EHealth - attack;
                    }
                    else if (num >= 41 && num < 60)
                    {
                        e2Round10.EHealth = e2Round10.EHealth - attack;
                    }
                    else
                    {
                        bossFinal.EHealth = bossFinal.EHealth - attack;
                    }
                    if (e1Round10.EHealth <= 0)
                    {
                        e1Round10.EHealth = 0;
                        e1Round10.IsAlive = false;
                    }
                    if (e2Round10.EHealth <= 0)
                    {
                        e2Round10.EHealth = 0;
                        e2Round10.IsAlive = false;
                    }
                    if (bossFinal.EHealth <= 0)
                    {
                        bossFinal.EHealth = 0;
                        bossFinal.IsAlive = false;
                    }

                    round10State = Round10States.Enemy2Turn;
                }
            }

            if (mState.X >= 1545 && mState.X <= 1845 && mState.Y >= 910 && mState.Y < 995 && mState.LeftButton == ButtonState.Pressed && LastmState.LeftButton != mState.LeftButton)
            {
                if (football.SpecialMeter >= 100)
                {
                    nerd.GHealth += 50;
                    cheer.CHealth += 50;
                    football.JHealth += 50;

                    if (nerd.GHealth > 350)
                    {
                        nerd.GHealth = 350;
                    }
                    if (cheer.CHealth > 150)
                    {
                        cheer.CHealth = 150;
                    }
                    if (football.JHealth > 225)
                    {
                        football.JHealth = 225;
                    }
                    football.SpecialMeter = 0;
                }
            }
        }

        protected void CheerCombat()
        {
            //Button click for attacking
            if (mState.X >= 1545 && mState.X <= 1845 && mState.Y >= 815 && mState.Y < 900 && mState.LeftButton == ButtonState.Pressed && LastmState.LeftButton != mState.LeftButton)
            {
                cheer.SpecialMeter += 15;

                if (round == 1)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = cheer.Attack();
                    if (num >= 0 && num < 50)
                    {
                        e1Round1.EHealth = e1Round1.EHealth - attack;
                    }
                    else
                    {
                        e2Round1.EHealth = e2Round1.EHealth - attack;
                    }
                    if (e1Round1.EHealth <= 0)
                    {
                        e1Round1.EHealth = 0;
                        e1Round1.IsAlive = false;
                    }
                    if (e2Round1.EHealth <= 0)
                    {
                        e2Round1.EHealth = 0;
                        e2Round1.IsAlive = false;
                    };

                    round1State = Round1States.Enemy2Turn;
                }

                if (round == 2)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = cheer.Attack();
                    if (num >= 0 && num < 50)
                    {
                        e1Round2.EHealth = e1Round2.EHealth - attack;
                    }
                    else
                    {
                        e2Round2.EHealth = e2Round2.EHealth - attack;
                    }
                    if (e1Round2.EHealth <= 0)
                    {
                        e1Round2.EHealth = 0;
                        e1Round2.IsAlive = false;
                    }
                    if (e2Round2.EHealth <= 0)
                    {
                        e2Round2.EHealth = 0;
                        e2Round2.IsAlive = false;
                    };

                    round2State = Round2States.EnemyTurn;
                }

                if (round == 3)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = cheer.Attack();
                    if (num >= 0 && num <= 40)
                    {
                        e1Round3.EHealth = e1Round3.EHealth - attack;
                    }
                    else if (num >= 41 && num < 60)
                    {
                        e2Round3.EHealth = e2Round3.EHealth - attack;
                    }
                    else
                    {
                        bossRound3.EHealth = bossRound3.EHealth - attack;
                    }
                    if (e1Round3.EHealth <= 0)
                    {
                        e1Round3.EHealth = 0;
                        e1Round3.IsAlive = false;
                    }
                    if (e2Round3.EHealth <= 0)
                    {
                        e2Round3.EHealth = 0;
                        e2Round3.IsAlive = false;
                    }
                    if (bossRound3.EHealth <= 0)
                    {
                        bossRound3.EHealth = 0;
                        bossRound3.IsAlive = false;
                    }

                    round3State = Round3States.NerdTurn;
                }

                if (round == 4)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = cheer.Attack();
                    if (num >= 0 && num < 50)
                    {
                        e1Round4.EHealth = e1Round4.EHealth - attack;
                    }
                    else
                    {
                        e2Round4.EHealth = e2Round4.EHealth - attack;
                    }
                    if (e1Round4.EHealth <= 0)
                    {
                        e1Round4.EHealth = 0;
                        e1Round4.IsAlive = false;
                    }
                    if (e2Round4.EHealth <= 0)
                    {
                        e2Round4.EHealth = 0;
                        e2Round4.IsAlive = false;
                    };

                    round4State = Round4States.EnemyTurn;
                }

                if (round == 5)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = cheer.Attack();
                    if (num >= 0 && num < 50)
                    {
                        e1Round5.EHealth = e1Round5.EHealth - attack;
                    }
                    else
                    {
                        e2Round5.EHealth = e2Round5.EHealth - attack;
                    }
                    if (e1Round5.EHealth <= 0)
                    {
                        e1Round5.EHealth = 0;
                        e1Round5.IsAlive = false;
                    }
                    if (e2Round5.EHealth <= 0)
                    {
                        e2Round5.EHealth = 0;
                        e2Round5.IsAlive = false;
                    };

                    round5State = Round5States.NerdTurn;
                }

                if (round == 6)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = cheer.Attack();
                    if (num >= 0 && num <= 40)
                    {
                        e1Round6.EHealth = e1Round6.EHealth - attack;
                    }
                    else if (num >= 41 && num < 60)
                    {
                        e2Round6.EHealth = e2Round6.EHealth - attack;
                    }
                    else
                    {
                        e3Round6.EHealth = e3Round6.EHealth - attack;
                    }
                    if (e1Round6.EHealth <= 0)
                    {
                        e1Round6.EHealth = 0;
                        e1Round6.IsAlive = false;
                    }
                    if (e2Round6.EHealth <= 0)
                    {
                        e2Round6.EHealth = 0;
                        e2Round6.IsAlive = false;
                    }
                    if (e3Round6.EHealth <= 0)
                    {
                        e3Round6.EHealth = 0;
                        e3Round6.IsAlive = false;
                    }

                    round6State = Round6States.EnemyTurn;
                }

                if (round == 7)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = cheer.Attack();
                    if (num >= 0 && num <= 40)
                    {
                        e1Round7.EHealth = e1Round7.EHealth - attack;
                    }
                    else if (num >= 41 && num < 60)
                    {
                        e2Round7.EHealth = e2Round7.EHealth - attack;
                    }
                    else
                    {
                        bossRound7.EHealth = bossRound7.EHealth - attack;
                    }
                    if (e1Round7.EHealth <= 0)
                    {
                        e1Round7.EHealth = 0;
                        e1Round7.IsAlive = false;
                    }
                    if (e2Round7.EHealth <= 0)
                    {
                        e2Round7.EHealth = 0;
                        e2Round7.IsAlive = false;
                    }
                    if (bossRound7.EHealth <= 0)
                    {
                        bossRound7.EHealth = 0;
                        bossRound7.IsAlive = false;
                    }

                    round7State = Round7States.NerdTurn;
                }

                if (round == 8)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = cheer.Attack();
                    if (num >= 0 && num <= 40)
                    {
                        e1Round8.EHealth = e1Round8.EHealth - attack;
                    }
                    else if (num >= 41 && num < 60)
                    {
                        e2Round8.EHealth = e2Round8.EHealth - attack;
                    }
                    else
                    {
                        e3Round8.EHealth = e3Round8.EHealth - attack;
                    }
                    if (e1Round8.EHealth <= 0)
                    {
                        e1Round8.EHealth = 0;
                        e1Round8.IsAlive = false;
                    }
                    if (e2Round8.EHealth <= 0)
                    {
                        e2Round8.EHealth = 0;
                        e2Round8.IsAlive = false;
                    }
                    if (e3Round8.EHealth <= 0)
                    {
                        e3Round8.EHealth = 0;
                        e3Round8.IsAlive = false;
                    }

                    round8State = Round8States.JockTurn;
                }

                if (round == 9)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = cheer.Attack();
                    if (num >= 0 && num <= 40)
                    {
                        e1Round9.EHealth = e1Round9.EHealth - attack;
                    }
                    else if (num >= 41 && num < 60)
                    {
                        e2Round9.EHealth = e2Round9.EHealth - attack;
                    }
                    else
                    {
                        e3Round9.EHealth = e3Round9.EHealth - attack;
                    }
                    if (e1Round9.EHealth <= 0)
                    {
                        e1Round9.EHealth = 0;
                        e1Round9.IsAlive = false;
                    }
                    if (e2Round9.EHealth <= 0)
                    {
                        e2Round9.EHealth = 0;
                        e2Round9.IsAlive = false;
                    }
                    if (e3Round9.EHealth <= 0)
                    {
                        e3Round9.EHealth = 0;
                        e3Round9.IsAlive = false;
                    }

                    round9State = Round9States.Enemy2Turn;
                }

                if (round == 10)
                {
                    Random rng = new Random();
                    int num = rng.Next(101);

                    int attack = cheer.Attack();
                    if (num >= 0 && num <= 40)
                    {
                        e1Round10.EHealth = e1Round10.EHealth - attack;
                    }
                    else if (num >= 41 && num < 60)
                    {
                        e2Round10.EHealth = e2Round10.EHealth - attack;
                    }
                    else
                    {
                        bossFinal.EHealth = bossFinal.EHealth - attack;
                    }
                    if (e1Round10.EHealth <= 0)
                    {
                        e1Round10.EHealth = 0;
                        e1Round10.IsAlive = false;
                    }
                    if (e2Round10.EHealth <= 0)
                    {
                        e2Round10.EHealth = 0;
                        e2Round10.IsAlive = false;
                    }
                    if (bossFinal.EHealth <= 0)
                    {
                        bossFinal.EHealth = 0;
                        bossFinal.IsAlive = false;
                    }

                    round10State = Round10States.EnemyTurn;
                }
            }

            if (mState.X >= 1545 && mState.X <= 1845 && mState.Y >= 910 && mState.Y < 995 && mState.LeftButton == ButtonState.Pressed && LastmState.LeftButton != mState.LeftButton)
            {
                if (cheer.SpecialMeter >= 100)
                {
                    if (round == 1)
                    {
                        int attack = cheer.Attack();

                        e1Round1.EHealth = e1Round1.EHealth - attack;

                        e2Round1.EHealth = e2Round1.EHealth - attack;

                        if (e1Round1.EHealth <= 0)
                        {
                            e1Round1.EHealth = 0;
                            e1Round1.IsAlive = false;
                        }
                        if (e2Round1.EHealth <= 0)
                        {
                            e2Round1.EHealth = 0;
                            e2Round1.IsAlive = false;
                        };

                        cheer.SpecialMeter = 0;
                        round1State = Round1States.Enemy2Turn;
                    }

                    if (round == 2)
                    {

                        int attack = cheer.Attack();

                        e1Round2.EHealth = e1Round2.EHealth - attack;

                        e2Round2.EHealth = e2Round2.EHealth - attack;

                        if (e1Round2.EHealth <= 0)
                        {
                            e1Round2.EHealth = 0;
                            e1Round2.IsAlive = false;
                        }
                        if (e2Round2.EHealth <= 0)
                        {
                            e2Round2.EHealth = 0;
                            e2Round2.IsAlive = false;
                        };

                        cheer.SpecialMeter = 0;
                        round2State = Round2States.EnemyTurn;
                    }

                    if (round == 3)
                    {
                        int attack = cheer.Attack();

                        e1Round3.EHealth = e1Round3.EHealth - attack;

                        e2Round3.EHealth = e2Round3.EHealth - attack;

                        bossRound3.EHealth = bossRound3.EHealth - attack;

                        if (e1Round3.EHealth <= 0)
                        {
                            e1Round3.EHealth = 0;
                            e1Round3.IsAlive = false;
                        }
                        if (e2Round3.EHealth <= 0)
                        {
                            e2Round3.EHealth = 0;
                            e2Round3.IsAlive = false;
                        }
                        if (bossRound3.EHealth <= 0)
                        {
                            bossRound3.EHealth = 0;
                            bossRound3.IsAlive = false;
                        }

                        cheer.SpecialMeter = 0;
                        round3State = Round3States.NerdTurn;
                    }

                    if (round == 4)
                    {
                        int attack = cheer.Attack();

                        e1Round4.EHealth = e1Round4.EHealth - attack;

                        e2Round4.EHealth = e2Round4.EHealth - attack;

                        if (e1Round4.EHealth <= 0)
                        {
                            e1Round4.EHealth = 0;
                            e1Round4.IsAlive = false;
                        }
                        if (e2Round4.EHealth <= 0)
                        {
                            e2Round4.EHealth = 0;
                            e2Round4.IsAlive = false;
                        };

                        cheer.SpecialMeter = 0;
                        round4State = Round4States.EnemyTurn;
                    }

                    if (round == 5)
                    {
                        int attack = cheer.Attack();

                        e1Round5.EHealth = e1Round5.EHealth - attack;

                        e2Round5.EHealth = e2Round5.EHealth - attack;

                        if (e1Round5.EHealth <= 0)
                        {
                            e1Round5.EHealth = 0;
                            e1Round5.IsAlive = false;
                        }
                        if (e2Round5.EHealth <= 0)
                        {
                            e2Round5.EHealth = 0;
                            e2Round5.IsAlive = false;
                        };

                        cheer.SpecialMeter = 0;
                        round5State = Round5States.NerdTurn;
                    }

                    if (round == 6)
                    {
                        int attack = cheer.Attack();

                        e1Round6.EHealth = e1Round6.EHealth - attack;

                        e2Round6.EHealth = e2Round6.EHealth - attack;

                        e3Round6.EHealth = e3Round6.EHealth - attack;

                        if (e1Round6.EHealth <= 0)
                        {
                            e1Round6.EHealth = 0;
                            e1Round6.IsAlive = false;
                        }
                        if (e2Round6.EHealth <= 0)
                        {
                            e2Round6.EHealth = 0;
                            e2Round6.IsAlive = false;
                        }
                        if (e3Round6.EHealth <= 0)
                        {
                            e3Round6.EHealth = 0;
                            e3Round6.IsAlive = false;
                        }

                        cheer.SpecialMeter = 0;
                        round6State = Round6States.EnemyTurn;
                    }

                    if (round == 7)
                    {
                        int attack = cheer.Attack();

                        e1Round7.EHealth = e1Round7.EHealth - attack;

                        e2Round7.EHealth = e2Round7.EHealth - attack;

                        bossRound7.EHealth = bossRound7.EHealth - attack;

                        if (e1Round7.EHealth <= 0)
                        {
                            e1Round7.EHealth = 0;
                            e1Round7.IsAlive = false;
                        }
                        if (e2Round7.EHealth <= 0)
                        {
                            e2Round7.EHealth = 0;
                            e2Round7.IsAlive = false;
                        }
                        if (bossRound7.EHealth <= 0)
                        {
                            bossRound7.EHealth = 0;
                            bossRound7.IsAlive = false;
                        }

                        cheer.SpecialMeter = 0;
                        round7State = Round7States.NerdTurn;
                    }

                    if (round == 8)
                    {
                        int attack = cheer.Attack();

                        e1Round8.EHealth = e1Round8.EHealth - attack;

                        e2Round8.EHealth = e2Round8.EHealth - attack;

                        e3Round8.EHealth = e3Round8.EHealth - attack;

                        if (e1Round8.EHealth <= 0)
                        {
                            e1Round8.EHealth = 0;
                            e1Round8.IsAlive = false;
                        }
                        if (e2Round8.EHealth <= 0)
                        {
                            e2Round8.EHealth = 0;
                            e2Round8.IsAlive = false;
                        }
                        if (e3Round8.EHealth <= 0)
                        {
                            e3Round8.EHealth = 0;
                            e3Round8.IsAlive = false;
                        }

                        cheer.SpecialMeter = 0;
                        round8State = Round8States.JockTurn;
                    }

                    if (round == 9)
                    {
                        int attack = cheer.Attack();

                        e1Round9.EHealth = e1Round9.EHealth - attack;

                        e2Round9.EHealth = e2Round9.EHealth - attack;

                        e3Round9.EHealth = e3Round9.EHealth - attack;

                        if (e1Round9.EHealth <= 0)
                        {
                            e1Round9.EHealth = 0;
                            e1Round9.IsAlive = false;
                        }
                        if (e2Round9.EHealth <= 0)
                        {
                            e2Round9.EHealth = 0;
                            e2Round9.IsAlive = false;
                        }
                        if (e3Round9.EHealth <= 0)
                        {
                            e3Round9.EHealth = 0;
                            e3Round9.IsAlive = false;
                        }

                        cheer.SpecialMeter = 0;
                        round9State = Round9States.Enemy2Turn;
                    }

                    if (round == 10)
                    {
                        int attack = cheer.Attack();

                        e1Round10.EHealth = e1Round10.EHealth - attack;

                        e2Round10.EHealth = e2Round10.EHealth - attack;

                        bossFinal.EHealth = bossFinal.EHealth - attack;

                        if (e1Round10.EHealth <= 0)
                        {
                            e1Round10.EHealth = 0;
                            e1Round10.IsAlive = false;
                        }
                        if (e2Round10.EHealth <= 0)
                        {
                            e2Round10.EHealth = 0;
                            e2Round10.IsAlive = false;
                        }
                        if (bossFinal.EHealth <= 0)
                        {
                            bossFinal.EHealth = 0;
                            bossFinal.IsAlive = false;
                        }

                        cheer.SpecialMeter = 0;
                        round10State = Round10States.EnemyTurn;
                    }
                }
            }

        }

        protected void FileLoader()
        {
            if(dstate == DifficultyStates.Easy)
            {
                // Enemy 1
                BinaryReader e1Round1Load = new BinaryReader(File.OpenRead("Enemy Maker (Easy)1.dat"));

                e1Round1Health = e1Round1Load.ReadInt32();
                e1Round1Attack = e1Round1Load.ReadInt32();
                e1Round1Defense = e1Round1Load.ReadInt32();
                e1Round1Speed = e1Round1Load.ReadInt32();

                e1Round1Load.Close();

                // Enemy 2
                BinaryReader e2Round1Load = new BinaryReader(File.OpenRead("Enemy Maker (Easy)2.dat"));

                e2Round1Health = e2Round1Load.ReadInt32();
                e2Round1Attack = e2Round1Load.ReadInt32();
                e2Round1Defense = e2Round1Load.ReadInt32();
                e2Round1Speed = e2Round1Load.ReadInt32();

                e2Round1Load.Close();

                // Enemy 3
                BinaryReader e1Round2Load = new BinaryReader(File.OpenRead("Enemy Maker (Easy)3.dat"));

                e1Round2Health = e1Round2Load.ReadInt32();
                e1Round2Attack = e1Round2Load.ReadInt32();
                e1Round2Defense = e1Round2Load.ReadInt32();
                e1Round2Speed = e1Round2Load.ReadInt32();

                e1Round2Load.Close();

                // Enemy 4
                BinaryReader e2Round2Load = new BinaryReader(File.OpenRead("Enemy Maker (Easy)4.dat"));

                e2Round2Health = e2Round2Load.ReadInt32();
                e2Round2Attack = e2Round2Load.ReadInt32();
                e2Round2Defense = e2Round2Load.ReadInt32();
                e2Round2Speed = e2Round2Load.ReadInt32();

                e2Round2Load.Close();

                // Enemy 5
                BinaryReader e1Round3Load = new BinaryReader(File.OpenRead("Enemy Maker (Easy)5.dat"));

                e1Round3Health = e1Round3Load.ReadInt32();
                e1Round3Attack = e1Round3Load.ReadInt32();
                e1Round3Defense = e1Round3Load.ReadInt32();
                e1Round3Speed = e1Round3Load.ReadInt32();

                e1Round3Load.Close();

                // Enemy 6
                BinaryReader e2Round3Load = new BinaryReader(File.OpenRead("Enemy Maker (Easy)6.dat"));

                e2Round3Health = e2Round3Load.ReadInt32();
                e2Round3Attack = e2Round3Load.ReadInt32();
                e2Round3Defense = e2Round3Load.ReadInt32();
                e2Round3Speed = e2Round3Load.ReadInt32();

                e2Round3Load.Close();

                // Enemy 7
                BinaryReader e1Round4Load = new BinaryReader(File.OpenRead("Enemy Maker (Easy)7.dat"));

                e1Round4Health = e1Round4Load.ReadInt32();
                e1Round4Attack = e1Round4Load.ReadInt32();
                e1Round4Defense = e1Round4Load.ReadInt32();
                e1Round4Speed = e1Round4Load.ReadInt32();

                e1Round4Load.Close();

                // Enemy 8
                BinaryReader e2Round4Load = new BinaryReader(File.OpenRead("Enemy Maker (Easy)8.dat"));

                e2Round4Health = e2Round4Load.ReadInt32();
                e2Round4Attack = e2Round4Load.ReadInt32();
                e2Round4Defense = e2Round4Load.ReadInt32();
                e2Round4Speed = e2Round4Load.ReadInt32();

                e2Round1Load.Close();

                // Enemy 9
                BinaryReader e1Round5Load = new BinaryReader(File.OpenRead("Enemy Maker (Easy)9.dat"));

                e1Round5Health = e1Round5Load.ReadInt32();
                e1Round5Attack = e1Round5Load.ReadInt32();
                e1Round5Defense = e1Round5Load.ReadInt32();
                e1Round5Speed = e1Round5Load.ReadInt32();

                e1Round5Load.Close();

                // Enemy 10
                BinaryReader e2Round5Load = new BinaryReader(File.OpenRead("Enemy Maker (Easy)10.dat"));

                e2Round5Health = e2Round5Load.ReadInt32();
                e2Round5Attack = e2Round5Load.ReadInt32();
                e2Round5Defense = e2Round5Load.ReadInt32();
                e2Round5Speed = e2Round5Load.ReadInt32();

                e2Round5Load.Close();

                // Enemy 11
                BinaryReader e1Round6Load = new BinaryReader(File.OpenRead("Enemy Maker (Easy)11.dat"));

                e1Round6Health = e1Round6Load.ReadInt32();
                e1Round6Attack = e1Round6Load.ReadInt32();
                e1Round6Defense = e1Round6Load.ReadInt32();
                e1Round6Speed = e1Round6Load.ReadInt32();

                e1Round6Load.Close();

                // Enemy 12
                BinaryReader e2Round6Load = new BinaryReader(File.OpenRead("Enemy Maker (Easy)12.dat"));

                e2Round6Health = e2Round6Load.ReadInt32();
                e2Round6Attack = e2Round6Load.ReadInt32();
                e2Round6Defense = e2Round6Load.ReadInt32();
                e2Round6Speed = e2Round6Load.ReadInt32();

                e2Round1Load.Close();

                // Enemy 13
                BinaryReader e3Round6Load = new BinaryReader(File.OpenRead("Enemy Maker (Easy)13.dat"));
                e3Round6Health = e3Round6Load.ReadInt32();
                e3Round6Attack = e3Round6Load.ReadInt32();
                e3Round6Defense = e3Round6Load.ReadInt32();
                e3Round6Speed = e3Round6Load.ReadInt32();

                e3Round6Load.Close();

                // Enemy 14
                BinaryReader e1Round7Load = new BinaryReader(File.OpenRead("Enemy Maker (Easy)14.dat"));

                e1Round7Health = e1Round7Load.ReadInt32();
                e1Round7Attack = e1Round7Load.ReadInt32();
                e1Round7Defense = e1Round7Load.ReadInt32();
                e1Round7Speed = e1Round7Load.ReadInt32();

                e1Round7Load.Close();

                // Enemy 15
                BinaryReader e2Round7Load = new BinaryReader(File.OpenRead("Enemy Maker (Easy)15.dat"));

                e2Round7Health = e2Round7Load.ReadInt32();
                e2Round7Attack = e2Round7Load.ReadInt32();
                e2Round7Defense = e2Round7Load.ReadInt32();
                e2Round7Speed = e2Round7Load.ReadInt32();

                e2Round7Load.Close();

                // Enemy 16
                BinaryReader e1Round8Load = new BinaryReader(File.OpenRead("Enemy Maker (Easy)16.dat"));

                e1Round8Health = e1Round8Load.ReadInt32();
                e1Round8Attack = e1Round8Load.ReadInt32();
                e1Round8Defense = e1Round8Load.ReadInt32();
                e1Round8Speed = e1Round8Load.ReadInt32();

                e1Round8Load.Close();

                // Enemy 17
                BinaryReader e2Round8Load = new BinaryReader(File.OpenRead("Enemy Maker (Easy)17.dat"));

                e2Round8Health = e2Round8Load.ReadInt32();
                e2Round8Attack = e2Round8Load.ReadInt32();
                e2Round8Defense = e2Round8Load.ReadInt32();
                e2Round8Speed = e2Round8Load.ReadInt32();

                e2Round8Load.Close();

                // Enemy 18
                BinaryReader e3Round8Load = new BinaryReader(File.OpenRead("Enemy Maker (Easy)18.dat"));

                e3Round8Health = e3Round8Load.ReadInt32();
                e3Round8Attack = e3Round8Load.ReadInt32();
                e3Round8Defense = e3Round8Load.ReadInt32();
                e3Round8Speed = e3Round8Load.ReadInt32();

                e3Round8Load.Close();

                // Enemy 19
                BinaryReader e1Round9Load = new BinaryReader(File.OpenRead("Enemy Maker (Easy)19.dat"));

                e1Round9Health = e1Round9Load.ReadInt32();
                e1Round9Attack = e1Round9Load.ReadInt32();
                e1Round9Defense = e1Round9Load.ReadInt32();
                e1Round9Speed = e1Round9Load.ReadInt32();

                e1Round9Load.Close();

                // Enemy 20
                BinaryReader e2Round9Load = new BinaryReader(File.OpenRead("Enemy Maker (Easy)20.dat"));

                e2Round9Health = e2Round9Load.ReadInt32();
                e2Round9Attack = e2Round9Load.ReadInt32();
                e2Round9Defense = e2Round9Load.ReadInt32();
                e2Round9Speed = e2Round9Load.ReadInt32();

                e2Round9Load.Close();

                // Enemy 21
                BinaryReader e3Round9Load = new BinaryReader(File.OpenRead("Enemy Maker (Easy)21.dat"));

                e3Round9Health = e3Round9Load.ReadInt32();
                e3Round9Attack = e3Round9Load.ReadInt32();
                e3Round9Defense = e3Round9Load.ReadInt32();
                e3Round9Speed = e3Round9Load.ReadInt32();

                e3Round9Load.Close();

                // Enemy 22
                BinaryReader e1Round10Load = new BinaryReader(File.OpenRead("Enemy Maker (Easy)22.dat"));

                e1Round10Health = e1Round10Load.ReadInt32();
                e1Round10Attack = e1Round10Load.ReadInt32();
                e1Round10Defense = e1Round10Load.ReadInt32();
                e1Round10Speed = e1Round10Load.ReadInt32();

                e1Round10Load.Close();

                // Enemy 23
                BinaryReader e2Round10Load = new BinaryReader(File.OpenRead("Enemy Maker (Easy)23.dat"));

                e2Round10Health = e2Round10Load.ReadInt32();
                e2Round10Attack = e2Round10Load.ReadInt32();
                e2Round10Defense = e2Round10Load.ReadInt32();
                e2Round10Speed = e2Round10Load.ReadInt32();

                e2Round10Load.Close();
            }
            if(dstate == DifficultyStates.Normal)
            {
                // Enemy 1
                BinaryReader e1Round1Load = new BinaryReader(File.OpenRead("Enemy Maker (Normal)1.dat"));

                e1Round1Health = e1Round1Load.ReadInt32();
                e1Round1Attack = e1Round1Load.ReadInt32();
                e1Round1Defense = e1Round1Load.ReadInt32();
                e1Round1Speed = e1Round1Load.ReadInt32();

                e1Round1Load.Close();

                // Enemy 2
                BinaryReader e2Round1Load = new BinaryReader(File.OpenRead("Enemy Maker (Normal)2.dat"));

                e2Round1Health = e2Round1Load.ReadInt32();
                e2Round1Attack = e2Round1Load.ReadInt32();
                e2Round1Defense = e2Round1Load.ReadInt32();
                e2Round1Speed = e2Round1Load.ReadInt32();

                e2Round1Load.Close();

                // Enemy 3
                BinaryReader e1Round2Load = new BinaryReader(File.OpenRead("Enemy Maker (Normal)3.dat"));

                e1Round2Health = e1Round2Load.ReadInt32();
                e1Round2Attack = e1Round2Load.ReadInt32();
                e1Round2Defense = e1Round2Load.ReadInt32();
                e1Round2Speed = e1Round2Load.ReadInt32();

                e1Round2Load.Close();

                // Enemy 4
                BinaryReader e2Round2Load = new BinaryReader(File.OpenRead("Enemy Maker (Normal)4.dat"));

                e2Round2Health = e2Round2Load.ReadInt32();
                e2Round2Attack = e2Round2Load.ReadInt32();
                e2Round2Defense = e2Round2Load.ReadInt32();
                e2Round2Speed = e2Round2Load.ReadInt32();

                e2Round2Load.Close();

                // Enemy 5
                BinaryReader e1Round3Load = new BinaryReader(File.OpenRead("Enemy Maker (Normal)5.dat"));

                e1Round3Health = e1Round3Load.ReadInt32();
                e1Round3Attack = e1Round3Load.ReadInt32();
                e1Round3Defense = e1Round3Load.ReadInt32();
                e1Round3Speed = e1Round3Load.ReadInt32();

                e1Round3Load.Close();

                // Enemy 6
                BinaryReader e2Round3Load = new BinaryReader(File.OpenRead("Enemy Maker (Normal)6.dat"));

                e2Round3Health = e2Round3Load.ReadInt32();
                e2Round3Attack = e2Round3Load.ReadInt32();
                e2Round3Defense = e2Round3Load.ReadInt32();
                e2Round3Speed = e2Round3Load.ReadInt32();

                e2Round3Load.Close();

                // Enemy 7
                BinaryReader e1Round4Load = new BinaryReader(File.OpenRead("Enemy Maker (Normal)7.dat"));

                e1Round4Health = e1Round4Load.ReadInt32();
                e1Round4Attack = e1Round4Load.ReadInt32();
                e1Round4Defense = e1Round4Load.ReadInt32();
                e1Round4Speed = e1Round4Load.ReadInt32();

                e1Round4Load.Close();

                // Enemy 8
                BinaryReader e2Round4Load = new BinaryReader(File.OpenRead("Enemy Maker (Normal)8.dat"));

                e2Round4Health = e2Round4Load.ReadInt32();
                e2Round4Attack = e2Round4Load.ReadInt32();
                e2Round4Defense = e2Round4Load.ReadInt32();
                e2Round4Speed = e2Round4Load.ReadInt32();

                e2Round1Load.Close();

                // Enemy 9
                BinaryReader e1Round5Load = new BinaryReader(File.OpenRead("Enemy Maker (Normal)9.dat"));

                e1Round5Health = e1Round5Load.ReadInt32();
                e1Round5Attack = e1Round5Load.ReadInt32();
                e1Round5Defense = e1Round5Load.ReadInt32();
                e1Round5Speed = e1Round5Load.ReadInt32();

                e1Round5Load.Close();

                // Enemy 10
                BinaryReader e2Round5Load = new BinaryReader(File.OpenRead("Enemy Maker (Normal)10.dat"));

                e2Round5Health = e2Round5Load.ReadInt32();
                e2Round5Attack = e2Round5Load.ReadInt32();
                e2Round5Defense = e2Round5Load.ReadInt32();
                e2Round5Speed = e2Round5Load.ReadInt32();

                e2Round5Load.Close();

                // Enemy 11
                BinaryReader e1Round6Load = new BinaryReader(File.OpenRead("Enemy Maker (Normal)11.dat"));

                e1Round6Health = e1Round6Load.ReadInt32();
                e1Round6Attack = e1Round6Load.ReadInt32();
                e1Round6Defense = e1Round6Load.ReadInt32();
                e1Round6Speed = e1Round6Load.ReadInt32();

                e1Round6Load.Close();

                // Enemy 12
                BinaryReader e2Round6Load = new BinaryReader(File.OpenRead("Enemy Maker (Normal)12.dat"));

                e2Round6Health = e2Round6Load.ReadInt32();
                e2Round6Attack = e2Round6Load.ReadInt32();
                e2Round6Defense = e2Round6Load.ReadInt32();
                e2Round6Speed = e2Round6Load.ReadInt32();

                e2Round1Load.Close();

                // Enemy 13
                BinaryReader e3Round6Load = new BinaryReader(File.OpenRead("Enemy Maker (Normal)13.dat"));
                e3Round6Health = e3Round6Load.ReadInt32();
                e3Round6Attack = e3Round6Load.ReadInt32();
                e3Round6Defense = e3Round6Load.ReadInt32();
                e3Round6Speed = e3Round6Load.ReadInt32();

                e3Round6Load.Close();

                // Enemy 14
                BinaryReader e1Round7Load = new BinaryReader(File.OpenRead("Enemy Maker (Normal)14.dat"));

                e1Round7Health = e1Round7Load.ReadInt32();
                e1Round7Attack = e1Round7Load.ReadInt32();
                e1Round7Defense = e1Round7Load.ReadInt32();
                e1Round7Speed = e1Round7Load.ReadInt32();

                e1Round7Load.Close();

                // Enemy 15
                BinaryReader e2Round7Load = new BinaryReader(File.OpenRead("Enemy Maker (Normal)15.dat"));

                e2Round7Health = e2Round7Load.ReadInt32();
                e2Round7Attack = e2Round7Load.ReadInt32();
                e2Round7Defense = e2Round7Load.ReadInt32();
                e2Round7Speed = e2Round7Load.ReadInt32();

                e2Round7Load.Close();

                // Enemy 16
                BinaryReader e1Round8Load = new BinaryReader(File.OpenRead("Enemy Maker (Normal)16.dat"));

                e1Round8Health = e1Round8Load.ReadInt32();
                e1Round8Attack = e1Round8Load.ReadInt32();
                e1Round8Defense = e1Round8Load.ReadInt32();
                e1Round8Speed = e1Round8Load.ReadInt32();

                e1Round8Load.Close();

                // Enemy 17
                BinaryReader e2Round8Load = new BinaryReader(File.OpenRead("Enemy Maker (Normal)17.dat"));

                e2Round8Health = e2Round8Load.ReadInt32();
                e2Round8Attack = e2Round8Load.ReadInt32();
                e2Round8Defense = e2Round8Load.ReadInt32();
                e2Round8Speed = e2Round8Load.ReadInt32();

                e2Round8Load.Close();

                // Enemy 18
                BinaryReader e3Round8Load = new BinaryReader(File.OpenRead("Enemy Maker (Normal)18.dat"));

                e3Round8Health = e3Round8Load.ReadInt32();
                e3Round8Attack = e3Round8Load.ReadInt32();
                e3Round8Defense = e3Round8Load.ReadInt32();
                e3Round8Speed = e3Round8Load.ReadInt32();

                e3Round8Load.Close();

                // Enemy 19
                BinaryReader e1Round9Load = new BinaryReader(File.OpenRead("Enemy Maker (Normal)19.dat"));

                e1Round9Health = e1Round9Load.ReadInt32();
                e1Round9Attack = e1Round9Load.ReadInt32();
                e1Round9Defense = e1Round9Load.ReadInt32();
                e1Round9Speed = e1Round9Load.ReadInt32();

                e1Round9Load.Close();

                // Enemy 20
                BinaryReader e2Round9Load = new BinaryReader(File.OpenRead("Enemy Maker (Normal)20.dat"));

                e2Round9Health = e2Round9Load.ReadInt32();
                e2Round9Attack = e2Round9Load.ReadInt32();
                e2Round9Defense = e2Round9Load.ReadInt32();
                e2Round9Speed = e2Round9Load.ReadInt32();

                e2Round9Load.Close();

                // Enemy 21
                BinaryReader e3Round9Load = new BinaryReader(File.OpenRead("Enemy Maker (Normal)21.dat"));

                e3Round9Health = e3Round9Load.ReadInt32();
                e3Round9Attack = e3Round9Load.ReadInt32();
                e3Round9Defense = e3Round9Load.ReadInt32();
                e3Round9Speed = e3Round9Load.ReadInt32();

                e3Round9Load.Close();

                // Enemy 22
                BinaryReader e1Round10Load = new BinaryReader(File.OpenRead("Enemy Maker (Normal)22.dat"));

                e1Round10Health = e1Round10Load.ReadInt32();
                e1Round10Attack = e1Round10Load.ReadInt32();
                e1Round10Defense = e1Round10Load.ReadInt32();
                e1Round10Speed = e1Round10Load.ReadInt32();

                e1Round10Load.Close();

                // Enemy 23
                BinaryReader e2Round10Load = new BinaryReader(File.OpenRead("Enemy Maker (Normal)23.dat"));

                e2Round10Health = e2Round10Load.ReadInt32();
                e2Round10Attack = e2Round10Load.ReadInt32();
                e2Round10Defense = e2Round10Load.ReadInt32();
                e2Round10Speed = e2Round10Load.ReadInt32();

                e2Round10Load.Close();
            }
            if(dstate == DifficultyStates.Nightmare)
            {
                // Enemy 1
                BinaryReader e1Round1Load = new BinaryReader(File.OpenRead("Enemy Maker (Nightmare)1.dat"));

                e1Round1Health = e1Round1Load.ReadInt32();
                e1Round1Attack = e1Round1Load.ReadInt32();
                e1Round1Defense = e1Round1Load.ReadInt32();
                e1Round1Speed = e1Round1Load.ReadInt32();

                e1Round1Load.Close();

                // Enemy 2
                BinaryReader e2Round1Load = new BinaryReader(File.OpenRead("Enemy Maker (Nightmare)2.dat"));

                e2Round1Health = e2Round1Load.ReadInt32();
                e2Round1Attack = e2Round1Load.ReadInt32();
                e2Round1Defense = e2Round1Load.ReadInt32();
                e2Round1Speed = e2Round1Load.ReadInt32();

                e2Round1Load.Close();

                // Enemy 3
                BinaryReader e1Round2Load = new BinaryReader(File.OpenRead("Enemy Maker (Nightmare)3.dat"));

                e1Round2Health = e1Round2Load.ReadInt32();
                e1Round2Attack = e1Round2Load.ReadInt32();
                e1Round2Defense = e1Round2Load.ReadInt32();
                e1Round2Speed = e1Round2Load.ReadInt32();

                e1Round2Load.Close();

                // Enemy 4
                BinaryReader e2Round2Load = new BinaryReader(File.OpenRead("Enemy Maker (Nightmare)4.dat"));

                e2Round2Health = e2Round2Load.ReadInt32();
                e2Round2Attack = e2Round2Load.ReadInt32();
                e2Round2Defense = e2Round2Load.ReadInt32();
                e2Round2Speed = e2Round2Load.ReadInt32();

                e2Round2Load.Close();

                // Enemy 5
                BinaryReader e1Round3Load = new BinaryReader(File.OpenRead("Enemy Maker (Nightmare)5.dat"));

                e1Round3Health = e1Round3Load.ReadInt32();
                e1Round3Attack = e1Round3Load.ReadInt32();
                e1Round3Defense = e1Round3Load.ReadInt32();
                e1Round3Speed = e1Round3Load.ReadInt32();

                e1Round3Load.Close();

                // Enemy 6
                BinaryReader e2Round3Load = new BinaryReader(File.OpenRead("Enemy Maker (Nightmare)6.dat"));

                e2Round3Health = e2Round3Load.ReadInt32();
                e2Round3Attack = e2Round3Load.ReadInt32();
                e2Round3Defense = e2Round3Load.ReadInt32();
                e2Round3Speed = e2Round3Load.ReadInt32();

                e2Round3Load.Close();

                // Enemy 7
                BinaryReader e1Round4Load = new BinaryReader(File.OpenRead("Enemy Maker (Nightmare)7.dat"));

                e1Round4Health = e1Round4Load.ReadInt32();
                e1Round4Attack = e1Round4Load.ReadInt32();
                e1Round4Defense = e1Round4Load.ReadInt32();
                e1Round4Speed = e1Round4Load.ReadInt32();

                e1Round4Load.Close();

                // Enemy 8
                BinaryReader e2Round4Load = new BinaryReader(File.OpenRead("Enemy Maker (Nightmare)8.dat"));

                e2Round4Health = e2Round4Load.ReadInt32();
                e2Round4Attack = e2Round4Load.ReadInt32();
                e2Round4Defense = e2Round4Load.ReadInt32();
                e2Round4Speed = e2Round4Load.ReadInt32();

                e2Round1Load.Close();

                // Enemy 9
                BinaryReader e1Round5Load = new BinaryReader(File.OpenRead("Enemy Maker (Nightmare)9.dat"));

                e1Round5Health = e1Round5Load.ReadInt32();
                e1Round5Attack = e1Round5Load.ReadInt32();
                e1Round5Defense = e1Round5Load.ReadInt32();
                e1Round5Speed = e1Round5Load.ReadInt32();

                e1Round5Load.Close();

                // Enemy 10
                BinaryReader e2Round5Load = new BinaryReader(File.OpenRead("Enemy Maker (Nightmare)10.dat"));

                e2Round5Health = e2Round5Load.ReadInt32();
                e2Round5Attack = e2Round5Load.ReadInt32();
                e2Round5Defense = e2Round5Load.ReadInt32();
                e2Round5Speed = e2Round5Load.ReadInt32();

                e2Round5Load.Close();

                // Enemy 11
                BinaryReader e1Round6Load = new BinaryReader(File.OpenRead("Enemy Maker (Nightmare)11.dat"));

                e1Round6Health = e1Round6Load.ReadInt32();
                e1Round6Attack = e1Round6Load.ReadInt32();
                e1Round6Defense = e1Round6Load.ReadInt32();
                e1Round6Speed = e1Round6Load.ReadInt32();

                e1Round6Load.Close();

                // Enemy 12
                BinaryReader e2Round6Load = new BinaryReader(File.OpenRead("Enemy Maker (Nightmare)12.dat"));

                e2Round6Health = e2Round6Load.ReadInt32();
                e2Round6Attack = e2Round6Load.ReadInt32();
                e2Round6Defense = e2Round6Load.ReadInt32();
                e2Round6Speed = e2Round6Load.ReadInt32();

                e2Round1Load.Close();

                // Enemy 13
                BinaryReader e3Round6Load = new BinaryReader(File.OpenRead("Enemy Maker (Nightmare)13.dat"));
                e3Round6Health = e3Round6Load.ReadInt32();
                e3Round6Attack = e3Round6Load.ReadInt32();
                e3Round6Defense = e3Round6Load.ReadInt32();
                e3Round6Speed = e3Round6Load.ReadInt32();

                e3Round6Load.Close();

                // Enemy 14
                BinaryReader e1Round7Load = new BinaryReader(File.OpenRead("Enemy Maker (Nightmare)14.dat"));

                e1Round7Health = e1Round7Load.ReadInt32();
                e1Round7Attack = e1Round7Load.ReadInt32();
                e1Round7Defense = e1Round7Load.ReadInt32();
                e1Round7Speed = e1Round7Load.ReadInt32();

                e1Round7Load.Close();

                // Enemy 15
                BinaryReader e2Round7Load = new BinaryReader(File.OpenRead("Enemy Maker (Nightmare)15.dat"));

                e2Round7Health = e2Round7Load.ReadInt32();
                e2Round7Attack = e2Round7Load.ReadInt32();
                e2Round7Defense = e2Round7Load.ReadInt32();
                e2Round7Speed = e2Round7Load.ReadInt32();

                e2Round7Load.Close();

                // Enemy 16
                BinaryReader e1Round8Load = new BinaryReader(File.OpenRead("Enemy Maker (Nightmare)16.dat"));

                e1Round8Health = e1Round8Load.ReadInt32();
                e1Round8Attack = e1Round8Load.ReadInt32();
                e1Round8Defense = e1Round8Load.ReadInt32();
                e1Round8Speed = e1Round8Load.ReadInt32();

                e1Round8Load.Close();

                // Enemy 17
                BinaryReader e2Round8Load = new BinaryReader(File.OpenRead("Enemy Maker (Nightmare)17.dat"));

                e2Round8Health = e2Round8Load.ReadInt32();
                e2Round8Attack = e2Round8Load.ReadInt32();
                e2Round8Defense = e2Round8Load.ReadInt32();
                e2Round8Speed = e2Round8Load.ReadInt32();

                e2Round8Load.Close();

                // Enemy 18
                BinaryReader e3Round8Load = new BinaryReader(File.OpenRead("Enemy Maker (Nightmare)18.dat"));

                e3Round8Health = e3Round8Load.ReadInt32();
                e3Round8Attack = e3Round8Load.ReadInt32();
                e3Round8Defense = e3Round8Load.ReadInt32();
                e3Round8Speed = e3Round8Load.ReadInt32();

                e3Round8Load.Close();

                // Enemy 19
                BinaryReader e1Round9Load = new BinaryReader(File.OpenRead("Enemy Maker (Nightmare)19.dat"));

                e1Round9Health = e1Round9Load.ReadInt32();
                e1Round9Attack = e1Round9Load.ReadInt32();
                e1Round9Defense = e1Round9Load.ReadInt32();
                e1Round9Speed = e1Round9Load.ReadInt32();

                e1Round9Load.Close();

                // Enemy 20
                BinaryReader e2Round9Load = new BinaryReader(File.OpenRead("Enemy Maker (Nightmare)20.dat"));

                e2Round9Health = e2Round9Load.ReadInt32();
                e2Round9Attack = e2Round9Load.ReadInt32();
                e2Round9Defense = e2Round9Load.ReadInt32();
                e2Round9Speed = e2Round9Load.ReadInt32();

                e2Round9Load.Close();

                // Enemy 21
                BinaryReader e3Round9Load = new BinaryReader(File.OpenRead("Enemy Maker (Nightmare)21.dat"));

                e3Round9Health = e3Round9Load.ReadInt32();
                e3Round9Attack = e3Round9Load.ReadInt32();
                e3Round9Defense = e3Round9Load.ReadInt32();
                e3Round9Speed = e3Round9Load.ReadInt32();

                e3Round9Load.Close();

                // Enemy 22
                BinaryReader e1Round10Load = new BinaryReader(File.OpenRead("Enemy Maker (Nightmare)22.dat"));

                e1Round10Health = e1Round10Load.ReadInt32();
                e1Round10Attack = e1Round10Load.ReadInt32();
                e1Round10Defense = e1Round10Load.ReadInt32();
                e1Round10Speed = e1Round10Load.ReadInt32();

                e1Round10Load.Close();

                // Enemy 23
                BinaryReader e2Round10Load = new BinaryReader(File.OpenRead("Enemy Maker (Nightmare)23.dat"));

                e2Round10Health = e2Round10Load.ReadInt32();
                e2Round10Attack = e2Round10Load.ReadInt32();
                e2Round10Defense = e2Round10Load.ReadInt32();
                e2Round10Speed = e2Round10Load.ReadInt32();

                e2Round10Load.Close();
            }
        }
    }
}