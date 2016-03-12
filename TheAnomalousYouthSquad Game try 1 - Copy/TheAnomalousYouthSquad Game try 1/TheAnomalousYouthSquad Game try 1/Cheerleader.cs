using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheAnomalousYouthSquad_Game_try_1
{
    // Cheerleader player class
    class Cheerleader : Character
    {
        // attributes
        private int cHealth;
        private int cAttack;
        private int cSpeed;
        private int cDefense;
        private bool isAlive;

        // constructor
        public Cheerleader(int h, int s, int a, int d, bool i) : base(h, s, a, d, i) { }

        public override void playerDead()
        {
            if (isAlive == true) isAlive = false;
        }

        // attack method
        public override void Attack(Enemy target)
        {

        }
    }
}
