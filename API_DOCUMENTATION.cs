/*
 * ═══════════════════════════════════════════════════════════════════════════════
 * DOCUMENTAÇÃO API - SISTEMA DE GERENCIAMENTO DE USUÁRIOS
 * ═══════════════════════════════════════════════════════════════════════════════
 */

namespace testvc
{
    /*
     * ═══════════════════════════════════════════════════════════════════════════
     * CLASS: DatabaseHelper
     * ═══════════════════════════════════════════════════════════════════════════
     * 
     * Descrição: Classe estática que fornece acesso ao banco de dados SQL Server
     * Localização: DatabaseHelper.cs
     * 
     * MÉTODOS:
     * ───────────────────────────────────────────────────────────────────────────
     * 
     * 1. ExecuteQuery(string query, SqlParameter[] parameters = null)
     *    Tipo de retorno: DataTable
     *    Descrição: Executa uma consulta SELECT e retorna os resultados em DataTable
     *    Parâmetros:
     *      - query: Comando SQL SELECT
     *      - parameters: Array opcional de SqlParameter para consultas parametrizadas
     *    Exceção: Exception com mensagem descritiva
     *    Exemplo:
     *      string query = "SELECT * FROM Usuario WHERE id_usuario = @id";
     *      SqlParameter[] parameters = { new SqlParameter("@id", 1) };
     *      DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
     * 
     * 
     * 2. ExecuteNonQuery(string query, SqlParameter[] parameters = null)
     *    Tipo de retorno: int (número de linhas afetadas)
     *    Descrição: Executa INSERT, UPDATE ou DELETE
     *    Parâmetros:
     *      - query: Comando SQL INSERT, UPDATE ou DELETE
     *      - parameters: Array opcional de SqlParameter
     *    Exceção: Exception com mensagem descritiva
     *    Exemplo:
     *      string query = "DELETE FROM Usuario WHERE id_usuario = @id";
     *      SqlParameter[] parameters = { new SqlParameter("@id", 1) };
     *      int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
     * 
     * 
     * 3. ExecuteScalar(string query, SqlParameter[] parameters = null)
     *    Tipo de retorno: object (valor único)
     *    Descrição: Executa uma consulta que retorna um único valor (por exemplo, COUNT)
     *    Parâmetros:
     *      - query: Comando SQL que retorna um valor
     *      - parameters: Array opcional de SqlParameter
     *    Exceção: Exception com mensagem descritiva
     *    Exemplo:
     *      string query = "SELECT COUNT(*) FROM Usuario";
     *      object count = DatabaseHelper.ExecuteScalar(query);
     * 
     * 
     * 4. TestConnection()
     *    Tipo de retorno: bool
     *    Descrição: Testa se a conexão com o banco de dados está funcionando
     *    Parâmetros: Nenhum
     *    Retorna: true se conectado, false caso contrário
     *    Exemplo:
     *      if (DatabaseHelper.TestConnection())
     *          MessageBox.Show("Conectado!");
     * 
     */

    /*
     * ═══════════════════════════════════════════════════════════════════════════
     * CLASS: UsuarioManager
     * ═══════════════════════════════════════════════════════════════════════════
     * 
     * Descrição: Gerencia operações CRUD de usuários
     * Localização: UsuarioManager.cs
     * Dependência: DatabaseHelper
     * 
     * CLASSE INTERNA: Usuario
     * ───────────────────────────────────────────────────────────────────────────
     * Propriedades:
     *   - int Id { get; set; }
     *   - string Nome { get; set; }
     *   - string Email { get; set; }
     *   - string SenhaHash { get; set; }
     *   - string Endereco { get; set; }
     *   - string Bairro { get; set; }
     *   - string Cidade { get; set; }
     *   - string CEP { get; set; }
     *   - string Telefone { get; set; }
     *   - string CPF { get; set; }
     *   - DateTime DataCriacao { get; set; }
     * 
     * 
     * MÉTODOS ESTÁTICOS:
     * ───────────────────────────────────────────────────────────────────────────
     * 
     * 1. SalvarUsuario(string nome, string email, string telefone, string endereco,
     *                  string cpf, string cidade, string cep)
     *    Tipo de retorno: int (ID do novo usuário)
     *    Descrição: Cria novo usuário no banco de dados
     *    Validações:
     *      - Email deve ser único
     *      - Email é obrigatório
     *      - Nome é obrigatório
     *    Parâmetros:
     *      - nome: Nome do usuário
     *      - email: Email único do usuário
     *      - telefone: Telefone (opcional)
     *      - endereco: Endereço residencial (opcional)
     *      - cpf: CPF do usuário (opcional)
     *      - cidade: Cidade (opcional)
     *      - cep: CEP (opcional)
     *    Retorna: ID do novo usuário ou -1 se falhar
     *    Exceção: Exception com descrição do erro
     *    Exemplo:
     *      try {
     *          int novoId = UsuarioManager.SalvarUsuario(
     *              "João Silva", "joao@email.com", "(11) 98765-4321",
     *              "Rua A, 123", "123.456.789-00", "São Paulo", "01000-000"
     *          );
     *          MessageBox.Show("ID: " + novoId);
     *      } catch (Exception ex) {
     *          MessageBox.Show("Erro: " + ex.Message);
     *      }
     * 
     * 
     * 2. AtualizarUsuario(int idUsuario, string nome, string email, string telefone,
     *                     string endereco, string cpf, string cidade, string cep)
     *    Tipo de retorno: bool
     *    Descrição: Atualiza dados de um usuário existente
     *    Validações:
     *      - Email não pode ser duplicado (em outro usuário)
     *      - Usuário deve existir
     *    Parâmetros: Idênticos a SalvarUsuario, com adição de idUsuario
     *    Retorna: true se atualizado com sucesso, false caso contrário
     *    Exceção: Exception com descrição do erro
     *    Exemplo:
     *      bool sucesso = UsuarioManager.AtualizarUsuario(
     *          1, "João Silva Novo", "joao.novo@email.com", ...
     *      );
     * 
     * 
     * 3. ObtenerUsuario(int idUsuario)
     *    Tipo de retorno: Usuario ou null
     *    Descrição: Recupera dados de um usuário específico
     *    Parâmetros:
     *      - idUsuario: ID do usuário
     *    Retorna: Objeto Usuario ou null se não encontrado
     *    Exceção: Exception com descrição do erro
     *    Exemplo:
     *      var usuario = UsuarioManager.ObtenerUsuario(1);
     *      if (usuario != null)
     *          MessageBox.Show("Nome: " + usuario.Nome);
     * 
     * 
     * 4. ObtenerTodosUsuarios()
     *    Tipo de retorno: List<Usuario>
     *    Descrição: Retorna lista de todos os usuários ordenada por nome
     *    Parâmetros: Nenhum
     *    Retorna: Lista de usuários
     *    Exceção: Exception com descrição do erro
     *    Exemplo:
     *      var usuarios = UsuarioManager.ObtenerTodosUsuarios();
     *      foreach (var u in usuarios)
     *          MessageBox.Show(u.Nome);
     * 
     * 
     * 5. DeletarUsuario(int idUsuario)
     *    Tipo de retorno: bool
     *    Descrição: Deleta um usuário e suas compras associadas
     *    Parâmetros:
     *      - idUsuario: ID do usuário
     *    Retorna: true se deletado com sucesso, false caso contrário
     *    Exceção: Exception com descrição do erro
     *    Nota: Também deleta todas as compras do usuário (integridade referencial)
     *    Exemplo:
     *      if (UsuarioManager.DeletarUsuario(1))
     *          MessageBox.Show("Deletado!");
     * 
     */

    /*
     * ═══════════════════════════════════════════════════════════════════════════
     * CLASS: UsuarioFormHelper
     * ═══════════════════════════════════════════════════════════════════════════
     * 
     * Descrição: Classe helper com métodos de conveniência para UI
     * Localização: UsuarioFormHelper.cs
     * Dependência: UsuarioManager, UserForm
     * 
     * MÉTODOS ESTÁTICOS:
     * ───────────────────────────────────────────────────────────────────────────
     * 
     * 1. AbrirNovoUsuario()
     *    Tipo de retorno: bool
     *    Descrição: Abre formulário modal para criar novo usuário
     *    Parâmetros: Nenhum
     *    Retorna: true se usuário foi criado, false se cancelou
     *    Exemplo:
     *      if (UsuarioFormHelper.AbrirNovoUsuario())
     *          MessageBox.Show("Novo usuário criado!");
     * 
     * 
     * 2. AbrirEditarUsuario(int usuarioId)
     *    Tipo de retorno: bool
     *    Descrição: Abre formulário modal para editar usuário existente
     *    Parâmetros:
     *      - usuarioId: ID do usuário a editar
     *    Retorna: true se usuário foi atualizado, false se cancelou
     *    Exemplo:
     *      if (UsuarioFormHelper.AbrirEditarUsuario(1))
     *          MessageBox.Show("Usuário atualizado!");
     * 
     * 
     * 3. CarregarUsuariosEmGrid(DataGridView grid)
     *    Tipo de retorno: void
     *    Descrição: Carrega lista de usuários em um DataGridView
     *    Parâmetros:
     *      - grid: Controle DataGridView onde carregar os dados
     *    Colunas do grid:
     *      - ID, Nome, Email, Telefone, CPF, Data de Criação
     *    Exceção: MessageBox com erro se houver falha
     *    Exemplo:
     *      UsuarioFormHelper.CarregarUsuariosEmGrid(dataGridView1);
     * 
     * 
     * 4. DeletarUsuario(int usuarioId, string nomeUsuario)
     *    Tipo de retorno: bool
     *    Descrição: Deleta usuário após confirmação do usuário
     *    Parâmetros:
     *      - usuarioId: ID do usuário a deletar
     *      - nomeUsuario: Nome do usuário (para exibir em confirmação)
     *    Retorna: true se deletado com sucesso, false caso contrário
     *    Comportamento: Exibe diálogo de confirmação antes de deletar
     *    Exemplo:
     *      if (UsuarioFormHelper.DeletarUsuario(1, "João Silva"))
     *          MessageBox.Show("Deletado com sucesso!");
     * 
     */

    /*
     * ═══════════════════════════════════════════════════════════════════════════
     * CLASS: UserForm
     * ═══════════════════════════════════════════════════════════════════════════
     * 
     * Descrição: Formulário Windows Forms para criar/editar usuários
     * Localização: UserForm.cs, UserForm.Designer.cs
     * Base: Form
     * 
     * MODOS:
     * ───────────────────────────────────────────────────────────────────────────
     * 
     * Modo Novo Usuário:
     *   new UserForm()
     *   - Formulário vazio
     *   - Título: "Novo Usuário"
     *   - Cria novo registro no banco ao salvar
     * 
     * Modo Edição:
     *   new UserForm(usuarioId)
     *   - Carrega dados do usuário
     *   - Título: "Editar Usuário"
     *   - Atualiza registro existente ao salvar
     * 
     * 
     * CONSTRUTORES:
     * ───────────────────────────────────────────────────────────────────────────
     * 
     * 1. UserForm()
     *    Descrição: Cria novo formulário em modo "novo usuário"
     * 
     * 2. UserForm(int usuarioId)
     *    Descrição: Cria novo formulário em modo "editar usuário"
     *    Parâmetro: usuarioId - ID do usuário a editar
     * 
     * 
     * CONTROLES:
     * ───────────────────────────────────────────────────────────────────────────
     * 
     * Entrada de Dados:
     *   - textBoxName: Nome do usuário
     *   - textBoxEmail: Email do usuário
     *   - textBoxPhone: Telefone
     *   - textBoxAddress: Endereço
     *   - textBoxCPF: CPF
     *   - textBoxDateOfBirth: Data de Nascimento
     *   - comboBoxGender: Gênero (Masculino, Feminino, Outro, Prefiro não informar)
     * 
     * Foto:
     *   - pictureBoxProfile: Exibe foto de perfil (180x180)
     *   - buttonUploadPhoto: Abre diálogo para selecionar foto
     *   - labelPhotoStatus: Status da foto (selecionada/erro)
     * 
     * Ações:
     *   - buttonSave: Valida e salva os dados
     *   - buttonCancel: Fecha o formulário sem salvar
     * 
     * 
     * EVENTOS:
     * ───────────────────────────────────────────────────────────────────────────
     * 
     * UserForm_Load:
     *   - Testa conexão com banco de dados
     *   - Carrega dados se em modo edição
     *   - Define título e descrição
     * 
     * ButtonUploadPhoto_Click:
     *   - Abre diálogo de seleção de arquivo
     *   - Filtro: Imagens (.jpg, .png, .gif, .bmp)
     *   - Exibe preview da imagem
     * 
     * ButtonSave_Click:
     *   - Valida campos obrigatórios
     *   - Salva ou atualiza usuário
     *   - Exibe mensagens de sucesso/erro
     * 
     * ButtonCancel_Click:
     *   - Fecha o formulário
     * 
     */
}

/*
 * ═══════════════════════════════════════════════════════════════════════════════
 * FLUXO DE DADOS - NOVO USUÁRIO
 * ═══════════════════════════════════════════════════════════════════════════════
 * 
 * 1. Usuário clica "Novo Usuário"
 *    ↓
 * 2. UsuarioFormHelper.AbrirNovoUsuario()
 *    ↓
 * 3. new UserForm() - Formulário em branco
 *    ↓
 * 4. Usuário preenche campos e clica "Salvar"
 *    ↓
 * 5. ValidateFields() - Verifica campos obrigatórios
 *    ↓
 * 6. UsuarioManager.SalvarUsuario() - Insere no BD
 *    ↓
 * 7. Mensagem de sucesso com ID do novo usuário
 *    ↓
 * 8. Formulário fecha com DialogResult.OK
 * 
 */

/*
 * ═══════════════════════════════════════════════════════════════════════════════
 * FLUXO DE DADOS - EDITAR USUÁRIO
 * ═══════════════════════════════════════════════════════════════════════════════
 * 
 * 1. Usuário seleciona usuário e clica "Editar"
 *    ↓
 * 2. UsuarioFormHelper.AbrirEditarUsuario(usuarioId)
 *    ↓
 * 3. new UserForm(usuarioId) - Modo edição
 *    ↓
 * 4. UserForm_Load() chama LoadUserData()
 *    ↓
 * 5. UsuarioManager.ObtenerUsuario(usuarioId) - Carrega dados
 *    ↓
 * 6. TextBoxes são preenchidas com dados do usuário
 *    ↓
 * 7. Usuário edita dados e clica "Salvar"
 *    ↓
 * 8. ValidateFields() - Verifica campos
 *    ↓
 * 9. UsuarioManager.AtualizarUsuario() - Atualiza no BD
 *    ↓
 * 10. Mensagem de sucesso
 *     ↓
 * 11. Formulário fecha com DialogResult.OK
 * 
 */

/*
 * ═══════════════════════════════════════════════════════════════════════════════
 * TRATAMENTO DE ERROS
 * ═══════════════════════════════════════════════════════════════════════════════
 * 
 * Todos os métodos possuem try-catch e retornam:
 * - MessageBox com descrição do erro
 * - Exception com stack trace
 * - Tipos de erro tratados:
 *   * SqlException - Erros de banco de dados
 *   * IOException - Erros de arquivo (foto)
 *   * ArgumentException - Argumentos inválidos
 *   * General Exception - Outros erros
 * 
 */

/*
 * ═══════════════════════════════════════════════════════════════════════════════
 * CHECKLIST DE IMPLEMENTAÇÃO
 * ═══════════════════════════════════════════════════════════════════════════════
 * 
 * ✅ DatabaseHelper - Conexão com SQL Server
 * ✅ UsuarioManager - CRUD de usuários
 * ✅ UserForm - Interface gráfica
 * ✅ UsuarioFormHelper - Métodos helpers
 * ✅ Validação de dados
 * ✅ Upload de foto
 * ✅ Modo novo/edição
 * ✅ Tratamento de exceções
 * ✅ Documentação completa
 * ✅ Compilação bem-sucedida
 * 
 */
