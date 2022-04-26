using AppPicking.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
            await Navigation.PushAsync(new PageAddEncomendasArtigos());
        }

        private async void lvEncomendasArtigos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            string action = await DisplayActionSheet("Ações: Que ação pretende realizar?", "Cancelar", null, "Editar", "Remover", "Alterar quantidade");
            Debug.WriteLine("Ações: " + action);

            if (action == "Editar")
            {
                await Navigation.PushAsync(new PageEditEncomendasArtigos());
            }
            if (action == "Remover")
            {
                await Navigation.PushAsync(new PageRemoveEncomendasArtigos());
            }
            if (action == "Alterar quantidade")
            {
                //await Navigation.PushAsync(new PageEditSituacao());

                string result = await DisplayPromptAsync("Quantidade", "Teste","Confirmar","Cancelar",keyboard:Keyboard.Numeric);

                if (int.Parse(result.ToString()) != 0)
                {
                    Encomendas_Artigos _encomendasartigos = new Encomendas_Artigos()
                    { 
                        Quant_artigos = int.Parse(result.ToString()),
                    };

                    await Encomendas_Artigos.EditEncomendas_Artigos(_encomendasartigos);
                }
                if (int.Parse(result.ToString()) == 0)
                {
                    Encomendas_Artigos _encomendasartigos = new Encomendas_Artigos()
                    {
                        Quant_artigos = 0,
                        Situacao = "Pronto",
                    };

                    await Encomendas_Artigos.EditEncomendas_Artigos(_encomendasartigos);
                }
                /*if (int.Parse(result.ToString()) > 10)
                {
                    await DisplayAlert("Erro","A Quantidade inserida é maior do que a pedida!","Ok");

                    return;
                }*/
            }
        }
    }
}