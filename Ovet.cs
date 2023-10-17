using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SmartHome_V3._23._10
{
    public class Ovet
    {
        public bool Etuovi_lukittu { get; set; }
        public bool Takaovi_lukittu { get; set; }
        public bool Tallinovi_kiinni { get; set; }

        public void Lukitse_Etuovi()
        {
            Etuovi_lukittu = true;

        }
        public void Avaa_Etuovi()
        {
            Etuovi_lukittu = false;

        }
        public void Lukitse_Takaovi()
        {
            Takaovi_lukittu = true;
        }
        public void Avaa_Takaovi()
        {
            Takaovi_lukittu = false;
        }
        public void Sulje_Tallinovi()
        {
            Tallinovi_kiinni = true;
        }
        public void Avaa_Tallinovi()
        {
            Tallinovi_kiinni = false;
        }

    }
}