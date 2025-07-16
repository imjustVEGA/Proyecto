using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MediVax.Sesion;

namespace MediVax
{
    public partial class InicioSesion : Form
    {
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Registro formreg = new Registro();
            formreg.Show();
        }

        private void label2_Click(object sender, EventArgs e) { }
        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e) { }


        private void btnIngresar_Click(object sender, EventArgs e)
        {
            {
                string correo = txtCorreo.Text.Trim();
                string contraseña = txtContrasena.Text.Trim();

                if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contraseña))
                {
                    MessageBox.Show("Por favor, ingresa tu correo y contraseña.");
                    return;
                }

                try
                {
                    string connStr = "server=localhost;database=medivx;Uid=root;pwd=root;";
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {
                        conn.Open();
                        string query = "SELECT PacienteID FROM pacientes WHERE Correo = @correo AND Contraseña = @contraseña";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@correo", correo);
                            cmd.Parameters.AddWithValue("@contraseña", contraseña);

                            object result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                Sesion.Sesion.UsuarioID = Convert.ToInt32(result);
                                this.Hide();
                                Menu menu = new Menu();
                                menu.Show();
                            }
                            else
                            {
                                MessageBox.Show("Correo o contraseña incorrectos.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar: " + ex.Message);
                }
            }
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Tutor tutorForm = new Tutor(); // Crea una instancia del formulario Tutor
            tutorForm.Show();              // Muestra el formulario Tutor
            this.Hide();                   // Opcional: oculta el formulario actual
        }

        private void btnRecuperarContrasena_Click(object sender, EventArgs e)
        {
            RecuperarContraseña recuperarForm = new RecuperarContraseña();
            recuperarForm.ShowDialog(); // Modal para que el usuario complete el proceso

        }
    }
}
