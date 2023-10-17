using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.CompilerServices;
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
using WPF_SmartHome_V3._23._10.Properties;
using System.Text.RegularExpressions;

namespace WPF_SmartHome_V3._23._10
{
    /// <summary>
    /// Interaction logic for pgValaistus.xaml
    /// </summary>
    //int val = Eteinen.Dimmer;
    //val = Convert.ToInt32(e.NewValue);
    //string msg = String.Format("{0} % ", val);
    //this.txtValotET.Text = msg;

    public partial class pgValaistus : Page
    {
        Lights Eteinen = new Lights();
        Lights Olohuone = new Lights();
        Lights Keittio = new Lights();
        Lights Makuuhuone = new Lights();


        public pgValaistus()
        {
            InitializeComponent();
            Load_Settings();
            //if 
            //sldrET.Value = 
            //sldrOH.Value = 
            //sldrKE.Value = 
            //sldrMH.Value = 

        }
        public void btnPaavalikko_Click(object sender, RoutedEventArgs e)
        {
            Write_settings(Eteinen.Dimmer, 3);
            Write_settings(Olohuone.Dimmer, 4);
            Write_settings(Keittio.Dimmer, 5);
            Write_settings(Makuuhuone.Dimmer, 6);
            this.NavigationService.GoBack();
        }
        private void ETSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {   
            
            int dimm = Convert.ToInt32(e.NewValue);
            Eteinen.Dimmer = String.Format("{0} %", dimm);
            this.txtValotET.Text = Eteinen.Dimmer;
            if (dimm < 1)
            {
                Eteinen.Switched = false;
                ETtilatie.Content = Eteinen.Pois;
            }
            else if (dimm > 0)
            { 
                Eteinen.Switched = true;
                ETtilatie.Content = Eteinen.Paalla;
            }

        }
        private void OHSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int dimm = Convert.ToInt32(e.NewValue);
            Olohuone.Dimmer = String.Format("{0} %", dimm);
            this.txtValotOH.Text = Olohuone.Dimmer;
            if (dimm < 1)
            {
                Olohuone.Switched = false;
                OHtilatie.Content = Olohuone.Pois;
            }
            else if (dimm > 0)
            {
                Olohuone.Switched = true;
                OHtilatie.Content = Olohuone.Paalla;
            }

        }
        private void KESlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int dimm = Convert.ToInt32(e.NewValue);
            Keittio.Dimmer = String.Format("{0} %", dimm);
            this.txtValotKE.Text = Keittio.Dimmer;
            if (dimm < 1)
            {
               Keittio.Switched = false;
               KEtilatie.Content = Keittio.Pois;
            }
            else if (dimm > 0)
            {
                Keittio.Switched = true;
                KEtilatie.Content = Keittio.Paalla;
            }
        }
        private void MHSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int dimm = Convert.ToInt32(e.NewValue);
            Makuuhuone.Dimmer = String.Format("{0} %", dimm);
            this.txtValotMH.Text = Makuuhuone.Dimmer;
            if (dimm < 1)
            {
                Makuuhuone.Switched = false;
                MHtilatie.Content = Makuuhuone.Pois;
            }
            else if (dimm > 0)
            {
                Makuuhuone.Switched = true;
                MHtilatie.Content = Makuuhuone.Paalla;

            }
        }
        #region Asetusten hallinta
        //Viedään asetukset tekstitiedostoon
        //docPath = @"D:\Archives\Coder\c#\Proj\WPF_SmartHome_V3.23.10\SMSettings.txt"; (param 3,4,5,6)
        public void Write_settings(string asetus, int line_to_edit)
        {
            string strasetus = "0 %";
            string fileName = @"D:\Archives\Coder\c#\Proj\WPF_SmartHome_V3.23.10\SMSettings.txt";
            string[] arrLine = File.ReadAllLines(fileName);
            if (asetus == null)
            {
                arrLine[line_to_edit] = strasetus;
                File.WriteAllLines(fileName, arrLine);
            }
            else 
            {
                strasetus = asetus.ToString();
                arrLine[line_to_edit] = strasetus;
                File.WriteAllLines(fileName, arrLine);
            }
        }
        //Ulkoinen lähde asetuksille
        public void Load_Settings()
        {
            string fileName = @"D:\Archives\Coder\c#\Proj\WPF_SmartHome_V3.23.10\SMSettings.txt";
            string[] arrLine = File.ReadAllLines(fileName);
            sldrET.Value = double.Parse(Regex.Match(arrLine[3], @"\d+").Value);
            sldrOH.Value = double.Parse(Regex.Match(arrLine[4], @"\d+").Value);
            sldrKE.Value = double.Parse(Regex.Match(arrLine[5], @"\d+").Value);
            sldrMH.Value = double.Parse(Regex.Match(arrLine[6], @"\d+").Value);
           #endregion
        }
    }   
}