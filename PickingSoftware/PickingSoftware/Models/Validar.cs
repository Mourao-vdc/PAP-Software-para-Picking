using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PickingSoftware.Models
{
    public class Validar
    {
        public int ID { get; set; }
        public int ID_Utilizadores { get; set; }
        public string Nome { get; set; }
        public string Data { get; set; }
        public int ID2 { get; set; }
        public int ID_Encomendas { get; set; }
        public string Nome2 { get; set; }
        public string Cod_Barras { get; set; }
        public string Estado { get; set; }
        public int Quant_artigos_cliente { get; set; }

        public static List<Validar> GetValidar(string _nome)
        {
            SqlConnection con =
                new SqlConnection(BD.Constring);
            con.Open();
            string query = "SELECT Encomendas.ID, Utilizador.Nome, FORMAT (Data, 'dd/MM/yyyy ') as Data FROM Encomendas" +
                " JOIN Utilizador" +
                " ON Utilizador.ID = Encomendas.ID_Utilizadores" +
                " WHERE Encomendas.ID NOT IN (SELECT ID_Encomendas FROM Encomendas_Artigos WHERE Situacao NOT LIKE 'PRONTO')" +
                " AND Utilizador.Nome = '" + _nome + "'" +
                " AND Encomendas.Estado = 'Por verificar'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            List<Validar> _tst = new List<Validar>();
            while (dr.Read())
            {
                _tst.Add(new Validar
                {
                    ID = (int)dr["ID"],
                    Nome = dr["Nome"].ToString(),
                    Data = dr["Data"].ToString()
                });
            }
            return _tst;
        }

        public static List<Validar> GetValidarDetalhes(int _idencomenda)
        {
            SqlConnection con =
                new SqlConnection(BD.Constring);
            con.Open();
            string query = "Select Encomendas_Artigos.ID, Encomendas_Artigos.ID_Encomendas, Artigos.Nome, Encomendas_Artigos.Quant_artigos_cliente, Encomendas_Artigos.Cod_Barras" +
                " from Encomendas_Artigos Inner join Artigos on Artigos.ID = Encomendas_Artigos.ID_Artigos WHERE ID_Encomendas='" + _idencomenda + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            List<Validar> _tst = new List<Validar>();
            while (dr.Read())
            {
                _tst.Add(new Validar
                {
                    ID2 = (int)dr["ID"],
                    ID_Encomendas = (int)dr["ID_Encomendas"],
                    Nome2 = dr["Nome"].ToString(),
                    Quant_artigos_cliente = (int)dr["Quant_artigos_cliente"],
                    Cod_Barras = dr["Cod_Barras"].ToString(),
                });
            }
            return _tst;
        }

        public static bool GetValidarEstado(Validar _validar)
        {
            try
            {
                SqlConnection con =
                    new SqlConnection(BD.Constring);
                con.Open();
                string query = "UPDATE Encomendas SET" +
                    " Estado=@Estado" +
                    " WHERE ID=@ID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", _validar.ID);
                    cmd.Parameters.AddWithValue("@Estado", _validar.Estado);
                    cmd.ExecuteScalar();

                    con.Close();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static List<Validar> GetValidadas()
        {
            SqlConnection con =
                new SqlConnection(BD.Constring);
            con.Open();
            string query = "SELECT Encomendas.ID, Utilizador.Nome, FORMAT (Data, 'dd/MM/yyyy ') as Data FROM Encomendas" +
                " JOIN Utilizador" +
                " ON Utilizador.ID = Encomendas.ID_Utilizadores" +
                " WHERE Encomendas.ID NOT IN (SELECT ID_Encomendas FROM Encomendas_Artigos WHERE Situacao NOT LIKE 'PRONTO')" +
                " AND Encomendas.Estado = 'Validada'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            List<Validar> _tst = new List<Validar>();
            while (dr.Read())
            {
                _tst.Add(new Validar
                {
                    ID = (int)dr["ID"],
                    Nome = dr["Nome"].ToString(),
                    Data = dr["Data"].ToString()
                });
            }
            return _tst;
        }
    }
}