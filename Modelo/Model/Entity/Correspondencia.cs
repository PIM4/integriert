using Model.Entity;
using System;

namespace Model.Entity
{
	public class Correspondencia
	{
        public Correspondencia(string descCorespondencia, string destinatario, DateTime dtEntrada)
        {

        }

        public Correspondencia()
        {

        }

        public void entregaCorrespondencia(DateTime dtSaida, Pessoa responsavelRetirada)
        {

        }

        public int id_correspondencia { get; set; }

		public string descCorrespondencia{get;set;}

		//public int destinatario{ get; set; }

        public Unidade unidade { get; set; }

		public string dtEntrada{ get; set; }

		public string dtSaida{ get; set; }

        public bool ativo { get; set; }

		//public int responsavelRetirada{ get; set; }    //Mudei o tipo

        public Pessoa responsavelRetirada { get; set; }

		public string obsCancelamento{ get; set; }

	}

}

