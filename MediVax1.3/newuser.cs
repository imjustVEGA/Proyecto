using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediVax1._3
{
    public partial class newuser : Form
    {
        // Bandera para controlar si el tutor ya ha sido registrado
        private bool tutorRegistrado = false;

        // Variable para modo edición: almacena el ID original si se edita
        private int idEditando = -1;

        public newuser()
        {
            InitializeComponent();

            // Navegación con tecla Enter en campos de texto
            txtNombres.KeyDown += Textbox_KeyDown;
            txtApellidos.KeyDown += Textbox_KeyDown;
            txtTelefono.KeyDown += Textbox_KeyDown;
            txtCrup.KeyDown += Textbox_KeyDown;
            txtCorreo.KeyDown += Textbox_KeyDown;
            txtContrasena.KeyDown += Textbox_KeyDown;
        }

        // 🔁 Navegación con Enter
        private void Textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        // 📝 Guardar o actualizar información del tutor
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombres.Text) ||
                string.IsNullOrWhiteSpace(txtApellidos.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtCrup.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show(
                    "⚠️ Por favor completa todos los campos antes de guardar.",
                    "Campos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Determinar si es edición o nuevo registro
            int idTutor = (idEditando != -1) ? idEditando : ObtenerSiguienteID();
            string fechaRegistro = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            string ruta = "tutores.txt";

            // Preparar datos para guardar
            string datos = $"ID:{idTutor} | Fecha:{fechaRegistro} | Nombre:{txtNombres.Text} {txtApellidos.Text} | Tel:{txtTelefono.Text} | CURP:{txtCrup.Text} | Correo:{txtCorreo.Text} | Contraseña:{txtContrasena.Text}";

            if (idEditando != -1)
            {
                // Modo edición: reemplazar línea existente
                string[] lineas = File.ReadAllLines(ruta);
                for (int i = 0; i < lineas.Length; i++)
                {
                    if (lineas[i].Contains($"ID:{idTutor}"))
                    {
                        lineas[i] = datos;
                        break;
                    }
                }
                File.WriteAllLines(ruta, lineas);
                idEditando = -1; // Salimos del modo edición
            }
            else
            {
                // Nuevo registro
                File.AppendAllText(ruta, datos + Environment.NewLine);
            }

            // Confirmación
            MessageBox.Show(
                $"✅ Registro exitoso\nTu número de tutor es: {idTutor}\nFecha de registro: {fechaRegistro}",
                "Confirmación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            tutorRegistrado = true;

            // Limpiar campos
            txtNombres.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtCrup.Clear();
            txtCorreo.Clear();
            txtContrasena.Clear();
        }

        // 🔐 Botón para ir a registrar paciente
        private void btnregistropaciente_Click(object sender, EventArgs e)
        {
            if (!tutorRegistrado)
            {
                MessageBox.Show(
                    "❌ No puedes pasar a registrar paciente sin guardar primero los datos del tutor.",
                    "Acceso denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            paciente ventanaPaciente = new paciente();
            ventanaPaciente.Show();
            this.Hide();
        }

        // ⚙️ Generador de ID autoincremental
        private int ObtenerSiguienteID()
        {
            string ruta = "tutores.txt";
            if (!File.Exists(ruta)) return 1;

            string[] lineas = File.ReadAllLines(ruta);
            foreach (string linea in lineas.Reverse())
            {
                if (linea.Contains("ID:"))
                {
                    string[] partes = linea.Split('|');
                    foreach (string parte in partes)
                    {
                        if (parte.Trim().StartsWith("ID:"))
                        {
                            string idTexto = parte.Replace("ID:", "").Trim();
                            if (int.TryParse(idTexto, out int id)) return id + 1;
                        }
                    }
                }
            }
            return 1;
        }

        // 🛠️ Botón "Editar información"
        private void btnEditar_Click(object sender, EventArgs e)
        {
            string curpBuscado = txtCrup.Text;
            string ruta = "tutores.txt";
            string[] lineas = File.ReadAllLines(ruta);

            foreach (string linea in lineas)
            {
                if (linea.Contains($"CURP:{curpBuscado}"))
                {
                    string[] partes = linea.Split('|');
                    foreach (string parte in partes)
                    {
                        if (parte.Trim().StartsWith("ID:"))
                        {
                            string idTexto = parte.Replace("ID:", "").Trim();
                            if (int.TryParse(idTexto, out int id)) idEditando = id;
                        }
                        if (parte.Trim().StartsWith("Nombre:"))
                        {
                            string[] nombreSplit = parte.Replace("Nombre:", "").Trim().Split(' ');
                            txtNombres.Text = nombreSplit[0];
                            txtApellidos.Text = string.Join(" ", nombreSplit.Skip(1));
                        }
                        if (parte.Trim().StartsWith("Tel:")) txtTelefono.Text = parte.Replace("Tel:", "").Trim();
                        if (parte.Trim().StartsWith("Correo:")) txtCorreo.Text = parte.Replace("Correo:", "").Trim();
                        if (parte.Trim().StartsWith("Contraseña:")) txtContrasena.Text = parte.Replace("Contraseña:", "").Trim();
                    }

                    MessageBox.Show("✅ Datos cargados. Puedes editarlos ahora.", "Edición habilitada");
                    return;
                }
            }

            MessageBox.Show("❌ CURP no encontrado en el registro.", "Sin coincidencias");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
