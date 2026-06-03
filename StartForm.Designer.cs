namespace testvc
{
    partial class StartForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelSubtitulo = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonCadastro = new System.Windows.Forms.Button();
            this.buttonSair = new System.Windows.Forms.Button();
            this.labelRodape = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Palatino Linotype", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.Color.White;
            this.labelTitulo.Location = new System.Drawing.Point(43, 38);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(149, 65);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Jogos";
            // 
            // labelSubtitulo
            // 
            this.labelSubtitulo.AutoSize = true;
            this.labelSubtitulo.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtitulo.ForeColor = System.Drawing.Color.White;
            this.labelSubtitulo.Location = new System.Drawing.Point(49, 105);
            this.labelSubtitulo.Name = "labelSubtitulo";
            this.labelSubtitulo.Size = new System.Drawing.Size(420, 32);
            this.labelSubtitulo.TabIndex = 1;
            this.labelSubtitulo.Text = "Entre ou crie uma conta para continuar";
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonLogin.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Location = new System.Drawing.Point(55, 186);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(360, 58);
            this.buttonLogin.TabIndex = 2;
            this.buttonLogin.Text = "Fazer login";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // buttonCadastro
            // 
            this.buttonCadastro.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonCadastro.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCadastro.ForeColor = System.Drawing.Color.White;
            this.buttonCadastro.Location = new System.Drawing.Point(55, 264);
            this.buttonCadastro.Name = "buttonCadastro";
            this.buttonCadastro.Size = new System.Drawing.Size(360, 58);
            this.buttonCadastro.TabIndex = 3;
            this.buttonCadastro.Text = "Cadastrar novo usuario";
            this.buttonCadastro.UseVisualStyleBackColor = false;
            this.buttonCadastro.Click += new System.EventHandler(this.ButtonCadastro_Click);
            // 
            // buttonSair
            // 
            this.buttonSair.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonSair.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSair.ForeColor = System.Drawing.Color.White;
            this.buttonSair.Location = new System.Drawing.Point(55, 350);
            this.buttonSair.Name = "buttonSair";
            this.buttonSair.Size = new System.Drawing.Size(130, 42);
            this.buttonSair.TabIndex = 4;
            this.buttonSair.Text = "Sair";
            this.buttonSair.UseVisualStyleBackColor = false;
            this.buttonSair.Click += new System.EventHandler(this.ButtonSair_Click);
            // 
            // labelRodape
            // 
            this.labelRodape.AutoSize = true;
            this.labelRodape.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRodape.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelRodape.Location = new System.Drawing.Point(51, 423);
            this.labelRodape.Name = "labelRodape";
            this.labelRodape.Size = new System.Drawing.Size(270, 20);
            this.labelRodape.TabIndex = 5;
            this.labelRodape.Text = "Sua biblioteca fica vinculada ao usuario";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(520, 480);
            this.Controls.Add(this.labelRodape);
            this.Controls.Add(this.buttonSair);
            this.Controls.Add(this.buttonCadastro);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.labelSubtitulo);
            this.Controls.Add(this.labelTitulo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelSubtitulo;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonCadastro;
        private System.Windows.Forms.Button buttonSair;
        private System.Windows.Forms.Label labelRodape;
    }
}
