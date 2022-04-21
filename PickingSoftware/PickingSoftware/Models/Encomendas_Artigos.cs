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
        public int Quant_artigos { get; set; }

        public static List<Encomendas_Artigos> GetEncomendas_Artigos()
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
                    Quant_artigos = (int)dr["Quant_artigos"]
                });
            }
            return _tst;
        }

        /// <summary>
        /// Adicionar
        /// </summary>
        /// <param name="_encomendasartigos"></param>
        public static bool GetAdicionar(Encomendas_Artigos _encomendasartigos)
        {
            try
            {
                SqlConnection con =
                    new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
                con.Open();
                string query = "INSERT INTO Encomendas_Artigos(" +
                    "ID_Encomendas,ID_Artigos,Cod_Barras,Situacao,Quant_artigos)" +
                    " VALUES (@ID_Encomendas,@ID_Artigos,@Cod_Barras,@Situacao,@Quant_artigos)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    //cmd.Parameters.AddWithValue("@ID", _artigo.ID);
                    cmd.Parameters.AddWithValue("@ID_Encomendas", _encomendasartigos.ID_Encomendas);
                    cmd.Parameters.AddWithValue("@ID_Artigos", _encomendasartigos.ID_Artigos);
                    cmd.Parameters.AddWithValue("@Cod_Barras", _encomendasartigos.Cod_Barras);
                    cmd.Parameters.AddWithValue("@Situacao", _encomendasartigos.Situacao);
                    cmd.Parameters.AddWithValue("@Quant_artigos", _encomendasartigos.Quant_artigos);
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

        /// <summary>
        /// Editar
        /// </summary>
        /// <param name="_encomendasartigos"></param>
        public static bool GetEditar(Encomendas_Artigos _encomendasartigos)
        {
            try
            {
                SqlConnection con =
                    new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
                con.Open();
                string query = "UPDATE Encomendas_Artigos SET" +
                    " ID_Encomendas=@ID_Encomendas,ID_Artigos=@ID_Artigos,Cod_Barras=@Cod_Barras,Quant_artigos=@Quant_artigos" +
                    " WHERE ID=@ID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", _encomendasartigos.ID);
                    cmd.Parameters.AddWithValue("@ID_Encomendas", _encomendasartigos.ID_Encomendas);
                    cmd.Parameters.AddWithValue("@ID_Artigos", _encomendasartigos.ID_Artigos);
                    cmd.Parameters.AddWithValue("@Cod_Barras", _encomendasartigos.Cod_Barras);
                    cmd.Parameters.AddWithValue("@Quant_artigos", _encomendasartigos.Quant_artigos);
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

        /// <summary>
        /// Eliminar
        /// </summary>
        /// <param name="id"></param>
        public static bool GetEliminar(int id)
        {
            try
            {
                SqlConnection con =
                    new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
                con.Open();
                string query = "DELETE Encomendas_Artigos" +
                    " WHERE ID=@ID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Editar Estado
        /// </summary>
        /// <param name="_encomendasartigos"></param>
        public static bool GetEstado(Encomendas_Artigos _encomendasartigos)
        {
            try
            {
                SqlConnection con =
                    new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
                con.Open();
                string query = "UPDATE Encomendas_Artigos SET" +
                    " Situacao=@Situacao" +
                    " WHERE ID_Encomendas=@ID_Encomendas";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID_Encomendas", _encomendasartigos.ID_Encomendas);
                    cmd.Parameters.AddWithValue("@Situacao", _encomendasartigos.Situacao);
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
    }
}