using AppPicking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageEditEncomendas : ContentPage
    {
        public int ID { get; set; }
        public int ID_Utilizadores { get; set; }
        public string Data { get; set; }

        public PageEditEncomendas()
        {
            InitializeComponent();
        }

        private async void searchButton_Clicked(object sender, EventArgs e)
        {
            if(txtIDUtilizador.SelectedIndex == -1)
            {
                await DisplayAlert("Alerta", "Encomenda não encontrado", "Ok");
                return;
            }
            else 
            {
                EditButton.IsVisible = true;
                searchButton.IsVisible = false;
            }
        }

        private void EditButton_Clicked(object sender, EventArgs e)
        {
            Encomendas encomendas = new Encomendas();
            {
                ID_Utilizadores = txtIDUtilizador.SelectedIndex;
                Data = dpData.Date.ToString();
            }
            DisplayAlert("Editado", "Encomenda atualizada com sucesso", "Ok");
        }
    }
}