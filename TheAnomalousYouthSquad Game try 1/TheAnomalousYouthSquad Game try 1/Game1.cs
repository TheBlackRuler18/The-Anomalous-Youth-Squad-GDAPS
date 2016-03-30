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
    enum GameStates { Intro, TitleScreen, Options, Credits, Game}

    enum BattleStates { NerdTurn, JockTurn, CheerTurn, EnemyTurn, Enemy2Turn }
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

        BattleStates bState;
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

        // Background Picture
        Texture2D GameBackground;

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

        // Make a enemy for test
        Enemy bad = new Enemy(120, 10, 10, 10, true);
        Enemy enemy = new Enemy(150, 10, 10, 10, true);
            
        // More test stuff
        List<Enemy> enemies;

        // Sprites for the characters and enemies
        Texture2D geek;
        Texture2D alien;
        Texture2D jock;
        Texture2D cheerLeader;
        Vector2 positionGeek;
        Vector2 positionAlien;
        Vector2 positionJock;
        Vector2 positionCheerLeader;

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
            graphics.PreferredBackBufferWidth = 1520;
            graphics.PreferredBackBufferHeight = 850;
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
            BluePosition = new Vector2(0, 395);
            GreenPosition = new Vector2(1420, 395);
            PurplePosition = new Vector2(710, 0);
            WhitePosition = new Vector2(710, 395);
            startBPosition = new Vector2(630, 285);
            creditsBPosition = new Vector2(630, 425);
            optionsBPosition = new Vector2(630, 595);
            TitlePosition = new Vector2(95, 110);
            LogoPosition = new Vector2(586, 535);
            MousePosition = new Point(mState.X, mState.Y);

            startArea = new Rectangle((int)startBPosition.X, (int)startBPosition.Y, 256, 70); // Area for start button
            optionsArea = new Rectangle((int)optionsBPosition.X, (int)optionsBPosition.Y, 256, 70); // Area for options button
            creditsArea = new Rectangle((int)creditsBPosition.X, (int)creditsBPosition.Y, 256, 70); // Area for credits button

            startArea = new Rectangle((int)startBPosition.X, (int)startBPosition.Y, 256, 70);
            optionsArea = new Rectangle((int)optionsBPosition.X, (int)optionsBPosition.Y, 256, 70);
            creditsArea = new Rectangle((int)creditsBPosition.X, (int)creditsBPosition.Y, 256, 70);

            returnBPosition = new Vector2(470, 540);

            // Test stuff
            enemies = new List<Enemy>();

            // Setting up the charcters
            positionGeek = new Vector2(180, 350);
            positionAlien = new Vector2(GraphicsDevice.Viewport.Width - 420, 355);
            positionJock = new Vector2(130, 320);
            positionCheerLeader = new Vector2(-40, 356);

            // Setting up Menus
            geekMenuPosition = new Vector2(0, 700);
            jockMenuPosition = new Vector2(0, 700);
            cheerMenuPosition = new Vector2(0, 700);

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
            OptionsButton= Content.Load<Texture2D>("OptionsButton");

            // Title for game 
            Title = Content.Load<Texture2D>("GameTitle");

            // Logo for intro
            Logo = Content.Load<Texture2D>("GameLogo");

            // Load in gStateBackground
            gStateBackground = Content.Load<Texture2D>("Game State background");

            // Load in Return button
            returnButton = Content.Load<Texture2D>("Return Button");

            // Load in charcters rites
            geek = Content.Load<Texture2D>("Geek Character");
            alien = Content.Load<Texture2D>("Alien Character");
            jock = Content.Load<Texture2D>("Jock Charcater for game");
            cheerLeader = Content.Load<Texture2D>("CheerLeader Charcter for game");

            // Load in Charcater Menus
            geekMenu = Content.Load<Texture2D>("Menu for game(Geek)");
            jockMenu = Content.Load<Texture2D>("Menu for game(Jock)");
            cheerMenu = Content.Load<Texture2D>("Menu for game(CheerLeader)");
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

            base.Update(gameTime);

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
            switch (bState)
            {
                case BattleStates.NerdTurn:
                    if (nerd.GHealth != 0)
                    {
                        NerdCombat();
                    }
                    break;

                case BattleStates.EnemyTurn:
                    if (bad.EHealth != 0)
                    {
                        enemyCombat();
                    }
                    break;
                case BattleStates.JockTurn:
                    if (football.JHealth != 0)
                    {
                        JockCombat();
                    }
                    break;
                case BattleStates.CheerTurn:
                    if (cheer.CHealth != 0)
                    {
                        CheerCombat();
                    }
                    break;
                case BattleStates.Enemy2Turn:
                    if (enemy.EHealth != 0)
                    {
                        enemyCombat2();
                    }
                    break;
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
          
            spriteBatch.Draw(Logo, new Rectangle((int)LogoPosition.X,(int)LogoPosition.Y, 350,300), Color.White);
            

            spriteBatch.End();
        }

        protected void DrawTitleScreen(GameTime gameTime)
        {
            spriteBatch.Begin();
            // Draws Background to the screen
            spriteBatch.Draw(GameBackground, new Rectangle(0,0, GraphicsDevice.Viewport.Width,GraphicsDevice.Viewport.Height), Color.White);
            spriteBatch.Draw(Title, TitlePosition, Color.White);
            spriteBatch.Draw(StartButton, startBPosition, Color.White);
            spriteBatch.Draw(CreditsButtons, creditsBPosition, Color.White);
            spriteBatch.Draw(OptionsButton, optionsBPosition, Color.White);

            // Mouse Position test. Commented out for the actual game. Un-comment it out when needed.
            //spriteBatch.DrawString(font, "Current X position for mouse: " + mState.X + " Y: " + mState.Y, new Vector2(20, 50), Color.Black);
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
            spriteBatch.DrawString(font, "This is a game was made over the course of our spring semester at Rochester Institute of Technology" , new Vector2(GraphicsDevice.Viewport.Width/3, 20), Color.Black);
            spriteBatch.DrawString(font, "The roles for the project include:" , new Vector2(GraphicsDevice.Viewport.Width / 3, 40), Color.Black);
            spriteBatch.DrawString(font, "Project Lead: Herman McElveen", new Vector2(GraphicsDevice.Viewport.Width / 3, 60), Color.Black);
            spriteBatch.DrawString(font, "Project Architect: Ryan Lowrie", new Vector2(GraphicsDevice.Viewport.Width / 3, 80), Color.Black);
            spriteBatch.DrawString(font, "Project Design: Tung Nguyen", new Vector2(GraphicsDevice.Viewport.Width / 3, 100), Color.Black);
            spriteBatch.DrawString(font, "Project Interface: Yoon Kim", new Vector2(GraphicsDevice.Viewport.Width / 3, 120), Color.Black);
            spriteBatch.End();
        }

        protected void DrawGame(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(gStateBackground, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

            // try code

            if (nerd.IsAlive == true)
            {
                spriteBatch.Draw(geek, new Rectangle((int)positionGeek.X, (int)positionGeek.Y, 440, 315), Color.White);
                spriteBatch.DrawString(font, "Nerd Health: " + nerd.GHealth, new Vector2(460, 670), Color.Black);
            }
            if (bad.IsAlive == true)
            {
                spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X, (int)positionAlien.Y, 470, 295), Color.White);
                spriteBatch.DrawString(font, "Enemy Health: " + bad.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 320, 670), Color.Black);
            }
            if (enemy.IsAlive == true)
            {
                spriteBatch.Draw(alien, new Rectangle((int)positionAlien.X - 400, (int)positionAlien.Y, 470, 295), Color.White);
                spriteBatch.DrawString(font, "Enemy Health: " + enemy.EHealth, new Vector2(GraphicsDevice.Viewport.Width - 680, 670), Color.Black);
            }
            if (football.IsAlive == true)
            {
                spriteBatch.Draw(jock, new Rectangle((int)positionJock.X, (int)positionJock.Y, 220, 340), Color.White);
                spriteBatch.DrawString(font, "Jock Health: " + football.JHealth, new Vector2(240, 670), Color.Black);
            }
            if (cheer.IsAlive == true)
            {
                spriteBatch.Draw(cheerLeader, new Rectangle((int)positionCheerLeader.X, (int)positionCheerLeader.Y, 200, 300), Color.White);
                spriteBatch.DrawString(font, "CheerLeader Health: " + cheer.CHealth, new Vector2(0, 670), Color.Black);
            }

            if (bState == BattleStates.NerdTurn)
            {
                spriteBatch.Draw(geekMenu, new Rectangle((int)geekMenuPosition.X, (int)geekMenuPosition.Y, 1520,150), Color.White);
                spriteBatch.DrawString(font, "" + nerd.GAttack, new Vector2(690, 848), Color.Black);
                spriteBatch.DrawString(font, "" + nerd.GDefense, new Vector2(690, 948), Color.Black);
                spriteBatch.DrawString(font, "" + nerd.GSpeed, new Vector2(1270, 848), Color.Black);
                spriteBatch.DrawString(font, "30%", new Vector2(1270, 948), Color.Black);
            }
            else if (bState == BattleStates.EnemyTurn)
            {
                spriteBatch.DrawString(font, "Enemy Turn", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
            }
            else if (bState == BattleStates.JockTurn)
            {
                spriteBatch.Draw(jockMenu, new Rectangle((int)jockMenuPosition.X, (int)jockMenuPosition.Y, 1520, 150), Color.White);
                spriteBatch.DrawString(font, "" + football.JAttack, new Vector2(690, 848), Color.Black);
                spriteBatch.DrawString(font, "" + football.JDefense, new Vector2(690, 948), Color.Black);
                spriteBatch.DrawString(font, "" + football.JSpeed, new Vector2(1270, 848), Color.Black);
                spriteBatch.DrawString(font, "20%", new Vector2(1270, 948), Color.Black);
            }
            else if (bState == BattleStates.CheerTurn)
            {
                spriteBatch.Draw(cheerMenu, new Rectangle((int)cheerMenuPosition.X, (int)cheerMenuPosition.Y, 1520, 150), Color.White);
                spriteBatch.DrawString(font, "" + cheer.CAttack, new Vector2(690, 848), Color.Black);
                spriteBatch.DrawString(font, "" + cheer.CDefense, new Vector2(690, 948), Color.Black);
                spriteBatch.DrawString(font, "" + cheer.CSpeed, new Vector2(1270, 848), Color.Black);
                spriteBatch.DrawString(font, "10%", new Vector2(1270, 948), Color.Black);
            }
            else if (bState == BattleStates.Enemy2Turn)
            {
                spriteBatch.DrawString(font, "Enemy Turn", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 100), Color.Black);
            }

            spriteBatch.DrawString(font, "Current X position for mouse: " + mState.X + " Y: " + mState.Y, new Vector2(20, 50), Color.Black);
            spriteBatch.End();
        }

        protected void TitleScreenInput()
        {

            // If statement for start button click
            if (mState.X >= 632 && mState.X <= 895 && mState.Y >= 285 && mState.Y < 370 && mState.LeftButton == ButtonState.Released && LastmState.LeftButton == ButtonState.Pressed)
            {
                gState = GameStates.Game;
            }
            // If statement for credits button click
            if (mState.X >= 632 && mState.X <= 895 && mState.Y >= 425 && mState.Y < 520 && mState.LeftButton == ButtonState.Released && LastmState.LeftButton == ButtonState.Pressed)
            {
                gState = GameStates.Credits;
            }  
            // if statement for options button click
            if(mState.X >= 632 && mState.X <= 895 && mState.Y >= 595 && mState.Y < 680 && mState.LeftButton == ButtonState.Released && LastmState.LeftButton == ButtonState.Pressed)
            {
                gState = GameStates.Options; 
            }
        }

        // Method that handles clicking the return button and changing the state to the title screen 
        protected void ReturnButtonInput()
        {
            if (mState.X >= 575 && mState.X <= 1005 && mState.Y >= 665 && mState.Y < 805 && mState.LeftButton == ButtonState.Released && LastmState.LeftButton == ButtonState.Pressed)
            {
                gState = GameStates.TitleScreen;
            }
        }   

        protected void enemyCombat()
        {
            Random rng = new Random();
            int num = rng.Next(101);

            if (num >= 0 && num < 40)
            {
                int attack = bad.Attack();
                nerd.GHealth = nerd.GHealth - attack;
            }
            else if (num >= 41 && num < 80)
            {
                int attack = bad.Attack();
                football.JHealth = football.JHealth - attack;
            }
            else
            {
                int attack = bad.Attack();
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
            bState = BattleStates.JockTurn;
        }

        protected void enemyCombat2()
        {
            Random rng = new Random();
            int num = rng.Next(101);
            if (num >= 0 && num < 40)
            {
                int attack = enemy.Attack();
                nerd.GHealth = nerd.GHealth - attack;
            }
            else if (num >= 41 && num < 80)
            {
                int attack = enemy.Attack();
                football.JHealth = football.JHealth - attack;
            }
            else
            {
                int attack = enemy.Attack();
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
            bState = BattleStates.NerdTurn;
        }

        protected void NerdCombat()
        {
            //Button click for attacking
            if (mState.X >= 1235 && mState.X <= 1480 && mState.Y >= 710 && mState.Y < 770 && mState.LeftButton == ButtonState.Pressed && LastmState.LeftButton != mState.LeftButton)
            {
                Random rng = new Random();
                int num = rng.Next(101);

                int attack = nerd.Attack();
                if (num >= 0 && num < 50)
                {
                    bad.EHealth = bad.EHealth - attack;
                }
                else
                {
                    enemy.EHealth = enemy.EHealth - attack;
                }
                if (bad.EHealth <= 0)
                {
                    bad.EHealth = 0;
                    bad.IsAlive = false;
                }
                if (enemy.EHealth <= 0)
                {
                    enemy.EHealth = 0;
                    enemy.IsAlive = false;
                };

                bState = BattleStates.EnemyTurn;
            }

        }

        protected void JockCombat()
        {
            //Button click for attacking
            if (mState.X >= 1235 && mState.X <= 1480 && mState.Y >= 710 && mState.Y < 770 && mState.LeftButton == ButtonState.Pressed && LastmState.LeftButton != mState.LeftButton)
            {
                Random rng = new Random();
                int num = rng.Next(101);

                int attack = football.Attack();
                if (num >= 0 && num < 50)
                {
                    bad.EHealth = bad.EHealth - attack;
                }
                else
                {
                    enemy.EHealth = enemy.EHealth - attack;
                }
                if (bad.EHealth <= 0)
                {
                    bad.EHealth = 0;
                    bad.IsAlive = false;
                }
                if (enemy.EHealth <= 0)
                {
                    enemy.EHealth = 0;
                    enemy.IsAlive = false;
                }

                bState = BattleStates.CheerTurn;
            }

        }

        protected void CheerCombat()
        {
            //Button click for attacking
            if (mState.X >= 1235 && mState.X <= 1480 && mState.Y >= 710 && mState.Y < 770 && mState.LeftButton == ButtonState.Pressed && LastmState.LeftButton != mState.LeftButton)
            {
                Random rng = new Random();
                int num = rng.Next(101);

                int attack = cheer.Attack();
                if (num >= 0 && num < 50)
                {
                    bad.EHealth = bad.EHealth - attack;
                }
                else
                {
                    enemy.EHealth = enemy.EHealth - attack;
                }
                if (bad.EHealth <= 0)
                {
                    bad.EHealth = 0;
                    bad.IsAlive = false;
                }
                if (enemy.EHealth <= 0)
                {
                    enemy.EHealth = 0;
                    enemy.IsAlive = false;
                }
                bState = BattleStates.Enemy2Turn;
            }

            //Button click for switching character focus
            /* if (mState.X >= 91 && mState.X <= 160 && mState.Y >= 850 && mState.Y < 920 && mState.LeftButton == ButtonState.Pressed)
             {
                 switching = true;
                 attacking = false;
             }*/
        }
    }
}
