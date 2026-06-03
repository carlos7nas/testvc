using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testvc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Carregar dados do usuário ao abrir o formulário
            LoadUserData();
        }

        private void LoadUserData()
        {
            try
            {
                // Se houver usuário na sessão, exibir dados
                if (SessionContext.CurrentUserId > 0)
                {
                    // Carregar dados do usuário do banco
                    UsuarioManager.Usuario usuario = UsuarioManager.ObtenerUsuario(SessionContext.CurrentUserId);
                    if (usuario != null)
                    {
                        label6.Text = usuario.Nome;
                        SessionContext.CurrentUserName = usuario.Nome;

                        // Tentar carregar imagem do banco ou de arquivo
                        if (!string.IsNullOrEmpty(SessionContext.CurrentUserImagePath) && System.IO.File.Exists(SessionContext.CurrentUserImagePath))
                        {
                            try
                            {
                                pictureBox4.Image = Image.FromFile(SessionContext.CurrentUserImagePath);
                            }
                            catch
                            {
                                pictureBox4.BackgroundImage = global::testvc.Properties.Resources.icon1;
                            }
                        }
                    }
                }
                else
                {
                    // Mostrar placeholder se nenhum usuário estiver logado
                    label6.Text = "HighspeedIV";
                    pictureBox4.BackgroundImage = global::testvc.Properties.Resources.icon1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados do usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool DeveMostrar(string conteudo, string texto)
        {
            return string.IsNullOrEmpty(texto) || conteudo.ToLower().Contains(texto);
        }

        private void Txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            string texto = txtpesquisa.Text.Trim().ToLower();

            pbgtav.Visible = DeveMostrar("gtav simulacao tiro", texto);
            lblgta.Visible = DeveMostrar("gtav simulacao tiro", texto);
            btgta.Visible = DeveMostrar("gtav simulacao tiro", texto);

            pbeafc.Visible = DeveMostrar("ea fc 26 esporte simulacao", texto);
            lbleafc.Visible = DeveMostrar("ea fc 26 esporte simulacao", texto);
            bteafc.Visible = DeveMostrar("ea fc 26 esporte simulacao", texto);

            pbmine.Visible = DeveMostrar("minecraft aventura exploracao", texto);
            lblmine.Visible = DeveMostrar("minecraft aventura exploracao", texto);
            btmine.Visible = DeveMostrar("minecraft aventura exploracao", texto);
        }

        private void ButtonNewUser_Click(object sender, EventArgs e)
        {
            // Abrir formulário para criar novo usuário
            UserForm userForm = new UserForm();
            if (userForm.ShowDialog() == DialogResult.OK)
            {
                // Após criar usuário, recarregar dados
                LoadUserData();
            }
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            // Abrir formulário de login para selecionar usuário existente
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Após selecionar usuário, recarregar dados
                LoadUserData();
            }
        }
    }
}
