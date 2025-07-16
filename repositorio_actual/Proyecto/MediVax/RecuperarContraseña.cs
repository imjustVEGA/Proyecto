using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediVax
{
    public partial class RecuperarContraseña : Form
    {
        public RecuperarContraseña()
        {
            InitializeComponent();
        }

        private void RecuperarContraseña_Load(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            string nuevaContrasena = txtNuevaContrasena.Text.Trim();
            string confirmarContrasena = txtConfirmarContrasena.Text.Trim();

            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(nuevaContrasena) || string.IsNullOrEmpty(confirmarContrasena))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            if (nuevaContrasena != confirmarContrasena)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            try
            {
                string connStr = "server=localhost;database=medivx;Uid=root;pwd=root;";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // Verificar si el correo existe
                    string verificarQuery = "SELECT COUNT(*) FROM pacientes WHERE Correo = @correo";
                    using (MySqlCommand verificarCmd = new MySqlCommand(verificarQuery, conn))
                    {
                        verificarCmd.Parameters.AddWithValue("@correo", correo);
                        int existe = Convert.ToInt32(verificarCmd.ExecuteScalar());

                        if (existe == 0)
                        {
                            MessageBox.Show("❌ El correo no está registrado.");
                            return;
                        }
                    }

                    // Actualizar contraseña
                    string actualizarQuery = "UPDATE pacientes SET Contraseña = @nueva WHERE Correo = @correo";
                    using (MySqlCommand actualizarCmd = new MySqlCommand(actualizarQuery, conn))
                    {
                        actualizarCmd.Parameters.AddWithValue("@correo", correo);
                        actualizarCmd.Parameters.AddWithValue("@nueva", nuevaContrasena);

                        int filas = actualizarCmd.ExecuteNonQuery();
                        if (filas > 0)
                        {
                            MessageBox.Show("✅ Contraseña actualizada correctamente.");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("❌ No se pudo actualizar la contraseña.");
                        }
                    }
                }
            } // ← Este corchete faltaba
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar: " + ex.Message);
            }
        }
    }
}
