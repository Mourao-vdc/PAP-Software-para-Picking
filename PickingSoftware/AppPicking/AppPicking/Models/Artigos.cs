using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
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

        public static async Task<List<Artigos>> AddArtigos()
        {
            using (HttpClient _client = new HttpClient())
            {
                var content = await _client.GetStringAsync("http://192.168.51.5:150/api/artigos/adicionar");

                Debug.WriteLine(content);

                return JsonConvert.DeserializeObject<List<Artigos>>(content);
            }
        }
    }
}
