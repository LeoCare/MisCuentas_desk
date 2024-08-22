namespace MisCuentas_desk
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelInicoPrincipal = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblLoginBtn = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.btnRegistro = new System.Windows.Forms.Button();
            this.lblRegistroBtn = new System.Windows.Forms.Label();
            this.lblRegistro = new System.Windows.Forms.Label();
            this.panelContenedorLogin = new System.Windows.Forms.Panel();
            this.panelEntrar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelRegistrar = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelInicoPrincipal.SuspendLayout();
            this.panelContenedorLogin.SuspendLayout();
            this.panelEntrar.SuspendLayout();
            this.panelRegistrar.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelInicoPrincipal
            // 
            this.panelInicoPrincipal.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelInicoPrincipal.Controls.Add(this.btnLogin);
            this.panelInicoPrincipal.Controls.Add(this.lblLoginBtn);
            this.panelInicoPrincipal.Controls.Add(this.lblLogin);
            this.panelInicoPrincipal.Controls.Add(this.btnRegistro);
            this.panelInicoPrincipal.Controls.Add(this.lblRegistroBtn);
            this.panelInicoPrincipal.Controls.Add(this.lblRegistro);
            this.panelInicoPrincipal.Location = new System.Drawing.Point(180, 110);
            this.panelInicoPrincipal.MaximumSize = new System.Drawing.Size(752, 304);
            this.panelInicoPrincipal.Name = "panelInicoPrincipal";
            this.panelInicoPrincipal.Size = new System.Drawing.Size(710, 304);
            this.panelInicoPrincipal.TabIndex = 2;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(51, 195);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(218, 42);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Entrar";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblLoginBtn
            // 
            this.lblLoginBtn.AutoSize = true;
            this.lblLoginBtn.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginBtn.ForeColor = System.Drawing.Color.White;
            this.lblLoginBtn.Location = new System.Drawing.Point(23, 135);
            this.lblLoginBtn.Name = "lblLoginBtn";
            this.lblLoginBtn.Size = new System.Drawing.Size(285, 23);
            this.lblLoginBtn.TabIndex = 4;
            this.lblLoginBtn.Text = "Preciona el boton para iniciar";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.Color.White;
            this.lblLogin.Location = new System.Drawing.Point(72, 78);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(186, 23);
            this.lblLogin.TabIndex = 3;
            this.lblLogin.Text = "¿Ya tienes cuenta?";
            // 
            // btnRegistro
            // 
            this.btnRegistro.BackColor = System.Drawing.Color.Transparent;
            this.btnRegistro.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRegistro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnRegistro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistro.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistro.ForeColor = System.Drawing.Color.White;
            this.btnRegistro.Location = new System.Drawing.Point(408, 195);
            this.btnRegistro.Name = "btnRegistro";
            this.btnRegistro.Size = new System.Drawing.Size(218, 42);
            this.btnRegistro.TabIndex = 2;
            this.btnRegistro.Text = "Registrarse";
            this.btnRegistro.UseVisualStyleBackColor = false;
            this.btnRegistro.Click += new System.EventHandler(this.btnRegistro_Click);
            // 
            // lblRegistroBtn
            // 
            this.lblRegistroBtn.AutoSize = true;
            this.lblRegistroBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRegistroBtn.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistroBtn.ForeColor = System.Drawing.Color.White;
            this.lblRegistroBtn.Location = new System.Drawing.Point(369, 135);
            this.lblRegistroBtn.Name = "lblRegistroBtn";
            this.lblRegistroBtn.Size = new System.Drawing.Size(321, 23);
            this.lblRegistroBtn.TabIndex = 1;
            this.lblRegistroBtn.Text = "Preciona el boton para registrarte";
            // 
            // lblRegistro
            // 
            this.lblRegistro.AutoSize = true;
            this.lblRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRegistro.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistro.ForeColor = System.Drawing.Color.White;
            this.lblRegistro.Location = new System.Drawing.Point(414, 78);
            this.lblRegistro.Name = "lblRegistro";
            this.lblRegistro.Size = new System.Drawing.Size(247, 23);
            this.lblRegistro.TabIndex = 0;
            this.lblRegistro.Text = "¿Aun no estas registrado?";
            // 
            // panelContenedorLogin
            // 
            this.panelContenedorLogin.BackColor = System.Drawing.Color.White;
            this.panelContenedorLogin.Controls.Add(this.panelEntrar);
            this.panelContenedorLogin.Controls.Add(this.panelRegistrar);
            this.panelContenedorLogin.Location = new System.Drawing.Point(180, 100);
            this.panelContenedorLogin.Name = "panelContenedorLogin";
            this.panelContenedorLogin.Size = new System.Drawing.Size(365, 325);
            this.panelContenedorLogin.TabIndex = 8;
            // 
            // panelEntrar
            // 
            this.panelEntrar.BackColor = System.Drawing.Color.White;
            this.panelEntrar.Controls.Add(this.label1);
            this.panelEntrar.Location = new System.Drawing.Point(3, 3);
            this.panelEntrar.Name = "panelEntrar";
            this.panelEntrar.Size = new System.Drawing.Size(365, 316);
            this.panelEntrar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "entrar";
            // 
            // panelRegistrar
            // 
            this.panelRegistrar.BackColor = System.Drawing.Color.White;
            this.panelRegistrar.Controls.Add(this.label2);
            this.panelRegistrar.Location = new System.Drawing.Point(372, 3);
            this.panelRegistrar.Name = "panelRegistrar";
            this.panelRegistrar.Size = new System.Drawing.Size(365, 316);
            this.panelRegistrar.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "registrar";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1079, 593);
            this.Controls.Add(this.panelContenedorLogin);
            this.Controls.Add(this.panelInicoPrincipal);
            this.Name = "Login";
            this.panelInicoPrincipal.ResumeLayout(false);
            this.panelInicoPrincipal.PerformLayout();
            this.panelContenedorLogin.ResumeLayout(false);
            this.panelEntrar.ResumeLayout(false);
            this.panelEntrar.PerformLayout();
            this.panelRegistrar.ResumeLayout(false);
            this.panelRegistrar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelInicoPrincipal;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblLoginBtn;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Button btnRegistro;
        private System.Windows.Forms.Label lblRegistroBtn;
        private System.Windows.Forms.Label lblRegistro;
        private System.Windows.Forms.Panel panelContenedorLogin;
        private System.Windows.Forms.Panel panelEntrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelRegistrar;
        private System.Windows.Forms.Label label2;
    }
}

