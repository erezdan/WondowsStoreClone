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

namespace WondowsStoreClone.UserControls
{
    /// <summary>
    /// Interaction logic for AppsViewer.xaml
    /// </summary>
    public partial class AppsViewer : UserControl
    {
        List<AnApp> PresentedApps;
        public delegate void OnAppClicked(AnApp sender, RoutedEventArgs e);
        public event OnAppClicked AppClicked;

        public AppsViewer()
        {
            InitializeComponent();

            try
            {
                PresentedApps = new List<AnApp>();
                AppsList.ItemsSource = PresentedApps;
                for (int ii = 0; ii < 9; ii++)
                {
                    AnApp app = new AnApp();
                    app.AppClicked += CurrAppClicked;
                    PresentedApps.Add(app);
                }
            }
            catch { }
        }
        private void CurrAppClicked(AnApp sender, RoutedEventArgs e)
        {
            AppClicked?.Invoke(sender, e);
        }

        private void ScrollLeft_Click(object sender, RoutedEventArgs e)
        {
            int widthOfOneApp = (int)(PresentedApps.First().ActualWidth + 2 * PresentedApps.First().Margin.Left);
            AppsScrollView.ScrollToHorizontalOffset(AppsScrollView.HorizontalOffset - 2 * widthOfOneApp);
        }

        private void ScrollRight_Click(object sender, RoutedEventArgs e)
        {
            int widthOfOneApp = (int)(PresentedApps.First().ActualWidth + 2 * PresentedApps.First().Margin.Left);
            AppsScrollView.ScrollToHorizontalOffset(AppsScrollView.HorizontalOffset + 2 * widthOfOneApp);
        }

        private void AppsScrollView_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
            var eventArgs = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
            eventArgs.RoutedEvent = UIElement.MouseWheelEvent;
            eventArgs.Source = sender;
            var parent = ((Control)sender).Parent as UIElement;
            parent.RaiseEvent(eventArgs);
        }
    }
}
