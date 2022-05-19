using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TopGames.Classes;

namespace TopGames
{
    public partial class FormArtigo : Form
    {
        public FormArtigo()
        {
            InitializeComponent();
        }
        public string nome { get; private set; }

        private void FormArtigo_Load(object sender, EventArgs e)
        {
            ClassArtigo cli = new ClassArtigo();
            List<ClassArtigo> artigo = cli.listaArtigo();
            dgvartigo.DataSource = artigo;
        }

        private void dgvartigo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvartigo.Rows[e.RowIndex];
                txtnome.Text = row.Cells[0].Value.ToString();
                txtcategoria.Text = row.Cells[1].Value.ToString();
                txttamanho.Text = row.Cells[2].Value.ToString();
                txtempresa.Text = row.Cells[3].Value.ToString();
                txtvalor.Text = row.Cells[4].Value.ToString();
                txtquantidade.Text = row.Cells[5].Value.ToString();

            }
        }

        private void btnlocalizar_Click(object sender, EventArgs e)
        {
            ClassArtigo artigo = new ClassArtigo();
            artigo.Procurar(nome);
            //txtNome.Text = "";
            txttamanho.Text = artigo.tamanho;
            txttamanho.Text = artigo.tamanho;
            txtempresa.Text = artigo.empresa;
            txtvalor.Text = artigo.valor;
            txtquantidade.Text = artigo.quantidade;
        }

        private async void btncadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                ClassArtigo artigo = new ClassArtigo();
                await artigo.Inserir(txtnome.Text, txtcategoria.Text, txttamanho.Text, txtempresa.Text, txtvalor.Text, txtquantidade.Text);
                MessageBox.Show("Artigo cadastrado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<ClassArtigo> cli = artigo.listaArtigo();
                dgvartigo.DataSource = cli;
                txtnome.Text = "";
                txtcategoria.Text = "";
                txttamanho.Text = "";
                txtempresa.Text = "";
                txtvalor.Text = "";
                txtquantidade.Text = "";

                DBContext.FecharConexao();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtnome.Text.Trim();
                ClassArtigo artigo = new ClassArtigo();
                artigo.Exclui(nome);
                MessageBox.Show("Artigo excluído com sucesso!", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<ClassArtigo> cli = artigo.listaArtigo();
                dgvartigo.DataSource = cli;
                txtnome.Text = "";
                txtcategoria.Text = "";
                txttamanho.Text = "";
                txtempresa.Text = "";
                txtvalor.Text = "";
                txtquantidade.Text = "";
                DBContext.FecharConexao();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnatualizar_Click(object sender, EventArgs e)
        {
            string Id = txtId.Text.Trim();
            ClassArtigo artigo = new ClassArtigo();
            artigo.Atualizar(txtnome.Text, txtcategoria.Text, txttamanho.Text, txtempresa.Text, txtvalor.Text, txtquantidade.Text);
            MessageBox.Show("Artigo atualizado com sucesso!");
            List<ClassArtigo> cli = artigo.listaArtigo();
            dgvartigo.DataSource = cli;
            txtnome.Text = "";
            txtcategoria.Text = "";
            txttamanho.Text = "";
            txtempresa.Text = "";
            txtvalor.Text = "";
            txtquantidade.Text = "";
            DBContext.FecharConexao();
        }
    }
}
