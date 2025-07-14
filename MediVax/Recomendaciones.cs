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
    public partial class Recomendaciones : Form
    {
        public Recomendaciones()
        {
            InitializeComponent();
        }

        private void Recomendaciones_Load(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnmenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void btnCamp_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProximasCamp formcamp = new ProximasCamp();
            formcamp.Show();
        }

        private void btncart_Click(object sender, EventArgs e)
        {
            this.Hide();
        Cartilla formcart = new Cartilla();
            formcart.Show();
        }
    }
}
