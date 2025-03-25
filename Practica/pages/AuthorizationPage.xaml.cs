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
using System.Xml.Linq;
using Practica.Classes;
namespace Practica.pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        ConnectionClass connnction = new ConnectionClass();

        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string login = TxbLogin.Text.Trim();
                string password = PbxPassword.Password.Trim();
                if (!String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(password))
                {
                    var user = connnction.entities.User.Where(x => x.Login == login && x.Password == password).First();
                    App.currentUser = user;
                    NavigationService.Navigate(new NavigationPage());
                    //login: vilner password: all108023567
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены!", " ", MessageBoxButton.OK, MessageBoxImage.Warning);
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Пользователь с текущими данными не найден", " ", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


        }
    }
}
