using Model.Entity;
using System.Collections.Generic;

namespace Model.DAO.Especifico
{
	public class VisitanteDAO
	{
        List<Visitante> lstVisitante = new List<Visitante>();
        public bool salva(Visitante visitante)
		{
            return true;
		}

		public List<Visitante> buscarVisitantePorNome(string nome)
		{
            return lstVisitante;

        }

		public List<Visitante> buscarVisitantePorRg(string rg)
		{
            return lstVisitante;

        }

		public List<Visitante> listaVisitante()
		{
            return lstVisitante;

        }

		public bool remove()
		{
            return true;
		}

	}

}

