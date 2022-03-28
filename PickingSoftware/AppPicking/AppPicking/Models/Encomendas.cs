using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppPicking.Models
{
    public class Encomendas
    {
        public int ID { get; set; }
        public int ID_Utilizadores { get; set; }
        public string Data { get; set; }

        public static async Task<List<Encomendas>> GetEncomendas()
        {
            using (HttpClient _client = new HttpClient())
            {
                var content = await _client.GetStringAsync("http://192.168.51.5:150/api/encomendas/todas");

                Debug.WriteLine(content);

                return JsonConvert.DeserializeObject<List<Encomendas>>(content);
            }
        }
    }
}
