using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace WCFSilverlightApp
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SilverlightServiceReference.SilverlightServiceExtensionClient client = new SilverlightServiceReference.SilverlightServiceExtensionClient();
            client.GetValueCompleted += Client_GetValueCompleted;
            client.GetValueAsync();     
        }

        private void Client_GetValueCompleted(object sender, SilverlightServiceReference.GetValueCompletedEventArgs e)
        {
           MessageBox.Show(e.Result);
        }

      
    }
}
