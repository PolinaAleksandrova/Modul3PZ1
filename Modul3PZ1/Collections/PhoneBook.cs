using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;
using Modul3PZ1.Collections;
using Modul3PZ1.Collections.Abstractions;
using Modul3PZ1.Models.Abstractions;
using Modul3PZ1.Models;

namespace Modul3PZ1.Collections
{
    public class PhoneBook<T> : IPhoneBook<T>
        where T : IContact
    {
        private IDictionary<CultureInfo, ICollection<T>> _culturedCollections;
        private IDictionary<CharType, ICollection<T>> _specialCollections;
        private ICultureResolver _cultureResolver;

        public PhoneBook()
        {
            _cultureResolver = new CultureResolver();
            _culturedCollections = new Dictionary<CultureInfo, ICollection<T>>();
            _culturedCollections.Add(CultureInfo.GetCultureInfo("ru-Ru"), new List<T>());
            _culturedCollections.Add(CultureInfo.GetCultureInfo("en-Gb"), new List<T>());
            _specialCollections = new Dictionary<CharType, ICollection<T>>();
            _specialCollections.Add(CharType.Number, new List<T>());
            _specialCollections.Add(CharType.Special, new List<T>());
        }

        public IReadOnlyCollection<T> this[string key]
        {
            get
            {
                var collection = DetermineCollection(key);
                var result = new List<T>();

                foreach (var contact in collection)
                {
                    if (contact.Name.StartsWith(key, StringComparison.InvariantCultureIgnoreCase))
                    {
                        result.Add(contact);
                    }
                }

                return result;
            }
        }

        public void Add(T contact)
        {
            if (string.IsNullOrEmpty(contact.Name))
            {
                throw new ArgumentException("Name is null or empty");
            }

            var collection = DetermineCollection(contact.Name);
            collection.Sort(new ContactComparer<T>());
            collection.Add(contact);
        }

        public ICollection<T> DetermineCollection(string name)
        {
            var cultureInfo = _cultureResolver.GetCultureInfo(name);

            if (cultureInfo == null)
            {
                if (Regex.IsMatch(name[0].ToString(), "[0-9]"))
                {
                    return _specialCollections[CharType.Number];
                }
                else
                {
                    return _specialCollections[CharType.Special];
                }
            }

            return _culturedCollections[cultureInfo];
        }
    }
}
