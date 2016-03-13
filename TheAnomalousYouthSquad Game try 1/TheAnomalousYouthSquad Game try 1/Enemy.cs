using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheAnomalousYouthSquad_Game_try_1
{
    class Enemy : Character
    {
        private int eHealth;
        private int eAttack;
        private int eDefense;
        private int eSpeed;
        private bool isAlive;

        public Enemy(int h, int s, int a, int d, bool i) : base(h, s, a, d, i) { }

        // check if enemy is dead
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
