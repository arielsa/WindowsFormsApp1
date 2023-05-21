using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Persona
    {
        List<Auto> la;
        public Persona(){ la=new List<Auto>(); }
        public Persona( string pNombre = "", string pDni = "", string pApellido = "") : this ( )
        {
            
            Nombre = pNombre;
            DNI = pDni;
            Apellido = pApellido;
        }

        public Persona (Persona pPersona) : this (pPersona.Nombre,pPersona.DNI,pPersona.Apellido) 
        {

        }
        public void AgregarAuto(Auto pAuto)
        {
            la.Add(new Auto(pAuto));
        }
        public List<Auto> RetornarListaAuto()
        {
            return (from a in la
                    select new Auto(a.Patente, a.Marca, a.Modelo, a.Año, a.Precio)).ToList();
        }
        public int RetornaCantidadAutos()
        {
            return la.Count();
        }

        public string Nombre { get; set; }
        public string DNI  { get; set; }
        public string Apellido { get; set; }    
    }
}
