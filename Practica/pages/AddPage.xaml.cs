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
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        string connectionString;
        public AddPage()
        {
            InitializeComponent();

            try
            {
                connectionString = ConfigurationManager
                    .ConnectionStrings[0].ConnectionString;//не разрешает подключиться к бд либо хз что не так
                con = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM NameOfGroup";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    CmbGroup.Items.Add(dr["NAme"]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = TxbName.Text;
                string secondName = TxbSecondName.Text;
                string lastName = TxbLastName.Text;
                string group = CmbGroup.Text;
                string description = TxbDescription.Text;
                if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(secondName) 
                    && !String.IsNullOrEmpty(lastName) /*&& !String.IsNullOrEmpty(group)*/)
                {
                    StudentClass student = new StudentClass();
                    student.NewStudent(name, secondName, lastName, 1, description);
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
