using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediVax1._3
{
    public partial class iniciar_sesion : Form
    {
        public iniciar_sesion()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void iniciar_seción_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string correoIngresado = txtCorreoIngreso.Text.Trim();
            string contrasenaIngresada = txtContrasenaIngreso.Text.Trim();
            string ruta = "tutores.txt";
            bool accesoPermitido = false;

            if (!File.Exists(ruta))
            {
                MessageBox.Show("⚠️ No hay registros de tutores.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] lineas = File.ReadAllLines(ruta);

            foreach (string linea in lineas)
            {
                if (linea.Contains($"Correo:{correoIngresado}") && linea.Contains($"Contraseña:{contrasenaIngresada}"))
                {
                    accesoPermitido = true;
                    break;
                }
            }

            if (accesoPermitido)
            {
                MessageBox.Show("✅ Bienvenido al sistema.", "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Abres ventana principal aquí:
                paciente ventanaPaciente = new paciente();
                ventanaPaciente.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("❌ Correo o contraseña incorrectos.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void botton1_Click(object sender, EventArgs e)
        {

        }

        private void iniciar_sesion_Click(object sender, EventArgs e)
        {

        }

        private void btnVolverLogin_Click(object sender, EventArgs e)
        {
            login loginVentana = new login(); // Asegúrate que tu formulario de login se llame "Login"
            loginVentana.Show();
            this.Close(); // Cierra la ventana actual para evitar duplicados

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnOlvidecontrasena_Click(object sender, EventArgs e)
        {
            RecuperarContra ventanaRecuperar = new RecuperarContra();
            ventanaRecuperar.Show();
            this.Hide(); // Oculta el login mientras se recupera

        }
    }
}
