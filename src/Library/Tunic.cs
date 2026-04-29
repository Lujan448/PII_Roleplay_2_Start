//Es la clase experta de la información que corresponde a la tunica
//Se aplica SRP separándola de Wizard, ya que si la lógica de la tunica viviera dentro de Wizard,
//esa clase tendría más de una razón de cambio.
//De esta forma, cualquier modificación relacionada a la tunica se realiza únicamente acá.

namespace Wizards
{
    public class Tunic : IEquipmentStats
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
        public Tunic(int DefenseValue)
        {
            this.AttackValue = 0;
            this.DefenseValue = DefenseValue;
        }
    }
}