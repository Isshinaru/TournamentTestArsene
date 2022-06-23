using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentTestArsene
{
    class Highlander:Warrior
    {
        private int missCount = 0;
        public Highlander(string _speciality = "normal",int _hitPoints = 150, int _dmg = 12, string _weapon = "greatSword")
        {
            hitPoints = _hitPoints;
            dmg = _dmg;
            weapon = _weapon;
            speciality = _speciality;
        }
        public override void Engage(Warrior _opponent)
        {
            if (hitPoints <= 45 && speciality == "Veteran"&&!specifics.Contains("berserker"))
            {
                dmg = 2 * dmg;
                specifics.Add("berserker");
            }
            missCount++;
            if (missCount == 3)
            {
                missCount = 0;
                _opponent.Engage(this);
            }
            else
            {
                base.Engage(_opponent);
            }
            
        }
    }
}
