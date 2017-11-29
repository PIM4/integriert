using Model.Entity;
using System;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using Model.DAO.Configuracao;

namespace Model.DAO.Generico
{
	public class dbBancos
	{
        public string strConexao { get; set; }

        public dbBancos()
        {
            Configuracoes configuracao = new Configuracoes();
            this.strConexao = configuracao.LeStringConexao();
        }

        public SqlDataReader MetodoSelect(string QuerySQL)
		{
            SqlConnection conexao = new SqlConnection(strConexao);
            SqlCommand cmd = new SqlCommand(QuerySQL, conexao);
			try
			{
                conexao.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
			}
			catch (Exception ex)
			{
                throw ex;
			}
            //finally
            //{
            //    if (conexao != null)
            //    {
            //        conexao.Close();
            //    }
            //    cmd.Dispose();
            //}
		}

		public bool MetodoNaoQuery(string QuerySQL)
		{
			bool retorno = false;
			SqlConnection conexao = null;
            SqlCommand cmd = null;
			try
			{
				conexao = new SqlConnection(strConexao);
                cmd = new SqlCommand(QuerySQL, conexao);
				conexao.Open();
                cmd.ExecuteNonQuery();
				retorno = true;
			}
			catch (Exception ex)
			{
                retorno = false;
                throw ex;
			}
			finally
			{
				if (conexao != null)
				{
					conexao.Close();
				}
			}
			return retorno;
		}

	}
}
