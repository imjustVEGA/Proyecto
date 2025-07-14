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
    public partial class paciente : Form
    {
        private string curpEditando = "";
        private int idPacienteEditando = -1;
        private int pacientesRegistrados = 0;


        public paciente()
        {
            InitializeComponent();

            txtNombresPaciente.KeyDown += TextboxPaciente_KeyDown;
            txtApellidosPaciente.KeyDown += TextboxPaciente_KeyDown;
            txtCurpPaciente.KeyDown += TextboxPaciente_KeyDown;
            cmbSexo.KeyDown += TextboxPaciente_KeyDown;
            dtpFechaNacimiento.KeyDown += TextboxPaciente_KeyDown;
        }

        private bool GuardarPaciente()
        {
            // Lógica para guardar los datos del paciente
            if (string.IsNullOrWhiteSpace(txtNombresPaciente.Text) ||
        string.IsNullOrWhiteSpace(txtApellidosPaciente.Text) ||
        string.IsNullOrWhiteSpace(txtCurpPaciente.Text) ||
        cmbSexo.SelectedItem == null)
            {
                MessageBox.Show("⚠️ Por favor completa todos los campos.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string nombres = txtNombresPaciente.Text;
            string apellidos = txtApellidosPaciente.Text;
            string sexo = cmbSexo.SelectedItem.ToString();
            string curp = txtCurpPaciente.Text;
            string nacimiento = dtpFechaNacimiento.Value.ToString("dd/MM/yyyy");
            string fechaRegistro = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            int idPaciente = (idPacienteEditando != -1) ? idPacienteEditando : ObtenerSiguienteIDPaciente();
            string datos = $"IDPaciente:{idPaciente} | Fecha:{fechaRegistro} | Nombre:{nombres} {apellidos} | Sexo:{sexo} | CURP:{curp} | Nacimiento:{nacimiento}";
            string ruta = "pacientes.txt";

            if (!string.IsNullOrEmpty(curpEditando))
            {
                string[] lineas = File.ReadAllLines(ruta);
                for (int i = 0; i < lineas.Length; i++)
                {
                    if (lineas[i].Contains($"CURP:{curpEditando}"))
                    {
                        lineas[i] = datos;
                        break;
                    }
                }
                File.WriteAllLines(ruta, lineas);
                curpEditando = "";
                idPacienteEditando = -1;
            }
            else
            {
                File.AppendAllText(ruta, datos + Environment.NewLine);
            }

            pacientesRegistrados++;
            MessageBox.Show($"✅ Paciente guardado.\nID: {idPaciente}", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar campos
            txtNombresPaciente.Clear();
            txtApellidosPaciente.Clear();
            txtCurpPaciente.Clear();
            cmbSexo.SelectedIndex = -1;
            dtpFechaNacimiento.Value = DateTime.Now;

            return true;

        }


        private void TextboxPaciente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private int ObtenerSiguienteIDPaciente()
        {
            string ruta = "pacientes.txt";
            if (!File.Exists(ruta)) return 1;

            string[] lineas = File.ReadAllLines(ruta);
            foreach (string linea in lineas.Reverse())
            {
                if (linea.Contains("IDPaciente:"))
                {
                    string[] partes = linea.Split('|');
                    foreach (string parte in partes)
                    {
                        if (parte.Trim().StartsWith("IDPaciente:"))
                        {
                            string idTexto = parte.Replace("IDPaciente:", "").Trim();
                            if (int.TryParse(idTexto, out int id)) return id + 1;
                        }
                    }
                }
            }
            return 1;
        }

        private void btnGuardaPaciente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombresPaciente.Text) ||
                string.IsNullOrWhiteSpace(txtApellidosPaciente.Text) ||
                string.IsNullOrWhiteSpace(txtCurpPaciente.Text) ||
                cmbSexo.SelectedItem == null)
            {
                MessageBox.Show("⚠️ Por favor completa todos los campos.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombres = txtNombresPaciente.Text;
            string apellidos = txtApellidosPaciente.Text;
            string sexo = cmbSexo.SelectedItem.ToString();
            string curp = txtCurpPaciente.Text;
            string nacimiento = dtpFechaNacimiento.Value.ToString("dd/MM/yyyy");
            string fechaRegistro = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            int idPaciente = (idPacienteEditando != -1) ? idPacienteEditando : ObtenerSiguienteIDPaciente();
            string datos = $"IDPaciente:{idPaciente} | Fecha:{fechaRegistro} | Nombre:{nombres} {apellidos} | Sexo:{sexo} | CURP:{curp} | Nacimiento:{nacimiento}";
            string ruta = "pacientes.txt";

            if (!string.IsNullOrEmpty(curpEditando))
            {
                // Modo edición
                string[] lineas = File.ReadAllLines(ruta);
                for (int i = 0; i < lineas.Length; i++)
                {
                    if (lineas[i].Contains($"CURP:{curpEditando}"))
                    {
                        lineas[i] = datos;
                        break;
                    }
                }
                File.WriteAllLines(ruta, lineas);
                curpEditando = "";
                idPacienteEditando = -1;
            }
            else
            {
                File.AppendAllText(ruta, datos + Environment.NewLine);
            }

            MessageBox.Show($"✅ Información guardada.\nID del paciente: {idPaciente}", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtNombresPaciente.Clear();
            txtApellidosPaciente.Clear();
            txtCurpPaciente.Clear();
            cmbSexo.SelectedIndex = -1;
            dtpFechaNacimiento.Value = DateTime.Now;
        }

        private void btnEditarPaciente_Click(object sender, EventArgs e)
        {
            string curpBuscar = txtCurpPaciente.Text;
            string ruta = "pacientes.txt";
            string[] lineas = File.ReadAllLines(ruta);

            foreach (string linea in lineas)
            {
                if (linea.Contains($"CURP:{curpBuscar}"))
                {
                    string[] partes = linea.Split('|');
                    foreach (string parte in partes)
                    {
                        if (parte.Trim().StartsWith("IDPaciente:"))
                        {
                            string idTexto = parte.Replace("IDPaciente:", "").Trim();
                            if (int.TryParse(idTexto, out int id)) idPacienteEditando = id;
                        }
                        if (parte.Trim().StartsWith("Nombre:"))
                        {
                            string[] nombreSplit = parte.Replace("Nombre:", "").Trim().Split(' ');
                            txtNombresPaciente.Text = nombreSplit[0];
                            txtApellidosPaciente.Text = string.Join(" ", nombreSplit.Skip(1));
                        }
                        if (parte.Trim().StartsWith("Sexo:"))
                            cmbSexo.SelectedItem = parte.Replace("Sexo:", "").Trim();

                        if (parte.Trim().StartsWith("CURP:"))
                            txtCurpPaciente.Text = parte.Replace("CURP:", "").Trim();

                        if (parte.Trim().StartsWith("Nacimiento:"))
                        {
                            string fecha = parte.Replace("Nacimiento:", "").Trim();
                            if (DateTime.TryParse(fecha, out DateTime fechaNac))
                                dtpFechaNacimiento.Value = fechaNac;
                        }
                    }

                    curpEditando = curpBuscar;
                    MessageBox.Show("✅ Datos cargados. Puedes editarlos ahora.", "Edición activada");
                    return;
                }
            }

            MessageBox.Show("❌ CURP no encontrado en el registro de pacientes.", "Sin coincidencias");
        }

        private void btnFinalizarRegistro_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombresPaciente.Text))
            {
                if (!GuardarPaciente()) return;
            }

            MessageBox.Show($"🩺 Has registrado {pacientesRegistrados} paciente(s).\nTe llevamos al inicio de sesión.", "Registro completo");

            // Redirigir al formulario de login
            login ventanaLogin = new login();
            ventanaLogin.Show();
            this.Close();

        }
    }
}




