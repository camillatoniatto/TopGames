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
    public partial class FormJogo : Form
    {
        public FormJogo()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(DBContext.stringconexao);


        private async void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                ClassJogo jogo = new ClassJogo();
                await jogo.Inserir(txtNome.Text, txtCategoria.Text, txtDescricao.Text, txtEditora.Text, txtValor.Text, txtQuantidade.Text, dtpDataCadastro.Value);
                MessageBox.Show("Jogo cadastrado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<ClassJogo> jog = jogo.listajogo();
                DgvJogos.DataSource = jog;
                txtNome.Text = "";
                txtCategoria.Text = "";
                txtEditora.Text = "";
                txtValor.Text = "";
                txtQuantidade.Text = "";
                this.dtpDataCadastro.Value = DateTime.Now.Date;
                DBContext.FecharConexao();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            string Id = txtId.Text.Trim();
            ClassJogo jogo = new ClassJogo();
            jogo.Atualizar(txtNome.Text, txtCategoria.Text, txtDescricao.Text, txtEditora.Text, txtValor.Text, txtQuantidade.Text, dtpDataCadastro.Value);
            MessageBox.Show("Jogo atualizado com sucesso!");
            List<ClassJogo> jog = jogo.listajogo();
            DgvJogos.DataSource = jog;
            txtNome.Text = "";
            txtCategoria.Text = "";
            txtEditora.Text = "";
            txtValor.Text = "";
            txtQuantidade.Text = "";
            this.dtpDataCadastro.Value = DateTime.Now.Date;
        }

        private void lblLocalizar_Click(object sender, EventArgs e)
        {
            string Id = txtId.Text.Trim();
            ClassJogo jogo = new ClassJogo();
            jogo.ProcurarId(Convert.ToInt32(Id));
            txtNome.Text = jogo.nome;
            txtCategoria.Text = jogo.categoria;
            txtDescricao.Text = jogo.descricao;
            txtEditora.Text = jogo.editora;
            txtValor.Text = jogo.valor;
            txtQuantidade.Text = jogo.editora;

            this.dtpDataCadastro.Value = jogo.data_cadastro;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                string Id = txtId.Text.Trim();
                ClassJogo jogo = new ClassJogo();
                jogo.Exclui(Id);
                MessageBox.Show("Jogo excluído com sucesso!", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<ClassJogo> jog = jogo.listajogo();
                DgvJogos.DataSource = jog;
                txtId.Text = "";
                txtNome.Text = "";
                txtCategoria.Text = "";
                txtDescricao.Text = "";
                txtEditora.Text = "";
                txtValor.Text = "";
                txtQuantidade.Text = "";
                this.dtpDataCadastro.Value = DateTime.Now.Date;
                DBContext.FecharConexao();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormJogo_Load(object sender, EventArgs e)
        {
            ClassJogo jogo = new ClassJogo();
            List<ClassJogo> artigo = jogo.listajogo();
            DgvJogos.DataSource = artigo;
        }
    }
}
