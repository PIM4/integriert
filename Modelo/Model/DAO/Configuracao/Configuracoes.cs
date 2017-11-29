using Model.Entity;
using System;

namespace Model.DAO.Configuracao
{
    public class Configuracoes
    {
        public string LeStringConexao()
        {
            string strConexao = null;
            try
            {
                strConexao = "Data Source=(localdb)\\v11.0;Database=SMARTDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;";
            }
            catch(Exception ex)
            {
                strConexao = null;
            }
            return strConexao;
        }
    }
}
