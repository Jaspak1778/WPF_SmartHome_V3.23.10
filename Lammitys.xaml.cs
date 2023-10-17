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
using System.Windows.Threading;
using System.Windows.Shapes;
using System.IO;

namespace WPF_SmartHome_V3._23._10
{
    /// <summary>
    /// Interaction logic for Lammitys.xaml
    /// </summary>
    public partial class Lammitys : Page
    {
        public DispatcherTimer Temp = new DispatcherTimer();
        Thermostat Asuintilat = new Thermostat();
        Thermostat Makuuhuone = new Thermostat();
        Thermostat Kylpyhuone = new Thermostat();

        public Lammitys()
        {
            InitializeComponent();
            Load_Settings();
            ReceiveValues();
            TempDisplay();

            Temp.Tick += TempSimulation;
            Temp.Interval = new TimeSpan(0,0,5);
            Temp.Start();
            Thermostat.Huoneistolämpö = Kylpyhuone.HuoneOloarvo;

        }
        private void TempSimulation(object sender, EventArgs e)
        {   
            //Ajastin on päällä kun sivu on ajossa.
            //Asuintilat
            if (Asuintilat.HuoneOloarvo < Asuintilat.HaluttuLampotila)
                Asuintilat.NostaLampoa();
                TempDisplay();
            if (Asuintilat.HuoneOloarvo > Asuintilat.HaluttuLampotila)
                Asuintilat.LaskeLampoa();
                TempDisplay();
            if (Asuintilat.HuoneOloarvo == Asuintilat.HaluttuLampotila)
                TempDisplay();
            //Makuuhuone
            if(Makuuhuone.HuoneOloarvo < Makuuhuone.HaluttuLampotila)
                Makuuhuone.NostaLampoa();
            TempDisplay();
            if (Makuuhuone.HuoneOloarvo > Makuuhuone.HaluttuLampotila)
                Makuuhuone.LaskeLampoa();
            TempDisplay();
            if (Makuuhuone.HuoneOloarvo == Makuuhuone.HaluttuLampotila)
                TempDisplay();
            //Kylpyhuone
            if (Kylpyhuone.HuoneOloarvo < Kylpyhuone.HaluttuLampotila)
                Kylpyhuone.NostaLampoa();
            TempDisplay();
            if (Kylpyhuone.HuoneOloarvo > Kylpyhuone.HaluttuLampotila)
                Kylpyhuone.LaskeLampoa();
            TempDisplay();
            if (Kylpyhuone.HuoneOloarvo == Kylpyhuone.HaluttuLampotila)
                TempDisplay();

        }
        public void TempDisplay()
        { 
            txtASLAsetus.Text = Asuintilat.HaluttuLampotila.ToString();
            txtMHLAsetus.Text = Makuuhuone.HaluttuLampotila.ToString();
            txtKHLAsetus.Text = Kylpyhuone.HaluttuLampotila.ToString();

            txtASLNykyinen.Text = Asuintilat.HuoneOloarvo.ToString();
            txtMHLNykyinen.Text = Makuuhuone.HuoneOloarvo.ToString();
            txtKHNykyinen.Text = Kylpyhuone.HuoneOloarvo.ToString();
        }

        private void btnPaavalikko_Click(object sender, RoutedEventArgs e)
        {
            
            Write_settings(Asuintilat.HaluttuLampotila, 7);
            Write_settings(Kylpyhuone.HaluttuLampotila, 8);
            Write_settings(Makuuhuone.HaluttuLampotila, 9);
            Thermostat.Huoneistolämpö = Kylpyhuone.HuoneOloarvo;
            Temp.Stop();
            this.NavigationService.GoBack();
        }
        private void btnASLisaa_Click(object sender, RoutedEventArgs e)
        {
            if (Asuintilat.HaluttuLampotila < 25)
            {
                Asuintilat.HaluttuLampotila++;
                txtASLAsetus.Text = Asuintilat.HaluttuLampotila.ToString();
            }
            else 
            {
                Asuintilat.HaluttuLampotila = 25;
            }
        }
        private void btnASVahenna_Click(object sender, RoutedEventArgs e)
        {
            if (Asuintilat.HaluttuLampotila > 17)
            {
                Asuintilat.HaluttuLampotila--;
                txtASLAsetus.Text = Asuintilat.HaluttuLampotila.ToString();
            }
            else 
            {
                Asuintilat.HaluttuLampotila = 17;
            }
        }
        private void btnMHLisaa_Click(object sender, RoutedEventArgs e)
        {
            Makuuhuone.HaluttuLampotila++;
            if (Makuuhuone.HaluttuLampotila <= 25)
            {
                txtMHLAsetus.Text = Makuuhuone.HaluttuLampotila.ToString();
            }
            else
            {
                Makuuhuone.HaluttuLampotila = 25;
            }
        }

        private void btnMHVahenna_Click(object sender, RoutedEventArgs e)
        {
            Makuuhuone.HaluttuLampotila--;
            if (Makuuhuone.HaluttuLampotila >= 17)
            {
                txtMHLAsetus.Text = Makuuhuone.HaluttuLampotila.ToString();
            }
            else
            {
                Makuuhuone.HaluttuLampotila = 17;
            }
        }

        private void btnKHLisaa_Click(object sender, RoutedEventArgs e)
        {
            Kylpyhuone.HaluttuLampotila++;
            if (Kylpyhuone.HaluttuLampotila <= 25)
            {
                txtKHLAsetus.Text = Kylpyhuone.HaluttuLampotila.ToString();
            }
            else
            {
                Kylpyhuone.HaluttuLampotila = 25;
            }
        }
        private void btnKHVahenna_Click(object sender, RoutedEventArgs e)
        {
            Kylpyhuone.HaluttuLampotila--;
            if (Kylpyhuone.HaluttuLampotila >= 17)
            {
                txtKHLAsetus.Text = Kylpyhuone.HaluttuLampotila.ToString();
            }
            else
            {
                Kylpyhuone.HaluttuLampotila = 17;
            }
        }
        public void ReceiveValues()                                     //ToDo: Haetaan LastStates tekstitiedostosta.
        {
            Asuintilat.HaluttuLampotila = Asuintilat.HuoneOloarvo;
            Makuuhuone.HaluttuLampotila = Makuuhuone.HuoneOloarvo;
            Kylpyhuone.HaluttuLampotila = Kylpyhuone.HuoneOloarvo;
        }
        #region Asetusten hallinta
        //Viedään asetukset tekstitiedostoon
        //docPath = @"D:\Archives\Coder\c#\Proj\WPF_SmartHome_V3.23.10\SMSettings.txt"; (param 7,8,9)
        public void Write_settings(int asetus, int line_to_edit)
        {
            string fileName = @"D:\Archives\Coder\c#\Proj\WPF_SmartHome_V3.23.10\SMSettings.txt";
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit] = asetus.ToString();
            File.WriteAllLines(fileName, arrLine);
        }

        //Ulkoinen lähde asetuksille
        public void Load_Settings()
        {
            string fileName = @"D:\Archives\Coder\c#\Proj\WPF_SmartHome_V3.23.10\SMSettings.txt";
            string[] arrLine = File.ReadAllLines(fileName);
            //Ladataan viimeisimmät (Last-State) tilat oville.                                                                      
            Asuintilat.HuoneOloarvo = int.Parse(arrLine[7]);
            Kylpyhuone.HuoneOloarvo = int.Parse(arrLine[8]);
            Makuuhuone.HuoneOloarvo = int.Parse(arrLine[9]);
            
            #endregion
        }

    }
}
    

