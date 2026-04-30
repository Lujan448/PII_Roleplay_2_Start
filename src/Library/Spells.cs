//Es la clase experta de la información que corresponde a los hechizos
//Se aplica SRP separándola de Wizard, ya que si la lógica de los hechizos viviera dentro de Wizard,
//esa clase tendría más de una razón de cambio.
//De esta forma, cualquier modificación relacionada a los hechizos se realiza únicamente acá.

using Ucu.Poo.RolePlayGame;

namespace Spells
{
    public class Spell : IItems
    {
        //Se inicializan aquellas responsabilidades de conocer de la clase Axe
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

        //Ceamos al constructor 
        //En este caso no en ni un arma ni una armadura, sin embargo el valor de defensa es fundamental para
        // el progreso.
        // En el caso del valor de ataque va a ser 0.
        public Spell(string Name, int DefenseValue)
        {
            this.AttackValue = 0;
            this.DefenseValue = DefenseValue;
            this.Name = Name;
        }
    }
}