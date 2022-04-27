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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            apresentadados();
        }

        async void apresentadados()
        {
            lvEncomendasArtigos.ItemsSource = new ObservableCollection<Models.Encomendas_Artigos>(await Models.Encomendas_Artigos.GetEncomendas_Artigos());
        }

        private async void btnPopup_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageAddEncomendasArtigos());
        }

        private async void lvEncomendasArtigos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //int id = int.Parse(txtID.ToString());

            //Dados da linha selecionada
            var aux = e.SelectedItem as Models.Encomendas_Artigos;

            Debug.Write("|||||");
            Debug.Write("|||||");
            Debug.WriteLine(aux.ID);
            Debug.Write("|||||");
            Debug.Write("|||||");

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

                string result = await DisplayPromptAsync("Quantidade", "Teste", "Confirmar", "Cancelar", keyboard: Keyboard.Numeric);

                if (result != null)
                {
                    if (int.Parse(result.ToString()) != 0)
                    {
                        Encomendas_Artigos _encomendasartigos = new Encomendas_Artigos()
                        {
                            ID = aux.ID,
                            Quant_artigos = int.Parse(result.ToString()),
                            Situacao = "A preparar",
                        };

                        await DisplayAlert("Resposta", await Encomendas_Artigos.EditQuantSituacao(_encomendasartigos), "Ok");

                        apresentadados();
                    }
                    if (int.Parse(result.ToString()) == 0)
                    {
                        Encomendas_Artigos _encomendasartigoss = new Encomendas_Artigos()
                        {
                            ID = aux.ID,
                            Quant_artigos = 0,
                            Situacao = "Pronto",
                        };

                        await DisplayAlert("Resposta", await Encomendas_Artigos.EditQuantSituacao(_encomendasartigoss), "Ok");

                        apresentadados();
                    }
                    if (result.ToString() == "")
                    { 
                        await DisplayAlert("Erro!", "A quantidade esta vazia", "Ok");
                    }
                }
                else
                {
                    return;
                }
            }
        }
    }
}