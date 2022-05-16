using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageValidarEncomendas : ContentPage
    {
        public PageValidarEncomendas()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            Models.PassValor.scan = "";

            lvValidar.ItemsSource = new ObservableCollection<Models.Validar>(await Models.Validar.GetValidar((await Models.Utilizador.perfil()).Nome));

            Debug.Write("|||||");
            Debug.Write("|||||");
            Debug.WriteLine((await Models.Utilizador.perfil()).ID);
            Debug.Write("|||||");
            Debug.Write("|||||");
            Debug.WriteLine(await Models.Encomendas.GetMAXID());
            Debug.Write("|||||");
            Debug.Write("|||||");
        }

        private async void lvValidar_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var aux = e.SelectedItem as Models.Validar;

            if (aux != null)
            {
                Models.PassValor.valor10 = aux.ID.ToString();

                OnAppearing();
                refresh.IsRefreshing = true;
                await Task.Delay(1000);
                refresh.IsRefreshing = false;
                await Navigation.PushAsync(new PageValidarDetalhes());
                lvValidar.SelectedItem = null;
            }
        }

        private async void tbItemAtualizar_Clicked(object sender, EventArgs e)
        {
            refresh.IsRefreshing = true;
            await Task.Delay(1500);
            OnAppearing();
            refresh.IsRefreshing = false;
        }

        private async void refresh_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(1500);
            OnAppearing();
            refresh.IsRefreshing = false;
        }
    }
}