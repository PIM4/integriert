using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO.Generico
{
    class Log
    {
        public bool armazenaLog(int tipo, int login, int id_registro, string tabela)
        {
            string query = null;

            try
            {
                query = "INSERT INTO LOG (ID_LOGIN, ID_REGISTRO, TABELA, DT_OPERACAO, TIPO_OPERACAO) VALUES ("
                        + (login).ToString() + ", " + (id_registro).ToString() + ", " + tabela + ", GETDATE(), " + (tipo).ToString() + ")";
                return true;
            }

            catch(Exception ex)
            {
                return false;
                throw ex;
            }
        }
    }
}
