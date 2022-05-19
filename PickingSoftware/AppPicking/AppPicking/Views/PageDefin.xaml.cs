﻿using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageDefin : ContentPage
    {
        public PageDefin()
        {
            InitializeComponent();

            Models.Username _username = new Models.Username
            {
                valor = Models.Username.Nome,
            };

            Debug.Write("||||||");
            Debug.Write("||||||");
            Debug.WriteLine(_username);
            Debug.Write("||||||");
            Debug.Write("||||||");

            this.BindingContext = _username;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Deseja terminar sessão?", "Sim", "Não");
            Debug.WriteLine("Ações: " + action);

            if (action == "Sim")
            {
                await Navigation.PushAsync(new PageLogin());
            }
            else
            {
                return;
            }
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageDataGridEncomendasPerfil());
        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PagePerfil());
        }
    }
}