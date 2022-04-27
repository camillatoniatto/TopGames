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

namespace TopGames
{
    public partial class FormVenda : Form
    {
        public FormVenda()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(DBContext.stringconexao);

        public void MinhasHospedagens()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand("HospedagemCliente", con);
            cmd.Parameters.AddWithValue("@cpf", SqlDbType.Int).Value = FormLogin.usuarioconectado;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int linhas = dt.Rows.Count;
            if (dt.Rows.Count > 0)
            {
                //cbxAnimal.Text = dt.Rows[0]["animal"].ToString();
                dgvPet.Columns.Add("Id", "Id");
                dgvPet.Columns.Add("Animal", "Animal");
                dgvPet.Columns.Add("Cpf", "Cpf");
                dgvPet.Columns.Add("Tutor", "Tutor");
                dgvPet.Columns.Add("Checkin", "Checkin");
                dgvPet.Columns.Add("Checkout", "Checkout");
                dgvPet.Columns.Add("Status", "Status");
                for (int i = 0; i < linhas; i++)
                {
                    DataGridViewRow item = new DataGridViewRow();
                    item.CreateCells(dgvPet);
                    item.Cells[0].Value = dt.Rows[i]["Id"].ToString();
                    item.Cells[1].Value = dt.Rows[i]["Animal"].ToString();
                    item.Cells[2].Value = dt.Rows[i]["Cpf"].ToString();
                    item.Cells[3].Value = dt.Rows[i]["Tutor"].ToString();
                    item.Cells[4].Value = dt.Rows[i]["Checkin"].ToString();
                    item.Cells[5].Value = dt.Rows[i]["Checkout"].ToString();
                    item.Cells[6].Value = dt.Rows[i]["Status"].ToString();
                    dgvPet.Rows.Add(item);
                }
            }
            con.Close();
        }

        public void CarregaCbxAnimal()
        {
            string cli = "SELECT * FROM animal WHERE cpf_tutor ='" + FormLogin.usuarioconectado + "' ORDER BY nome";
            SqlCommand cmd = new SqlCommand(cli, con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cli, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "animal");
            cbxAnimal.ValueMember = "Id";
            cbxAnimal.DisplayMember = "nome";
            cbxAnimal.DataSource = ds.Tables["animal"];
            con.Close();
        }

        private void btnLocalizar_Click_1(object sender, EventArgs e)
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
        }

        private void btnCadastro_Click_1(object sender, EventArgs e)
        {
            try
            {
                Hospedagem hsp = new Hospedagem();
                hsp.Inserir(cbxAnimal.SelectedValue, dtpDtInicio.Value.Date, dtpDtFim.Value.Date);
                MessageBox.Show("Hospedagem cadastrada com sucesso!", "Cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvPet.Rows.Clear();
                dgvPet.Columns.Clear();
                dgvPet.Refresh();
                MinhasHospedagens();
                txtID.Text = "";
                string animal = cbxAnimal.ValueMember;
                this.dtpDtInicio.Value = DateTime.Now.Date;
                this.dtpDtFim.Value = DateTime.Now.Date.AddDays(2);

                ClassConecta.FecharConexao();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnAttPet_Click_1(object sender, EventArgs e)
        {
            try
            {
                Hospedagem hsp = new Hospedagem();
                hsp.Atualizar(txtID.Text, cbxAnimal.SelectedValue, dtpDtInicio.Value.Date, dtpDtFim.Value.Date);
                MessageBox.Show("Hospedagem atualizada com sucesso!", "Atualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvPet.Rows.Clear();
                dgvPet.Columns.Clear();
                dgvPet.Refresh();
                MinhasHospedagens();
                txtID.Text = "";
                this.dtpDtInicio.Value = DateTime.Now.Date;
                this.dtpDtFim.Value = DateTime.Now.Date.AddDays(2);
                ClassConecta.FecharConexao();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnConfirmar_Click_1(object sender, EventArgs e)
        {
            try
            {
                Hospedagem hsp = new Hospedagem();
                hsp.Confirmar(txtID.Text);
                MessageBox.Show("Hospedagem confirmada com sucesso!", "Atualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvPet.Rows.Clear();
                dgvPet.Columns.Clear();
                dgvPet.Refresh();
                MinhasHospedagens();
                txtID.Text = "";
                this.dtpDtInicio.Value = DateTime.Now.Date;
                this.dtpDtFim.Value = DateTime.Now.Date.AddDays(2);
                ClassConecta.FecharConexao();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnExcluirPet_Click_1(object sender, EventArgs e)
        {
            try
            {
                string id = txtID.Text.Trim();
                Hospedagem hsp = new Hospedagem();
                hsp.Excluir(id);
                MessageBox.Show("Hospedagem excluída com sucesso!", "Deletar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvPet.Rows.Clear();
                dgvPet.Columns.Clear();
                dgvPet.Refresh();
                MinhasHospedagens();
                txtID.Text = "";
                this.dtpDtInicio.Value = DateTime.Now.Date;
                this.dtpDtFim.Value = DateTime.Now.Date.AddDays(2);
                ClassConecta.FecharConexao();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormHospedagemCliente_Load_1(object sender, EventArgs e)
        {
            CarregaCbxAnimal();
            dgvPet.Rows.Clear();
            dgvPet.Columns.Clear();
            dgvPet.Refresh();
            MinhasHospedagens();
        }

        private void dgvPet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgvPet.Rows[e.RowIndex];
            txtID.Text = row.Cells[0].Value.ToString().Trim();
            cbxAnimal.Text = row.Cells[1].Value.ToString().Trim();
            dtpDtInicio.Text = row.Cells[4].Value.ToString().Trim();
            dtpDtFim.Text = row.Cells[5].Value.ToString().Trim();
        }
    }
}
