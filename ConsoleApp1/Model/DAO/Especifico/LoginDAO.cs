using Model.Entity;
using System.Collections.Generic;

namespace Model.DAO.Especifico
{
	public class LoginDAO
	{
        Login obj = new Login();
        public bool cadastra(Login login)
		{
            return true;
        }

		public Login buscaLogin(string login, string senha)
		{
            
            return obj;
        }

		public bool remove(Login login)
		{
            return true;
        }

	}

}

