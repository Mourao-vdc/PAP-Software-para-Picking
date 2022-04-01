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
    public partial class PageEditArtigos : ContentPage
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cod_Barras { get; set; }

        public PageEditArtigos()
        {
            InitializeComponent();
        }

        private async void searchButton_Clicked(object sender, EventArgs e)
        {
            if (txtID.SelectedIndex == -1)

            {

                await DisplayAlert("Alerta", "Artigo não encontrado", "Ok");
                return;
            }
            else
            {

                EditButton.IsVisible = true;
                searchButton.IsVisible = false;
            }
        }

        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(txtNome.Text) || (string.IsNullOrWhiteSpace(txtNome.Text)
                || (string.IsNullOrEmpty(txtCod_Barras.Text) || (string.IsNullOrWhiteSpace(txtCod_Barras.Text))))))
            {
                await DisplayAlert("Alerta", "Existem campos por preencher", "Ok");
                return;
            }
            else
            {
                Artigos artigos = new Artigos();
                {
                    ID = Convert.ToInt16(txtID.ToString());
                    Nome = txtNome.Text;
                    Cod_Barras = txtCod_Barras.Text;
                }
                DisplayAlert("Editado", "Artigo atulizado com sucesso", "Ok");
            }            
        }
    }
}