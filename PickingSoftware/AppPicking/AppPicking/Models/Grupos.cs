using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
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
                var content = await _client.GetStringAsync("http://192.168.51.5:150/swagger/ui/index");

                return JsonConvert.DeserializeObject<List<Grupos>>(content);
            }
        }

        public static async Task<string> IDNM2()
        {
            using (HttpClient _client = new HttpClient())
            {
                var content = await _client.GetAsync("http://192.168.51.5:150/api/grupos/getgrupo/");

                Debug.WriteLine("");
                Debug.WriteLine(content.StatusCode.ToString());
                Debug.WriteLine("");

                return JsonConvert.DeserializeObject<string>(await content.Content.ReadAsStringAsync());
            }
        }
    }
}
