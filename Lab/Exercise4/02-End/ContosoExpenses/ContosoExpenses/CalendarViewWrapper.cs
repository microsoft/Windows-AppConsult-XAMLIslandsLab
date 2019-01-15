using Microsoft.Toolkit.Win32.UI.XamlHost;
using Microsoft.Toolkit.Wpf.UI.XamlHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoExpenses
{
    public class CalendarViewWrapper : WindowsXamlHostBase
    {
        public CalendarViewWrapper() : base()
        {

        }

        public event EventHandler<SelectedDatesChangedEventArgs> SelectedDatesChanged;

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            this.ChildInternal = UWPTypeFactory.CreateXamlContentByType("Windows.UI.Xaml.Controls.CalendarView");

            SetContent();

            Windows.UI.Xaml.Controls.CalendarView calendarView = this.ChildInternal as Windows.UI.Xaml.Controls.CalendarView;
            calendarView.SelectedDatesChanged += CalendarView_SelectedDatesChanged;
        }

        private void CalendarView_SelectedDatesChanged(Windows.UI.Xaml.Controls.CalendarView sender, Windows.UI.Xaml.Controls.CalendarViewSelectedDatesChangedEventArgs args)
        {
            OnSelectedDatesChanged(new SelectedDatesChangedEventArgs(args.AddedDates));
        }

        public IList<DateTimeOffset> SelectedDates
        {
            get
            {
                if (this.ChildInternal != null)
                {
                    global::Windows.UI.Xaml.Controls.CalendarView calendarView = this.ChildInternal as global::Windows.UI.Xaml.Controls.CalendarView;
                    return calendarView.SelectedDates;
                }

                return null;
            }
        }

        private DateTimeOffset minDate;

        public DateTimeOffset MinDate
        {
            get { return minDate; }
            set
            {
                if (this.ChildInternal != null)
                {
                    minDate = value;
                    Windows.UI.Xaml.Controls.CalendarView calendarView = this.ChildInternal as global::Windows.UI.Xaml.Controls.CalendarView;
                    calendarView.MinDate = value;
                }
            }
        }

        private DateTimeOffset maxDate;

        public DateTimeOffset MaxDate
        {
            get { return maxDate; }
            set
            {
                if (this.ChildInternal != null)
                {
                    maxDate = value;
                    Windows.UI.Xaml.Controls.CalendarView calendarView = this.ChildInternal as global::Windows.UI.Xaml.Controls.CalendarView;
                    calendarView.MaxDate = value;
                }
            }
        }

        protected virtual void OnSelectedDatesChanged(SelectedDatesChangedEventArgs e)
        {
            SelectedDatesChanged?.Invoke(this, e);
        }
    }
}
