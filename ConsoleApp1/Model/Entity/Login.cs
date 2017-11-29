using Model.Entity;
using System;

namespace Model.Entity
{
	public class Login
	{
		public string login{get;set;}
		public string senha{get;set;}
		public int permissao{get;set;}
		public Login()
        {

        }
		public Login(string login, string senha, int perma)
		{

		}

	}

}

