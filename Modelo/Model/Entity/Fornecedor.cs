using Model.Entity;
using System;
using System.Collections.Generic;

namespace Model.Entity
{
	public class Fornecedor
	{
        public Fornecedor()
        {

        }

        public Fornecedor(string nomeEmpresa, string ramo, string cnpj, List<Telefone> telefone)
        {

        }
        
        public int id_fornecedor { get; set; }

		public string nomeEmpresa { get; set; }

		public string ramo { get; set; }

		public string cnpj { get; set; }

        public List<Telefone> telefone { get; set; }
        
        public int ativo { get; set; }
	}

}

