using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageDataGridDetalhesPerfil : ContentPage
	{
		public PageDataGridDetalhesPerfil ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                Debug.Write("|||||");
                Debug.Write("|||||");
                Debug.WriteLine(Models.PassValor.valor20);
                Debug.Write("|||||");
                Debug.Write("|||||");

                int idencomenda = int.Parse(Models.PassValor.valor20);

                lvValidarPedido.ItemsSource = new ObservableCollection<Models.Validar>(await Models.Validar.GetValidarDetalhes(idencomenda));

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
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