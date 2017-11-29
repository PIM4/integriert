using Model.Entity;
using System;
using System.Collections.Generic;

namespace Model.Entity
{
	public class Condomino : Pessoa
	{
		public bool morador{get;set;}
		public bool proprietario{get;set;}

        public Condomino()
        {

        }
		public Condomino(bool morador, bool proprietario, string nome, string rg, string documento, List<Endereco> endereco, List<Telefone> telefone)
		{
			
		}
	}

}

