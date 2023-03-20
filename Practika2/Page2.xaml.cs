using Practika2._Praktika1_1DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

namespace Practika2
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        Pocupatel_TableAdapter pokupatel = new Pocupatel_TableAdapter();
        CoffeeTableAdapter coffee = new CoffeeTableAdapter();
        public Page2()
        {
            InitializeComponent();
            Pocupatel_DataGrid.ItemsSource = pokupatel.GetData();
            coffeeID.ItemsSource = coffee.GetData();
            coffeeID.DisplayMemberPath = "Name";
            coffeeID.SelectedValuePath = "Id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)coffeeID.SelectedValue;
            pokupatel.InsertQuery(Name.Text, id);

            Pocupatel_DataGrid.ItemsSource = pokupatel.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = (int)(Pocupatel_DataGrid.SelectedItem as DataRowView).Row[0];
            pokupatel.DeleteQuery(id);

            Pocupatel_DataGrid.ItemsSource = coffee.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Pocupatel_DataGrid.SelectedItem != null)
            {
                var item = Pocupatel_DataGrid.SelectedItem as DataRowView;
                pokupatel.UpdateQuery(Name.Text, (int)coffeeID.SelectedValue, (int)item.Row[0]);


            }
        }

        private void Pocupatel_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Pocupatel_DataGrid.SelectedItem != null)
            {
                var item = Pocupatel_DataGrid.SelectedItem as DataRowView;
                Name.Text = (string)item.Row[1];
                coffeeID.SelectedValue = (int)item.Row[2];

            }

        }
    }
    
}
