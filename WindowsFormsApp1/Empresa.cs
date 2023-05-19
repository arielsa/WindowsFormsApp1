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
        public void BorrarPersona (Persona pPersona)
        {
            try
            {
                Persona p = lp.Find(x => x.DNI == pPersona.DNI);
                if (p == null) throw new Exception("la persona no existe");
                lp.Remove(p);
            }
            catch (Exception ex){ throw ex; }
        }

        public object RetornaListaPersona()
        {

            var query = (from p in lp
                        select new
                        {
                            DNI = p.DNI,
                            apellido_y_nombre = $"{p.Apellido},{p.Nombre}"
                        }).ToArray();

            return query;
        }
        public bool ValidaDNIPersona(Persona pPersona)
        {
            return lp.Exists(x => x.DNI == pPersona.DNI);
        }
    }
}
