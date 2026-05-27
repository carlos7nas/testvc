# Sistema de Gerenciamento de Usuários - Integração com SQL Server

## 📋 Visão Geral

Este sistema implementa um completo gerenciamento de usuários integrado com SQL Server, permitindo criar, editar, visualizar e deletar usuários através de uma interface gráfica.

## 🗂️ Arquivos Criados

### 1. **DatabaseHelper.cs**
Classe estática que fornece métodos para interação com o banco de dados SQL Server:
- `ExecuteQuery()` - Executa consultas SELECT
- `ExecuteNonQuery()` - Executa INSERT, UPDATE, DELETE
- `ExecuteScalar()` - Retorna um único valor
- `TestConnection()` - Testa a conexão com o banco de dados

### 2. **UsuarioManager.cs**
Classe que gerencia operações com usuários:
- `SalvarUsuario()` - Cria novo usuário no banco de dados
- `AtualizarUsuario()` - Atualiza dados de usuário existente
- `ObtenerUsuario()` - Recupera dados de um usuário específico
- `ObtenerTodosUsuarios()` - Lista todos os usuários
- `DeletarUsuario()` - Remove um usuário e suas compras associadas
- Classe interna `Usuario` - Representa um usuário com seus dados

### 3. **UserForm.cs e UserForm.Designer.cs**
Formulário Windows Forms para:
- ✏️ Criar novos usuários
- 📝 Editar usuários existentes
- 📷 Upload de foto de perfil
- ✅ Validação de dados
- 💾 Salvar dados no banco de dados

### 4. **UsuarioFormHelper.cs**
Classe helper com métodos de conveniência:
- `AbrirNovoUsuario()` - Abre formulário para novo usuário
- `AbrirEditarUsuario()` - Abre formulário para editar usuário
- `CarregarUsuariosEmGrid()` - Carrega usuários em DataGridView
- `DeletarUsuario()` - Deleta usuário com confirmação

### 5. **App.config**
Arquivo de configuração com string de conexão:
```xml
<connectionStrings>
	<add name="DefaultConnection" 
		 connectionString="Server=.\SQLEXPRESS;Database=mobgames_store;Integrated Security=true;" 
		 providerName="System.Data.SqlClient" />
</connectionStrings>
```

## 📊 Campos do Usuário

| Campo | Tipo | Descrição |
|-------|------|-----------|
| id_usuario | INT | ID único (auto-incremento) |
| nome | NVARCHAR(100) | Nome completo do usuário |
| email | NVARCHAR(150) | Email único |
| telefone | NVARCHAR(15) | Telefone de contato |
| cpf | NVARCHAR(20) | CPF do usuário |
| endereco | NVARCHAR(150) | Endereço residencial |
| cidade | NVARCHAR(100) | Cidade |
| cep | NVARCHAR(10) | CEP |
| bairro | NVARCHAR(100) | Bairro |
| senha_hash | NVARCHAR(255) | Hash da senha |
| data_criacao | DATETIME | Data de criação |

## 🚀 Como Usar

### Abrir Formulário de Novo Usuário
```csharp
if (UsuarioFormHelper.AbrirNovoUsuario())
{
	MessageBox.Show("Usuário criado com sucesso!");
}
```

### Abrir Formulário de Edição
```csharp
if (UsuarioFormHelper.AbrirEditarUsuario(usuarioId))
{
	MessageBox.Show("Usuário atualizado com sucesso!");
}
```

### Carregar Usuários em DataGridView
```csharp
UsuarioFormHelper.CarregarUsuariosEmGrid(dataGridView1);
```

### Deletar Usuário
```csharp
if (UsuarioFormHelper.DeletarUsuario(usuarioId, nomeUsuario))
{
	// Atualizar lista
}
```

### Acessar Dados Diretamente
```csharp
UsuarioManager.Usuario usuario = UsuarioManager.ObtenerUsuario(1);
List<UsuarioManager.Usuario> todos = UsuarioManager.ObtenerTodosUsuarios();
```

## 🔒 Validações Implementadas

- ✅ Email obrigatório e único
- ✅ Nome obrigatório
- ✅ Validação de formato de email
- ✅ Verificação de email duplicado
- ✅ Tratamento de exceções SQL

## 🎨 Interface Gráfica

### Campos do Formulário
- 📝 Nome (TextBox)
- 📧 Email (TextBox)
- 📞 Telefone (TextBox)
- 🏠 Endereço (TextBox)
- 🆔 CPF (TextBox)
- 📅 Data de Nascimento (TextBox)
- 👥 Gênero (ComboBox)
- 📷 Foto de Perfil (PictureBox com upload)

### Botões
- 💾 Salvar - Valida e salva dados
- ❌ Cancelar - Fecha o formulário
- 📷 Selecionar Foto - Abre diálogo de seleção de imagem

### Design Visual
- Tema: DarkSlateGray
- Fontes: Palatino Linotype (títulos), Microsoft Sans Serif (campos)
- Dimensões: 750x650 pixels
- Cores: Branco sobre escuro

## ⚙️ Configurações de Conexão

**String de Conexão Padrão:**
```
Server=.\SQLEXPRESS;Database=mobgames_store;Integrated Security=true;
```

Para alterar o servidor ou banco de dados, edite em `DatabaseHelper.cs`:
```csharp
private static readonly string ConnectionString = "seu_servidor;seu_banco;...";
```

## 📦 Dependências

- System.Data.SqlClient
- System.Windows.Forms
- System.Drawing
- System.Configuration (para futuros recursos)

## 🧪 Testes

Para testar a conexão:
```csharp
if (DatabaseHelper.TestConnection())
{
	MessageBox.Show("Conexão OK!");
}
```

## 🐛 Tratamento de Erros

Todas as operações possuem try-catch e retornam mensagens de erro detalhadas ao usuário via MessageBox.

## 📝 Exemplo Completo

```csharp
// Criar novo usuário
int novoId = UsuarioManager.SalvarUsuario(
	nome: "Lucas Silva",
	email: "lucas@email.com",
	telefone: "(11) 98765-4321",
	endereco: "Rua Principal, 123",
	cpf: "123.456.789-00",
	cidade: "São Paulo",
	cep: "01000-000"
);

// Recuperar usuário
var usuario = UsuarioManager.ObtenerUsuario(novoId);

// Atualizar usuário
UsuarioManager.AtualizarUsuario(
	novoId,
	"Lucas Silva Atualizado",
	"lucas.novo@email.com",
	"(11) 99999-9999",
	"Rua Nova, 456",
	"123.456.789-00",
	"Rio de Janeiro",
	"20000-000"
);

// Deletar usuário
UsuarioManager.DeletarUsuario(novoId);
```

## 🔗 Integração com Form1

Você pode adicionar botões em Form1 para abrir o gerenciador de usuários:

```csharp
private void btnGerenciarUsuarios_Click(object sender, EventArgs e)
{
	UsuarioFormHelper.AbrirNovoUsuario();
}
```

## 📌 Notas Importantes

1. O banco de dados `mobgames_store` deve estar criado e acessível
2. Usar Integrated Security requer autenticação Windows
3. Fotos de perfil são armazenadas localmente (caminho guardado no formulário)
4. Emails devem ser únicos no banco de dados
5. Ao deletar um usuário, suas compras também são deletadas (integridade referencial)

## ✅ Status

✅ Compilação bem-sucedida  
✅ Validação de dados implementada  
✅ Integração com SQL Server  
✅ Interface gráfica funcional  
✅ Tratamento de erros  

---

**Versão:** 1.0  
**Data:** 2024  
**Framework:** .NET Framework 4.8
