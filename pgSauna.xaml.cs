using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO;

namespace WPF_SmartHome_V3._23._10
{
    /// <summary>
    /// Interaction logic for pgSauna.xaml
    /// </summary>
    public partial class pgSauna : Page
    {
        public DispatcherTimer SaunaTemp = new DispatcherTimer();
        Sauna Sauna1 = new Sauna();
        
        public pgSauna()
        {
            InitializeComponent();
            //Load_Settings();
            Sauna1.SaunanLampo = Thermostat.Huoneistolämpö;
            txtLampotila.Text = Sauna1.SaunanLampo.ToString();

            SaunaTemp.Tick += TmpSimulation;
            SaunaTemp.Interval = new TimeSpan(0, 0, 0, 0,5);
            
        }
        private void TmpSimulation(object sender, EventArgs e)
        {
            if (Sauna1.Switched == true)
            {
                
                txtLampotila.Text = Sauna1.SaunanLampo.ToString();
                if (Sauna1.SaunanLampo < 86) 
                {
                    Sauna1.SaunanLampo++;
                    txtLampotila.Text = Sauna1.SaunanLampo.ToString();
                }
            }
            else if (Sauna1.Switched == false) 
            {
                Sauna1.SaunanLampo--;
                txtLampotila.Text = Sauna1.SaunanLampo.ToString();
                if (Sauna1.SaunanLampo == Thermostat.Huoneistolämpö)
                {
                    txtLampotila.Text = Sauna1.SaunanLampo.ToString();
                    SaunaTemp.Stop();
                }
            }
        }
        private void btnPaavalikko_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        private void SaunaOFF_Click(object sender, RoutedEventArgs e)
        {
            Sauna1.SaunaPois();
            
            txtTilaTieto.Text = "Sauna pois";
        }

        private void SanaON_Click(object sender, RoutedEventArgs e)
        {   
            Sauna1.SaunaPaalle();
            SaunaTemp.Start();
            txtTilaTieto.Text = "Sauna päällä";
        }
        public void Load_Settings()
        {
            string fileName = @"D:\Archives\Coder\c#\Proj\WPF_SmartHome_V3.23.10\SMSettings.txt";
            string[] arrLine = File.ReadAllLines(fileName);
            //Ladataan viimeisimmät (Last-State) tilat oville.                                                                      
            Sauna1.SaunanLampo = int.Parse(arrLine[8]);
        }
    }
}
