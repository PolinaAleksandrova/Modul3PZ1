using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Modul3PZ1.Collections.Abstractions;
using Modul3PZ1.Collections;

namespace Modul3PZ1.Collections
{
    public class CultureResolver : ICultureResolver
    {
        private readonly CultureInfo _defaultInfo;

        public CultureResolver()
        {
            _defaultInfo = CultureInfo.GetCultureInfo("en-Gb");
        }

        public void Add(string strCulture)
        {
            var cultureInfo = new CultureInfo(strCulture);

            _defaultInfo.Add(strCulture, cultureInfo);
        }

        public CultureInfo GetCultureInfo(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name is null or empty");
            }

            if (Regex.IsMatch(name, "[A-Za-z]"))
            {
                return CultureInfo.GetCultureInfo("en-Gb");
            }
            else if (Regex.IsMatch(name, "[ЁёА-Яа-я]"))
            {
                return CultureInfo.GetCultureInfo("ru-Ru");
            }
            else
            {
                return _defaultInfo;
            }
        }
    }
}
