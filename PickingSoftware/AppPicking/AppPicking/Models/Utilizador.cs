using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppPicking.Models
{
    internal class Utilizador
    {
        public int ID { get; set; }
        public int ID_Grupo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public static async Task<List<Utilizador>> GetUtilizadores()
        {
            using (HttpClient _client = new HttpClient())
            {
                var content = await _client.GetStringAsync("http://192.168.51.5:150/api/Utilizador/todas");

                Debug.WriteLine(content);

                return JsonConvert.DeserializeObject<List<Utilizador>>(content);
            }
        }

        public static async Task<bool> AddUtilizadores(Utilizador utilizador)
        {
            Debug.Write("||||||");
            Debug.Write("Inserir");
            Debug.Write("||||||");
            using (HttpClient _client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(utilizador);
                Debug.WriteLine("");
                Debug.WriteLine(json);
                Debug.WriteLine("");

                var content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync("http://192.168.51.5:150/api/utilizador/adicionar", content);

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

        public static async Task<bool> Userlogin(Utilizador utilizador)
        {
            using (HttpClient _client = new HttpClient())
            {

                var respomse = await _client.GetAsync("http://192.168.51.5:150/api/Utilizador/Login");

                if (respomse.IsSuccessStatusCode)
                    return true;

                else
                    return false;
            }
        }
    }
}
