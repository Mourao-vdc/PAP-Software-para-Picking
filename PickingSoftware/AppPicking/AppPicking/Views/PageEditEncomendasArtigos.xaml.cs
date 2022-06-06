using AppPicking.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageEditEncomendasArtigos : ContentPage
    {
        public int ID { get; set; }
        public int ID_Encomendas { get; set; }
        public int ID_Artigos { get; set; }
        public string Cod_Barras { get; set; }
        public string Situacao { get; set; }
        public int Quant_artigos { get; set; }


        private List<Models.Encomendas_Artigos> lvEncomendasartigos = new List<Encomendas_Artigos>();

        private List<Models.Encomendas> lvEncomendas = new List<Encomendas>();

        private List<Models.Artigos> listaArtigo = new List<Artigos>();

        List<string> _artigos = new List<string>
        {

        };

        public PageEditEncomendasArtigos()
        {
            InitializeComponent();
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

            //Mostra todos os nomes dos artigos existentes
            var _listt = await Models.Artigos.GetArtigos();

            listaArtigo = _listt;

            foreach (var _item in _listt)
            {
                _artigos.Add(_item.Nome.ToString());
            }

            //Mostra todos os ids das encomendas existentes
            var _listtt = await Models.Encomendas.GetEncomendastodas();

            lvEncomendas = _listtt;

            foreach (var _item in _listtt)
            {
                txtIDEncomenda.Items.Add(_item.ID.ToString());
            }

            if (Models.PassValor.scan == "")
            {
                txtID.Text = Models.PassValor.valor1;
                txtIDEncomenda.SelectedItem = Models.PassValor.valor2;
                SearchConteudo.Text = Models.PassValor.valor3;
                txtQuantArtigos.Text = Models.PassValor.valor4;
                txtCodBarras.Text = Models.PassValor.valor6;
            }
            else
            {
                txtID.Text = Models.PassValor.valor1;
                txtIDEncomenda.SelectedItem = Models.PassValor.valor2;
                SearchConteudo.Text = Models.PassValor.valor3;
                txtQuantArtigos.Text = Models.PassValor.valor4;
                txtCodBarras.Text = Models.PassValor.scan;
            }
            Models.PassValor.scan = "";
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

                EditButton.IsVisible = true;
                searchButton.IsVisible = false;
            }
        }*/

        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            //Verifica se a quantidade esta vazia
            if (txtQuantArtigos.Text == "")
            {
                int quant = 0;

                txtQuantArtigos.Text = quant.ToString();
            }
            //Verifica se a quantidade esta vazia ou se é diferente de 0
            if (int.Parse(txtQuantArtigos.Text) > 0)
            {
                int _ID = await Models.Encomendas_Artigos.IDNM(SearchConteudo.Text.ToString());

                Debug.Write("|||||");
                Debug.Write("|||||");
                Debug.WriteLine(_ID);
                Debug.Write("|||||");
                Debug.Write("|||||");

                if (_ID != -1)
                {
                    //Verifica se os seguintes campos se encontram vazios
                    if ((string.IsNullOrEmpty(Quant_artigos.ToString()) || (string.IsNullOrWhiteSpace(Quant_artigos.ToString())
                    || (string.IsNullOrEmpty(txtCodBarras.Text) || (string.IsNullOrWhiteSpace(txtCodBarras.Text)
                    || (string.IsNullOrEmpty(SearchConteudo.Text) || (string.IsNullOrWhiteSpace(SearchConteudo.Text))))))))
                    {
                        await DisplayAlert("Alerta", "Existem campos por preencher", "Ok");
                        return;
                    }
                    else
                    {
                        Encomendas_Artigos _encomendasartigos = new Encomendas_Artigos()
                        {
                            ID = int.Parse(txtID.Text),
                            ID_Encomendas = int.Parse(txtIDEncomenda.SelectedItem.ToString()),
                            ID_Artigos = _ID,
                            Quant_artigos = int.Parse(txtQuantArtigos.Text.ToString()),
                            Quant_artigos_cliente = int.Parse(txtQuantArtigos.Text.ToString()),
                            Cod_Barras = txtCodBarras.Text,
                        };

                        //Edita o artigo da encomenda selecionada
                        await DisplayAlert("Resposta", await Encomendas_Artigos.EditEncomendas_Artigos(_encomendasartigos), "Ok");

                        //txtID.SelectedIndex = -1;
                        txtID.Text = "";
                        txtIDEncomenda.SelectedIndex = -1;
                        SearchConteudo.Text = "";
                        txtCodBarras.Text = "";
                        txtQuantArtigos.Text = "";

                        await Shell.Current.GoToAsync("..");
                        //EditButton.IsVisible = false;
                        //searchButton.IsVisible = true;
                    }
                }
                else
                {
                    await DisplayAlert("Alerta", "Artigo não encontrado", "Ok");
                    return;
                }
            }
            else
            {
                await DisplayAlert("Erro!", "A quantidade do artigo tem de ser maior que 0", "Ok");
            }
        }

        private void SearchConteudo_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Filtra a lista consoante o texto escrito na SearchConteudo
            var keyword = SearchConteudo.Text;
            if (keyword.Length >= 1)
            {
                var sugestao = _artigos.Where(c => c.ToLower().Contains(keyword.ToLower()));
                listaArtigos.ItemsSource = sugestao;
                listaArtigos.IsVisible = true;
            }
            else
            {
                listaArtigos.IsVisible = false;
            }
        }

        private async void listaArtigos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //O item selecionado fica na SearchConteudo
            if (e.Item as string == null)
            {
                return;
            }
            else
            {
                listaArtigos.ItemsSource = _artigos.Where(c => c.Equals(e.Item as string));
                listaArtigos.IsVisible = true;
                SearchConteudo.Text = e.Item as string;
                txtCodBarras.Text = await Models.Artigos.CodBarras(SearchConteudo.Text);
                listaArtigos.IsVisible = false;
            }
        }

        private async void CodBarras_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageReadBarcode(PageReadBarcode.BarcodeSearchType.Encomendas));

        }

        /*private void txtID_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIDEncomenda.SelectedIndex = -1;
            txtIDArtigo.SelectedIndex = -1;
            txtCodBarras.Text = "";
            txtQuantArtigos.Text = "";

            EditButton.IsVisible = false;
            searchButton.IsVisible = true;
        }*/
    }
}