using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace PickingSoftware
{
    public class BD
    {
        private static string _conString = WebConfigurationManager.ConnectionStrings["conexaoPrincipal"].ConnectionString;

        public static string Constring
        {
            get { return _conString; }
        }
    }
}