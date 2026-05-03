using Wizards;
using NUnit.Framework;

namespace SpellBookTests
{
    [TestFixture]
    public class SpellBookTest
    {
        //HasSpell devuelve false si no se agregó el spell a la lista o si este se removio
        [Test]
        public void HasSpell_ReturnsFalse_IfSpellNotAdded()
        {
            SpellBook book = new SpellBook();
            Spell spell = new Spell("Nombre", 10);
            Assert.That(book.HasSpell(spell), Is.False);
        }

        //AddSpell y HasSpell se verifican juntos, ya que los métodos depende del otro para que funcionen y de correcto
        [Test]
        public void HasSpell_ReturnsTrue_AfterAddSpell()
        {
            SpellBook book = new SpellBook();
            Spell spell = new Spell("Nombre", 10);
            book.AddSpell(spell);
            Assert.That(book.HasSpell(spell), Is.True);
        }
    }
}