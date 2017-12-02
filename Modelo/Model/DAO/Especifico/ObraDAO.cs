using Model.Entity;
using System.Collections.Generic;
using System;

namespace Model.DAO.Especifico
{
	public class ObraDAO
	{
        List<Obra> lstObra = new List<Obra>();
		public bool cadastra(Obra obra)
		{
            return true; 
        }

		public List<Obra> buscaPorArea(Area area)
		{
            return lstObra;
        }

		public List<Obra> buscaPorTipo(string tipo)
		{
            return lstObra;
        }	
		
		public List<Obra> buscaPorData(DateTime data)
		{
            return lstObra;
        }

		public List<Obra> buscaPorAbertas()
		{
            return lstObra;
        }	

		public List<Obra> buscaPorFechadas()
		{
            return lstObra;
        }						

		public List<Obra> busca()
		{
            return lstObra;
        }

		public bool remove(int id)
		{
            return true;
        }

        public bool altera(Obra obra)
        {
            return true;
        }

    }

}

