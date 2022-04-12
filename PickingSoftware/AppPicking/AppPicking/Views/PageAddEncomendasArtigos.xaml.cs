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
    public partial class PageAddEncomendasArtigos : ContentPage
    {
        public int ID { get; set; }
        public int ID_Encomendas { get; set; }
        public int ID_Artigos { get; set; }
        public string Cod_Barras { get; set; }
        public string Situacao { get; set; }
        public int Quant_artigos { get; set; }

        private List<Models.Encomendas> listaEncomenda = new List<Encomendas>();
        
        private List<Models.Artigos> listaArtigo = new List<Artigos>();

        public PageAddEncomendasArtigos()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var _list = await Models.Encomendas.GetEncomendas();

            listaEncomenda = _list;

            foreach (var _item in _list)
            {
                txtIDEncomenda.Items.Add(_item.ID.ToString());
            }

            var _listt = await Models.Artigos.GetArtigos();

            listaArtigo = _listt;

            foreach (var _item in _listt)
            {
                txtIDArtigo.Items.Add(_item.ID.ToString());
            }
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            if ((txtIDArtigo.SelectedIndex == -1) || (txtIDEncomenda.SelectedIndex == -1))
            {
                await DisplayAlert("Alerta", "Existem campos por preencher", "Ok");
                return;
            }
            else
            {
                Encomendas_Artigos encomendas_artigos = new Encomendas_Artigos()
                {
                    ID_Encomendas = int.Parse(txtIDEncomenda.SelectedItem.ToString()),
                    ID_Artigos = int.Parse(txtIDArtigo.SelectedItem.ToString()),
                    Quant_artigos = int.Parse(txtQuantArtigos.Text.ToString()),
                    Cod_Barras = txtCodBarras.Text,
                    Situacao = txtsituacao.Text,
                };

                await Encomendas_Artigos.AddEncomendas_Artigos(encomendas_artigos);

                DisplayAlert("Adicionado", "Encomenda adicionada com sucesso", "Ok");
            }
        }
    }
}