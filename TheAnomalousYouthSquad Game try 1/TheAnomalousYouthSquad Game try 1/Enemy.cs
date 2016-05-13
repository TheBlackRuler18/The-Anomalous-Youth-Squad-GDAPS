using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheAnomalousYouthSquad_Game_try_1
{
    class Enemy : Character
    {
        private int eHealth;
        private int eAttack;
        private int eDefense;
        private int eSpeed;
        private bool isAlive;

        public int EHealth { get { return eHealth; } set { eHealth = value; } }
        public int EAttack { get { return eAttack; } }
        public int EDefense { get { return eDefense; } }
        public int ESpeed { get { return eSpeed; } }
        public bool IsAlive { get { return isAlive; } set { isAlive = value; } }

        public Enemy(int h, int s, int a, int d, bool i) : base(h, s, a, d, i)
        {
            eHealth = h;
            eAttack = a;
            eSpeed = s;
            eDefense = d;
            isAlive = true;
        }

        // check if enemy is dead
        public override void playerDead()
        {
            if (isAlive == true) isAlive = false;
        }

        // attack method
        public override int Attack(/*Enemy target*/)
        {
            eAttack = 0;
            Random rng = new Random();
            int chance = rng.Next(101);

            if (chance >= 0 && chance < 25)
            {
                eAttack = 0;
            }
            else if (chance >= 26 && chance < 45)
            {
                eAttack = eAttack -5;
            }
            else if (chance >= 46 && chance < 65)
            {
                eAttack = eAttack += 0;
            }
            else if (chance >= 66 && chance < 85)
            {
                eAttack = eAttack += 5;
            }
            else
            {
                eAttack = eAttack += 15;
            }

            return eAttack;
        }

        public override void ChangeHealth(int amount)
        {
            eHealth = eHealth - amount;

            if (eHealth < 0)
            {
                eHealth = 0;
            }
        }

    }
}

