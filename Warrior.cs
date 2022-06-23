using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentTestArsene
{
    class Warrior
    {
        protected string speciality = "normal";
        protected int hitPoints = 100;
        protected int dmg = 5;
        protected string weapon = "handSword";
        protected List<String> specifics = new List<string>();
        protected int bucklerHP = 3;
        protected bool isBucklerActive = true;
        protected int missCount = 0;
        internal Warrior(string _speciality = "normal", int _hitPoints = 100, int _dmg = 5, string _weapon= "handSword")
        {
            hitPoints = _hitPoints;
            dmg = _dmg;
            weapon = _weapon;
        }
        virtual internal void Engage(Warrior _opponent)
        {
            if (weapon == "greatSword")
            {
                missCount++;
                if (missCount == 3)
                {
                    missCount = 0;
                    _opponent.Engage(this);
                    return;
                }
            }
            int _finalBlow = dmg;
            if (specifics.Contains("armor"))
            {
                _finalBlow = (int)MathF.Max(0, _finalBlow - 1);
            }
            if (_finalBlow > 0)
            {
                _opponent.ReceiveDamage(_finalBlow, this);
            }
            else
            {
                _opponent.Engage(this);
            }
        }
        virtual protected void ReceiveDamage(int _opponentsBlow, Warrior _opponent)
        {
            int _finalDmg = _opponentsBlow;
            //damage mitigation
                //Buckler
            if (specifics.Contains("buckler"))
            {
                if (isBucklerActive)
                {
                    _finalDmg = 0;
                    isBucklerActive = false;
                    if (_opponent.weapon == "axe")
                    {
                        bucklerHP--;
                        if (bucklerHP == 0)
                        {
                            specifics.Remove("buckler");
                        }
                    }
                }
                else
                {
                    isBucklerActive = true;
                }
            }
            if (specifics.Contains("armor"))//Mitigation armor
            {
                _finalDmg = (int)MathF.Max(0, _finalDmg - 3);
            }
            // actual damages received
            hitPoints = (int)MathF.Max(0,hitPoints - _finalDmg);
            if (hitPoints > 0)
            {
                Engage(_opponent);
            }
        }
        internal int HitPoints()
        {
            return hitPoints;
        }
        internal virtual Warrior Equip(string _newEquipment)
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
                    if(!specifics.Contains(_newEquipment)) specifics.Add(_newEquipment);
                    break;
            }
            return this;
        }
        internal bool IsEquipped(string _equipment)
        {
            return specifics.Contains(_equipment);
        }
    }
}
