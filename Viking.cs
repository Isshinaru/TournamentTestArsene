using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentTestArsene
{
    class Viking:Warrior
    {
        public Viking(string _speciality = "normal", int _hitPoints = 120,int _dmg= 6, string _weapon = "axe")
        {
            hitPoints = _hitPoints;
            dmg = _dmg;
            weapon = _weapon;
            speciality = _speciality;
        }
    }
}
