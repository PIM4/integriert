using Model.Entity;
using System.Collections.Generic;
using System;

namespace Model.DAO.Especifico
{
	public class ReclamSugestDAO
	{
        List<ReclamSugest> reclamSugest = new List<ReclamSugest>();

        public bool cadastrar(ReclamSugest RS)
		{
            return true;
		}

		public List<ReclamSugest> listaReclamSugest(int vefiricador)
		{
            return reclamSugest;
        }

		public List<ReclamSugest> buscarReclamPorTitulo(string titulo)
		{
            return reclamSugest;
        }

		public List<ReclamSugest> buscarReclamPorTitulo(Pessoa pessoa)
		{
            return reclamSugest;
        }		

		public List<ReclamSugest> buscarSugestPorData(DateTime dtInicio, DateTime dtFinal)
		{
            return reclamSugest;
        }

		public bool remove(ReclamSugest RS)
		{
            return true;
		}

	}

}

