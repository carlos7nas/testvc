using System;

namespace testvc
{
    /// <summary>
    /// Classe estática para gerenciar o contexto da sessão (usuário logado)
    /// </summary>
    public static class SessionContext
    {
        public static int CurrentUserId { get; set; } = 0;
        public static string CurrentUserName { get; set; } = string.Empty;
        public static string CurrentUserImagePath { get; set; } = string.Empty;
    }
}
