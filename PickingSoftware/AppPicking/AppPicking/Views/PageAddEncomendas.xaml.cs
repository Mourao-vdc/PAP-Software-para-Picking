using AppPicking.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAddEncomendas : ContentPage
    {
        public int ID { get; set; }
        public int ID_Utilizadores { get; set; }
        public string Data { get; set; }

        public PageAddEncomendas()
        {
            InitializeComponent();
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            if (txtIDUtilizador.SelectedIndex == -1)

            {
                await DisplayAlert("Alerta", "Existem campos por preencher", "Ok");
                return;
            }
            else
            {
                Encomendas encomendas = new Encomendas();
                {
                    ID_Utilizadores = txtIDUtilizador.SelectedIndex;
                    Data = dpData.Date.ToString();
                }

                var httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(encomendas);
                HttpContent httpContent = new StringContent(json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                httpClient.PostAsync("http://192.168.51.5:150/api/encomendas/adicionar", httpContent);

                DisplayAlert("Adicionado", "Encomenda adicionada com sucesso", "Ok");
            }
        }
    }
}