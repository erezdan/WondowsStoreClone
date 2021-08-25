using MiscUtil;
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

namespace WondowsStoreClone.UserControls.AppDetailsTabContent
{
    /// <summary>
    /// Interaction logic for AReview.xaml
    /// </summary>
    public partial class AReview : UserControl
    {
        public List<string> Names;
        public AReview()
        {
            InitializeComponent();

            Names = new List<string>() { "Viktoria", "Mike", "Zoltan", "Maria", "Daniel", "Emma" };
            string reviewerName = Names[StaticRandom.Next(Names.Count)];
            ReviewerNameLabel.Content = reviewerName;
            AvatarLabel.Content = reviewerName[0];
            NumberOfStarsLabel.Content = GetRandomNumOfStars();
            ReviewTitleLabel.Content = GetReviewTitleBasedOnStars(NumberOfStarsLabel.Content.ToString());
        }
        private string GetRandomNumOfStars()
        {
            string content = string.Empty;
            for(int ii = 0; ii < StaticRandom.Next(1, 6); ii++)
            {
                content += "*";
            }
            return content;
        }
        private string GetReviewTitleBasedOnStars(string inputStars)
        {
            if (inputStars.Length >= 4) return "This app is realy awesome";
            if (inputStars.Length == 3) return "This app is all right";
            return "This app is poor";
        }
    }
}
