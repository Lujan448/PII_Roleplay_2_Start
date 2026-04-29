using System.Collections.Generic;
using Spells;
using Ucu.Poo.RolePlayGame;

//Es la clase experta de la información que corresponde a el libro de hechizos.
//Se aplica SRP separándola de Wizard, ya que si la lógica del libro de hechizos viviera dentro de Wizard,
//esa clase tendría más de una razón de cambio.
//De esta forma, cualquier modificación relacionada al libro se realiza únicamente acá.
namespace Wizards
{
    public class SpellBook : IInventory<Spell>
    {
        //Esta es la lista real, pero ahora es privada. 
        //Nadie de afuera puede tocarla directamente.
        private List<Spell> spellList = new List<Spell>();

        //Método para agregar un hechizo
        public void AddMagic(Spell spell)
        {
            this.spellList.Add(spell);
        }

        //Método para ver si hay un hechizo
        public bool HasMagic(Spell spell)
        {
            return spellList.Contains(spell);
        }

        //Método para quitar un hexhizo
        public void RemoveMagic(Spell spell)
        {
            spellList.Remove(spell);
        }

        //Método para calcular el valor total del hechizo de defensa.
        //Lo colocamos aca porque creemos que para realizarlo se tiene aquella información que
        //es necesaria, porque nosotros interactuamos en esta clase directamente con la clase spell, no necesitamos nada más.
        public int TotalSpellDefense()  //Método propio de la clase SpellBook
        {
            int total = 0;
            foreach (Spell spell in spellList)
            {
                total += spell.DefenseValue;
            }
            return total;
        }
    }
}