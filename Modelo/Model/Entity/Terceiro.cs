using Model.Entity;
using System;
using System.Collections.Generic;

namespace Model.Entity
{
	public class Terceiro : Pessoa
	{
		public string servico{get;set;}

		public Terceiro(string servico, string nome, string rg, string documento, List<Endereco> endereco, List<Telefone> telefone)
		{

		}

	}

}

