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
    public partial class PageRemoveArtigos : ContentPage
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cod_Barras { get; set; }

        public PageRemoveArtigos()
        {
            InitializeComponent();
        }

        private async void searchButton_Clicked(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(txtID.Text)) || (string.IsNullOrWhiteSpace(txtID.Text)))

            {

                await DisplayAlert("Alerta", "Artigo não encontrado", "Ok");
                return;
            }
            else
            {
                RemoveButton.IsVisible = true;
                searchButton.IsVisible = false;
            }
        }

        private void RemoveButton_Clicked(object sender, EventArgs e)
        {

            Artigos artigos = new Artigos();
            {
                ID = Convert.ToInt16(txtID.Text);
                Nome = txtNome.Text;
                Cod_Barras = txtCod_Barras.Text;
            }

            //var httpClient = new HttpClient();
            //var json = JsonConvert.SerializeObject(artigos);
            //HttpContent httpContent = new StringContent(json);
            //httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //httpClient.DeleteAsync(String.Format("http://192.168.51.5:150/api/artigos/eliminar"), httpContent);

            //DisplayAlert("Adicionado", "A sua Base de dados Tem novos registos", "ok");
        }
    }
}