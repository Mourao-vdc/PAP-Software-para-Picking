using AppPicking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private List<Models.Encomendas> lvEncomendas = new List<Encomendas>();
        
        private List<Models.Utilizador> listaUtilizadores = new List<Utilizador>();

        public PageEditEncomendas()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            /*var _list = await Models.Encomendas.GetEncomendas();

            lvEncomendas = _list;

            foreach (var _item in _list)
            {
                txtID.Items.Add(_item.ID.ToString());
            }*/

            var _lista = await Models.Utilizador.GetUtilizadores();

            listaUtilizadores = _lista;

            foreach (var _item in _lista)
            {
                txtIDUtilizador.Items.Add(_item.Nome.ToString());
            }

            txtID.Text = Models.PassValor.valor1;
            txtIDUtilizador.SelectedItem = Models.PassValor.valor2;
            dpData.Date = DateTime.Parse(Models.PassValor.valor3);
        }

        /*private async void searchButton_Clicked(object sender, EventArgs e)
        {
            if(txtID.SelectedIndex == -1)
            {
                await DisplayAlert("Alerta", "Encomenda não encontrado", "Ok");
                return;
            }
            else 
            {
                var _artigo = lvEncomendas.ElementAt(txtID.SelectedIndex);

                txtIDUtilizador.SelectedIndex = int.Parse(_artigo.Nome);
                dpData.Date = Convert.ToDateTime(_artigo.Data);

                EditButton.IsVisible = true;
                searchButton.IsVisible = false;
            }
        }*/

        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            int _ID = await Models.Encomendas.IDNM2(txtIDUtilizador.SelectedItem.ToString());


            if (_ID != -1)
            {
                Encomendas encomendas = new Encomendas()
                {
                    ID = int.Parse(txtID.Text),
                    ID_Utilizadores = _ID,
                    Data = dpData.Date.ToString("MM/dd/yyyy"),
                };

                await DisplayAlert("Resposta", await Encomendas.EditEncomendas(encomendas), "Ok");

                //txtID.SelectedIndex = -1;
                txtID.Text = "";
                txtIDUtilizador.SelectedIndex = -1;
                Data = DateTime.Now.ToString();

                await Shell.Current.GoToAsync("..");
                //EditButton.IsVisible = false;
                //searchButton.IsVisible = true;
            }
        }

        /*private void txtID_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIDUtilizador.SelectedIndex = -1;
            Data = DateTime.Now.ToString();
            EditButton.IsVisible = false;
            searchButton.IsVisible = true;

            EditButton.IsVisible = false;
            searchButton.IsVisible = true;
        }*/
    }
}