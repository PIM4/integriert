using Model.Entity;
using System;

namespace Model.DAO.Configuracao
{
    public class Configuracoes
    {
        public string LeStringConexao()
        {
            //string strConexao = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\\Users\bruna\\Documents\\bancoTestePim.mdf;Integrated Security=True;Connect Timeout=30";
            string strConexao = null;
            try
            {
                strConexao = strConexao = "Server=(localdb)\\mssqllocaldb;Database=smartdb;Trusted_Connection=true;";
                //
                //strConexao = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\\Users\\bruna\\Documents\\bancoTestePim.mdf;Integrated Security=True;Connect Timeout=30";
            }
            finally {  }
            //catch(Exception ex)
            //{
            //    strConexao = null;
            //}
            return strConexao;
        }
    }
}
