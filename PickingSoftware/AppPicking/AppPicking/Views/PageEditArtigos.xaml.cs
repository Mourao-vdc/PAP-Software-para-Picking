using AppPicking.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageEditArtigos : ContentPage
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cod_Barras { get; set; }

        private List<Models.Artigos> listaArtigos = new List<Artigos>();

        List<string> _artigos = new List<string>
        {

        };

        public PageEditArtigos()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            /*var _list = await Models.Artigos.GetArtigos();

            listaArtigos = _list;

            foreach(var _item in _list)
            {
                txtID.Items.Add(_item.ID.ToString());
            }*/
            if(Models.PassValor.scan == "")
            {
                txtID.Text = Models.PassValor.valor1;
                txtNome.Text = Models.PassValor.valor2;
                txtCod_Barras.Text = Models.PassValor.valor3;
            }
            else
            {
                txtID.Text = Models.PassValor.valor1;
                txtNome.Text = Models.PassValor.valor2;
                txtCod_Barras.Text = Models.PassValor.scan;
            }
            Models.PassValor.scan = "";
            //txtID.Items.Add();
            //txtID.ItemsSource = new ObservableCollection<Models.Artigos>(await Models.Artigos.GetIDArtigos());
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
                var _artigo = listaArtigos.ElementAt(txtID.SelectedIndex);

                txtNome.Text = _artigo.Nome;
                txtCod_Barras.Text = _artigo.Cod_Barras;

                EditButton.IsVisible = true;
                searchButton.IsVisible = false;
            }
        }*/

        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            //Verifica se os seguintes campos se encontram vazios
            if ((string.IsNullOrEmpty(txtNome.Text) || (string.IsNullOrWhiteSpace(txtNome.Text)
                || (string.IsNullOrEmpty(txtCod_Barras.Text) || (string.IsNullOrWhiteSpace(txtCod_Barras.Text))))))
            {
                await DisplayAlert("Alerta", "Existem campos por preencher", "Ok");
                return;
            }
            else
            {
                Artigos artigos = new Artigos()
                {
                    ID = int.Parse(txtID.Text),//int.Parse(txtID.SelectedItem.ToString()),
                    Nome = txtNome.Text,
                    Cod_Barras = txtCod_Barras.Text,
                };

                //Edita a encomenda selecionada
                await DisplayAlert("Resposta", await Artigos.EditArtigos(artigos), "Ok");

                //txtID.SelectedIndex = -1;
                txtNome.Text = "";
                txtCod_Barras.Text = "";

                //EditButton.IsVisible = false;
                //searchButton.IsVisible = true;

                await Shell.Current.GoToAsync("..");
            }            
        }

        private async void CodBarras_Clicked(object sender, EventArgs e)
        {
            //Abre a página PageReadBarcode
            await Navigation.PushAsync(new PageReadBarcode(PageReadBarcode.BarcodeSearchType.Artigos));
        }

        /*private void txtID_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtNome.Text = "";
            txtCod_Barras.Text = "";

            EditButton.IsVisible = false;
            searchButton.IsVisible = true;
        }*/
    }
}