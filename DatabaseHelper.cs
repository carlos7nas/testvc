using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace testvc
{
    public static class DatabaseHelper
    {
        // String de conexão padrão para o banco de dados mobgames_store
        private static readonly string ConnectionString = "Server=.\\SQLEXPRESS;Database=mobgames_store;Integrated Security=true;";

        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao executar consulta no banco de dados: " + ex.Message);
            }

            return dataTable;
        }

        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao executar comando no banco de dados: " + ex.Message);
            }

            return rowsAffected;
        }

        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        return command.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao executar escalar no banco de dados: " + ex.Message);
            }
        }

        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
