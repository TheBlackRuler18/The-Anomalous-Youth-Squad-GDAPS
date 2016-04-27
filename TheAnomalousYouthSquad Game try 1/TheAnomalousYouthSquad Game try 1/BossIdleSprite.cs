﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TheAnomalousYouthSquad_Game_try_1
{
    class BossIdleSprite
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

        public BossIdleSprite(Texture2D img, Point size, int frames, int rows, int cls, int msPerFrame)
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
                        currentFrame.X = 1000;
                        currentFrame.Y = 0;
                        break;
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(picture, new Rectangle(positions.X, positions.Y, positions.Width, positions.Height), new Rectangle(currentFrame.X, currentFrame.Y
                , frameSize.X, frameSize.Y), Color.White,
                0,
                Vector2.Zero,
                SpriteEffects.None,
               1);
        }
    }
}

