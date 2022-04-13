using System.Collections.Generic;
using System.Data.SqlClient;

namespace PickingSoftware.Models
{
    public class Utilizador
    {
        public int ID { get; set; }
        public int ID_Grupo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public static List<Utilizador> GetUtilizadores()
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "SELECT ID, ID_GRUPO, Nome, Email from Utilizador";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            List<Utilizador> _tst = new List<Utilizador>();
            while (dr.Read())
            {
                _tst.Add(new Utilizador
                {
                    ID = (int)dr["ID"],
                    ID_Grupo = (int)dr["ID_Grupo"],
                    Nome = dr["Nome"].ToString(),
                    Email = dr["Email"].ToString(),
                    //Password = dr["Password"].ToString()
                });
            }
            return _tst;
        }

        /// <summary>
        /// Adicionar
        /// </summary>
        /// <param name="_utilizador"></param>
        public static void GetAdicionar(Utilizador _utilizador)
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "INSERT INTO Utilizador(" +
                "Nome,Email,Password)" +
                " VALUES (@Nome,@Email,@Password)";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Nome", _utilizador.Nome);
                cmd.Parameters.AddWithValue("@Email", _utilizador.Email);
                cmd.Parameters.AddWithValue("@Password", _utilizador.Password);
                cmd.ExecuteScalar();

                con.Close();
            }

        }

        /// <summary>
        /// Editar
        /// </summary>
        /// <param name="_utilizador"></param>

        public static void GetEditar(Utilizador _utilizador)
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "UPDATE Utilizador SET" +
                " ID_Grupo=@ID_Grupo,Nome=@Nome,Email=@Email,Password=@Password" +
                " WHERE ID=@ID";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ID", _utilizador.ID);
                cmd.Parameters.AddWithValue("@ID_Grupo", _utilizador.ID_Grupo);
                cmd.Parameters.AddWithValue("@Nome", _utilizador.Nome);
                cmd.Parameters.AddWithValue("@Email", _utilizador.Email);
                cmd.Parameters.AddWithValue("@Password", _utilizador.Password);
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
            string query = "DELETE Utilizador" +
                " WHERE ID=@ID";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ID",id);
                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="_utilizador"></param>
        public static bool UserLogin(Utilizador _utilizador)
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();

            using (SqlCommand cmd = new SqlCommand("Utilizador_login",con))
            {
                cmd.Parameters.AddWithValue("@Nome", _utilizador.Nome);
                cmd.Parameters.AddWithValue("@Password", _utilizador.Password);
            }

            return true;
        }

        /// <summary>
        /// Verify Email
        /// </summary>
        /// <param name="_utilizador"></param>
        public static bool UserVerifyEmail(Utilizador _utilizador)
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();

            using (SqlCommand cmd = new SqlCommand("verify_emails", con))
            {
                cmd.Parameters.AddWithValue("@email", _utilizador.Email);
            }

            return true;
        }

        /// <summary>
        /// Verify Nome
        /// </summary>
        /// <param name="_utilizador"></param>
        public static bool UserVerifyNome(Utilizador _utilizador)
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();

            using (SqlCommand cmd = new SqlCommand("verify_nome", con))
            {
                cmd.Parameters.AddWithValue("@nome", _utilizador.Nome);
            }

            return true;
        }
    }
}