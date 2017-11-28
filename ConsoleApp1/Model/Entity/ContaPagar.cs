using Model.Entity;
using System;

namespace Model.Entity
{
	public class ContaPagar
	{
        public ContaPagar()
        {

        }

        public ContaPagar(string tipo, Fornecedor fornecedor, DateTime data, float valor)
        {

        }

        public int id_cp { get; set; }

        public DateTime data { get; set; }

        public decimal valor { get; set; }

        //TIPO_CONTA
		public int id_tipo{get;set;}

        public string desc_conta { get; set; }

		public Fornecedor fornecedor{get;set;}

        public Condominio condominio { get; set; }

	}

}

