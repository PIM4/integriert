using Model.Entity;
using System.Collections.Generic;

namespace Model.DAO.Especifico
{
	public class UnidadeDAO
	{
        List<Unidade> lstUnidade = new List<Unidade>();
		public bool cadastra(Unidade unidade)
		{
            return true;
		}

		//public Unidade buscaUnidadePorID(string id)
		//{
		//	reutnr 
		//}

		public List<Unidade> busca()
		{
            return lstUnidade;
        }

		public bool remove(int id)
		{
            return true;
        }

        public bool altera(Unidade unidade)
        {
            return true;
        }

    }

}

