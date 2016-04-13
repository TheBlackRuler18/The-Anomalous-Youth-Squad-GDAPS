﻿using System;
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
        {
            jHealth = h;
            jSpeed = s;
            jAttack = a;
            jDefense = d;
            isAlive = true;
        }

        // attack method
        public override int Attack(/*Enemy target*/)
        {
            int attackDamage;
            Random rng = new Random();
            int chance = rng.Next(101);

            if (chance >= 0 && chance < 26)
            {
                attackDamage = 0;
            }
            else if (chance >= 26 && chance < 46)
            {
                attackDamage = (int)(jAttack / 5.0);
            }
            else if (chance >= 46 && chance < 66)
            {
                attackDamage = (int)(jAttack / 2.5);
            }
            else if (chance >= 66 && chance < 86)
            {
                attackDamage = (int)(jAttack / 1.25);
            }
            else
            {
                attackDamage = jAttack;
            }

            return attackDamage;
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
