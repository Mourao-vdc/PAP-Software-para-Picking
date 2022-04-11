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
    public partial class PageRemoveArtigos : ContentPage
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cod_Barras { get; set; }

        private List<Models.Artigos> listaArtigos = new List<Artigos>();

        public PageRemoveArtigos()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var _list = await Models.Artigos.GetArtigos();

            listaArtigos = _list;

            foreach (var _item in _list)
            {
                txtID.Items.Add(_item.ID.ToString());
            }

            //txtID.Items.Add();
            //txtID.ItemsSource = new ObservableCollection<Models.Artigos>(await Models.Artigos.GetIDArtigos());
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
                var _artigo = listaArtigos.ElementAt(txtID.SelectedIndex);

                txtNome.Text = _artigo.Nome;
                txtCod_Barras.Text = _artigo.Cod_Barras;

                RemoveButton.IsVisible = true;
                searchButton.IsVisible = false;
            }
        }

        private async void RemoveButton_Clicked(object sender, EventArgs e)
        {

            Artigos artigos = new Artigos()
            {
                ID = int.Parse(txtID.SelectedItem.ToString()),

            };

            await Artigos.DellArtigos(int.Parse(txtID.SelectedItem.ToString()));

            DisplayAlert("Removido", "Artigo removido da base de dados", "Ok");

            txtID.SelectedIndex = -1;
            txtNome.Text = "";
            txtCod_Barras.Text = "";
            RemoveButton.IsVisible= false;
            searchButton.IsVisible= true;
        }
    }
}