using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PickingSoftware.Models
{
    public class Encomendas
    {
        public int ID { get; set; }
        public int ID_Utilizadores { get; set; }
        public string Nome { get; set; }
        public string Data { get; set; }


        public static List<Encomendas> GetEncomendas()
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "SELECT Encomendas.ID, Utilizador.Nome, Encomendas.Data FROM Encomendas" +
                " INNER JOIN Utilizador" +
                " ON Utilizador.ID = Encomendas.ID_Utilizadores";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            List<Encomendas> _tst = new List<Encomendas>();
            while (dr.Read())
            {
                _tst.Add(new Encomendas
                {
                    ID = (int)dr["ID"],
                    Nome = dr["Nome"].ToString(),
                    Data = dr["Data"].ToString()
                });
            }
            return _tst;
        }

        /// <summary>
        /// Adicionar
        /// </summary>
        /// <param name="_encomendas"></param>
        public static bool GetAdicionar(Encomendas _encomendas, string _nome)
        {
            try
            {
                SqlConnection con =
                    new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
                con.Open();
                string query = "INSERT INTO Encomendas(" +
                    "ID_Utilizadores,Data)" +
                    " VALUES (@ID_Utilizadores,@Data)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    Debug.WriteLine("");
                    Debug.WriteLine("NOME");
                    Debug.WriteLine(_nome);
                    Debug.WriteLine("");

                    //cmd.Parameters.AddWithValue("@ID", _artigo.ID);
                    cmd.Parameters.AddWithValue("@ID_Utilizadores", IDM(_nome));
                    cmd.Parameters.AddWithValue("@Data", _encomendas.Data);
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
        /// <param name="_encomendas"></param>
        public static bool GetEditar(Encomendas _encomendas)
        {
            try
            {
                SqlConnection con =
                    new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
                con.Open();
                string query = "UPDATE Encomendas SET" +
                    " ID_Utilizadores=@ID_Utilizadores,Data=@Data" +
                    " WHERE ID=@ID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", _encomendas.ID);
                    cmd.Parameters.AddWithValue("@ID_Utilizadores", _encomendas.Nome);
                    cmd.Parameters.AddWithValue("@Data", _encomendas.Data);
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
                string query = "DELETE Encomendas" +
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

        public static bool IDM(string _nome)
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "SELECT ID FROM Utilizador WHERE Nome=@Nome";
            
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Nome", _nome);
                cmd.ExecuteNonQuery();

                con.Close();
            }
            return true;
        }
    }
}