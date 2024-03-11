using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using ZXing;
using ZXing.Common;

// Il modello di elemento Pagina vuota è documentato all'indirizzo https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x410

namespace QR64v1
{
    /// <summary>
    /// Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private object txtQRCodeText;

        public MainPage()
        {
            this.InitializeComponent();
        }
        private void GenerateQRCode(object sender, RoutedEventArgs e)
        {
            string text = txtInput.Text;
            if (!string.IsNullOrEmpty(text))
            {
                BarcodeWriter writer = new BarcodeWriter
                {
                    Format = BarcodeFormat.QR_CODE,
                    Options = new EncodingOptions
                    {
                        Height = 300,
                        Width = 300
                    }
                };

                WriteableBitmap bitmap = writer.Write(text);
                imgQRCode.Source = bitmap;
            }
            else
            {
                // Show an error message
                var dialog = new ContentDialog
                {
                    Title = "Error",
                    Content = "Please enter text to generate QR code",
                    CloseButtonText = "Ok"
                };
                dialog.ShowAsync();
            }
        }
    }
}