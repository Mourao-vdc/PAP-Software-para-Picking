﻿using AppPicking.Services;
using AppPicking.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
