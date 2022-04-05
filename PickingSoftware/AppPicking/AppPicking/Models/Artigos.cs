﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppPicking.Models
{
    class Artigos
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cod_Barras { get; set; }

        public static async Task<List<Artigos>> GetArtigos()
        {
            using (HttpClient _client = new HttpClient())
            {
                var content = await _client.GetStringAsync("http://192.168.51.5:150/api/artigos/todas");

                Debug.WriteLine(content);

                return JsonConvert.DeserializeObject<List<Artigos>>(content);
            }
        }

        public static async Task<bool> AddArtigos(Artigos artigos)
        {
            Debug.Write("||||||");
            Debug.Write("Inserir");
            Debug.Write("||||||");
            using (HttpClient _client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(artigos);
                Debug.WriteLine("");
                Debug.WriteLine(json);
                Debug.WriteLine("");

                var content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync("http://192.168.51.5:150/api/artigos/adicionar", content);

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

        public static async Task<bool> EditArtigos(Artigos artigos)
        {
            Debug.Write("||||||");
            Debug.Write("Editar");
            Debug.Write("||||||");
            using (HttpClient _client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(artigos);
                Debug.WriteLine("");
                Debug.WriteLine(json);
                Debug.WriteLine("");

                var content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PutAsync("http://192.168.51.5:150/api/artigos/editar", content);

                Debug.WriteLine("");
                Debug.WriteLine("StatusCode");
                Debug.WriteLine(response.StatusCode.ToString());
                Debug.WriteLine("");

                if (response.IsSuccessStatusCode)
                    return true;

                else
                    return false;
            }
        }

        public static async Task<bool> DellArtigos(int id)
        {
            using (HttpClient _client = new HttpClient())
            {
                /*var json = JsonConvert.SerializeObject(artigos);
                Debug.WriteLine("");
                Debug.WriteLine(json);
                Debug.WriteLine("");

                var content =
                    new StringContent(json, Encoding.UTF8, "application/json");*/
                var response = await _client.DeleteAsync("http://192.168.51.5:150/api/artigos/eliminar/" + id);

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
