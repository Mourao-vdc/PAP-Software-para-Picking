using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppPicking.Models
{
    internal class Grupos
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        public static async Task<List<Grupos>> GetEncomendas()
        {
            using (HttpClient _client = new HttpClient())
            {
                var content = await _client.GetStringAsync("http://192.168.51.5:150/swagger/ui/index");

                return JsonConvert.DeserializeObject<List<Grupos>>(content);
            }
        }
    }
}
