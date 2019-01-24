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

            MapService.ServiceToken = "IFFAI5SFOtHV9VBKF8Ea~3FS1XamCV2NM0IqlfoQo6A~AguqcUboJvnqWU1H9E-6MVThouJoCrM4wpv_1R_KX_oQLV_e59vyoK42470JvLsU";
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

        private void Window_Closed(object sender, EventArgs e)
        {
            Signature.Dispose();
            ExpenseMap.Dispose();
        }
    }
}
