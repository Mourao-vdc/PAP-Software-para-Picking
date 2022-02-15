using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlServerCe;

namespace API.Models
{
    public class Artigos
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int Cod_Barras { get; set; }
    }

    public sealed class SqlCeConnection : Artigos
    {
        SqlCeConnection con =
                    new SqlCeConnection(@"Data Source=|DataDirectory|\Picking.sdf");
        con.Open();
            string query = "SELECT * FROM clientes where idcliente='" + txtIDCliente.Text + "'";
        SqlCeCommand cmd = new SqlCeCommand(query, con);
        SqlCeDataReader dr = cmd.ExecuteReader();

        teste _tst = new teste();
        while (dr.Read)
        {
            _tst.ID = (int) dr["ID"];
            _tst.Nome = dr["Nome"].toString();
            _tst.Cod_Barras = (int) dr["Cod_Barras"];
        }
    }

}