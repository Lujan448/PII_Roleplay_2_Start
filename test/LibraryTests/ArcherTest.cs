using NUnit.Framework;
using Library;
using Archers;
using Elfs;

namespace ArchersTests
{
    [TestFixture]
    public class ArcherTest
    {   
        //Es el encargado de probar si el arquero esta vivo, si lo esta devuelve true
        [Test]
        public void IsAlive_WhenHealthIsPositive_ReturnsTrue()
        {
            Archer archer = new Archer("Nombre", 20, 10, 100);
            Assert.That(archer.IsAlive(), Is.True);
        }

        //Es el encargado de probar si el arquero esta vivo, si no lo esta devuelve false
        [Test]
        public void IsAlive_WhenHealthIsZero_ReturnsFalse()
        {
            Archer archer = new Archer("Nombre", 20, 10, 0);
            Assert.That(archer.IsAlive(), Is.False);
        }

        //Es el encargado de verificar si es correcto que al recibir ataques cuando daño excede a la defensa, se decrece asi su vida
        [Test]
        public void ReceiveAttack_WhenDamageExceedsDefense_DecreasesHealth()
        {
            Archer archer = new Archer("Nombre", 20, 10, 100);
            Bow attacker = new Bow(30); 
            archer.ReceiveAttack(attacker);
            Assert.That(archer.Health, Is.EqualTo(80));
        }

        //Es el encargado de verificar si es incorrecto, ya que el daño es menor que la defensa no le va a hacer nada.
        [Test]
        public void ReceiveAttack_WhenDamageLessThanDefense_HealthUnchanged()
        {
            Archer archer = new Archer("Nombre", 20, 10, 100);
            Bow attacker = new Bow(5); 
            archer.ReceiveAttack(attacker);
            Assert.That(archer.Health, Is.EqualTo(100));    //Esto pasa cuandotenes una cantidad de ataque menor o igual
                                                            //a la defensa, entonces simplemente queda la vida original o la que tenía hasta ese momento.
        }

        //Esto verifica que cuando un item esta equipado el ataque sale bien y la persona afectada se le disminuye la vida
        [Test]
        public void AttackOthers_WhenItemIsEquipped_DecreasesElfHealth()
        {
            Archer archer = new Archer("Nombre", 30, 5, 100);
            Elf elf = new Elf("Nombre", 20, 10, 100);
            Bow bow = new Bow(50);
            archer.AttackOthers(elf, bow);
            Assert.That(elf.Health, Is.EqualTo(60));
        }

        //Verifica que Cure restaura la vida al máximo
        [Test]
        public void Cure_WhenCalled_RestoresHealthToMax()
        {
            Archer archer = new Archer("Nombre", 20, 10, 100);
            Bow attacker = new Bow(50); 
            archer.ReceiveAttack(attacker);
            Assert.That(archer.Health, Is.EqualTo(60)); //verificamos que recibió daño
 
            archer.Cure();
            Assert.That(archer.Health, Is.EqualTo(100)); //vuelve al máximo
        }
 
        //Verifica que Cure no supera el máximo de vida
        [Test]
        public void Cure_WhenCalledAtFullHealth_DoesNotExceedMaxHealth()
        {
            Archer archer = new Archer("Nombre", 20, 10, 100);
            archer.Cure();                                              //curar estando lleno no debe cambiar nada
            Assert.That(archer.Health, Is.EqualTo(100));
        }

        //Verifica si se cambia correctamente el arco
        [Test]
        public void ChangeItem_WhenNewBowEquipped_UpdatesAttackValue()
        {
            Bow newBow = new Bow(10);
            Archer archer = new Archer("Nombre", 20, 10, 100);
            archer.ChangeItem(newBow);
            Assert.That(archer.AttackValue, Is.EqualTo(10));
        }

        //Verifica si se cambia correctamente la daga
        [Test]
        public void ChangeItem_WhenNewDaggerEquipped_UpdatesAttackValue()
        {
            Dagger newDagger = new Dagger(10);
            Archer archer = new Archer("Nombre", 20, 10, 100);
            archer.ChangeItem(newDagger);
            Assert.That(archer.AttackValue, Is.EqualTo(10));
        }

        //Verifica si el ataque total retorna la suma correcta
        [Test]
        public void AttackTotal_WithBowAndDagger_ReturnsSumCorrectly()
        {
            Bow bow = new Bow(15);
            Dagger dagger = new Dagger(5);
            Archer archer = new Archer("Nombre", 20, 10, 100);
            int result = archer.AttackTotal(dagger, bow);
            Assert.That(result, Is.EqualTo(40));
        }

        //Verifica en caso de que la suma no retorne la suma correcta
        [Test]
        public void AttackTotal_WithBowAndDagger_DoesNotReturnWrongValue()              
        {
            Bow bow = new Bow(15);
            Dagger dagger = new Dagger(5);
            Archer archer = new Archer("Nombre", 20, 10, 100);
            int result = archer.AttackTotal(dagger, bow);
            Assert.That(result, Is.Not.EqualTo(99));    
        }

        //Verifica que DefenseTotal retorna la suma correcta
        [Test]
        public void DefenseTotal_WithBowAndDagger_ReturnsSumCorrectly()
        {
            Bow bow = new Bow(0);        
            Dagger dagger = new Dagger(0);
            Archer archer = new Archer("Nombre", 20, 10, 100);
            int result = archer.DefenseTotal(dagger, bow);
            Assert.That(result, Is.EqualTo(10));
        }
 
        //Verifica que DefenseTotal no retorna un valor incorrecto
        [Test]
        public void DefenseTotal_WithBowAndDagger_DoesNotReturnWrongValue()
        {
            Bow bow = new Bow(0);
            Dagger dagger = new Dagger(0);
            Archer archer = new Archer("Nombre", 20, 10, 100);
            int result = archer.DefenseTotal(dagger, bow);
            Assert.That(result, Is.Not.EqualTo(99));
        }
    }
}