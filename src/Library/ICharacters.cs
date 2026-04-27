namespace Library;

public interface ICharacters
{
    string Name { get;}
    int health { get;}
    int AttackValue {get;}
    int DefenseValue {get;}
    int maxHealth {get;}

    public bool IsAlive()
    {
        if (this.Health < 0)        //En caso de que la vida sea negativa lo que hago es convertirla en 0;
        {                           //ya que nadie tiene vida en negativo.
            this.Health = 0;
        }
        return this.Health > 0; 
    }
    public void ReciveAttack()
    {
        int damage = AttackValue - this.DefenseValue;
        if (damage > 0) 
        {
            this.Health -= damage;
        }
        else if (this.Health < 0) 
        {
            this.Health = 0;
        }
    }

    public void AttackTotal ()
    {
        int totalSpellAttack = book.SpellList.Sum(spell => spell.AttackValue);
        int totalAttack = this.AttackValue + staff.AttackValue + totalSpellAttack;
        return totalAttack;
    }
        
    public void AttackOthers(Wizard target, SpellBook book, Spell spell)
    {
        if(book.HasSpell(spell))
        {
            target.ReceiveAttack(spell.AttackValue);
        } 
    }
    public void ThrowCure(Potion potion, Archer target, PotionInventory inventory)
    {
        if (inventory.HasMagic(potion))
        {
            target.HealCompletely();
            inventory.RemoveMagic(potion);
        }
    }
    public void RemoveItem(Dagger dagger)
        {
            this.AttackValue = 0;
            this.DefenseValue = 0;
        }
    public void ChangeItem(Dagger newDagger)
        {
            this.AttackValue = newDagger.AttackValue;
        }
    public int DefenseTotal(SpellBook book, Tunic tunic)
    {
        int totalSpellDefense = book.TotalSpellDefense();
        int totalDefense = this.DefenseValue + tunic.DefenseValue + totalSpellDefense;
        return totalDefense;
    }
}


