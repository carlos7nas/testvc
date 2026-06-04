using System;
using System.Drawing;
using System.Windows.Forms;

namespace testvc
{
    public partial class CompraForm : Form
    {
        private readonly string nomeJogo;
        private readonly string categorias;
        private readonly string preco;
        private readonly Image imagemJogo;

        public CompraForm(string nomeJogo, string categorias, string preco, Image imagemJogo)
        {
            this.nomeJogo = nomeJogo;
            this.categorias = categorias;
            this.preco = preco;
            this.imagemJogo = imagemJogo;

            InitializeComponent();
            CarregarDadosCompra();
        }

        private void CarregarDadosCompra()
        {
            labelTituloJogo.Text = nomeJogo;
            labelCategorias.Text = categorias;
            labelPreco.Text = preco;
            pictureBoxJogo.BackgroundImage = imagemJogo;
        }

        private void ButtonComprar_Click(object sender, EventArgs e)
        {
            if (SessionContext.CurrentUserId <= 0)
            {
                MessageBox.Show(
                    "Faca login antes de comprar um jogo.",
                    "Compra",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            CompraManager.RegistrarCompra(SessionContext.CurrentUserId, nomeJogo);

            MessageBox.Show(
                "Compra de " + nomeJogo + " realizada com sucesso!",
                "Compra finalizada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
