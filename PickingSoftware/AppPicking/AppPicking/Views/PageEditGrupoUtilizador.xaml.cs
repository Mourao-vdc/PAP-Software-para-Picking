using AppPicking.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageEditGrupoUtilizador : ContentPage
    {
        public PageEditGrupoUtilizador()
        {
            InitializeComponent();
        }

        private List<Models.Grupos> lvGrup = new List<Grupos>();

        private List<Models.Utilizador> lvUtil = new List<Utilizador>();


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            /*var _list = await Models.Encomendas_Artigos.GetEncomendas_Artigos();

            lvEncomendasartigos = _list;

            foreach (var _item in _list)
            {
                txtID.Items.Add(_item.ID.ToString());
            }*/

            //Mostra todos os grupos existentes
            var _listtt = await Models.Grupos.GetGrupos();

            lvGrup = _listtt;

            foreach (var _item in _listtt)
            {
                txtGrupo.Items.Add(_item.Nome.ToString());
            }

            txtID.Text = Models.PassValor.grupo;
            txtNome.Text = Models.PassValor.grupo2;
            txtEmail.Text = Models.PassValor.grupo3;
            txtGrupo.SelectedItem = Models.PassValor.grupo4;
        }

        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            //Busca o ID do utilizador correspondente ao nome do grupo selecionado
            int _ID = await Models.Grupos.IDNM2(txtGrupo.SelectedItem.ToString());
            Debug.Write("|||||");
            Debug.Write("|||||");
            Debug.WriteLine(_ID);
            Debug.Write("|||||");
            Debug.Write("|||||");

            if (_ID != -1)
            {
                Utilizador _utilizador = new Utilizador()
                {
                    ID = int.Parse(txtID.Text),
                    ID_Grupo = _ID,
                };

                //Edita o grupo do utilizador selecionado
                await DisplayAlert("Resposta", await Utilizador.GetEditarGrupo(_utilizador), "Ok");

                //txtID.SelectedIndex = -1;
                txtID.Text = "";
                txtGrupo.SelectedIndex = -1;
                txtNome.Text = "";
                txtEmail.Text = "";

                await Shell.Current.GoToAsync("..");
                //EditButton.IsVisible = false;
                //searchButton.IsVisible = true;
            }
        }
    }
}