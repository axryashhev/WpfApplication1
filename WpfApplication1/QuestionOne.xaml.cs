using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfApplication1.Controller;
using WpfApplication1.Models;

namespace WpfApplication1
{
    public partial class QuestionOne : Page
    {
        private readonly MainController _controller = MainController.GetInstance();
        public QuestionOne()
        {
            InitializeComponent(); ;
            // var viewLabel = (TextBlock) this.FindName("ViewLabel");
            // viewLabel.Text = "Данные по студентам мужского пола.";
        }


        private void ComboBox_Selected(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            var selectedItem = comboBox.SelectedIndex;
            var viewLabel = (TextBlock) this.FindName("ViewLabel");
            var viewData = (TextBlock) this.FindName("ViewData1");   
            char sex = '\0';
            if (selectedItem == 0)
            {
                if (viewLabel != null) viewLabel.Text = "Данные по студентам мужского пола.";
                sex = 'M';
            }
            else if (selectedItem == 1)
            {
                if (viewLabel != null) viewLabel.Text = "Данные по студентам женского пола.";
                sex = 'Ж';
            }

            var request = from student in _controller.Students where student.Sex == sex select student;
            var list = new List<Student>(request);
            if (viewData != null) viewData.Text = _controller.OutputListData(list);
        }

        private void NextView(object sender, RoutedEventArgs e)
        {
            var navigationService = this.NavigationService;
            navigationService?.Navigate(new QuestionTwo());
        }
    }
}