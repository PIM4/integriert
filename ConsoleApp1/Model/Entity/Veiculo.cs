using Model.Entity;
using System;

namespace Model.Entity
{
	public class Veiculo
	{
		public string placa{get;set;}
		public string modelo{get;set;}
		public Unidade unidade{get;set;}

		public Veiculo(string placa, string modelo, Unidade unidade)
		{

		}

	}

}

