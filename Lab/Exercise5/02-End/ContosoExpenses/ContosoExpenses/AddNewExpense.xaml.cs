// ******************************************************************

// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THE CODE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH
// THE CODE OR THE USE OR OTHER DEALINGS IN THE CODE.

// ******************************************************************

using ContosoExpenses.Models;
using ContosoExpenses.Services;
using Microsoft.Toolkit.Wpf.UI.XamlHost;
using System;
using System.Linq;
using System.Threading;
using System.Windows;

namespace ContosoExpenses
{
    /// <summary>
    /// Interaction logic for AddNewExpense.xaml
    /// </summary>
    public partial class AddNewExpense : Window
    {
        public int EmployeeId { get; set; }

        private DateTime SelectedDate;

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
                    Address = txtLocation.Text,
                    City = txtCity.Text,
                    Cost = Convert.ToDouble(txtAmount.Text),
                    Description = txtDescription.Text,
                    Type = txtType.Text,
                    Date = SelectedDate,
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

        private void CalendarUwp_ChildChanged(object sender, EventArgs e)
        {
            WindowsXamlHost windowsXamlHost = (WindowsXamlHost)sender;

            Windows.UI.Xaml.Controls.CalendarView calendarView =
                (Windows.UI.Xaml.Controls.CalendarView)windowsXamlHost.Child;

            if (calendarView != null)
            {
                calendarView.SelectedDatesChanged += (obj, args) =>
                {
                    if (args.AddedDates.Count > 0)
                    {
                        SelectedDate = args.AddedDates.FirstOrDefault().DateTime;
                        txtDate.Text = SelectedDate.ToShortDateString();
                    }
                };

                calendarView.MinDate = DateTimeOffset.Now.AddYears(-1);
                calendarView.MaxDate = DateTimeOffset.Now;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            CalendarUwp.Dispose();
        }
    }
}
