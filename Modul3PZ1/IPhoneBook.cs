using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul3PZ1
{
    public interface IPhoneBook<T>
    {
        void Add(T contact);
        T Get(string key);
        IReadOnlyCollection<T> this[string key] { get; }
    }
}
