using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
            string action = await DisplayActionSheet("Ações: Que ação pretende realizar?", "Cancelar", null, "Editar", "Remover");
            Debug.WriteLine("Ações: " + action);

            if (action == "Editar")
            {
                await Navigation.PushAsync(new PageEditEncomendas());
            }
            if (action == "Remover")
            {
                await Navigation.PushAsync(new PageRemoveEncomendas());
            }
        }
    }
}