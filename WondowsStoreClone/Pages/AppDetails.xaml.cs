using System;
using System.Collections.Generic;
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
using WondowsStoreClone.UserControls;

namespace WondowsStoreClone.Pages
{
    /// <summary>
    /// Interaction logic for AppDetails.xaml
    /// </summary>
    public partial class AppDetails : Page
    {
        public delegate void OnBackButtonClicked(object sender, RoutedEventArgs e);
        public event OnBackButtonClicked BackButtonClicked;

        public AppDetails(AnApp anApp)
        {
            InitializeComponent();

            AppDetaildTitleAndBackgroundUC.AppNameLable.Content = anApp.AppName;
            AppDetaildTitleAndBackgroundUC.AppImage.Source = anApp.AppImageSource;
            AppDetaildTitleAndBackgroundUC.BackButtonClicked += AppDetaildTitleAndBackgroundUC_BackButtonClicked;
        }

        private void AppDetaildTitleAndBackgroundUC_BackButtonClicked(object sender, RoutedEventArgs e)
        {
            BackButtonClicked?.Invoke(sender, e);
        }
    }
}
