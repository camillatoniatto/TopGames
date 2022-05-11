﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGames.Classes
{
    public class ClassAluguel
    {
        public int Id { get; set; }
        public int idCliente { get; set; }
        public int idProduto { get; set; }
        public decimal valor_total { get; set; }
        public int quantidade { get; set; }
        public DateTime data_retirada { get; set; }
        public DateTime data_entrega { get; set; }
        public int entregue { get; set; } // 0 não - 1 sim
        public decimal multa { get; set; } 


        public void Inserir(object idCliente, object idProduto, string valor_total, int quantidade, DateTime data_retirada, DateTime data_entrega, int entregue, decimal multa, string tipo)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            decimal valor = Convert.ToDecimal(valor_total);
            cmd.CommandText = "INSERT INTO Aluguel(idCliente,idProduto,valor_total,quantidade,data_retirada,data_entrega,entregue,multa,tipo) VALUES ('" + Convert.ToInt32(idCliente) + "','" + Convert.ToInt32(idProduto) + "','" + valor + "','" + Convert.ToInt32(quantidade) + "',Convert(DateTime,'" + data_retirada + "',103),Convert(DateTime,'" + data_entrega + "',103),'" + entregue + "','" + multa + "','" + tipo + "')";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            DBContext.FecharConexao();
        }

        public void LocalizaById(int id)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM Aluguel WHERE Id='" + id + "'";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                idCliente = (int)dr["idCliente"];
                idProduto = (int)dr["idProduto"];
                valor_total = (decimal)dr["valor_total"];
                quantidade = (int)dr["quantidade"];
                data_retirada = Convert.ToDateTime(dr["data_retirada"]);
                data_entrega = Convert.ToDateTime(dr["data_entrega"]);
                entregue = (int)dr["entregue"];
                multa = (decimal)dr["multa"];
            }
        }

        public void Atualizar(string id, int idCliente, int idProduto, decimal valor_total, int quantidade, DateTime data_retirada, DateTime data_entrega, int entregue, decimal multa, string tipo)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE Aluguel SET idCliente='" + idCliente + "',idProduto='" + idProduto + "', valor_total='" + valor_total + "', quantidade='" + quantidade + "', data_retirada=Convert(DateTime,'" + data_retirada + "',103), data_entrega=Convert(DateTime,'" + data_entrega + "',103), entregue='" + entregue + "', multa='" + multa + "', tipo='" + tipo + "' WHERE Id = '" + Convert.ToInt32(id) + "'";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            DBContext.FecharConexao();
        }

        public void Confirmar(string id, DateTime data_entrega, decimal multa)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE Aluguel SET  data_entrega=Convert(DateTime,'" + data_entrega + "',103), entregue='" + 1 + "', multa='" + multa + "' WHERE Id = '" + Convert.ToInt32(id) + "'";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            DBContext.FecharConexao();
        }

        public void Excluir(string id)
        {
            SqlConnection con = DBContext.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Aluguel WHERE Id = '" + Convert.ToInt32(id) + "'";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            DBContext.FecharConexao();
        }
    }
}
