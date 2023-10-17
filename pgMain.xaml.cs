using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace WPF_SmartHome_V3._23._10
{
    /// <summary>
    /// Interaction logic for pgMain.xaml
    /// </summary>
    public partial class pgMain : Page
    {
        
        public pgMain()
        {
            InitializeComponent();
            
        }

        private void btnLukitus_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new pgLukitus());
        }

        private void btnLammitys_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Lammitys());
        }

        private void btnValot_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new pgValaistus());
        }

        private void btnSauna_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new pgSauna());
        }
        
    }
}
   
