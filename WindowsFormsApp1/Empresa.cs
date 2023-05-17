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
<<<<<<< HEAD
            var query = (from p in lp
                        select new
                        {
                            DNI = p.DNI,
                            apellido_y_nombre = $"{p.Apellido},{p.Nombre}"
                        }).ToArray();

            return query;
=======
            
>>>>>>> 49a42d0069ec55951cecf023fd8ae29c3c6804b8
        }
    }
}
