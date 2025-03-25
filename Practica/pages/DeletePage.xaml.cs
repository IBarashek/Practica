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
    /// Логика взаимодействия для DeletePage.xaml
    /// </summary>
    public partial class DeletePage : Page
    {
        ConnectionClass connection = new ConnectionClass();
        public DeletePage()
        {
            InitializeComponent();
        }

        private void Delete_click(object sender, RoutedEventArgs e)
        {
            try
            {
                string numberOfStudent = TxbNumberOfStudent.Text.Trim();
                if (!String.IsNullOrEmpty(numberOfStudent))
                {
                    int number = int.Parse(numberOfStudent);
                    Student student = new Student();
                    student = connection.entities.Student.Where(x =>
                    x.Id_student == number).FirstOrDefault();
                    connection.entities.Student.Remove(student);
                    MessageBox.Show("Студент был удален");
                    NavigationService.Navigate(new DefaultPage());
                }
                else
                {
                    MessageBox.Show("Поле не заполнено");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Такого студента не существует");
            }
        }
    }
}
