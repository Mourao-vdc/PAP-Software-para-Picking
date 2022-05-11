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
    public partial class PageDataGridEncomendas : ContentPage
    {
        public PageDataGridEncomendas()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            Models.PassValor.scan = "";

            if ((await Models.Utilizador.perfil()).ID_Grupo != 1)
            {
                lvEncomendas.ItemsSource = new ObservableCollection<Models.Encomendas>(await Models.Encomendas.GetEncomendas((await Models.Utilizador.perfil()).Nome));

                Debug.Write("|||||");
                Debug.Write("|||||");
                Debug.WriteLine((await Models.Utilizador.perfil()).ID);
                Debug.Write("|||||");
                Debug.Write("|||||");
                Debug.WriteLine(await Models.Encomendas.GetMAXID());
                Debug.Write("|||||");
                Debug.Write("|||||");
            }
            else
            {
                lvEncomendas.ItemsSource = new ObservableCollection<Models.Encomendas>(await Models.Encomendas.GetEncomendastodas());
            }
        }

        private async void btnPopup_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Deseja realizar uma nova encomendas?", "Sim", "Não");
            Debug.WriteLine("Ações: " + action);

            if (action == "Sim")
            {
                Encomendas encomendas = new Encomendas()
                {
                    ID_Utilizadores = (await Models.Utilizador.perfil()).ID,
                    Data = DateTime.Now.ToString("MM/dd/yyyy"),
                };

                Debug.Write("||||||");
                Debug.Write("||||||");
                Debug.WriteLine(encomendas.ID_Utilizadores);
                Debug.Write("||||||");
                Debug.Write("||||||");

                await DisplayAlert("Resposta", await Encomendas.AddEncomendas(encomendas), "Ok");

                OnAppearing();

                Models.PassValor.valor1 = (await Models.Encomendas.GetMAXID()).ToString();

                await Navigation.PushAsync(new PageDataGridEncomendasArtigos());
            }
            if (action == "Não")
            {
                return;
            }
        }

        private async void lvEncomendas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if ((await Models.Utilizador.perfil()).ID_Grupo == 1)
            {
                try
                {
                    var aux = e.SelectedItem as Models.Encomendas;

                    if (aux != null)
                    {
                        Models.PassValor.valor1 = aux.ID.ToString();
                        Models.PassValor.valor2 = aux.Nome.ToString();
                        Models.PassValor.valor3 = aux.Data.ToString();
                        string action = await DisplayActionSheet("Encomendas: Que ação pretende realizar?", "Cancelar", null, "Editar", "Remover", "Detalhes");
                        Debug.WriteLine("Ações: " + action);

                        if (action == "Editar")
                        {
                            lvEncomendas.SelectedItem = null;
                            await Navigation.PushAsync(new PageEditEncomendas());
                        }
                        if (action == "Remover")
                        {
                            lvEncomendas.SelectedItem = null;
                            string action2 = await DisplayActionSheet("Deseja remover a encomenda selecionada?", "Sim", "Não");
                            Debug.WriteLine("Ações: " + action2);

                            if (action2 == "Sim")
                            {
                                lvEncomendas.SelectedItem = null;
                                Encomendas encomendas = new Encomendas()
                                {
                                    ID = int.Parse(Models.PassValor.valor1),
                                };

                                await DisplayAlert("Resposta", await Encomendas.DellEncomenda(int.Parse(Models.PassValor.valor1)), "Ok");

                                OnAppearing();
                            }
                            if (action == "Não")
                            {
                                lvEncomendas.SelectedItem = null;
                                return;
                            }
                        }
                        if (action == "Detalhes")
                        {
                            lvEncomendas.SelectedItem = null;
                            await Navigation.PushAsync(new PageDataGridEncomendasArtigos());
                        }
                        if (action == null || action == "Cancelar")
                        {
                            lvEncomendas.SelectedItem = null;
                            return;
                        }

                        /*string action = await DisplayActionSheet("Deseja eliminar a encomenda selecionada?", "Sim", "Não");
                        Debug.WriteLine("Ações: " + action);

                        if (action == "Sim")
                        {
                            Encomendas encomendas = new Encomendas()
                            {
                                ID = int.Parse(Models.PassValor.valor1),
                            };

                            await DisplayAlert("Resposta", await Encomendas.DellEncomenda(int.Parse(Models.PassValor.valor1)), "Ok");

                            await Navigation.PushAsync(new PageDataGridEncomendasArtigos());
                        }
                        if (action == "Não")
                        {
                            lvEncomendas.SelectedItem = null;
                            return;
                        }
                        if (action == null)
                        {
                            lvEncomendas.SelectedItem = null;
                            return;
                        }*/
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("");
                    Debug.WriteLine(ex.ToString());
                    Debug.WriteLine("");
                }
            }
            else
            {
                var aux = e.SelectedItem as Models.Encomendas;

                if (aux != null)
                {
                    Models.PassValor.valor1 = aux.ID.ToString();
                    Models.PassValor.valor2 = aux.Nome.ToString();
                    Models.PassValor.valor3 = aux.Data.ToString();

                    string action = await DisplayActionSheet("Deseja visualizar os detalhes da encomenda selecionada?", "Sim", "Não");
                    Debug.WriteLine("Ações: " + action);

                    if (action == "Sim")
                    {
                        lvEncomendas.SelectedItem = null;
                        OnAppearing();
                        await Navigation.PushAsync(new PageDataGridEncomendasArtigos());
                    }
                    if (action == "Não")
                    {
                        return;
                    }
                }
            }
        }

        private async void refresh_Refreshing(object sender, EventArgs e)
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