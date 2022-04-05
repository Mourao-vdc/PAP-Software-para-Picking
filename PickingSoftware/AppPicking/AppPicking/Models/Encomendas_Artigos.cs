﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppPicking.Models
{
    internal class Encomendas_Artigos
    {
        public int ID { get; set; }
        public int ID_Encomendas { get; set; }
        public int ID_Artigos { get; set; }
        public string Cod_Barras { get; set; }
        public string Situacao { get; set; }
        public string Quant_artigos { get; set; }

        public static async Task<List<Encomendas_Artigos>> GetEncomendas_Artigos()
        {
            using (HttpClient _client = new HttpClient())
            {
                var content = await _client.GetStringAsync("http://192.168.51.5:150/api/encomendas/todas");

                Debug.WriteLine(content);

                return JsonConvert.DeserializeObject<List<Encomendas_Artigos>>(content);
            }
        }

        public static async Task<bool> AddEncomendas_Artigos(Encomendas_Artigos encomendas_Artigos)
        {
            Debug.Write("||||||");
            Debug.Write("Inserir");
            Debug.Write("||||||");
            using (HttpClient _client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(encomendas_Artigos);
                Debug.WriteLine("");
                Debug.WriteLine(json);
                Debug.WriteLine("");

                var content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync("http://192.168.51.5:150/api/Encomendas_Artigos/adicionar", content);

                Debug.WriteLine("");
                Debug.WriteLine("StatusCode");
                Debug.WriteLine(response.StatusCode.ToString());
                Debug.WriteLine(await response.Content.ReadAsStringAsync());
                Debug.WriteLine("");

                if (response.IsSuccessStatusCode)
                    return true;

                else
                    return false;
            }
        }
    }
}
