using Model.Entity;
using System;

namespace Model.Entity
{
	public class Login
	{
        public int id_login { get; set; }
		public string login{get;set;}
		public string senha{get;set;}
		public int permissao{get;set;}
        public bool ativo { get; set; }

        public Pessoa pessoa { get; set; }


		public Login()
        {

        }
		public Login(string login, string senha, int perma)
		{

		}

	}

}

