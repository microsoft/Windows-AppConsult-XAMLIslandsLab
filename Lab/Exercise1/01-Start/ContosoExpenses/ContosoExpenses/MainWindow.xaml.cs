using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ContosoExpenses.Models;
using ContosoExpenses.Services;

namespace ContosoExpenses
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            List<Employee> customers = new List<Employee>();
            DatabaseService db = new DatabaseService();
            db.InitializeDatabase();

            CustomersGrid.ItemsSource = db.GetEmployees();
        }

        private void OnSelectedEmployee(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var employee = e.AddedItems[0] as Employee;
                if (employee != null && employee.EmployeeId != 0)
                {
                    ExpensesList detail = new ExpensesList();
                    detail.EmployeeId = employee.EmployeeId;
                    detail.Show();
                }
            }
        }

        private void OnOpenAbout(object sender, RoutedEventArgs e)
        {
            AboutView about = new AboutView();
            about.ShowDialog();
        }
    }
}
