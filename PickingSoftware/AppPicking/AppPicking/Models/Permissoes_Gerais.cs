using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppPicking.Models
{
    internal class Permissoes_Gerais
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string NomeG { get; set; }
        public int ID_Grupo { get; set; }
        public int ID_Permicoes { get; set; }
        public string Estado { get; set; }

        public static async Task<List<Permissoes_Gerais>> GetPermicoes_Gerais(string _nome)
        {
            using (HttpClient _client = new HttpClient())
            {
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Models.Utilizador.token);

                var content = await _client.GetAsync("http://192.168.51.5:150/api/Permissoes_Gerais/todas/" + _nome);

                Debug.WriteLine("");
                Debug.WriteLine(content.StatusCode.ToString());
                Debug.WriteLine(await content.Content.ReadAsStringAsync());
                Debug.WriteLine("");

                if (content.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<List<Permissoes_Gerais>>(await content.Content.ReadAsStringAsync());

                else
                    return new List<Permissoes_Gerais>();
            }
        }
    }
}
