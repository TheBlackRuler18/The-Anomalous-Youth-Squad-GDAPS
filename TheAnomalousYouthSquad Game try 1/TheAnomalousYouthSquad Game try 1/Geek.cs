using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheAnomalousYouthSquad_Game_try_1
{
    class Geek : Character
    {
        private int gHealth;
        private int gMaxHealth;
        private int gSpeed;
        private int gDefense;
        private int gAttack;
        private bool isAlive;
        private int specialMeter;
        private int specialMax;

        public int GHealth { get { return gHealth; } set { gHealth = value; } }
        public int GMaxHealth { get { return gMaxHealth; } }
        public int GAttack { get { return gAttack; } set { gAttack = value; } }
        public int GDefense { get { return gDefense; } }
        public int GSpeed { get { return gSpeed; } }
        public bool IsAlive { get { return isAlive; } set { isAlive = value; } }
        public int SpecialMeter
        {
            get { return specialMeter; }
            set
            {
                if (value <= 100)
                {
                    specialMeter = value;
                }
                else
                {
                    specialMeter = 100;
                }
            }
        }
        public int SpecialMax { get { return specialMax; } }

        // Constructor
        public Geek(int h, int s, int a, int d, bool i) : base(h, s, a, d, i)
        {
            gHealth = h;
            gMaxHealth = gHealth;
            gAttack = a;
            gSpeed = s;
            gDefense = d;
            isAlive = true;
            specialMeter = 0;
            specialMax = 100;
            if (specialMeter > specialMax)
            {
                specialMeter = 100;
            }
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
                gAttack = 10;
            }
            else if (chance >= 26 && chance < 45)
            {
                gAttack = 10;
            }
            else if (chance >= 46 && chance < 65)
            {
                gAttack = 20;
            }
            else if (chance >= 66 && chance < 85)
            {
                gAttack = 30;
            }
            else
            {
                gAttack = 30;
            }

            return gAttack;
        }

        public override void ChangeHealth(int amount)
        {
            gHealth = gHealth - amount;

            if (gHealth < 0)
            {
                gHealth = 0;
            }
        }

        public void GeekSpecialAttack()
        {
            if (specialMeter == 100)
            {
                gAttack += 50;
            }
        }

    }
}