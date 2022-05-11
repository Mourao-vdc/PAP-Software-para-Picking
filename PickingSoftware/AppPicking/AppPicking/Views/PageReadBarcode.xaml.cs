using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageReadBarcode : ContentPage
    {
        public PageReadBarcode()
        {
            InitializeComponent();
        }

        public string _Scan { get; set; }

        private async void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            Debug.WriteLine("");
            Debug.WriteLine("Result");
            Debug.WriteLine(result.Text);
            Debug.WriteLine("");
            if (txtTable.SelectedItem.ToString() == "Artigos")
            {
                if (result.Text == "")
                {
                    scanResultText.Text = "A procurar...";
                }
                else
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        zxBarCodeReader.IsScanning = false;
                        scanResultText.Text = result.Text + " (type: " + result.BarcodeFormat.ToString() + ")";
                        await DisplayAlert("Sucesso", "Scan realizado com sucesso!", "Ok");
                        Models.PassValor.scan = result.Text;
                        zxBarCodeReader.IsScanning = true;
                        await Shell.Current.GoToAsync($"//PageDataGridArtigos"); ;
                    });
                    /*bool bPercorrer = true;

                    while (bPercorrer)
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            zxBarCodeReader.IsScanning = false;
                            scanResultText.Text = result.Text + " (type: " + result.BarcodeFormat.ToString() + ")";
                            string action = await DisplayActionSheet("Deseja visuzalizar o codigo na aplicação?", "Sim", "Não");
                            Debug.WriteLine("Ações: " + action);
                            if (action == "Sim")
                            {
                                bPercorrer = false;
                            }
                        });
                    }*/
                }
            }
            if (txtTable.SelectedItem.ToString() == "Pedidos")
            {
                if (result.Text == "")
                {
                    scanResultText.Text = "A procurar...";
                }
                else
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        zxBarCodeReader.IsScanning = false;
                        scanResultText.Text = result.Text + " (type: " + result.BarcodeFormat.ToString() + ")";
                        await DisplayAlert("Sucesso", "Scan realizado com sucesso!", "Ok");
                        Models.PassValor.scan = result.Text;
                        zxBarCodeReader.IsScanning = true;
                        txtTable.SelectedIndex = -1;
                        await Shell.Current.GoToAsync($"//PageDataGridEncomendasArtigos");
                    });
                }
            }
            if(txtTable.SelectedItem.ToString() == "")
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    zxBarCodeReader.IsScanning = false;
                    scanResultText.Text = "Erro";
                    await DisplayAlert("Erro!", "Selecione onde quer procurar pelo códgio de barras", "Ok");
                    zxBarCodeReader.IsScanning = true;
                });
            }

            Debug.WriteLine("");
            Debug.WriteLine("Status");
            Debug.WriteLine(zxBarCodeReader.IsScanning.ToString());
            Debug.WriteLine("");

            //zxBarCodeReader.IsScanning = true;
        }
    }
}