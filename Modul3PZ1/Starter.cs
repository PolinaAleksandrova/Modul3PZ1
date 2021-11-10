using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul3PZ1.Collections;
using Modul3PZ1.Models;
using Modul3PZ1.Collections.Abstractions;

namespace Modul3PZ1
{
    public class Starter
    {
        private readonly IPhoneBook<Contact> _phoneBook;
        public Starter(IPhoneBook<Contact> phoneBook)
        {
            _phoneBook = phoneBook;
        }

        public void Run()
        {
            _phoneBook.Add(new Contact() { Name = "Alexander", LastName = "Novikov" });
            _phoneBook.Add(new Contact() { Name = "Alexey", LastName = "Smirnov" });
            _phoneBook.Add(new Contact() { Name = "Ivan", LastName = "Orlov" });
            _phoneBook.Add(new Contact() { Name = "Elizaveta", LastName = "Andreeva" });
            _phoneBook.Add(new Contact() { Name = "Ilya", LastName = "Sidorov" });
            _phoneBook.Add(new Contact() { Name = "Alice", LastName = "Ignatieva" });
            _phoneBook.Add(new Contact() { Name = "Varvara", LastName = "Demina" });
            _phoneBook.Add(new Contact() { Name = "Andrey", LastName = "Denisov" });
            _phoneBook.Add(new Contact() { Name = "Valeria", LastName = "Nikiforova" });
            _phoneBook.Add(new Contact() { Name = "Anna", LastName = "Trofimova" });
            _phoneBook.Add(new Contact() { Name = "Сергей", LastName = "Бурцев" });
            _phoneBook.Add(new Contact() { Name = "Владислав", LastName = "Фоменко" });
            var x = _phoneBook["Alex"];
        }
    }
}
