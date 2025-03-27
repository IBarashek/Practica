using Practica.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
    public partial class AddPage : Page
    {
        ConnectionClass connection = new ConnectionClass();
        public AddPage()
        {
            InitializeComponent();
            CmbGroup.ItemsSource = connection.entities.Group.ToList();
            CmbGroup.DisplayMemberPath = "Name";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = TxbName.Text;
                string secondName = TxbSecondName.Text;
                string lastName = TxbLastName.Text;
                string description = TxbDescription.Text;
                if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(secondName)
                    && !String.IsNullOrEmpty(lastName) && CmbGroup.SelectedItem != null)
                {
                    int aaaaa = Convert.ToInt32(CmbGroup.Text);
                    int n = connection.entities.Group.Where(x => x.Name == aaaaa).FirstOrDefault().Id_Group;
                    StudentClass student = new StudentClass();
                    student.NewStudent(name, secondName, lastName, n, description);
                    MessageBox.Show("Студент добавлен");
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
