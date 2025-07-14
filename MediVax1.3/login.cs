using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediVax1._3
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            iniciar_sesion ventanaLogin = new iniciar_sesion(); // ← este nombre debe coincidir EXACTAMENTE con la clase del formulario
            ventanaLogin.Show(); // Abre la ventana
            this.Hide();         // Oculta el formulario actual (opcional)

        }

        private void btnNuevo_usuario_Click(object sender, EventArgs e)
        {
            newuser ventanaNuevoUsuario = new newuser(); // Usa el nombre exacto de la clase en newuser.cs
            ventanaNuevoUsuario.Show();
            this.Hide(); // Opcional: oculta la ventana actual

        }
    }
}
