using Model.Entity;
using System;

namespace Model.Entity
{
	public class Unidade
	{
        public int id_unidade { get; set; }
		public string identificacao{get;set;}
		public Pessoa proprietario{get;set;}
		public Bloco bloco{get;set;}
		public int vagas{get;set;}
        public bool ativo { get; set; }
        
        public Unidade()
        {

        }
		public Unidade(Bloco bl, string identificacao, int vagas, Pessoa proprietario)
		{

		}

	}

}

