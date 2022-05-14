using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGames
{
    class DBContext
    {
        public static string stringconexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Camilla\source\repos\TopGames\TopGames\DatabaseTopGames.mdf;Integrated Security=True";
        private static string str = stringconexao;
        private static SqlConnection con = null;

        public static SqlConnection ObterConexao()
        {
            con = new SqlConnection(str);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            try
            {
                con.Open();
            }
            catch (SqlException)
            {
                con = null;
            }
            return con;
        }

        public static void FecharConexao()
        {
            if (con != null || con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
