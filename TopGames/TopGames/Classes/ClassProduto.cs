using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGames.Classes
{
    class ClassProduto
    {
        public int Id { get; set; }
        public int idJogo { get; set; }
        public int idArtigo { get; set; }
        public int idVenda { get; set; }


        public void Inserir(object idJogo, object idArtigo, int idVenda)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Produtos(idJogo,idArtigo,idVenda) VALUES ('" + Convert.ToInt32(idJogo) + "','" + Convert.ToInt32(idArtigo) + "','" + Convert.ToInt32(idVenda) + "')";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            DBContext.FecharConexao();
        }

        public void LocalizaById(string id)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM Produtos WHERE Id='" + Convert.ToInt32(id) + "'";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                idJogo = (int)dr["idJogo"];
                idArtigo = (int)dr["idArtigo"];
                idVenda = (int)dr["idVenda"];
            }
        }

        public async Task<int> LocalizaByIdVenda(string idVenda)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM Produtos WHERE Id='" + Convert.ToInt32(idVenda) + "'";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            var idProduto = (int)dr["Id"];
            return idProduto;
        }

        public void Atualizar(string id, object idJogo, object idArtigo, string idVenda)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE Produtos SET idJogo='" + Convert.ToInt32(idJogo) + "',idArtigo='" + Convert.ToInt32(idArtigo) + "',idVenda='" + Convert.ToInt32(idVenda) + "' WHERE Id = '" + Convert.ToInt32(id) + "'";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            DBContext.FecharConexao();
        }

        public void Excluir(string id)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Produtos WHERE Id = '" + Convert.ToInt32(id) + "'";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            DBContext.FecharConexao();
        }
    }
}
