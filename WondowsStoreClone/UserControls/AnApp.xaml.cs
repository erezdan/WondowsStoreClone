using MiscUtil;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
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

namespace WondowsStoreClone.UserControls
{
    public partial class AnApp : UserControl
    {
        public string AppName;
        public ImageSource AppImageSource;

        public delegate void OnAppClicked(AnApp sender, RoutedEventArgs e);
        public event OnAppClicked AppClicked;

        public AnApp()
        {
            InitializeComponent();

            List<string> filePaths = Directory.GetFiles(Environment.CurrentDirectory + @"\..\..\Images\", "*.png").ToList();
            FileInfo randomFile = new FileInfo(filePaths[StaticRandom.Next(filePaths.Count)]);
            ProductImage.Source = new BitmapImage(new Uri(randomFile.FullName, UriKind.RelativeOrAbsolute));
            AppNameText.Text = (new CultureInfo("en-US", false).TextInfo).ToTitleCase(randomFile.Name.Split('-').Last().Split('.').First());

            AppName = AppNameText.Text;
            AppImageSource = ProductImage.Source;
        }

        public AnApp(string inAppName, ImageSource inImageSource)
        {
            InitializeComponent();
            ProductImage.Source = inImageSource;
            AppNameText.Text = inAppName;
            AppImageSource = inImageSource;
        }

        private void ProductImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            AppClicked(this, e);
        }
    }
}
