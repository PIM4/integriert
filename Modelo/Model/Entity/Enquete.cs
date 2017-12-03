using System;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Entity
{
	public class Enquete
    {
        #region ENQUETE

        public int id_enquete { get; set; }

        public string pergunta { get; set; }

        public DateTime dtInicio { get; set; }

        public DateTime dtFim { get; set; }

        public Condominio condominio { get; set; }

        public int enq_ativo { get; set; }

        #endregion

        #region ENQUETE_ALTERNATIVAS

        public int id_enquete_alt { get; set; }

        public string textoAlt { get; set; }

        #endregion

        #region VOTO

        public int id_voto { get; set; }

        public int voto { get; set; }

        public List<string> opVotos { get; set; }

        public Pessoa pessoa { get; set; }

        #endregion

        #region Construtores

        public Enquete(string pergunta, string dtInicio, string dtFim, List<string> opVotos)
		{

		}
        public Enquete()
        {

        }

        #endregion
    }
}

