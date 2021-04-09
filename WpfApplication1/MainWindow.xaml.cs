using System.Windows;
using System.Windows.Controls;
using WpfApplication1.Controller;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var controller = MainController.GetInstance();
            var viewDataStudents = (TextBlock)this.FindName("ViewDataStudents");
            var viewDataScientificAdvisors = (TextBlock)this.FindName("ViewDataScientificAdvisors");
            // viewData.Text = controller.Students.ToString() + "\n\n" + controller.ScientificAdvisors.ToString();
            
            if (viewDataScientificAdvisors != null)
                viewDataScientificAdvisors.Text = controller.OutputListData(controller.ScientificAdvisors);

            if (viewDataStudents != null) 
                viewDataStudents.Text = controller.OutputListData(controller.Students);
            
        }

        private void NextView(object sender, RoutedEventArgs e)
        {
            var navigationService = this.NavigationService;
            navigationService?.Navigate(new QuestionOne());
        }
    }
}