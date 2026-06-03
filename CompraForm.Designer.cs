namespace testvc
{
    partial class CompraForm
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
            this.pictureBoxJogo = new System.Windows.Forms.PictureBox();
            this.labelTituloJogo = new System.Windows.Forms.Label();
            this.labelCategorias = new System.Windows.Forms.Label();
            this.labelDescricao = new System.Windows.Forms.Label();
            this.labelPrecoTitulo = new System.Windows.Forms.Label();
            this.labelPreco = new System.Windows.Forms.Label();
            this.buttonComprar = new System.Windows.Forms.Button();
            this.buttonVoltar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxJogo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Palatino Linotype", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.Color.White;
            this.labelTitulo.Location = new System.Drawing.Point(28, 9);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(210, 65);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Compra";
            // 
            // labelSubtitulo
            // 
            this.labelSubtitulo.AutoSize = true;
            this.labelSubtitulo.Font = new System.Drawing.Font("Palatino Linotype", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtitulo.ForeColor = System.Drawing.Color.White;
            this.labelSubtitulo.Location = new System.Drawing.Point(33, 73);
            this.labelSubtitulo.Name = "labelSubtitulo";
            this.labelSubtitulo.Size = new System.Drawing.Size(370, 36);
            this.labelSubtitulo.TabIndex = 1;
            this.labelSubtitulo.Text = "Confirme os dados do jogo";
            // 
            // pictureBoxJogo
            // 
            this.pictureBoxJogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxJogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxJogo.Location = new System.Drawing.Point(39, 139);
            this.pictureBoxJogo.Name = "pictureBoxJogo";
            this.pictureBoxJogo.Size = new System.Drawing.Size(360, 260);
            this.pictureBoxJogo.TabIndex = 2;
            this.pictureBoxJogo.TabStop = false;
            // 
            // labelTituloJogo
            // 
            this.labelTituloJogo.AutoSize = true;
            this.labelTituloJogo.Font = new System.Drawing.Font("Palatino Linotype", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTituloJogo.ForeColor = System.Drawing.Color.White;
            this.labelTituloJogo.Location = new System.Drawing.Point(430, 139);
            this.labelTituloJogo.MaximumSize = new System.Drawing.Size(420, 0);
            this.labelTituloJogo.Name = "labelTituloJogo";
            this.labelTituloJogo.Size = new System.Drawing.Size(126, 51);
            this.labelTituloJogo.TabIndex = 3;
            this.labelTituloJogo.Text = "Jogo";
            // 
            // labelCategorias
            // 
            this.labelCategorias.AutoSize = true;
            this.labelCategorias.Font = new System.Drawing.Font("Palatino Linotype", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCategorias.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelCategorias.Location = new System.Drawing.Point(434, 198);
            this.labelCategorias.MaximumSize = new System.Drawing.Size(420, 0);
            this.labelCategorias.Name = "labelCategorias";
            this.labelCategorias.Size = new System.Drawing.Size(120, 29);
            this.labelCategorias.TabIndex = 4;
            this.labelCategorias.Text = "Categoria";
            // 
            // labelDescricao
            // 
            this.labelDescricao.Font = new System.Drawing.Font("Palatino Linotype", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescricao.ForeColor = System.Drawing.Color.White;
            this.labelDescricao.Location = new System.Drawing.Point(435, 251);
            this.labelDescricao.Name = "labelDescricao";
            this.labelDescricao.Size = new System.Drawing.Size(420, 92);
            this.labelDescricao.TabIndex = 5;
            this.labelDescricao.Text = "Finalize a compra para adicionar este jogo a sua biblioteca e acessar pela tela p" +
    "rincipal.";
            // 
            // labelPrecoTitulo
            // 
            this.labelPrecoTitulo.AutoSize = true;
            this.labelPrecoTitulo.Font = new System.Drawing.Font("Palatino Linotype", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrecoTitulo.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelPrecoTitulo.Location = new System.Drawing.Point(434, 356);
            this.labelPrecoTitulo.Name = "labelPrecoTitulo";
            this.labelPrecoTitulo.Size = new System.Drawing.Size(61, 26);
            this.labelPrecoTitulo.TabIndex = 6;
            this.labelPrecoTitulo.Text = "Preco";
            // 
            // labelPreco
            // 
            this.labelPreco.AutoSize = true;
            this.labelPreco.Font = new System.Drawing.Font("Palatino Linotype", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPreco.ForeColor = System.Drawing.Color.White;
            this.labelPreco.Location = new System.Drawing.Point(431, 382);
            this.labelPreco.Name = "labelPreco";
            this.labelPreco.Size = new System.Drawing.Size(147, 44);
            this.labelPreco.TabIndex = 7;
            this.labelPreco.Text = "R$ 0,00";
            // 
            // buttonComprar
            // 
            this.buttonComprar.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonComprar.Font = new System.Drawing.Font("Palatino Linotype", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonComprar.ForeColor = System.Drawing.Color.White;
            this.buttonComprar.Location = new System.Drawing.Point(439, 462);
            this.buttonComprar.Name = "buttonComprar";
            this.buttonComprar.Size = new System.Drawing.Size(180, 50);
            this.buttonComprar.TabIndex = 8;
            this.buttonComprar.Text = "Comprar";
            this.buttonComprar.UseVisualStyleBackColor = false;
            this.buttonComprar.Click += new System.EventHandler(this.ButtonComprar_Click);
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonVoltar.Font = new System.Drawing.Font("Palatino Linotype", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVoltar.ForeColor = System.Drawing.Color.White;
            this.buttonVoltar.Location = new System.Drawing.Point(639, 462);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(180, 50);
            this.buttonVoltar.TabIndex = 9;
            this.buttonVoltar.Text = "Voltar";
            this.buttonVoltar.UseVisualStyleBackColor = false;
            this.buttonVoltar.Click += new System.EventHandler(this.ButtonVoltar_Click);
            // 
            // CompraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(900, 560);
            this.Controls.Add(this.buttonVoltar);
            this.Controls.Add(this.buttonComprar);
            this.Controls.Add(this.labelPreco);
            this.Controls.Add(this.labelPrecoTitulo);
            this.Controls.Add(this.labelDescricao);
            this.Controls.Add(this.labelCategorias);
            this.Controls.Add(this.labelTituloJogo);
            this.Controls.Add(this.pictureBoxJogo);
            this.Controls.Add(this.labelSubtitulo);
            this.Controls.Add(this.labelTitulo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "CompraForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Compra";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxJogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelSubtitulo;
        private System.Windows.Forms.PictureBox pictureBoxJogo;
        private System.Windows.Forms.Label labelTituloJogo;
        private System.Windows.Forms.Label labelCategorias;
        private System.Windows.Forms.Label labelDescricao;
        private System.Windows.Forms.Label labelPrecoTitulo;
        private System.Windows.Forms.Label labelPreco;
        private System.Windows.Forms.Button buttonComprar;
        private System.Windows.Forms.Button buttonVoltar;
    }
}
