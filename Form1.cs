using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace testvc
{
    public partial class Form1 : Form
    {
        private readonly List<GameCardControls> gameCards = new List<GameCardControls>();
        private TipoFiltroPreco filtroPrecoAtual = TipoFiltroPreco.Todos;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            JogoManager.GarantirJogosCadastrados();
            LoadUserData();
            AtualizarControlesAdmin();
            CarregarJogos();
        }

        private void LoadUserData()
        {
            try
            {
                if (SessionContext.CurrentUserId > 0)
                {
                    UsuarioManager.Usuario usuario = UsuarioManager.ObtenerUsuario(SessionContext.CurrentUserId);
                    if (usuario != null)
                    {
                        label6.Text = usuario.Nome;
                        SessionContext.CurrentUserName = usuario.Nome;
                        SessionContext.CurrentUserIsAdmin = usuario.IsAdmin;

                        if (!string.IsNullOrEmpty(SessionContext.CurrentUserImagePath) && System.IO.File.Exists(SessionContext.CurrentUserImagePath))
                        {
                            try
                            {
                                pictureBox4.Image = Image.FromFile(SessionContext.CurrentUserImagePath);
                            }
                            catch
                            {
                                pictureBox4.BackgroundImage = global::testvc.Properties.Resources.icon1;
                            }
                        }
                    }
                }
                else
                {
                    label6.Text = "HighspeedIV";
                    pictureBox4.BackgroundImage = global::testvc.Properties.Resources.icon1;
                    SessionContext.CurrentUserIsAdmin = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados do usuario: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarJogos()
        {
            try
            {
                panelJogos.SuspendLayout();
                panelJogos.Controls.Clear();
                gameCards.Clear();

                List<JogoManager.Jogo> jogos = JogoManager.ListarJogosAtivos();

                foreach (JogoManager.Jogo jogo in jogos)
                {
                    GameCardControls card = CriarCardJogo(jogo);
                    gameCards.Add(card);
                    panelJogos.Controls.Add(card.Container);
                }

                if (jogos.Count == 0)
                {
                    panelJogos.Controls.Add(CriarMensagem("Nenhum jogo cadastrado no banco."));
                }

                AplicarFiltro();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar jogos do banco: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                panelJogos.ResumeLayout();
            }
        }

        private GameCardControls CriarCardJogo(JogoManager.Jogo jogo)
        {
            Panel card = new Panel
            {
                BackColor = Color.FromArgb(38, 78, 78),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 24, 24),
                Size = new Size(270, 300),
                Tag = jogo
            };

            PictureBox capa = new PictureBox
            {
                BackColor = Color.FromArgb(23, 50, 50),
                BackgroundImage = ObterImagemJogo(jogo.Nome),
                BackgroundImageLayout = ImageLayout.Stretch,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(15, 15),
                Size = new Size(238, 135),
                TabStop = false
            };

            Label nome = new Label
            {
                AutoEllipsis = true,
                Font = new Font("Palatino Linotype", 13F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(15, 161),
                Size = new Size(238, 30),
                Text = jogo.Nome
            };

            Label categoria = new Label
            {
                AutoEllipsis = true,
                Font = new Font("Palatino Linotype", 10F, FontStyle.Regular),
                ForeColor = Color.Gainsboro,
                Location = new Point(15, 194),
                Size = new Size(238, 24),
                Text = jogo.Categoria
            };

            Label preco = new Label
            {
                AutoSize = false,
                Font = new Font("Palatino Linotype", 12F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(15, 224),
                Size = new Size(105, 28),
                Text = FormatarPreco(jogo.Preco)
            };

            Button acao = new Button
            {
                BackColor = Color.White,
                Font = new Font("Palatino Linotype", 12F, FontStyle.Regular),
                ForeColor = Color.DarkSlateGray,
                Location = new Point(128, 219),
                Size = new Size(125, 40),
                Tag = jogo,
                Text = ObterTextoBotao(jogo.Nome),
                UseVisualStyleBackColor = false
            };
            acao.Click += ButtonJogo_Click;

            Button menu = new Button
            {
                BackColor = Color.FromArgb(23, 50, 50),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(221, 16),
                Size = new Size(31, 28),
                Tag = jogo,
                Text = "...",
                UseVisualStyleBackColor = false,
                Visible = SessionContext.CurrentUserId > 0
            };
            menu.FlatAppearance.BorderSize = 0;
            menu.Click += ButtonMenuJogo_Click;

            card.Controls.Add(capa);
            card.Controls.Add(menu);
            card.Controls.Add(nome);
            card.Controls.Add(categoria);
            card.Controls.Add(preco);
            card.Controls.Add(acao);
            menu.BringToFront();

            return new GameCardControls(card, capa, acao, menu);
        }

        private Control CriarMensagem(string texto)
        {
            return new Label
            {
                AutoSize = false,
                Font = new Font("Palatino Linotype", 16F, FontStyle.Regular),
                ForeColor = Color.White,
                Size = new Size(820, 60),
                Text = texto,
                TextAlign = ContentAlignment.MiddleLeft
            };
        }

        private Image ObterImagemJogo(string nomeJogo)
        {
            string nome = nomeJogo.ToUpperInvariant();

            if (nome.Contains("GTA"))
            {
                return global::testvc.Properties.Resources.gtavi;
            }

            if (nome.Contains("EA FC"))
            {
                return global::testvc.Properties.Resources.maxresdefault;
            }

            return global::testvc.Properties.Resources.icon;
        }

        private string FormatarPreco(decimal preco)
        {
            return preco.ToString("C2", new CultureInfo("pt-BR"));
        }

        private void Txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void AplicarFiltro()
        {
            string texto = txtpesquisa.Text.Trim().ToLowerInvariant();
            decimal media = CalcularMedia();
            decimal mediana = CalcularMediana();
            List<decimal> modas = CalcularModas();

            foreach (GameCardControls card in gameCards)
            {
                JogoManager.Jogo jogo = (JogoManager.Jogo)card.Container.Tag;
                string conteudo = (jogo.Nome + " " + jogo.Categoria + " " + FormatarPreco(jogo.Preco)).ToLowerInvariant();
                bool correspondePesquisa = string.IsNullOrEmpty(texto) || conteudo.Contains(texto);
                bool correspondeFiltroPreco = CorrespondeFiltroPreco(jogo, media, mediana, modas);

                card.Container.Visible = correspondePesquisa && correspondeFiltroPreco;
            }
        }

        private bool CorrespondeFiltroPreco(JogoManager.Jogo jogo, decimal media, decimal mediana, List<decimal> modas)
        {
            switch (filtroPrecoAtual)
            {
                case TipoFiltroPreco.Media:
                    return jogo.Preco >= media;
                case TipoFiltroPreco.Mediana:
                    return jogo.Preco >= mediana;
                case TipoFiltroPreco.Moda:
                    return modas.Contains(jogo.Preco);
                default:
                    return true;
            }
        }

        private decimal CalcularMedia()
        {
            if (gameCards.Count == 0)
            {
                return 0m;
            }

            return gameCards
                .Select(card => ((JogoManager.Jogo)card.Container.Tag).Preco)
                .Average();
        }

        private decimal CalcularMediana()
        {
            if (gameCards.Count == 0)
            {
                return 0m;
            }

            List<decimal> precos = gameCards
                .Select(card => ((JogoManager.Jogo)card.Container.Tag).Preco)
                .OrderBy(preco => preco)
                .ToList();

            int meio = precos.Count / 2;

            if (precos.Count % 2 == 1)
            {
                return precos[meio];
            }

            return (precos[meio - 1] + precos[meio]) / 2m;
        }

        private List<decimal> CalcularModas()
        {
            if (gameCards.Count == 0)
            {
                return new List<decimal>();
            }

            var grupos = gameCards
                .Select(card => ((JogoManager.Jogo)card.Container.Tag).Preco)
                .GroupBy(preco => preco)
                .Select(grupo => new { Preco = grupo.Key, Quantidade = grupo.Count() })
                .ToList();

            int maiorQuantidade = grupos.Max(grupo => grupo.Quantidade);
            return grupos
                .Where(grupo => grupo.Quantidade == maiorQuantidade)
                .Select(grupo => grupo.Preco)
                .ToList();
        }

        private void SelecionarFiltroPreco(TipoFiltroPreco filtro)
        {
            filtroPrecoAtual = filtro;
            AtualizarVisualFiltroPreco();
            AplicarFiltro();
        }

        private void AtualizarVisualFiltroPreco()
        {
            AtualizarBotaoFiltro(buttonFiltroTodos, filtroPrecoAtual == TipoFiltroPreco.Todos);
            AtualizarBotaoFiltro(buttonFiltroMedia, filtroPrecoAtual == TipoFiltroPreco.Media);
            AtualizarBotaoFiltro(buttonFiltroMediana, filtroPrecoAtual == TipoFiltroPreco.Mediana);
            AtualizarBotaoFiltro(buttonFiltroModa, filtroPrecoAtual == TipoFiltroPreco.Moda);
        }

        private void AtualizarBotaoFiltro(Button botao, bool selecionado)
        {
            botao.BackColor = selecionado ? Color.White : Color.FromArgb(38, 78, 78);
            botao.ForeColor = selecionado ? Color.DarkSlateGray : Color.White;
        }

        private void ButtonFiltroTodos_Click(object sender, EventArgs e)
        {
            SelecionarFiltroPreco(TipoFiltroPreco.Todos);
        }

        private void ButtonFiltroMedia_Click(object sender, EventArgs e)
        {
            SelecionarFiltroPreco(TipoFiltroPreco.Media);
        }

        private void ButtonFiltroMediana_Click(object sender, EventArgs e)
        {
            SelecionarFiltroPreco(TipoFiltroPreco.Mediana);
        }

        private void ButtonFiltroModa_Click(object sender, EventArgs e)
        {
            SelecionarFiltroPreco(TipoFiltroPreco.Moda);
        }

        private void ButtonNewUser_Click(object sender, EventArgs e)
        {
            if (SessionContext.CurrentUserId <= 0)
            {
                MessageBox.Show("Nenhum usuario logado.", "Perfil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            UserForm userForm = new UserForm(SessionContext.CurrentUserId);
            if (userForm.ShowDialog() == DialogResult.OK)
            {
                LoadUserData();
            }
        }

        private void ButtonJogo_Click(object sender, EventArgs e)
        {
            Button botao = (Button)sender;
            JogoManager.Jogo jogo = (JogoManager.Jogo)botao.Tag;

            if (JogarSeUsuarioPossuiJogo(jogo.Nome))
            {
                return;
            }

            PictureBox capa = null;
            foreach (GameCardControls card in gameCards)
            {
                if (card.Container.Tag == jogo)
                {
                    capa = card.Capa;
                    break;
                }
            }

            AbrirCompra(jogo.Nome, jogo.Categoria, FormatarPreco(jogo.Preco), capa != null ? capa.BackgroundImage : ObterImagemJogo(jogo.Nome));
        }

        private void ButtonMenuJogo_Click(object sender, EventArgs e)
        {
            Button botaoMenu = (Button)sender;
            JogoManager.Jogo jogo = (JogoManager.Jogo)botaoMenu.Tag;

            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem remover = new ToolStripMenuItem("Remover");
            remover.Enabled = UsuarioPodeRemoverJogo(jogo.Nome);
            remover.Click += delegate
            {
                RemoverJogoComprado(jogo);
            };

            menu.Items.Add(remover);

            if (SessionContext.CurrentUserIsAdmin)
            {
                menu.Items.Add(new ToolStripSeparator());

                ToolStripMenuItem alterar = new ToolStripMenuItem("Alterar infos do jogo");
                alterar.Click += delegate
                {
                    AlterarJogo(jogo);
                };
                menu.Items.Add(alterar);

                ToolStripMenuItem excluir = new ToolStripMenuItem("Excluir jogo do banco");
                excluir.Click += delegate
                {
                    ExcluirJogo(jogo);
                };
                menu.Items.Add(excluir);
            }

            menu.Show(botaoMenu, new Point(0, botaoMenu.Height));
        }

        private bool UsuarioPodeRemoverJogo(string nomeJogo)
        {
            return SessionContext.CurrentUserId > 0 && CompraManager.UsuarioPossuiJogo(SessionContext.CurrentUserId, nomeJogo);
        }

        private void RemoverJogoComprado(JogoManager.Jogo jogo)
        {
            if (!UsuarioPodeRemoverJogo(jogo.Nome))
            {
                MessageBox.Show("Esse jogo ainda nao esta comprado por este usuario.", "Remover", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult resposta = MessageBox.Show(
                "Remover " + jogo.Nome + " da sua lista de jogos comprados?",
                "Remover jogo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resposta != DialogResult.Yes)
            {
                return;
            }

            if (CompraManager.RemoverCompra(SessionContext.CurrentUserId, jogo.Nome))
            {
                AtualizarBotoesJogos();
                MessageBox.Show("Jogo removido. Agora ele voltou para a opcao Comprar.", "Remover", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ButtonAdicionarJogo_Click(object sender, EventArgs e)
        {
            if (!SessionContext.CurrentUserIsAdmin)
            {
                return;
            }

            DadosJogo dados;
            if (!ExibirEditorJogo("Adicionar jogo", null, out dados))
            {
                return;
            }

            try
            {
                JogoManager.InserirJogo(dados.Nome, dados.Categoria, dados.Preco);
                CarregarJogos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar jogo: " + ex.Message, "Admin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AlterarJogo(JogoManager.Jogo jogo)
        {
            if (!SessionContext.CurrentUserIsAdmin)
            {
                return;
            }

            DadosJogo dados;
            if (!ExibirEditorJogo("Alterar jogo", jogo, out dados))
            {
                return;
            }

            try
            {
                JogoManager.AtualizarJogo(jogo.Id, dados.Nome, dados.Categoria, dados.Preco);
                CarregarJogos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar jogo: " + ex.Message, "Admin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExcluirJogo(JogoManager.Jogo jogo)
        {
            if (!SessionContext.CurrentUserIsAdmin)
            {
                return;
            }

            DialogResult resposta = MessageBox.Show(
                "Excluir " + jogo.Nome + " do banco de dados? As compras desse jogo tambem serao removidas.",
                "Excluir jogo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resposta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                JogoManager.ExcluirJogo(jogo.Id, jogo.Nome);
                CarregarJogos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir jogo: " + ex.Message, "Admin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ExibirEditorJogo(string titulo, JogoManager.Jogo jogo, out DadosJogo dados)
        {
            dados = null;

            Form form = new Form
            {
                Text = titulo,
                BackColor = Color.DarkSlateGray,
                ClientSize = new Size(430, 250),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                StartPosition = FormStartPosition.CenterParent
            };

            Label labelNome = CriarLabelEditor("Nome", 24);
            TextBox textNome = CriarTextBoxEditor(130, 20, jogo == null ? "" : jogo.Nome);

            Label labelCategoria = CriarLabelEditor("Categoria", 76);
            TextBox textCategoria = CriarTextBoxEditor(130, 72, jogo == null ? "" : jogo.Categoria);

            Label labelPreco = CriarLabelEditor("Preco", 128);
            TextBox textPreco = CriarTextBoxEditor(130, 124, jogo == null ? "" : FormatarPreco(jogo.Preco));

            Button buttonSalvar = new Button
            {
                BackColor = Color.White,
                ForeColor = Color.DarkSlateGray,
                Location = new Point(190, 185),
                Size = new Size(100, 36),
                Text = "Salvar",
                UseVisualStyleBackColor = false
            };

            Button buttonCancelar = new Button
            {
                BackColor = Color.White,
                ForeColor = Color.DarkSlateGray,
                Location = new Point(300, 185),
                Size = new Size(100, 36),
                Text = "Cancelar",
                UseVisualStyleBackColor = false
            };

            DadosJogo dadosCapturados = null;

            buttonSalvar.Click += delegate
            {
                decimal preco;
                if (!ValidarDadosJogo(textNome.Text, textCategoria.Text, textPreco.Text, out preco))
                {
                    return;
                }

                dadosCapturados = new DadosJogo
                {
                    Nome = textNome.Text.Trim(),
                    Categoria = textCategoria.Text.Trim(),
                    Preco = preco
                };

                form.DialogResult = DialogResult.OK;
                form.Close();
            };

            buttonCancelar.Click += delegate
            {
                form.DialogResult = DialogResult.Cancel;
                form.Close();
            };

            form.Controls.Add(labelNome);
            form.Controls.Add(textNome);
            form.Controls.Add(labelCategoria);
            form.Controls.Add(textCategoria);
            form.Controls.Add(labelPreco);
            form.Controls.Add(textPreco);
            form.Controls.Add(buttonSalvar);
            form.Controls.Add(buttonCancelar);

            bool confirmado = form.ShowDialog(this) == DialogResult.OK;
            dados = dadosCapturados;
            return confirmado && dados != null;
        }

        private Label CriarLabelEditor(string texto, int y)
        {
            return new Label
            {
                AutoSize = false,
                Font = new Font("Palatino Linotype", 12F, FontStyle.Regular),
                ForeColor = Color.White,
                Location = new Point(24, y),
                Size = new Size(100, 28),
                Text = texto
            };
        }

        private TextBox CriarTextBoxEditor(int x, int y, string texto)
        {
            return new TextBox
            {
                Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular),
                Location = new Point(x, y),
                Size = new Size(270, 24),
                Text = texto
            };
        }

        private bool ValidarDadosJogo(string nome, string categoria, string precoTexto, out decimal preco)
        {
            preco = 0m;

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(categoria))
            {
                MessageBox.Show("Preencha o nome e a categoria do jogo.", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            string texto = precoTexto.Replace("R$", "").Trim();
            bool precoValido =
                decimal.TryParse(texto, NumberStyles.Number, new CultureInfo("pt-BR"), out preco) ||
                decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out preco);

            if (!precoValido || preco < 0)
            {
                MessageBox.Show("Informe um preco valido.", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void AbrirCompra(string nomeJogo, string categorias, string preco, Image imagemJogo)
        {
            CompraForm compraForm = new CompraForm(nomeJogo, categorias, preco, imagemJogo);
            if (compraForm.ShowDialog() == DialogResult.OK)
            {
                AtualizarBotoesJogos();
            }
        }

        private void AtualizarBotoesJogos()
        {
            foreach (GameCardControls card in gameCards)
            {
                JogoManager.Jogo jogo = (JogoManager.Jogo)card.Container.Tag;
                card.BotaoAcao.Text = ObterTextoBotao(jogo.Nome);
                card.BotaoMenu.Visible = SessionContext.CurrentUserId > 0;
            }
        }

        private void AtualizarControlesAdmin()
        {
            buttonAdicionarJogo.Visible = SessionContext.CurrentUserIsAdmin;
        }

        private string ObterTextoBotao(string nomeJogo)
        {
            if (SessionContext.CurrentUserId <= 0)
            {
                return "Comprar";
            }

            return CompraManager.UsuarioPossuiJogo(SessionContext.CurrentUserId, nomeJogo) ? "Jogar" : "Comprar";
        }

        private bool JogarSeUsuarioPossuiJogo(string nomeJogo)
        {
            if (SessionContext.CurrentUserId <= 0)
            {
                return false;
            }

            if (!CompraManager.UsuarioPossuiJogo(SessionContext.CurrentUserId, nomeJogo))
            {
                return false;
            }

            MessageBox.Show(
                "Iniciando " + nomeJogo + "...",
                "Jogar",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            return true;
        }

        private class GameCardControls
        {
            public GameCardControls(Panel container, PictureBox capa, Button botaoAcao, Button botaoMenu)
            {
                Container = container;
                Capa = capa;
                BotaoAcao = botaoAcao;
                BotaoMenu = botaoMenu;
            }

            public Panel Container { get; private set; }
            public PictureBox Capa { get; private set; }
            public Button BotaoAcao { get; private set; }
            public Button BotaoMenu { get; private set; }
        }

        private enum TipoFiltroPreco
        {
            Todos,
            Media,
            Mediana,
            Moda
        }

        private class DadosJogo
        {
            public string Nome { get; set; }
            public string Categoria { get; set; }
            public decimal Preco { get; set; }
        }
    }
}
