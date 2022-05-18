using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TopGames.Classes;

namespace TopGames
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            SqlConnection con = DBContext.ObterConexao();
            ClassCliente user = new ClassCliente();
            user.Procurar(FormLogin.usuarioconectado);
            lblUser.Text = user.nome;
            con.Close();
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVenda venda = new FormVenda();
            venda.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCliente cliente = new FormCliente();
            cliente.Show();
        }

        private void alugueisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAluguel aluguel = new FormAluguel();
            aluguel.Show();
        }

        private void jogosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormJogo form = new FormJogo();
            form.Show();
        }

        private void artigosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormArtigo form = new FormArtigo();
            form.Show();
        }
    }
}
