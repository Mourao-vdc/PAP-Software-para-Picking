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
    public partial class PageAddArtigos : ContentPage
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cod_Barras { get; set; }

        public PageAddArtigos()
        {
            InitializeComponent();
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(txtID.Text)) || (string.IsNullOrWhiteSpace(txtID.Text)
                || (string.IsNullOrEmpty(txtNome.Text) || (string.IsNullOrWhiteSpace(txtNome.Text)
                || (string.IsNullOrEmpty(txtCod_Barras.Text) || (string.IsNullOrWhiteSpace(txtCod_Barras.Text))))))){

                await DisplayAlert("Alerta", "Existem campos por preencher", "Ok");
                return;
            }
 
                Artigos artigos = new Artigos();
                {
                    ID = Convert.ToInt16(txtID.Text);
                    Nome = txtNome.Text;
                    Cod_Barras = txtCod_Barras.Text;
                }

                var httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(artigos);
                HttpContent httpContent = new StringContent(json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                httpClient.PostAsync(String.Format("http://192.168.51.5:150/api/artigos/adicionar"), httpContent);
                DisplayAlert("Adicionado", "A sua Base de dados Tem novos registos", "ok");
        }
    }
}