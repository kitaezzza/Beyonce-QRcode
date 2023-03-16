using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QRCoder;

namespace Beyonce
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_generate_Click(object sender, RoutedEventArgs e)
        {
            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(tb_context.Text,QRCodeGenerator.ECCLevel.Q);
            QRCode qR = new QRCode(qRCodeData);
            Bitmap qr = qR.GetGraphic(200);
            img_qrcode.Source = Convert(qr);
        }

        public BitmapImage Convert(Bitmap scr)
        {
            MemoryStream stream = new MemoryStream();
            ((System.Drawing.Bitmap)scr).Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            stream.Seek(0, SeekOrigin.Begin);
            image.EndInit();
            return image;

        }

        private void btn_bip_bip_Click(object sender, RoutedEventArgs e)
        {
            SystemSounds.Beep.Play();
        }
    }
}
