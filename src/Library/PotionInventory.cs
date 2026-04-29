using System.Collections.Generic;
using Ucu.Poo.RolePlayGame;
//Es la clase experta de la información que corresponde a el inventario de pociones.
//Se aplica SRP separándola de Elf, ya que si la lógica del inventario de pociones viviera dentro de Elf,
//esa clase tendría más de una razón de cambio.
//De esta forma, cualquier modificación relacionada al inventario se realiza únicamente acá.
namespace Elfs
{
    public class PotionInventory : IInventory<Potion>
    {
        //Esta es la lista real, pero ahora es privada. 
        //Nadie de afuera puede tocarla directamente.
        private List<Potion> potions = new List<Potion>();

        //Método para agregar una poción
        public void AddMagic(Potion potion)
        {
            potions.Add(potion);
        }

        //Método para saber si tenemos una poción específica
        public bool HasMagic(Potion potion)
        {
            return potions.Contains(potion);
        }

        //Método para quitar una poción
        public void RemoveMagic(Potion potion)
        {
            potions.Remove(potion);
        }
    }
}