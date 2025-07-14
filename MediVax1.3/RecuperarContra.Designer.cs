namespace MediVax1._3
{
    partial class RecuperarContra
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtCorreoRecuperacion = new System.Windows.Forms.TextBox();
            this.txtNuevaContrasena = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRestablecerContrasena = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1056, 111);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // txtCorreoRecuperacion
            // 
            this.txtCorreoRecuperacion.Location = new System.Drawing.Point(91, 244);
            this.txtCorreoRecuperacion.Name = "txtCorreoRecuperacion";
            this.txtCorreoRecuperacion.Size = new System.Drawing.Size(225, 22);
            this.txtCorreoRecuperacion.TabIndex = 7;
            // 
            // txtNuevaContrasena
            // 
            this.txtNuevaContrasena.Location = new System.Drawing.Point(524, 208);
            this.txtNuevaContrasena.Name = "txtNuevaContrasena";
            this.txtNuevaContrasena.Size = new System.Drawing.Size(225, 22);
            this.txtNuevaContrasena.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Correo de recuperación";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(584, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nueva contraseña";
            // 
            // btnRestablecerContrasena
            // 
            this.btnRestablecerContrasena.Location = new System.Drawing.Point(639, 479);
            this.btnRestablecerContrasena.Name = "btnRestablecerContrasena";
            this.btnRestablecerContrasena.Size = new System.Drawing.Size(277, 110);
            this.btnRestablecerContrasena.TabIndex = 11;
            this.btnRestablecerContrasena.Text = "Restablecer Contraseña ";
            this.btnRestablecerContrasena.UseVisualStyleBackColor = true;
            this.btnRestablecerContrasena.Click += new System.EventHandler(this.btnRestablecerContrasena_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(154, 479);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(277, 110);
            this.button2.TabIndex = 12;
            this.button2.Text = "Volver al login";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RecuperarContra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 678);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnRestablecerContrasena);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNuevaContrasena);
            this.Controls.Add(this.txtCorreoRecuperacion);
            this.Controls.Add(this.pictureBox1);
            this.Name = "RecuperarContra";
            this.Text = "RecuperarContra";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtCorreoRecuperacion;
        private System.Windows.Forms.TextBox txtNuevaContrasena;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRestablecerContrasena;
        private System.Windows.Forms.Button button2;
    }
}