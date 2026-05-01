
using Library;

//Es la clase Experta, ya que se encarga de conocer todas las responsabilidades que tiene Dwarf 
//y los comportamientos que va a realizar son a partir del conocimiento de cada una de estas responsabilidades.
namespace Ucu.Poo.RolePlayGame
{
    public class Dwarf : ICharacters
    {
        //Iniciamos cada uno de las responsabiliades de conocer a la clase Dwarf.
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

        //método constructor.
        public Dwarf(string name, int attackValue, int defenseValue, int health = 100)
        {
            this.Name = name;
            this.AttackValue = attackValue;
            this.DefenseValue = defenseValue;
            this.maxHealth = health;
            this.Health = health;
        }

        //Nos pareció bueno verificar si el personaje estaba vivo, en caso de que lo este devuelve un valor booleano
        public bool IsAlive()
        {
            return this.Health > 0;
        }
    
        public void ReceiveAttack(IItems attackValue)
        {
            int damage = attackValue.AttackValue - this.DefenseValue;
            if (damage > 0) 
            {
                this.Health -= damage;
            }
        }

        //Elegimos que el que se encargue de atacar sea el enano, ya que por letra se entendia
        //que era el más preparado para pelear.
        //Hicimos un método especifico para que ataque un elfos, ya que no nos dejaba que el elfo curara
        //a otros personajes por fuera de los elfos. La unica forma que dejaba es que agregaramos el método
        //HealCompleatly(), perteneciente a los elfos, a cada una de las clases, sin embargo, por letra nosotros entendimos
        //que ese método era perteneciente a la clase Elf únicamente.

        public void AttackOthers(ICharacters characters, IItems item)
        {
            characters.ReceiveAttack(item);
        }

        public void Cure()
        {
            this.Health = maxHealth;
        }

        //En los siguientes dos métodos lo que se hace es poder cambiar el arma que tienen por uno nuevo
        //En este caso lo pusimos en esta clase porque nos parecia que era la Experta de la información para poder realizar
        //las responsabilidades correspondientes y además porque por más que las clase Axe o Shield de manera individual pueden 
        //cumplir con estas responsabilidades, logicamente no tiene sentido, no se cambia un item solo,
        //es el personaje el que cambia el item por otro.
        public void ChangeItem(IItems item)
        {
            this.AttackValue = item.AttackValue;  
        }

        //En los siguientes dos métodos lo que se hace es poder remover el arma que tiene
        //En este caso lo pusimos en esta clase porque nos parecia que era la Experta de la información para poder realizar
        //las responsabilidades correspondientes y además porque por más que las clase Axe o Shield de manera individual pueden 
        //cumplir con estas responsabilidades, logicamente no tiene sentido, no se saca un item solo,
        //es el personaje el que saca el item.
        public void RemoveItem(IItems item)
        {
            this.AttackValue = 0;
            this.DefenseValue = 0;
        }

        //Es el encargado de calcular el ataque total del personaje.
        public int AttackTotal(IItems item1, IItems item2)
        {
            int totalAttack = this.AttackValue + item1.AttackValue + item2.AttackValue;
            return totalAttack;
        }

        //Se encarga de calcular la defensa total del personaje
        public int DefenseTotal(IItems item1, IItems item2)
        {
            int totalDefense = this.defenseValue + item1.DefenseValue + item2.DefenseValue;
            return totalDefense;
        }
    }
}