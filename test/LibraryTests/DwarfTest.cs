using NUnit.Framework;
using Library;
using Dwarfs;
using Elfs;

namespace DwarfsTests
{
    [TestFixture]
    public class DwarfTest
    {   
        //Es el encargado de probar si el enano esta vivo, si lo esta devuelve true
        [Test]
        public void IsAlive_WhenHealthIsPositive_ReturnsTrue()
        {
            Dwarf dwarf = new Dwarf("Nombre", 20, 10, 100);
            Assert.That(dwarf.IsAlive(), Is.True);
        }

        //Es el encargado de probar si el enano esta vivo, si no lo esta devuelve false
        [Test]
        public void IsAlive_WhenHealthIsZero_ReturnsFalse()
        {
            Dwarf dwarf = new Dwarf("Nombre", 20, 10, 0);
            Assert.That(dwarf.IsAlive(), Is.False);
        }

        //Es el encargado de verificar si es correcto que al recibir ataques cuando daño excede a la defensa, se decrece asi su vida
        [Test]
        public void ReceiveAttack_WhenDamageExceedsDefense_DecreasesHealth()
        {
            Dwarf dwarf = new Dwarf("Nombre", 20, 10, 100);
            Axe attacker = new Axe(30); 
            dwarf.ReceiveAttack(attacker);
            Assert.That(dwarf.Health, Is.EqualTo(80));
        }

        //Es el encargado de verificar si es incorrecto, ya que el daño es menor que la defensa no le va a hacer nada.
        [Test]
        public void ReceiveAttack_WhenDamageLessThanDefense_HealthUnchanged()
        {
            Dwarf dwarf = new Dwarf("Nombre", 20, 10, 100);
            Axe attacker = new Axe(5); 
            dwarf.ReceiveAttack(attacker);
            Assert.That(dwarf.Health, Is.EqualTo(100));  //Esto pasa cuando tenes una cantidad de ataque menor o igual
                                                         //a la defensa, entonces simplemente queda la vida original o la que tenía hasta ese momento.
        }

        //Esto verifica que cuando un item esta equipado el ataque sale bien y la persona afectada se le disminuye la vida
        [Test]
        public void AttackOthers_WhenItemIsEquipped_DecreasesElfHealth()
        {
            Dwarf dwarf = new Dwarf("Nombre", 30, 5, 100);
            Elf elf = new Elf("Nombre", 20, 10, 100);
            Axe axe = new Axe(50);
            dwarf.AttackOthers(elf, axe);
            Assert.That(elf.Health, Is.EqualTo(95));
        }

        //Verifica que Cure restaura la vida al máximo
        [Test]
        public void Cure_WhenCalled_RestoresHealthToMax()
        {
            Dwarf dwarf = new Dwarf("Nombre", 20, 10, 100);
            Axe attacker = new Axe(50); 
            dwarf.ReceiveAttack(attacker);
            Assert.That(dwarf.Health, Is.EqualTo(60)); //verificamos que recibió daño
 
            dwarf.Cure();
            Assert.That(dwarf.Health, Is.EqualTo(100)); //vuelve al máximo
        }
 
        //Verifica que Cure no supera el máximo de vida
        [Test]
        public void Cure_WhenCalledAtFullHealth_DoesNotExceedMaxHealth()
        {
            Dwarf dwarf = new Dwarf("Nombre", 20, 10, 100);
            dwarf.Cure();                                       //curar estando lleno no debe cambiar nada
            Assert.That(dwarf.Health, Is.EqualTo(100));
        }

        //Verifica si se cambia correctamente el hacha
        [Test]
        public void ChangeItem_WhenNewAxeEquipped_UpdatesAttackValue()
        {
            Axe newAxe = new Axe(10);
            Dwarf dwarf = new Dwarf("Nombre", 20, 10, 100);
            dwarf.ChangeItem(newAxe);
            Assert.That(dwarf.AttackValue, Is.EqualTo(10));
        }

        //Verifica si se cambia correctamente el escudo
        [Test]
        public void ChangeItem_WhenNewShieldEquipped_UpdatesAttackValue()
        {
            Shield newShield = new Shield(10);
            Dwarf dwarf = new Dwarf("Nombre", 20, 10, 100);
            dwarf.ChangeItem(newShield);
            Assert.That(dwarf.AttackValue, Is.EqualTo(10));
        }

        //Verifica si el ataque total retorna la suma correcta
        [Test]
        public void AttackTotal_WithAxeAndShield_ReturnsSumCorrectly()
        {
            Axe axe = new Axe(15);
            Shield shield = new Shield(0);
            Dwarf dwarf = new Dwarf("Nombre", 20, 10, 100);
            int result = dwarf.AttackTotal(axe, shield);
            Assert.That(result, Is.EqualTo(40));
        }

        //Verifica en caso de que la suma no retorne la suma correcta
        [Test]
        public void AttackTotal_WithAxeAndShield_DoesNotReturnWrongValue()              
        {
            Axe axe = new Axe(15);
            Shield shield = new Shield(-1);
            Dwarf dwarf = new Dwarf("Nombre", 20, 10, 100);
            int result = dwarf.AttackTotal(axe, shield);
            Assert.That(result, Is.Not.EqualTo(100));    
        }

        //Verifica que DefenseTotal retorna la suma correcta
        [Test]
        public void DefenseTotal_WithAxeAndShield_ReturnsSumCorrectly()
        {
            Axe axe = new Axe(0);        
            Shield shield = new Shield(15);
            Dwarf dwarf = new Dwarf("Nombre", 20, 10, 100);
            int result = dwarf.DefenseTotal(axe,shield);
            Assert.That(result, Is.EqualTo(25));
        }
 
        //Verifica que DefenseTotal no retorna un valor incorrecto
        [Test]
        public void DefenseTotal_WithAxeAndShield_DoesNotReturnWrongValue()
        {
            Axe axe = new Axe(0);
            Shield shield = new Shield(0);
            Dwarf dwarf= new Dwarf("Nombre", 20, 10, 100);
            int result = dwarf.DefenseTotal(axe,shield);
            Assert.That(result, Is.Not.EqualTo(99));
        }
    }
}