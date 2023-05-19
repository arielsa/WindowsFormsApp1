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
                Persona p = new Persona(dni,"","");
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
                Persona p = new Persona(f.Cells[0].Value.ToString(),"","");
                empresa.BorrarPersona(p);
            }
            catch (Exception ex){ MessageBox.Show(ex.Message); }
        }
    }
}
