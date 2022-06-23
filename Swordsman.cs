using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentTestArsene
{
    class Swordsman : Warrior
    {
        private int poisonCount = 3;
        internal Swordsman(string _speciality = "normal", int _hitPoints = 100, int _dmg = 5, string _weapon = "handSword")
        {
            hitPoints = _hitPoints;
            dmg = _dmg;
            weapon = _weapon;
            speciality = _speciality;
        }
        internal override void Engage(Warrior _opponent)
        {
            if (speciality == "Vicious")
            {
                if (poisonCount == 1)
                {
                    dmg = dmg-20;
                    poisonCount--;
                }
                else if (poisonCount == 2)
                {
                    poisonCount--;
                }
                else if (poisonCount == 3)
                {
                    dmg = dmg + 20;
                    poisonCount--;
                }
            }
            base.Engage(_opponent);
        }
        internal new Swordsman Equip(string _newEquipment)
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
