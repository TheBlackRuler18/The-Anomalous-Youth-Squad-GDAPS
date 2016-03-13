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

        public int CHealth { get { return cHealth; } }
        public int CAttack { get { return cAttack; } }
        public int CDefense { get { return cDefense; } }
        public int CSpeed { get { return cSpeed; } }
        public bool IsAlive { get { return isAlive; } }

        // constructor
        public Cheerleader(int h, int s, int a, int d, bool i) : base(h, s, a, d, i)
        {
            cHealth = h;
            cAttack = a;
            cSpeed = s;
            cDefense = d;
            isAlive = true;
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

            if(chance >= 0 && chance < 25)
            {
                cAttack = 0;
            }
            else if(chance >= 26 && chance < 45)
            {
                cAttack = 5;
            }
            else if(chance >= 46 && chance < 65)
            {
                cAttack = 10;
            }
            else if(chance >= 66 && chance < 85)
            {
                cAttack = 15;
            }
            else
            {
                cAttack = 30;
            }

            return cAttack;
        }

        public override void ChangeHealth(int amount)
        {
            cHealth = cHealth - amount;

            if(cHealth < 0)
            {
                cHealth = 0;
            }
        }
    }
}
