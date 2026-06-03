using System;
using System.Windows.Forms;

namespace testvc
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                AbrirTelaJogos();
            }
        }

        private void ButtonCadastro_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm(false);
            if (userForm.ShowDialog() == DialogResult.OK)
            {
                AbrirTelaJogos();
            }
        }

        private void ButtonSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AbrirTelaJogos()
        {
            Hide();

            Form1 formJogos = new Form1();
            formJogos.ShowDialog();

            Close();
        }
    }
}
