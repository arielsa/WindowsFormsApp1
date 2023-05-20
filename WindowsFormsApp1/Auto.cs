using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Auto
    {
        List<Auto> la;

        public Auto() { la = new List<Auto>(); }
        public Auto(string pPatente, string pMarca, string pModelo, string pAño, decimal pPrecio): this ()
        {
            Patente = pPatente;
            Marca = pMarca;
            Modelo = pModelo;
            Año = pAño;
            Precio = pPrecio;
        }
        public Auto (Auto pAuto): this(pAuto.Patente, pAuto.Marca, pAuto.Modelo, pAuto.Año, pAuto.Precio)
        {

        }
        public  string Patente { get; set; }
        public  string Marca { get; set; }
        public  string Modelo { get; set; }
        public  string Año { get; set; }
         public decimal Precio { get; set; }

    }
}
