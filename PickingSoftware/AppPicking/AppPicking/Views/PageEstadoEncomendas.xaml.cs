using AppPicking.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageEstadoEncomendas : ContentPage
    {
        string estado;

        public int ID_Encomendas { get; set; }
        public string Situacao { get; set; }

        public PageEstadoEncomendas()
        {
            InitializeComponent();

        }

        private List<Models.Encomendas_Artigos> listaUtilizadores = new List<Encomendas_Artigos>();

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            /*var _list = await Models.Encomendas_Artigos.GetEncomendas_Artigos();

            listaUtilizadores = _list;

            foreach (var _item in _list)
            {
                txtEncomenda.Items.Add(_item.ID.ToString());
            }*/
        }

        private void Estado()
        {
            Models.Encomendas_Artigos _estado = new Encomendas_Artigos();

            if (_estado.Situacao == "A preparar")
            {
                rbprepara.IsChecked = true;
            }
            if (_estado.Situacao == "Em distribuição")
            {
                rbdistribuicao.IsChecked = true;
            }
            if (_estado.Situacao == "Entregue")
            {
                rbentregue.IsChecked = true;
            }
        }

        private void PassEstado()
        {
            if (rbprepara.IsChecked == true)
            {
                estado = "A preparar";
            }
            if (rbdistribuicao.IsChecked == true)
            {
                estado = "Em distribuição";
            }
            if (rbentregue.IsChecked == true)
            {
                estado = "Entregue";
            }
        }

        private async void btnconcluir_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Estado: Pretende alterar o estado da encomenda?", "Não", "Sim");
            Debug.WriteLine("Ações: " + action);
            if (action == "Sim")
            {
                Encomendas_Artigos encomendas_artigos = new Encomendas_Artigos()
                {
                    ID_Encomendas = int.Parse(txtEncomenda.SelectedItem.ToString()),
                    //Situacao = PassEstado(estado),
                };

                await Encomendas_Artigos.EditEstado(encomendas_artigos);

                DisplayAlert("Concuído", "Estado da encomendas alterado", "Ok");

                txtEncomenda.SelectedIndex = -1;
                rbestado.IsVisible = false;
                btnconcluir.IsVisible = false;
            }
            return;
            
        }

        private async void txtEncomenda_SelectedIndexChanged(object sender, EventArgs e)
        {
                Estado();
                rbestado.IsVisible = true;
                btnconcluir.IsVisible = true;
        }
    }
}