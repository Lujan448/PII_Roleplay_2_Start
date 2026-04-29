using System;
using System.Data;
using Library;

namespace Ucu.Poo.RolePlayGame
{
    public interface IPotion
    {
        string Name {get;}
        int AttackValue {get;}
        int DefenseValue {get;}
        int HealingPower {get;}
    }

}