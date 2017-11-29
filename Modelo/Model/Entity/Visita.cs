using Model.Entity;
using System;

namespace Model.Entity
{
	public class Visita
	{
		public Visitante visitante{get;set;}
		public Unidade unidade{get;set;}
		public DateTime dtChegada{get;set;}
		public DateTime dtSaida{get;set;}

		public Visita()
		{

		}

		public void fechamentoVisita(DateTime dtSaida)
		{
			
		}

	}
}

