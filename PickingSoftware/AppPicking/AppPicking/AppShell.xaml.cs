using AppPicking.Views;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace AppPicking
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));

            Models.Username _username = new Models.Username
            {
                valor = "Bem-vindo(a): " + Models.Username.Nome,
            };

            Debug.Write("||||||");
            Debug.Write("||||||");
            Debug.WriteLine(_username);
            Debug.Write("||||||");
            Debug.Write("||||||");

            this.BindingContext = _username;

            OnAppearing();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var _retorno = await Models.Permissoes_Gerais.LoginView("Visualizar utilizadores");

            if (_retorno)
            {
                utilizadores.IsVisible = true;
            }
            else
            {
                utilizadores.IsVisible = false;
            }

            var _retorno2 = await Models.Permissoes_Gerais.LoginView("Visualizar permissões");

            if (_retorno2)
            {
                permissoes.IsVisible = true;
            }
            else
            {
                permissoes.IsVisible = false;
            }

            if ((await Models.Utilizador.perfil()).ID_Grupo == 1)
            {
                validarencomendas.IsVisible = false;
                encomendasvalidadas.IsVisible = true;
            }
            else
            {
                validarencomendas.IsVisible = true;
                encomendasvalidadas.IsVisible = false;
            }
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync("//LoginPage");
            await Shell.Current.GoToAsync($"//{nameof(PageDataGridEncomendas)}");
        }
    }
}
