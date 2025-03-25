using Practica.Classes;
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

namespace Practica.pages
{
    /// <summary>
    /// Логика взаимодействия для NavigationPage.xaml
    /// </summary>
    public partial class NavigationPage : Page
    {
        public NavigationPage()
        {
            InitializeComponent();
        }

        private void ClickNavigation(object sender, RoutedEventArgs e)
        {
            
            Button button = sender as Button;
            if (button.Name == "BtnAdd")
            {
                NavigationFrame.NavigationService.Navigate(new AddPage());
            }
            else if (button.Name == "BtnEdit")
            {
                NavigationFrame.NavigationService.Navigate(new EditPage());
            }
            else if (button.Name == "BtnDelete")
            {
                NavigationFrame.NavigationService.Navigate(new DeletePage());
            }
            else if(button.Name == "BtnFilter")
            {
                NavigationFrame.NavigationService.Navigate(new GroupPage());
            }
            else
            {
                NavigationFrame.NavigationService.Navigate(new StudentsPage());
            }
        }
    }
}
