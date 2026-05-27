/*
 * =====================================================================
 * GUIA DE USO - SISTEMA DE GERENCIAMENTO DE USUÁRIOS
 * =====================================================================
 * 
 * Este documento mostra exemplos práticos de como usar o sistema
 * de gerenciamento de usuários integrado com SQL Server.
 * 
 * =====================================================================
 * 1. ABRIR FORMULÁRIO PARA NOVO USUÁRIO
 * =====================================================================
 * 
 * Exemplo em um Button Click:
 * 
 *     private void btnNovoUsuario_Click(object sender, EventArgs e)
 *     {
 *         if (UsuarioFormHelper.AbrirNovoUsuario())
 *         {
 *             MessageBox.Show("Novo usuário criado com sucesso!");
 *             // Recarregar lista de usuários se necessário
 *             CarregarUsuarios();
 *         }
 *     }
 * 
 * =====================================================================
 * 2. ABRIR FORMULÁRIO PARA EDITAR USUÁRIO
 * =====================================================================
 * 
 * Exemplo:
 * 
 *     private void btnEditar_Click(object sender, EventArgs e)
 *     {
 *         if (dataGridView1.SelectedRows.Count > 0)
 *         {
 *             int usuarioId = (int)dataGridView1.SelectedRows[0].Cells["ID"].Value;
 *             if (UsuarioFormHelper.AbrirEditarUsuario(usuarioId))
 *             {
 *                 MessageBox.Show("Usuário atualizado com sucesso!");
 *                 CarregarUsuarios();
 *             }
 *         }
 *         else
 *         {
 *             MessageBox.Show("Selecione um usuário para editar.");
 *         }
 *     }
 * 
 * =====================================================================
 * 3. CARREGAR LISTA DE USUÁRIOS EM DATAGRIDVIEW
 * =====================================================================
 * 
 * Exemplo:
 * 
 *     private void CarregarUsuarios()
 *     {
 *         try
 *         {
 *             UsuarioFormHelper.CarregarUsuariosEmGrid(dataGridView1);
 *         }
 *         catch (Exception ex)
 *         {
 *             MessageBox.Show("Erro: " + ex.Message);
 *         }
 *     }
 * 
 *     private void Form1_Load(object sender, EventArgs e)
 *     {
 *         CarregarUsuarios();
 *     }
 * 
 * =====================================================================
 * 4. DELETAR USUÁRIO
 * =====================================================================
 * 
 * Exemplo:
 * 
 *     private void btnDeletar_Click(object sender, EventArgs e)
 *     {
 *         if (dataGridView1.SelectedRows.Count > 0)
 *         {
 *             int usuarioId = (int)dataGridView1.SelectedRows[0].Cells["ID"].Value;
 *             string nomeUsuario = dataGridView1.SelectedRows[0].Cells["Nome"].Value.ToString();
 *             
 *             if (UsuarioFormHelper.DeletarUsuario(usuarioId, nomeUsuario))
 *             {
 *                 CarregarUsuarios();
 *             }
 *         }
 *         else
 *         {
 *             MessageBox.Show("Selecione um usuário para deletar.");
 *         }
 *     }
 * 
 * =====================================================================
 * 5. ACESSAR DADOS DIRETAMENTE VIA USUARIOMANAGER
 * =====================================================================
 * 
 * Obter um usuário específico:
 * 
 *     UsuarioManager.Usuario usuario = UsuarioManager.ObtenerUsuario(1);
 *     if (usuario != null)
 *     {
 *         MessageBox.Show($"Nome: {usuario.Nome}, Email: {usuario.Email}");
 *     }
 * 
 * =====================================================================
 * 6. SALVAR NOVO USUÁRIO PROGRAMATICAMENTE
 * =====================================================================
 * 
 *     try
 *     {
 *         int novoId = UsuarioManager.SalvarUsuario(
 *             nome: "João Silva",
 *             email: "joao@email.com",
 *             telefone: "(11) 98765-4321",
 *             endereco: "Rua A, 123",
 *             cpf: "123.456.789-00",
 *             cidade: "São Paulo",
 *             cep: "01000-000"
 *         );
 *         MessageBox.Show($"Usuário criado com ID: {novoId}");
 *     }
 *     catch (Exception ex)
 *     {
 *         MessageBox.Show("Erro: " + ex.Message);
 *     }
 * 
 * =====================================================================
 * 7. ATUALIZAR USUÁRIO PROGRAMATICAMENTE
 * =====================================================================
 * 
 *     try
 *     {
 *         bool sucesso = UsuarioManager.AtualizarUsuario(
 *             idUsuario: 1,
 *             nome: "João Silva Atualizado",
 *             email: "joao.novo@email.com",
 *             telefone: "(11) 99999-9999",
 *             endereco: "Rua B, 456",
 *             cpf: "123.456.789-00",
 *             cidade: "Rio de Janeiro",
 *             cep: "20000-000"
 *         );
 *         
 *         if (sucesso)
 *             MessageBox.Show("Usuário atualizado com sucesso!");
 *     }
 *     catch (Exception ex)
 *     {
 *         MessageBox.Show("Erro: " + ex.Message);
 *     }
 * 
 * =====================================================================
 * 8. TESTAR CONEXÃO COM BANCO DE DADOS
 * =====================================================================
 * 
 *     if (DatabaseHelper.TestConnection())
 *     {
 *         MessageBox.Show("Conexão com banco de dados estabelecida!");
 *     }
 *     else
 *     {
 *         MessageBox.Show("Erro ao conectar ao banco de dados.");
 *     }
 * 
 * =====================================================================
 * ESTRUTURA DO BANCO DE DADOS
 * =====================================================================
 * 
 * Tabela Usuario:
 * - id_usuario (INT, IDENTITY)
 * - nome (NVARCHAR(100))
 * - email (NVARCHAR(150), UNIQUE)
 * - senha_hash (NVARCHAR(255))
 * - data_criacao (DATETIME, DEFAULT GETDATE())
 * - endereco (NVARCHAR(150))
 * - bairro (NVARCHAR(100))
 * - cidade (NVARCHAR(100))
 * - cep (NVARCHAR(10))
 * - telefone (NVARCHAR(15)) - Campo adicional não mencionado, adicionado para compatibilidade
 * - cpf (NVARCHAR(20)) - Campo adicional não mencionado, adicionado para compatibilidade
 * 
 * =====================================================================
 * REQUISITOS
 * =====================================================================
 * 
 * - SQL Server com banco de dados "mobgames_store" criado
 * - Tabela "Usuario" criada conforme o schema fornecido
 * - Permissão para conectar com Integrated Security ou credenciais SQL
 * - .NET Framework 4.8
 * 
 * =====================================================================
 */
