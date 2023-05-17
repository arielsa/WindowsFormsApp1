using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Empresa
    {
        List<Auto> la;
        List<Persona> lp;
        public Empresa()
        {
            la = new List<Auto> () ; lp = new List<Persona>();
        }
        public void AgregarPersona (Persona pPersona)
        {
            lp.Add( new Persona (pPersona) );
        }

        public object RetornaListaPersona()
        {
            return lp;
        }
    }
}
