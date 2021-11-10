using System;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Modul3PZ1.Collections;
using Modul3PZ1.Collections.Abstractions;
using Modul3PZ1.Models;

namespace Modul3PZ1.Collections
{
    public class PhoneBook<T> : IPhoneBook<T>
        where T : Contact
    {
        private IDictionary<CultureInfo, List<T>> _culturedCollection;
        private IDictionary<CharType, List<T>> _specialCollection;
        private ICultureResolver _cultureResolver;

        public PhoneBook(ICultureResolver cultureResolver)
        {
            _cultureResolver = cultureResolver;
            _cultureResolver.Add("en-GB");
            _cultureResolver.Add("ru-RU");

            _culturedCollection = new Dictionary<CultureInfo, List<T>>();
            _specialCollection = new Dictionary<CharType, List<T>>();

            foreach (var culture in _cultureResolver.GetCultures())
            {
                _culturedCollection.Add(culture, new List<T>());
            }

            _specialCollection.Add(CharType.Number, new List<T>());
            _specialCollection.Add(CharType.Special, new List<T>());
        }

        public IReadOnlyCollection<T> this[string key]
        {
            get
            {
                var collection = DetermineCollection(key);
                var res = new List<T>();

                foreach (var contact in collection)
                {
                    if (contact.Name.StartsWith(key, StringComparison.InvariantCultureIgnoreCase))
                    {
                        res.Add(contact);
                    }
                }

                return res;
            }
        }

        public void Add(T contact)
        {
            if (string.IsNullOrEmpty(contact.Name))
            {
                throw new ArgumentException("Name is null or empty");
            }

            var collection = DetermineCollection(contact.Name);
            collection.Add(contact);
            collection.Sort(new ContactComparer<T>());
        }

        private List<T> DetermineCollection(string name)
        {
            try
            {
                var cultureInfo = _cultureResolver.GetCultureInfo(name);

                return _culturedCollection[cultureInfo];
            }
            catch
            {
                if (Regex.IsMatch(name[0].ToString(), "[0-9]"))
                {
                    return _specialCollection[CharType.Number];
                }

                return _specialCollection[CharType.Special];
            }
        }
    }
}
