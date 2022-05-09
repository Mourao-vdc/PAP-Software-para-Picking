using AppPicking.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageSignup : ContentPage
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public PageSignup()
        {
            InitializeComponent();
        }

        private void ShowPassword_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (ShowPassword.IsChecked)
            {
                txtPassword.IsPassword = false;
                txtPassword2.IsPassword = false;
            }
            else
            {
                txtPassword.IsPassword = true;
                txtPassword2.IsPassword = true;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            btnAdd.IsVisible = false;
            lblLogin.IsVisible = false;
            loading.IsRunning = true;

            if (//(string.IsNullOrEmpty(txtID.Text)) || (string.IsNullOrWhiteSpace(txtID.Text)
                 (string.IsNullOrEmpty(txtNome.Text) || (string.IsNullOrWhiteSpace(txtNome.Text)
                || (string.IsNullOrEmpty(txtPassword.Text) || (string.IsNullOrWhiteSpace(txtPassword.Text)
                || (string.IsNullOrEmpty(txtEmail.Text) || (string.IsNullOrWhiteSpace(txtEmail.Text)
                || (string.IsNullOrEmpty(txtPassword2.Text) || (string.IsNullOrWhiteSpace(txtPassword2.Text))))))))))
            {
                await DisplayAlert("Alerta", "Existem campos por preencher", "Ok");
                btnAdd.IsVisible = true;
                lblLogin.IsVisible = true;
                loading.IsRunning = false;
                return;
            }
            else
            {
                if(Models.Utilizador.IsValidEmail(txtEmail.Text))
                {
                    //if((txtPassword.Text.Length >= 8) || (txtPassword2.Text.Length >= 8))
                    //{
                        if (txtPassword.Text != txtPassword2.Text)
                        {
                            await DisplayAlert("Alerta", "As passwords não coincidem", "Ok");
                            btnAdd.IsVisible = true;
                            lblLogin.IsVisible = true;
                            loading.IsRunning = false;
                            return;
                        }
                        else
                        {

                            if (await Models.Utilizador.VerifyEmail(txtEmail.Text))
                            {
                                await DisplayAlert("Erro","O Email inserido ja se encontra registado","Ok");
                                btnAdd.IsVisible = true;
                                lblLogin.IsVisible = true;
                                loading.IsRunning = false;
                                return;
                            }
                            else
                            {
                                if(await Models.Utilizador.VerifyNome(txtNome.Text))
                                {
                                    await DisplayAlert("Erro", "O Nome inserido ja se encontra registado", "Ok");
                                    btnAdd.IsVisible = true;
                                    lblLogin.IsVisible = true;
                                    loading.IsRunning = false;
                                    return;
                                }
                                else
                                {
                                    Utilizador utilizador = new Utilizador()
                                    {
                                        ID_Grupo = 2,
                                        Nome = txtNome.Text.TrimEnd().TrimStart(),
                                        Email = txtEmail.Text,
                                        Password = Cryptography.Encrypt(txtPassword.Text.ToString()),
                                    };

                                    await DisplayAlert("Resposta", await Utilizador.AddUtilizadores(utilizador), "Ok");

                                    txtNome.Text = "";
                                    txtEmail.Text = "";
                                    txtPassword.Text = "";
                                    txtPassword2.Text = "";

                                    await teste.FadeTo(0, 500, Easing.Linear);

                                    await Navigation.PushModalAsync(new PageLogin());

                                    btnAdd.IsVisible = true;
                                    lblLogin.IsVisible = true;
                                    loading.IsRunning = false;
                                }
                            }
                        }
                    //}
                    //else
                    //{
                        //await DisplayAlert("Erro", "Password deve ter no mínimo 8 caracteres", "Ok");
                    //}
                }
                else
                {
                    await DisplayAlert("Erro", "Email inválido", "Ok");
                    
                    txtEmail.Text = "";
                }
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtPassword2.Text = "";

            await teste.FadeTo(0, 500, Easing.Linear);

            await Navigation.PushModalAsync(new PageLogin());
        }
    }
}