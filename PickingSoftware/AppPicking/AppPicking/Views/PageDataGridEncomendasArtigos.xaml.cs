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

            try
            {
                Debug.Write("|||||");
                Debug.Write("|||||");
                Debug.WriteLine(Models.PassValor.valor1);
                Debug.Write("|||||");
                Debug.Write("|||||");

                int idencomenda = int.Parse(Models.PassValor.valor1);

                lvEncomendasArtigos.ItemsSource = new ObservableCollection<Models.Encomendas_Artigos>(await Models.Encomendas_Artigos.GetEncomendas_Artigos(idencomenda));

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    
        private async void btnPopup_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageAddEncomendasArtigos());

            OnAppearing();
        }

        private async void lvEncomendasArtigos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var aux = e.SelectedItem as Models.Encomendas_Artigos;

                //int id = int.Parse(txtID.ToString());
                if (aux.Situacao == "A preparar")
                {
                    //Dados da linha selecionada


                    if (aux != null)
                    {
                        Models.PassValor.valor1 = aux.ID.ToString();
                        Models.PassValor.valor2 = aux.ID_Encomendas.ToString();
                        Models.PassValor.valor3 = aux.Nome.ToString();
                        Models.PassValor.valor4 = aux.Quant_artigos.ToString();
                        Models.PassValor.valor5 = aux.Situacao.ToString();
                        Models.PassValor.valor6 = aux.Cod_Barras.ToString();


                        string action = await DisplayActionSheet("Detalhes: Que ação pretende realizar?", "Cancelar", null, "Editar", "Remover", "Alterar quantidade");
                        Debug.WriteLine("Ações: " + action);

                        if (action == "Editar")
                        {
                            lvEncomendasArtigos.SelectedItem = null;
                            await Navigation.PushAsync(new PageEditEncomendasArtigos());
                        }
                        if (action == "Remover")
                        {
                            string action2 = await DisplayActionSheet("Deseja remover a encomenda selecionada?", "Sim", "Não");
                            Debug.WriteLine("Ações: " + action2);

                            if (action2 == "Sim")
                            {
                                Encomendas_Artigos _encomendasartigos = new Encomendas_Artigos()
                                {
                                    ID = int.Parse(Models.PassValor.valor1),
                                };

                                await DisplayAlert("Resposta", await Encomendas_Artigos.DellEncomendas_Artigos(int.Parse(Models.PassValor.valor1)), "Ok");

                                OnAppearing();
                                lvEncomendasArtigos.SelectedItem = null;
                            }
                            if (action == "Não")
                            {
                                return;
                            }
                        }
                        if (action == null || action == "Cancelar")
                        {
                            lvEncomendasArtigos.SelectedItem = null;
                            return;
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

                                    OnAppearing();
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

                                    OnAppearing();
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
                else
                {
                    lvEncomendasArtigos.SelectedItem = null;
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }
        }
    }
}