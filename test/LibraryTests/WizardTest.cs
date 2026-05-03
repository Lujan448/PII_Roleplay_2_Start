using NUnit.Framework;
using Library;
using Archers;
using Wizards;

namespace WizardsTests
{
    [TestFixture]
    public class WizardTest
    {   
        //Es el encargado de probar si el hechicero esta vivo, si lo esta devuelve true
        [Test]
        public void IsAlive_WhenHealthIsPositive_ReturnsTrue()
        {
            Wizard wizard = new Wizard("Nombre", 20, 10, 100);
            Assert.That(wizard.IsAlive(), Is.True);
        }

        //Es el encargado de probar si el hechicero esta vivo, si no lo esta devuelve false
        [Test]
        public void IsAlive_WhenHealthIsZero_ReturnsFalse()
        {
            Wizard wizard = new Wizard("Nombre", 20, 10, 0);
            Assert.That(wizard.IsAlive(), Is.False);
        }

        //Es el encargado de verificar si es correcto que al recibir ataques cuando daño excede a la defensa, se decrece asi su vida
        [Test]
        public void ReceiveAttack_WhenDamageExceedsDefense_DecreasesHealth()
        {
            Wizard wizard = new Wizard("Nombre", 20, 10, 100);
            MagicStaff attacker = new MagicStaff(30); 
            wizard.ReceiveAttack(attacker);
            Assert.That(wizard.Health, Is.EqualTo(80));
        }

        //Es el encargado de verificar si es incorrecto, ya que el daño es menor que la defensa no le va a hacer nada.
        [Test]
        public void ReceiveAttack_WhenDamageLessThanDefense_HealthUnchanged()
        {
            Wizard wizard = new Wizard("Nombre", 20, 10, 100);
            MagicStaff attacker = new MagicStaff(5); 
            wizard.ReceiveAttack(attacker);
            Assert.That(wizard.Health, Is.EqualTo(100));    //Esto pasa cuandotenes una cantidad de ataque menor o igual
                                                            //a la defensa, entonces simplemente queda la vida original o la que tenía hasta ese momento.
        }

        //Esto verifica que cuando un item esta equipado el ataque sale bien y la persona afectada se le disminuye la vida
        [Test]
        public void AttackOthers_WhenItemIsEquipped_DecreasesElfHealth()
        {
            Wizard wizard = new Wizard("Nombre", 30, 5, 100);
            Archer archer= new Archer("Nombre", 20, 10, 100);
            MagicStaff staff = new MagicStaff(50);
            wizard.AttackOthers(archer, staff);
            Assert.That(archer.Health, Is.EqualTo(60));
        }

        //Verifica que Cure restaura la vida al máximo
        [Test]
        public void Cure_WhenCalled_RestoresHealthToMax()
        {
            Wizard wizard = new Wizard("Nombre", 20, 10, 100);
            MagicStaff attacker = new MagicStaff(50); 
            wizard.ReceiveAttack(attacker);
            Assert.That(wizard.Health, Is.EqualTo(60)); //verificamos que recibió daño
 
            wizard.Cure();
            Assert.That(wizard.Health, Is.EqualTo(100)); //vuelve al máximo
        }
 
        //Verifica que Cure no supera el máximo de vida
        [Test]
        public void Cure_WhenCalledAtFullHealth_DoesNotExceedMaxHealth()
        {
            Wizard wizard = new Wizard("Nombre", 20, 10, 100);
            wizard.Cure();                                          //curar estando lleno no debe cambiar nada
            Assert.That(wizard.Health, Is.EqualTo(100));
        }

        //Verifica si se cambia correctamente el bastón mágico
        [Test]
        public void ChangeItem_WhenNewStaffEquipped_UpdatesAttackValue()
        {
            MagicStaff newStaff = new MagicStaff(10);
            Wizard wizard = new Wizard("Nombre", 20, 10, 100);
            wizard.ChangeItem(newStaff);
            Assert.That(wizard.AttackValue, Is.EqualTo(10));
        }

        //Verifica si se cambia correctamente la túnica
        [Test]
        public void ChangeItem_WhenNewTunicEquipped_UpdatesAttackValue()
        {
            Tunic newTunic = new Tunic(10);
            Wizard wizard = new Wizard("Nombre", 20, 10, 100);
            wizard.ChangeItem(newTunic);
            Assert.That(wizard.DefenseValue, Is.EqualTo(10));
        }

        //Verifica si el ataque total retorna la suma correcta
        [Test]
        public void AttackTotal_WithStaffAndTunic_ReturnsSumCorrectly()
        {
            MagicStaff staff = new MagicStaff(15);
            Tunic tunic = new Tunic(0);
            Wizard wizard = new Wizard("Nombre", 20, 10, 100);
            int result = wizard.AttackTotal(staff, tunic);
            Assert.That(result, Is.EqualTo(35));
        }

        //Verifica en caso de que la suma no retorne la suma correcta
        [Test]
        public void AttackTotal_WithStaffAndTunic_DoesNotReturnWrongValue()              
        {
            MagicStaff staff = new MagicStaff(15);
            Tunic tunic = new Tunic(5);
            Wizard wizard = new Wizard("Nombre", 20, 10, 100);
            int result = wizard.AttackTotal(staff, tunic);
            Assert.That(result, Is.Not.EqualTo(99));    
        }

        //Verifica que DefenseTotal retorna la suma correcta
        [Test]
        public void DefenseTotal_WithStaffAndTunic_ReturnsSumCorrectly()
        {
            MagicStaff staff = new MagicStaff(0);        
            Tunic tunic = new Tunic(15);
            Wizard wizard = new Wizard("Nombre", 20, 10, 100);
            int result = wizard.DefenseTotal(staff, tunic);
            Assert.That(result, Is.EqualTo(25));
        }
 
        //Verifica que DefenseTotal no retorna un valor incorrecto
        [Test]
        public void DefenseTotal_WithStaffAndTunic_DoesNotReturnWrongValue()
        {
            MagicStaff staff = new MagicStaff(0);
            Tunic tunic = new Tunic(0);
            Wizard wizard= new Wizard("Nombre", 20, 10, 100);
            int result = wizard.DefenseTotal(staff,tunic);
            Assert.That(result, Is.Not.EqualTo(99));
        }
    }
}