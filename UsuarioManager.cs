using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace testvc
{
    public class UsuarioManager
    {
        public class Usuario
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
            public string SenhaHash { get; set; }
            public string Endereco { get; set; }
            public string Bairro { get; set; }
            public string Cidade { get; set; }
            public string CEP { get; set; }
            public string Telefone { get; set; }
            public string CPF { get; set; }
            public DateTime DataCriacao { get; set; }
            public bool IsAdmin { get; set; }
        }

        public static void GarantirContaAdmin()
        {
            GarantirColunaAdmin();

            string senhaHash = GerarHashPadrao();
            string query = @"
IF NOT EXISTS (SELECT 1 FROM Usuario WHERE email = @email)
BEGIN
    INSERT INTO Usuario (nome, email, senha_hash, endereco, bairro, cidade, cep, telefone, cpf, is_admin)
    VALUES (@nome, @email, @senhaHash, @endereco, @bairro, @cidade, @cep, @telefone, @cpf, 1)
END
ELSE
BEGIN
    UPDATE Usuario SET is_admin = 1 WHERE email = @email
END";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@nome", "Admin"),
                new SqlParameter("@email", "admin@mobgames.com"),
                new SqlParameter("@senhaHash", senhaHash),
                new SqlParameter("@endereco", ""),
                new SqlParameter("@bairro", ""),
                new SqlParameter("@cidade", ""),
                new SqlParameter("@cep", ""),
                new SqlParameter("@telefone", ""),
                new SqlParameter("@cpf", "000.000.000-00")
            };

            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        private static void GarantirColunaAdmin()
        {
            string query = @"
IF COL_LENGTH('Usuario', 'is_admin') IS NULL
BEGIN
    ALTER TABLE Usuario ADD is_admin BIT NOT NULL CONSTRAINT DF_Usuario_IsAdmin DEFAULT 0
END";

            DatabaseHelper.ExecuteNonQuery(query);
        }

        public static int SalvarUsuario(string nome, string email, string telefone, string endereco, string cpf, string cidade, string cep)
        {
            try
            {
                // Verificar se o email já existe
                string queryVerify = "SELECT COUNT(*) FROM Usuario WHERE email = @email";
                SqlParameter[] paramsVerify = { new SqlParameter("@email", email) };
                object result = DatabaseHelper.ExecuteScalar(queryVerify, paramsVerify);

                if (result != null && (int)result > 0)
                {
                    throw new Exception("Este email já está registrado no sistema.");
                }

                string senhaHash = GerarHashPadrao();

                string query = @"INSERT INTO Usuario (nome, email, senha_hash, endereco, cidade, cep, telefone, cpf) 
                               VALUES (@nome, @email, @senhaHash, @endereco, @cidade, @cep, @telefone, @cpf);
                               SELECT SCOPE_IDENTITY();";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@nome", nome),
                    new SqlParameter("@email", email),
                    new SqlParameter("@senhaHash", senhaHash),
                    new SqlParameter("@endereco", endereco ?? ""),
                    new SqlParameter("@cidade", cidade ?? ""),
                    new SqlParameter("@cep", cep ?? ""),
                    new SqlParameter("@telefone", telefone ?? ""),
                    new SqlParameter("@cpf", cpf ?? "")
                };

                object idObject = DatabaseHelper.ExecuteScalar(query, parameters);
                if (idObject != null && int.TryParse(idObject.ToString(), out int id))
                {
                    return id;
                }

                throw new Exception("Erro ao obter o ID do usuário inserido.");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar usuário: " + ex.Message);
            }
        }

        public static bool AtualizarUsuario(int idUsuario, string nome, string email, string telefone, string endereco, string cpf, string cidade, string cep)
        {
            try
            {
                // Verificar se o email está sendo usado por outro usuário
                string queryVerify = "SELECT COUNT(*) FROM Usuario WHERE email = @email AND id_usuario != @idUsuario";
                SqlParameter[] paramsVerify = new SqlParameter[]
                {
                    new SqlParameter("@email", email),
                    new SqlParameter("@idUsuario", idUsuario)
                };
                object result = DatabaseHelper.ExecuteScalar(queryVerify, paramsVerify);

                if (result != null && (int)result > 0)
                {
                    throw new Exception("Este email já está registrado para outro usuário.");
                }

                string query = @"UPDATE Usuario 
                               SET nome = @nome, email = @email, endereco = @endereco, 
                                   cidade = @cidade, cep = @cep, telefone = @telefone, cpf = @cpf
                               WHERE id_usuario = @idUsuario";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@nome", nome),
                    new SqlParameter("@email", email),
                    new SqlParameter("@endereco", endereco ?? ""),
                    new SqlParameter("@cidade", cidade ?? ""),
                    new SqlParameter("@cep", cep ?? ""),
                    new SqlParameter("@telefone", telefone ?? ""),
                    new SqlParameter("@cpf", cpf ?? ""),
                    new SqlParameter("@idUsuario", idUsuario)
                };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar usuário: " + ex.Message);
            }
        }

        public static Usuario ObtenerUsuario(int idUsuario)
        {
            try
            {
                string query = "SELECT * FROM Usuario WHERE id_usuario = @idUsuario";
                SqlParameter[] parameters = { new SqlParameter("@idUsuario", idUsuario) };

                DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    return new Usuario
                    {
                        Id = (int)row["id_usuario"],
                        Nome = row["nome"].ToString(),
                        Email = row["email"].ToString(),
                        SenhaHash = row["senha_hash"].ToString(),
                        Endereco = row["endereco"]?.ToString() ?? "",
                        Bairro = row["bairro"]?.ToString() ?? "",
                        Cidade = row["cidade"]?.ToString() ?? "",
                        CEP = row["cep"]?.ToString() ?? "",
                        Telefone = row["telefone"]?.ToString() ?? "",
                        CPF = row["cpf"]?.ToString() ?? "",
                        DataCriacao = (DateTime)row["data_criacao"],
                        IsAdmin = row.Table.Columns.Contains("is_admin") && Convert.ToBoolean(row["is_admin"])
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter usuário: " + ex.Message);
            }
        }

        public static List<Usuario> ObtenerTodosUsuarios()
        {
            try
            {
                string query = "SELECT * FROM Usuario ORDER BY nome";
                DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

                List<Usuario> usuarios = new List<Usuario>();
                foreach (DataRow row in dataTable.Rows)
                {
                    usuarios.Add(new Usuario
                    {
                        Id = (int)row["id_usuario"],
                        Nome = row["nome"].ToString(),
                        Email = row["email"].ToString(),
                        SenhaHash = row["senha_hash"].ToString(),
                        Endereco = row["endereco"]?.ToString() ?? "",
                        Bairro = row["bairro"]?.ToString() ?? "",
                        Cidade = row["cidade"]?.ToString() ?? "",
                        CEP = row["cep"]?.ToString() ?? "",
                        Telefone = row["telefone"]?.ToString() ?? "",
                        CPF = row["cpf"]?.ToString() ?? "",
                        DataCriacao = (DateTime)row["data_criacao"],
                        IsAdmin = row.Table.Columns.Contains("is_admin") && Convert.ToBoolean(row["is_admin"])
                    });
                }

                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter usuários: " + ex.Message);
            }
        }

        public static bool DeletarUsuario(int idUsuario)
        {
            try
            {
                // Primeiro, deletar as compras associadas ao usuário
                string queryDeleteCompras = "DELETE FROM Compra WHERE id_usuario = @idUsuario";
                SqlParameter[] paramsDelete = { new SqlParameter("@idUsuario", idUsuario) };
                DatabaseHelper.ExecuteNonQuery(queryDeleteCompras, paramsDelete);

                // Depois, deletar o usuário
                string query = "DELETE FROM Usuario WHERE id_usuario = @idUsuario";
                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, paramsDelete);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar usuário: " + ex.Message);
            }
        }

        private static string GerarHashPadrao()
        {
            // Gera um hash padrão para novos usuários (você pode alterar isso)
            string senhaTemporaria = "senha123";
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senhaTemporaria));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
