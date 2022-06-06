using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageEncomendasValidadas : ContentPage
	{
		public PageEncomendasValidadas ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //Mostra todas as encomendas validadas na datagrid
            lvValidadas.ItemsSource = new ObservableCollection<Models.Validar>(await Models.Validar.GetValidada());
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

        private async void lvValidadas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var aux = e.SelectedItem as Models.Validar;

            if (aux != null)
            {
                Models.PassValor.valor10 = aux.ID.ToString();

                OnAppearing();
                refresh.IsRefreshing = true;
                await Task.Delay(1000);
                refresh.IsRefreshing = false;
                //Abre a página PagePedidosValidados
                await Navigation.PushAsync(new PagePedidosValidados());
                lvValidadas.SelectedItem = null;
            }
        }
    }
}