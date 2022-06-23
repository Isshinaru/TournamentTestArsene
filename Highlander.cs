using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentTestArsene
{
    class Highlander:Warrior
    {
        internal Highlander(string _speciality = "normal",int _hitPoints = 150, int _dmg = 12, string _weapon = "greatSword")
        {
            hitPoints = _hitPoints;
            dmg = _dmg;
            weapon = _weapon;
            speciality = _speciality;
        }
        internal override void Engage(Warrior _opponent)
        {
            if (hitPoints <= 45 && speciality == "Veteran"&&!specifics.Contains("berserker"))
            {
                dmg = 2 * dmg;
                specifics.Add("berserker");
            }
            base.Engage(_opponent);
        }
        internal new Highlander Equip(string _newEquipment)
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
