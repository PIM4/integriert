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
                /*String BRUNA*/
                //strConexao = "Data Source=(localdb)\\v11.0;Database=SMARTDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;";
                /*String CARLOS*/
                strConexao = "Data Source = (LocalDB)\\MSSQLLocalDB; Initial Catalog = smartdb; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
                
            }
            // Pra que? \/ nunca vai cair nessa condição
            catch(Exception ex)
            {
                strConexao = null;
            }
            return strConexao;
        }
    }
}
