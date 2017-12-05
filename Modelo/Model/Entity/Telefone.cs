using System;
using Model.Entity;

namespace Model.Entity
{
    public class Telefone
    {
        public int id_telefone{get;set;}

        public string fixo{get;set;}
        public string celular { get; set; }
		public string desc{set;get;}

        public Pessoa pessoa { get; set; }
        public Fornecedor fornecedor { get; set; }
        public bool ativo { get; set; }
		public Telefone(string tel, string desc)
		{

		}
        public Telefone()
        {

        }

	}

}

