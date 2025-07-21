using MediVax.Sesion;
namespace MediVax
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void btncart_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cartilla nuevoFormulario = new Cartilla();
            nuevoFormulario.Show();

        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            Recomendaciones nuevoFormulario = new Recomendaciones();
            nuevoFormulario.Show();
        }

        private void guna2CirclePictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Separator1_Click(object sender, EventArgs e)
        {

        }

        private void btnCamp_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProximasCamp nuevoFormulario = new ProximasCamp();
            nuevoFormulario.Show();
        }

        private void btnmenu_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
            Sesion.Sesion.UsuarioID = 0;
            InicioSesion inicioSesion = new InicioSesion();
            inicioSesion.Show();
        }
    }
}
