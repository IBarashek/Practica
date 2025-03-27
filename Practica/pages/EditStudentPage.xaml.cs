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
    /// Логика взаимодействия для EditStudentPage.xaml
    /// </summary>
    public partial class EditStudentPage : Page
    {
        ConnectionClass connection = new ConnectionClass();
        int number;
        public EditStudentPage(int studentNumber)
        {
            InitializeComponent();
            TxbName.Text = connection.entities.Student.Where(x => studentNumber == x.Id_student).First().Name;
            TxbSecondName.Text = connection.entities.Student.Where(x => studentNumber == x.Id_student).First().SecondName;
            TxbDescription.Text = connection.entities.Student.Where(x => studentNumber == x.Id_student).First().Description;
            TxbLastName.Text = connection.entities.Student.Where(x => studentNumber == x.Id_student).First().LastName;
            TxbGroup.Text = connection.entities.Group.Where(x => x.Id_Group ==
            (connection.entities.Student.Where(y => studentNumber == y.Id_student).FirstOrDefault().Id_Group) ).Select(x => x.Name).FirstOrDefault().ToString();
            number = studentNumber;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = TxbName.Text;
                string secondName = TxbSecondName.Text;
                string lastName = TxbLastName.Text;
                string description = TxbDescription.Text;
                string group = TxbGroup.Text;
                int aaaaaaa = Convert.ToInt32(group);
                if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(secondName)
                    && !String.IsNullOrEmpty(lastName) && !String.IsNullOrEmpty(group))
                {
                    //нет удаления данных
                    Student studentDelete = new Student();
                    studentDelete = connection.entities.Student.Where(x =>
                    x.Id_student == number).FirstOrDefault();
                    connection.entities.Student.Remove(studentDelete);
                    connection.entities.SaveChanges();
                    int n = connection.entities.Group.Where(x => x.Name == aaaaaaa).FirstOrDefault().Id_Group;
                    StudentClass studentAdd = new StudentClass();
                    studentAdd.NewStudent(name, secondName, lastName, n, description);
                    MessageBox.Show("Данные студента были изменены");
                    NavigationService.Navigate(new DefaultPage());
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
