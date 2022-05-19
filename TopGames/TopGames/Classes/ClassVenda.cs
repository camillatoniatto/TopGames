using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TopGames.Classes
{
    public class ClassVenda
    {
        public int Id { get; set; }
        public int idCliente { get; set; }
        public int idProduto { get; set; }
        public decimal valor_total { get; set; }
        public int quantidade { get; set; }
        public DateTime data_venda { get; set; }
        public string tipo { get; set; }


        public void Inserir(object idCliente, object idProduto, string valor_total, int quantidade, string tipo)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            string replace = valor_total.Replace(",", ".");
            decimal valor = Convert.ToDecimal(replace) / 100;
            cmd.CommandText = "INSERT INTO Venda(idCliente,idProduto,valor_total,quantidade,data_venda,tipo) VALUES ('" + Convert.ToInt32(idCliente) + "','" + Convert.ToInt32(idProduto) + "','" + valor + "','" + quantidade + "','"+ DateTime.Now +"','" + tipo.ToString() + "')";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            DBContext.FecharConexao();
        }

        public void LocalizaById(int id)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM Venda WHERE Id='" + Convert.ToInt32(id) + "'";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                idCliente = (int)dr["idCliente"];
                idProduto = (int)dr["idProduto"];
                valor_total = (decimal)dr["valor_total"];
                quantidade = (int)dr["quantidade"];
                data_venda = Convert.ToDateTime(dr["data_venda"]);
                tipo = dr["tipo"].ToString();
            }
        }

        public void Atualizar(string id, object idCliente, object idProduto, string valor_total, string quantidade, string tipo)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            string replace = valor_total.Replace(",", ".");
            decimal valor = Convert.ToDecimal(replace) / 100;
            cmd.CommandText = "UPDATE Venda SET idCliente='" + Convert.ToInt32(idCliente) + "',idProduto='" + Convert.ToInt32(idProduto) + "', valor_total='" + Convert.ToDecimal(valor_total) + "', quantidade='" + Convert.ToInt32(quantidade) + "', tipo='" + tipo + "' WHERE Id = '" + Convert.ToInt32(id) + "'";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            DBContext.FecharConexao();
        }

        public void Excluir(string id)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Venda WHERE Id = '" + Convert.ToInt32(id) + "'";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            DBContext.FecharConexao();
        }
    }
}
