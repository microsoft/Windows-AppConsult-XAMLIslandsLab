using Microsoft.Toolkit.Win32.UI.XamlHost;
using Microsoft.Toolkit.Wpf.UI.XamlHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoExpenses
{
    public class CalendarViewWrapper: WindowsXamlHostBase
    {
        public CalendarViewWrapper(): base()
        {

        }

        public event EventHandler<SelectedDatesChangedEventArgs> SelectedDatesChanged;

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            this.ChildInternal = UWPTypeFactory.CreateXamlContentByType("Windows.UI.Xaml.Controls.CalendarView");

            SetContent();

            global::Windows.UI.Xaml.Controls.CalendarView calendarView = this.ChildInternal as global::Windows.UI.Xaml.Controls.CalendarView;
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

        protected virtual void OnSelectedDatesChanged(SelectedDatesChangedEventArgs e)
        {
            SelectedDatesChanged?.Invoke(this, e);
        }
    }
}
