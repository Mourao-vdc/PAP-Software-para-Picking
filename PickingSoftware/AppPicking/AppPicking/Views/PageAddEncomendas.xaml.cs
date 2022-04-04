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
    public partial class PageAddEncomendas : ContentPage
    {
        public int ID { get; set; }
        public int ID_Utilizadores { get; set; }
        public string Data { get; set; }

        private List<Models.Utilizador> listaUtilizadores = new List<Utilizador>();

        public PageAddEncomendas()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var _list = await Models.Utilizador.GetUtilizadores();

            listaUtilizadores = _list;

            foreach (var _item in _list)
            {
                txtIDUtilizador.Items.Add(_item.ID.ToString());
            }

            //txtID.Items.Add();
            //txtID.ItemsSource = new ObservableCollection<Models.Artigos>(await Models.Artigos.GetIDArtigos());
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            if (txtIDUtilizador.SelectedIndex == -1)

            {
                await DisplayAlert("Alerta", "Existem campos por preencher", "Ok");
                return;
            }
            else
            {
                Encomendas encomendas = new Encomendas()
                {
                    ID_Utilizadores = txtIDUtilizador.SelectedIndex +1,
                    Data = dpData.Date.ToString(),
                };

                await Encomendas.AddEncomendas(encomendas);

                DisplayAlert("Adicionado", "Encomenda adicionada com sucesso", "Ok");
            }
        }
    }
}