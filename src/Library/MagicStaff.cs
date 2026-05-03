//Es la clase experta de la información que corresponde a el bastón mágico
//Se aplica SRP separándola de Wizard, ya que si la lógica del bastón mágico viviera dentro de Wizard,
//esa clase tendría más de una razón de cambio.
//De esta forma, cualquier modificación relacionada al bastón se realiza únicamente acá.
using Ucu.Poo.RolePlayGame;

namespace Wizards
{
    public class MagicStaff : IItems
    {
        //Se inicializan aquellas responsabilidades de conocer de la clase MagicStaff
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

        //Creamos al constructor 
        //En este caso como es un arma, su valor de defensa va a ser 0.
        public MagicStaff(int AttackValue)
        {
            this.AttackValue = AttackValue;
            this.DefenseValue = 0;
        }
    }
}