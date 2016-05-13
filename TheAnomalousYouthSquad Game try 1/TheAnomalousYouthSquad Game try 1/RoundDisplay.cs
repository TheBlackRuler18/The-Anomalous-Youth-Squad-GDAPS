using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TheAnomalousYouthSquad_Game_try_1
{
    class RoundDisplay
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
        int stop;

        public int Stop { get { return stop; } set { stop = value; } }
        public int MilisecondPerFrame { set { milisecondPerFrame = value; } }

        public RoundDisplay(Texture2D img, Point size, int frames, int rows, int cls, int msPerFrame)
        {
            picture = img;
            frameSize = size;
            numFrames = frames;
            row = rows;
            cols = cls;
            milisecondPerFrame = msPerFrame;
            currentFrame.X = 0;
            currentFrame.Y = 0;
            stop = 0;
        }

        public void UpdateRound1(GameTime gameTime)
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
                        currentFrame.X = 905;
                        currentFrame.Y = 0;
                        break;

                    case 2:
                        currentFrame.X = 1810;
                        currentFrame.Y = 0;
                        break;

                    case 3:
                        currentFrame.X = 2715;
                        currentFrame.Y = 0;
                        break;

                    case 4:
                        currentFrame.X = 0;
                        currentFrame.Y = 240;
                        break;

                    case 5:
                        currentFrame.X = 905;
                        currentFrame.Y = 240;
                        break;

                    case 6:
                        currentFrame.X = 1810;
                        currentFrame.Y = 240;
                        break;

                    case 7:
                        currentFrame.X = 2715;
                        currentFrame.Y = 240;
                        break;

                    case 8:
                        currentFrame.X = 0;
                        currentFrame.Y = 480;
                        break;

                    case 9:
                        currentFrame.X = 905;
                        currentFrame.Y = 480;
                        break;

                    case 10:
                        currentFrame.X = 1810;
                        currentFrame.Y = 480;
                        break;

                    case 11:
                        currentFrame.X = 2715;
                        currentFrame.Y = 480;
                        break;

                    case 12:
                        currentFrame.X = 0;
                        currentFrame.Y = 720;
                        break;

                    case 13:
                        currentFrame.X = 905;
                        currentFrame.Y = 720;
                        break;

                    case 14:
                        currentFrame.X = 1810;
                        currentFrame.Y = 720;
                        break;

                    case 15:
                        currentFrame.X = 2715;
                        currentFrame.Y = 720;
                        break;

                    case 16:
                        currentFrame.X = 0;
                        currentFrame.Y = 960;
                        break;

                    case 17:
                        currentFrame.X = 905;
                        currentFrame.Y = 960;
                        break;

                    case 18:
                        currentFrame.X = 1810;
                        currentFrame.Y = 960;
                        break;

                    case 19:
                        currentFrame.X = 2715;
                        currentFrame.Y = 960;
                        break;

                    case 20:
                        currentFrame.X = 0;
                        currentFrame.Y = 1200;
                        stop = 1;
                        break;

                    /*case 21:
                        currentFrame.X = 0;
                        currentFrame.Y = 2000;
                        break;*/
                }
            }
        }

        public void DrawRound1(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(picture, new Rectangle(500, -25, 800, 200), new Rectangle(currentFrame.X, currentFrame.Y
                , frameSize.X, frameSize.Y), Color.White,
                0,
                Vector2.Zero,
                SpriteEffects.None,
               1);
        }
    }
}
