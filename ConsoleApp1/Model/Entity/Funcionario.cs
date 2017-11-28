using Model.Entity;
using System;
using Model.DAO.Generico;
using System.Collections.Generic;

namespace Model.Entity
{
	public class Funcionario : Pessoa
	{
		public Funcionario cargo{get;set;}

		public Funcionario(Cargo cargo, string nome, string rg, string documento, List<Endereco> endereco, List<Telefone> telefone)
		{
			
		}
	}

}

