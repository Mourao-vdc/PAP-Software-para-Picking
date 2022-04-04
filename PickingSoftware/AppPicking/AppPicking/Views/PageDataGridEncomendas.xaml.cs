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
            string action = await DisplayActionSheet("Ações: Que ação pretende realizar?", "Cancelar", null, "Adicionar", "Editar", "Remover");
            Debug.WriteLine("Ações: " + action);

            if (action == "Adicionar")
            {
                await Navigation.PushAsync(new PageAddEncomendas());
            }
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