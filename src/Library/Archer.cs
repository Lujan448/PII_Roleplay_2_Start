//Es la clase Experta, ya que se encarga de conocer todas las responsabilidades que tiene Archer 
//y los comportamientos que va a realizar son a partir del conocimiento de cada una de estas responsabilidades.
using Elfs;

namespace Archers
{
    public class Archer
    {
        //Iniciamos cada uno de las responsabiliades de conocer a la clase Archer.
        //Su nombre, valor de ataque, de defensa y su vida.
        private string name;
        public string Name 
        { 
            get {return name; } set {name = value; } 
        }

        private int attackValue;
        public int AttackValue 
        { 
            get {return attackValue; } set {attackValue = value;} 
        }

        private int defenseValue;
        public int DefenseValue 
        { 
            get {return defenseValue; } set { defenseValue = value;}
        }

        //En este caso agregamos un máximo de vida ya que nosotros entendimos por la letra de que debe existir un limite
        //en la vida, más que nada cuando se aplican en algún punto las curaciones, no podes tener más de 100.
        private int maxHealth;
        private int health;
        public int Health 
        { 
            get {return health; } 
            set 
            {
                if (value < 0)
                {
                    health = 0;
                }
                else if (value > maxHealth)
                {
                    health = maxHealth;
                }
                else
                {
                    health = value;
                }
            } 
        }

        //Agregamos el constructor.
        public Archer(string name, int attackValue, int defenseValue, int health = 100)
        {
            this.Name = name;
            this.AttackValue = attackValue;
            this.DefenseValue = defenseValue;
            this.maxHealth = health;
            this.Health = health;
        }

        //Nos pareció bueno verificar si el personaje estaba vivo, en caso de que lo este devuelve un valor booleano.
        public bool IsAlive()
        {
            return this.Health > 0;
        }

        //Este método lo que va a realizar es que este personaje puede recibir ataque de otro.
        public void ReceiveAttack(int attackValue)
        {
            int damage = attackValue - this.DefenseValue;
            if (damage > 0) 
            {
                this.Health -= damage;
            }
        }

        public void AttackOthers(Elf target, Axe axe)
        {
            target.ReceiveAttack(axe.AttackValue);
        }

        //En los siguientes dos métodos lo que se hace es poder cambiar el arma que tienen por uno nuevo
        //En este caso lo pusimos en esta clase porque nos parecia que era la Experta de la información para poder realizar
        //las responsabilidades correspondientes y además porque por más que las clase Bow o Dagger de manera individual pueden 
        //cumplir con estas responsabilidades, pero logicamente no tiene sentido, no se cambia un item solo,
        //es el personaje el que cambia el item por otro.
        public void ChangeItem(Bow newBow)
        {
            this.AttackValue = newBow.AttackValue;  
        }

        public void ChangeItem(Dagger newDagger)
        {
            this.AttackValue = newDagger.AttackValue;
        }

        //En los siguientes dos métodos lo que se hace es poder remover el arma que tiene
        //En este caso lo pusimos en esta clase porque nos parecia que era la Experta de la información para poder realizar
        //las responsabilidades correspondientes y además porque por más que las clase Bow o Dagger de manera individual pueden 
        //cumplir con estas responsabilidades, pero logicamente no tiene sentido, no se saca un item solo,
        //es el personaje el que saca el item.
        public void RemoveItem(Bow bow)
        {
            this.AttackValue = 0;
            this.DefenseValue = 0;
        }
        public void RemoveItem(Dagger dagger)
        {
            this.AttackValue = 0;
            this.DefenseValue = 0;
        }

        //Es el encargado de calcular el ataque total.
        public int AttackTotal(Dagger dagger, Bow bow)
        {
            int totalAttack = this.AttackValue + dagger.AttackValue + bow.AttackValue;
            return totalAttack;
        }

        public void HealCompletely() => this.Health = maxHealth;

        //Es el encargado de curar a alguien y que le quede su vida inicial
        public void ThrowCure(Potion potion, Archer target, PotionInventory inventory)
        {
            if (inventory.HasMagic(potion))
            {
                target.HealCompletely();
                inventory.RemoveMagic(potion);
            }
        }
    }  
}
