﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PickingSoftware.Models
{
    public class Permicoes_Gerais
    {
        public int ID { get; set; }
        public int ID_Grupo { get; set; }
        public int ID_Permicoes { get; set; }
        public string Estado { get; set; }

        public static List<Permicoes_Gerais> GetPermicoes_Gerais()
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "SELECT * FROM Permicoes_Gerais";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            List<Permicoes_Gerais> _tst = new List<Permicoes_Gerais>();
            while (dr.Read())
            {
                _tst.Add(new Permicoes_Gerais
                {
                    ID = (int)dr["ID"],
                    ID_Grupo = (int)dr["ID_Grupo"],
                    ID_Permicoes = (int)dr["ID_Permicoes"],
                    Estado = dr["Estado"].ToString()
                });
            }
            return _tst;
        }

        public static void GetAdicionar(Permicoes_Gerais _permicoesgerais)
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "INSERT INTO Permicoes_Gerais(" +
                "ID_Grupo,ID_Permicoes,Estado)" +
                "VALUES (@ID_Grupo,@ID_Permicoes,@Estado)";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ID_Grupo", _permicoesgerais.ID_Grupo);
                cmd.Parameters.AddWithValue("@ID_Permicoes", _permicoesgerais.ID_Permicoes);
                cmd.Parameters.AddWithValue("@Estado", _permicoesgerais.Estado);
                cmd.ExecuteScalar();

                con.Close();
            }

        }

        public static void GetEditar(Permicoes_Gerais _permicoesgerais)
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "UPDATE Permicoes_Gerais SET(" +
                "ID_Grupo=@ID_Grupo,ID_Permicoes=@ID_Permicoes,Estado=@Estado)" +
                "WHERE ID=@ID";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ID_Grupo", _permicoesgerais.ID_Grupo);
                cmd.Parameters.AddWithValue("@ID_Permicoes", _permicoesgerais.ID_Permicoes);
                cmd.Parameters.AddWithValue("@Estado", _permicoesgerais.Estado);
                cmd.ExecuteScalar();

                con.Close();
            }

        }

        public static void GetEliminar(Permicoes_Gerais _permicoesgerais)
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "DELETE Permicoes_Gerais" +
                "WHERE ID=@ID";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.ExecuteNonQuery();

                con.Close();
            }
        }
    }
}