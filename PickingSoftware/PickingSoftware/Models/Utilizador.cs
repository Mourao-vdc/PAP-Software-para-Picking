using AppPicking.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PickingSoftware.Models
{
    public class Utilizador
    {
        public int ID { get; set; }
        public int ID_Grupo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// Show Utilizadores
        /// </summary>
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
                });
            }
            return _tst;
        }

        public static Utilizador GetUtilizadorNome(string _nome)
        {
            try
            {
                SqlConnection con =
                    new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
                con.Open();
                string query = "SELECT ID, ID_GRUPO, Nome, Email from Utilizador where nome like '" + _nome.TrimEnd().TrimStart() + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Debug.WriteLine("");
                        Debug.WriteLine("NOME");
                        Debug.WriteLine(dr["nome"].ToString());
                        Debug.WriteLine("");

                        return new Utilizador
                        {
                            ID = (int)dr["ID"],
                            ID_Grupo = (int)dr["ID_Grupo"],
                            Nome = dr["Nome"].ToString(),
                            Email = dr["Email"].ToString(),
                        };
                    }
                }

                return new Utilizador();
            }

            catch (Exception ex)
            {
                return new Utilizador()
                {
                    Nome = ex.ToString()
                };
            }
        }

        /// <summary>
        /// Adicionar
        /// </summary>
        /// <param name="_utilizador"></param>
        public static bool GetAdicionar(Utilizador _utilizador)
        {
            try
            {
                SqlConnection con =
                    new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
                con.Open();
                string query = "INSERT INTO Utilizador(" +
                    "ID_Grupo,Nome,Email,Password)" +
                    " VALUES (@ID_Grupo,@Nome,@Email,@Password)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID_Grupo", _utilizador.ID_Grupo);
                    cmd.Parameters.AddWithValue("@Nome", _utilizador.Nome);
                    cmd.Parameters.AddWithValue("@Email", _utilizador.Email);
                    cmd.Parameters.AddWithValue("@Password", _utilizador.Password);
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
        /// <param name="_utilizador"></param>

        public static bool GetEditar(Utilizador _utilizador)
        {
            try
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
                string query = "DELETE Utilizador" +
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
        /// Login
        /// </summary>
        /// <param name="_utilizador"></param>
        public static bool UserLogin(Utilizador _utilizador)
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");

            using (SqlCommand cmd = new SqlCommand("Utilizador_login",con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@Nome", _utilizador.Nome);
                cmd.Parameters.AddWithValue("@Password", Cryptography.Encrypt(_utilizador.Password));
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Verify Email
        /// </summary>
        /// <param name="email"></param>
        public static bool UserVerifyEmail(string email)
        {
            SqlConnection con =
    new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            using (SqlCommand cmd = new SqlCommand("verify_emails", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@email", email);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Verify Nome
        /// </summary>
        /// <param name="nome"></param>
        public static bool UserVerifyNome(string nome)
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            using (SqlCommand cmd = new SqlCommand("verify_nome", con))
            { 
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@nome", nome);
                SqlDataReader rd = cmd.ExecuteReader();
                if(rd.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Send Email
        /// </summary>
        public static bool SendEmail(string email)
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            string query = "SELECT Nome, Password FROM Utilizador WHERE Email=@Email";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@Email", email);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}