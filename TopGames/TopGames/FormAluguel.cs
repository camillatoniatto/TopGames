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
    public partial class FormAluguel : Form
    {
        public FormAluguel()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(DBContext.stringconexao);

        public void GetAll()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand("GetAllAluguel", con);
            //cmd.Parameters.AddWithValue("@tipo", );
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int linhas = dt.Rows.Count;
            if (dt.Rows.Count > 0)
            {
                dgvVenda.Columns.Add("Id", "Venda");
                dgvVenda.Columns.Add("Nome", "Nome");
                dgvVenda.Columns.Add("Cpf", "Cpf");
                dgvVenda.Columns.Add("Id", "idProduto");
                dgvVenda.Columns.Add("Tipo", "Tipo");
                dgvVenda.Columns.Add("Quantidade", "Quantidade");
                dgvVenda.Columns.Add("Valor_Total", "Valor Total");
                dgvVenda.Columns.Add("Data_Retirada", "Data Retirada");
                dgvVenda.Columns.Add("Data_Entrega", "Data Entrega");
                dgvVenda.Columns.Add("multa", "Multa");

                for (int i = 0; i < linhas; i++)
                {
                    DataGridViewRow item = new DataGridViewRow();
                    item.CreateCells(dgvVenda);
                    item.Cells[0].Value = dt.Rows[i]["Id"].ToString();
                    item.Cells[1].Value = dt.Rows[i]["Nome"].ToString();
                    item.Cells[2].Value = dt.Rows[i]["Cpf"].ToString();
                    item.Cells[3].Value = dt.Rows[i]["idProduto"].ToString();
                    item.Cells[4].Value = dt.Rows[i]["Tipo"].ToString();
                    item.Cells[5].Value = dt.Rows[i]["Quantidade"].ToString();
                    item.Cells[6].Value = dt.Rows[i]["Valor_Total"].ToString();
                    item.Cells[7].Value = dt.Rows[i]["data_retirada"].ToString();
                    item.Cells[6].Value = dt.Rows[i]["data_entrega"].ToString();
                    item.Cells[9].Value = dt.Rows[i]["multa"].ToString();
                    dgvVenda.Rows.Add(item);
                }
            }
            con.Close();
        }


        public async void DiminuirQuantidade(bool isGame, int quantidade, object id)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            var verifica = await VerificarQuantidade(id, isGame);

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

        public async Task<ModelQuantidade> VerificarQuantidade(object id, bool isGame)
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
                cmd = new SqlCommand("SELECT * FROM Artigo WHERE Id=@Id", con);
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Artigo WHERE Id=@Id", con);

            }
            cmd.Parameters.AddWithValue("@Id", cbxProdutos.SelectedValue);
            cmd.CommandType = CommandType.Text;
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                int valor2 = Convert.ToInt32(rd["quantidade"].ToString());
                model.Id = Convert.ToInt32(id);
                model.Quantidade = Convert.ToInt32(rd["quantidade"].ToString());
                model.Valor = Convert.ToDecimal(rd["valor"].ToString());

                var valorUnid = Convert.ToDecimal(rd["valor"].ToString());
                var total = valorUnid * valor2;
                txtTotal.Text = total.ToString();
                rd.Close();
            }
            return model;
        }

        public void clean()
        {
            CarregaCbxCliente();
            txtID.Text = "";
            cbxClientes.Enabled = false;
            cbxProdutos.Enabled = false;
            txtQuantidade.Enabled = false;
            txtTotal.Enabled = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;

            dgvVenda.Rows.Clear();
            dgvVenda.Columns.Clear();
            dgvVenda.Refresh();
            //GetAll();
        }

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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //desmarca check artigo
            checkBox2.Checked = false;
            //libera cbxproduto
            cbxProdutos.Enabled = true;
            CarregaCbxJogo();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //desmarca check jogo
            checkBox1.Checked = false;
            //libera cbxproduto
            cbxProdutos.Enabled = true;
            CarregaCbxArtigo();
        }

        private void btnNovoAlugel_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            cbxClientes.Enabled = true;
            string cliente = cbxClientes.ValueMember;
            txtQuantidade.Enabled = true;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            dtRetirada.Value = DateTime.Now;
            dtRetirada.Enabled = true;
            dtEntrega.Value = DateTime.Now.AddDays(3);
            dtEntrega.Enabled = false;
        }

        private void FormAluguel_Load(object sender, EventArgs e)
        {
            CarregaCbxCliente();
            txtID.Text = "";
            cbxClientes.Enabled = false;
            cbxProdutos.Enabled = false;
            txtQuantidade.Enabled = false;
            txtTotal.Enabled = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            dtRetirada.Enabled = false;
            dtEntrega.Enabled = false;


            dgvVenda.Rows.Clear();
            dgvVenda.Columns.Clear();
            dgvVenda.Refresh();
            GetAll();
        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantidade.Text != "")
            {
                if (Convert.ToInt32(txtQuantidade.Text) > 0)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    ModelQuantidade model = new ModelQuantidade();
                    SqlCommand cmd = new SqlCommand();
                    if (checkBox1.Checked)
                    {
                        cmd = new SqlCommand("EncontraJogo", con);
                    }
                    else if (checkBox2.Checked)
                    {
                        cmd = new SqlCommand("EncontraArtigo", con);
                    }
                    cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(cbxProdutos.SelectedValue));
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
                            rd.Close();
                            con.Close();
                        }
                        else
                        {
                            decimal valorUnid = Convert.ToDecimal(rd["valor"]);
                            int quantidade = Convert.ToInt32(txtQuantidade.Text);
                            var total = valorUnid * quantidade;
                            txtTotal.Text = total.ToString();
                        }
                    }
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAlugar_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                ClassAluguel aluguel = new ClassAluguel();
                ClassProduto produtos = new ClassProduto();
                SqlCommand cmdProduto = new SqlCommand();
                bool isGame = false;
                var type = "";
                if (checkBox1.Checked)
                {
                    //produtos.Inserir(cbxProdutos.SelectedValue, null, 0);
                    isGame = true;
                    string idProduto = "SELECT IDENT_CURRENT('Jogo')";
                    cmdProduto = new SqlCommand(idProduto, con);
                    type = "j";
                }
                else if (checkBox2.Checked)
                {
                    //produtos.Inserir(null, cbxProdutos.SelectedValue, 0);
                    isGame = false;
                    string idArtigo = "SELECT IDENT_CURRENT('Artigo')";
                    cmdProduto = new SqlCommand(idArtigo, con);
                    type = "a";
                }

                aluguel.Inserir(cbxClientes.SelectedValue, cbxProdutos.SelectedValue, txtTotal.Text, Convert.ToInt32(txtQuantidade.Text), dtRetirada.Value, dtEntrega.Value, 0, 0M, type);

                DiminuirQuantidade(isGame, Convert.ToInt32(txtQuantidade.Text), cbxProdutos.SelectedValue);

                MessageBox.Show("Aluguel realizado com sucesso.", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvVenda.Rows.Clear();
                dgvVenda.Columns.Clear();
                dgvVenda.Refresh();
                //GetAll();
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

        private void dtRetirada_ValueChanged(object sender, EventArgs e)
        {
            dtEntrega.Value = dtRetirada.Value.AddDays(3);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                ClassAluguel aluguel = new ClassAluguel();
                ClassProduto produtos = new ClassProduto();
                SqlCommand cmdProduto = new SqlCommand();
                bool isGame = false;
                var type = "";
                if (checkBox1.Checked)
                {
                    //produtos.Inserir(cbxProdutos.SelectedValue, null, 0);
                    isGame = true;
                    string idProduto = "SELECT IDENT_CURRENT('Jogo')";
                    cmdProduto = new SqlCommand(idProduto, con);
                    type = "j";
                }
                else if (checkBox2.Checked)
                {
                    //produtos.Inserir(null, cbxProdutos.SelectedValue, 0);
                    isGame = false;
                    string idArtigo = "SELECT IDENT_CURRENT('Artigo')";
                    cmdProduto = new SqlCommand(idArtigo, con);
                    type = "a";
                }

                aluguel.LocalizaById(Convert.ToInt32(txtID.Text));
                DateTime entrega = Convert.ToDateTime(aluguel.data_entrega);
                DateTime dateNow = DateTime.Now;
                var atraso = entrega.DayOfYear - dateNow.DayOfYear;
                var multa = 5.00M;
                var totalMulta = 0M;
                if (atraso > 1)
                {
                    totalMulta = multa * atraso;
                }
                aluguel.Confirmar(txtID.Text, DateTime.Now, totalMulta);
                AumentarQuantidade(isGame, Convert.ToInt32(txtQuantidade.Text), cbxProdutos.SelectedValue);
                
                MessageBox.Show("Venda realizada com sucesso.", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DBContext.FecharConexao();
                clean();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        public async void AumentarQuantidade(bool isGame, int quantidade, object id)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            var verifica = await VerificarQuantidade(id, isGame);

            var resto = verifica.Quantidade + quantidade;
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

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtID.Text.Trim());
                ClassAluguel aluguel = new ClassAluguel();

                aluguel.LocalizaById(id);

                txtID.Text = aluguel.Id.ToString().Trim();
                cbxClientes.Text = aluguel.idCliente.ToString().Trim();
                cbxProdutos.Text = aluguel.idProduto.ToString().Trim();
                txtQuantidade.Text = aluguel.quantidade.ToString().Trim();
                if (aluguel.tipo.ToString().Trim() == "j")
                {
                    checkBox1.Checked = true;
                    checkBox2.Checked = false;

                    id = Convert.ToInt32(txtID.Text.Trim());
                    ClassJogo jg = new ClassJogo();
                    jg.ProcurarId(id);
                    cbxProdutos.ValueMember = jg.Id.ToString().Trim();
                    cbxProdutos.DisplayMember = jg.nome.ToString().Trim();
                }
                else if (aluguel.tipo.ToString().Trim() == "a")
                {
                    checkBox1.Checked = false;
                    checkBox2.Checked = true;

                    id = Convert.ToInt32(txtID.Text.Trim());
                    ClassArtigo art = new ClassArtigo();
                    art.ProcurarId(id);
                    cbxProdutos.ValueMember = art.Id.ToString().Trim();
                    cbxProdutos.DisplayMember = art.nome.ToString().Trim();
                }
                txtTotal.Text = aluguel.valor_total.ToString().Trim();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void dgvVenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgvVenda.Rows[e.RowIndex];
            txtID.Text = row.Cells[0].Value.ToString().Trim();
            cbxClientes.Text = row.Cells[1].Value.ToString().Trim();
            cbxProdutos.Text = row.Cells[3].Value.ToString().Trim();
            txtQuantidade.Text = row.Cells[5].Value.ToString().Trim();
            if (row.Cells[4].Value.ToString().Trim() == "j")
            {
                checkBox1.Checked = true;
                checkBox2.Checked = false;

                int id = Convert.ToInt32(txtID.Text.Trim());
                ClassJogo jg = new ClassJogo();
                jg.ProcurarId(id);
                cbxProdutos.ValueMember = jg.Id.ToString().Trim();
                cbxProdutos.DisplayMember = jg.nome.ToString().Trim(); ;
            }
            else if (row.Cells[4].Value.ToString().Trim() == "a")
            {
                checkBox1.Checked = false;
                checkBox2.Checked = true;

                int id = Convert.ToInt32(txtID.Text.Trim());
                ClassArtigo art = new ClassArtigo();
                art.ProcurarId(id);
                cbxProdutos.ValueMember = art.Id.ToString().Trim();
                cbxProdutos.DisplayMember = art.nome.ToString().Trim();
            }
            dtRetirada.Text = row.Cells[7].Value.ToString().Trim();
            dtEntrega.Text = row.Cells[8].Value.ToString().Trim();

        }
    }
}
