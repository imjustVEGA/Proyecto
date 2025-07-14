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
       
        
        private void btnIngresar_Click(object sender, EventArgs e) {
        {
            string nombre = txtNombre.Text.Trim();
            string curp = txtCURP.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(curp))
            {
                MessageBox.Show("Por favor, ingresa tu nombre y CURP.");
                return;
            }

            try
            {
                string connStr = "server=localhost;database=medivx;Uid=root;pwd=root;";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT PacienteID FROM pacientes WHERE Nombre = @nombre AND CURP = @curp";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@curp", curp);

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
                            MessageBox.Show("Nombre o CURP incorrectos.");
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


}
}
