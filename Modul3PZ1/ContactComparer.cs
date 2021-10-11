using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul3PZ1.Models;

namespace Modul3PZ1
{
   public class ContactComparer<T> : IComparer<T>
       where T : Contact
   {
        public int Compare(T x, T y)
        {
            return string.CompareOrdinal(x.Name, y.Name);
        }
   }
}
