using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using Modul3PZ1.Collections;
using Modul3PZ1.Models;
using Microsoft.Extensions.DependencyInjection;
using Modul3PZ1.Collections.Abstractions;

namespace Modul3PZ1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddTransient<ICultureResolver, CultureResolver>()
            .AddTransient<IPhoneBook<Contact>, PhoneBook<Contact>>()
            .AddTransient<Starter>()
            .BuildServiceProvider();
            var appStarter = serviceProvider.GetService<Starter>();
            appStarter.Run();
        }
    }
}
