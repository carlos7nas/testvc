using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testvc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private bool DeveMostrar(string conteudo, string texto)
        {
            return string.IsNullOrEmpty(texto) || conteudo.ToLower().Contains(texto);
        }

        private void Txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            string texto = txtpesquisa.Text.Trim().ToLower();

            pbgtav.Visible = DeveMostrar("gtav simulacao tiro", texto);
            lblgta.Visible = DeveMostrar("gtav simulacao tiro", texto);
            btgta.Visible = DeveMostrar("gtav simulacao tiro", texto);

            pbeafc.Visible = DeveMostrar("ea fc 26 esporte simulacao", texto);
            lbleafc.Visible = DeveMostrar("ea fc 26 esporte simulacao", texto);
            bteafc.Visible = DeveMostrar("ea fc 26 esporte simulacao", texto);

            pbmine.Visible = DeveMostrar("minecraft aventura exploracao", texto);
            lblmine.Visible = DeveMostrar("minecraft aventura exploracao", texto);
            btmine.Visible = DeveMostrar("minecraft aventura exploracao", texto);
        }
    }
}
