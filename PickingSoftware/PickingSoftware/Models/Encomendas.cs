using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlServerCe;

namespace PickingSoftware.Models
{
    public class Encomendas
    {
        public int ID { get; set; }
        public int ID_Artigos { get; set; }
        public string Cod_Barras { get; set; }
        public bool Situacao { get; set; }
        public int Quant_artigos { get; set; }


        public static List<Encomendas> GetArtigos()
        {
            SqlCeConnection con =
                new SqlCeConnection(@"DataSource=|DataDirectory|\Picking.sdf");
            con.Open();
            string query = "SELECT * FROM Encomendas";
            SqlCeCommand cmd = new SqlCeCommand(query, con);
            SqlCeDataReader dr = cmd.ExecuteReader();

            List<Encomendas> _tst = new List<Encomendas>();
            while (dr.Read())
            {
                _tst.Add(new Encomendas
                {
                    ID = (int)dr["ID"],
                    ID_Artigos = (int)dr["ID_Artigos"],
                    Cod_Barras = dr["Cod_Barras"].ToString(),
                    Situacao = dr["Situacao"].ToString(),
                    Quant_artigos = (int)dr["Quant_artigos"]
                });
            }
            return _tst;
        }
    }
}