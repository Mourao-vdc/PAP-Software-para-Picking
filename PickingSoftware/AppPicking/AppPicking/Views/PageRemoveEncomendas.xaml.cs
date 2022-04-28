﻿using AppPicking.Models;
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

            /*var _list = await Models.Encomendas.GetEncomendas();

            listaPedido = _list;

            foreach (var _item in _list)
            {
                txtID.Items.Add(_item.ID.ToString());
            }*/

            var _listt = await Models.Utilizador.GetUtilizadores();

            listaUtilizadores = _listt;

            foreach (var _item in _listt)
            {
                txtIDUtilizador.Items.Add(_item.ID.ToString());
            }

            txtID.Text = Models.PassValor.valor1;
            //txtIDUtilizador.SelectedIndex = int.Parse(Models.PassValor.valor2);
            dpData.Date = DateTime.Parse(Models.PassValor.valor3);
        }

        /*private async void searchButton_Clicked(object sender, EventArgs e)
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

                txtIDUtilizador.SelectedItem = _pedido.Nome.ToString();
                dpData.Date = Convert.ToDateTime(_pedido.Data);

                RemoveButton.IsVisible = true;
                searchButton.IsVisible = false;
            }
        }*/

        private async void RemoveButton_Clicked(object sender, EventArgs e)
        {
            Encomendas encomendas = new Encomendas()
            {
                ID = int.Parse(txtID.Text),
            };

            await DisplayAlert("Resposta", await Encomendas.DellEncomenda(int.Parse(txtID.Text)), "Ok");

            //txtID.SelectedIndex = -1;
            txtID.Text = "";
            txtIDUtilizador.SelectedIndex = -1;
            Data = DateTime.Now.ToString();

            await Shell.Current.GoToAsync("..");
            //RemoveButton.IsVisible = false;
            //searchButton.IsVisible = true;
        }

        /*private void txtID_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIDUtilizador.SelectedIndex = -1;
            Data = DateTime.Now.ToString();

            RemoveButton.IsVisible = false;
            searchButton.IsVisible = true;
        }*/
    }
}