using AppPicking.Models;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePerfil : ContentPage
    {
        public PagePerfil()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            string _email = (await Models.Utilizador.perfil()).Email;

            Models.Username _username = new Models.Username
            {
                valor = Models.Username.Nome,
                valor2 = _email,
            };

            Debug.Write("||||||");
            Debug.Write("||||||");
            Debug.WriteLine(_username);
            Debug.Write("||||||");
            Debug.Write("||||||");

            this.BindingContext = _username;
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            btnSave.IsVisible = true;
            ShowPassword.IsVisible = true;
            btnPass.IsVisible = false;
            txtpassatual.IsVisible = true;
            txtpassnova.IsVisible = true;
            txtrepetirpass.IsVisible = true;
        }

        private async void btnSave_Clicked(object sender, System.EventArgs e)
        {
            int _id = (await Models.Utilizador.perfil()).ID;

            if (txtpassatual.Text == "" || txtpassatual.Text == null || txtpassnova.Text == "" || txtpassnova.Text == null || txtrepetirpass.Text == "" || txtrepetirpass.Text == null)
            {
                await DisplayAlert("Erro!", "Existem campos por preencher", "Ok");
            }
            else
            {
                if (Models.Cryptography.Decrypt((await Models.Utilizador.perfil()).Password.ToString()) == txtpassatual.Text)
                {
                    if (txtpassnova.Text != txtpassatual.Text && txtrepetirpass.Text == txtpassnova.Text)
                    {
                        Debug.Write("|||");
                        Debug.Write("|||");
                        Utilizador utilizador = new Utilizador()
                        {
                            ID = _id,
                            Password = Models.Cryptography.Encrypt(txtpassnova.Text.ToString())
                        };
                        Debug.Write("|||");
                        Debug.Write("|||");

                        await DisplayAlert("Resposta", await Models.Utilizador.GetEditarPass(utilizador), "Ok");

                        await Navigation.PushAsync(new PageLogin());

                        txtpassatual.Text = "";
                        txtpassnova.Text = "";
                        txtrepetirpass.Text = "";
                        btnPass.IsVisible = true;
                        ShowPassword.IsVisible = false;
                        txtpassatual.IsVisible = false;
                        txtpassnova.IsVisible = false;
                        txtrepetirpass.IsVisible = false;
                        btnSave.IsVisible = false;
                    }
                    else
                    {
                        await DisplayAlert("Erro!", "Verifique os dados inseridos", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Erro!", "A password inserida não coincide com a atual", "Ok");
                }
            }
        }

        private void ShowPassword_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (ShowPassword.IsChecked)
            {
                txtpassatual.IsPassword = false;
                txtpassnova.IsPassword = false;
                txtrepetirpass.IsPassword = false;
            }
            else
            {
                txtpassatual.IsPassword = true;
                txtpassnova.IsPassword = true;
                txtrepetirpass.IsPassword = true;
            }
        }
    }
}