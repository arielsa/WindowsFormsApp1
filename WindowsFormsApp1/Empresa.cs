using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            try
            {
                if (ValidaDNIPersona(pPersona)) { throw new Exception("dni xistente"); } else { lp.Add(new Persona(pPersona)); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        }
        public void AgregarAuto (Auto pAuto)
        {
            la.Add( new Auto (pAuto) );
        }
        public void BorrarPersona (Persona pPersona)
        {
            try
            {
                Persona p = lp.Find(x => x.DNI == pPersona.DNI);
                if (p == null) throw new Exception("la persona no existe");
                foreach (Auto a in p.RetornarListaAuto())
                {
                    la.Find(x => x.Patente == a.Patente).AgregarDueño(null);
                }
                lp.Remove(p);
            }
            catch (Exception ex){ throw ex; }
        }
        public void BorrarAuto(Auto pAuto)
        {
            try
            {
                Auto a = la.Find(x => x.Patente == pAuto.Patente);
                if (a == null) throw new Exception("patente inexistente");
                la.Remove(a);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void ModificarPersona(Persona pPersona)
        {
            try
            {
                Persona p = lp.Find(x => x.DNI == pPersona.DNI);
                if (p == null) throw new Exception("no se encontro el dni");
                p.Nombre=pPersona.Nombre;
                p.Apellido=pPersona.Apellido;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message);  }
        }
        public void ModificarAuto(Auto pAuto)
        {
            try
            {
                Auto a = la.Find(x => x.Patente == pAuto.Patente);
                if (a == null) throw new Exception("no se encontro el patente");
                a.Modelo = pAuto.Modelo;
                a.Marca = pAuto.Marca;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public object RetornaListaPersona()
        {
            var query = (from p in lp
                        select new
                        {
                            DNI = p.DNI,
                            apellido_y_nombre = $"{p.Apellido}, {p.Nombre}"
                        }).ToArray();
            return query;
        }
        public object RetornarListaAuto()
        {
            return (from a in la select new {
                                                Patente = a.Patente,
                                                Marca_y_Modelo = $"{a.Marca}, {a.Modelo}",
                                                Año = a.Año,
                                                Precio = a.Precio,
                                                }).ToArray();            
        }
        public bool ValidaDNIPersona(Persona pPersona)
        {
            return lp.Exists(x => x.DNI == pPersona.DNI);
        }
        public bool ValidarPatente (Auto pAuto)
        {
            return la.Exists(x => x.Patente == pAuto.Patente );
        }
        public void AsignaAutoAPersona(Persona pPersona, Auto pAuto)
        {

            try
            {
                Persona p = lp.Find(x => x.DNI == pPersona.DNI);
                Auto a = la.Find(x => x.Patente == pAuto.Patente);
                if (a == null || p == null) throw new Exception("auto o persona nula");
                if (a.RetornaDueño() != null) throw new Exception(" el auto ya tiene dueño ");
                a.AgregarDueño(new Persona(p));
                p.AgregarAuto(new Auto (a));

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
            

        }

        public object RetornarListaAutoDePersona(Persona pPersona)
        {
            Persona p = lp.Find(x => x.DNI == pPersona.DNI);

            return (from a in p.RetornarListaAuto()
                    select new
                    {
                        Patente = a.Patente,
                        Marca_y_Modelo = $"{a.Marca}, {a.Modelo}",
                        Año = a.Año,
                        Precio = a.Precio,
                    }).ToArray();
        }

    }
}
