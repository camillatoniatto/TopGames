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


        public void Inserir(object idCliente, object idProduto, string valor_total, string quantidade, DateTime data_venda)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Venda(idCliente,idProduto,valor_total,quantidade,data_venda) VALUES ('" + Convert.ToInt32(idCliente) + "','" + Convert.ToInt32(idProduto) + "','" + Convert.ToDecimal(valor_total) + "','" + Convert.ToInt32(quantidade) + "',Convert(DateTime,'" + data_venda + "',103))";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            DBContext.FecharConexao();
        }

        public void LocalizaById(string id)
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
            }
        }

        public void Atualizar(string id, object idCliente, object idProduto, string valor_total, string quantidade)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE Venda SET idCliente='" + Convert.ToInt32(idCliente) + "',idProduto='" + Convert.ToInt32(idProduto) + "', valor_total='" + Convert.ToDecimal(valor_total) + "', quantidade='" + Convert.ToInt32(quantidade) + "' WHERE Id = '" + Convert.ToInt32(id) + "'";
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
