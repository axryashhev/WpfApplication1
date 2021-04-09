using System.Windows;
using System.Windows.Controls;

namespace WpfApplication1
{
    public partial class QuestionTwo : Page
    {
        public QuestionTwo()
        {
            InitializeComponent();
        }

        private void NextView(object sender, RoutedEventArgs e)
        {
            var navigationService = this.NavigationService;
            navigationService?.Navigate(new QuestionTwo());
        }
    }
}