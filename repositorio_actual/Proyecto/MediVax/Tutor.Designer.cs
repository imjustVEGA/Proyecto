namespace MediVax
{
    partial class Tutor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tutor));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtNombres = new TextBox();
            txtApellidos = new TextBox();
            txtCorreo = new TextBox();
            txtContrasena = new TextBox();
            btnGuardarInformacion = new Button();
            btnEditarInformacion = new Button();
            btnRegistrarPaciente = new Button();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.Anchor = AnchorStyles.None;
            guna2PictureBox1.BackColor = SystemColors.Control;
            guna2PictureBox1.CustomizableEdges = customizableEdges1;
            guna2PictureBox1.Image = (Image)resources.GetObject("guna2PictureBox1.Image");
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(542, 0);
            guna2PictureBox1.Margin = new Padding(3, 4, 3, 4);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2PictureBox1.Size = new Size(405, 691);
            guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            guna2PictureBox1.TabIndex = 7;
            guna2PictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(30, 98);
            label1.Name = "label1";
            label1.Size = new Size(410, 62);
            label1.TabIndex = 8;
            label1.Text = "Registro de Tutor";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(127, 0);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(186, 109);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Nirmala Text", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(15, 160);
            label2.Name = "label2";
            label2.Size = new Size(145, 38);
            label2.TabIndex = 12;
            label2.Text = "Nombres:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Nirmala Text", 16.2F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(15, 263);
            label3.Name = "label3";
            label3.Size = new Size(147, 38);
            label3.TabIndex = 13;
            label3.Text = "Apellidos:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Nirmala Text", 16.2F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(15, 368);
            label4.Name = "label4";
            label4.Size = new Size(113, 38);
            label4.TabIndex = 14;
            label4.Text = "Correo:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Nirmala Text", 16.2F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(15, 468);
            label5.Name = "label5";
            label5.Size = new Size(172, 38);
            label5.TabIndex = 15;
            label5.Text = "Contraseña:";
            // 
            // txtNombres
            // 
            txtNombres.Location = new Point(15, 201);
            txtNombres.Multiline = true;
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(269, 47);
            txtNombres.TabIndex = 16;
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(15, 304);
            txtApellidos.Multiline = true;
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(269, 47);
            txtApellidos.TabIndex = 17;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(15, 409);
            txtCorreo.Multiline = true;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(269, 47);
            txtCorreo.TabIndex = 18;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(15, 509);
            txtContrasena.Multiline = true;
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(269, 47);
            txtContrasena.TabIndex = 19;
            // 
            // btnGuardarInformacion
            // 
            btnGuardarInformacion.BackColor = Color.FromArgb(0, 192, 0);
            btnGuardarInformacion.Location = new Point(347, 201);
            btnGuardarInformacion.Name = "btnGuardarInformacion";
            btnGuardarInformacion.Size = new Size(157, 82);
            btnGuardarInformacion.TabIndex = 20;
            btnGuardarInformacion.Text = "Guardar Información";
            btnGuardarInformacion.UseVisualStyleBackColor = false;
            btnGuardarInformacion.Click += btnGuardarInformacion_Click;
            // 
            // btnEditarInformacion
            // 
            btnEditarInformacion.BackColor = Color.FromArgb(0, 192, 0);
            btnEditarInformacion.Location = new Point(347, 321);
            btnEditarInformacion.Name = "btnEditarInformacion";
            btnEditarInformacion.Size = new Size(157, 82);
            btnEditarInformacion.TabIndex = 21;
            btnEditarInformacion.Text = "Editar información";
            btnEditarInformacion.UseVisualStyleBackColor = false;
            btnEditarInformacion.Click += btnEditarInformacion_Click;
            // 
            // btnRegistrarPaciente
            // 
            btnRegistrarPaciente.BackColor = Color.FromArgb(0, 192, 0);
            btnRegistrarPaciente.Location = new Point(347, 440);
            btnRegistrarPaciente.Name = "btnRegistrarPaciente";
            btnRegistrarPaciente.Size = new Size(157, 82);
            btnRegistrarPaciente.TabIndex = 22;
            btnRegistrarPaciente.Text = "Pasar a registrar paciente";
            btnRegistrarPaciente.UseVisualStyleBackColor = false;
            btnRegistrarPaciente.Click += btnRegistrarPaciente_Click;
            // 
            // Tutor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 20, 255);
            ClientSize = new Size(943, 661);
            Controls.Add(btnRegistrarPaciente);
            Controls.Add(btnEditarInformacion);
            Controls.Add(btnGuardarInformacion);
            Controls.Add(txtContrasena);
            Controls.Add(txtCorreo);
            Controls.Add(txtApellidos);
            Controls.Add(txtNombres);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(guna2PictureBox1);
            Name = "Tutor";
            Text = "Tutor";
            Load += Tutor_Load;
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtNombres;
        private TextBox txtApellidos;
        private TextBox txtCorreo;
        private TextBox txtContrasena;
        private Button btnGuardarInformacion;
        private Button btnEditarInformacion;
        private Button btnRegistrarPaciente;
    }
}