﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace TheAnomalousYouthSquad_Game_try_1
{
    // Staes for the game
    enum GameStates { Intro, TitleScreen, Options, Credits, Game}
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

        // Button for attack in the game state
        Texture2D atkButton;
        Texture2D switchButton;



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
            startArea = new Rectangle((int)startBPosition.X, (int)startBPosition.Y, 256, 70);
            optionsArea = new Rectangle((int)optionsBPosition.X, (int)optionsBPosition.Y, 256, 70);
            creditsArea = new Rectangle((int)creditsBPosition.X, (int)creditsBPosition.Y, 256, 70);

            returnBPosition = new Vector2(470, 540);

            base.Initialize();

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

            // Load in game buttons
            atkButton = Content.Load<Texture2D>("SCAttack");
            switchButton = Content.Load<Texture2D>("SCSwitchSelec");
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

            // Mouse Position test
            spriteBatch.DrawString(font, "Current X position for mouse: " + mState.X + " Y: " + mState.Y, new Vector2(20, 50), Color.Black);
            spriteBatch.End();
        }


        protected void DrawOptions(GameTime gameTime)
        {
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.Green);
            spriteBatch.Draw(returnButton, returnBPosition, Color.White);
            spriteBatch.DrawString(font, "Current X position for mouse: " + mState.X + " Y: " + mState.Y, new Vector2(20, 50), Color.Black);
            spriteBatch.End();
        }

        protected void DrawCredits(GameTime gameTime)
        {
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.Pink);
            spriteBatch.Draw(returnButton, returnBPosition, Color.White);
            spriteBatch.End();
        }

        protected void DrawGame(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(gStateBackground, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
            spriteBatch.DrawString(font, "Current X position for mouse: " + mState.X + " Y: " + mState.Y, new Vector2(20, 50), Color.Black);

            // try code
            spriteBatch.Draw(atkButton, new Rectangle(0 + atkButton.Bounds.Width, GraphicsDevice.Viewport.Height - atkButton.Bounds.Height * 4, atkButton.Bounds.Width, atkButton.Bounds.Height), Color.White);
            spriteBatch.Draw(switchButton, new Rectangle(0 + atkButton.Bounds.Width * 2, GraphicsDevice.Viewport.Height - atkButton.Bounds.Height * 4, atkButton.Bounds.Width, atkButton.Bounds.Height), Color.White);


            spriteBatch.End();
        }

        protected void TitleScreenInput()
        {
            LastmState = mState;
            mState = Mouse.GetState();
            // If statement for start button click
            if (mState.X >= 632 && mState.X <= 895 && mState.Y >= 285 && mState.Y < 370 && mState.LeftButton == ButtonState.Pressed)
            {
                gState = GameStates.Game;
            }
            // If statement for credits button click
            if (mState.X >= 632 && mState.X <= 895 && mState.Y >= 425 && mState.Y < 520 && mState.LeftButton == ButtonState.Pressed)
            {
                gState = GameStates.Credits;
            }  
            // if statement for options button click
            if(mState.X >= 632 && mState.X <= 895 && mState.Y >= 595 && mState.Y < 680 && mState.LeftButton == ButtonState.Pressed)
            {
                gState = GameStates.Options; 
            }
        }
        protected void GameScreenInput()
        {
            LastmState = mState;
            mState = Mouse.GetState();
            // If statement for start button click
            if (mState.X >= atkButton.Bounds.X && mState.X <= atkButton.Bounds.X + atkButton.Bounds.Width && mState.Y >= atkButton.Bounds.Y && mState.Y <= atkButton.Bounds.Y + atkButton.Bounds.Height && mState.LeftButton == ButtonState.Pressed)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(font, "Character attack!", new Vector2(GraphicsDevice.Viewport.Width/2, GraphicsDevice.Viewport.Height/2), Color.Black);
                spriteBatch.End();
            }
            // If statement for credits button click
            /*if (mState.X >= 632 && mState.X <= 895 && mState.Y >= 425 && mState.Y < 520 && mState.LeftButton == ButtonState.Pressed)
            {
            }
            // if statement for options button click
            if (mState.X >= 632 && mState.X <= 895 && mState.Y >= 595 && mState.Y < 680 && mState.LeftButton == ButtonState.Pressed)
            {
            }*/
        }

        protected void ReturnButtonInput()
        {
            LastmState = mState;
            mState = Mouse.GetState();

            if (mState.X >= 575 && mState.X <= 1005 && mState.Y >= 665 && mState.Y < 805 && mState.LeftButton == ButtonState.Pressed)
            {
                gState = GameStates.TitleScreen;
            }
        }
    }
}
