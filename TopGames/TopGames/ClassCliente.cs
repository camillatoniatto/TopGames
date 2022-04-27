using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopGames
{
    class ClassCliente
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public DateTime data_nascimento { get; set; }

        public List<ClassCliente> listacliente()
        {
            List<ClassCliente> li = new List<ClassCliente>();
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM cliente";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ClassCliente c = new ClassCliente();
                c.Id = (int)dr["Id"];
                c.nome = dr["nome"].ToString();
                c.cpf = dr["cpf"].ToString();
                c.telefone = dr["telefone"].ToString();
                c.email = dr["email"].ToString();
                c.senha = "*****";
                c.data_nascimento = Convert.ToDateTime(dr["data_nascimento"]);
                li.Add(c);
            }
            return li;
        }

        public async Task<bool> Inserir(string nome, string cpf, string telefone, string email, string senha, DateTime data_nascimento)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            var processo = "user"; ////////
            var busca = await BuscarPorCPF(cpf);
            if (busca)
            {
                cmd.CommandText = "INSERT INTO cliente(nome,cpf,telefone,email,senha,data_nascimento) VALUES ('" + nome + "','" + cpf + "','" + telefone + "','" + email + "','" + senha + "','" + data_nascimento + "')";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cadastro realizado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DBContext.FecharConexao();
                return true;
            }
            else
            {
                DBContext.FecharConexao();
                return false;
            }

        }

        public void Procurar(string cpf)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM cliente WHERE cpf='" + cpf + "'";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nome = dr["nome"].ToString();
                this.cpf = dr["cpf"].ToString();
                telefone = dr["celular"].ToString();
                email = dr["email"].ToString();
                data_nascimento = Convert.ToDateTime(dr["data_nascimento"]);
            }
        }

        public async Task<bool> BuscarPorCPF(string cpf)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM cliente WHERE cpf='" + cpf + "'";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Já existe um cliente cadastrado com esse CPF", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Exclui(string cpf)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM cliente WHERE cpf='" + cpf + "'";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            DBContext.FecharConexao();
        }

        public void Atualizar(string nome, string cpf, string telefone, string email, string senha, DateTime data_nascimento)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE cliente SET nome='" + nome + "',telefone='" + telefone + "',email='" + email + "',senha='" + senha + "',data_nascimento='" + data_nascimento + "' WHERE cpf = '" + FormLogin.usuarioconectado + "'";
            cmd.CommandType = CommandType.Text; //form login na lina acima
            cmd.ExecuteNonQuery();
            DBContext.FecharConexao();
        }

        public void AtualizarAdmin(string nome, string cpf, string telefone, string email, DateTime data_nascimento, bool checkbox)
        {
            var processo = "";
            if (checkbox)
            {
                processo = "admin";
            }
            else
            {
                processo = "user";
            }
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE cliente SET nome='" + nome + "',telefone='" + telefone + "',email='" + email + "',data_nascimento='" + data_nascimento + "' WHERE cpf = '" + cpf + "'";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            DBContext.FecharConexao();
        }
    }
}
