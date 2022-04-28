using System;
using System.Diagnostics;
using System.Net.Mail;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageRecuperarConta : ContentPage
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public PageRecuperarConta()
        {
            InitializeComponent();
        }

        //public static async void PassDados()
        //{
        //    Models.Utilizador _user = new Models.Utilizador()
        //    {
        //        Email = Models.PassValor.recup,
        //    };

        //    if(await Models.Utilizador.SendEmail(_user.ToString()))
        //    {
        //        Models.RecupEmail.nome = _user.Nome.ToString();
        //        Models.RecupEmail.pass = _user.Password.ToString();
        //    }
        //}

        public static void SendEmail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("nsns9877@gmail.com");
                mail.To.Add(Models.PassValor.recup);
                mail.Subject = "Recuperar conta";
                mail.Body ="Teste";

                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("nsns9877@gmail.com", "eunaosei");

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Debug.Write("||||||");
                Debug.Write("||||||");
                Debug.WriteLine(ex.ToString());
                Debug.Write("||||||");
                Debug.Write("||||||");
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Models.PassValor.recup = txtEmail.Text;

            if (await Models.Utilizador.VerifyEmail(txtEmail.Text))
            {
                try
                {
                    SendEmail();
                    await DisplayAlert("Sucesso!", "Recuperação enviada com sucesso", "Ok");
                    txtEmail.Text = "";
                    await teste.FadeTo(0, 500, Easing.Linear);

                    await Navigation.PushModalAsync(new PageLogin());
                }
                catch
                {
                    await DisplayAlert("Erro!", "Ocorreu um erro ao enviar o email", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Erro!", "Não existe nenhuma conta com o email inserido", "Ok");

                txtEmail.Text = "";
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await teste.FadeTo(0, 500, Easing.Linear);

            await Navigation.PushModalAsync(new PageLogin());
        }
    }
}