using System;
using System.Linq;
using System.Windows;
using ContosoExpenses.Models;

namespace ContosoExpenses
{
    /// <summary>
    /// Interaction logic for ExpenseDetail.xaml
    /// </summary>
    public partial class ExpenseDetail : Window
    {
        public Expense SelectedExpense { get; set; }

        public ExpenseDetail()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtType.Text = SelectedExpense.Type;
            txtDescription.Text = SelectedExpense.Description;
            txtLocation.Text = SelectedExpense.Address;
            txtAmount.Text = SelectedExpense.Cost.ToString();
        }
    }
}
