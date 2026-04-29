using System;
using System.Data;
using Library;

namespace Ucu.Poo.RolePlayGame
{
    public interface IInventory <T>
    {
        bool HasMagic(T item);

        void RemoveMagic(T item);

        void AddMagic(T item);
    }



}