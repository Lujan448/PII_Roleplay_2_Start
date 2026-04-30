//Es la clase experta de la información que corresponde a la lanza
//Se aplica SRP separándola de Elf, ya que si la lógica de la lanza viviera dentro de Elf,
//esa clase tendría más de una razón de cambio.
//De esta forma, cualquier modificación relacionada a la lanza se realiza únicamente acá.
using Ucu.Poo.RolePlayGame;

namespace Elfs
{
    public class Spear : IItems
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
        public Spear(int attackValue)
        {
            this.AttackValue = attackValue;
            this.DefenseValue = 0;
        }
    }     
}