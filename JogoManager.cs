using System.Data.SqlClient;

namespace testvc
{
    public static class JogoManager
    {
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
