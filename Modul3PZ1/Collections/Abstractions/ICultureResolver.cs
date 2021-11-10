using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul3PZ1.Collections.Abstractions
{
    public interface ICultureResolver
    {
        public CultureInfo GetCultureInfo(string name);
        public void Add(string strCulture);
        public CultureInfo[] GetCultures();
    }
}
