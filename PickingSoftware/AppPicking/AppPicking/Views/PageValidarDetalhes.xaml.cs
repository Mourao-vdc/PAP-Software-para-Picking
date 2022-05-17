using AppPicking.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageValidarDetalhes : ContentPage
	{
		public PageValidarDetalhes ()
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
                Debug.WriteLine(Models.PassValor.valor10);
                Debug.Write("|||||");
                Debug.Write("|||||");

                int idencomenda = int.Parse(Models.PassValor.valor10);

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

        private async void btnPopup_Clicked(object sender, EventArgs e)
        {
            string action2 = await DisplayActionSheet("Deseja validar a encomeda?", "Sim", "Não");
            Debug.WriteLine("Ações: " + action2);

            if (action2 == "Sim")
            {
                Validar _validar = new Validar()
                {
                    ID = int.Parse(Models.PassValor.valor10),
                    Estado = "Validada",
                };

                await DisplayAlert("Resposta", await Validar.GetValidarEstado(_validar), "Ok");

                await Shell.Current.GoToAsync("..");
            }
            if (action2 == "Não")
            {
                return;
            }
        }

        private async void refresh_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(1500);
            OnAppearing();
            refresh.IsRefreshing = false;
        }
    }
}