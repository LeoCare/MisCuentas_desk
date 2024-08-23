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
            this.panelRegistrar = new System.Windows.Forms.Panel();
            this.panelEntrar = new System.Windows.Forms.Panel();
            this.lblTituloEntrar = new System.Windows.Forms.Label();
            this.tbxPass = new System.Windows.Forms.TextBox();
            this.tbxUsuario = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblRegistro2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblPass2 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.panelInicoPrincipal.SuspendLayout();
            this.panelContenedorLogin.SuspendLayout();
            this.panelRegistrar.SuspendLayout();
            this.panelEntrar.SuspendLayout();
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
            this.panelInicoPrincipal.Location = new System.Drawing.Point(186, 110);
            this.panelInicoPrincipal.MaximumSize = new System.Drawing.Size(752, 304);
            this.panelInicoPrincipal.Name = "panelInicoPrincipal";
            this.panelInicoPrincipal.Size = new System.Drawing.Size(705, 304);
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
            this.btnLogin.Location = new System.Drawing.Point(58, 194);
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
            this.lblLoginBtn.Location = new System.Drawing.Point(54, 120);
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
            this.lblLogin.Location = new System.Drawing.Point(90, 85);
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
            this.btnRegistro.Location = new System.Drawing.Point(442, 187);
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
            this.lblRegistroBtn.Location = new System.Drawing.Point(425, 120);
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
            this.lblRegistro.Location = new System.Drawing.Point(458, 85);
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
            this.panelContenedorLogin.Size = new System.Drawing.Size(361, 325);
            this.panelContenedorLogin.TabIndex = 8;
            // 
            // panelRegistrar
            // 
            this.panelRegistrar.BackColor = System.Drawing.Color.White;
            this.panelRegistrar.Controls.Add(this.textBox3);
            this.panelRegistrar.Controls.Add(this.lblCorreo);
            this.panelRegistrar.Controls.Add(this.lblRegistro2);
            this.panelRegistrar.Controls.Add(this.textBox1);
            this.panelRegistrar.Controls.Add(this.textBox2);
            this.panelRegistrar.Controls.Add(this.lblPass2);
            this.panelRegistrar.Controls.Add(this.lblNombre);
            this.panelRegistrar.Location = new System.Drawing.Point(9, 6);
            this.panelRegistrar.Name = "panelRegistrar";
            this.panelRegistrar.Size = new System.Drawing.Size(342, 316);
            this.panelRegistrar.TabIndex = 9;
            // 
            // panelEntrar
            // 
            this.panelEntrar.BackColor = System.Drawing.Color.White;
            this.panelEntrar.Controls.Add(this.lblTituloEntrar);
            this.panelEntrar.Controls.Add(this.tbxPass);
            this.panelEntrar.Controls.Add(this.tbxUsuario);
            this.panelEntrar.Controls.Add(this.lblPass);
            this.panelEntrar.Controls.Add(this.lblUsuario);
            this.panelEntrar.Location = new System.Drawing.Point(18, 6);
            this.panelEntrar.Name = "panelEntrar";
            this.panelEntrar.Size = new System.Drawing.Size(316, 316);
            this.panelEntrar.TabIndex = 12;
            // 
            // lblTituloEntrar
            // 
            this.lblTituloEntrar.AutoSize = true;
            this.lblTituloEntrar.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloEntrar.Location = new System.Drawing.Point(129, 30);
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
            this.tbxPass.Size = new System.Drawing.Size(210, 31);
            this.tbxPass.TabIndex = 3;
            this.tbxPass.UseSystemPasswordChar = true;
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
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(69, 99);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(92, 22);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "USUARIO";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(79, 178);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(210, 31);
            this.textBox3.TabIndex = 8;
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
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(79, 248);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 31);
            this.textBox1.TabIndex = 9;
            this.textBox1.UseSystemPasswordChar = true;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(79, 109);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(210, 31);
            this.textBox2.TabIndex = 7;
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(962, 506);
            this.Controls.Add(this.panelContenedorLogin);
            this.Controls.Add(this.panelInicoPrincipal);
            this.Name = "Login";
            this.panelInicoPrincipal.ResumeLayout(false);
            this.panelInicoPrincipal.PerformLayout();
            this.panelContenedorLogin.ResumeLayout(false);
            this.panelRegistrar.ResumeLayout(false);
            this.panelRegistrar.PerformLayout();
            this.panelEntrar.ResumeLayout(false);
            this.panelEntrar.PerformLayout();
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
        private System.Windows.Forms.Label lblTituloEntrar;
        private System.Windows.Forms.TextBox tbxPass;
        private System.Windows.Forms.TextBox tbxUsuario;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Panel panelRegistrar;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblRegistro2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblPass2;
        private System.Windows.Forms.Label lblNombre;
    }
}

