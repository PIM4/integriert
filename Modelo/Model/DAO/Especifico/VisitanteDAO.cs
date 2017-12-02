using Model.Entity;
using System.Collections.Generic;

namespace Model.DAO.Especifico
{
	public class VisitanteDAO
	{
        List<Visitante> lstVisitante = new List<Visitante>();
        public bool cadastra(Visitante visitante)
		{
            return true;
		}

		public List<Visitante> buscaPorNome(string nome)
		{
            return lstVisitante;

        }

		public List<Visitante> buscaPorRg(string rg)
		{
            return lstVisitante;

        }

		public List<Visitante> busca()
		{
            return lstVisitante;

        }

		public bool remove(int id)
		{
            return true;
		}

        public bool altera(Visitante visitante)
        {
            return true;
        }

    }

}

