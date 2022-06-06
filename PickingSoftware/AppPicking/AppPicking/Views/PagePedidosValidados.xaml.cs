using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PagePedidosValidados : ContentPage
	{
		public PagePedidosValidados ()
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
                Debug.WriteLine(Models.PassValor.valor1);
                Debug.Write("|||||");
                Debug.Write("|||||");

                int idencomenda = int.Parse(Models.PassValor.valor10);

                //Mostra os artigos da encomenda selecionada
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