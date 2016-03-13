using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheAnomalousYouthSquad_Game_try_1
{
    class Geek : Character
    {
        private int gHealth;
        private int gSpeed;
        private int gDefense;
        private int gAttack;
        private bool isAlive;

        // Constructor
        public Geek(int h, int s, int a, int d, bool i) : base(h, s, a, d, i) { }

        // Attack method
        public override void Attack(Enemy target)
        {

        }
        // check if player is dead
        public override void playerDead()
        {
            if (isAlive == true) isAlive = false;
        }
    }
}
