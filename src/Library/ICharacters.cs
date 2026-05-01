
using Ucu.Poo.RolePlayGame;

namespace Library
{
    public interface ICharacters
    {
        string Name { get;}
        int Health { get;}
        int AttackValue {get;}
        int DefenseValue {get;}

        bool IsAlive();
        void ReceiveAttack(IItems attackValue);
        int AttackTotal(IItems item1, IItems item2);
        void AttackOthers(ICharacters target, IItems item);
        void Cure();
        void RemoveItem(IItems item);
        void ChangeItem(IItems item);
        int DefenseTotal(IItems item1, IItems item2);
    } 
}

