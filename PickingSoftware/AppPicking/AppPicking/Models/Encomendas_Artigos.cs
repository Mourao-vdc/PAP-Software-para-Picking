using Newtonsoft.Json;
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
        public string Nome { get; set; }
        public int ID_Artigos { get; set; }
        public string Cod_Barras { get; set; }
        public string Situacao { get; set; }
        public int Quant_artigos { get; set; }

        public static async Task<List<Encomendas_Artigos>> GetEncomendas_Artigos()
        {
            using (HttpClient _client = new HttpClient())
            {
                var content = await _client.GetStringAsync("http://192.168.51.5:150/api/Encomendas_Artigos/todas");

                Debug.WriteLine(content);

                return JsonConvert.DeserializeObject<List<Encomendas_Artigos>>(content);
            }
        }

        public static async Task<string> AddEncomendas_Artigos(Encomendas_Artigos encomendas_Artigos)
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

                return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
            }
        }

        public static async Task<string> EditEncomendas_Artigos(Encomendas_Artigos encomendas_Artigos)
        {
            Debug.Write("||||||");
            Debug.Write("Editar");
            Debug.Write("||||||");
            using (HttpClient _client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(encomendas_Artigos);
                Debug.WriteLine("");
                Debug.WriteLine(json);
                Debug.WriteLine("");

                var content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PutAsync("http://192.168.51.5:150/api/Encomendas_Artigos/editar", content);

                Debug.WriteLine("");
                Debug.WriteLine("StatusCode");
                Debug.WriteLine(response.StatusCode.ToString());
                Debug.WriteLine("");

                return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
            }
        }

        public static async Task<string> DellEncomendas_Artigos(int id)
        {
            using (HttpClient _client = new HttpClient())
            {
                /*var json = JsonConvert.SerializeObject(artigos);
                Debug.WriteLine("");
                Debug.WriteLine(json);
                Debug.WriteLine("");

                var content =
                    new StringContent(json, Encoding.UTF8, "application/json");*/
                var response = await _client.DeleteAsync("http://192.168.51.5:150/api/Encomendas_Artigos/eliminar/" + id);

                Debug.WriteLine("");
                Debug.WriteLine("StatusCode");
                Debug.WriteLine(response.StatusCode.ToString());
                Debug.WriteLine(await response.Content.ReadAsStringAsync());
                Debug.WriteLine("");

                return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
            }
        }

        public static async Task<bool> EditEstado(Encomendas_Artigos encomendas_Artigos)
        {
            Debug.Write("||||||");
            Debug.Write("Editar");
            Debug.Write("||||||");
            using (HttpClient _client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(encomendas_Artigos);
                Debug.WriteLine("");
                Debug.WriteLine(json);
                Debug.WriteLine("");

                var content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PutAsync("http://192.168.51.5:150/api/Encomendas_Artigos/estado", content);

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

        public static async Task<string> EditQuantSituacao(Encomendas_Artigos encomendas_Artigos)
        {
            Debug.Write("||||||");
            Debug.Write("Editar");
            Debug.Write("||||||");
            using (HttpClient _client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(encomendas_Artigos);
                Debug.WriteLine("");
                Debug.WriteLine(json);
                Debug.WriteLine("");

                var content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PutAsync("http://192.168.51.5:150/api/Encomendas_Artigos/EditQuantSituacao", content);

                Debug.WriteLine("");
                Debug.WriteLine("StatusCode");
                Debug.WriteLine(response.StatusCode.ToString());
                Debug.WriteLine(await response.Content.ReadAsStringAsync());
                Debug.WriteLine("");

                return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
            }
        }

        public static async Task<int> IDNM(string _Nome)
        {
            using (HttpClient _client = new HttpClient())
            {
                var content = await _client.GetAsync("http://192.168.51.5:150/api/Encomendas_Artigos/idnm/" + _Nome);

                Debug.WriteLine("");
                Debug.WriteLine(content.StatusCode.ToString());
                Debug.WriteLine("");

                if (content.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<int>(await content.Content.ReadAsStringAsync());

                else
                    return -1;
            }
        }
    }
}
