using Model.Entity;
using System;

namespace Model.Entity
{
	public class Visitante
	{
        public int id_visitante { get; set; }
		public string nome{get;set;}
		public string rg{get;set;}
		
        public bool ativo { get; set; }

        public string img { get; set; }

        public Visitante()
        {

        }

		public Visitante(string nome, string rg)
		{

		}
	}

}

