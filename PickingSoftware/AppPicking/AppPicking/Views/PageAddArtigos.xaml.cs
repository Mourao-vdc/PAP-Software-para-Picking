using AppPicking.Models;
using System;
using System.Diagnostics;
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

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            txtCod_Barras.Text = Models.PassValor.scan;

            Models.PassValor.scan = "";
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            if (//(string.IsNullOrEmpty(txtID.Text)) || (string.IsNullOrWhiteSpace(txtID.Text)
                 (string.IsNullOrEmpty(txtNome.Text) || (string.IsNullOrWhiteSpace(txtNome.Text)
                || (string.IsNullOrEmpty(txtCod_Barras.Text) || (string.IsNullOrWhiteSpace(txtCod_Barras.Text)))))){

                await DisplayAlert("Alerta", "Existem campos por preencher", "Ok");
                return;
            }
            else
            {
                Artigos artigos = new Artigos()
                {
                    //ID = Convert.ToInt16(txtID.Text);
                    Nome = txtNome.Text,
                    Cod_Barras = txtCod_Barras.Text,
                };

                Debug.WriteLine("");
                Debug.WriteLine("NOME");
                Debug.WriteLine(artigos.Nome);
                Debug.WriteLine("");

                await DisplayAlert("Resposta", await Artigos.AddArtigos(artigos), "Ok");

                txtNome.Text = "";
                txtCod_Barras.Text = "";
            }           
        }

        private async void CodBarras_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageReadBarcode(PageReadBarcode.BarcodeSearchType.Artigos));
        }
    }
}