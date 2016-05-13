using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace TheAnomalousYouthSquad_Game_try_1
{
    class Enemy2IdleSprite
    {
        private Texture2D picture;
        private int frame;
        private Point frameSize;
        private int numFrames;
        private int row, cols;
        private int timeSinceLastFrame;
        private int milisecondPerFrame;
        private Point currentFrame;
        private Rectangle positions = new Rectangle(1700, 820, 213, 160);
        int loop;

        public int Loop { get { return loop; } set { loop = value; } }
        public int MilisecondPerFrame { set { milisecondPerFrame = value; } }

        public Enemy2IdleSprite(Texture2D img, Point size, int frames, int rows, int cls, int msPerFrame)
        {
            picture = img;
            frameSize = size;
            numFrames = frames;
            row = rows;
            cols = cls;
            milisecondPerFrame = msPerFrame;
            currentFrame.X = 0;
            currentFrame.Y = 0;
            loop = 0;
        }

        public void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastFrame > milisecondPerFrame)
            {
                timeSinceLastFrame = 0;
                frame++;

                if (frame >= numFrames)
                {
                    frame = 0;
                }

                switch (frame)
                {
                    case 0:
                        currentFrame.X = 0;
                        currentFrame.Y = 0;
                        break;

                    case 1:
                        currentFrame.X = 970;
                        currentFrame.Y = 0;
                        break;
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(picture, new Rectangle(1400, 270, 600, 475), new Rectangle(currentFrame.X, currentFrame.Y
                , frameSize.X, frameSize.Y), Color.White,
                0,
                Vector2.Zero,
                SpriteEffects.None,
               1);
        }

        public void DrawMini(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(picture, new Rectangle(1150, 475, 250, 275), new Rectangle(currentFrame.X, currentFrame.Y
                , frameSize.X, frameSize.Y), Color.White,
                0,
                Vector2.Zero,
                SpriteEffects.None,
               1);
        }

        public void DrawTall(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(picture, new Rectangle(1250, 150, 350, 600), new Rectangle(currentFrame.X, currentFrame.Y
                , frameSize.X, frameSize.Y), Color.White,
                0,
                Vector2.Zero,
                SpriteEffects.None,
               1);
        }
    }
}

    