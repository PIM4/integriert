using Model.Entity;
using System;

namespace Model.Entity
{
	public class Obra
	{
		public string tipoObra{get;set;}
		public Area area{get;set;}
		public DateTime dtinicio{get;set;}
		public DateTime dtfinal{get;set;}
		public Fornecedor fornecedor{set; get;}

        public Obra() { }

		public void fechamentoObra(DateTime dtfinal)
		{
            return; 
		}

	}

}

