using Model.Entity;
using System;

namespace Model.Entity
{
	public class Endereco
	{
        public int id_endereco { get; set; }
		public string logradouro{get;set;}
		public int numero{get;set;}
		public string complemento{get;set;}
		public string bairro{get;set;}
		public string cep{get;set;}
		public string cidade{get;set;}
		public string estado{get;set;}
        public string descricao { get; set; }

        public Pessoa id_pessoa { get; set; }
		public Endereco(string cep, string log, int num, string bairro, string cidade)
		{

		}

        public Endereco()
        {

        }
	}

}

