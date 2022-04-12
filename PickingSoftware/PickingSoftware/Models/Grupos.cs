using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PickingSoftware.Models
{
    public class Grupos
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        public static List<Grupos> GetGrupos()
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "SELECT * FROM Grupos";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            List<Grupos> _tst = new List<Grupos>();
            while (dr.Read())
            {
                _tst.Add(new Grupos
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
        /// <param name="_grupos"></param>
        public static void GetAdicionar(Grupos _grupos)
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "INSERT INTO Grupos(" +
                "ID,Nome)" +
                " VALUES (@ID,@Nome)";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                //cmd.Parameters.AddWithValue("@ID", _artigo.ID);
                cmd.Parameters.AddWithValue("@ID", _grupos.ID);
                cmd.Parameters.AddWithValue("@Nome", _grupos.Nome);
                cmd.ExecuteScalar();

                con.Close();
            }

        }

        /// <summary>
        /// Editar
        /// </summary>
        /// <param name="_grupos"></param>
        public static void GetEditar(Grupos _grupos)
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "UPDATE Grupos SET" +
                " Nome=@Nome" +
                " WHERE ID=@ID";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ID", _grupos.ID);
                cmd.Parameters.AddWithValue("@Nome", _grupos.Nome);
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
            string query = "DELETE Grupos" +
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