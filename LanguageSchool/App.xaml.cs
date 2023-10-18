using LanguageSchool.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LanguageSchool
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static LanguaheSchool321Entities1 db = new LanguaheSchool321Entities1();
        public static bool IsAdmin = false;
    }
}
