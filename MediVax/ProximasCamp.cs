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
    }
}
