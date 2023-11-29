using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSchool.Base;

namespace LanguageSchool.Base
{
    public partial class Client
    {
        public string FullName
        {
            get
            {
                return $"{LastName} {FirstName} {Patronymic}";
            }
        }
    }
}
