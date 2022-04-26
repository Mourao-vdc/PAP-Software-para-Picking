using System;
using System.Collections.Generic;
using System.Text;

namespace AppPicking.Models
{
    internal class Username
    {
        public string valor { get; set; }

        private static string _Nome = "";
        public static string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }
    }
}
