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
    enum GameStates { Intro, TitleScreen, Options, Credits, Game, LoadScreen }
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
        Cheerleader cheer = new Cheerleader(1000, 10, 10, 10, true);
        Geek nerd = new Geek(1000, 20, 20, 20, true);
        Jock football = new Jock(1000, 20, 15, 15, true);

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
        int msPerFrame;

        // Idle Sprites
        NerdIdleSprite IdleNerd;
        CheerIdleSprite IdleCheer;
        JockIdleSprite IdleJock;
        EnemyIdleSprite IdleEnemy;
        BossIdleSprite IdleBoss;

        // Textures and Vectors for Credits and Instructions screen
        Texture2D creditImg;
        Vector2 creditV;


        // Music for Game
        private Song GameTitleMusic;
        private Song GameCombatMusic;
        private Song GameLoadScreenMusic;


        int TitleMusicCounter = 960;
        int LoadScreenMusicCounter = 1440;
        int CombatMusicCouter = 1965;
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

            // Credit img
            creditV = new Vector2(485, 80);

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
            IdleJock = new JockIdleSprite(newJock, new Point(305, 860), 2, 1, 2, 550);

            // Cheer Idle
            Texture2D newCheer = Content.Load<Texture2D>("game stuff brit idle");
            IdleCheer = new CheerIdleSprite(newCheer, new Point(448, 865), 2, 1, 2, 550);

            // Enemy Idle
            Texture2D newEnemy = Content.Load<Texture2D>("game stuff alien idle");
            IdleEnemy = new EnemyIdleSprite(newEnemy, new Point(800, 1013), 2, 1, 2, 150);

            // Boss Idle
            Texture2D newBoss = Content.Load<Texture2D>("game stuff boss idle");
            IdleBoss = new BossIdleSprite(newBoss, new Point(1000, 1218), 2, 1, 2, 150);

            // Load in Music
            GameTitleMusic = Content.Load<Song>("Game TitleScreen Music.wav");
            GameCombatMusic = Content.Load<Song>("Game Combat music.wav");
            GameLoadScreenMusic = Content.Load<Song>("Game LoadScreen Music1.wav");

            // Credit Img
            creditImg = Content.Load<Texture2D>("TAYSCredits");

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

            //GameTitleMusic.Play();
            ReturnButtonInput();
        }

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
            /*TitleMusicCounter = 0;
           
            if (CombatMusicCouter == 1965)
            {
                MediaPlayer.Play(GameCombatMusic);
            }
            CombatMusicCouter -= 1;
            if (CombatMusicCouter <= 0)
            {
                MediaPlayer.Play(GameTitleMusic);
                CombatMusicCouter = 1965;
            }*/

            IdleNerd.Update(gameTime);
            IdleJock.Update(gameTime);
            IdleCheer.Update(gameTime);

            // Switch statement for round1 turns
            if (round == 1)
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
            }
            if (round == 2)
            {

                LoadScreenMusicCounter = 0;

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
            }

            if (round == 3)
            {

                LoadScreenMusicCounter = 0;

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
                    //nerd.GHealth += 30;
                    //football.JHealth += 30;


                    /*if (cheer.CHealth > 100)
                    {
                        cheer.CHealth = 100;
                    }/*
                    /*if (football.JHealth > 120)
                    {
                        football.JHealth = 120;
                    }*/
                    /*if (nerd.GHealth > 200)
                    {
                        nerd.GHealth = 200;
                    }*/

                    gState = GameStates.LoadScreen;
                }
            }

            if (round == 4)
            {

                LoadScreenMusicCounter = 0;

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
            }
            if (round == 5)
            {

                LoadScreenMusicCounter = 0;

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
            }

            if (round == 6)
            {

                LoadScreenMusicCounter = 0;

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
            }

            if (round == 7)
            {

                LoadScreenMusicCounter = 0;

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
                            CheerCombat();
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
                    /*if (cheer.IsAlive == false)
                    {
                        cheer.IsAlive = true;
                    }*/
                    /*if (football.IsAlive == false)
                    {
                        football.IsAlive = true;
                    }*/
                    if (nerd.IsAlive == false)
                    {
                        nerd.IsAlive = true;
                    }

                    cheer.CHealth += 30;
                    //nerd.GHealth += 30;
                    //football.JHealth += 30;

                    /*if(cheer.CHealth > 100)
                    {
                        cheer.CHealth = 100;
                    }*/
                    /*if(football.JHealth > 120)
                    {
                        football.JHealth = 120;
                    }*/
                    /*if(nerd.GHealth > 200)
                    {
                        nerd.GHealth = 200;
                    }*/

                    gState = GameStates.LoadScreen;
                }
            }

            if (round == 8)
            {

                LoadScreenMusicCounter = 0;

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
            }

            if (round == 9)
            {

                LoadScreenMusicCounter = 0;

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
            }
            if (round == 10)
            {

                LoadScreenMusicCounter = 0;

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
                    gState = GameStates.LoadScreen;
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
                gState = GameStates.Game;
                round++;
                Earth.Loop = 0;
                LoadScreenMusicCounter = 0;
                MediaPlayer.Stop();
                MediaPlayer.Play(GameCombatMusic);
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

            // Game intrutions for the player to see
            spriteBatch.DrawString(font, "Hello player, the game you are playing is a turn based action RPG set in the real world(but with a couple of changes)", new Vector2(GraphicsDevice.Viewport.Width / 4, 20), Color.Black);
            spriteBatch.DrawString(font, "The game is a point and click style type of game so thwe only thing that you are goping to need is a mouse and you wits!!!", new Vector2(GraphicsDevice.Viewport.Width / 4, 40), Color.Black);
            spriteBatch.DrawString(font, "As the player you will control three different types of characters that are all different and have unique stats.", new Vector2(GraphicsDevice.Viewport.Width / 4, 60), Color.Black);
            spriteBatch.DrawString(font, "Your mission is to defeat all the enemies that you find and defeat the boss to win the game and save the world", new Vector2(GraphicsDevice.Viewport.Width / 4, 80), Color.Black);
            spriteBatch.End();
        }

        protected void DrawCredits(GameTime gameTime)
        {
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Draw(returnButton, returnBPosition, Color.White);

            // Writing the credits to the screen
            spriteBatch.Draw(creditImg, creditV, Color.White);

            /* spriteBatch.DrawString(font, "This is a game was made over the course of our spring semester at Rochester Institute of Technology", new Vector2(GraphicsDevice.Viewport.Width / 3, 20), Color.Black);
            spriteBatch.DrawString(font, "The roles for the project include:", new Vector2(GraphicsDevice.Viewport.Width / 3, 40), Color.Black);
            spriteBatch.DrawString(font, "Project Lead: Herman McElveen", new Vector2(GraphicsDevice.Viewport.Width / 3, 60), Color.Black);
            spriteBatch.DrawString(font, "Project Architect: Ryan Lowrie", new Vector2(GraphicsDevice.Viewport.Width / 3, 80), Color.Black);
            spriteBatch.DrawString(font, "Project Design: Tung Nguyen", new Vector2(GraphicsDevice.Viewport.Width / 3, 100), Color.Black);
            spriteBatch.DrawString(font, "Project Interface: Yoon Kim", new Vector2(GraphicsDevice.Viewport.Width / 3, 120), Color.Black); */
            spriteBatch.End();
        }

        protected void DrawGame(GameTime gameTime)
        {
            spriteBatch.Begin();
            // Draw for round 1
            if (round == 1)
            {
                spriteBatch.Draw(gStateBackground, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                if (nerd.IsAlive == true)
                {
                    //spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
                    IdleNerd.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Nerd Health: " + nerd.GHealth, new Vector2(510, 750), Color.Black);
                }
                if (e1Round1.IsAlive == true)
                {
                    spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X, (int)positionAlien.Y, 600, 425), Color.White);
                    spriteBatch.DrawString(font, "Enemy Health: " + e1Round1.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 340, 750), Color.Black);
                }
                if (e2Round1.IsAlive == true)
                {
                    spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 400, (int)positionAlien.Y, 600, 425), Color.White);
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
                    spriteBatch.DrawString(font, "" + nerd.GAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "30%", new Vector2(1270, 948), Color.Black);
                    if (nerd.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + nerd.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round1State == Round1States.EnemyTurn)
                {
                    spriteBatch.DrawString(font, "Enemy Attacks " + e1Round1.EAttack + " Damage was dealt", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
                else if (round1State == Round1States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "20%", new Vector2(1270, 948), Color.Black);
                    if (football.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + football.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round1State == Round1States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "10%", new Vector2(1270, 948), Color.Black);
                    if (cheer.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + cheer.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round1State == Round1States.Enemy2Turn)
                {
                    spriteBatch.DrawString(font, "Enemy2 Attacks " + e2Round1.EAttack + " Damage was dealt", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
            }

            // Draw for round 2
            if (round == 2)
            {
                spriteBatch.Draw(gStateBackground, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);


                if (nerd.IsAlive == true)
                {
                    //spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
                    IdleNerd.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Nerd Health: " + nerd.GHealth, new Vector2(510, 750), Color.Black);
                }
                if (e1Round2.IsAlive == true)
                {
                    spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X, (int)positionAlien.Y, 600, 425), Color.White);
                    spriteBatch.DrawString(font, "Enemy Health: " + e1Round2.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 340, 750), Color.Black);
                }
                if (e2Round2.IsAlive == true)
                {
                    spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 400, (int)positionAlien.Y, 600, 425), Color.White);
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
                    spriteBatch.DrawString(font, "" + nerd.GAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "30%", new Vector2(1270, 948), Color.Black);
                    if (nerd.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + nerd.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round2State == Round2States.EnemyTurn)
                {
                    spriteBatch.DrawString(font, "Enemy Attacks " + e1Round2.EAttack + " Damage was dealt", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
                else if (round2State == Round2States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "20%", new Vector2(1270, 948), Color.Black);
                    if (football.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + football.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round2State == Round2States.CheertTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "10%", new Vector2(1270, 948), Color.Black);
                    if (cheer.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + cheer.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round2State == Round2States.Enemy2Turn)
                {
                    spriteBatch.DrawString(font, "Enemy2 Attacks " + e2Round2.EAttack + " Damage was dealt", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
            }

            // Draw for round 3
            if (round == 3)
            {
                spriteBatch.Draw(gStateBackground, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);


                if (nerd.IsAlive == true)
                {
                    //spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
                    IdleNerd.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Nerd Health: " + nerd.GHealth, new Vector2(510, 750), Color.Black);
                }
                if (e1Round3.IsAlive == true)
                {
                    spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 245, (int)positionAlien.Y + 200, 400, 225), Color.White);
                    spriteBatch.DrawString(font, "Enemy Health: " + e1Round3.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 660, 750), Color.Black);
                }
                if (e2Round3.IsAlive == true)
                {
                    spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 520, (int)positionAlien.Y + 200, 400, 225), Color.White);
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
                    spriteBatch.Draw(boss, new Rectangle((int)positionAlien.X - 80, (int)positionAlien.Y - 175, 700, 600), Color.White);
                    spriteBatch.DrawString(font, "Boss Health: " + bossRound3.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 390, 750), Color.Black);
                }

                if (round3State == Round3States.NerdTurn)
                {
                    spriteBatch.Draw(geekMenu, geekMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + nerd.GAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "30%", new Vector2(1270, 948), Color.Black);
                    if (nerd.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + nerd.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round3State == Round3States.EnemyTurn)
                {
                    spriteBatch.DrawString(font, "Enemy Attacks " + e1Round3.EAttack + " Damage was dealt", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
                else if (round3State == Round3States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "20%", new Vector2(1270, 948), Color.Black);
                    if (football.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + football.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round3State == Round3States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "10%", new Vector2(1270, 948), Color.Black);
                    if (cheer.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + cheer.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round3State == Round3States.Enemy2Turn)
                {
                    spriteBatch.DrawString(font, "Enemy2 Attacks " + e2Round3.EAttack + " Damage was dealt", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
                else if (round3State == Round3States.BossTurn)
                {
                    spriteBatch.DrawString(font, "Boss Attacks " + bossRound3.EAttack + " Damage was dealt", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
            }

            if (round == 4)
            {
                spriteBatch.Draw(StreetBackgroundRound4, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);


                if (nerd.IsAlive == true)
                {
                    //spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
                    IdleNerd.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Nerd Health: " + nerd.GHealth, new Vector2(510, 750), Color.Black);
                }
                if (e1Round4.IsAlive == true)
                {
                    spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X, (int)positionAlien.Y, 600, 425), Color.White);
                    spriteBatch.DrawString(font, "Enemy Health: " + e1Round4.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 340, 750), Color.Black);
                }
                if (e2Round4.IsAlive == true)
                {
                    spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 400, (int)positionAlien.Y, 600, 425), Color.White);
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
                    spriteBatch.DrawString(font, "" + nerd.GAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "30%", new Vector2(1270, 948), Color.Black);
                    if (nerd.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + nerd.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round4State == Round4States.EnemyTurn)
                {
                    spriteBatch.DrawString(font, "Enemy Attacks " + e1Round4.EAttack + " Damage was dealt", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
                else if (round4State == Round4States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "20%", new Vector2(1270, 948), Color.Black);
                    if (football.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + football.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round4State == Round4States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "10%", new Vector2(1270, 948), Color.Black);
                    if (cheer.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + cheer.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round4State == Round4States.Enemy2Turn)
                {
                    spriteBatch.DrawString(font, "Enemy2 Attacks " + e2Round4.EAttack + " Damage was dealt", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
            }

            if (round == 5)
            {
                spriteBatch.Draw(StreetBackgroundRound5, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);


                if (nerd.IsAlive == true)
                {
                    //spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
                    IdleNerd.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Nerd Health: " + nerd.GHealth, new Vector2(510, 750), Color.Black);
                }
                if (e1Round5.IsAlive == true)
                {
                    spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X, (int)positionAlien.Y, 600, 425), Color.White);
                    spriteBatch.DrawString(font, "Enemy Health: " + e1Round5.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 340, 750), Color.Black);
                }
                if (e2Round5.IsAlive == true)
                {
                    spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 400, (int)positionAlien.Y, 600, 425), Color.White);
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
                    spriteBatch.DrawString(font, "" + nerd.GAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "30%", new Vector2(1270, 948), Color.Black);
                    if (nerd.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + nerd.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round5State == Round5States.EnemyTurn)
                {
                    spriteBatch.DrawString(font, "Enemy Attacks " + e1Round5.EAttack + " Damage was dealt", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
                else if (round5State == Round5States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "20%", new Vector2(1270, 948), Color.Black);
                    if (football.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + football.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round5State == Round5States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "10%", new Vector2(1270, 948), Color.Black);
                    if (cheer.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + cheer.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round5State == Round5States.Enemy2Turn)
                {
                    spriteBatch.DrawString(font, "Enemy2 Attacks " + e2Round5.EAttack + " Damage was dealt", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
            }

            if (round == 6)
            {
                spriteBatch.Draw(StreetBackgroundRound6, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);


                if (nerd.IsAlive == true)
                {
                    //spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
                    IdleNerd.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Nerd Health: " + nerd.GHealth, new Vector2(510, 750), Color.Black);
                }
                if (e1Round6.IsAlive == true)
                {
                    spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 115, (int)positionAlien.Y - 120, 450, 550), Color.White);
                    spriteBatch.DrawString(font, "Enemy Health 1: " + e1Round6.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 500, 750), Color.Black);
                }
                if (e2Round6.IsAlive == true)
                {
                    spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 420, (int)positionAlien.Y - 120, 450, 550), Color.White);
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
                    spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X + 180, (int)positionAlien.Y - 120, 450, 550), Color.White);
                    spriteBatch.DrawString(font, "Enemy Health 3: " + e3Round6.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 220, 750), Color.Black);
                }

                if (round6State == Round6States.NerdTurn)
                {
                    spriteBatch.Draw(geekMenu, geekMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + nerd.GAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "30%", new Vector2(1270, 948), Color.Black);
                    if (nerd.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + nerd.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round6State == Round6States.EnemyTurn)
                {
                    spriteBatch.DrawString(font, "Enemy Attacks " + e1Round6.EAttack + " Damage was dealt", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
                else if (round6State == Round6States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "20%", new Vector2(1270, 948), Color.Black);
                    if (football.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + football.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round6State == Round6States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "10%", new Vector2(1270, 948), Color.Black);
                    if (cheer.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + cheer.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round6State == Round6States.Enemy2Turn)
                {
                    spriteBatch.DrawString(font, "Enemy2 Attacks " + e2Round6.EAttack + " Damage was dealt", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
            }

            if (round == 7)
            {
                spriteBatch.Draw(StreetBackgroundRound7, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);


                if (nerd.IsAlive == true)
                {
                    //spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
                    IdleNerd.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Nerd Health: " + nerd.GHealth, new Vector2(510, 750), Color.Black);
                }
                if (e1Round7.IsAlive == true)
                {
                    spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 245, (int)positionAlien.Y + 200, 400, 225), Color.White);
                    spriteBatch.DrawString(font, "Enemy Health: " + e1Round7.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 660, 750), Color.Black);
                }
                if (e2Round7.IsAlive == true)
                {
                    spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 520, (int)positionAlien.Y + 200, 400, 225), Color.White);
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
                    spriteBatch.Draw(boss, new Rectangle((int)positionAlien.X - 80, (int)positionAlien.Y - 175, 700, 600), Color.White);
                    spriteBatch.DrawString(font, "Boss Health: " + bossRound7.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 390, 750), Color.Black);
                }

                if (round7State == Round7States.NerdTurn)
                {
                    spriteBatch.Draw(geekMenu, geekMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + nerd.GAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "30%", new Vector2(1270, 948), Color.Black);
                    if (nerd.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + nerd.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round7State == Round7States.EnemyTurn)
                {
                    spriteBatch.DrawString(font, "Enemy Attacks " + e1Round7.EAttack + " Damage was dealt", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
                else if (round7State == Round7States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "20%", new Vector2(1270, 948), Color.Black);
                    if (football.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + football.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round7State == Round7States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "10%", new Vector2(1270, 948), Color.Black);
                    if (cheer.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + cheer.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round7State == Round7States.Enemy2Turn)
                {
                    spriteBatch.DrawString(font, "Enemy2 Attacks " + e2Round7.EAttack + " Damage was dealt", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
                else if (round7State == Round7States.BossTurn)
                {
                    spriteBatch.DrawString(font, "Boss Attacks " + bossRound7.EAttack + " Damage was dealt", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
            }

            if (round == 8)
            {
                spriteBatch.Draw(StreetBackgroundRound7, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                if (nerd.IsAlive == true)
                {
                    //spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
                    IdleNerd.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Nerd Health: " + nerd.GHealth, new Vector2(510, 750), Color.Black);
                }
                if (e1Round8.IsAlive == true)
                {
                    spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 115, (int)positionAlien.Y - 120, 450, 550), Color.White);
                    spriteBatch.DrawString(font, "Enemy Health 1: " + e1Round8.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 500, 750), Color.Black);
                }
                if (e2Round8.IsAlive == true)
                {
                    spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 420, (int)positionAlien.Y - 120, 450, 550), Color.White);
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
                    spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X + 180, (int)positionAlien.Y - 120, 450, 550), Color.White);
                    spriteBatch.DrawString(font, "Enemy Health 3: " + e3Round8.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 220, 750), Color.Black);
                }

                if (round8State == Round8States.NerdTurn)
                {
                    spriteBatch.Draw(geekMenu, geekMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + nerd.GAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "30%", new Vector2(1270, 948), Color.Black);
                    if (nerd.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + nerd.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round8State == Round8States.EnemyTurn)
                {
                    spriteBatch.DrawString(font, "Enemy Attacks " + e1Round8.EAttack + " Damage was dealt", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
                else if (round8State == Round8States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "20%", new Vector2(1270, 948), Color.Black);
                    if (football.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + football.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round8State == Round8States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "10%", new Vector2(1270, 948), Color.Black);
                    if (cheer.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + cheer.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round8State == Round8States.Enemy2Turn)
                {
                    spriteBatch.DrawString(font, "Enemy2 Attacks " + e2Round8.EAttack + " Damage was dealt", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
                else if (round8State == Round8States.Enemy3Turn)
                {
                    spriteBatch.DrawString(font, "Enemy3 Attacks " + e3Round8.EAttack + " Damage was dealt", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
            }

            if (round == 9)
            {
                spriteBatch.Draw(WhiteHouse, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                if (nerd.IsAlive == true)
                {
                    //spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
                    IdleNerd.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Nerd Health: " + nerd.GHealth, new Vector2(510, 750), Color.Black);
                }
                if (e1Round9.IsAlive == true)
                {
                    spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 115, (int)positionAlien.Y - 120, 450, 550), Color.White);
                    spriteBatch.DrawString(font, "Enemy Health 1: " + e1Round9.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 500, 750), Color.Black);
                }
                if (e2Round9.IsAlive == true)
                {
                    spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 420, (int)positionAlien.Y - 120, 450, 550), Color.White);
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
                    spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X + 180, (int)positionAlien.Y - 120, 450, 550), Color.White);
                    spriteBatch.DrawString(font, "Enemy Health 3: " + e3Round9.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 220, 750), Color.Black);
                }

                if (round9State == Round9States.NerdTurn)
                {
                    spriteBatch.Draw(geekMenu, geekMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + nerd.GAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "30%", new Vector2(1270, 948), Color.Black);
                    if (nerd.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + nerd.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round9State == Round9States.EnemyTurn)
                {
                    spriteBatch.DrawString(font, "Enemy Attacks " + e1Round8.EAttack + " Damage was dealt", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
                else if (round9State == Round9States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "20%", new Vector2(1270, 948), Color.Black);
                    if (football.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + football.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round9State == Round9States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "10%", new Vector2(1270, 948), Color.Black);
                    if (cheer.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + cheer.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round9State == Round9States.Enemy2Turn)
                {
                    spriteBatch.DrawString(font, "Enemy2 Attacks " + e2Round9.EAttack + " Damage was dealt", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
                else if (round9State == Round9States.Enemy3Turn)
                {
                    spriteBatch.DrawString(font, "Enemy3 Attacks " + e3Round9.EAttack + " Damage was dealt", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
            }

            if (round == 10)
            {
                spriteBatch.Draw(OvalOffice, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                if (nerd.IsAlive == true)
                {
                    //spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
                    IdleNerd.Draw(gameTime, spriteBatch);
                    spriteBatch.DrawString(font, "Nerd Health: " + nerd.GHealth, new Vector2(510, 750), Color.Black);
                }
                if (e1Round10.IsAlive == true)
                {
                    spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 245, (int)positionAlien.Y + 200, 400, 225), Color.White);
                    spriteBatch.DrawString(font, "Enemy Health: " + e1Round10.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 660, 750), Color.Black);
                }
                if (e2Round10.IsAlive == true)
                {
                    spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 520, (int)positionAlien.Y + 200, 400, 225), Color.White);
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
                    spriteBatch.Draw(boss, new Rectangle((int)positionAlien.X - 80, (int)positionAlien.Y - 175, 700, 600), Color.White);
                    spriteBatch.DrawString(font, "Boss Health: " + bossFinal.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 390, 750), Color.Black);
                }

                if (round10State == Round10States.NerdTurn)
                {
                    spriteBatch.Draw(geekMenu, geekMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + nerd.GAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "30%", new Vector2(1270, 948), Color.Black);
                    if (nerd.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + nerd.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round10State == Round10States.EnemyTurn)
                {
                    spriteBatch.DrawString(font, "Enemy Attacks " + e1Round10.EAttack + " Damage was dealt", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
                else if (round10State == Round10States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "20%", new Vector2(1270, 948), Color.Black);
                    if (football.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + football.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round10State == Round10States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "10%", new Vector2(1270, 948), Color.Black);
                    if (cheer.SpecialMeter < 100)
                    {
                        spriteBatch.DrawString(font, "Special Meter: " + cheer.SpecialMeter, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Special ready for use", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                    }
                }
                else if (round10State == Round10States.Enemy2Turn)
                {
                    spriteBatch.DrawString(font, "Enemy2 Attacks " + e2Round10.EAttack + " Damage was dealt", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
                else if (round10State == Round10States.BossTurn)
                {
                    spriteBatch.DrawString(font, "Boss Attacks " + e2Round10.EAttack + " Damage was dealt", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
            }
            spriteBatch.DrawString(font, "Current X position for mouse: " + mState.X + " Y: " + mState.Y, new Vector2(20, 50), Color.Black);
            spriteBatch.End();
        }

        protected void DrawLoadScreen(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            Earth.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        protected void TitleScreenInput()
        {

            // If statement for start button click
            if (mState.X >= 792 && mState.X <= 1055 && mState.Y >= 285 && mState.Y < 370 && mState.LeftButton == ButtonState.Pressed)
            {
                MediaPlayer.Stop();
                gState = GameStates.Game;
            }
            // If statement for credits button click
            if (mState.X >= 792 && mState.X <= 1055 && mState.Y >= 425 && mState.Y < 520 && mState.LeftButton == ButtonState.Pressed)
            {
                MediaPlayer.Stop();
                gState = GameStates.Credits;
            }
            // if statement for options button click
            if (mState.X >= 792 && mState.X <= 1055 && mState.Y >= 595 && mState.Y < 680 && mState.LeftButton == ButtonState.Pressed)
            {
                MediaPlayer.Stop();
                gState = GameStates.Options;
            }
        }

        // Method that handles clicking the return button and changing the state to the title screen 
        protected void ReturnButtonInput()
        {
            if (mState.X >= 735 && mState.X <= 1165 && mState.Y >= 835 && mState.Y < 975 && mState.LeftButton == ButtonState.Pressed)
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
                    if (e1Round1.EHealth <= 0)
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
                    if (e1Round1.EHealth <= 0)
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

                    if (nerd.GHealth > 200)
                    {
                        nerd.GHealth = 200;
                    }
                    if (cheer.CHealth > 100)
                    {
                        cheer.CHealth = 100;
                    }
                    if (football.JHealth > 120)
                    {
                        football.JHealth = 120;
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
            // Enemy 1
            BinaryReader e1Round1Load = new BinaryReader(File.OpenRead("Enemy Maker1.dat"));

            e1Round1Health = e1Round1Load.ReadInt32();
            e1Round1Attack = e1Round1Load.ReadInt32();
            e1Round1Defense = e1Round1Load.ReadInt32();
            e1Round1Speed = e1Round1Load.ReadInt32();

            e1Round1Load.Close();

            // Enemy 2
            BinaryReader e2Round1Load = new BinaryReader(File.OpenRead("Enemy Maker2.dat"));

            e2Round1Health = e2Round1Load.ReadInt32();
            e2Round1Attack = e2Round1Load.ReadInt32();
            e2Round1Defense = e2Round1Load.ReadInt32();
            e2Round1Speed = e2Round1Load.ReadInt32();

            e2Round1Load.Close();

            // Enemy 3
            BinaryReader e1Round2Load = new BinaryReader(File.OpenRead("Enemy Maker3.dat"));

            e1Round2Health = e1Round2Load.ReadInt32();
            e1Round2Attack = e1Round2Load.ReadInt32();
            e1Round2Defense = e1Round2Load.ReadInt32();
            e1Round2Speed = e1Round2Load.ReadInt32();

            e1Round2Load.Close();

            // Enemy 4
            BinaryReader e2Round2Load = new BinaryReader(File.OpenRead("Enemy Maker4.dat"));

            e2Round2Health = e2Round2Load.ReadInt32();
            e2Round2Attack = e2Round2Load.ReadInt32();
            e2Round2Defense = e2Round2Load.ReadInt32();
            e2Round2Speed = e2Round2Load.ReadInt32();

            e2Round2Load.Close();

            // Enemy 5
            BinaryReader e1Round3Load = new BinaryReader(File.OpenRead("Enemy Maker5.dat"));

            e1Round3Health = e1Round3Load.ReadInt32();
            e1Round3Attack = e1Round3Load.ReadInt32();
            e1Round3Defense = e1Round3Load.ReadInt32();
            e1Round3Speed = e1Round3Load.ReadInt32();

            e1Round3Load.Close();

            // Enemy 6
            BinaryReader e2Round3Load = new BinaryReader(File.OpenRead("Enemy Maker6.dat"));

            e2Round3Health = e2Round3Load.ReadInt32();
            e2Round3Attack = e2Round3Load.ReadInt32();
            e2Round3Defense = e2Round3Load.ReadInt32();
            e2Round3Speed = e2Round3Load.ReadInt32();

            e2Round3Load.Close();

            // Enemy 7
            BinaryReader e1Round4Load = new BinaryReader(File.OpenRead("Enemy Maker7.dat"));

            e1Round4Health = e1Round4Load.ReadInt32();
            e1Round4Attack = e1Round4Load.ReadInt32();
            e1Round4Defense = e1Round4Load.ReadInt32();
            e1Round4Speed = e1Round4Load.ReadInt32();

            e1Round4Load.Close();

            // Enemy 8
            BinaryReader e2Round4Load = new BinaryReader(File.OpenRead("Enemy Maker8.dat"));

            e2Round4Health = e2Round4Load.ReadInt32();
            e2Round4Attack = e2Round4Load.ReadInt32();
            e2Round4Defense = e2Round4Load.ReadInt32();
            e2Round4Speed = e2Round4Load.ReadInt32();

            e2Round1Load.Close();

            // Enemy 9
            BinaryReader e1Round5Load = new BinaryReader(File.OpenRead("Enemy Maker9.dat"));

            e1Round5Health = e1Round5Load.ReadInt32();
            e1Round5Attack = e1Round5Load.ReadInt32();
            e1Round5Defense = e1Round5Load.ReadInt32();
            e1Round5Speed = e1Round5Load.ReadInt32();

            e1Round5Load.Close();

            // Enemy 10
            BinaryReader e2Round5Load = new BinaryReader(File.OpenRead("Enemy Maker10.dat"));

            e2Round5Health = e2Round5Load.ReadInt32();
            e2Round5Attack = e2Round5Load.ReadInt32();
            e2Round5Defense = e2Round5Load.ReadInt32();
            e2Round5Speed = e2Round5Load.ReadInt32();

            e2Round5Load.Close();

            // Enemy 11
            BinaryReader e1Round6Load = new BinaryReader(File.OpenRead("Enemy Maker11.dat"));

            e1Round6Health = e1Round6Load.ReadInt32();
            e1Round6Attack = e1Round6Load.ReadInt32();
            e1Round6Defense = e1Round6Load.ReadInt32();
            e1Round6Speed = e1Round6Load.ReadInt32();

            e1Round6Load.Close();

            // Enemy 12
            BinaryReader e2Round6Load = new BinaryReader(File.OpenRead("Enemy Maker12.dat"));

            e2Round6Health = e2Round6Load.ReadInt32();
            e2Round6Attack = e2Round6Load.ReadInt32();
            e2Round6Defense = e2Round6Load.ReadInt32();
            e2Round6Speed = e2Round6Load.ReadInt32();

            e2Round1Load.Close();

            // Enemy 13
            BinaryReader e3Round6Load = new BinaryReader(File.OpenRead("Enemy Maker13.dat"));
            e3Round6Health = e3Round6Load.ReadInt32();
            e3Round6Attack = e3Round6Load.ReadInt32();
            e3Round6Defense = e3Round6Load.ReadInt32();
            e3Round6Speed = e3Round6Load.ReadInt32();

            e3Round6Load.Close();

            // Enemy 14
            BinaryReader e1Round7Load = new BinaryReader(File.OpenRead("Enemy Maker14.dat"));

            e1Round7Health = e1Round7Load.ReadInt32();
            e1Round7Attack = e1Round7Load.ReadInt32();
            e1Round7Defense = e1Round7Load.ReadInt32();
            e1Round7Speed = e1Round7Load.ReadInt32();

            e1Round7Load.Close();

            // Enemy 15
            BinaryReader e2Round7Load = new BinaryReader(File.OpenRead("Enemy Maker15.dat"));

            e2Round7Health = e2Round7Load.ReadInt32();
            e2Round7Attack = e2Round7Load.ReadInt32();
            e2Round7Defense = e2Round7Load.ReadInt32();
            e2Round7Speed = e2Round7Load.ReadInt32();

            e2Round7Load.Close();

            // Enemy 16
            BinaryReader e1Round8Load = new BinaryReader(File.OpenRead("Enemy Maker16.dat"));

            e1Round8Health = e1Round8Load.ReadInt32();
            e1Round8Attack = e1Round8Load.ReadInt32();
            e1Round8Defense = e1Round8Load.ReadInt32();
            e1Round8Speed = e1Round8Load.ReadInt32();

            e1Round8Load.Close();

            // Enemy 17
            BinaryReader e2Round8Load = new BinaryReader(File.OpenRead("Enemy Maker17.dat"));

            e2Round8Health = e2Round8Load.ReadInt32();
            e2Round8Attack = e2Round8Load.ReadInt32();
            e2Round8Defense = e2Round8Load.ReadInt32();
            e2Round8Speed = e2Round8Load.ReadInt32();

            e2Round8Load.Close();

            // Enemy 18
            BinaryReader e3Round8Load = new BinaryReader(File.OpenRead("Enemy Maker18.dat"));

            e3Round8Health = e3Round8Load.ReadInt32();
            e3Round8Attack = e3Round8Load.ReadInt32();
            e3Round8Defense = e3Round8Load.ReadInt32();
            e3Round8Speed = e3Round8Load.ReadInt32();

            e3Round8Load.Close();

            // Enemy 19
            BinaryReader e1Round9Load = new BinaryReader(File.OpenRead("Enemy Maker19.dat"));

            e1Round9Health = e1Round9Load.ReadInt32();
            e1Round9Attack = e1Round9Load.ReadInt32();
            e1Round9Defense = e1Round9Load.ReadInt32();
            e1Round9Speed = e1Round9Load.ReadInt32();

            e1Round9Load.Close();

            // Enemy 20
            BinaryReader e2Round9Load = new BinaryReader(File.OpenRead("Enemy Maker20.dat"));

            e2Round9Health = e2Round9Load.ReadInt32();
            e2Round9Attack = e2Round9Load.ReadInt32();
            e2Round9Defense = e2Round9Load.ReadInt32();
            e2Round9Speed = e2Round9Load.ReadInt32();

            e2Round9Load.Close();

            // Enemy 21
            BinaryReader e3Round9Load = new BinaryReader(File.OpenRead("Enemy Maker21.dat"));

            e3Round9Health = e3Round9Load.ReadInt32();
            e3Round9Attack = e3Round9Load.ReadInt32();
            e3Round9Defense = e3Round9Load.ReadInt32();
            e3Round9Speed = e3Round9Load.ReadInt32();

            e3Round9Load.Close();

            // Enemy 22
            BinaryReader e1Round10Load = new BinaryReader(File.OpenRead("Enemy Maker22.dat"));

            e1Round10Health = e1Round10Load.ReadInt32();
            e1Round10Attack = e1Round10Load.ReadInt32();
            e1Round10Defense = e1Round10Load.ReadInt32();
            e1Round10Speed = e1Round10Load.ReadInt32();

            e1Round10Load.Close();

            // Enemy 23
            BinaryReader e2Round10Load = new BinaryReader(File.OpenRead("Enemy Maker23.dat"));

            e2Round10Health = e2Round10Load.ReadInt32();
            e2Round10Attack = e2Round10Load.ReadInt32();
            e2Round10Defense = e2Round10Load.ReadInt32();
            e2Round10Speed = e2Round10Load.ReadInt32();

            e2Round10Load.Close();
        }
    }
}