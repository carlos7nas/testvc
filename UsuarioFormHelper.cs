using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace testvc
{
    public static class UsuarioFormHelper
    {
        /// <summary>
        /// Abre o formulário para criar um novo usuário
        /// </summary>
        public static bool AbrirNovoUsuario()
        {
            UserForm form = new UserForm();
            return form.ShowDialog() == DialogResult.OK;
        }

        /// <summary>
        /// Abre o formulário para editar um usuário existente
        /// </summary>
        public static bool AbrirEditarUsuario(int usuarioId)
        {
            UserForm form = new UserForm(usuarioId);
            return form.ShowDialog() == DialogResult.OK;
        }

        /// <summary>
        /// Carrega a lista de usuários em um DataGridView
        /// </summary>
        public static void CarregarUsuariosEmGrid(DataGridView grid)
        {
            try
            {
                List<UsuarioManager.Usuario> usuarios = UsuarioManager.ObtenerTodosUsuarios();

                grid.DataSource = null;
                grid.DataSource = ConvertirUsuariosADataTable(usuarios);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar usuários: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Converte uma lista de usuários para DataTable
        /// </summary>
        private static System.Data.DataTable ConvertirUsuariosADataTable(List<UsuarioManager.Usuario> usuarios)
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Nome", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("Telefone", typeof(string));
            dataTable.Columns.Add("CPF", typeof(string));
            dataTable.Columns.Add("Data de Criação", typeof(DateTime));

            foreach (var usuario in usuarios)
            {
                dataTable.Rows.Add(usuario.Id, usuario.Nome, usuario.Email, usuario.Telefone, usuario.CPF, usuario.DataCriacao);
            }

            return dataTable;
        }

        /// <summary>
        /// Deleta um usuário após confirmação
        /// </summary>
        public static bool DeletarUsuario(int usuarioId, string nomeUsuario)
        {
            DialogResult result = MessageBox.Show(
                $"Tem certeza que deseja deletar o usuário '{nomeUsuario}'? Esta ação não pode ser desfeita.",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool sucesso = UsuarioManager.DeletarUsuario(usuarioId);
                    if (sucesso)
                    {
                        MessageBox.Show("Usuário deletado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Erro ao deletar o usuário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return false;
        }
    }
}
