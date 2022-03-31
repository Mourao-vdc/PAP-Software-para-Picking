using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            string action = await DisplayActionSheet("Ações: Que ação pretende relizar?", "Cancelar", null, "Adicionar", "Editar", "Remover");
            Debug.WriteLine("Ações: " + action);

            if (action == "Adicionar")
            {
                await Navigation.PushAsync(new PageAddArtigos());
            }
            if (action == "Editar")
            {
                await Navigation.PushAsync(new PageEditArtigos());
            }
        }
    }
}