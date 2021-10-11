using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul3PZ1.Models.Abstractions;
namespace Modul3PZ1.Models
{
    public class Contact : IContact
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
