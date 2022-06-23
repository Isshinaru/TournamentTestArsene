using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentTestArsene
{
    class Swordsman:Warrior
    {
        private int poisonCount=3;
        private int baseDmg = 0;
        public Swordsman(string _speciality = "normal", int _hitPoints = 100, int _dmg = 5, string _weapon = "handSword")
        {
            hitPoints = _hitPoints;
            dmg = _dmg;
            weapon = _weapon;
            speciality = _speciality;
        }
        public override void Engage(Warrior _opponent)
        {
            if (speciality == "Vicious") {
                if (poisonCount == 1)
                {
                    dmg = baseDmg;
                    poisonCount--;
                }
                else if (poisonCount == 2)
                {
                    poisonCount--;
                }
                else if (poisonCount == 3)
                {
                    baseDmg = dmg;
                    dmg = dmg + 20;
                    poisonCount--;
                }
            }
            base.Engage(_opponent);
        }
    }
}
