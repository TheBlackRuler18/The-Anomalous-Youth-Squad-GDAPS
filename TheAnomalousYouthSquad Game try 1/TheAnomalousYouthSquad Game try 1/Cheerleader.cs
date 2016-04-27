using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheAnomalousYouthSquad_Game_try_1
{
    class Cheerleader : Character
    {
        // attributes
        private int cHealth;
        private int cAttack;
        private int cSpeed;
        private int cDefense;
        private bool isAlive;
        private int specialMeter;
        public int CHealth { get { return cHealth; } set { cHealth = value; } }
        public int CAttack { get { return cAttack; } }
        public int CDefense { get { return cDefense; } }
        public int CSpeed { get { return cSpeed; } }
        public bool IsAlive { get { return isAlive; } set { isAlive = value; } }
        public int SpecialMeter { get { return specialMeter; } set { specialMeter = value; } }

        // constructor
        public Cheerleader(int h, int s, int a, int d, bool i) : base(h, s, a, d, i)
        {
            cHealth = h;
            cAttack = a;
            cSpeed = s;
            cDefense = d;
            isAlive = true;
            specialMeter = 0;
            if (specialMeter > 100)
            {
                specialMeter = 100;
            }
        }

        public override void playerDead()
        {
            if (isAlive == true) isAlive = false;
        }

        // attack method
        public override int Attack(/*Enemy target*/)
        {
            cAttack = 0;
            Random rng = new Random();
            int chance = rng.Next(101);

            if (chance >= 0 && chance < 25)
            {
                cAttack = 50;
            }
            else if (chance >= 26 && chance < 45)
            {
                cAttack = 50;
            }
            else if (chance >= 46 && chance < 65)
            {
                cAttack = 50;
            }
            else if (chance >= 66 && chance < 85)
            {
                cAttack = 50;
            }
            else
            {
                cAttack = 50;
            }

            return cAttack;
        }

        public override void ChangeHealth(int amount)
        {
            cHealth = cHealth - amount;

            if (cHealth < 0)
            {
                cHealth = 0;
            }
        }
    }
}