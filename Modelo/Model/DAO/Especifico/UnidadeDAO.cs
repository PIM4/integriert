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

		public List<Unidade> listaUnidade()
		{
            return lstUnidade;
        }

		public bool remove()
		{
            return true;
        }

	}

}

