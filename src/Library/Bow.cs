//Es la clase experta de la información que corresponde a el arco.
//Se aplica SRP separándola de Archer, ya que si la lógica del arco viviera dentro de Archer,
//esa clase tendría más de una razón de cambio.
//De esta forma, cualquier modificación relacionada al arco se realiza únicamente acá.

namespace Archers
{
    public class Bow : IEquipmentStats
    {
        //Se inicializan aquellas responsabilidades de conocer de la clase Bow
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
        public Bow(int AttackValue)
        {
            this.AttackValue = AttackValue;
            this.DefenseValue = 0;
        }
    } 
}

