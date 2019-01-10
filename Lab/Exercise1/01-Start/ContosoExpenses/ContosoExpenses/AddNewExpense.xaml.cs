using ContosoExpenses.Models;
using ContosoExpenses.Services;
using System;
using System.Windows;

namespace ContosoExpenses
{
    /// <summary>
    /// Interaction logic for AddNewExpense.xaml
    /// </summary>
    public partial class AddNewExpense : Window
    {
        public int EmployeeId { get; set; }

        public AddNewExpense()
        {
            InitializeComponent();
        }

        private void OnSaveExpense(object sender, RoutedEventArgs e)
        {
            try
            {
                Expense expense = new Expense
                {
                    Address = txtAmount.Text,
                    City = txtCity.Text,
                    Cost = Convert.ToDouble(txtAmount.Text),
                    Description = txtDescription.Text,
                    Type = txtType.Text,
                    Date = txtDate.SelectedDate.GetValueOrDefault(),
                    EmployeeId = EmployeeId
                };

                DatabaseService service = new DatabaseService();
                service.SaveExpense(expense);
                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Validation error. Please check your data.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
