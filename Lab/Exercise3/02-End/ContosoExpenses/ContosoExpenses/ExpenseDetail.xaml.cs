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
            MapService.ServiceToken = "IFFAI5SFOtHV9VBKF8Ea~3FS1XamCV2NM0IqlfoQo6A~AguqcUboJvnqWU1H9E-6MVThouJoCrM4wpv_1R_KX_oQLV_e59vyoK42470JvLsU";
            SignatureCanvas.InkPresenter.InputDeviceTypes = CoreInputDeviceTypes.Mouse | CoreInputDeviceTypes.Pen;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtType.Text = SelectedExpense.Type;
            txtDescription.Text = SelectedExpense.Description;
            txtLocation.Text = SelectedExpense.Address;
            txtAmount.Text = SelectedExpense.Cost.ToString();

            BasicGeoposition queryHint = new BasicGeoposition();
            queryHint.Latitude = 47.643;
            queryHint.Longitude = -122.131;
            Geopoint hintPoint = new Geopoint(queryHint);

            var result = await MapLocationFinder.FindLocationsAsync(SelectedExpense.Address, null);
            var location = result.Locations.FirstOrDefault();
            if (location != null)
            {
                await UserLocation.TrySetViewAsync(location.Point, 13);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UserLocation.Dispose();
            SignatureCanvas.Dispose();
        }
    }
}
