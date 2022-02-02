using Software_Picking.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Software_Picking.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}