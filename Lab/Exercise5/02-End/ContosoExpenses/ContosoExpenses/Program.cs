using Microsoft.Toolkit.Win32.UI.XamlHost;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoExpenses
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            using (var xamlApp = new XamlApplication())
            {
                var app = new App();
                app.InitializeComponent();
                app.Run();
            }
        }
    }
}
