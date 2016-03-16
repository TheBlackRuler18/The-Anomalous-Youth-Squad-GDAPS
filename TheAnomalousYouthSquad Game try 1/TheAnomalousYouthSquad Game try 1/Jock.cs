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
    class Jock : Character
    {
        private int jHealth;
        private int jAttack;
        private int jDefense;
        private int jSpeed;
        private bool isAlive;
        private Rectangle jRect;

        public int JHealth { get { return jHealth; } set { jHealth = value; } }
        public int JAttack { get { return jAttack; } }
        public int JDefense { get { return jDefense; } }
        public int JSpeed { get { return jSpeed; } }
        public bool IsAlive { get { return isAlive; } set { isAlive = value; } }


        public Jock(int h, int s, int a, int d, bool i) : base(h, s, a, d, i)
        {}

        // attack method
        public override int Attack(/*Enemy target*/)
        {
            jAttack = 0;
            Random rng = new Random();
            int chance = rng.Next(101);

            if (chance >= 0 && chance < 25)
            {
                jAttack = 0;
            }
            else if (chance >= 26 && chance < 45)
            {
                jAttack = 5;
            }
            else if (chance >= 46 && chance < 65)
            {
                jAttack = 10;
            }
            else if (chance >= 66 && chance < 85)
            {
                jAttack = 15;
            }
            else
            {
                jAttack = 30;
            }

            return jAttack;
        }

        public override void Draw(SpriteBatch sbatch)
        {
            
        }

        /*public override void ChangeHealth(int amount)
        {
            jHealth = jHealth - amount;

            if (jHealth < 0)
            {
                jHealth = 0;
            }
        }*/
    }
}
