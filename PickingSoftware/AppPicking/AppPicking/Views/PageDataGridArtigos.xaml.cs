using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageDataGridArtigos : ContentPage
    {
        public PageDataGridArtigos()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            lvArtigos.ItemsSource = new ObservableCollection<Models.Artigos>(await Models.Artigos.GetArtigos());
        }

        private async void btnPopup_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageAddArtigos());
        }

        private async void lvArtigos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var aux = e.SelectedItem as Models.Artigos;

            Models.PassValor.valor1 = aux.ID.ToString();
            Models.PassValor.valor2 = aux.Nome.ToString();
            Models.PassValor.valor3 = aux.Cod_Barras.ToString();

            string action = await DisplayActionSheet("Ações: Que ação pretende realizar?", "Cancelar", null, "Editar", "Remover");
            Debug.WriteLine("Ações: " + action);

            if (action == "Editar")
            {
                //await Shell.Current.GoToAsync($"//{nameof(PageEditArtigos)}");
                await Navigation.PushAsync(new PageEditArtigos());
            }
            if (action == "Remover")
            {
                await Navigation.PushAsync(new PageRemoveArtigos());
            }
        }
    }
}