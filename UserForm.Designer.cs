namespace testvc
{
    partial class UserForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelSubtitle = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.labelCPF = new System.Windows.Forms.Label();
            this.textBoxCPF = new System.Windows.Forms.TextBox();
            this.labelDateOfBirth = new System.Windows.Forms.Label();
            this.textBoxDateOfBirth = new System.Windows.Forms.TextBox();
            this.labelGender = new System.Windows.Forms.Label();
            this.comboBoxGender = new System.Windows.Forms.ComboBox();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.buttonUploadPhoto = new System.Windows.Forms.Button();
            this.labelPhotoStatus = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Palatino Linotype", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(28, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(234, 65);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Usuários";
            this.labelTitle.Click += new System.EventHandler(this.LabelTitle_Click);
            // 
            // labelSubtitle
            // 
            this.labelSubtitle.AutoSize = true;
            this.labelSubtitle.Font = new System.Drawing.Font("Palatino Linotype", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtitle.ForeColor = System.Drawing.Color.White;
            this.labelSubtitle.Location = new System.Drawing.Point(31, 73);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(330, 26);
            this.labelSubtitle.TabIndex = 1;
            this.labelSubtitle.Text = "Preencha os dados do usuário";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.White;
            this.labelName.Location = new System.Drawing.Point(31, 115);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(67, 22);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Nome:";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(31, 140);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(400, 28);
            this.textBoxName.TabIndex = 3;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.ForeColor = System.Drawing.Color.White;
            this.labelEmail.Location = new System.Drawing.Point(31, 180);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(62, 22);
            this.labelEmail.TabIndex = 4;
            this.labelEmail.Text = "Email:";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.Location = new System.Drawing.Point(31, 205);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(400, 28);
            this.textBoxEmail.TabIndex = 5;
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPhone.ForeColor = System.Drawing.Color.White;
            this.labelPhone.Location = new System.Drawing.Point(31, 245);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(81, 22);
            this.labelPhone.TabIndex = 6;
            this.labelPhone.Text = "Telefone:";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPhone.Location = new System.Drawing.Point(31, 270);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(400, 28);
            this.textBoxPhone.TabIndex = 7;
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddress.ForeColor = System.Drawing.Color.White;
            this.labelAddress.Location = new System.Drawing.Point(31, 310);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(77, 22);
            this.labelAddress.TabIndex = 8;
            this.labelAddress.Text = "Endereço:";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAddress.Location = new System.Drawing.Point(31, 335);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(400, 28);
            this.textBoxAddress.TabIndex = 9;
            // 
            // labelCPF
            // 
            this.labelCPF.AutoSize = true;
            this.labelCPF.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCPF.ForeColor = System.Drawing.Color.White;
            this.labelCPF.Location = new System.Drawing.Point(31, 375);
            this.labelCPF.Name = "labelCPF";
            this.labelCPF.Size = new System.Drawing.Size(48, 22);
            this.labelCPF.TabIndex = 10;
            this.labelCPF.Text = "CPF:";
            // 
            // textBoxCPF
            // 
            this.textBoxCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCPF.Location = new System.Drawing.Point(31, 400);
            this.textBoxCPF.Name = "textBoxCPF";
            this.textBoxCPF.Size = new System.Drawing.Size(400, 28);
            this.textBoxCPF.TabIndex = 11;
            // 
            // labelDateOfBirth
            // 
            this.labelDateOfBirth.AutoSize = true;
            this.labelDateOfBirth.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateOfBirth.ForeColor = System.Drawing.Color.White;
            this.labelDateOfBirth.Location = new System.Drawing.Point(31, 440);
            this.labelDateOfBirth.Name = "labelDateOfBirth";
            this.labelDateOfBirth.Size = new System.Drawing.Size(152, 22);
            this.labelDateOfBirth.TabIndex = 12;
            this.labelDateOfBirth.Text = "Data de Nascimento:";
            // 
            // textBoxDateOfBirth
            // 
            this.textBoxDateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDateOfBirth.Location = new System.Drawing.Point(31, 465);
            this.textBoxDateOfBirth.Name = "textBoxDateOfBirth";
            this.textBoxDateOfBirth.Size = new System.Drawing.Size(400, 28);
            this.textBoxDateOfBirth.TabIndex = 13;
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGender.ForeColor = System.Drawing.Color.White;
            this.labelGender.Location = new System.Drawing.Point(31, 505);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(64, 22);
            this.labelGender.TabIndex = 14;
            this.labelGender.Text = "Gênero:";
            // 
            // comboBoxGender
            // 
            this.comboBoxGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxGender.FormattingEnabled = true;
            this.comboBoxGender.Items.AddRange(new object[] {
            "Masculino",
            "Feminino",
            "Outro",
            "Prefiro não informar"});
            this.comboBoxGender.Location = new System.Drawing.Point(31, 530);
            this.comboBoxGender.Name = "comboBoxGender";
            this.comboBoxGender.Size = new System.Drawing.Size(400, 29);
            this.comboBoxGender.TabIndex = 15;
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.BackColor = System.Drawing.Color.Gray;
            this.pictureBoxProfile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxProfile.Location = new System.Drawing.Point(520, 115);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(180, 180);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 16;
            this.pictureBoxProfile.TabStop = false;
            // 
            // buttonUploadPhoto
            // 
            this.buttonUploadPhoto.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonUploadPhoto.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUploadPhoto.ForeColor = System.Drawing.Color.White;
            this.buttonUploadPhoto.Location = new System.Drawing.Point(520, 310);
            this.buttonUploadPhoto.Name = "buttonUploadPhoto";
            this.buttonUploadPhoto.Size = new System.Drawing.Size(180, 40);
            this.buttonUploadPhoto.TabIndex = 17;
            this.buttonUploadPhoto.Text = "Selecionar Foto";
            this.buttonUploadPhoto.UseVisualStyleBackColor = false;
            this.buttonUploadPhoto.Click += new System.EventHandler(this.ButtonUploadPhoto_Click);
            // 
            // labelPhotoStatus
            // 
            this.labelPhotoStatus.AutoSize = true;
            this.labelPhotoStatus.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPhotoStatus.ForeColor = System.Drawing.Color.Gray;
            this.labelPhotoStatus.Location = new System.Drawing.Point(520, 360);
            this.labelPhotoStatus.Name = "labelPhotoStatus";
            this.labelPhotoStatus.Size = new System.Drawing.Size(163, 16);
            this.labelPhotoStatus.TabIndex = 18;
            this.labelPhotoStatus.Text = "Nenhuma foto selecionada";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonSave.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(31, 590);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(150, 45);
            this.buttonSave.TabIndex = 19;
            this.buttonSave.Text = "Salvar";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonCancel.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(200, 590);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(150, 45);
            this.buttonCancel.TabIndex = 20;
            this.buttonCancel.Text = "Cancelar";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(750, 650);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelPhotoStatus);
            this.Controls.Add(this.buttonUploadPhoto);
            this.Controls.Add(this.pictureBoxProfile);
            this.Controls.Add(this.comboBoxGender);
            this.Controls.Add(this.labelGender);
            this.Controls.Add(this.textBoxDateOfBirth);
            this.Controls.Add(this.labelDateOfBirth);
            this.Controls.Add(this.textBoxCPF);
            this.Controls.Add(this.labelCPF);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelSubtitle);
            this.Controls.Add(this.labelTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "UserForm";
            this.Text = "Gerenciar Usuário";
            this.Load += new System.EventHandler(this.UserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSubtitle;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label labelCPF;
        private System.Windows.Forms.TextBox textBoxCPF;
        private System.Windows.Forms.Label labelDateOfBirth;
        private System.Windows.Forms.TextBox textBoxDateOfBirth;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.ComboBox comboBoxGender;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Button buttonUploadPhoto;
        private System.Windows.Forms.Label labelPhotoStatus;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}
