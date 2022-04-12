using AppPicking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageRemoveEncomendas : ContentPage
    {
        public int ID { get; set; }
        public int ID_Utilizadores { get; set; }
        public string Data { get; set; }

        public PageRemoveEncomendas()
        {
            InitializeComponent();
        }

        private List<Models.Utilizador> listaUtilizadores = new List<Utilizador>();
        private List<Models.Encomendas> listaPedido = new List<Encomendas>();

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var _list = await Models.Encomendas.GetEncomendas();

            listaPedido = _list;

            foreach (var _item in _list)
            {
                txtID.Items.Add(_item.ID.ToString());
            }

            var _listt = await Models.Utilizador.GetUtilizadores();

            listaUtilizadores = _listt;

            foreach (var _item in _listt)
            {
                txtIDUtilizador.Items.Add(_item.ID.ToString());
            }
        }

        private async void searchButton_Clicked(object sender, EventArgs e)
        {
            if (txtID.SelectedIndex == -1)
            {
                await DisplayAlert("Alerta", "Encomenda não encontrado", "Ok");
                return;
            }
            else
            {
                //var _utilizadores = listaUtilizador.ElementAt(txtIDUtilizador.SelectedIndex);
                var _pedido = listaPedido.ElementAt(txtID.SelectedIndex);

                txtIDUtilizador.SelectedItem = _pedido.ID_Utilizadores.ToString();
                dpData.Date = Convert.ToDateTime(_pedido.Data);

                RemoveButton.IsVisible = true;
                searchButton.IsVisible = false;
            }
        }

        private async void RemoveButton_Clicked(object sender, EventArgs e)
        {
            Encomendas encomendas = new Encomendas()
            {
                ID = int.Parse(txtID.SelectedItem.ToString()),
            };

            await Encomendas.DellEncomenda(int.Parse(txtID.SelectedItem.ToString()));

            DisplayAlert("Removido", "Pedido removido da base de dados", "Ok");

            txtID.SelectedIndex = -1;
            txtIDUtilizador.SelectedIndex = -1;
            Data = DateTime.Now.ToString();

            RemoveButton.IsVisible = false;
            searchButton.IsVisible = true;
        }

        private void txtID_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIDUtilizador.SelectedIndex = -1;
            Data = DateTime.Now.ToString();

            RemoveButton.IsVisible = false;
            searchButton.IsVisible = true;
        }
    }
}