using Model.Entity;
using System;

namespace Model.Entity
{
	public class Bloco
	{
        public Bloco()
        {

        }

        public Bloco(string nome, Condominio condominio)
        {

        }

        public int id_bloco { get; set; }

		public string nome{get;set;}

		public int qtAndares{get;set;}

		public int qtApto{get;set;}	

		public Condominio cond{get;set;}
	}

}

