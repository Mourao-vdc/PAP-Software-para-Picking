using System;
using System.Collections.Generic;
using System.Text;

namespace AppPicking.Models
{
    internal class Username
    {
        private static string _valor = "";
        public static string valor
        {
            get { return _valor; }
            set { _valor = value; }
        }
    }
}
