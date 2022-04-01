using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppPicking.Models
{
    internal class Encomendas_Artigos
    {
        public int ID { get; set; }
        public int ID_Encomendas { get; set; }
        public int ID_Artigos { get; set; }
        public string Cod_Barras { get; set; }
        public string Situacao { get; set; }
        public string Quant_artigos { get; set; }

        public static async Task<List<Encomendas_Artigos>> GetEncomendas_Artigos()
        {
            using (HttpClient _client = new HttpClient())
            {
                var content = await _client.GetStringAsync("http://192.168.51.5:150/api/encomendas/todas");

                return JsonConvert.DeserializeObject<List<Encomendas_Artigos>>(content);
            }
        }
    }
}
