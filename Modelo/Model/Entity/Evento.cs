using System;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Entity
{
	public class Evento
    {
        public Evento()
        {

        }

        public Evento(string descEvento, Unidade unidade, int tempMin, Pessoa responsavel, DateTime data)
        {

        }

        #region EVENTO

        public int id_evento { get; set; }

        public string descEvento { get; set; }

        public Unidade unidade { get; set; }

        public List<Area> lstarea { get; set; }            // Verificar

        public Area area { get; set; }

        public int tempoMinParaReserva { get; set; }

        public int limitadorDeAreas { get; set; }      //Verificar

        public Pessoa responsavel { get; set; }

        public DateTime data { get; set; }

        #endregion

        #region AREA_EVENTO



        #endregion

		
	}

}

