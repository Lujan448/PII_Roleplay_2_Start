using System;
using System.Data;
using Library;

//Esta va a ser la interfaz, la cual se agrego con el proposito de simplificar el código de los items
//y como estos tienen caracteristicas en común se pudo realizar esta implementación.
namespace Ucu.Poo.RolePlayGame
{
    public interface IItems
    {
        int AttackValue {get;}
        int DefenseValue {get;}
    }
}


//Creamos solo una interfaz para aquellos items que tienen caracteristicas similares, 
//en el caso del spellboook este agrega otras caracteristicas que no son propias de estas generalidades
//por lo tanto se podría hacer una interfaz por separado solo para spellbook pero perdería sentido, ya que 
//sería una sola interfaz por el momento para solo un item el cual no comparte todas las caracteristicas con el resto
//por lo tanto optamos por simplemente usar la clase en si como esta. En caso de que posteriormente se agregue
//alguna clase extra y esta tiene las mismas caracteristicas que el spellbook, ahí si creariamos una interfaz nueva.