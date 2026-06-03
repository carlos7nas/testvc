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
    public partial class LoginForm : Form
    {
        private List<UsuarioManager.Usuario> usuariosList = new List<UsuarioManager.Usuario>();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Carregar lista de usuários do banco de dados
            CarregarUsuarios();
        }

        private void CarregarUsuarios()
        {
            try
            {
                usuariosList = UsuarioManager.ObtenerTodosUsuarios();

                if (usuariosList == null || usuariosList.Count == 0)
                {
                    MessageBox.Show("Nenhum usuário encontrado no banco de dados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }

                // Criar DataTable com os dados dos usuários
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Nome", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Telefone", typeof(string));
                dt.Columns.Add("CPF", typeof(string));

                foreach (var usuario in usuariosList)
                {
                    dt.Rows.Add(usuario.Id, usuario.Nome, usuario.Email, usuario.Telefone, usuario.CPF);
                }

                // Configurar DataGridView
                dataGridViewUsers.DataSource = dt;

                // Ajustar colunas
                dataGridViewUsers.Columns["ID"].Width = 50;
                dataGridViewUsers.Columns["Nome"].Width = 150;
                dataGridViewUsers.Columns["Email"].Width = 180;
                dataGridViewUsers.Columns["Telefone"].Width = 120;
                dataGridViewUsers.Columns["CPF"].Width = 120;

                // Selecionar primeira linha por padrão
                if (dataGridViewUsers.Rows.Count > 0)
                {
                    dataGridViewUsers.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar usuários: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewUsers.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, selecione um usuário.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obter ID do usuário selecionado
                int selectedId = Convert.ToInt32(dataGridViewUsers.SelectedRows[0].Cells["ID"].Value);

                // Carregar dados do usuário
                UsuarioManager.Usuario usuario = UsuarioManager.ObtenerUsuario(selectedId);

                if (usuario != null)
                {
                    // Atualizar SessionContext
                    SessionContext.CurrentUserId = usuario.Id;
                    SessionContext.CurrentUserName = usuario.Nome;
                    SessionContext.CurrentUserImagePath = ""; // Ajustar conforme necessário

                    MessageBox.Show($"Bem-vindo, {usuario.Nome}!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro ao carregar dados do usuário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao efetuar login: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
