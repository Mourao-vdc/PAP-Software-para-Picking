using System.Collections.Generic;
using System.Data.SqlClient;

namespace PickingSoftware.Models
{
    public class Permissoes_List
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        public static List<Permissoes_List> GetPermicoes_List()
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "SELECT * FROM Permissoes_List";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            List<Permissoes_List> _tst = new List<Permissoes_List>();
            while (dr.Read())
            {
                _tst.Add(new Permissoes_List
                {
                    ID = (int)dr["ID"],
                    Nome = dr["Nome"].ToString()
                });
            }
            return _tst;
        }

        /// <summary>
        /// Adicionar
        /// </summary>
        /// <param name="_permicoeslist"></param>
        public static bool GetAdicionar(Permissoes_List _permicoeslist)
        {
            try
            {
                SqlConnection con =
                    new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
                con.Open();
                string query = "INSERT INTO Permissoes_List(" +
                    "Nome)" +
                    " VALUES (@Nome)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", _permicoeslist.Nome);
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
        /// <param name="_permicoesgerais"></param>
        public static bool GetEditar(Permissoes_List _permicoeslist)
        {
            try
            {
                SqlConnection con =
                    new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
                con.Open();
                string query = "UPDATE Permissoes_List SET" +
                    " Nome=@Nome" +
                    " WHERE ID=@ID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", _permicoeslist.ID);
                    cmd.Parameters.AddWithValue("@Nome", _permicoeslist.Nome);

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
                string query = "DELETE Permissoes_List" +
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
    }
}