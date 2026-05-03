//Es la clase experta de la información que corresponde a los hechizos
//Se aplica SRP separándola de Wizard, ya que si la lógica de los hechizos viviera dentro de Wizard,
//esa clase tendría más de una razón de cambio.
//De esta forma, cualquier modificación relacionada a los hechizos se realiza únicamente acá.
using Ucu.Poo.RolePlayGame;

namespace Wizards
{
    public class Spell : IItems
    {
        //Se inicializan aquellas responsabilidades de conocer de la clase Spells
        //Valor de nombre, ataque y de defensa.
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

        //Creamos al constructor 
        public Spell(string name, int defenseValue, int attackValue)
        {
            this.AttackValue = attackValue;
            this.DefenseValue = defenseValue;
            this.Name = name;
        }
    }
}