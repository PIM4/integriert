using System;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Entity
{
	public class Pessoa
	{
        public int id_pessoa { get; set; }
		public string nome{get;set;}
		public DateTime data_nasc{get;set;}
		public string rg{get;set;}
		public string cpf{get;set;}
		public Login login{set;get;}
		public List<Endereco> endereco{set;get;}
		public List<Telefone> telefone{set;get;}

        public Pessoa()
        {

        }
		public Pessoa(string nome, string rg, string documento, List<Endereco> endereco, List<Telefone> telefone)
		{

		}

	}

}

