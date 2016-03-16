using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace TheAnomalousYouthSquad_Game_try_1
{
    class Geek : Character
    {
        private int gHealth;
        private int gSpeed;
        private int gDefense;
        private int gAttack;
        private bool isAlive;
        private Rectangle gRect;

        public int GHealth { get { return gHealth; } set { gHealth = value; } }
        public int GAttack { get { return gAttack; } }
        public int GDefense { get { return gDefense; } }
        public int GSpeed { get { return gSpeed; } }
        public bool IsAlive { get { return isAlive; } set { isAlive = value; } }

        // Constructor
        public Geek(int h, int s, int a, int d, bool i) : base(h, s, a, d, i)
        {
            gHealth = h;
            gAttack = a;
            gSpeed = s;
            gDefense = d;
            isAlive = true;
        }

        // check if player is dead
        public override void playerDead()
        {
            if (isAlive == true) isAlive = false;
        }

        public override int Attack(/*Enemy target*/)
        {
            gAttack = 0;
            Random rng = new Random();
            int chance = rng.Next(101);

            if (chance >= 0 && chance < 25)
            {
                gAttack = 0;
            }
            else if (chance >= 26 && chance < 45)
            {
                gAttack = 5;
            }
            else if (chance >= 46 && chance < 65)
            {
                gAttack = 10;
            }
            else if (chance >= 66 && chance < 85)
            {
                gAttack = 15;
            }
            else
            {
                gAttack = 30;
            }

            return gAttack;
        }

        public override void Draw(SpriteBatch sbatch)
        {
            
        }
        /* public override void ChangeHealth(int amount)
        {
            gHealth = gHealth - amount;

            if (gHealth < 0)
            {
                gHealth = 0;
            }
        }*/
    }
}
