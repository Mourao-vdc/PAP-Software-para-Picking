﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PickingSoftware.Models
{
    public class Permicoes_List
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        public static List<Permicoes_List> GetPermicoes_List()
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "SELECT * FROM Permicoes_List";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            List<Permicoes_List> _tst = new List<Permicoes_List>();
            while (dr.Read())
            {
                _tst.Add(new Permicoes_List
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
        public static void GetAdicionar(Permicoes_List _permicoeslist)
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "INSERT INTO Permicoes_List(" +
                "Nome)" +
                " VALUES (@Nome)";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Nome", _permicoeslist.Nome);
                cmd.ExecuteScalar();

                con.Close();
            }

        }

        /// <summary>
        /// Editar
        /// </summary>
        /// <param name="_permicoesgerais"></param>
        public static void GetEditar(Permicoes_List _permicoeslist)
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano;User ID=estagio;Password=Pass.123");
            con.Open();
            string query = "UPDATE Permicoes_List SET(" +
                "Nome=@Nome)" +
                " WHERE ID=@ID";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Nome", _permicoeslist.Nome);

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
            string query = "DELETE Permicoes_List" +
                " WHERE ID=@ID";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ID",id);
                cmd.ExecuteNonQuery();

                con.Close();
            }
        }
    }
}