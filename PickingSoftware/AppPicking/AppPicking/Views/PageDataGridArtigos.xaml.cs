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

            string action = await DisplayActionSheet("Ações: Que ação pretende realizar?", "Cancelar", null, "Adicionar", "Editar", "Remover");
            Debug.WriteLine("Ações: " + action);

            if (action == "Adicionar")
            {
                await Navigation.PushAsync(new PageAddArtigos());
            }
            if (action == "Editar")
            {
                await Navigation.PushAsync(new PageEditArtigos());
            }
            if(action == "Remover")
            {
                await Navigation.PushAsync(new PageRemoveArtigos());
            }
        }
    }
}