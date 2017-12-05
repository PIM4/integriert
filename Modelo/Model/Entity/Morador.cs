using Model.Entity;
using System;
using System.Collections.Generic;

namespace Model.Entity
{
	public class Morador : Pessoa
	{

        public Morador()
        {

        }
		public Morador(bool morador, bool proprietario, string nome, string rg, string documento, List<Endereco> endereco, List<Telefone> telefone)
		{
			
		}
        public int id_morador { get; set; }
        //public bool ativo { get; set; }
        public Unidade unidade { get; set; }
	}

}

