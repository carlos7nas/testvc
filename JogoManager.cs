using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace testvc
{
    public static class JogoManager
    {
        public class Jogo
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Categoria { get; set; }
            public decimal Preco { get; set; }
        }

        public static void GarantirJogosCadastrados()
        {
            GarantirTabelaJogos();

            InserirJogoSeNaoExistir("GTA VI", "Simulacao, Tiro", 349.90m);
            InserirJogoSeNaoExistir("EA FC 26", "Esporte, Simulacao", 299.90m);
            InserirJogoSeNaoExistir("MINECRAFT", "Aventura, Exploracao", 99.90m);
            InserirJogoSeNaoExistir("RED DEAD REDEMPTION 2", "Acao, Aventura", 249.90m);
            InserirJogoSeNaoExistir("FORZA HORIZON 5", "Corrida, Mundo Aberto", 199.90m);
            InserirJogoSeNaoExistir("THE LAST OF US PART I", "Acao, Sobrevivencia", 249.90m);
            InserirJogoSeNaoExistir("HOGWARTS LEGACY", "RPG, Aventura", 229.90m);
            InserirJogoSeNaoExistir("CYBERPUNK 2077", "RPG, Mundo Aberto", 199.90m);
            InserirJogoSeNaoExistir("GOD OF WAR", "Acao, Aventura", 199.90m);
            InserirJogoSeNaoExistir("ELDEN RING", "RPG, Acao", 279.90m);
        }

        public static List<Jogo> ListarJogosAtivos()
        {
            GarantirTabelaJogos();

            string query = @"
SELECT id_jogo, nome, categoria, preco
FROM Jogo
WHERE ativo = 1
ORDER BY nome";

            DataTable tabela = DatabaseHelper.ExecuteQuery(query);
            List<Jogo> jogos = new List<Jogo>();

            foreach (DataRow linha in tabela.Rows)
            {
                jogos.Add(new Jogo
                {
                    Id = (int)linha["id_jogo"],
                    Nome = linha["nome"].ToString(),
                    Categoria = linha["categoria"].ToString(),
                    Preco = (decimal)linha["preco"]
                });
            }

            return jogos;
        }

        public static bool InserirJogo(string nome, string categoria, decimal preco)
        {
            string query = @"
INSERT INTO Jogo (nome, categoria, preco, ativo)
VALUES (@nome, @categoria, @preco, 1)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@nome", nome),
                new SqlParameter("@categoria", categoria),
                new SqlParameter("@preco", preco)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public static bool AtualizarJogo(int idJogo, string nome, string categoria, decimal preco)
        {
            string nomeAntigo = ObterNomeJogo(idJogo);

            string query = @"
UPDATE Jogo
SET nome = @nome, categoria = @categoria, preco = @preco
WHERE id_jogo = @idJogo";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@idJogo", idJogo),
                new SqlParameter("@nome", nome),
                new SqlParameter("@categoria", categoria),
                new SqlParameter("@preco", preco)
            };

            bool atualizado = DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;

            if (atualizado && !string.IsNullOrEmpty(nomeAntigo) && nomeAntigo != nome)
            {
                AtualizarNomeJogoCompras(nomeAntigo, nome);
            }

            return atualizado;
        }

        public static bool ExcluirJogo(int idJogo, string nomeJogo)
        {
            CompraManager.GarantirTabelaCompras();

            string queryDeleteCompras = "DELETE FROM Compra WHERE nome_jogo = @nomeJogo";
            SqlParameter[] compraParameters = new SqlParameter[]
            {
                new SqlParameter("@nomeJogo", nomeJogo)
            };
            DatabaseHelper.ExecuteNonQuery(queryDeleteCompras, compraParameters);

            string queryDeleteJogo = "DELETE FROM Jogo WHERE id_jogo = @idJogo";
            SqlParameter[] jogoParameters = new SqlParameter[]
            {
                new SqlParameter("@idJogo", idJogo)
            };

            return DatabaseHelper.ExecuteNonQuery(queryDeleteJogo, jogoParameters) > 0;
        }

        private static string ObterNomeJogo(int idJogo)
        {
            string query = "SELECT nome FROM Jogo WHERE id_jogo = @idJogo";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@idJogo", idJogo)
            };

            object result = DatabaseHelper.ExecuteScalar(query, parameters);
            return result == null ? "" : result.ToString();
        }

        private static void AtualizarNomeJogoCompras(string nomeAntigo, string nomeNovo)
        {
            CompraManager.GarantirTabelaCompras();

            string query = "UPDATE Compra SET nome_jogo = @nomeNovo WHERE nome_jogo = @nomeAntigo";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@nomeNovo", nomeNovo),
                new SqlParameter("@nomeAntigo", nomeAntigo)
            };

            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        private static void GarantirTabelaJogos()
        {
            string query = @"
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Jogo' AND xtype = 'U')
BEGIN
    CREATE TABLE Jogo (
        id_jogo INT IDENTITY(1,1) PRIMARY KEY,
        nome NVARCHAR(100) NOT NULL UNIQUE,
        categoria NVARCHAR(150) NOT NULL,
        preco DECIMAL(10,2) NOT NULL,
        ativo BIT NOT NULL DEFAULT 1,
        data_cadastro DATETIME DEFAULT GETDATE()
    )
END";

            DatabaseHelper.ExecuteNonQuery(query);
        }

        private static void InserirJogoSeNaoExistir(string nome, string categoria, decimal preco)
        {
            string query = @"
IF NOT EXISTS (SELECT 1 FROM Jogo WHERE nome = @nome)
BEGIN
    INSERT INTO Jogo (nome, categoria, preco)
    VALUES (@nome, @categoria, @preco)
END";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@nome", nome),
                new SqlParameter("@categoria", categoria),
                new SqlParameter("@preco", preco)
            };

            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }
    }
}
