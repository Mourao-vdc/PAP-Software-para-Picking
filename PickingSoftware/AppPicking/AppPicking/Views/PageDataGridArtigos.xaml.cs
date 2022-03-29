using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageDataGridArtigos : ContentPage
    {
        public PageDataGridArtigos()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            lvArtigos.ItemsSource = new ObservableCollection<Models.Artigos>(await Models.Artigos.GetEncomendas());
        }

    }
}