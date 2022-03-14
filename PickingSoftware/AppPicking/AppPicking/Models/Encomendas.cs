using System;
using System.Collections.Generic;
using System.Text;

namespace AppPicking.Models
{
    class Encomendas
    {
        public int ID { get; set; }
        public int ID_Artigos { get; set; }
        public string Cod_Barras { get; set; }
        public bool Situacao { get; set; }
        public int Quant_artigos { get; set; }
        
        public static async Task<List<Encomendas>> GetEncomendas()
        {
            using (HttpClient _client = new HttpClient())
            {
                var content = await _client.GetStringAsync("https://localhost:44351/api/Encomendas/Todas");

                return JsonConvert.DeserializeObject<List<Encomendas>>(content);
            }
        }
    }
}
