using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageDataGridUtilizadores : ContentPage
    {
        public PageDataGridUtilizadores()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            lvUtilizadores.ItemsSource = new ObservableCollection<Models.Utilizador>(await Models.Utilizador.GetUtilizadores());
        }

        private async void btnPopup_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageAddEncomendas());
        }

        private async void lvUtilizadores_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

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
    }
}