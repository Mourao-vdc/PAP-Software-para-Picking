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
    public partial class PageAddEncomendasArtigos : ContentPage
    {
        public int ID { get; set; }
        public int ID_Encomendas { get; set; }
        public string Nome { get; set; }
        public int ID_Artigos { get; set; }
        public string Cod_Barras { get; set; }
        public string Situacao { get; set; }
        public int Quant_artigos { get; set; }

        private List<Models.Encomendas> listaEncomenda = new List<Encomendas>();
        
        private List<Models.Artigos> listaArtigo = new List<Artigos>();

        List<string> _artigos = new List<string>
        {

        };

        public PageAddEncomendasArtigos()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            /*var _list = await Models.Encomendas.GetEncomendas();

            listaEncomenda = _list;

            foreach (var _item in _list)
            {
                txtIDEncomenda.Items.Add(_item.ID.ToString());
            }*/

            txtCodBarras.Text = Models.PassValor.scan;

            txtIDEncomenda.Text = Models.PassValor.valor1;

            Models.PassValor.scan = "";

            //Passa o nome dos artigos para a lista, linha 26
            var _listt = await Models.Artigos.GetArtigos();

            listaArtigo = _listt;

            foreach (var _item in _listt)
            {
                _artigos.Add(_item.Nome.ToString());
            }

            txtQuantArtigos.Text = 1.ToString();

        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            //Verifica se os seguintes campos se encontram vazios
            if ((string.IsNullOrEmpty(txtCodBarras.Text) || (string.IsNullOrWhiteSpace(txtCodBarras.Text))))
            {
                await DisplayAlert("Alerta", "Existem campos por preencher", "Ok");
                return;
            }
            else
            {
                //Verifica se a txtQuantArtigos se encontra vazia
                if (txtQuantArtigos.Text == "")
                {
                    int quant = 0;

                    txtQuantArtigos.Text = quant.ToString();
                }
                if (int.Parse(txtQuantArtigos.Text) > 0)
                {
                    int _ID = await Models.Encomendas_Artigos.IDNM(SearchConteudo.Text);

                    Debug.Write("|||||");
                    Debug.Write("|||||");
                    Debug.WriteLine(_ID);
                    Debug.Write("|||||");
                    Debug.Write("|||||");

                    if (_ID != -1)
                    {
                        Encomendas_Artigos encomendas_artigos = new Encomendas_Artigos()
                        {
                            //ID_Encomendas = int.Parse(txtIDEncomenda.SelectedItem.ToString()),
                            ID_Encomendas = int.Parse(txtIDEncomenda.Text),
                            ID_Artigos = _ID,
                            Quant_artigos = int.Parse(txtQuantArtigos.Text.ToString()),
                            Quant_artigos_cliente = int.Parse(txtQuantArtigos.Text.ToString()),
                            Cod_Barras = txtCodBarras.Text,
                            Situacao = txtsituacao.Text,
                        };

                        //Adiciona o artigo à encomenda
                        await DisplayAlert("Resposta", await Encomendas_Artigos.AddEncomendas_Artigos(encomendas_artigos), "Ok");

                        //txtIDEncomenda.SelectedIndex = -1;
                        txtIDEncomenda.Text = "";
                        SearchConteudo.Text = "";
                        //txtIDArtigo.SelectedIndex = -1;
                        txtCodBarras.Text = "";
                        txtQuantArtigos.Text = "";

                        await Shell.Current.GoToAsync("..");
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

        private async void CodBarras_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageReadBarcode(PageReadBarcode.BarcodeSearchType.Encomendas));
        }
    }
}