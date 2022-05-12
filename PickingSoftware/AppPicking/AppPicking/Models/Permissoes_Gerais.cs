using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
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

        public static async Task<string> GetEditarEstado(Permissoes_Gerais _estado)
        {
            Debug.Write("||||||");
            Debug.Write("Editar");
            Debug.Write("||||||");
            using (HttpClient _client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(_estado);
                Debug.WriteLine("");
                Debug.WriteLine(json);
                Debug.WriteLine("");

                var content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PutAsync("http://192.168.51.5:150/api/Permissoes_Gerais/editarestado", content);

                Debug.WriteLine("");
                Debug.WriteLine("StatusCode");
                Debug.WriteLine(response.StatusCode.ToString());
                Debug.WriteLine("");

                return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
            }
        }

        public static async Task<List<string>> PermissionsVerify(string _grupo)
        {
            using (HttpClient _client = new HttpClient())
            {
                var response = await _client.GetAsync("http://192.168.51.5:150/api/Permissoes_Gerais/PermissionsVerify/" + _grupo);

                Debug.WriteLine(response.StatusCode.ToString());

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<List<string>>(await response.Content.ReadAsStringAsync());

                else
                    return new List<string>();
            }
        }

        public static async Task<bool> LoginView(string _PermissionNome)
        {
            using (HttpClient _client = new HttpClient())
            {
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Models.Utilizador.token);

                var response = await _client.GetAsync("http://192.168.51.5:150/api/Permissoes_Gerais/LoginView/" + _PermissionNome);

                Debug.WriteLine("");
                Debug.WriteLine(await response.Content.ReadAsStringAsync());
                Debug.WriteLine(response.StatusCode.ToString());
                Debug.WriteLine("");

                if (response.IsSuccessStatusCode)
                    return true;

                else
                    return false;
            }
        }
    }
}
