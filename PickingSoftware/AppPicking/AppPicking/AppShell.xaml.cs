﻿using AppPicking.Views;
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
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync("//LoginPage");
            await Shell.Current.GoToAsync($"//{nameof(PageDataGridEncomendas)}");
        }
    }
}
