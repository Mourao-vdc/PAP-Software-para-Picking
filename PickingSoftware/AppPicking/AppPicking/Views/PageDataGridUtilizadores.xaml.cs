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

            Models.PassValor.scan = "";

            lvUtilizadores.ItemsSource = new ObservableCollection<Models.Utilizador>(await Models.Utilizador.GetUtilizadores());
        }

        private async void lvUtilizadores_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var aux = e.SelectedItem as Models.Encomendas;

            if (aux != null)
            {
                Models.PassValor.grupo = aux.ID.ToString();;
                string action = await DisplayActionSheet("Utilizador: Deseja alterar o grupo do utilizador selecionado?", "Sim", "Não");
                Debug.WriteLine("Ações: " + action);

                if (action == "Sim")
                {
                    string action2 = await DisplayActionSheet("Grupo: Selecione o grupo que pretende atribuir ao utilizador?", "Cancelar", null, "");
                    Debug.WriteLine("Ações: " + action2);
                }
                if (action == "Não" || action == null)
                {
                    lvUtilizadores.SelectedItem = null;
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
    }
}