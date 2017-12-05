using Model.Entity;
using System;

namespace Model.Entity
{
	public class Condominio
	{
        public Condominio()
        {

        }

        public Condominio(string nome, Endereco endereco, string proprietario, string cnpj, DateTime dtInau)
        {

        }

        public int id_cond { get; set; }

		public string nome{get;set;}

		public Endereco endereco{get;set;}		

		public int qtdBlocos{get;set;}	
	
		public string proprietario{get;set;}

		public string cnpj{get;set;}

		public DateTime dataInauguracao{get;set;}
		
        public bool ativo { get; set; }
	}

}

