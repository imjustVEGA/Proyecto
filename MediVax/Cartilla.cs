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

namespace MediVax
{
    public partial class Cartilla : Form
    {
        public Cartilla()
        {
            InitializeComponent();
            CargarDatosVacunas();
        }

        private void Cartilla_Load(object sender, EventArgs e)
        {

        }

        private void historialvac_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
            this.Close();
        }

        private void addvac_Click(object sender, EventArgs e)
        {
            

        }
        private void CargarDatosVacunas()
        {
            Consulta consulta = new Consulta();
            string query = "SELECT Nombre, Dosis, Previene, FechaAplic FROM vacuna";

            using (MySqlConnection conexion = consulta.Conectar())
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    historialvac.DataSource = table;

                    historialvac.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    historialvac.ReadOnly = true;
                    historialvac.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos: " + ex.Message);
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string nombre = txtnombre.Text;
            string dosis = txtdosis.Text;
            string previene = txtprev.Text;
            string fechaAplicada = timepick.Value.ToString("yyyy-MM-dd");
            Consulta consulta = new Consulta();

            string tabla = "vacuna";
            string campos = "Nombre, Dosis, Previene, FechaAplic";
            string valores = $"'{nombre}', '{dosis}', '{previene}', '{fechaAplicada}'";

            try
            {
                consulta.agregar(tabla, campos, valores);
                MessageBox.Show("Datos registrados exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar datos: {ex.Message}");
            }

            historialvac.Refresh();

        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
