using Library;
using Ucu.Poo.RolePlayGame;

//Es la clase Experta, ya que se encarga de conocer todas las responsabilidades que tiene Wizard
//y los comportamientos que va a realizar son a partir del conocimiento de cada una de estas responsabilidades.
namespace Wizards
{
    public class Wizard : ICharacters
    {
        //Iniciamos cada uno de las responsabiliades de conocer a la clase Wizard.
        //Su nombre, valor de ataque, de defensa y su vida.
        private string name;
        public string Name 
        { 
            get {return name; } set {name = value; } 
        }

        private int baseAttackValue;
        private int attackValue;
        public int AttackValue 
        { 
            get {return attackValue; } set {attackValue = value;} 
        }

        private int baseDefenseValue;
        private int defenseValue;
        public int DefenseValue 
        { 
            get {return defenseValue; } set { defenseValue = value;}
        }

        //En este caso agregamos un máximo de vida ya que nosotros entendimos por la letra de que debe existir un limite
        //en la vida, más que nada cuando se aplican en algún punto las curaciones, no podes tener más de 100
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

        //método constructor.
        public Wizard(string name, int attackValue, int defenseValue, int health = 100)
        {
            this.Name = name;
            this.baseAttackValue = attackValue;
            this.baseDefenseValue = defenseValue;
            this.maxHealth = health;
            this.Health = health;
        }

        //Nos pareció bueno verificar si el personaje estaba vivo, en caso de que lo este devuelve un valor booleano.
        public bool IsAlive()
        {
            return this.Health > 0;
        }
    
        //Este método lo que va a realizar es que este personaje puede recibir ataque de otro.
        public void ReceiveAttack(IItems attackValue)
        {
            int damage = attackValue.AttackValue - this.baseDefenseValue;
            if (damage > 0) 
            {
                this.Health -= damage;
            }
        }

        //Es el método que se encarga de atacar al resto de personajes
        public void AttackOthers(ICharacters characters, IItems item)
        {
            characters.ReceiveAttack(item);
        }

        //cambiamos la forma en la que curabamos a los personajes, ya que creemos que habíamos complejizado completamente
        //la letra y perfectamente la podemos hacer mucho más sencilla, por lo tanto aplicamos lo siguiente
        public void Cure()
        {
            this.Health = maxHealth;
        }

        //En el siguiente método lo que se hace es poder cambiar el arma que tienen por uno nuevo
        //En este caso lo pusimos en esta clase porque nos parecia que era la Experta de la información para poder realizar
        //las responsabilidades correspondientes y además porque por más que las clase MagicStaff o Tunic de manera individual pueden 
        //cumplir con estas responsabilidades, pero logicamente no tiene sentido, no se cambia un item solo,
        //es el personaje el que cambia el item por otro.
        public void ChangeItem(IItems newItem)
        {
            this.AttackValue = newItem.AttackValue;
            this.DefenseValue = newItem.DefenseValue;
        }

        //En el siguiente método lo que se hace es poder remover el arma que tiene
        //En este caso lo pusimos en esta clase porque nos parecia que era la Experta de la información para poder realizar
        //las responsabilidades correspondientes y además porque por más que las clase MagicStaff o Tunic de manera individual pueden 
        //cumplir con estas responsabilidades, pero logicamente no tiene sentido, no se saca un item solo,
        //es el personaje el que saca el item.
        public void RemoveItem(IItems item)
        {
            this.AttackValue = 0;
            this.DefenseValue = 0;
        }

        //Se encarga de calcular el total de ataque del wizard
        public int AttackTotal(IItems item1, IItems item2)
        {
            int totalAttack = this.baseAttackValue + item1.AttackValue + item2.AttackValue;
            return totalAttack;
        }


        //Es el encargado de calcular el total de valor de defensa que tiene el personaje.
        public int DefenseTotal(IItems item1, IItems item2)
        {
            int totalDefense = this.baseDefenseValue + item1.DefenseValue + item2.DefenseValue;
            return totalDefense;
        }
    }
}