using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            empresa = new Empresa(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView2.MultiSelect = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            empresa.AgregarAuto(new Auto ("asd111","audi","fiorino","1324",1111));
            empresa.AgregarAuto(new Auto("asd222", "audi", "fiorino","1324", 2222));
            empresa.AgregarAuto(new Auto("asd333", "audi", "fiorino","1324", 3333));

            empresa.AgregarPersona(new Persona("juan","11.111.111","calvo"));
            empresa.AgregarPersona(new Persona("miguel", "22.222.222", "cebolla"));
            empresa.AgregarPersona(new Persona("ramira", "33.333.333", "verde"));
            empresa.AgregarPersona(new Persona("juliana", "44.444.444", "lopez"));

            Mostrar(dataGridView1,empresa.RetornaListaPersona());
            Mostrar(dataGridView2, empresa.RetornarListaAuto());

        }
        Regex re;
        Empresa empresa;
        private void Mostrar(DataGridView pDGV, object pO)
        {
            pDGV.DataSource = null;
            pDGV.DataSource=pO;
        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            try
            {
                re = new Regex(@"\d\d.\d{3}.\d{3}");
                string dni = Interaction.InputBox("dni: ");
                if (!(re.IsMatch(dni) && dni.Length == 10)) throw new Exception("error de formato");
                Persona p = new Persona("",dni,"");
                if (empresa.ValidaDNIPersona(p)) throw new Exception("dni existente");
                p.Nombre = Interaction.InputBox("nombre: ");
                p.Apellido = Interaction.InputBox("apellido: ");
                empresa.AgregarPersona(p);
                Mostrar(dataGridView1, empresa.RetornaListaPersona());
            }
            catch (Exception ex)
            {                MessageBox.Show(ex.Message);            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0) throw new Exception("no hay nada para borrar");
                DataGridViewRow f = dataGridView1.SelectedRows[0];
                Persona p = new Persona( "",f.Cells[0].Value.ToString(),"");
                empresa.BorrarPersona(p);
                Mostrar(dataGridView1,empresa.RetornaListaPersona());
            }
            catch (Exception ex){ MessageBox.Show(ex.Message); }
        }

        private void btnAgregarAuto_Click(object sender, EventArgs e)
        {
            try
            {
                re = new Regex(@"[a-z,A-Z]{3}\d{3}");
                string patente = Interaction.InputBox("patente: ");
                if (!(re.IsMatch(patente) && patente.Length == 6)) throw new Exception("patente erronea");
                Auto a = new Auto(patente,"","","",0);
                if ((empresa.ValidarPatente(a))) throw new Exception("patente invalida");
                a.Marca = Interaction.InputBox("marca: ");
                a.Modelo = Interaction.InputBox("modelo: ");
                a.Año = Interaction.InputBox("año: ");
                re = new Regex(@"\d{4}");
                string precio = Interaction.InputBox("precio: ");
                if (!(re.IsMatch(precio))) throw new Exception("valor invalido ");
                a.Precio = decimal.Parse(precio);
                empresa.AgregarAuto(a);
                Mostrar(dataGridView2, empresa.RetornarListaAuto());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message);           }
        }

        private void button1_Click(object sender, EventArgs e)//MODIFICAR PERSONA
        {
            try
            {
                MessageBox.Show("entro");
                if (dataGridView1.Rows.Count == 0) throw new Exception("grilla vacia");
                DataGridViewRow f = dataGridView1.SelectedRows[0];
                Persona p = new Persona ( "",f.Cells[0].Value.ToString(),"");
                

                var x = f.Cells[1].Value.ToString().Split(new string[] { ", " } , StringSplitOptions.None);

                p.Nombre = Interaction.InputBox("Nombre", "modificar nombre", x[1]);
                p.Apellido = Interaction.InputBox("apellido: ", "modificar apellido", x[0]);

                empresa.ModificarPersona(p);
                Mostrar(dataGridView1,empresa.RetornaListaPersona());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnModificarAuto_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count == 0) throw new Exception("grilla vacia");
                DataGridViewRow f = dataGridView2.SelectedRows[0];MessageBox.Show("entro");
                Auto a = new Auto(f.Cells[0].Value.ToString(),"","", f.Cells[2].Value.ToString(), decimal.Parse(f.Cells[3].Value.ToString()) );


                var x = f.Cells[1].Value.ToString().Split(new string[] { ", " }, StringSplitOptions.None);

                a.Marca = Interaction.InputBox("Marca: ", "modificar Marca", x[1]);
                a.Modelo = Interaction.InputBox("modelo: ", "modificar Modelo", x[0]);

                empresa.ModificarAuto(a);
                Mostrar(dataGridView2, empresa.RetornarListaAuto());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void btnBorrarAuto_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count == 0) throw new Exception("no hay nada para borrar");
                DataGridViewRow f = dataGridView2.SelectedRows[0];
                Auto a = new Auto( f.Cells[0].Value.ToString(),"","","",0000);
                empresa.BorrarAuto(a);
                Mostrar(dataGridView2, empresa.RetornarListaAuto());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
