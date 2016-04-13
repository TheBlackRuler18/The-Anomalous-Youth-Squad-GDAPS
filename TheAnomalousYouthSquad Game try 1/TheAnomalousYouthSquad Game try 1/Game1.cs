using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Threading;

namespace TheAnomalousYouthSquad_Game_try_1
{
    // Staes for the game
    enum GameStates { Intro, TitleScreen, Options, Credits, Game }
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

    enum LoadingStates { LoadScreen }
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
        Cheerleader cheer = new Cheerleader(100, 10, 10, 10, true);
        Geek nerd = new Geek(200, 20, 20, 20, true);
        Jock football = new Jock(150, 20, 15, 15, true);

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
            }
        }

        // Update Methos for each state
        protected void UpdateIntro(GameTime gameTime)
        {

        }

        protected void UpdateTitleScreen(GameTime gameTime)
        {
            TitleScreenInput();
        }

        protected void UpdateOptions(GameTime gameTime)
        {
            ReturnButtonInput();
        }

        protected void UpdateCredits(GameTime gameTime)
        {
            ReturnButtonInput();
        }

        protected void UpdateGame(GameTime gameTime)
        {
            // Switch statement for round1 turns
            if (round == 1)
            {
                switch (round1State)
                {
                    case Round1States.NerdTurn:
                        if (nerd.GHealth != 0)
                        {
                            NerdCombat();
                        }
                        if (nerd.GHealth == 0)
                        {
                            round1State = Round1States.EnemyTurn;
                        }
                        break;

                    case Round1States.EnemyTurn:
                        if (e1Round1.EHealth != 0)
                        {
                            enemyCombat();
                        }
                        if (e1Round1.EHealth == 0)
                        {
                            round1State = Round1States.JockTurn;
                        }
                        break;
                    case Round1States.JockTurn:
                        if (football.JHealth != 0)
                        {
                            JockCombat();
                        }
                        if (football.JHealth == 0)
                        {
                            round1State = Round1States.CheerTurn;
                        }
                        break;
                    case Round1States.CheerTurn:
                        if (cheer.CHealth != 0)
                        {
                            CheerCombat();
                        }
                        if (cheer.CHealth == 0)
                        {
                            round1State = Round1States.Enemy2Turn;
                        }
                        break;
                    case Round1States.Enemy2Turn:
                        if (e2Round1.EHealth != 0)
                        {
                            enemyCombat2();
                        }
                        if (e2Round1.EHealth == 0)
                        {
                            round1State = Round1States.NerdTurn;
                        }
                        break;

                }
                if (e1Round1.EHealth == 0 && e2Round1.EHealth == 0)
                {
                    round++;
                }
            }
            if (round == 2)
            {
                // Switch for round2 turns
                switch (round2State)
                {
                    case Round2States.EnemyTurn:
                        if (e1Round2.EHealth != 0)
                        {
                            enemyCombat();
                        }
                        if (e1Round2.EHealth == 0)
                        {
                            round2State = Round2States.JockTurn;
                        }
                        break;

                    case Round2States.JockTurn:
                        if (football.JHealth != 0)
                        {
                            JockCombat();
                        }
                        if (football.JHealth == 0)
                        {
                            round2State = Round2States.NerdTurn;
                        }
                        break;
                    case Round2States.NerdTurn:
                        if (nerd.GHealth != 0)
                        {
                            NerdCombat();
                        }
                        if (nerd.GHealth == 0)
                        {
                            round2State = Round2States.Enemy2Turn;
                        }
                        break;
                    case Round2States.Enemy2Turn:
                        if (e2Round2.EHealth != 0)
                        {
                            enemyCombat2();
                        }
                        if (e2Round2.EHealth == 0)
                        {
                            round2State = Round2States.CheertTurn;
                        }
                        break;
                    case Round2States.CheertTurn:
                        if (cheer.CHealth != 0)
                        {
                            CheerCombat();
                        }
                        if (cheer.CHealth == 0)
                        {
                            round2State = Round2States.EnemyTurn;
                        }
                        break;
                }
                if (e1Round2.EHealth == 0 && e2Round2.EHealth == 0)
                {
                    round++;
                }
            }

            if (round == 3)
            {
                // Swtch statement for round 3
                switch (round3State)
                {
                    case Round3States.CheerTurn:
                        if (cheer.CHealth != 0)
                        {
                            CheerCombat();
                        }
                        if (cheer.CHealth == 0)
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
                        if (e1Round3.EHealth == 0)
                        {
                            round3State = Round3States.JockTurn;
                        }
                        break;
                    case Round3States.JockTurn:
                        if (football.JHealth != 0)
                        {
                            JockCombat();
                        }
                        if (football.JHealth == 0)
                        {
                            round3State = Round3States.Enemy2Turn;
                        }
                        break;
                    case Round3States.Enemy2Turn:
                        if (e2Round3.EHealth != 0)
                        {
                            enemyCombat2();
                        }
                        if (e2Round3.EHealth == 0)
                        {
                            round3State = Round3States.BossTurn;
                        }
                        break;
                    case Round3States.BossTurn:
                        if (bossRound3.EHealth != 0)
                        {
                            BossCombat();
                        }
                        if (bossRound3.EHealth == 0)
                        {
                            round3State = Round3States.CheerTurn;
                        }
                        break;
                }
                if (e1Round3.EHealth == 0 && e2Round3.EHealth == 0 && bossRound3.EHealth == 0)
                {
                    round++;
                }
            }

            if (round == 4)
            {
                // Swtch statement for round4
                switch (round4State)
                {
                    case Round4States.Enemy2Turn:
                        if (e2Round4.EHealth != 0)
                        {
                            enemyCombat2();
                        }
                        if (e2Round4.EHealth == 0)
                        {
                            round4State = Round4States.CheerTurn;
                        }
                        break;

                    case Round4States.CheerTurn:
                        if (cheer.CHealth != 0)
                        {
                            CheerCombat();
                        }
                        if (cheer.CHealth == 0)
                        {
                            round4State = Round4States.EnemyTurn;
                        }
                        break;
                    case Round4States.EnemyTurn:
                        if (e1Round4.EHealth != 0)
                        {
                            enemyCombat();
                        }
                        if (e1Round4.EHealth == 0)
                        {
                            round4State = Round4States.NerdTurn;
                        }
                        break;
                    case Round4States.NerdTurn:
                        if (nerd.GHealth != 0)
                        {
                            NerdCombat();
                        }
                        if (nerd.GHealth == 0)
                        {
                            round4State = Round4States.JockTurn;
                        }
                        break;
                    case Round4States.JockTurn:
                        if (football.JHealth != 0)
                        {
                            JockCombat();
                        }
                        if (football.JHealth == 0)
                        {
                            round4State = Round4States.Enemy2Turn;
                        }
                        break;
                }
                if (e1Round4.EHealth == 0 && e2Round4.EHealth == 0)
                {
                    round++;
                }
            }
            if (round == 5)
            {

                // Swtch stament for round 5
                switch (round5State)
                {
                    case Round5States.NerdTurn:
                        if (nerd.GHealth != 0)
                        {
                            NerdCombat();
                        }
                        if (nerd.GHealth == 0)
                        {
                            round5State = Round5States.Enemy2Turn;
                        }
                        break;

                    case Round5States.Enemy2Turn:
                        if (e2Round5.EHealth != 0)
                        {
                            enemyCombat2();
                        }
                        if (e2Round5.EHealth == 0)
                        {
                            round5State = Round5States.JockTurn;
                        }
                        break;
                    case Round5States.JockTurn:
                        if (football.JHealth != 0)
                        {
                            JockCombat();
                        }
                        if (football.JHealth == 0)
                        {
                            round5State = Round5States.EnemyTurn;
                        }
                        break;
                    case Round5States.EnemyTurn:
                        if (e1Round5.EHealth != 0)
                        {
                            enemyCombat();
                        }
                        if (e1Round5.EHealth == 0)
                        {
                            round5State = Round5States.CheerTurn;
                        }
                        break;
                    case Round5States.CheerTurn:
                        if (cheer.CHealth != 0)
                        {
                            CheerCombat();
                        }
                        if (cheer.CHealth == 0)
                        {
                            round5State = Round5States.NerdTurn;
                        }
                        break;
                }
                if (e1Round5.EHealth == 0 && e2Round5.EHealth == 0)
                {
                    round++;
                }
            }

            if (round == 6)
            {
                // Swtch statement for round6
                switch (round6State)
                {
                    case Round6States.Enemy3Turn:
                        if (e3Round6.EHealth != 0)
                        {
                            EnemyCombat3();
                        }
                        if (e3Round6.EHealth == 0)
                        {
                            round6State = Round6States.NerdTurn;
                        }
                        break;

                    case Round6States.NerdTurn:
                        if (nerd.GHealth != 0)
                        {
                            NerdCombat();
                        }
                        if (nerd.GHealth == 0)
                        {
                            round6State = Round6States.Enemy2Turn;
                        }
                        break;
                    case Round6States.Enemy2Turn:
                        if (e2Round6.EHealth != 0)
                        {
                            enemyCombat2();
                        }
                        if (e2Round6.EHealth == 0)
                        {
                            round6State = Round6States.JockTurn;
                        }
                        break;
                    case Round6States.JockTurn:
                        if (football.JHealth != 0)
                        {
                            JockCombat();
                        }
                        if (football.JHealth == 0)
                        {
                            round6State = Round6States.CheerTurn;
                        }
                        break;
                    case Round6States.CheerTurn:
                        if (cheer.CHealth != 0)
                        {
                            CheerCombat();
                        }
                        if (cheer.CHealth == 0)
                        {
                            round6State = Round6States.EnemyTurn;
                        }
                        break;
                    case Round6States.EnemyTurn:
                        if (e1Round6.EHealth != 0)
                        {
                            enemyCombat();
                        }
                        if (e1Round6.EHealth == 0)
                        {
                            round6State = Round6States.Enemy3Turn;
                        }
                        break;
                }
                if (e1Round6.EHealth == 0 && e2Round6.EHealth == 0 && e3Round6.EHealth == 0)
                {
                    round++;
                }
            }

            if (round == 7)
            {

                // Swtch statement for round7
                switch (round7State)
                {
                    case Round7States.BossTurn:
                        if (bossRound7.EHealth != 0)
                        {
                            BossCombat();
                        }
                        if (bossRound7.EHealth == 0)
                        {
                            round7State = Round7States.CheerTurn;
                        }
                        break;

                    case Round7States.CheerTurn:
                        if (cheer.CHealth != 0)
                        {
                            CheerCombat();
                        }
                        if (cheer.CHealth == 0)
                        {
                            round7State = Round7States.NerdTurn;
                        }
                        break;
                    case Round7States.NerdTurn:
                        if (nerd.GHealth != 0)
                        {
                            NerdCombat();
                        }
                        if (nerd.GHealth == 0)
                        {
                            round7State = Round7States.EnemyTurn;
                        }
                        break;
                    case Round7States.EnemyTurn:
                        if (e1Round7.EHealth != 0)
                        {
                            CheerCombat();
                        }
                        if (e1Round7.EHealth == 0)
                        {
                            round7State = Round7States.Enemy2Turn;
                        }
                        break;
                    case Round7States.Enemy2Turn:
                        if (e2Round7.EHealth != 0)
                        {
                            enemyCombat2();
                        }
                        if (e2Round7.EHealth == 0)
                        {
                            round7State = Round7States.JockTurn;
                        }
                        break;
                    case Round7States.JockTurn:
                        if (football.JHealth != 0)
                        {
                            JockCombat();
                        }
                        if (football.JHealth == 0)
                        {
                            round7State = Round7States.BossTurn;
                        }
                        break;
                }
                if (e1Round7.EHealth == 0 && e2Round7.EHealth == 0 && bossRound7.EHealth == 0)
                {
                    round++;
                }
            }

            if (round == 8)
            {
                // Swtch statement for round8
                switch (round8State)
                {
                    case Round8States.JockTurn:
                        if (football.JHealth != 0)
                        {
                            JockCombat();
                        }
                        if (football.JHealth == 0)
                        {
                            round8State = Round8States.Enemy2Turn;
                        }
                        break;

                    case Round8States.Enemy2Turn:
                        if (e2Round8.EHealth != 0)
                        {
                            enemyCombat2();
                        }
                        if (e2Round8.EHealth == 0)
                        {
                            round8State = Round8States.Enemy3Turn;
                        }
                        break;
                    case Round8States.Enemy3Turn:
                        if (e3Round8.EHealth != 0)
                        {
                            EnemyCombat3();
                        }
                        if (e3Round8.EHealth == 0)
                        {
                            round8State = Round8States.NerdTurn;
                        }
                        break;
                    case Round8States.NerdTurn:
                        if (nerd.GHealth != 0)
                        {
                            NerdCombat();
                        }
                        if (nerd.GHealth == 0)
                        {
                            round8State = Round8States.EnemyTurn;
                        }
                        break;
                    case Round8States.EnemyTurn:
                        if (e1Round8.EHealth != 0)
                        {
                            enemyCombat();
                        }
                        if (e1Round8.EHealth == 0)
                        {
                            round8State = Round8States.CheerTurn;
                        }
                        break;
                    case Round8States.CheerTurn:
                        if (cheer.CHealth != 0)
                        {
                            CheerCombat();
                        }
                        if (cheer.CHealth == 0)
                        {
                            round8State = Round8States.JockTurn;
                        }
                        break;
                }
                if (e1Round8.EHealth == 0 && e2Round8.EHealth == 0 && e3Round8.EHealth == 0)
                {
                    round++;
                }
            }

            if (round == 9)
            {
                // Swtch statement for round 9
                switch (round9State)
                {
                    case Round9States.NerdTurn:
                        if (nerd.GHealth != 0)
                        {
                            NerdCombat();
                        }
                        if (nerd.GHealth == 0)
                        {
                            round9State = Round9States.CheerTurn;
                        }
                        break;

                    case Round9States.CheerTurn:
                        if (cheer.CHealth != 0)
                        {
                            CheerCombat();
                        }
                        if (cheer.CHealth == 0)
                        {
                            round9State = Round9States.Enemy2Turn;
                        }
                        break;
                    case Round9States.Enemy2Turn:
                        if (e2Round9.EHealth != 0)
                        {
                            enemyCombat2();
                        }
                        if (e2Round9.EHealth == 0)
                        {
                            round9State = Round9States.Enemy3Turn;
                        }
                        break;
                    case Round9States.Enemy3Turn:
                        if (e3Round9.EHealth != 0)
                        {
                            EnemyCombat3();
                        }
                        if (e3Round9.EHealth == 0)
                        {
                            round9State = Round9States.JockTurn;
                        }
                        break;
                    case Round9States.JockTurn:
                        if (football.JHealth != 0)
                        {
                            JockCombat();
                        }
                        if (football.JHealth == 0)
                        {
                            round9State = Round9States.EnemyTurn;
                        }
                        break;
                    case Round9States.EnemyTurn:
                        if (e1Round9.EHealth != 0)
                        {
                            enemyCombat();
                        }
                        if (e1Round9.EHealth == 0)
                        {
                            round9State = Round9States.NerdTurn;
                        }
                        break;
                }
                if (e1Round9.EHealth == 0 && e2Round9.EHealth == 0 && e3Round9.EHealth == 0)
                {
                    round++;
                }
            }
            if (round == 10)
            {
                // Swtch statement for round10
                switch (round10State)
                {
                    case Round10States.BossTurn:
                        if (bossFinal.EHealth != 0)
                        {
                            BossCombat();
                        }
                        if (bossFinal.EHealth == 0)
                        {
                            round10State = Round10States.JockTurn;
                        }
                        break;

                    case Round10States.JockTurn:
                        if (football.JHealth != 0)
                        {
                            JockCombat();
                        }
                        if (football.JHealth == 0)
                        {
                            round10State = Round10States.Enemy2Turn;
                        }
                        break;
                    case Round10States.Enemy2Turn:
                        if (e2Round10.EHealth != 0)
                        {
                            enemyCombat2();
                        }
                        if (e2Round10.EHealth == 0)
                        {
                            round10State = Round10States.CheerTurn;
                        }
                        break;
                    case Round10States.CheerTurn:
                        if (cheer.CHealth != 0)
                        {
                            CheerCombat();
                        }
                        if (cheer.CHealth == 0)
                        {
                            round10State = Round10States.EnemyTurn;
                        }
                        break;
                    case Round10States.EnemyTurn:
                        if (e1Round10.EHealth != 0)
                        {
                            enemyCombat();
                        }
                        if (e1Round10.EHealth == 0)
                        {
                            round10State = Round10States.NerdTurn;
                        }
                        break;
                    case Round10States.NerdTurn:
                        if (nerd.GHealth != 0)
                        {
                            NerdCombat();
                        }
                        if (nerd.GHealth == 0)
                        {
                            round10State = Round10States.BossTurn;
                        }
                        break;
                }
                if (e1Round10.EHealth == 0 && e2Round10.EHealth == 0 && bossFinal.EHealth == 0)
                {
                    round++;
                }
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
            GraphicsDevice.Clear(Color.Pink);
            spriteBatch.Draw(returnButton, returnBPosition, Color.White);

            // Writing the credits to the screen
            spriteBatch.DrawString(font, "This is a game was made over the course of our spring semester at Rochester Institute of Technology", new Vector2(GraphicsDevice.Viewport.Width / 3, 20), Color.Black);
            spriteBatch.DrawString(font, "The roles for the project include:", new Vector2(GraphicsDevice.Viewport.Width / 3, 40), Color.Black);
            spriteBatch.DrawString(font, "Project Lead: Herman McElveen", new Vector2(GraphicsDevice.Viewport.Width / 3, 60), Color.Black);
            spriteBatch.DrawString(font, "Project Architect: Ryan Lowrie", new Vector2(GraphicsDevice.Viewport.Width / 3, 80), Color.Black);
            spriteBatch.DrawString(font, "Project Design: Tung Nguyen", new Vector2(GraphicsDevice.Viewport.Width / 3, 100), Color.Black);
            spriteBatch.DrawString(font, "Project Interface: Yoon Kim", new Vector2(GraphicsDevice.Viewport.Width / 3, 120), Color.Black);
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
                    spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
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
                    spriteBatch.Draw(jock, new Rectangle((int)positionJock.X, (int)positionJock.Y, 290, 400), Color.White);
                    spriteBatch.DrawString(font, "Jock Health: " + football.JHealth, new Vector2(270, 750), Color.Black);
                }
                if (cheer.IsAlive == true)
                {
                    spriteBatch.Draw(cheerLeader, new Rectangle((int)positionCheerLeader.X, (int)positionCheerLeader.Y, 270, 350), Color.White);
                    spriteBatch.DrawString(font, "CheerLeader Health: " + cheer.CHealth, new Vector2(0, 750), Color.Black);
                }

                if (round1State == Round1States.NerdTurn)
                {
                    spriteBatch.Draw(geekMenu, geekMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + nerd.GAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "30%", new Vector2(1270, 948), Color.Black);
                }
                else if (round1State == Round1States.EnemyTurn)
                {
                    spriteBatch.DrawString(font, "Enemy Turn", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
                else if (round1State == Round1States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "20%", new Vector2(1270, 948), Color.Black);
                }
                else if (round1State == Round1States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "10%", new Vector2(1270, 948), Color.Black);
                }
                else if (round1State == Round1States.Enemy2Turn)
                {
                    spriteBatch.DrawString(font, "Enemy Turn", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
            }

            // Draw for round 2
            if (round == 2)
            {
                spriteBatch.Draw(gStateBackground, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                if (nerd.IsAlive == true)
                {
                    spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
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
                    spriteBatch.Draw(jock, new Rectangle((int)positionJock.X, (int)positionJock.Y, 290, 400), Color.White);
                    spriteBatch.DrawString(font, "Jock Health: " + football.JHealth, new Vector2(270, 750), Color.Black);
                }
                if (cheer.IsAlive == true)
                {
                    spriteBatch.Draw(cheerLeader, new Rectangle((int)positionCheerLeader.X, (int)positionCheerLeader.Y, 270, 350), Color.White);
                    spriteBatch.DrawString(font, "CheerLeader Health: " + cheer.CHealth, new Vector2(0, 750), Color.Black);
                }

                if (round2State == Round2States.NerdTurn)
                {
                    spriteBatch.Draw(geekMenu, geekMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + nerd.GAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "30%", new Vector2(1270, 948), Color.Black);
                }
                else if (round2State == Round2States.EnemyTurn)
                {
                    spriteBatch.DrawString(font, "Enemy Turn", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
                else if (round2State == Round2States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "20%", new Vector2(1270, 948), Color.Black);
                }
                else if (round2State == Round2States.CheertTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "10%", new Vector2(1270, 948), Color.Black);
                }
                else if (round2State == Round2States.Enemy2Turn)
                {
                    spriteBatch.DrawString(font, "Enemy Turn", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
            }

            // Draw for round 3
            if (round == 3)
            {
                spriteBatch.Draw(gStateBackground, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                if (nerd.IsAlive == true)
                {
                    spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
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
                    spriteBatch.Draw(jock, new Rectangle((int)positionJock.X, (int)positionJock.Y, 290, 400), Color.White);
                    spriteBatch.DrawString(font, "Jock Health: " + football.JHealth, new Vector2(270, 750), Color.Black);
                }
                if (cheer.IsAlive == true)
                {
                    spriteBatch.Draw(cheerLeader, new Rectangle((int)positionCheerLeader.X, (int)positionCheerLeader.Y, 270, 350), Color.White);
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
                }
                else if (round3State == Round3States.EnemyTurn)
                {
                    spriteBatch.DrawString(font, "Enemy Turn", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
                else if (round3State == Round3States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "20%", new Vector2(1270, 948), Color.Black);
                }
                else if (round3State == Round3States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "10%", new Vector2(1270, 948), Color.Black);
                }
                else if (round3State == Round3States.Enemy2Turn)
                {
                    spriteBatch.DrawString(font, "Enemy Turn", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
            }

            if (round == 4)
            {
                spriteBatch.Draw(StreetBackgroundRound4, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                if (nerd.IsAlive == true)
                {
                    spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
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
                    spriteBatch.Draw(jock, new Rectangle((int)positionJock.X, (int)positionJock.Y, 290, 400), Color.White);
                    spriteBatch.DrawString(font, "Jock Health: " + football.JHealth, new Vector2(270, 750), Color.Black);
                }
                if (cheer.IsAlive == true)
                {
                    spriteBatch.Draw(cheerLeader, new Rectangle((int)positionCheerLeader.X, (int)positionCheerLeader.Y, 270, 350), Color.White);
                    spriteBatch.DrawString(font, "CheerLeader Health: " + cheer.CHealth, new Vector2(0, 750), Color.Black);
                }

                if (round4State == Round4States.NerdTurn)
                {
                    spriteBatch.Draw(geekMenu, geekMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + nerd.GAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "30%", new Vector2(1270, 948), Color.Black);
                }
                else if (round4State == Round4States.EnemyTurn)
                {
                    spriteBatch.DrawString(font, "Enemy Turn", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
                else if (round4State == Round4States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "20%", new Vector2(1270, 948), Color.Black);
                }
                else if (round4State == Round4States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "10%", new Vector2(1270, 948), Color.Black);
                }
                else if (round4State == Round4States.Enemy2Turn)
                {
                    spriteBatch.DrawString(font, "Enemy Turn", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
            }

            if (round == 5)
            {
                spriteBatch.Draw(StreetBackgroundRound5, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                if (nerd.IsAlive == true)
                {
                    spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
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
                    spriteBatch.Draw(jock, new Rectangle((int)positionJock.X, (int)positionJock.Y, 290, 400), Color.White);
                    spriteBatch.DrawString(font, "Jock Health: " + football.JHealth, new Vector2(270, 750), Color.Black);
                }
                if (cheer.IsAlive == true)
                {
                    spriteBatch.Draw(cheerLeader, new Rectangle((int)positionCheerLeader.X, (int)positionCheerLeader.Y, 270, 350), Color.White);
                    spriteBatch.DrawString(font, "CheerLeader Health: " + cheer.CHealth, new Vector2(0, 750), Color.Black);
                }

                if (round5State == Round5States.NerdTurn)
                {
                    spriteBatch.Draw(geekMenu, geekMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + nerd.GAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + nerd.GSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "30%", new Vector2(1270, 948), Color.Black);
                }
                else if (round5State == Round5States.EnemyTurn)
                {
                    spriteBatch.DrawString(font, "Enemy Turn", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
                else if (round5State == Round5States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "20%", new Vector2(1270, 948), Color.Black);
                }
                else if (round5State == Round5States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "10%", new Vector2(1270, 948), Color.Black);
                }
                else if (round5State == Round5States.Enemy2Turn)
                {
                    spriteBatch.DrawString(font, "Enemy Turn", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
            }

            if (round == 6)
            {
                spriteBatch.Draw(StreetBackgroundRound6, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                if (nerd.IsAlive == true)
                {
                    spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
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
                    spriteBatch.Draw(jock, new Rectangle((int)positionJock.X, (int)positionJock.Y, 290, 400), Color.White);
                    spriteBatch.DrawString(font, "Jock Health: " + football.JHealth, new Vector2(270, 750), Color.Black);
                }
                if (cheer.IsAlive == true)
                {
                    spriteBatch.Draw(cheerLeader, new Rectangle((int)positionCheerLeader.X, (int)positionCheerLeader.Y, 270, 350), Color.White);
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
                }
                else if (round6State == Round6States.EnemyTurn)
                {
                    spriteBatch.DrawString(font, "Enemy Turn", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
                else if (round6State == Round6States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "20%", new Vector2(1270, 948), Color.Black);
                }
                else if (round6State == Round6States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "10%", new Vector2(1270, 948), Color.Black);
                }
                else if (round6State == Round6States.Enemy2Turn)
                {
                    spriteBatch.DrawString(font, "Enemy Turn", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
            }

            if (round == 7)
            {
                spriteBatch.Draw(StreetBackgroundRound7, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                if (nerd.IsAlive == true)
                {
                    spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
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
                    spriteBatch.Draw(jock, new Rectangle((int)positionJock.X, (int)positionJock.Y, 290, 400), Color.White);
                    spriteBatch.DrawString(font, "Jock Health: " + football.JHealth, new Vector2(270, 750), Color.Black);
                }
                if (cheer.IsAlive == true)
                {
                    spriteBatch.Draw(cheerLeader, new Rectangle((int)positionCheerLeader.X, (int)positionCheerLeader.Y, 270, 350), Color.White);
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
                }
                else if (round7State == Round7States.EnemyTurn)
                {
                    spriteBatch.DrawString(font, "Enemy Turn", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
                else if (round7State == Round7States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "20%", new Vector2(1270, 948), Color.Black);
                }
                else if (round7State == Round7States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "10%", new Vector2(1270, 948), Color.Black);
                }
                else if (round7State == Round7States.Enemy2Turn)
                {
                    spriteBatch.DrawString(font, "Enemy Turn", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
            }

            if (round == 8)
            {
                spriteBatch.Draw(StreetBackgroundRound7, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);


                if (nerd.IsAlive == true)
                {
                    spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
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
                    spriteBatch.Draw(jock, new Rectangle((int)positionJock.X, (int)positionJock.Y, 290, 400), Color.White);
                    spriteBatch.DrawString(font, "Jock Health: " + football.JHealth, new Vector2(270, 750), Color.Black);
                }
                if (cheer.IsAlive == true)
                {
                    spriteBatch.Draw(cheerLeader, new Rectangle((int)positionCheerLeader.X, (int)positionCheerLeader.Y, 270, 350), Color.White);
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
                }
                else if (round8State == Round8States.EnemyTurn)
                {
                    spriteBatch.DrawString(font, "Enemy Turn", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
                else if (round8State == Round8States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "20%", new Vector2(1270, 948), Color.Black);
                }
                else if (round8State == Round8States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "10%", new Vector2(1270, 948), Color.Black);
                }
                else if (round8State == Round8States.Enemy2Turn)
                {
                    spriteBatch.DrawString(font, "Enemy Turn", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
            }

            if (round == 9)
            {
                spriteBatch.Draw(WhiteHouse, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);


                if (nerd.IsAlive == true)
                {
                    spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
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
                    spriteBatch.Draw(jock, new Rectangle((int)positionJock.X, (int)positionJock.Y, 290, 400), Color.White);
                    spriteBatch.DrawString(font, "Jock Health: " + football.JHealth, new Vector2(270, 750), Color.Black);
                }
                if (cheer.IsAlive == true)
                {
                    spriteBatch.Draw(cheerLeader, new Rectangle((int)positionCheerLeader.X, (int)positionCheerLeader.Y, 270, 350), Color.White);
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
                }
                else if (round9State == Round9States.EnemyTurn)
                {
                    spriteBatch.DrawString(font, "Enemy Turn", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
                else if (round9State == Round9States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "20%", new Vector2(1270, 948), Color.Black);
                }
                else if (round9State == Round9States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "10%", new Vector2(1270, 948), Color.Black);
                }
                else if (round9State == Round9States.Enemy2Turn)
                {
                    spriteBatch.DrawString(font, "Enemy Turn", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
            }

            if (round == 10)
            {
                spriteBatch.Draw(OvalOffice, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                if (nerd.IsAlive == true)
                {
                    spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 500, 375), Color.White);
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
                    spriteBatch.Draw(jock, new Rectangle((int)positionJock.X, (int)positionJock.Y, 290, 400), Color.White);
                    spriteBatch.DrawString(font, "Jock Health: " + football.JHealth, new Vector2(270, 750), Color.Black);
                }
                if (cheer.IsAlive == true)
                {
                    spriteBatch.Draw(cheerLeader, new Rectangle((int)positionCheerLeader.X, (int)positionCheerLeader.Y, 270, 350), Color.White);
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
                }
                else if (round10State == Round10States.EnemyTurn)
                {
                    spriteBatch.DrawString(font, "Enemy Turn", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
                else if (round10State == Round10States.JockTurn)
                {
                    spriteBatch.Draw(jockMenu, jockMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "20%", new Vector2(1270, 948), Color.Black);
                }
                else if (round10State == Round10States.CheerTurn)
                {
                    spriteBatch.Draw(cheerMenu, cheerMenuPosition, Color.White);
                    spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(690, 848), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(690, 948), Color.Black);
                    spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(1270, 848), Color.Black);
                    spriteBatch.DrawString(font, "10%", new Vector2(1270, 948), Color.Black);
                }
                else if (round10State == Round10States.Enemy2Turn)
                {
                    spriteBatch.DrawString(font, "Enemy Turn", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
                }
            }
            spriteBatch.DrawString(font, "Current X position for mouse: " + mState.X + " Y: " + mState.Y, new Vector2(20, 50), Color.Black);
            spriteBatch.End();
        }

        protected void TitleScreenInput()
        {

            // If statement for start button click
            if (mState.X >= 792 && mState.X <= 1055 && mState.Y >= 285 && mState.Y < 370 && mState.LeftButton == ButtonState.Pressed)
            {
                gState = GameStates.Game;
            }
            // If statement for credits button click
            if (mState.X >= 792 && mState.X <= 1055 && mState.Y >= 425 && mState.Y < 520 && mState.LeftButton == ButtonState.Pressed)
            {
                gState = GameStates.Credits;
            }
            // if statement for options button click
            if (mState.X >= 792 && mState.X <= 1055 && mState.Y >= 595 && mState.Y < 680 && mState.LeftButton == ButtonState.Pressed)
            {
                gState = GameStates.Options;
            }
        }

        // Method that handles clicking the return button and changing the state to the title screen 
        protected void ReturnButtonInput()
        {
            if (mState.X >= 735 && mState.X <= 1165 && mState.Y >= 835 && mState.Y < 975 && mState.LeftButton == ButtonState.Pressed)
            {
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
                round1State = Round1States.CheerTurn;
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

        }

        protected void JockCombat()
        {
            //Button click for attacking
            if (mState.X >= 1545 && mState.X <= 1845 && mState.Y >= 815 && mState.Y < 900 && mState.LeftButton == ButtonState.Pressed && LastmState.LeftButton != mState.LeftButton)
            {
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

        }

        protected void CheerCombat()
        {
            //Button click for attacking
            if (mState.X >= 1545 && mState.X <= 1845 && mState.Y >= 815 && mState.Y < 900 && mState.LeftButton == ButtonState.Pressed && LastmState.LeftButton != mState.LeftButton)
            {
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

            //Button click for switching character focus
            /* if (mState.X >= 91 && mState.X <= 160 && mState.Y >= 850 && mState.Y < 920 && mState.LeftButton == ButtonState.Pressed)
             {
                 switching = true;
                 attacking = false;
             }*/
        }

        protected void BattleStateClicks()
        {
            if (round1State == Round1States.NerdTurn && mState.X >= 1545 && mState.X <= 1845 && mState.Y >= 815 && mState.Y < 900 && mState.LeftButton == ButtonState.Pressed)
            {
                round1State = Round1States.EnemyTurn;
            }
            if (round1State == Round1States.EnemyTurn)
            {
                Thread.Sleep(3000);
                round1State = Round1States.JockTurn;
            }
            if (round1State == Round1States.JockTurn && mState.X >= 1545 && mState.X <= 1845 && mState.Y >= 815 && mState.Y < 900 && mState.LeftButton == ButtonState.Pressed)
            {
                round1State = Round1States.CheerTurn;
            }
            if (round1State == Round1States.CheerTurn && mState.X >= 1545 && mState.X <= 1845 && mState.Y >= 815 && mState.Y < 900 && mState.LeftButton == ButtonState.Pressed)
            {
                round1State = Round1States.Enemy2Turn;
            }
            if (round1State == Round1States.Enemy2Turn)
            {
                Thread.Sleep(3000);
                round1State = Round1States.NerdTurn;
            }
        }
    }
}
