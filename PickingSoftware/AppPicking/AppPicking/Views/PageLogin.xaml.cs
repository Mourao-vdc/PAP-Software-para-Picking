using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLogin : ContentPage
    {
        public PageLogin()
        {
            InitializeComponent();

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (txtNome.Text == ""|| txtNome.Text == null || txtPassword.Text == "" || txtPassword.Text == null)
            {
                await DisplayAlert("Erro!","Existem campos por preencher","Ok");
                return;
            }
            else
            {
                btnLogin.IsVisible = false;
                lblNA.IsVisible = false;
                loading.IsRunning = true;

                Debug.Write("||||||");
                Debug.Write("PageLogin");
                Debug.Write("||||||");

                Models.Utilizador _user = new Models.Utilizador()
                {
                    Nome = txtNome.Text.TrimEnd().TrimStart(),
                    Password = txtPassword.Text
                };

                if (await Models.Utilizador.Userlogin(_user))
                {
                    //Models.Username.Nome = txtNome.Text;

                    //Debug.Write(Models.Username.Nome);

                    //Models.Username.ID = (await Models.Utilizador.perfil()).ID.ToString();
                    Models.Username.Nome = txtNome.Text;

                    txtNome.Text = "";
                    txtPassword.Text = "";

                    //await Shell.Current.GoToAsync($"//{nameof(PageDataGridEncomendas)}");

                    await teste.FadeTo(0, 500, Easing.Linear);

                    btnLogin.IsVisible = true;
                    lblNA.IsVisible = true;
                    loading.IsRunning = false;

                    App.Current.MainPage = new AppShell();

                    Debug.Write("|||||||||");
                    Debug.Write("|||||||||");
                    Debug.WriteLine(Models.Username.Nome);
                    Debug.Write("|||||||||");
                    Debug.Write("|||||||||");

                    /*Debug.Write("|||||||||");
                    Debug.Write("|||||||||");
                    Debug.WriteLine(Models.Username.ID);
                    Debug.Write("|||||||||");
                    Debug.Write("|||||||||");*/
                }
                else
                {
                    await DisplayAlert("Erro", "Nome ou Password incorreta", "Ok");

                    btnLogin.IsVisible = true;
                    lblNA.IsVisible = true;
                    loading.IsRunning = false;
                }

                Debug.Write("||||||");
                Debug.Write("PageLogin");
                Debug.Write("||||||");
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtPassword.Text = "";

            //await Shell.Current.GoToAsync($"//{nameof(PageSignup)}");
            await teste.FadeTo(0, 500, Easing.Linear);

            await Navigation.PushModalAsync(new PageSignup());
        }

        private void ShowPassword_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (ShowPassword.IsChecked)
            {
                txtPassword.IsPassword = false;
            }
            else
            {
                txtPassword.IsPassword = true;
            }
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await teste.FadeTo(0, 500, Easing.Linear);

            await Navigation.PushModalAsync(new PageRecuperarConta());
        }
    }
}