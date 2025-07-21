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
using MySql.Data.MySqlClient;
using MediVax.Sesion;   

namespace MediVax
{
    public partial class Cartilla : Form
    {
        private int pacienteID;

        public Cartilla()
        {
            this.pacienteID = Sesion.Sesion.UsuarioID;
            InitializeComponent();
            Cargardatos(pacienteID);
            CargarVacunas();
            CargarDatosPaciente();
        }

        private void Cartilla_Load(object sender, EventArgs e)
        {

        }

        private void historialvac_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();

        }



        void btn_save_Click(object sender, EventArgs e)
        {
            if (cmboxVacunas.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona una vacuna.");
                return;
            }
            string tabla = "aplicaciones";
            int vacunaID = Convert.ToInt32(cmboxVacunas.SelectedValue);
            string dosisAplicada = txtdosis.Text;
            DateTime fechaAplicacion = timepick.Value;

            string campos = "PacienteID, VacunaID, DosisAplicada, FechaAplicacion";
            string valores = $"{pacienteID}, {vacunaID}, '{dosisAplicada}', '{fechaAplicacion:yyyy-MM-dd}'";

            Consulta consulta = new Consulta();
            consulta.agregar(tabla, campos, valores);

            MessageBox.Show("Aplicación registrada correctamente.");
            Cargardatos(pacienteID);
        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Cargardatos(int pacienteID)
        {
            try
            {
                Consulta consulta = new Consulta();
                MySqlConnection conexion = consulta.Conectar();

                string query = @"
            SELECT 
                v.VacunaID,
                v.NombreVacuna,
                a.DosisAplicada,
                v.Previene,
                a.FechaAplicacion
            FROM aplicaciones a
            JOIN vacunas v ON a.VacunaID = v.VacunaID
            WHERE a.PacienteID = @id;
        ";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", pacienteID);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);

                historialvac.DataSource = tabla;

                consulta.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }
        private void CargarVacunas()
        {
            try
            {
                Consulta consulta = new Consulta();
                MySqlConnection conexion = consulta.Conectar();

                string query = "SELECT VacunaID, NombreVacuna, Previene FROM vacunas";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cmboxVacunas.DataSource = dt;
                cmboxVacunas.DisplayMember = "NombreVacuna";
                cmboxVacunas.ValueMember = "VacunaID";
                cmboxVacunas.SelectedIndex = -1;

                consulta.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar vacunas: " + ex.Message);
            }
        }

        private void btnRecomendaciones_Click(object sender, EventArgs e)
        {
            this.Hide();
            Recomendaciones recomendaciones = new Recomendaciones();
            recomendaciones.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCampanas_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProximasCamp proximasCamp = new ProximasCamp();
            proximasCamp.Show();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (historialvac.CurrentRow != null)
            {
                if (cmboxVacunas.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecciona una vacuna.");
                    return;
                }

                string tabla = "aplicaciones";
                int vacunaID = Convert.ToInt32(cmboxVacunas.SelectedValue);
                string dosisAplicada = txtdosis.Text;
                DateTime fechaAplicacion = timepick.Value;

                string ID = historialvac.CurrentRow.Cells["VacunaID"].Value.ToString();


                string camposvalor = $"VacunaID = {vacunaID}, DosisAplicada = '{dosisAplicada}', FechaAplicacion = '{fechaAplicacion:yyyy-MM-dd}'";

                string campo = "VacunaID";

                Consulta consulta = new Consulta();
                consulta.actualizar(tabla, camposvalor, campo, ID);

                MessageBox.Show("Registro actualizado correctamente.");
                Cargardatos(pacienteID);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
             {
            {
                if (historialvac.CurrentRow != null)
                {
                    DialogResult confirmacion = MessageBox.Show("¿Estás seguro de eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmacion == DialogResult.Yes)
                    {
                       
                        string tabla = "aplicaciones";

                        string campo = "VacunaID"; 

                        
                        string id = historialvac.CurrentRow.Cells["VacunaID"].Value.ToString();

                       
                        Consulta consulta = new Consulta();
                        consulta.eliminar(tabla, campo, id);

                        MessageBox.Show("Registro eliminado correctamente.");
                        Cargardatos(pacienteID); 
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona una fila para borrar.");
                }
            }

    }

        private void CargarDatosPaciente()
        {
            try
            {
                Consulta consulta = new Consulta();
                consulta.Conectar();

                string query = "SELECT Nombre, Apellido, Edad, Sexo FROM pacientes WHERE pacienteID = @id";
                MySqlCommand cmd = new MySqlCommand(query, consulta.Conexion);
                cmd.Parameters.AddWithValue("@id", Sesion.Sesion.UsuarioID);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblNombre.Text = reader["Nombre"].ToString() + " " + reader["Apellido"].ToString();
                    lblEdad.Text = reader["Edad"].ToString() + " años";
                    lblSexo.Text = reader["Sexo"].ToString();
                }
                else
                {
                    MessageBox.Show("No se encontró el paciente.");
                }

                reader.Close(); 
                consulta.cerrar(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del paciente: " + ex.Message);
            }
        }








    }
}


