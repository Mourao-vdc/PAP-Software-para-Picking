using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppPicking.Models
{
    internal class Utilizador
    {
        public int ID { get; set; }
        public int ID_Grupo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public static async Task<Utilizador> perfil()
        {

            using (HttpClient _client = new HttpClient())
            {
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var content = await _client.GetAsync("http://192.168.51.5:150/api/utilizador/perfil");

                Debug.WriteLine("");
                Debug.WriteLine(content.StatusCode.ToString());
                Debug.WriteLine(await content.Content.ReadAsStringAsync());
                Debug.WriteLine("");

                if (content.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Utilizador>(await content.Content.ReadAsStringAsync());

                else
                    return new Utilizador();
            }
        }

        public static async Task<List<Utilizador>> GetUtilizadores()
        {
            using (HttpClient _client = new HttpClient())
            {
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var content = await _client.GetAsync("http://192.168.51.5:150/api/utilizador/todas");

                Debug.WriteLine("");
                Debug.WriteLine(content.StatusCode.ToString());
                Debug.WriteLine("");

                if (content.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<List<Utilizador>>(await content.Content.ReadAsStringAsync());

                else
                    return new List<Utilizador>();
            }
        }

        public static async Task<string> AddUtilizadores(Utilizador utilizador)
        {
            Debug.Write("||||||");
            Debug.Write("Inserir");
            Debug.Write("||||||");
            using (HttpClient _client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(utilizador);
                Debug.WriteLine("");
                Debug.WriteLine(json);
                Debug.WriteLine("");

                var content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync("http://192.168.51.5:150/api/utilizador/adicionar", content);

                Debug.WriteLine("");
                Debug.WriteLine("StatusCode");
                Debug.WriteLine(response.StatusCode.ToString());
                Debug.WriteLine(await response.Content.ReadAsStringAsync());
                Debug.WriteLine("");

                return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
            }
        }

        public static string token { get; set; }

        public static async Task<bool> Userlogin(Utilizador utilizador)
        {

            Debug.Write("||||||");
            Debug.Write("Login");
            Debug.Write("||||||");

            using (HttpClient _client = new HttpClient())
            {

                var keyvalues = new List<KeyValuePair<string, string>>
                {
                new KeyValuePair<string, string>("username", utilizador.Nome),
                new KeyValuePair<string, string>("password", utilizador.Password),
                new KeyValuePair<string, string>("grant_type", "password")
                };

                var request = new HttpRequestMessage(HttpMethod.Post, "http://192.168.51.5:150/" + "token");

                request.Content = new FormUrlEncodedContent(keyvalues);

                var client = new HttpClient();

                var response = await client.SendAsync(request);

                Debug.WriteLine("");
                Debug.WriteLine(await response.Content.ReadAsStringAsync());
                Debug.WriteLine("");

                if (response.IsSuccessStatusCode)
                {
                    JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());

                    token = jwtDynamic.Value<string>("access_token");

                    return true;
                }

                else
                    return false;
            }
            /*Debug.Write("||||||");
            Debug.Write("Login");
            Debug.Write("||||||");

            var respomse = await _client.GetAsync("http://192.168.51.5:150/token");

            Debug.WriteLine("");
            Debug.WriteLine("StatusCode");
            Debug.WriteLine(respomse.StatusCode.ToString());
            Debug.WriteLine(await respomse.Content.ReadAsStringAsync());
            Debug.WriteLine("");

            if (respomse.IsSuccessStatusCode)
                return true;

            else
                return false;*/
        }

        public static async Task<bool> VerifyEmail(string email)
        {
            using (HttpClient _client = new HttpClient())
            {
                var response = await _client.GetAsync("http://192.168.51.5:150/api/utilizador/VerifyEmail/" + email);

                Debug.WriteLine(response.StatusCode.ToString());

                if (response.IsSuccessStatusCode)
                    return true;

                else
                    return false;
            }
        }

        public static async Task<bool> VerifyNome(string nome)
        {
            using (HttpClient _client = new HttpClient())
            {
                var response = await _client.GetAsync("http://192.168.51.5:150/api/utilizador/VerifyNome/" + nome);

                if (response.IsSuccessStatusCode)
                    return true;

                else
                    return false;
            }
        }

        public static bool IsValidEmail(string _email)
        {
            try
            {
                var enderecoemail = new System.Net.Mail.MailAddress(_email);
                return enderecoemail.Address == _email;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> SendEmail(string _email)
        {
            using (HttpClient _client = new HttpClient())
            {
                var response = await _client.GetAsync("http://192.168.51.5:150/api/utilizador/SendEmail/" + _email);

                if (response.IsSuccessStatusCode)
                    return true;

                else
                    return false;
            }
        }
    }
}
