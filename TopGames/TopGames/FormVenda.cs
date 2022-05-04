using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Data.SqlClient;
using TopGames.Classes;
using TopGames.Models;

namespace TopGames
{
    public partial class FormVenda : Form
    {
        public FormVenda()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(DBContext.stringconexao);

        // QUERY SELECT
        /*select venda.id, cliente.nome, cliente.cpf, jogo.nome, artigo.nome, venda.quantidade, venda.valor_total
        from venda
        join produto on venda.id = produto.idvenda
        join jogo on produto.idjogo = jogo.id
        join artigo on produto.idartigo = artigo.id
        joint cliente on cliente.id = venda.idcliente
        order by venda.data_venda desc
        */

        // ToDo: realizar query de vendas com join em artigos e produtos, arrumar metodo GetAll
        public void GetAll()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand("GetAllVendas", con);
            //cmd.Parameters.AddWithValue("@cpf", SqlDbType.Int).Value = FormLogin.usuarioconectado;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int linhas = dt.Rows.Count;
            if (dt.Rows.Count > 0)
            {
                //cbxVenda.Text = dt.Rows[0]["animal"].ToString();
                dgvVenda.Columns.Add("Id", "Venda");
                dgvVenda.Columns.Add("Nome", "Nome");
                dgvVenda.Columns.Add("Cpf", "Cpf");
                dgvVenda.Columns.Add("Jogo", "Nome");
                dgvVenda.Columns.Add("Artigo", "Nome");
                dgvVenda.Columns.Add("Quantidade", "Quantidade");
                dgvVenda.Columns.Add("Valor_Total", "Valor Total");
                for (int i = 0; i < linhas; i++)
                {
                    DataGridViewRow item = new DataGridViewRow();
                    item.CreateCells(dgvVenda);
                    item.Cells[0].Value = dt.Rows[i]["Id"].ToString();
                    item.Cells[1].Value = dt.Rows[i]["Nome"].ToString();
                    item.Cells[2].Value = dt.Rows[i]["Cpf"].ToString();
                    item.Cells[3].Value = dt.Rows[i]["Nome"].ToString();
                    item.Cells[4].Value = dt.Rows[i]["Nome"].ToString();
                    item.Cells[5].Value = dt.Rows[i]["Quantidade"].ToString();
                    item.Cells[6].Value = dt.Rows[i]["Valor_Total"].ToString();
                    dgvVenda.Rows.Add(item);
                }
            }
            con.Close();
        }

        public async void DiminuirQuantidade(bool isGame, int quantidade, int id)
        {
            var verifica = await VerificarQuantidade(id, isGame);

            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            var resto = verifica.Quantidade - quantidade;
            if (isGame)
            {
                cmd.CommandText = "UPDATE Jogo SET quantidade='" + resto + "' WHERE Id = '" + Convert.ToInt32(id) + "'";
            }
            else
            {
                cmd.CommandText = "UPDATE Artigo SET quantidade='" + resto + "' WHERE Id = '" + Convert.ToInt32(id) + "'";
            }
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            DBContext.FecharConexao();
        }

        public async Task<ModelQuantidade> VerificarQuantidade(int id, bool isGame)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            ModelQuantidade model = new ModelQuantidade();
            SqlCommand cmd = new SqlCommand();
            if (isGame)
            {
                cmd = new SqlCommand("SELECT * FROM Jogo WHERE @Id='" + Convert.ToInt32(id) + "'", con);

            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Artigo WHERE @Id='" + Convert.ToInt32(id) + "'", con);
            }
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = cmd.ExecuteReader();
            int valor1 = 0;
            bool conversaoSucedida = int.TryParse(txtQuantidade.Text, out valor1);
            if (rd.Read())
            {
                int valor2 = Convert.ToInt32(rd["quantidade"].ToString());
                if (valor1 > valor2)
                {
                    MessageBox.Show("Não tem quantidade suficiente em estoque!", "Estoque Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQuantidade.Text = "";
                    txtQuantidade.Focus();
                    con.Close();
                }
                else
                {
                    model.Id = id;
                    model.Quantidade = Convert.ToInt32(rd["quantidade"].ToString());
                    model.Valor = Convert.ToDecimal(rd["valor"].ToString());
                }
            }
            return model;
        }

        // GET ALL CLIENTE
        public void CarregaCbxCliente()
        {
            string cli = "SELECT * FROM Cliente ORDER BY nome";
            SqlCommand cmd = new SqlCommand(cli, con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cli, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Cliente");
            cbxClientes.ValueMember = "Id";
            cbxClientes.DisplayMember = "nome";
            cbxClientes.DataSource = ds.Tables["Cliente"];
            con.Close();
        }

        // GET ALL JOGO
        public void CarregaCbxJogo()
        {
            string jogo = "SELECT * FROM Jogo ORDER BY nome";
            SqlCommand cmd = new SqlCommand(jogo, con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(jogo, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Jogo");
            cbxProdutos.ValueMember = "Id";
            cbxProdutos.DisplayMember = "nome";
            cbxProdutos.DataSource = ds.Tables["Jogo"];
            con.Close();
        }

        // GET ALL ARTIGO
        public void CarregaCbxArtigo()
        {
            string artigo = "SELECT * FROM Artigo ORDER BY nome";
            SqlCommand cmd = new SqlCommand(artigo, con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(artigo, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Artigo");
            cbxProdutos.ValueMember = "Id";
            cbxProdutos.DisplayMember = "nome";
            cbxProdutos.DataSource = ds.Tables["Artigo"];
            con.Close();
        }
                
        /*private void btnLocalizar_Click_1(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtID.Text.Trim());
                Hospedagem hsp = new Hospedagem();
                hsp.Localiza(id);
                cbxAnimal.SelectedValue = hsp.id_animal.ToString().Trim();
                dtpDtInicio.Value = Convert.ToDateTime(hsp.checkin);
                dtpDtFim.Value = Convert.ToDateTime(hsp.checkout);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }*/

        private void dgvVenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*DataGridViewRow row = this.dgvVenda.Rows[e.RowIndex];
            txtID.Text = row.Cells[0].Value.ToString().Trim();
            cbxAnimal.Text = row.Cells[1].Value.ToString().Trim();
            dtpDtInicio.Text = row.Cells[4].Value.ToString().Trim();
            dtpDtFim.Text = row.Cells[5].Value.ToString().Trim();*/
        }

        // ARRUMAR DECIMAL
        private void btnVender_Click(object sender, EventArgs e)
        {
            try
            {
                ClassVenda venda = new ClassVenda();
                ClassProduto produtos = new ClassProduto();
                bool isGame = false;
                if (checkBox1.Checked)
                {
                    produtos.Inserir(cbxProdutos.SelectedValue, null, 0);
                    isGame = true;
                }
                else if (checkBox2.Checked)
                {
                    produtos.Inserir(null, cbxProdutos.SelectedValue, 0);
                    isGame = false;

                }
                string idProduto = "SELECT IDENT_CURRENT('Produto') AS idProduto";
                venda.Inserir(cbxClientes.SelectedValue, idProduto, txtTotal.Text, txtQuantidade.Text, DateTime.Now);
                
                string idVenda = "SELECT IDENT_CURRENT('Venda') AS idVenda";
                
                if (checkBox1.Checked)
                {
                    produtos.Atualizar(idProduto, cbxProdutos.SelectedValue, null, idVenda);
                }
                else if (checkBox2.Checked)
                {
                    produtos.Atualizar(idProduto, null, cbxProdutos.SelectedValue, idVenda);
                }

                DiminuirQuantidade(isGame, Convert.ToInt32(txtQuantidade.Text), Convert.ToInt32(idProduto));

                MessageBox.Show("Venda realizada com sucesso.", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvVenda.Rows.Clear();
                dgvVenda.Columns.Clear();
                dgvVenda.Refresh();
                GetAll();
                txtID.Text = "";
                string cliente = cbxClientes.ValueMember;
                string produto = cbxProdutos.ValueMember;
                txtQuantidade.Text = "";
                txtTotal.Text = "";

                DBContext.FecharConexao();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        // CHECKBOX JOGO true
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //desmarca check artigo
            checkBox2.Checked = false;
            //libera cbxproduto
            cbxProdutos.Enabled = true;
            CarregaCbxJogo();
        }

        // CHECKBOX ARTIGO true
        private void checkBox2_MouseCaptureChanged(object sender, EventArgs e)
        {
            //desmarca check jogo
            checkBox1.Checked = false;
            //libera cbxproduto
            cbxProdutos.Enabled = true;
            CarregaCbxArtigo();
        }

        private void FormVenda_Load(object sender, EventArgs e)
        {
            CarregaCbxCliente();
            cbxProdutos.Enabled = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;

            dgvVenda.Rows.Clear();
            dgvVenda.Columns.Clear();
            dgvVenda.Refresh();
            GetAll();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            string cliente = cbxClientes.ValueMember;
            cbxProdutos.Enabled = false;
            txtQuantidade.Text = "";
            txtTotal.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtID.Text.Trim();
                ClassVenda venda = new ClassVenda();
                venda.Excluir(id);
                MessageBox.Show("Venda excluída com sucesso!", "Deletar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvVenda.Rows.Clear();
                dgvVenda.Columns.Clear();
                dgvVenda.Refresh();
                GetAll();
                txtID.Text = "";
                string cliente = cbxClientes.ValueMember;
                string produto = cbxProdutos.ValueMember;
                txtQuantidade.Text = "";
                txtTotal.Text = "";
                DBContext.FecharConexao();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private async void btnAttVenda_Click(object sender, EventArgs e)
        {
            try
            {
                ClassVenda venda = new ClassVenda();
                venda.Atualizar(txtID.Text, cbxClientes.SelectedValue, cbxProdutos.SelectedValue, txtTotal.Text, txtQuantidade.Text);
                ClassProduto produtos = new ClassProduto();
                if (checkBox1.Checked)
                {
                    produtos.Inserir(cbxProdutos.SelectedValue, null, 0);
                }
                else if (checkBox2.Checked)
                {
                    produtos.Inserir(null, cbxProdutos.SelectedValue, 0);

                }

                var idProduto = await produtos.LocalizaByIdVenda(txtID.Text);
                if (checkBox1.Checked)
                {
                    produtos.Atualizar(idProduto.ToString(), cbxProdutos.SelectedValue, null, txtID.Text);
                }
                else if (checkBox2.Checked)
                {
                    produtos.Atualizar(idProduto.ToString(), null, cbxProdutos.SelectedValue, txtID.Text);
                }
                MessageBox.Show("Venda atualizada com sucesso!", "Atualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvVenda.Rows.Clear();
                dgvVenda.Columns.Clear();
                dgvVenda.Refresh();
                GetAll();
                txtID.Text = "";
                string cliente = cbxClientes.ValueMember;
                string produto = cbxProdutos.ValueMember;
                txtQuantidade.Text = "";
                txtTotal.Text = "";
                DBContext.FecharConexao();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnVoltar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
