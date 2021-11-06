using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul3PZ1.Collections.Abstractions
{
    public interface IPhoneBook<T>
    {
        public IReadOnlyCollection<T> this[string key] { get; }
        public void Add(T contact);
    }
}
