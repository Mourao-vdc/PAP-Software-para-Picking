using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlServerCe;
using System.Data.SqlClient;

namespace PickingSoftware.Models
{
    public class Artigos
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cod_Barras { get; set; }

        public static List<Artigos> GetArtigos()
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "SELECT * FROM Artigos";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            List<Artigos> _tst = new List<Artigos>();
            while (dr.Read())
            {
                _tst.Add(new Artigos
                {
                    ID = (int)dr["ID"],
                    Nome = dr["Nome"].ToString(),
                    Cod_Barras = dr["Cod_Barras"].ToString()
                });
            }
            return _tst;
        }

        public static List<Artigos> GetAdicionar()
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "INSERT INTO Artigos(" +
                "ID,Nome,Cod_Barras)" +
                "VALUES (@ID,@Nome,@Cod_Barras)";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            List<Artigos> _tst = new List<Artigos>();
            while (dr.Read())
            {
                _tst.Add(new Artigos
                {
                    ID = (int)dr["ID"],
                    Nome = dr["Nome"].ToString(),
                    Cod_Barras = dr["Cod_Barras"].ToString()
                });
            }
            return _tst;
        }

    }
}