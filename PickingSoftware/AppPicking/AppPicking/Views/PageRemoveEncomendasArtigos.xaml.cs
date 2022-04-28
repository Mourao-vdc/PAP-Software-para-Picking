using AppPicking.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageRemoveEncomendasArtigos : ContentPage
	{
        public int ID { get; set; }
        public int ID_Encomendas { get; set; }
        public int ID_Artigos { get; set; }
        public string Cod_Barras { get; set; }
        public bool Situacao { get; set; }
        public string Quant_artigos { get; set; }


        private List<Models.Encomendas_Artigos> lvEncomendasartigos = new List<Encomendas_Artigos>();

        private List<Models.Encomendas> lvEncomendas = new List<Encomendas>();

        private List<Models.Artigos> listaArtigo = new List<Artigos>();

        public PageRemoveEncomendasArtigos ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            /*var _list = await Models.Encomendas_Artigos.GetEncomendas_Artigos();

            lvEncomendasartigos = _list;

            foreach (var _item in _list)
            {
                txtID.Items.Add(_item.ID.ToString());
            }*/

            var _listt = await Models.Artigos.GetArtigos();

            listaArtigo = _listt;

            foreach (var _item in _listt)
            {
                txtIDArtigo.Items.Add(_item.Nome.ToString());
            }

            var _listtt = await Models.Encomendas.GetEncomendas();

            lvEncomendas = _listtt;

            foreach (var _item in _listtt)
            {
                txtIDEncomenda.Items.Add(_item.ID.ToString());
            }

            txtID.Text = Models.PassValor.valor1;
            //txtIDEncomenda.SelectedIndex = int.Parse(Models.PassValor.valor2);
            //txtIDArtigo.SelectedIndex = int.Parse(Models.PassValor.valor3);
            txtQuantArtigos.Text = Models.PassValor.valor4;
            txtCodBarras.Text = Models.PassValor.valor6;
        }

        /*private async void searchButton_Clicked(object sender, EventArgs e)
        {
            if (txtID.SelectedIndex == -1)

            {
                await DisplayAlert("Alerta", "Artigo não encontrado", "Ok");
                return;
            }
            else
            {
                var _encomendaartigos = lvEncomendasartigos.ElementAt(txtID.SelectedIndex);

                txtIDEncomenda.SelectedIndex = _encomendaartigos.ID_Encomendas;
                txtIDArtigo.SelectedIndex = _encomendaartigos.ID_Artigos;
                txtQuantArtigos.Text = _encomendaartigos.Quant_artigos.ToString();
                txtCodBarras.Text = _encomendaartigos.Cod_Barras;

                RemoveButton.IsVisible = true;
                searchButton.IsVisible = false;
            }
        }*/

        /*private void txtID_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIDEncomenda.SelectedIndex = -1;
            txtIDArtigo.SelectedIndex = -1;
            txtCodBarras.Text = "";
            txtQuantArtigos.Text = "";

            RemoveButton.IsVisible = false;
            searchButton.IsVisible = true;
        }*/

        private async void RemoveButton_Clicked(object sender, EventArgs e)
        {
            Encomendas_Artigos _encomendasartigos = new Encomendas_Artigos()
            {
                ID = int.Parse(txtID.ToString()),
            };

            await DisplayAlert("Resposta", await Encomendas_Artigos.DellEncomendas_Artigos(int.Parse(txtID.ToString())), "Ok");

            //txtID.SelectedIndex = -1;
            txtID.Text = "";
            txtIDEncomenda.SelectedIndex = -1;
            txtIDArtigo.SelectedIndex = -1;
            txtCodBarras.Text = "";
            txtQuantArtigos.Text = "";

            await Shell.Current.GoToAsync("..");
            //RemoveButton.IsVisible = false;
            //searchButton.IsVisible = true;
        }
    }
}