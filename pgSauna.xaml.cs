using System;
using System.Windows;
using System.Windows.Controls;
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
        int muisti;
        
        public pgSauna()
        {
            InitializeComponent();
            if (MainWindow.FirstRun == true)
            {
                Load_Settings();
            }
            else 
            {
                Sauna1.SaunanLampo = Thermostat.Huoneistolämpö;
            }
            txtLampotila.Content = Sauna1.SaunanLampo.ToString();

            SaunaTemp.Tick += TmpSimulation;
            SaunaTemp.Interval = TimeSpan.FromMilliseconds(500);
            
        }
        private void btnPaavalikko_Click(object sender, RoutedEventArgs e)      //Takaisin päävalikkoon
        {
            //Write_settings(Sauna1.SaunanLampo, 10);
            
            this.NavigationService.GoBack();
        }
        private void TmpSimulation(object sender, EventArgs e)          //Lämpö simulaatio
        {
            if (Sauna1.Switched == true)
            {
                
                txtLampotila.Content = Sauna1.SaunanLampo.ToString();
                if (Sauna1.SaunanLampo < 86) 
                {
                    Sauna1.SaunanLampo++;
                    txtLampotila.Content = Sauna1.SaunanLampo.ToString();
                }
            }
            else if (Sauna1.Switched == false) 
            {
                Sauna1.SaunanLampo--;
                txtLampotila.Content = Sauna1.SaunanLampo.ToString();

                if (Sauna1.SaunanLampo == muisti /*Thermostat.Huoneistolämpö*/)
                {
                    txtLampotila.Content = Sauna1.SaunanLampo.ToString();
                    SaunaTemp.Stop();
                }
            }
        }
        
        private void SaunaOFF_Click(object sender, RoutedEventArgs e)
        {
            Sauna1.SaunaPois();
            
            txtTilaTieto.Text = "Sauna pois";
        }

        private void SanaON_Click(object sender, RoutedEventArgs e)
        {
            muisti = Sauna1.SaunanLampo;
            Sauna1.SaunaPaalle();
            SaunaTemp.Start();
            txtTilaTieto.Text = "Sauna päällä";
        }

        //Testauksia varten

        //public void Write_settings(int asetus, int line_to_edit)
        //{
        //    string fileName = @"D:\Archives\Coder\c#\Proj\WPF_SmartHome_V3.23.10\SMSettings.txt";
        //    string[] arrLine = File.ReadAllLines(fileName);
        //    arrLine[line_to_edit] = asetus.ToString();
        //    File.WriteAllLines(fileName, arrLine);
        //}
        public void Load_Settings()
        {
            string fileName = @"D:\Archives\Coder\c#\Proj\WPF_SmartHome_V3.23.10\SMSettings.txt";
            string[] arrLine = File.ReadAllLines(fileName);
            Sauna1.SaunanLampo = int.Parse(arrLine[8]);
        }
               
    }
}
