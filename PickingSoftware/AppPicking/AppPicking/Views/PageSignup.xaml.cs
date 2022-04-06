using AppPicking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (//(string.IsNullOrEmpty(txtID.Text)) || (string.IsNullOrWhiteSpace(txtID.Text)
                 (string.IsNullOrEmpty(txtNome.Text) || (string.IsNullOrWhiteSpace(txtNome.Text)
                || (string.IsNullOrEmpty(txtPassword.Text) || (string.IsNullOrWhiteSpace(txtPassword.Text)
                || (string.IsNullOrEmpty(txtEmail.Text) || (string.IsNullOrWhiteSpace(txtEmail.Text)
                || (string.IsNullOrEmpty(txtPassword2.Text) || (string.IsNullOrWhiteSpace(txtPassword2.Text))))))))))
            {
                await DisplayAlert("Alerta", "Existem campos por preencher", "Ok");
                return;
            }
            else
            {
                if(txtPassword.Text != txtPassword2.Text)
                {
                    await DisplayAlert("Alerta", "As passwords não coincidem", "Ok");
                    return;
                }
                else
                {
                    Utilizador utilizador = new Utilizador()
                    {
                        Nome = txtNome.Text,
                        Email = txtEmail.Text,
                        Password = txtPassword.Text,
                    };

                    await Utilizador.AddUtilizadores(utilizador);

                    DisplayAlert("Adicionado", "Artigo adiciocado com sucesso", "Ok");

                    txtNome.Text = "";
                    txtEmail.Text = "";
                    txtPassword.Text = "";
                    txtPassword2.Text = "";

                    await Shell.Current.GoToAsync($"//{nameof(PageLogin)}");
                }
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(PageLogin)}");
        }
    }
}