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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        public EditPage()
        {
            InitializeComponent();
        }

        private void Edit_click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(TxbNumberOfStudent.Text))
            {
                NavigationService.Navigate(new EditStudentPage(Convert.ToInt32(TxbNumberOfStudent.Text)));
            }
            else
            {
                MessageBox.Show("Введите номер студента");
            }
        }
    }
}
