using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppPicking.Models
{
    internal class Grupos
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        public static async Task<List<Grupos>> GetGrupos()
        {
            using (HttpClient _client = new HttpClient())
            {
                var content = await _client.GetStringAsync(Utils.sEndereco + "/api/grupos/todas");

                return JsonConvert.DeserializeObject<List<Grupos>>(content);
            }
        }

        public static async Task<string> EditGrupo(Artigos _grupos)
        {
            Debug.Write("||||||");
            Debug.Write("Editar");
            Debug.Write("||||||");
            using (HttpClient _client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(_grupos);
                Debug.WriteLine("");
                Debug.WriteLine(json);
                Debug.WriteLine("");

                var content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PutAsync(Utils.sEndereco + "/api/grupos/editar", content);

                Debug.WriteLine("");
                Debug.WriteLine("StatusCode");
                Debug.WriteLine(response.StatusCode.ToString());
                Debug.WriteLine("");

                return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
            }
        }

        public static async Task<int> IDNM2(string _Nome)
        {
            using (HttpClient _client = new HttpClient())
            {
                var content = await _client.GetAsync(Utils.sEndereco + "/api/grupos/getgrupo/" + _Nome);

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
