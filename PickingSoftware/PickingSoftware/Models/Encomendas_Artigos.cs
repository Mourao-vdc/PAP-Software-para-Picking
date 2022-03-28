using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PickingSoftware.Models
{
    public class Encomendas_Artigos
    {
        public int ID { get; set; }
        public int ID_Encomendas { get; set; }
        public int ID_Artigos { get; set; }
        public string Cod_Barras { get; set; }
        public string Situacao { get; set; }
        public string Quant_artigos { get; set; }

        public static List<Encomendas_Artigos> GetArtigos()
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "SELECT * FROM Encomendas_Artigos";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            List<Encomendas_Artigos> _tst = new List<Encomendas_Artigos>();
            while (dr.Read())
            {
                _tst.Add(new Encomendas_Artigos
                {
                    ID = (int)dr["ID"],
                    ID_Encomendas = (int)dr["ID_Encomendas"],
                    ID_Artigos = (int)dr["ID_Artigos"],
                    Cod_Barras = dr["Cod_Barras"].ToString(),
                    Situacao = dr["Situacao"].ToString(),
                    Quant_artigos = dr["Situacao"].ToString()
                });
            }
            return _tst;
        }
    }
}