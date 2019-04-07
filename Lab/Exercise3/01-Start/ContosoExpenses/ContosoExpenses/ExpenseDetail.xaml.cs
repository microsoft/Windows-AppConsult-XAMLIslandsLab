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

using System;
using System.Linq;
using System.Windows;
using ContosoExpenses.Models;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using Windows.Services.Maps;

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
            Signature.InkPresenter.InputDeviceTypes = CoreInputDeviceTypes.Mouse | CoreInputDeviceTypes.Pen;

            /// TO-DO Add the token retrieved from https://www.bingmapsportal.com/
            MapService.ServiceToken = "";
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtType.Text = SelectedExpense.Type;
            txtDescription.Text = SelectedExpense.Description;
            txtLocation.Text = SelectedExpense.Address;
            txtAmount.Text = SelectedExpense.Cost.ToString();
            Chart.Height = (SelectedExpense.Cost * 400) / 1000;

            var result = await MapLocationFinder.FindLocationsAsync(SelectedExpense.Address, null);
            var location = result.Locations.FirstOrDefault();
            if (location != null)
            {
                await ExpenseMap.TrySetViewAsync(location.Point, 13);
            }
        }
    }
}
