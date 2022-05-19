using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopGames.Classes
{
    class ClassArtigo
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string categoria { get; set; }
        public string tamanho { get; set; }
        public string empresa { get; set; }
        public string valor { get; set; }
        public int quantidade { get; set; }

        public List<ClassArtigo> listaArtigo()
        {
            List<ClassArtigo> li = new List<ClassArtigo>();
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM Artigo";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ClassArtigo c = new ClassArtigo();
                c.Id = (int)dr["Id"];
                c.nome = dr["nome"].ToString().Trim();
                c.categoria = dr["categoria"].ToString().Trim();
                c.tamanho = dr["tamanho"].ToString().Trim();
                c.empresa = dr["empresa"].ToString().Trim();
                c.valor = dr["valor"].ToString().Trim();
                c.quantidade = (int)dr["quantidade"];
                li.Add(c);
            }
            return li;
        }

        public async Task<bool> Inserir(string nome, string categoria, string tamanho, string empresa, string valor, string quantidade)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            var busca = await BuscarPornome(nome);
            if (busca)
            {
                cmd.CommandText = "INSERT INTO artigo(nome,categoria,tamanho,empresa,valor,quantidade) VALUES ('" + nome + "','" + categoria + "','" + tamanho + "','" + empresa + "','" + valor + "','" + Convert.ToInt32(quantidade) + "')";
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

        public void Procurar(string nome)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM artigo WHERE nome='" + nome + "'";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nome = dr["nome"].ToString();
                categoria = dr["categoria"].ToString();
                tamanho = dr["tamanho"].ToString();
                empresa = dr["empresa"].ToString();
                valor = dr["valor"].ToString();
            }
        }

        public void ProcurarId(int id)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM artigo WHERE Id='" + id + "'";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nome = dr["nome"].ToString();
                categoria = dr["categoria"].ToString();
                tamanho = dr["tamanho"].ToString();
                empresa = dr["empresa"].ToString();
                valor = dr["valor"].ToString();
                quantidade = (int)dr["quantidade"];
            }
        }

        public async Task<bool> BuscarPornome(string nome)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM artigo WHERE nome='" + nome + "'";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Já existe um artigo cadastrado com esse nome", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Exclui(string nome)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM artigo WHERE nome='" + nome + "'";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            DBContext.FecharConexao();
        }

        public void Atualizar(string nome, string categoria, string tamanho, string empresa, string valor, string quantidade, int id)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE artigo SET nome='" + nome + "',categoria='" + categoria + "',tamanho='" + tamanho + "',empresa='" + empresa + "',valor='" + valor + "',quantidade='" + Convert.ToInt32(quantidade) + "' WHERE Id = '" + id + "'";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            DBContext.FecharConexao();
        }
    }
}
