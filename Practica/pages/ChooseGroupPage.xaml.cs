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
    /// Логика взаимодействия для ChooseGroupPage.xaml
    /// </summary>
    public partial class ChooseGroupPage : Page
    {
        ConnectionClass connection = new ConnectionClass();
        public ChooseGroupPage(string group)
        {
            int g = Convert.ToInt32(group);
            InitializeComponent();
            DgStudents.ItemsSource = connection.entities.Student.Where(x => x.Id_Group == 
            (connection.entities.Group.Where(y => g == y.Name).FirstOrDefault().Id_Group)).ToList();
        }
    }
}
