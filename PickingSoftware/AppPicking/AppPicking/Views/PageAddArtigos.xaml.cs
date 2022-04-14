using AppPicking.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAddArtigos : ContentPage
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cod_Barras { get; set; }

        public PageAddArtigos()
        {
            InitializeComponent();

        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            if (//(string.IsNullOrEmpty(txtID.Text)) || (string.IsNullOrWhiteSpace(txtID.Text)
                 (string.IsNullOrEmpty(txtNome.Text) || (string.IsNullOrWhiteSpace(txtNome.Text)
                || (string.IsNullOrEmpty(txtCod_Barras.Text) || (string.IsNullOrWhiteSpace(txtCod_Barras.Text)))))){

                await DisplayAlert("Alerta", "Existem campos por preencher", "Ok");
                return;
            }
            else
            {

                Artigos artigos = new Artigos()
                {
                    //ID = Convert.ToInt16(txtID.Text);
                    Nome = txtNome.Text,
                    Cod_Barras = txtCod_Barras.Text,
                };

                Debug.WriteLine("");
                Debug.WriteLine("NOME");
                Debug.WriteLine(artigos.Nome);
                Debug.WriteLine("");

                /*if (await Artigos.AddArtigos(artigos))
                    DisplayAlert("Adicionado", "Artigo adiciocado com sucesso", "Ok");

                else*/
                    await DisplayAlert("Resposta", await Artigos.AddArtigos(artigos), "Ok");

                txtNome.Text = "";
                txtCod_Barras.Text = "";
            }           
        }
    }
}