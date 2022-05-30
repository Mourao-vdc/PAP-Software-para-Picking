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
                new SqlConnection(BD.Constring);
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

            con.Close();

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
                    new SqlConnection(BD.Constring);
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
        public static bool GetEditar(Artigos _artigo)
        {
            try
            {
                SqlConnection con =
                    new SqlConnection(BD.Constring);
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
                    new SqlConnection(BD.Constring);
                con.Open();
                string query = "DELETE Artigos" +
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

        public static List<Artigos> GetCodBarras(string _CodBarras)
        {
            SqlConnection con =
                new SqlConnection(BD.Constring);
            con.Open();
            string query = "SELECT * FROM Artigos WHERE Cod_Barras like '" + _CodBarras + "'";
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

            con.Close();

            return _tst;
        }

        public static string CodBarras(string _Nome)
        {
            SqlConnection con =
                new SqlConnection(BD.Constring);
            con.Open();
            string query = "SELECT Cod_Barras FROM Artigos WHERE Nome='" + _Nome + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            List<Utilizador> _tst = new List<Utilizador>();
            while (dr.Read())
            {
                return dr["Cod_Barras"].ToString();
            }

            con.Close();

            return _tst.ToString();
        }
    }
}