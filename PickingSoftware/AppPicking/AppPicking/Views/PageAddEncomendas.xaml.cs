using AppPicking.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAddEncomendas : ContentPage
    {
        public int ID { get; set; }
        public int ID_Utilizadores { get; set; }
        public string Data { get; set; }

        private List<Models.Utilizador> listaUtilizadores = new List<Utilizador>();

        public PageAddEncomendas()
        {
            Debug.Write("|||||||||||");
            Debug.Write("Adicionar");
            Debug.Write("|||||||||||");
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //Passa o nome de todos os utilizadores existentes para a txtIDUtilizador
            var _list = await Models.Utilizador.GetUtilizadores();

            listaUtilizadores = _list;

            foreach (var _item in _list)
            {
                txtIDUtilizador.Items.Add(_item.Nome.ToString());
            }
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            //Verifica se existe um utilizador selecionado
            if (txtIDUtilizador.SelectedIndex == -1)
            {
                await DisplayAlert("Alerta", "Existem campos por preencher", "Ok");
                return;
            }
            else
            {
                Encomendas encomendas = new Encomendas()
                {
                    ID_Utilizadores = int.Parse(txtIDUtilizador.SelectedItem.ToString()),
                    Data = dpData.Date.ToString(),
                };

                //Cria uma nova encomenda
                await DisplayAlert("Resposta", await Encomendas.AddEncomendas(encomendas), "Ok");
                
                txtIDUtilizador.SelectedIndex = -1;
                Data = DateTime.Now.ToString();

                //Volta para a página anterior
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}