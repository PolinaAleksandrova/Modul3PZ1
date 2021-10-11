using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul3PZ1.Models.Abstractions;

namespace Modul3PZ1.Collections.Abstractions
{
    public interface IPhoneBook<T>
        where T : IContact
    {
        public IReadOnlyCollection<T> this[string key] { get; }
        public void Add(T contact);
    }
}
