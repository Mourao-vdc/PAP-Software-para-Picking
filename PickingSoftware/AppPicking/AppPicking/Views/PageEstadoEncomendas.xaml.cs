using AppPicking.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageEstadoEncomendas : ContentPage
    {
        public PageEstadoEncomendas()
        {
            InitializeComponent();

        }

        private List<Models.Encomendas_Artigos> listaUtilizadores = new List<Encomendas_Artigos>();

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var _list = await Models.Encomendas_Artigos.GetEncomendas_Artigos();

            listaUtilizadores = _list;

            foreach (var _item in _list)
            {
                txtEncomenda.Items.Add(_item.ID.ToString());
            }
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

        private async void btnconcluir_Clicked(object sender, EventArgs e)
        {

        }

        private async void txtEncomenda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtEncomenda.SelectedIndex == -1)
            {
                await DisplayAlert("Alerta", "Selecione o ID da encomenda pretendida", "Ok");
                return;
            }
            else
            {
                Estado();
                rbestado.IsVisible = true;
                btnconcluir.IsVisible = true;
            }
        }
    }
}