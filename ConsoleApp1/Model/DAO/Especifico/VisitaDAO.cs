using Model.Entity;
using System.Collections.Generic;
using System;

namespace Model.DAO.Especifico
{
	public class VisitaDAO
	{
        List<Visita> lstVisita = new List<Visita>();
		public bool salva(Visita visita)
		{
            return true;
		}

		public List<Visita> buscaVisitaPorData(DateTime dt1, DateTime dt2)
		{
            return this.lstVisita;

        }

		public List<Visita> buscaVisitaPorUnidade(Unidade unidade)
		{
            return this.lstVisita;
        }

		public List<Visita> listaVisita()
		{
            return this.lstVisita;
        }

		public bool remove()
		{
            return true;
		}

	}

}

