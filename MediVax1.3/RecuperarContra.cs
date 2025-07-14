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
    public partial class RecuperarContra : Form
    {
        public RecuperarContra()
        {
            InitializeComponent();
        }

        private void btnRestablecerContrasena_Click(object sender, EventArgs e)
        {
            string correoBuscado = txtCorreoRecuperacion.Text.Trim();
            string nuevaContrasena = txtNuevaContrasena.Text.Trim();
            string ruta = "tutores.txt";

            if (string.IsNullOrWhiteSpace(correoBuscado) || string.IsNullOrWhiteSpace(nuevaContrasena))
            {
                MessageBox.Show("⚠️ Ingresa el correo y la nueva contraseña.", "Campos obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(ruta))
            {
                MessageBox.Show("❌ No se encontró el archivo de tutores.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] lineas = File.ReadAllLines(ruta);
            bool actualizado = false;

            for (int i = 0; i < lineas.Length; i++)
            {
                if (lineas[i].Contains($"Correo:{correoBuscado}"))
                {
                    string[] partes = lineas[i].Split('|');
                    for (int j = 0; j < partes.Length; j++)
                    {
                        if (partes[j].Trim().StartsWith("Contraseña:"))
                        {
                            partes[j] = $" Contraseña:{nuevaContrasena}";
                            break;
                        }
                    }

                    lineas[i] = string.Join("|", partes);
                    actualizado = true;
                    break;
                }
            }

            if (actualizado)
            {
                File.WriteAllLines(ruta, lineas);
                MessageBox.Show("✅ Contraseña actualizada correctamente.", "Recuperación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Volver al login
                iniciar_sesion loginVentana = new iniciar_sesion(); // Usa el nombre real de tu formulario
                loginVentana.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("❌ No se encontró un tutor con ese correo.", "Correo no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
