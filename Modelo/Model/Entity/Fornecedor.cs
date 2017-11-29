using Model.Entity;
using System;
using System.Collections.Generic;

namespace Model.Entity
{
	public class Fornecedor
	{
        public int id_fornecedor { get; set; }
		public string nomeEmpresa{get;set;}
		public string ramo{get;set;}
		public string cnpj{get;set;}
		public List<Endereco> endereco{get;set;}
		public List<Telefone> telefone{get;set;}

        public Fornecedor()
        {

        }
		public Fornecedor(string nomeEmpresa, string ramo, string cnpj, List<Endereco> endereco, List<Telefone> telefone)
		{
			
		}

	}

}

