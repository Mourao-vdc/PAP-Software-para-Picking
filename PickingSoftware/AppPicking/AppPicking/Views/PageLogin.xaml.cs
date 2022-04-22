﻿using System;
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

            Debug.Write("||||||");
            Debug.Write("PageLogin");
            Debug.Write("||||||");

            Models.Utilizador _user = new Models.Utilizador()
            {
                Nome = txtNome.Text,
                Password = txtPassword.Text
            };

            if(await Models.Utilizador.Userlogin(_user))
            {
                //Models.Username.Nome = txtNome.Text;

                //Debug.Write(Models.Username.Nome);

                txtNome.Text = "";
                txtPassword.Text = "";

                await Shell.Current.GoToAsync($"//{nameof(PageDataGridEncomendas)}");
            }
            else
            {
                await DisplayAlert("Erro","Nome ou Password incorreta","Ok");
            }

            Debug.Write("||||||");
            Debug.Write("PageLogin");
            Debug.Write("||||||");

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtPassword.Text = "";

            await Shell.Current.GoToAsync($"//{nameof(PageSignup)}");
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
    }
}