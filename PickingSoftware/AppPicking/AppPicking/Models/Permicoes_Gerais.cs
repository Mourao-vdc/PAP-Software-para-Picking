using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppPicking.Models
{
    internal class Permicoes_Gerais
    {
        public int ID { get; set; }
        public int ID_Grupo { get; set; }
        public int ID_Permicoes { get; set; }
        public string Estado { get; set; }

        public static async Task<List<Permicoes_Gerais>> GetPermicoes_Gerais()
        {
            using (HttpClient _client = new HttpClient())
            {
                var content = await _client.GetStringAsync("http://192.168.51.5:150/swagger/ui/index");

                return JsonConvert.DeserializeObject<List<Permicoes_Gerais>>(content);
            }
        }
    }
}
