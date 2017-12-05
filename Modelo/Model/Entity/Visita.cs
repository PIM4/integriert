using Model.Entity;
using System;

namespace Model.Entity
{
	public class Visita
	{
        public int id_visita { get; set; }
		public Visitante visitante{get;set;}
		public Unidade unidade{get;set;}
		public string dtChegada{get;set;}
		public string dtSaida {get;set;}
        public bool ativo { get; set; }

		public Visita()
		{

		}

		public void fechamentoVisita(DateTime dtSaida)
		{
			
		}

	}
}

