using Model.Entity;
using System;

namespace Model.Entity
{
	public class Aviso
	{
        public Aviso()
        {

        }

        public int id_aviso { get; set; }

		public string titulo { get; set; }

		public string descricao { get; set; }

        public Condominio cond { get; set; }

		public DateTime data { get; set; }

        public bool ativo { get; set; }

        public Aviso(string titulo, string descricao, Condominio condominio)
        {

		}
	}

}

