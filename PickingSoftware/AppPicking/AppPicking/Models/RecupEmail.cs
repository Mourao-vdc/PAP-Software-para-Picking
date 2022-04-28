namespace AppPicking.Models
{
    class RecupEmail
    {
        private static string _nome = "";
        public static string nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private static string _pass = "";
        public static string pass
        {
            get { return _pass; }
            set { _pass = value; }
        }
    }
}
