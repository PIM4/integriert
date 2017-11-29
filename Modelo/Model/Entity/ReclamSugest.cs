using System;
using Model.Entity;

namespace Model.Entity
{
	public class ReclamSugest
	{
		public Morador autor{get;set;}
		public string titulo{get;set;}
		public string descricao{get;set;}
		public DateTime data{get;set;}
		public bool verificador{get;set;}

		public ReclamSugest(Morador autor, string titulo, string descricao, bool verificador)
		{

		}

	}
}

