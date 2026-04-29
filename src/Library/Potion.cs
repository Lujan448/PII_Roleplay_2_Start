//Es la clase experta de la información que corresponde a las pociones
//Se aplica SRP separándola de Elf, ya que si la lógica de las pociones viviera dentro de Elf,
//esa clase tendría más de una razón de cambio.
//De esta forma, cualquier modificación relacionada a las pociones se realiza únicamente acá.
using Ucu.Poo.RolePlayGame;

namespace Elfs
{
    public class Potion : IPotion
    {
        //Se inicializan aquellas responsabilidades de conocer de la clase Potion
        //Valor de nombre, poder de curación, ataque y de defensa.
        private int attackValue;
        public int AttackValue 
        {
            get {return attackValue; }
            set {attackValue = value;} 
        }

        private int defenseValue;
        public int DefenseValue 
        {
            get {return defenseValue; } set {defenseValue = value; } 
        }

        private string name;
        public string Name 
        { 
            get {return name; } set {name = value;}
        }

        private int healingPower;
        public int HealingPower
        {
            get {return healingPower; } set {healingPower = value;}
        }

        //Ceamos al constructor 
        //En este caso como no es ni un arma ni una armadura, sus valores de defensa y ataque van a ser 0.
        public Potion(string name, int healingPower)
        {
            this.AttackValue = 0;
            this.DefenseValue = 0;
            this.Name = name;
            this.HealingPower = healingPower;
        }
    }
}