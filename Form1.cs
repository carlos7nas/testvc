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
            if (SessionContext.CurrentUserId <= 0)
            {
                MessageBox.Show("Nenhum usuario logado.", "Perfil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            UserForm userForm = new UserForm(SessionContext.CurrentUserId);
            if (userForm.ShowDialog() == DialogResult.OK)
            {
                LoadUserData();
            }
        }

        private void AbrirCompra(string nomeJogo, string categorias, string preco, Image imagemJogo)
        {
            CompraForm compraForm = new CompraForm(nomeJogo, categorias, preco, imagemJogo);
            compraForm.ShowDialog();
        }

        private void Btgta_Click(object sender, EventArgs e)
        {
            AbrirCompra("GTA VI", "Simulacao, Tiro", "R$ 349,90", pbgtav.BackgroundImage);
        }

        private void Bteafc_Click(object sender, EventArgs e)
        {
            AbrirCompra("EA FC 26", "Esporte, Simulacao", "R$ 299,90", pbeafc.BackgroundImage);
        }

        private void Btmine_Click(object sender, EventArgs e)
        {
            AbrirCompra("MINECRAFT", "Aventura, Exploracao", "R$ 99,90", pbmine.BackgroundImage);
        }
    }
}
