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
using System.Windows.Shapes;
using ContosoExpenses.Models;
using ContosoExpenses.Services;

namespace ContosoExpenses
{
    /// <summary>
    /// Interaction logic for ExpensesList.xaml
    /// </summary>
    public partial class ExpensesList : Window
    {
        public int EmployeeId { get; set; }

        private Employee selectedEmployee;

        public ExpensesList()
        {
            InitializeComponent();
        }

        private void OnSelectedExpense(object sender, SelectionChangedEventArgs e)
        {
            var expense = e.AddedItems[0] as Expense;
            ExpenseDetail detail = new ExpenseDetail();
            detail.SelectedExpense = expense;
            detail.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DatabaseService databaseService = new DatabaseService();
            selectedEmployee = databaseService.GetEmployee(EmployeeId);
            ExpensesGrid.ItemsSource = databaseService.GetExpenses(EmployeeId);
        }
    }
}
