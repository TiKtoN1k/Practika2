using Practika2._Praktika1_1DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        CoffeeTableAdapter coffee = new CoffeeTableAdapter();
        public Page1()
        {
            InitializeComponent();
            CoffeeDataGrid.ItemsSource = coffee.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            coffee.InsertQuery(Name.Text, Convert.ToInt16(Razmer.Text), Convert.ToInt16(Price.Text));
            CoffeeDataGrid.ItemsSource = coffee.GetData();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = (int)(CoffeeDataGrid.SelectedItem as DataRowView).Row[0];
            coffee.DeleteQuery(id);

            CoffeeDataGrid.ItemsSource = coffee.GetData();
        }

        private void CoffeeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CoffeeDataGrid.SelectedItem != null)
            {
                var item = CoffeeDataGrid.SelectedItem as DataRowView;
                Name.Text = (string)item.Row[1];
                Razmer.Text = Convert.ToInt16(item.Row[2]).ToString();
                Price.Text = Convert.ToInt16(item.Row[3]).ToString();

            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (CoffeeDataGrid.SelectedItem != null)
            {
                var item = CoffeeDataGrid.SelectedItem as DataRowView;
                coffee.UpdateQuery(Name.Text, Convert.ToInt16(Razmer.Text),Convert.ToInt16(Price.Text), (int)item.Row[0]);
                CoffeeDataGrid.ItemsSource= coffee.GetData();

            }
       
        }
    }
}