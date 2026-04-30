//Es la clase experta de la información que corresponde a el escudo.
//Se aplica SRP separándola de Dwarf, ya que si la lógica del escudo viviera dentro de Dwarf,
//esa clase tendría más de una razón de cambio.
//De esta forma, cualquier modificación relacionada al escudo se realiza únicamente acá.
using Ucu.Poo.RolePlayGame;

namespace Dwarfs
{
public class Shield : IItems
    {
        //Se inicializan aquellas responsabilidades de conocer de la clase Shield
        //Valor de ataque y de defensa.
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

        //Ceamos al constructor 
        //En este caso como es parte de la armadura en si, su valor de ataque va a ser 0.
        public Shield(int DefenseValue)
        {
            this.AttackValue = 0;
            this.DefenseValue = DefenseValue;
        }
    }
}