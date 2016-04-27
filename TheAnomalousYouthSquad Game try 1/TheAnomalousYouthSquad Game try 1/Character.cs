using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheAnomalousYouthSquad_Game_try_1
{
    abstract class Character
    {
        // Ryan Lowrie
        // Attributes
        int health;
        int speed;
        int defense;
        int attack;
        bool isAlive;

        // Methods that must be inherited
        public Character(int h, int s, int a, int d, bool i)
        {
            health = h;
            speed = s;
            attack = a;
            defense = d;
            isAlive = i;
        }
        public abstract void playerDead(); // Called when any characters health reaches 0, displays animation for inactive character
        public abstract int Attack(/*Enemy en*/); // Main damage dealing method, will edit values and account for missing/blocking
        public abstract void ChangeHealth(int amount);
    }
}
