
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SmartHome_V3._23._10
{
    public class Sauna
    {
        public int SaunanLampo { get; set; }
        public bool Switched { get; set; }

        public void SaunaPaalle()
        {
            Switched = true;
        }
        public void SaunaPois()
        {
            Switched = false;
        }


    }
}

