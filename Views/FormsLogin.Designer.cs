namespace MisCuentas_desk
{
    partial class FormsLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormsLogin));
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
            this.btnNoVerPassLogin = new System.Windows.Forms.PictureBox();
            this.btnVerPassLogin = new System.Windows.Forms.PictureBox();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.lblTituloEntrar = new System.Windows.Forms.Label();
            this.tbxPass = new System.Windows.Forms.TextBox();
            this.tbxUsuario = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblLoginCorreo = new System.Windows.Forms.Label();
            this.panelRegistrar = new System.Windows.Forms.Panel();
            this.btnNoVerPassRegistro = new System.Windows.Forms.PictureBox();
            this.btnVerPassRegistro = new System.Windows.Forms.PictureBox();
            this.btnRegistrarse = new System.Windows.Forms.Button();
            this.tbxCorreoRegistro = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblRegistro2 = new System.Windows.Forms.Label();
            this.tbxPassRegistro = new System.Windows.Forms.TextBox();
            this.tbxNombreRegistro = new System.Windows.Forms.TextBox();
            this.lblPass2 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.panelInicoPrincipal.SuspendLayout();
            this.panelContenedorLogin.SuspendLayout();
            this.panelEntrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNoVerPassLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerPassLogin)).BeginInit();
            this.panelRegistrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNoVerPassRegistro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerPassRegistro)).BeginInit();
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
            this.panelInicoPrincipal.Location = new System.Drawing.Point(312, 199);
            this.panelInicoPrincipal.MaximumSize = new System.Drawing.Size(752, 304);
            this.panelInicoPrincipal.Name = "panelInicoPrincipal";
            this.panelInicoPrincipal.Size = new System.Drawing.Size(752, 304);
            this.panelInicoPrincipal.TabIndex = 2;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(79, 180);
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
            this.lblLoginBtn.Location = new System.Drawing.Point(43, 113);
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
            this.lblLogin.Location = new System.Drawing.Point(90, 51);
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
            this.btnRegistro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistro.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistro.ForeColor = System.Drawing.Color.White;
            this.btnRegistro.Location = new System.Drawing.Point(460, 180);
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
            this.lblRegistroBtn.Location = new System.Drawing.Point(409, 113);
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
            this.lblRegistro.Location = new System.Drawing.Point(440, 51);
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
            this.panelContenedorLogin.Location = new System.Drawing.Point(310, 189);
            this.panelContenedorLogin.Name = "panelContenedorLogin";
            this.panelContenedorLogin.Size = new System.Drawing.Size(361, 404);
            this.panelContenedorLogin.TabIndex = 8;
            // 
            // panelEntrar
            // 
            this.panelEntrar.BackColor = System.Drawing.Color.White;
            this.panelEntrar.Controls.Add(this.btnNoVerPassLogin);
            this.panelEntrar.Controls.Add(this.btnVerPassLogin);
            this.panelEntrar.Controls.Add(this.btnEntrar);
            this.panelEntrar.Controls.Add(this.lblTituloEntrar);
            this.panelEntrar.Controls.Add(this.tbxPass);
            this.panelEntrar.Controls.Add(this.tbxUsuario);
            this.panelEntrar.Controls.Add(this.lblPass);
            this.panelEntrar.Controls.Add(this.lblLoginCorreo);
            this.panelEntrar.Location = new System.Drawing.Point(9, 6);
            this.panelEntrar.Name = "panelEntrar";
            this.panelEntrar.Size = new System.Drawing.Size(342, 392);
            this.panelEntrar.TabIndex = 15;
            // 
            // btnNoVerPassLogin
            // 
            this.btnNoVerPassLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnNoVerPassLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNoVerPassLogin.BackgroundImage")));
            this.btnNoVerPassLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNoVerPassLogin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNoVerPassLogin.InitialImage = null;
            this.btnNoVerPassLogin.Location = new System.Drawing.Point(289, 216);
            this.btnNoVerPassLogin.Name = "btnNoVerPassLogin";
            this.btnNoVerPassLogin.Size = new System.Drawing.Size(32, 26);
            this.btnNoVerPassLogin.TabIndex = 18;
            this.btnNoVerPassLogin.TabStop = false;
            this.btnNoVerPassLogin.Visible = false;
            this.btnNoVerPassLogin.Click += new System.EventHandler(this.btnVerPassLogin_Click);
            // 
            // btnVerPassLogin
            // 
            this.btnVerPassLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnVerPassLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVerPassLogin.BackgroundImage")));
            this.btnVerPassLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVerPassLogin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnVerPassLogin.InitialImage = null;
            this.btnVerPassLogin.Location = new System.Drawing.Point(289, 216);
            this.btnVerPassLogin.Name = "btnVerPassLogin";
            this.btnVerPassLogin.Size = new System.Drawing.Size(32, 26);
            this.btnVerPassLogin.TabIndex = 16;
            this.btnVerPassLogin.TabStop = false;
            this.btnVerPassLogin.Click += new System.EventHandler(this.btnVerPassLogin_Click);
            // 
            // btnEntrar
            // 
            this.btnEntrar.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnEntrar.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.btnEntrar.ForeColor = System.Drawing.Color.Black;
            this.btnEntrar.Location = new System.Drawing.Point(30, 294);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(281, 50);
            this.btnEntrar.TabIndex = 5;
            this.btnEntrar.Text = "ENTRAR";
            this.btnEntrar.UseVisualStyleBackColor = false;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // lblTituloEntrar
            // 
            this.lblTituloEntrar.AutoSize = true;
            this.lblTituloEntrar.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloEntrar.Location = new System.Drawing.Point(82, 18);
            this.lblTituloEntrar.Name = "lblTituloEntrar";
            this.lblTituloEntrar.Size = new System.Drawing.Size(105, 36);
            this.lblTituloEntrar.TabIndex = 4;
            this.lblTituloEntrar.Text = "LOGIN";
            // 
            // tbxPass
            // 
            this.tbxPass.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPass.Location = new System.Drawing.Point(73, 211);
            this.tbxPass.Name = "tbxPass";
            this.tbxPass.PasswordChar = '*';
            this.tbxPass.Size = new System.Drawing.Size(210, 31);
            this.tbxPass.TabIndex = 3;
            // 
            // tbxUsuario
            // 
            this.tbxUsuario.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxUsuario.Location = new System.Drawing.Point(73, 126);
            this.tbxUsuario.Name = "tbxUsuario";
            this.tbxUsuario.Size = new System.Drawing.Size(210, 31);
            this.tbxUsuario.TabIndex = 2;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.Location = new System.Drawing.Point(69, 184);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(139, 22);
            this.lblPass.TabIndex = 1;
            this.lblPass.Text = "CONTRASEÑA";
            // 
            // lblLoginCorreo
            // 
            this.lblLoginCorreo.AutoSize = true;
            this.lblLoginCorreo.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginCorreo.Location = new System.Drawing.Point(69, 99);
            this.lblLoginCorreo.Name = "lblLoginCorreo";
            this.lblLoginCorreo.Size = new System.Drawing.Size(93, 22);
            this.lblLoginCorreo.TabIndex = 0;
            this.lblLoginCorreo.Text = "CORREO";
            // 
            // panelRegistrar
            // 
            this.panelRegistrar.BackColor = System.Drawing.Color.White;
            this.panelRegistrar.Controls.Add(this.btnNoVerPassRegistro);
            this.panelRegistrar.Controls.Add(this.btnVerPassRegistro);
            this.panelRegistrar.Controls.Add(this.btnRegistrarse);
            this.panelRegistrar.Controls.Add(this.tbxCorreoRegistro);
            this.panelRegistrar.Controls.Add(this.lblCorreo);
            this.panelRegistrar.Controls.Add(this.lblRegistro2);
            this.panelRegistrar.Controls.Add(this.tbxPassRegistro);
            this.panelRegistrar.Controls.Add(this.tbxNombreRegistro);
            this.panelRegistrar.Controls.Add(this.lblPass2);
            this.panelRegistrar.Controls.Add(this.lblNombre);
            this.panelRegistrar.Location = new System.Drawing.Point(9, 6);
            this.panelRegistrar.Name = "panelRegistrar";
            this.panelRegistrar.Size = new System.Drawing.Size(342, 392);
            this.panelRegistrar.TabIndex = 9;
            // 
            // btnNoVerPassRegistro
            // 
            this.btnNoVerPassRegistro.BackColor = System.Drawing.Color.Transparent;
            this.btnNoVerPassRegistro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNoVerPassRegistro.BackgroundImage")));
            this.btnNoVerPassRegistro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNoVerPassRegistro.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNoVerPassRegistro.InitialImage = null;
            this.btnNoVerPassRegistro.Location = new System.Drawing.Point(295, 253);
            this.btnNoVerPassRegistro.Name = "btnNoVerPassRegistro";
            this.btnNoVerPassRegistro.Size = new System.Drawing.Size(32, 26);
            this.btnNoVerPassRegistro.TabIndex = 17;
            this.btnNoVerPassRegistro.TabStop = false;
            this.btnNoVerPassRegistro.Visible = false;
            this.btnNoVerPassRegistro.Click += new System.EventHandler(this.btnVerPassRegistro_Click);
            // 
            // btnVerPassRegistro
            // 
            this.btnVerPassRegistro.BackColor = System.Drawing.Color.Transparent;
            this.btnVerPassRegistro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVerPassRegistro.BackgroundImage")));
            this.btnVerPassRegistro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVerPassRegistro.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnVerPassRegistro.InitialImage = null;
            this.btnVerPassRegistro.Location = new System.Drawing.Point(295, 253);
            this.btnVerPassRegistro.Name = "btnVerPassRegistro";
            this.btnVerPassRegistro.Size = new System.Drawing.Size(32, 26);
            this.btnVerPassRegistro.TabIndex = 16;
            this.btnVerPassRegistro.TabStop = false;
            this.btnVerPassRegistro.Click += new System.EventHandler(this.btnVerPassRegistro_Click);
            // 
            // btnRegistrarse
            // 
            this.btnRegistrarse.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnRegistrarse.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.btnRegistrarse.ForeColor = System.Drawing.Color.Black;
            this.btnRegistrarse.Location = new System.Drawing.Point(40, 297);
            this.btnRegistrarse.Name = "btnRegistrarse";
            this.btnRegistrarse.Size = new System.Drawing.Size(281, 50);
            this.btnRegistrarse.TabIndex = 11;
            this.btnRegistrarse.Text = "REGISTRARSE";
            this.btnRegistrarse.UseVisualStyleBackColor = false;
            this.btnRegistrarse.Click += new System.EventHandler(this.btnRegistrarse_Click);
            // 
            // tbxCorreoRegistro
            // 
            this.tbxCorreoRegistro.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCorreoRegistro.Location = new System.Drawing.Point(79, 178);
            this.tbxCorreoRegistro.Name = "tbxCorreoRegistro";
            this.tbxCorreoRegistro.Size = new System.Drawing.Size(210, 31);
            this.tbxCorreoRegistro.TabIndex = 8;
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreo.Location = new System.Drawing.Point(75, 153);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(93, 22);
            this.lblCorreo.TabIndex = 10;
            this.lblCorreo.Text = "CORREO";
            // 
            // lblRegistro2
            // 
            this.lblRegistro2.AutoSize = true;
            this.lblRegistro2.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistro2.Location = new System.Drawing.Point(91, 18);
            this.lblRegistro2.Name = "lblRegistro2";
            this.lblRegistro2.Size = new System.Drawing.Size(191, 36);
            this.lblRegistro2.TabIndex = 9;
            this.lblRegistro2.Text = "REGISTRARSE";
            // 
            // tbxPassRegistro
            // 
            this.tbxPassRegistro.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPassRegistro.Location = new System.Drawing.Point(79, 248);
            this.tbxPassRegistro.Name = "tbxPassRegistro";
            this.tbxPassRegistro.PasswordChar = '*';
            this.tbxPassRegistro.Size = new System.Drawing.Size(210, 31);
            this.tbxPassRegistro.TabIndex = 9;
            // 
            // tbxNombreRegistro
            // 
            this.tbxNombreRegistro.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNombreRegistro.Location = new System.Drawing.Point(79, 109);
            this.tbxNombreRegistro.Name = "tbxNombreRegistro";
            this.tbxNombreRegistro.Size = new System.Drawing.Size(210, 31);
            this.tbxNombreRegistro.TabIndex = 7;
            // 
            // lblPass2
            // 
            this.lblPass2.AutoSize = true;
            this.lblPass2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass2.Location = new System.Drawing.Point(75, 221);
            this.lblPass2.Name = "lblPass2";
            this.lblPass2.Size = new System.Drawing.Size(139, 22);
            this.lblPass2.TabIndex = 6;
            this.lblPass2.Text = "CONTRASEÑA";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(75, 82);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(91, 22);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "NOMBRE";
            // 
            // Login
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1347, 749);
            this.Controls.Add(this.panelContenedorLogin);
            this.Controls.Add(this.panelInicoPrincipal);
            this.Name = "Login";
            this.panelInicoPrincipal.ResumeLayout(false);
            this.panelInicoPrincipal.PerformLayout();
            this.panelContenedorLogin.ResumeLayout(false);
            this.panelEntrar.ResumeLayout(false);
            this.panelEntrar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNoVerPassLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerPassLogin)).EndInit();
            this.panelRegistrar.ResumeLayout(false);
            this.panelRegistrar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNoVerPassRegistro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerPassRegistro)).EndInit();
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
        private System.Windows.Forms.Panel panelRegistrar;
        private System.Windows.Forms.TextBox tbxCorreoRegistro;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblRegistro2;
        private System.Windows.Forms.TextBox tbxPassRegistro;
        private System.Windows.Forms.TextBox tbxNombreRegistro;
        private System.Windows.Forms.Label lblPass2;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnRegistrarse;
        private System.Windows.Forms.Panel panelEntrar;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.Label lblTituloEntrar;
        private System.Windows.Forms.TextBox tbxPass;
        private System.Windows.Forms.TextBox tbxUsuario;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblLoginCorreo;
        private System.Windows.Forms.PictureBox btnVerPassLogin;
        private System.Windows.Forms.PictureBox btnVerPassRegistro;
        private System.Windows.Forms.PictureBox btnNoVerPassRegistro;
        private System.Windows.Forms.PictureBox btnNoVerPassLogin;
    }
}

