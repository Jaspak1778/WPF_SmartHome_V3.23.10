using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
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

namespace WPF_SmartHome_V3._23._10
{
    /// <summary>
    /// Interaction logic for pgLukitus.xaml
    /// </summary>
    public partial class pgLukitus : Page
    {
        Ovet koti = new Ovet();

        public pgLukitus()
        {
            InitializeComponent();
            Load_Settings();
            CheckDoorStatus();
        }
        
        public void btnPaavalikko_Click(object sender, RoutedEventArgs e)   //Extra toiminnallisuus
        {
            Write_settings(koti.Etuovi_lukittu, 0);
            Write_settings(koti.Takaovi_lukittu, 1);
            Write_settings(koti.Tallinovi_kiinni, 2);
            this.NavigationService.GoBack();
        }
        #region Ovien status
        public void CheckDoorStatus()     //Ovien tilan tarkistus
        {   
            if (koti.Etuovi_lukittu == true)
            {
                tbEtuovi.Content = "Avaa lukitus";
                lblEtuovi.Content = "Etuovi Lukittu";
                

            }
            else if (koti.Etuovi_lukittu == false)
            {
                tbEtuovi.Content = "Lukitse";
                lblEtuovi.Content = "Etuovi lukitsematta";
                
            }
            if (koti.Takaovi_lukittu == true)
            {
                tbTakaovi.Content = "Avaa lukitus";
                lblTakaovi.Content = "Takaovi Lukittu";

            }
            else if (koti.Takaovi_lukittu == false)
            {
                tbTakaovi.Content = "Lukitse";
                lblTakaovi.Content = "Takaovi lukitsematta";

            }
            if (koti.Tallinovi_kiinni == true)
            {
                tbTallinOvi.Content = "Avaa tallinovi";
                lblTallinOvi.Content = "Tallinovi suljettu";

            }
            else if (koti.Tallinovi_kiinni == false)
            {
                tbTallinOvi.Content = "Sulje Tallinovi";
                lblTallinOvi.Content = "Tallinovi auki";

            }
        }
        #endregion

        private void Etuovi_toggle(object sender, RoutedEventArgs e)
        {
            if (koti.Etuovi_lukittu == false) // Ovi on lukitsematta
            {
                koti.Lukitse_Etuovi();
                CheckDoorStatus();
            }
            else if (koti.Etuovi_lukittu == true) // Ovi on lukittu
            {
                koti.Avaa_Etuovi();
                CheckDoorStatus();
            }
        }

        private void Takaovi_toggle(object sender, RoutedEventArgs e)
        {
            if (koti.Takaovi_lukittu == false) // Ovi on lukitsematta
            {
                koti.Lukitse_Takaovi();
                CheckDoorStatus();
            }
            else if (koti.Takaovi_lukittu == true) // Ovi on lukittu
            {
                koti.Avaa_Takaovi();
                CheckDoorStatus();
            }
        }

        private void Tallinovi_toggle(object sender, RoutedEventArgs e)
        {
            if (koti.Tallinovi_kiinni == false) // Ovi on lukitsematta
            {
                koti.Sulje_Tallinovi();
                CheckDoorStatus();
            }
            else if (koti.Tallinovi_kiinni == true) // Ovi on lukittu
            {
                koti.Avaa_Tallinovi();
                CheckDoorStatus();
            }
        }

        #region Asetusten hallinta
        //Viedään asetukset tekstitiedostoon
        //docPath = @"D:\Archives\Coder\c#\Proj\WPF_SmartHome_V3.23.10\SMSettings.txt"; (param 1,2,3)
        public void Write_settings(bool asetus, int line_to_edit)
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
            koti.Etuovi_lukittu = bool.Parse(arrLine[0]);
            koti.Takaovi_lukittu = bool.Parse(arrLine[1]);
            koti.Tallinovi_kiinni = bool.Parse(arrLine[2]);
            #endregion
        }
    }
}
