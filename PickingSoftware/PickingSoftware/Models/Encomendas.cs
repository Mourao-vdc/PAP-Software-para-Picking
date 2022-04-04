using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlServerCe;
using System.Data.SqlClient;

namespace PickingSoftware.Models
{
    public class Encomendas
    {
        public int ID { get; set; }
        public int ID_Utilizadores { get; set; }
        public string Data { get; set; }


        public static List<Encomendas> GetEncomendas()
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "SELECT * FROM Encomendas";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            List<Encomendas> _tst = new List<Encomendas>();
            while (dr.Read())
            {
                _tst.Add(new Encomendas
                {
                    ID = (int)dr["ID"],
                    ID_Utilizadores = (int)dr["ID_Utilizadores"],
                    Data = dr["Data"].ToString()
                });
            }
            return _tst;
        }

        /// <summary>
        /// Adicionar
        /// </summary>
        /// <param name="_encomendas"></param>
        public static void GetAdicionar(Encomendas _encomendas)
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "INSERT INTO Encomendas(" +
                "ID_Utilizadores,Data)" +
                "VALUES (@ID_Utilizadores,@Data)";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                //cmd.Parameters.AddWithValue("@ID", _artigo.ID);
                cmd.Parameters.AddWithValue("@ID_Utilizadores", _encomendas.ID_Utilizadores);
                cmd.Parameters.AddWithValue("@Data", _encomendas.Data);
                cmd.ExecuteScalar();

                con.Close();
            }

        }

        public static void GetEditar(Encomendas _encomendas)
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "UPDATE Encomendas SET(" +
                "ID_Utilizadores=@ID_Utilizadores,Data=@Data)" +
                "WHERE ID=@ID";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ID_Utilizadores", _encomendas.ID_Utilizadores);
                cmd.Parameters.AddWithValue("@Data", _encomendas.Data);
                cmd.ExecuteScalar();

                con.Close();
            }

        }

        public static void GetEliminar(Encomendas _encomendas)
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "DELETE Encomendas" +
                "WHERE ID=@ID";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.ExecuteNonQuery();

                con.Close();
            }
        }
    }
}