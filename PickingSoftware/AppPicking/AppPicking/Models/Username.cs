namespace AppPicking.Models
{
    internal class Username
    {
        public string valor { get; set; }
        public string valor2 { get; set; }

        private static string _Nome = "";
        public static string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }

        private static string _ID = "";
        public static string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private static string _Email = "";
        public static string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
    }
}
