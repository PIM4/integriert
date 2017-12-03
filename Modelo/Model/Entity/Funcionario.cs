using Model.Entity;
using System;
using Model.DAO.Generico;
using System.Collections.Generic;

namespace Model.Entity
{
	public class Funcionario : Pessoa
	{
        public Funcionario()
        {

        }

        public int id_funcionario { get; set; }

		public Cargo cargo{get;set;}


	}

}

