using AppPicking.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePermicoes : ContentPage
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string NomeG { get; set; }
        public int ID_Grupo { get; set; }
        public int ID_Permicoes { get; set; }
        public string Estado { get; set; }

        private List<Models.Grupos> lvGrupos = new List<Grupos>();

        List<string> _grupos = new List<string>
        {

        };
        public PagePermicoes()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            Models.PassValor.scan = "";

            /*var _list = await Models.Grupos.GetGrupos();

            lvGrupos = _list;

            foreach (var _item in _list)
            {
                btnPopup.Items.Add(_item.ID.ToString());
            }*/

            var _listt = await Models.Grupos.GetGrupos();

            lvGrupos = _listt;

            foreach (var _item in _listt)
            {
                _grupos.Add(_item.Nome.ToString());
            }
        }

        private async void table()
        {
            lvPermicoes.ItemsSource = new ObservableCollection<Models.Permissoes_Gerais>(await Models.Permissoes_Gerais.GetPermicoes_Gerais(SearchConteudo.Text));
        }

        private async void lvPermicoes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var aux = e.SelectedItem as Models.Permissoes_Gerais;

            if (aux != null)
            {
                Models.PassValor.permgid = aux.ID.ToString();
                Models.PassValor.permnome = aux.Nome.ToString();

                string action = await DisplayActionSheet("Permissão: " + Models.PassValor.permnome, "Cancelar", null, "Permitir acesso", "Negar acesso");
                Debug.WriteLine("Ações: " + action);
                if (action == "Permitir acesso")
                {
                    Permissoes_Gerais _estado = new Permissoes_Gerais()
                    {
                        ID = int.Parse(Models.PassValor.permgid),
                        Estado = "Autorizado",
                    };

                    await DisplayAlert("Resposta", await Permissoes_Gerais.GetEditarEstado(_estado), "Ok");

                    OnAppearing();

                    lvPermicoes.SelectedItem = null;
                }
                if (action == "Negar acesso")
                {
                    Permissoes_Gerais _estado = new Permissoes_Gerais()
                    {
                        ID = int.Parse(Models.PassValor.permgid),//int.Parse(txtID.SelectedItem.ToString()),
                        Estado = "Negado",
                    };

                    await DisplayAlert("Resposta", await Permissoes_Gerais.GetEditarEstado(_estado), "Ok");

                    OnAppearing();

                    lvPermicoes.SelectedItem = null;
                }
                if (action == "Cancelar" || action == null)
                {
                    lvPermicoes.SelectedItem = null;
                    return;
                }
            }
        }

        private async void refresh_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(1500);
            OnAppearing();
            refresh.IsRefreshing = false;
        }

        private async void tbItemAtualizar_Clicked(object sender, EventArgs e)
        {
            refresh.IsRefreshing = true;
            await Task.Delay(1500);
            OnAppearing();
            refresh.IsRefreshing = false;
        }

        private void SearchConteudo_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = SearchConteudo.Text;
            if (keyword.Length >= 1)
            {
                var sugestao = _grupos.Where(c => c.ToLower().Contains(keyword.ToLower()));
                listaGrupos.ItemsSource = sugestao;
                listaGrupos.IsVisible = true;
            }
            else
            {
                listaGrupos.IsVisible = false;
            }
        }

        private void listaGrupos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item as string == null)
            {
                return;
            }
            else
            {
                listaGrupos.ItemsSource = _grupos.Where(c => c.Equals(e.Item as string));
                listaGrupos.IsVisible = true;
                SearchConteudo.Text = e.Item as string;
                listaGrupos.IsVisible = false;
                table();
            }
        }

        private void SearchConteudo_SearchButtonPressed(object sender, EventArgs e)
        {
            table();
        }
    }
}