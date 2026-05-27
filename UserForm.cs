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
    public partial class UserForm : Form
    {
        private string selectedImagePath = string.Empty;
        private int usuarioId = 0;
        private bool isEditMode = false;
        private bool isMainForm = false;  // Flag para indicar se é a tela principal

        public UserForm()
        {
            InitializeComponent();
            this.isMainForm = true;  // Modo tela principal
        }

        public UserForm(int usuarioId) : this()
        {
            this.usuarioId = usuarioId;
            this.isEditMode = true;
            this.isMainForm = false;  // Modo edição (formulário modal)
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            // Teste de conexão com banco de dados
            if (!DatabaseHelper.TestConnection())
            {
                MessageBox.Show("Falha ao conectar ao banco de dados. Verifique a string de conexão.", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isMainForm)
            {
                // Tela principal - modo listagem
                this.Text = "Gerenciador de Usuários";
                labelSubtitle.Text = "Selecione um usuário para gerenciar";
                buttonSave.Text = "Novo Usuário";
                buttonCancel.Text = "Sair";

                // Carregar lista de usuários se houver DataGridView
                ClearForm();
            }
            else if (isEditMode && usuarioId > 0)
            {
                // Modo edição
                LoadUserData();
                this.Text = "Editar Usuário";
                labelSubtitle.Text = "Edite os dados do usuário";
            }
            else
            {
                // Modo novo usuário
                this.Text = "Novo Usuário";
                labelSubtitle.Text = "Preencha os dados do novo usuário";
            }
        }

        private void LoadUserData()
        {
            try
            {
                UsuarioManager.Usuario usuario = UsuarioManager.ObtenerUsuario(usuarioId);
                if (usuario != null)
                {
                    textBoxName.Text = usuario.Nome;
                    textBoxEmail.Text = usuario.Email;
                    textBoxPhone.Text = usuario.Telefone;
                    textBoxAddress.Text = usuario.Endereco;
                    textBoxCPF.Text = usuario.CPF;
                }
                else
                {
                    MessageBox.Show("Usuário não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados do usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonUploadPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos os arquivos|*.*";
                openFileDialog.Title = "Selecione uma foto de perfil";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName;
                    try
                    {
                        pictureBoxProfile.Image = Image.FromFile(selectedImagePath);
                        labelPhotoStatus.Text = "Foto selecionada ✓";
                        labelPhotoStatus.ForeColor = Color.LimeGreen;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao carregar a imagem: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        labelPhotoStatus.Text = "Erro ao carregar foto";
                        labelPhotoStatus.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            // Se for tela principal, "Salvar" = "Novo Usuário"
            if (isMainForm)
            {
                UsuarioFormHelper.AbrirNovoUsuario();
                ClearForm();
                return;
            }

            // Modo edição/novo
            if (ValidateFields())
            {
                SaveUserData();
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Por favor, preencha o campo Nome.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show("Por favor, preencha o campo Email.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEmail.Focus();
                return false;
            }

            // Validação básica de email
            if (!textBoxEmail.Text.Contains("@"))
            {
                MessageBox.Show("Por favor, insira um email válido.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEmail.Focus();
                return false;
            }

            return true;
        }

        private void SaveUserData()
        {
            try
            {
                string nome = textBoxName.Text.Trim();
                string email = textBoxEmail.Text.Trim();
                string telefone = textBoxPhone.Text.Trim();
                string endereco = textBoxAddress.Text.Trim();
                string cpf = textBoxCPF.Text.Trim();
                string dataDeNascimento = textBoxDateOfBirth.Text.Trim();
                string genero = comboBoxGender.SelectedItem?.ToString() ?? "";

                if (isEditMode && usuarioId > 0)
                {
                    // Modo edição
                    bool sucesso = UsuarioManager.AtualizarUsuario(usuarioId, nome, email, telefone, endereco, cpf, "", "");
                    if (sucesso)
                    {
                        MessageBox.Show("Usuário atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao atualizar o usuário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Modo novo usuário
                    int novoId = UsuarioManager.SalvarUsuario(nome, email, telefone, endereco, cpf, "", "");
                    if (novoId > 0)
                    {
                        MessageBox.Show($"Usuário salvo com sucesso! (ID: {novoId})", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao salvar o usuário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            if (isMainForm)
            {
                // Na tela principal, fechar = sair da aplicação
                this.Close();
            }
            else
            {
                // Em modo modal, apenas fechar
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void LabelTitle_Click(object sender, EventArgs e)
        {

        }

        private void ClearForm()
        {
            textBoxName.Clear();
            textBoxEmail.Clear();
            textBoxPhone.Clear();
            textBoxAddress.Clear();
            textBoxCPF.Clear();
            textBoxDateOfBirth.Clear();
            comboBoxGender.SelectedIndex = -1;
            pictureBoxProfile.Image = null;
            selectedImagePath = string.Empty;
            labelPhotoStatus.Text = "Nenhuma foto selecionada";
            labelPhotoStatus.ForeColor = Color.Gray;
        }
    }
}
