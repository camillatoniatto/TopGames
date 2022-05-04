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
    public partial class FormLogin : Form
    {
        public static string usuarioconectado;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = DBContext.ObterConexao();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Cliente WHERE cpf=@cpf AND senha=@senha";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@cpf", SqlDbType.NChar).Value = txtCPF.Text.Trim();
                cmd.Parameters.AddWithValue("@senha", SqlDbType.NChar).Value = txtSenha.Text.Trim();
                SqlDataReader usuario = cmd.ExecuteReader();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                if (usuario.HasRows)
                {
                    usuarioconectado = txtCPF.Text;
                    this.Hide();
                    FormPrincipal hos = new FormPrincipal();
                    hos.Show();
                    DBContext.FecharConexao();
                }
                else
                {
                    MessageBox.Show("CPF ou senha inválido! Por favor, tente novamente!", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCPF.Text = "";
                    txtSenha.Text = "";
                    txtCPF.Focus();
                    DBContext.FecharConexao();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtCPF.Focus();
        }
    }
}
