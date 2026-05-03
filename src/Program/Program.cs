using System;
using Archers;
using Elfs;
using Dwarfs;
using Wizards;

//Es el Main, es el que se va a encargar de crear los objetos y probar los comportamientos de cada clase.
namespace Program
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Elf
            Elf legolas = new Elf("Legolas", 15, 5);
            legolas.IsAlive();
            Spear spear = new Spear(13);
            legolas.ChangeItem(spear);
            Helmet helmet = new Helmet(25);
            legolas.ChangeItem(helmet);


            //Dwarf
            Dwarf gimli = new Dwarf("Gimli", 20, 10);
            Axe axe = new Axe(17);
            Shield shield = new Shield(12);
            gimli.ChangeItem(axe);
            gimli.ChangeItem(shield);


            //Archer
            Archer robin = new Archer("Robin", 18, 4);
            Bow bow = new Bow(16);
            Dagger dagger = new Dagger(5);
            robin.ChangeItem(bow);
            robin.ChangeItem(dagger); 

            
            //Wizard
            Wizard snape = new Wizard("Snape", 5, 2);
            Spell spell = new Spell("Defense", 15, 5);
            SpellBook book = new SpellBook();
            book.AddSpell(spell);
            MagicStaff staff = new MagicStaff(20);
            snape.ChangeItem(staff);
            Tunic tunic = new Tunic(15);
            snape.ChangeItem(tunic);
            

            Console.WriteLine("--- ESTADO INICIAL ---");
            Console.WriteLine($"{legolas.Name} tiene {legolas.Health} de vida");
            Console.WriteLine($"{gimli.Name} tiene {gimli.Health} de vida");
            Console.WriteLine($"{robin.Name} tiene {robin.Health} de vida");
            Console.WriteLine($"{snape.Name} tiene {snape.Health} de vida\n");

            Console.WriteLine("--- SIMULACIÓN DE COMBATE ---");
            gimli.AttackOthers(snape, axe);
            snape.ReceiveAttack(axe);
            legolas.AttackOthers(gimli,spear);
            legolas.RemoveItem(spear);
            gimli.ReceiveAttack(spear);
            robin.AttackOthers(legolas,bow);
            robin.RemoveItem(bow);
            legolas.ReceiveAttack(bow);
            snape.AttackOthers(robin, staff);
            robin.ReceiveAttack(staff);

            Console.WriteLine($"{gimli.Name} ha atacado a {snape.Name}");
            Console.WriteLine($"La vida de {snape.Name} bajó a: {snape.Health} de vida");
            Console.WriteLine($"{legolas.Name} ha atacado a {gimli.Name}");
            Console.WriteLine($"Se le ha sacado un item a {legolas.Name}");
            Console.WriteLine($"La vida de {gimli.Name} bajó a: {gimli.Health} de vida");
            Console.WriteLine($"{robin.Name} ha atacado a {legolas.Name}");
            Console.WriteLine($"Se le ha sacado un item a {robin.Name}");
            Console.WriteLine($"La vida de {legolas.Name} bajó a: {legolas.Health} de vida");
            Console.WriteLine($"{snape.Name} ha atacado a {robin.Name}");
            Console.WriteLine($"La vida de {robin.Name} bajó a: {robin.Health} de vida\n");

            Console.WriteLine("--- SIMULACIÓN DE CURACIÓN ---");
            legolas.Cure();
            Console.WriteLine($"La vida de {legolas.Name} vuelve a ser: {legolas.Health} de vida");
            gimli.Cure();
            Console.WriteLine($"La vida de {gimli.Name} vuelve a ser: {gimli.Health} de vida");
            snape.Cure();
            Console.WriteLine($"La vida de {legolas.Name} vuelve a ser: {legolas.Health} de vida");
            robin.Cure();
            Console.WriteLine($"La vida de {robin.Name} vuelve a ser: {robin.Health} de vida\n");


            //Lo que va a mostrar es el resultado total del ataque
            Console.WriteLine("--- TOTAL DE VALOR DE ATAQUE ---");
            int totalAttack = robin.AttackTotal(dagger, bow);
            Console.WriteLine($"El valor de ataque total que tiene {robin.Name} es: {totalAttack}");
            int totalAttack1 = gimli.AttackTotal(axe, shield);
            Console.WriteLine($"El valor de ataque total que tiene {gimli.Name} es: {totalAttack1}");
            int totalAttack2 = legolas.AttackTotal(spear, helmet);
            Console.WriteLine($"El valor de ataque total que tiene {legolas.Name} es: {totalAttack2}");
            int totalAttack3 = snape.AttackTotal(tunic,staff);
            Console.WriteLine($"El valor de ataque total que tiene {snape.Name} es: {totalAttack3}\n");

            //Lo que va a mostrar es el resultado total de la defensa
            Console.WriteLine("--- TOTAL DE VALOR DE DEFENSA ---");
            int totalDefense = robin.DefenseTotal(dagger, bow);
            Console.WriteLine($"El valor de defensa total que tiene {robin.Name} es: {totalDefense}");
            int totalDefense1 = gimli.DefenseTotal(axe, shield);
            Console.WriteLine($"El valor de defensa total que tiene {gimli.Name} es: {totalDefense1}");
            int totalDefense2 = legolas.DefenseTotal(spear, helmet);
            Console.WriteLine($"El valor de defensa total que tiene {legolas.Name} es: {totalDefense2}");
            int totalDefense3 = snape.DefenseTotal(tunic,staff);
            Console.WriteLine($"El valor de defensa total que tiene {snape.Name} es: {totalDefense3}");
        }
    }
} 
