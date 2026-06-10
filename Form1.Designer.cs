namespace testvc
{
    partial class Form1
    {
        /// <summary>
        /// Variavel de designer necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estao sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessario descartar os recursos gerenciados; caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codigo gerado pelo Windows Form Designer

        /// <summary>
        /// Metodo necessario para suporte ao Designer.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAdicionarJogo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtpesquisa = new System.Windows.Forms.TextBox();
            this.filterPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonFiltroTodos = new System.Windows.Forms.Button();
            this.buttonFiltroMedia = new System.Windows.Forms.Button();
            this.buttonFiltroMediana = new System.Windows.Forms.Button();
            this.buttonFiltroModa = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panelJogos = new System.Windows.Forms.FlowLayoutPanel();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.buttonNewUser = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.searchPanel.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.footerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 65);
            this.label1.TabIndex = 0;
            this.label1.Text = "Jogos";
            // 
            // buttonAdicionarJogo
            // 
            this.buttonAdicionarJogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdicionarJogo.BackColor = System.Drawing.Color.White;
            this.buttonAdicionarJogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdicionarJogo.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.buttonAdicionarJogo.Location = new System.Drawing.Point(909, 25);
            this.buttonAdicionarJogo.Name = "buttonAdicionarJogo";
            this.buttonAdicionarJogo.Size = new System.Drawing.Size(46, 42);
            this.buttonAdicionarJogo.TabIndex = 21;
            this.buttonAdicionarJogo.Text = "+";
            this.buttonAdicionarJogo.UseVisualStyleBackColor = false;
            this.buttonAdicionarJogo.Visible = false;
            this.buttonAdicionarJogo.Click += new System.EventHandler(this.ButtonAdicionarJogo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(31, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(330, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "Escolha um jogo para comprar";
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.White;
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.txtpesquisa);
            this.searchPanel.Location = new System.Drawing.Point(39, 130);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(799, 43);
            this.searchPanel.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(12, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "?";
            // 
            // txtpesquisa
            // 
            this.txtpesquisa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtpesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpesquisa.Location = new System.Drawing.Point(48, 10);
            this.txtpesquisa.Name = "txtpesquisa";
            this.txtpesquisa.Size = new System.Drawing.Size(735, 22);
            this.txtpesquisa.TabIndex = 17;
            this.txtpesquisa.TextChanged += new System.EventHandler(this.Txtpesquisa_TextChanged);
            // 
            // filterPanel
            // 
            this.filterPanel.Controls.Add(this.buttonFiltroTodos);
            this.filterPanel.Controls.Add(this.buttonFiltroMedia);
            this.filterPanel.Controls.Add(this.buttonFiltroMediana);
            this.filterPanel.Controls.Add(this.buttonFiltroModa);
            this.filterPanel.Location = new System.Drawing.Point(39, 183);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(799, 42);
            this.filterPanel.TabIndex = 20;
            // 
            // buttonFiltroTodos
            // 
            this.buttonFiltroTodos.BackColor = System.Drawing.Color.White;
            this.buttonFiltroTodos.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFiltroTodos.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.buttonFiltroTodos.Location = new System.Drawing.Point(3, 3);
            this.buttonFiltroTodos.Name = "buttonFiltroTodos";
            this.buttonFiltroTodos.Size = new System.Drawing.Size(100, 34);
            this.buttonFiltroTodos.TabIndex = 0;
            this.buttonFiltroTodos.Text = "Todos";
            this.buttonFiltroTodos.UseVisualStyleBackColor = false;
            this.buttonFiltroTodos.Click += new System.EventHandler(this.ButtonFiltroTodos_Click);
            // 
            // buttonFiltroMedia
            // 
            this.buttonFiltroMedia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.buttonFiltroMedia.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFiltroMedia.ForeColor = System.Drawing.Color.White;
            this.buttonFiltroMedia.Location = new System.Drawing.Point(109, 3);
            this.buttonFiltroMedia.Name = "buttonFiltroMedia";
            this.buttonFiltroMedia.Size = new System.Drawing.Size(100, 34);
            this.buttonFiltroMedia.TabIndex = 1;
            this.buttonFiltroMedia.Text = "Media";
            this.buttonFiltroMedia.UseVisualStyleBackColor = false;
            this.buttonFiltroMedia.Click += new System.EventHandler(this.ButtonFiltroMedia_Click);
            // 
            // buttonFiltroMediana
            // 
            this.buttonFiltroMediana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.buttonFiltroMediana.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFiltroMediana.ForeColor = System.Drawing.Color.White;
            this.buttonFiltroMediana.Location = new System.Drawing.Point(215, 3);
            this.buttonFiltroMediana.Name = "buttonFiltroMediana";
            this.buttonFiltroMediana.Size = new System.Drawing.Size(100, 34);
            this.buttonFiltroMediana.TabIndex = 2;
            this.buttonFiltroMediana.Text = "Mediana";
            this.buttonFiltroMediana.UseVisualStyleBackColor = false;
            this.buttonFiltroMediana.Click += new System.EventHandler(this.ButtonFiltroMediana_Click);
            // 
            // buttonFiltroModa
            // 
            this.buttonFiltroModa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.buttonFiltroModa.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFiltroModa.ForeColor = System.Drawing.Color.White;
            this.buttonFiltroModa.Location = new System.Drawing.Point(321, 3);
            this.buttonFiltroModa.Name = "buttonFiltroModa";
            this.buttonFiltroModa.Size = new System.Drawing.Size(100, 34);
            this.buttonFiltroModa.TabIndex = 3;
            this.buttonFiltroModa.Text = "Moda";
            this.buttonFiltroModa.UseVisualStyleBackColor = false;
            this.buttonFiltroModa.Click += new System.EventHandler(this.ButtonFiltroModa_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(31, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(210, 44);
            this.label5.TabIndex = 6;
            this.label5.Text = "| Loja de jogos";
            // 
            // panelJogos
            // 
            this.panelJogos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelJogos.AutoScroll = true;
            this.panelJogos.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelJogos.Location = new System.Drawing.Point(39, 285);
            this.panelJogos.Name = "panelJogos";
            this.panelJogos.Padding = new System.Windows.Forms.Padding(0, 0, 12, 16);
            this.panelJogos.Size = new System.Drawing.Size(929, 326);
            this.panelJogos.TabIndex = 18;
            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = System.Drawing.Color.DarkSlateGray;
            this.footerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.footerPanel.Controls.Add(this.buttonNewUser);
            this.footerPanel.Controls.Add(this.label7);
            this.footerPanel.Controls.Add(this.label6);
            this.footerPanel.Controls.Add(this.pictureBox4);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 631);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(1006, 64);
            this.footerPanel.TabIndex = 19;
            // 
            // buttonNewUser
            // 
            this.buttonNewUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNewUser.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonNewUser.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewUser.ForeColor = System.Drawing.Color.White;
            this.buttonNewUser.Location = new System.Drawing.Point(819, 10);
            this.buttonNewUser.Name = "buttonNewUser";
            this.buttonNewUser.Size = new System.Drawing.Size(150, 42);
            this.buttonNewUser.TabIndex = 27;
            this.buttonNewUser.Text = "Meu Perfil";
            this.buttonNewUser.UseVisualStyleBackColor = false;
            this.buttonNewUser.Click += new System.EventHandler(this.ButtonNewUser_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LimeGreen;
            this.label7.Location = new System.Drawing.Point(74, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "• Online";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(73, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 28);
            this.label6.TabIndex = 15;
            this.label6.Text = "HighspeedIV";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::testvc.Properties.Resources.icon1;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.InitialImage = null;
            this.pictureBox4.Location = new System.Drawing.Point(12, 8);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(50, 45);
            this.pictureBox4.TabIndex = 14;
            this.pictureBox4.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1006, 695);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.panelJogos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.buttonAdicionarJogo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "Form1";
            this.Text = "Jogos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.filterPanel.ResumeLayout(false);
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAdicionarJogo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel filterPanel;
        private System.Windows.Forms.Button buttonFiltroTodos;
        private System.Windows.Forms.Button buttonFiltroMedia;
        private System.Windows.Forms.Button buttonFiltroMediana;
        private System.Windows.Forms.Button buttonFiltroModa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtpesquisa;
        private System.Windows.Forms.FlowLayoutPanel panelJogos;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonNewUser;
    }
}
