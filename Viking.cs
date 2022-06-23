using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentTestArsene
{
    class Viking:Warrior
    {
        internal Viking(string _speciality = "normal", int _hitPoints = 120,int _dmg= 6, string _weapon = "axe")
        {
            hitPoints = _hitPoints;
            dmg = _dmg;
            weapon = _weapon;
            speciality = _speciality;
        }
        internal new Viking Equip(string _newEquipment)
        {
            switch (_newEquipment)
            {
                case "handSword":
                    weapon = "handSword";
                    dmg = 5;
                    break;
                case "axe":
                    weapon = "axe";
                    dmg = 6;
                    break;
                case "greatSword":
                    weapon = "greatSword";
                    dmg = 12;
                    break;
                default:
                    specifics.Add(_newEquipment);
                    break;
            }
            return this;
        }
    }
    
}
