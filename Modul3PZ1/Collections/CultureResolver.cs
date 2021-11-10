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
        private IDictionary<string, CultureInfo> _defaultInfo;

        public CultureResolver()
        {
            _defaultInfo = new Dictionary<string, CultureInfo>();
        }

        public void Add(string strCulture)
        {
            var cultureInfo = new CultureInfo(strCulture);

            _defaultInfo.Add(strCulture, cultureInfo);
        }

        public CultureInfo GetCultureInfo(string name)
        {
            var convert = name[0];

            if (Regex.IsMatch(convert.ToString(), "[a-z]", RegexOptions.IgnoreCase))
            {
                return _defaultInfo["en-GB"];
            }

            if (Regex.IsMatch(convert.ToString(), "[а-я]", RegexOptions.IgnoreCase))
            {
                return _defaultInfo["ru-RU"];
            }

            throw new ArgumentException("No such CultureInfo stored");
        }

        public CultureInfo[] GetCultures()
        {
            return _defaultInfo.Values.ToArray();
        }
    }
}
