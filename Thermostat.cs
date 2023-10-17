using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Threading;

namespace WPF_SmartHome_V3._23._10
{
    public class Thermostat
    {
        
        public int HaluttuLampotila { get; set; }
        public int HuoneOloarvo { get; set; }
        public static int Huoneistolämpö { get; set; }

        public void NostaLampoa() 
        {
            HuoneOloarvo +=1;
        }
        public void LaskeLampoa() 
        {
            HuoneOloarvo -= 1;
        }

    }
}
