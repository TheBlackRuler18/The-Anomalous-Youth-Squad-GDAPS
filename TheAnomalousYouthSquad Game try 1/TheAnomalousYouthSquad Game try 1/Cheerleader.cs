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
    class Cheerleader : Character
    {
        // attributes
        private int cHealth;
        private int cAttack;
        private int cSpeed;
        private int cDefense;
        private bool isAlive;
        private Rectangle cRect;

        public int CHealth { get { return cHealth; } set { cHealth = value; } }
        public int CAttack { get { return cAttack; } }
        public int CDefense { get { return cDefense; } }
        public int CSpeed { get { return cSpeed; } }
        public bool IsAlive { get { return isAlive; } set { isAlive = value; } }

        // constructor
        public Cheerleader(int h, int s, int a, int d, bool i) : base(h, s, a, d, i)
        {
            cHealth = h;
            cSpeed = s;
            cAttack = a;
            cDefense = d;
            isAlive = true;
        }

        // attack method
        public override int Attack(/*Enemy target*/)
        {
            int attackDamage;
            Random rng = new Random();
            int chance = rng.Next(101);

            if(chance >= 0 && chance < 26)
            {
                attackDamage = 0;
            }
            else if(chance >= 26 && chance < 46)
            {
                attackDamage = (int)(cAttack / 5.0);
            }
            else if(chance >= 46 && chance < 66)
            {
                attackDamage = (int)(cAttack / 2.5);
            }
            else if(chance >= 66 && chance < 86)
            {
                attackDamage = (int)(cAttack / 1.25);
            }
            else
            {
                attackDamage = cAttack;
            }

            return attackDamage;
        }

        public override void Draw(SpriteBatch sbatch)
        {
            
        }
        /* public override void ChangeHealth(int amount)
        {
            cHealth = cHealth - amount;

            if(cHealth < 0)
            {
                cHealth = 0;
            }
        } */
    }
}
