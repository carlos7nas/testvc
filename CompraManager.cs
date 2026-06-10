using System;
using System.Data;
using System.Data.SqlClient;

namespace testvc
{
    public static class CompraManager
    {
        public static void GarantirTabelaCompras()
        {
            string query = @"
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Compra' AND xtype = 'U')
BEGIN
    CREATE TABLE Compra (
        id_compra INT IDENTITY(1,1) PRIMARY KEY,
        id_usuario INT NOT NULL,
        nome_jogo NVARCHAR(100) NOT NULL,
        data_compra DATETIME DEFAULT GETDATE(),
        CONSTRAINT FK_Compra_Usuario FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
        CONSTRAINT UQ_Compra_Usuario_Jogo UNIQUE (id_usuario, nome_jogo)
    )
END";

            DatabaseHelper.ExecuteNonQuery(query);
        }

        public static bool UsuarioPossuiJogo(int idUsuario, string nomeJogo)
        {
            GarantirTabelaCompras();

            string query = "SELECT COUNT(*) FROM Compra WHERE id_usuario = @idUsuario AND nome_jogo = @nomeJogo";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@idUsuario", idUsuario),
                new SqlParameter("@nomeJogo", nomeJogo)
            };

            object result = DatabaseHelper.ExecuteScalar(query, parameters);
            return result != null && Convert.ToInt32(result) > 0;
        }

        public static bool RegistrarCompra(int idUsuario, string nomeJogo)
        {
            GarantirTabelaCompras();

            if (UsuarioPossuiJogo(idUsuario, nomeJogo))
            {
                return true;
            }

            string query = "INSERT INTO Compra (id_usuario, nome_jogo) VALUES (@idUsuario, @nomeJogo)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@idUsuario", idUsuario),
                new SqlParameter("@nomeJogo", nomeJogo)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public static bool RemoverCompra(int idUsuario, string nomeJogo)
        {
            GarantirTabelaCompras();

            string query = "DELETE FROM Compra WHERE id_usuario = @idUsuario AND nome_jogo = @nomeJogo";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@idUsuario", idUsuario),
                new SqlParameter("@nomeJogo", nomeJogo)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
