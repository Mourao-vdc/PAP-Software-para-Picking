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
    public partial class PageDataGridEncomendasArtigos : ContentPage
    {
        public PageDataGridEncomendasArtigos()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            lvEncomendasArtigos.ItemsSource = new ObservableCollection<Models.Encomendas_Artigos>(await Models.Encomendas_Artigos.GetEncomendas_Artigos());
        }

        private async void btnPopup_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Ações: Que ação pretende realizar?", "Cancelar", null, "Adicionar", "Editar", "Remover");
            Debug.WriteLine("Ações: " + action);

            if (action == "Adicionar")
            {
                await Navigation.PushAsync(new PageAddEncomendasArtigos());
            }
            if (action == "Editar")
            {
                await Navigation.PushAsync(new PageEditEncomendasArtigos());
            }
            if (action == "Remover")
            {
                await Navigation.PushAsync(new PageRemoveEncomendasArtigos());
            }
        }
    }
}