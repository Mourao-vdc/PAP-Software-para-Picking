using Newtonsoft.Json;
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
                var content = await _client.GetStringAsync(Utils.sEndereco + "/api/artigos/todas");

                Debug.WriteLine(content);

                return JsonConvert.DeserializeObject<List<Artigos>>(content);
            }
        }

        public static async Task<string> AddArtigos(Artigos artigos)
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
                var response = await _client.PostAsync(Utils.sEndereco + "/api/artigos/adicionar", content);

                Debug.WriteLine("");
                Debug.WriteLine("StatusCode");
                Debug.WriteLine(response.StatusCode.ToString());
                Debug.WriteLine(await response.Content.ReadAsStringAsync());
                Debug.WriteLine("");

                return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());

                /*if (response.IsSuccessStatusCode)
                return true;

                else
                return false;*/
            }
        }

        public static async Task<string> EditArtigos(Artigos artigos)
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
                var response = await _client.PutAsync(Utils.sEndereco + "/api/artigos/editar", content);

                Debug.WriteLine("");
                Debug.WriteLine("StatusCode");
                Debug.WriteLine(response.StatusCode.ToString());
                Debug.WriteLine("");

                return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
            }
        }

        public static async Task<string> DellArtigos(int id)
        {
            using (HttpClient _client = new HttpClient())
            {
                /*var json = JsonConvert.SerializeObject(artigos);
                Debug.WriteLine("");
                Debug.WriteLine(json);
                Debug.WriteLine("");

                var content =
                    new StringContent(json, Encoding.UTF8, "application/json");*/
                var response = await _client.DeleteAsync(Utils.sEndereco + "/api/artigos/eliminar/" + id);

                Debug.WriteLine("");
                Debug.WriteLine("StatusCode");
                Debug.WriteLine(response.StatusCode.ToString());
                Debug.WriteLine(await response.Content.ReadAsStringAsync());
                Debug.WriteLine("");

                return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
            }
        }

        public static async Task<List<Artigos>> GetCodBarras(string _CodBarras)
        {
            using (HttpClient _client = new HttpClient())
            {
                var content = await _client.GetStringAsync(Utils.sEndereco + "/api/artigos/CodBarras/" + _CodBarras);

                Debug.WriteLine(content);

                return JsonConvert.DeserializeObject<List<Artigos>>(content);
            }
        }

        public static async Task<string> CodBarras(string _Nome)
        {
            using (HttpClient _client = new HttpClient())
            {
                var content = await _client.GetAsync(Utils.sEndereco + "/api/artigos/GetNome/" + _Nome);

                Debug.WriteLine("");
                Debug.WriteLine(content.StatusCode.ToString());
                Debug.WriteLine("");

                if (content.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<string>(await content.Content.ReadAsStringAsync());

                else
                    return content.ToString();
            }
        }
    }
}
