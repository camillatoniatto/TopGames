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
    public partial class FormCliente : Form
    {
        public FormCliente()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtCPF.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            this.dtpNascimento.Value = DateTime.Now.Date;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            /*try
            {
                ClassCliente usuario = new ClassCliente();
                var result = await usuario.Inserir(txtNome.Text, txtCPF.Text, txtTelefone.Text, txtEmail.Text);
                //List<Usuario> usu = usuario.listacliente();
                this.Hide();
                if (result)
                {
                    FormLogin hos = new FormLogin();
                    hos.Show();
                }
                else
                {
                    this.Refresh();
                }
                DBContext.FecharConexao();
                //dgvCliente.DataSource = usu;
                txtNome.Text = "";
                txtCPF.Text = "";
                txtTelefone.Text = "";
                txtEmail.Text = "";
                this.dtpNascimento.Value = DateTime.Now.Date;
                DBContext.FecharConexao();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }*/
        }
    }
}
