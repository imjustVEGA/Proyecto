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
    public partial class ProximasCamp : Form
    {
        public ProximasCamp()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void btnRecomendaciones_Click(object sender, EventArgs e)
        {
            this.Hide();
            Recomendaciones recomendaciones = new Recomendaciones();
            recomendaciones.Show();
        }

        private void btncartilla_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cartilla cartilla = new Cartilla();
            cartilla.Show();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ProximasCamp_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Recomendaciones formrem = new Recomendaciones();
            formrem.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cartilla formcar = new Cartilla();
            formcar.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu formmenu = new Menu();
            formmenu.Show();
        }
    }
}
