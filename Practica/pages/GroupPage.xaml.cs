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
    /// Логика взаимодействия для GroupPage.xaml
    /// </summary>
    public partial class GroupPage : Page
    {
        ConnectionClass connection = new ConnectionClass();
        public GroupPage()
        {
            InitializeComponent();
            LtvProgramming.ItemsSource = connection.entities.Group.Where(x => x.Id_NameOfGroup == 1).Select(
                x => x.Name).ToList();
            LtvPhusicalCulture.ItemsSource = connection.entities.Group.Where(x => x.Id_NameOfGroup == 4).Select(
                x =>  x.Name ).ToList();
            LtvPrepodavN.ItemsSource = connection.entities.Group.Where(x => x.Id_NameOfGroup == 2).Select(
                x =>  x.Name ).ToList();
            LtvPreSchool.ItemsSource = connection.entities.Group.Where(x => x.Id_NameOfGroup == 3).Select(
                x => x.Name ).ToList();
        }

        void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListViewItem listViewItem = sender as ListViewItem;
            NavigationService.Navigate(new ChooseGroupPage(listViewItem.Content.ToString()));
        }
    }
}
