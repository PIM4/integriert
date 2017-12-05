using Model.Entity;
using System;

namespace Model.Entity
{
    public class Obra
    {
        public int id_obra { get; set; }
        public string descricao_obra { get; set; }
        public Area area { get; set; }
        public Condominio cond { get; set; }
        public string dt_inicio { get; set; }
        public string dt_previsao_termino { get; set; }
        public string dt_termino { get; set; }
        public bool finalizada { get; set; }
        public bool ativo { get; set; }

        //

        public int id_tipo_obra { get; set; }
        public string desc_tipo { get; set; }

        //

        public int id_terceiro_obra { get; set; }
        public Terceiro terceiro { get; set; }

        public Obra() { }

		public void fechamentoObra(DateTime dtfinal)
		{
            return; 
		}

	}

}

