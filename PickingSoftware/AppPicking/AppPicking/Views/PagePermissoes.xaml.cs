using AppPicking.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

        public PagePermicoes()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            lvPermicoes.ItemsSource = new ObservableCollection<Models.Permissoes_Gerais>(await Models.Permissoes_Gerais.GetPermicoes_Gerais(txtprocurar.Text));

            /*var _list = await Models.Grupos.GetGrupos();

            lvGrupos = _list;

            foreach (var _item in _list)
            {
                btnPopup.Items.Add(_item.ID.ToString());
            }*/
        }

        private async void lvPermicoes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            string action = await DisplayActionSheet("Permissões: Permissão selecionada", "Cancelar", null, "Permitir acesso", "Remover acesso");
            Debug.WriteLine("Ações: " + action);
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

        private void txtprocurar_SearchButtonPressed(object sender, EventArgs e)
        {
            OnAppearing();
        }
    }
}