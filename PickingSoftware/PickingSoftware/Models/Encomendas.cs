using System.Collections.Generic;
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

        public static List<Encomendas> GetEncomendastodas()
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "SELECT Encomendas.ID, Utilizador.Nome, FORMAT (Data, 'dd/MM/yyyy ') as Data FROM Encomendas" +
                " JOIN Utilizador" +
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

        public static List<Encomendas> GetEncomendas(string _nome)
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "SELECT Encomendas.ID, Utilizador.Nome, FORMAT (Data, 'dd/MM/yyyy ') as Data FROM Encomendas" +
                " JOIN Utilizador" +
                " ON Utilizador.ID = Encomendas.ID_Utilizadores WHERE Utilizador.Nome = '" + _nome + "'";
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
        public static bool GetAdicionar(Encomendas _encomendas)
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

                    cmd.Parameters.AddWithValue("@ID", _encomendas.ID);
                    cmd.Parameters.AddWithValue("@ID_Utilizadores", _encomendas.ID_Utilizadores);
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
                    cmd.Parameters.AddWithValue("@ID_Utilizadores", _encomendas.ID_Utilizadores);
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

        public static int GetMAXID()
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "select max(ID) ID from Encomendas";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            List<Encomendas> _tst = new List<Encomendas>();
            while (dr.Read())
            {
                return (int)dr["ID"];
            }

            return -1;
        }

        public static int IDNM2(string _Nome)
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "SELECT ID FROM Utilizador WHERE Nome like '" + _Nome + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            List<Utilizador> _tst = new List<Utilizador>();
            while (dr.Read())
            {
                return (int)dr["ID"];
            }

            return -1;
        }
    }
}