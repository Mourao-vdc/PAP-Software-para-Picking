using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageDataGridEncomendas : ContentPage
    {
        public PageDataGridEncomendas()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            lvEncomendas.ItemsSource = new ObservableCollection<Models.Encomendas>(await Models.Encomendas.GetEncomendas());
        }

        private async void btnPopup_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageAddEncomendas());
        }

        private async void lvEncomendas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            string action = await DisplayActionSheet("Ações: Que ação pretende realizar?", "Cancelar", null, "Editar", "Remover", "Detalhes");
            Debug.WriteLine("Ações: " + action);

            if (action == "Editar")
            {
                await Navigation.PushAsync(new PageEditEncomendas());
            }
            if (action == "Remover")
            {
                await Navigation.PushAsync(new PageRemoveEncomendas());
            }
            if (action == "Detalhes")
            {
                await Navigation.PushAsync(new PageDataGridEncomendasArtigos());
            }
        }
    }
}