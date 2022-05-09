using System.Collections.Generic;
using System.Data.SqlClient;

namespace PickingSoftware.Models
{
    public class Permissoes_Gerais
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string NomeG { get; set; }
        public int ID_Grupo { get; set; }
        public int ID_Permicoes { get; set; }
        public string Estado { get; set; }

        public static List<Permissoes_Gerais> GetPermicoes_Gerais(string _nome)
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "SELECT Permissoes_Gerais.ID, Permissoes_List.Nome, Grupos.Nome NomeG, Permissoes_Gerais.Estado FROM Permissoes_Gerais " +
                " JOIN Permissoes_List ON Permissoes_List.ID = Permissoes_Gerais.ID_Permissoes" +
                " JOIN Grupos ON Permissoes_Gerais.ID_Grupo = Grupos.ID WHERE Grupos.Nome='" + _nome + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            List<Permissoes_Gerais> _tst = new List<Permissoes_Gerais>();
            while (dr.Read())
            {
                _tst.Add(new Permissoes_Gerais
                {
                    ID = (int)dr["ID"],
                    Nome = dr["Nome"].ToString(),
                    NomeG = dr["NomeG"].ToString(),
                    Estado = dr["Estado"].ToString()
                });
            }
            return _tst;
        }

        /// <summary>
        /// Adicionar
        /// </summary>
        /// <param name="_permicoesgerais"></param>
        public static bool GetAdicionar(Permissoes_Gerais _permicoesgerais)
        {
            try
            {
                SqlConnection con =
                    new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
                con.Open();
                string query = "INSERT INTO Permissoes_Gerais(" +
                    "ID_Grupo,ID_Permicoes,Estado)" +
                    " VALUES (@ID_Grupo,@ID_Permicoes,@Estado)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID_Grupo", _permicoesgerais.ID_Grupo);
                    cmd.Parameters.AddWithValue("@ID_Permicoes", _permicoesgerais.ID_Permicoes);
                    cmd.Parameters.AddWithValue("@Estado", _permicoesgerais.Estado);
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
        public static bool GetEditar(Permissoes_Gerais _permicoesgerais)
        {
            try
            {
                SqlConnection con =
                    new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
                con.Open();
                string query = "UPDATE Permissoes_Gerais SET" +
                    " ID_Grupo=@ID_Grupo,ID_Permissoes=@ID_Permicoes,Estado=@Estado" +
                    " WHERE ID=@ID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", _permicoesgerais.ID);
                    cmd.Parameters.AddWithValue("@ID_Grupo", _permicoesgerais.ID_Grupo);
                    cmd.Parameters.AddWithValue("@ID_Permicoes", _permicoesgerais.ID_Permicoes);
                    cmd.Parameters.AddWithValue("@Estado", _permicoesgerais.Estado);
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
                string query = "DELETE Permissoes_Gerais" +
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