using Model.Entity;
using System.Collections.Generic;
using System;

namespace Model.DAO.Especifico
{
	public class ReclamSugestDAO
	{
        List<ReclamSugest> reclamSugest = new List<ReclamSugest>();

        public bool cadastra(ReclamSugest RS)
		{
            return true;
		}

		public List<ReclamSugest> busca()
		{
            return reclamSugest;
        }

		public List<ReclamSugest> buscaPorTitulo(string titulo)
		{
            return reclamSugest;
        }

		public List<ReclamSugest> buscaPorTitulo(Pessoa pessoa)
		{
            return reclamSugest;
        }		

		public List<ReclamSugest> buscaPorData(DateTime dtInicio, DateTime dtFinal)
		{
            return reclamSugest;
        }

        public bool remove(ReclamSugest RS)
        {
            return true;
        }

    }

}

