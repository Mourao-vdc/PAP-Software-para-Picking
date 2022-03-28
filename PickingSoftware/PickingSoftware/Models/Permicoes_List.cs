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

        public static List<Permicoes_List> GetArtigos()
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
    }
}