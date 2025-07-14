using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediVax.Consultas;

namespace MediVax
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            InicioSesion formini = new InicioSesion();
            formini.Show();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string tabla = "pacientes";
            string nombre = txtNombre.Text.Trim();
            string curp = txtCURP.Text.Trim();
            string edad = txtEdad.Text.Trim();
            string sexo = cmboxSexo.SelectedItem.ToString();
            string apellido = txtApellido.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(curp) || (string.IsNullOrEmpty(edad) || string.IsNullOrEmpty(sexo)|| string.IsNullOrEmpty(apellido)))
            {
                MessageBox.Show("Por favor, ingresa los datos faltantes");
                return;
            }
            
                string campos = "Nombre, Apellido, Edad, Sexo, CURP";
            string valores = $"'{nombre}', '{apellido}', '{edad}', '{sexo}','{curp}'";

            Consulta consulta = new Consulta();
            consulta.agregar(tabla, campos, valores);

            MessageBox.Show("Se ha registrado el paciente correctamente");
        }
        

        private void guna2PictureBox1_Click(object seqnder, EventArgs e)
        {

        }

        private void Registro_Load(object sender, EventArgs e)
        {
            cmboxSexo.DataSource = Enum.GetValues(typeof(Sexo));
        }

        public enum Sexo
        {
            Masculino,
            Femenino

        }


    }
}
