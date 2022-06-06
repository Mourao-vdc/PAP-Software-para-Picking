using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageDataGridEncomendasPerfil : ContentPage
    {
        public PageDataGridEncomendasPerfil()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //Mostra as encomendas realizadas pelo utilizador que deu login
            lvEncomendas.ItemsSource = new ObservableCollection<Models.Encomendas>(await Models.Encomendas.GetEncomendasPerfil((await Models.Utilizador.perfil()).Nome));
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

        private async void lvEncomendas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var aux = e.SelectedItem as Models.Encomendas;

            if (aux != null)
            {
                Models.PassValor.valor20 = aux.ID.ToString();

                OnAppearing();
                refresh.IsRefreshing = true;
                await Task.Delay(1000);
                refresh.IsRefreshing = false;
                //Abre a página PageDataGridDetalhesPerfil
                await Navigation.PushAsync(new PageDataGridDetalhesPerfil());
                lvEncomendas.SelectedItem = null;
            }
        }
    }
}