using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

namespace SfDataGridDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var index = 0;
            if (dataGrid.View != null)
            {
                var group = dataGrid.View.Groups[index] as Group;
                ExpandGroupToChild(dataGrid, group);
            }
        }

        private static void ExpandGroupToChild(SfDataGrid grid, Group start)
        {
            var current = start;
            while (current != null)
            {
                grid.ExpandGroup(current);
                if (current.Groups == null || current.Groups.Count == 0)
                    break;

                current = current.Groups[0] as Group;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var index = 0;
            if (dataGrid.View != null)
            {
                var group = dataGrid.View.Groups[index] as Group;
                CollapseGroupToChild(dataGrid, group);
            }
        }

        private static void CollapseGroupToChild(SfDataGrid grid, Group start)
        {
            var current = start;
            var chain = new List<Group>();
            while (current != null)
            {
                if (current.Groups == null || current.Groups.Count == 0)
                {
                    chain.Add(current);
                    break;
                }
                chain.Add(current);
                current = current.Groups[0] as Group;
            }

            for (int i = chain.Count - 1; i >= 0; i--)
                grid.CollapseGroup(chain[i]);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.dataGrid.View.BeginInit();
            this.dataGrid.GroupColumnDescriptions.Add(new GroupColumnDescription() { ColumnName = "OrderID" });
            this.dataGrid.GroupColumnDescriptions.Add(new GroupColumnDescription() { ColumnName = "CustomerID" });
            this.dataGrid.GroupColumnDescriptions.Add(new GroupColumnDescription() { ColumnName = "CustomerName" });
            this.dataGrid.GroupColumnDescriptions.Add(new GroupColumnDescription() { ColumnName = "Country" });
            this.dataGrid.GroupColumnDescriptions.Add(new GroupColumnDescription() { ColumnName = "ShipCity" });
            this.dataGrid.View.EndInit();
        }
    }
}
