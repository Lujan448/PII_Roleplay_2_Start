//Es la clase experta de la información que corresponde a el hacha
//Se aplica SRP separándola de Dwarf, ya que si la lógica del hacha viviera dentro de Dwarf,
//esa clase tendría más de una razón de cambio.
//De esta forma, cualquier modificación relacionada al hacha se realiza únicamente acá.
using Ucu.Poo.RolePlayGame;

namespace Dwarfs

{
    public class Axe : IItems
    {
        //Se inicializan aquellas responsabilidades de conocer de la clase Axe
        //Valor de ataque y de defensa.
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

        //Ceamos al constructor 
        //En este caso como es un arma, su valor de defensa va a ser 0.
        public Axe(int AttackValue)
        {
            this.AttackValue = AttackValue;
            this.DefenseValue = 0;
        }
    }      
}
