using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheAnomalousYouthSquad_Game_try_1
{
    class Jock : Character
    {
        private int jHealth;
        private int jAttack;
        private int jDefense;
        private int jSpeed;
        private bool isAlive;

        public Jock(int h, int s, int a, int d, bool i) : base(h, s, a, d, i) { }

        // called if player is dead
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
