using AppPicking.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
            if ((await Models.Utilizador.perfil()).ID_Grupo != 1)
            {
                btnPopup.IsVisible = false;
            }
            else
            {
                btnPopup.IsVisible = true;
            }

                try
            {
                lvArtigos.ItemsSource = new ObservableCollection<Models.Artigos>(await Models.Artigos.GetArtigos());
            }

            catch (Exception ex)
            {
                Debug.WriteLine("");
                Debug.WriteLine(ex.ToString());
                Debug.WriteLine("");
            }
        }

        private async void btnPopup_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageAddArtigos());
        }

        private async void lvArtigos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if ((await Models.Utilizador.perfil()).ID_Grupo == 1)
            {
                try
                {
                    var aux = e.SelectedItem as Models.Artigos;

                    if (aux != null)
                    {
                        Models.PassValor.valor1 = aux.ID.ToString();
                        Models.PassValor.valor2 = aux.Nome.ToString();
                        Models.PassValor.valor3 = aux.Cod_Barras.ToString();

                        string action = await DisplayActionSheet("Artigos: Que ação pretende realizar?", "Cancelar", null, "Editar", "Remover");
                        Debug.WriteLine("Ações: " + action);

                        if (action == "Editar")
                        {
                            lvArtigos.SelectedItem = null;
                            await Navigation.PushAsync(new PageEditArtigos());
                        }
                        if (action == "Remover")
                        {
                            string action2 = await DisplayActionSheet("Deseja remover a encomenda selecionada?", "Sim", "Não");
                            Debug.WriteLine("Ações: " + action2);

                            if (action2 == "Sim")
                            {
                                lvArtigos.SelectedItem = null;
                                Artigos artigos = new Artigos()
                                {
                                    ID = int.Parse(Models.PassValor.valor1),
                                };

                                await DisplayAlert("Resposta", await Artigos.DellArtigos(int.Parse(Models.PassValor.valor1)), "Ok");
                            }
                            else
                            {
                                lvArtigos.SelectedItem = null;
                                return;
                            }
                        }
                        if (action == null || action == "Cancelar")
                        {
                            lvArtigos.SelectedItem = null;
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("");
                    Debug.WriteLine(ex.ToString());
                    Debug.WriteLine("");
                }
            }
        }

        private async void RefreshView_Refreshing(object sender, EventArgs e)
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