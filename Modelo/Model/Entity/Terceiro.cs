using Model.Entity;
using System;
using System.Collections.Generic;

namespace Model.Entity
{
	public class Terceiro : Pessoa
	{
        public int id_terceiro { get; set; }
        
        public Fornecedor fornecedor { get; set; }

        public int id_servico { get; set; }
		public string servico{get;set;}
        
	}

}

