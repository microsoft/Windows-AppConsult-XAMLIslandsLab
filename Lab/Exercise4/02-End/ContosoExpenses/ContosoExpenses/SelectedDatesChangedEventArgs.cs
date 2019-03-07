using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoExpenses
{
    public class SelectedDatesChangedEventArgs : EventArgs
    {
        public IReadOnlyList<DateTimeOffset> SelectedDates { get; set; }

        public SelectedDatesChangedEventArgs(IReadOnlyList<DateTimeOffset> selectedDates)
        {
            this.SelectedDates = selectedDates;
        }
    }
}