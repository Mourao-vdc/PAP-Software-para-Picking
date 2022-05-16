using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppPicking.Models
{
    public class Encomendas
    {
        public int ID { get; set; }
        public int ID_Utilizadores { get; set; }
        public string Nome { get; set; }
        public string Data { get; set; }
        public string Estado { get; set; }

        public static async Task<List<Encomendas>> GetEncomendastodas()
        {
            using (HttpClient _client = new HttpClient())
            {
                var content = await _client.GetAsync("http://192.168.51.5:150/api/encomendas/todas");

                Debug.WriteLine("");
                Debug.WriteLine(content.StatusCode.ToString());
                Debug.WriteLine("");

                if (content.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<List<Encomendas>>(await content.Content.ReadAsStringAsync());

                else
                    return new List<Encomendas>();
            }
        }

        public static async Task<List<Encomendas>> GetEncomendas(string _nome)
        {
            using (HttpClient _client = new HttpClient())
            {
                var content = await _client.GetAsync("http://192.168.51.5:150/api/encomendas/todas/" + _nome);

                Debug.WriteLine("");
                Debug.WriteLine(content.StatusCode.ToString());
                Debug.WriteLine("");

                if (content.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<List<Encomendas>>(await content.Content.ReadAsStringAsync());

                else
                    return new List<Encomendas>();
            }
        }

        public static async Task<int> GetMAXID()
        {
            using (HttpClient _client = new HttpClient())
            {
                var content = await _client.GetAsync("http://192.168.51.5:150/api/encomendas/maxid");

                Debug.WriteLine("");
                Debug.WriteLine(content.StatusCode.ToString());
                Debug.WriteLine("");

                if (content.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<int>(await content.Content.ReadAsStringAsync());

                else
                    return -1;
            }
        }

        public static async Task<string> AddEncomendas(Encomendas encomendas)
        {
            Debug.Write("||||||");
            Debug.Write("Inserir");
            Debug.Write("||||||");
            using (HttpClient _client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(encomendas);
                Debug.WriteLine("");
                Debug.WriteLine(json);
                Debug.WriteLine("");

                var content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync("http://192.168.51.5:150/api/encomendas/adicionar", content);

                Debug.WriteLine("");
                Debug.WriteLine("StatusCode");
                Debug.WriteLine(response.StatusCode.ToString());
                Debug.WriteLine(await response.Content.ReadAsStringAsync());
                Debug.WriteLine("");

                return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
            }
        }

        public static async Task<string> EditEncomendas(Encomendas encomendas)
        {
            Debug.Write("||||||");
            Debug.Write("Editar");
            Debug.Write("||||||");
            using (HttpClient _client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(encomendas);
                Debug.WriteLine("");
                Debug.WriteLine(json);
                Debug.WriteLine("");

                var content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PutAsync("http://192.168.51.5:150/api/encomendas/editar", content);

                Debug.WriteLine("");
                Debug.WriteLine("StatusCode");
                Debug.WriteLine(response.StatusCode.ToString());
                Debug.WriteLine("");

                return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
            }
        }

        public static async Task<string> DellEncomenda(int id)
        {
            using (HttpClient _client = new HttpClient())
            {
                /*var json = JsonConvert.SerializeObject(artigos);
                Debug.WriteLine("");
                Debug.WriteLine(json);
                Debug.WriteLine("");

                var content =
                    new StringContent(json, Encoding.UTF8, "application/json");*/
                var response = await _client.DeleteAsync("http://192.168.51.5:150/api/encomendas/eliminar/" + id);

                Debug.WriteLine("");
                Debug.WriteLine("StatusCode");
                Debug.WriteLine(response.StatusCode.ToString());
                Debug.WriteLine(await response.Content.ReadAsStringAsync());
                Debug.WriteLine("");

                return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
            }
        }

        public static async Task<int> IDNM2(string _Nome)
        {
            using (HttpClient _client = new HttpClient())
            {
                var content = await _client.GetAsync("http://192.168.51.5:150/api/Encomendas/idnm2/" + _Nome);

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
