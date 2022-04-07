﻿using AppPicking.Models;
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

        private List<Models.Encomendas> lvEncomendas = new List<Encomendas>();
        
        private List<Models.Utilizador> listaUtilizadores = new List<Utilizador>();

        public PageEditEncomendas()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var _list = await Models.Encomendas.GetEncomendas();

            lvEncomendas = _list;

            foreach (var _item in _list)
            {
                txtID.Items.Add(_item.ID.ToString());
            }

            var _lista = await Models.Utilizador.GetUtilizadores();

            listaUtilizadores = _lista;

            foreach (var _item in _lista)
            {
                txtIDUtilizador.Items.Add(_item.ID.ToString());
            }
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
                var _artigo = lvEncomendas.ElementAt(txtIDUtilizador.SelectedIndex);

                txtIDUtilizador.SelectedIndex = _artigo.ID_Utilizadores;
                //dpData.Date = _artigo.Data;

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