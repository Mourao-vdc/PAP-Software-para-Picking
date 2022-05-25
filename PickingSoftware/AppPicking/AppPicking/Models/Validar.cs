using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppPicking.Models
{
    internal class Validar
    {
        public int ID { get; set; }
        public int ID_Utilizadores { get; set; }
        public string Nome { get; set; }
        public string Data { get; set; }
        public int ID2 { get; set; }
        public int ID_Encomendas { get; set; }
        public string Nome2 { get; set; }
        public string Cod_Barras { get; set; }
        public string Estado { get; set; }
        public int Quant_artigos_cliente { get; set; }

        public static async Task<List<Validar>> GetValidar(string _nome)
        {
            using (HttpClient _client = new HttpClient())
            {
                var content = await _client.GetAsync(Utils.sEndereco + "/api/validar/todas/" + _nome);

                Debug.WriteLine("");
                Debug.WriteLine(content.StatusCode.ToString());
                Debug.WriteLine("");

                if (content.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<List<Validar>>(await content.Content.ReadAsStringAsync());

                else
                    return new List<Validar>();
            }
        }

        public static async Task<List<Validar>> GetValidarDetalhes(int _idencomenda)
        {
            using (HttpClient _client = new HttpClient())
            {
                var content = await _client.GetAsync(Utils.sEndereco + "/api/validar/detalhes/" + _idencomenda);

                Debug.WriteLine("");
                Debug.WriteLine(content.StatusCode.ToString());
                Debug.WriteLine("");

                if (content.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<List<Validar>>(await content.Content.ReadAsStringAsync());

                else
                    return new List<Validar>();
            }
        }

        public static async Task<string> GetValidarEstado(Validar _validar)
        {
            Debug.Write("||||||");
            Debug.Write("Editar");
            Debug.Write("||||||");
            using (HttpClient _client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(_validar);
                Debug.WriteLine("");
                Debug.WriteLine(json);
                Debug.WriteLine("");

                var content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PutAsync(Utils.sEndereco + "/api/validar/estado", content);

                Debug.WriteLine("");
                Debug.WriteLine("StatusCode");
                Debug.WriteLine(response.StatusCode.ToString());
                Debug.WriteLine("");

                return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
            }
        }

        public static async Task<List<Validar>> GetValidada()
        {
            using (HttpClient _client = new HttpClient())
            {
                var content = await _client.GetAsync(Utils.sEndereco + "/api/validar/validadas");

                Debug.WriteLine("");
                Debug.WriteLine(content.StatusCode.ToString());
                Debug.WriteLine("");

                if (content.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<List<Validar>>(await content.Content.ReadAsStringAsync());

                else
                    return new List<Validar>();
            }
        }
    }
}
