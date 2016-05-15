using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheAnomalousYouthSquad_Game_try_1
{
    class Jock : Character
    {
        private int jHealth;
        private int jMaxHealth;
        private int jAttack;
        private int jDefense;
        private int jSpeed;
        private bool isAlive;
        private int specialMeter;
        private int specialMax;

        public int JHealth { get { return jHealth; } set { jHealth = value; } }
        public int JMaxHealth { get { return jMaxHealth; } }
        public int JAttack { get { return jAttack; } }
        public int JDefense { get { return jDefense; } }
        public int JSpeed { get { return jSpeed; } }
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

        public Jock(int h, int s, int a, int d, bool i) : base(h, s, a, d, i)
        {
            jHealth = h;
            jMaxHealth = jHealth;
            jAttack = a;
            jSpeed = s;
            jDefense = d;
            isAlive = true;
            specialMeter = 0;
            specialMax = 100;
            if (specialMeter > specialMax)
            {
                specialMeter = 100;
            }
        }

        // called if player is dead
        public override void playerDead()
        {
            if (isAlive == true) isAlive = false;
        }

        // attack method
        public override int Attack(/*Enemy target*/)
        {
            jAttack = 0;
            Random rng = new Random();
            int chance = rng.Next(101);

            if (chance >= 0 && chance < 25)
            {
                jAttack = 50;
            }
            else if (chance >= 26 && chance < 45)
            {
                jAttack = 50;
            }
            else if (chance >= 46 && chance < 65)
            {
                jAttack = 50;
            }
            else if (chance >= 66 && chance < 85)
            {
                jAttack = 50;
            }
            else
            {
                jAttack = 50;
            }

            return jAttack;
        }

        public override void ChangeHealth(int amount)
        {
            jHealth = jHealth - amount;

            if (jHealth < 0)
            {
                jHealth = 0;
            }
        }

        public void JockSpecialAttack()
        {
            Cheerleader cheer = new Cheerleader(100, 10, 10, 10, true);
            Geek nerd = new Geek(200, 20, 20, 20, true);

            if (specialMeter == 100)
            {
                nerd.GHealth += 50;
                cheer.CHealth += 50;
                jHealth += 50;

                if (nerd.GHealth > 200)
                {
                    nerd.GHealth = 200;
                }
                if (cheer.CHealth > 100)
                {
                    cheer.CHealth = 100;
                }
            }
        }
    }
}

