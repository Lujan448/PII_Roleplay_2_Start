using NUnit.Framework;
using Library;
using Elfs;
using Dwarfs;

namespace ElfsTests
{
    [TestFixture]
    public class ElfTest
    {   
        //Es el encargado de probar si el elfo esta vivo, si lo esta devuelve true
        [Test]
        public void IsAlive_WhenHealthIsPositive_ReturnsTrue()
        {
            Elf elf = new Elf("Nombre", 20, 10, 100);
            Assert.That(elf.IsAlive(), Is.True);
        }

        //Es el encargado de probar si el elfo esta vivo, si no lo esta devuelve false
        [Test]
        public void IsAlive_WhenHealthIsZero_ReturnsFalse()
        {
            Elf elf = new Elf("Nombre", 20, 10, 0);
            Assert.That(elf.IsAlive(), Is.False);
        }

        //Es el encargado de verificar si es correcto que al recibir ataques cuando daño excede a la defensa, se decrece asi su vida
        [Test]
        public void ReceiveAttack_WhenDamageExceedsDefense_DecreasesHealth()
        {
            Elf elf = new Elf("Nombre", 20, 10, 100);
            Spear attacker = new Spear(30); 
            elf.ReceiveAttack(attacker);
            Assert.That(elf.Health, Is.EqualTo(80));
        }

        //Es el encargado de verificar si es incorrecto, ya que el daño es menor que la defensa no le va a hacer nada.
        [Test]
        public void ReceiveAttack_WhenDamageLessThanDefense_HealthUnchanged()
        {
            Elf elf = new Elf("Nombre", 20, 10, 100);
            Spear attacker = new Spear(5); 
            elf.ReceiveAttack(attacker);
            Assert.That(elf.Health, Is.EqualTo(100));    //Esto pasa cuando tenes una cantidad de ataque menor o igual
                                                         //a la defensa, entonces simplemente queda la vida original o la que tenía hasta ese momento.
        }

        //Esto verifica que cuando un item esta equipado el ataque sale bien y la persona afectada se le disminuye la vida
        [Test]
        public void AttackOthers_WhenItemIsEquipped_DecreasesElfHealth()
        {
            Elf elf = new Elf("Nombre", 30, 5, 100);
            Dwarf dwarf = new Dwarf("Nombre", 20, 10, 100);
            Spear spear = new Spear(50);
            elf.AttackOthers(dwarf, spear);
            Assert.That(dwarf.Health, Is.EqualTo(60));
        }

        //Verifica que Cure restaura la vida al máximo
        [Test]
        public void Cure_WhenCalled_RestoresHealthToMax()
        {
            Elf elf = new Elf("Nombre", 20, 10, 100);
            Spear attacker = new Spear(50); 
            elf.ReceiveAttack(attacker);
            Assert.That(elf.Health, Is.EqualTo(60)); //verificamos que recibió daño
 
            elf.Cure();
            Assert.That(elf.Health, Is.EqualTo(100)); //vuelve al máximo
        }
 
        //Verifica que Cure no supera el máximo de vida
        [Test]
        public void Cure_WhenCalledAtFullHealth_DoesNotExceedMaxHealth()
        {
            Elf elf = new Elf("Nombre", 20, 10, 100);
            elf.Cure();                                 //curar estando lleno no debe cambiar nada
            Assert.That(elf.Health, Is.EqualTo(100));
        }

        //Verifica si se cambia correctamente la lanza
        [Test]
        public void ChangeItem_WhenNewSpearEquipped_UpdatesAttackValue()
        {
            Spear newSpear = new Spear(10);
            Elf elf = new Elf("Nombre", 20, 10, 100);
            elf.ChangeItem(newSpear);
            Assert.That(elf.AttackValue, Is.EqualTo(10));
        }

        //Verifica si se cambia correctamente el casco
        [Test]
        public void ChangeItem_WhenNewHelmetEquipped_UpdatesAttackValue()
        {
            Helmet newHelmet = new Helmet(10);
            Elf elf = new Elf("Nombre", 20, 10, 100);
            elf.ChangeItem(newHelmet);
            Assert.That(elf.DefenseValue, Is.EqualTo(10));
        }

        //Verifica si el ataque total retorna la suma correcta
        [Test]
        public void AttackTotal_WithSpearAndHelmet_ReturnsSumCorrectly()
        {
            Spear spear = new Spear(15);
            Helmet helmet = new Helmet(0);
            Elf elf = new Elf("Nombre", 20, 10, 100);
            int result = elf.AttackTotal(spear, helmet);
            Assert.That(result, Is.EqualTo(35));
        }

        //Verifica en caso de que la suma no retorne la suma correcta
        [Test]
        public void AttackTotal_WithSpearAndHelmet_DoesNotReturnWrongValue()              
        {
            Spear spear = new Spear(15);
            Helmet helmet = new Helmet(-1);
            Elf elf = new Elf("Nombre", 20, 10, 100);
            int result = elf.AttackTotal(spear, helmet);
            Assert.That(result, Is.Not.EqualTo(100));    
        }

        //Verifica que DefenseTotal retorna la suma correcta
        [Test]
        public void DefenseTotal_WithSpearAndHelmet_ReturnsSumCorrectly()
        {
            Spear spear = new Spear(0);        
            Helmet helmet = new Helmet(15);
            Elf elf = new Elf("Nombre", 20, 10, 100);
            int result = elf.DefenseTotal(spear,helmet);
            Assert.That(result, Is.EqualTo(25));
        }
 
        //Verifica que DefenseTotal no retorna un valor incorrecto
        [Test]
        public void DefenseTotal_WithSpearAndHelmet_DoesNotReturnWrongValue()
        {
            Spear spear = new Spear(0);
            Helmet helmet = new Helmet(0);
            Elf elf = new Elf("Nombre", 20, 10, 100);
            int result = elf.DefenseTotal(spear,helmet);
            Assert.That(result, Is.Not.EqualTo(99));
        }
    }
}