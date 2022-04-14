using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Adicionar
        /// </summary>
        /// <param name="_artigo"></param>
        public static bool GetAdicionar(Artigos _artigo)
        {
            try
            {
                SqlConnection con =
                    new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
                con.Open();
                string query = "INSERT INTO Artigos(" +
                    "Nome,Cod_Barras)" +
                    " VALUES (@Nome,@Cod_Barras)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    //cmd.Parameters.AddWithValue("@ID", _artigo.ID);
                    cmd.Parameters.AddWithValue("@Nome", _artigo.Nome);
                    cmd.Parameters.AddWithValue("@Cod_Barras", _artigo.Cod_Barras);
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
        /// <param name="id"></param>
        /// <param name="_artigo"></param>
        public static void GetEditar(Artigos _artigo)
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "UPDATE Artigos SET" +
                " Nome=@Nome,Cod_Barras=@Cod_Barras" +
                " WHERE ID=@ID";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ID", _artigo.ID);
                cmd.Parameters.AddWithValue("@Nome", _artigo.Nome);
                cmd.Parameters.AddWithValue("@Cod_Barras", _artigo.Cod_Barras);
                cmd.ExecuteScalar();

                con.Close();
            }

        }

        /// <summary>
        /// Eliminar
        /// </summary>
        /// <param name="id"></param>
        public static void GetEliminar(int id)
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "DELETE Artigos" +
                " WHERE ID=@ID";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();

                con.Close();
            }
        }
    }
}