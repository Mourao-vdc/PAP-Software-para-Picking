using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageReadBarcode : ContentPage
    {
        public enum BarcodeSearchType
        {
            Artigos,
            Encomendas
        }

        private BarcodeSearchType searchType;

        public PageReadBarcode(BarcodeSearchType _type)
        {
            InitializeComponent();

            this.searchType = _type;
        }

        public string _Scan { get; set; }

        private async void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            Debug.WriteLine("");
            Debug.WriteLine("Result");
            Debug.WriteLine(result.Text);
            Debug.WriteLine("");
            switch (this.searchType)
            {
                case BarcodeSearchType.Artigos:

                    if (result.Text == "")
                    {
                        scanResultText.Text = "Scanning...";
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
                            await Navigation.PopAsync();
                        });
                    }

                    break;

                case BarcodeSearchType.Encomendas:

                    if (result.Text == "")
                    {
                        scanResultText.Text = "Scanning...";
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
                            await Navigation.PopAsync();
                        });
                    }

                    break;

                default:

                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        zxBarCodeReader.IsScanning = false;
                        scanResultText.Text = "Erro!";
                        await DisplayAlert("Erro!", "Selecione o tabela onde deseja procurar", "Ok");
                        zxBarCodeReader.IsScanning = true;
                    });

                    break;


                    /*if (txtTable.SelectedItem.ToString() == "Artigos")
                    {
                        if (result.Text == "")
                        {
                            scanResultText.Text = "Scanning...";
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
                                await Shell.Current.GoToAsync($"//PageDataGridArtigos");
                            });
                            bool bPercorrer = true;

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
                            }
                        }
                    }*/
            }
        }
    }
}