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

		public List<Obra> buscarObraPorArea(Area area)
		{
            return lstObra;
        }

		public List<Obra> buscarObraPorTipo(string tipo)
		{
            return lstObra;
        }	
		
		public List<Obra> buscarObraPorData(DateTime data)
		{
            return lstObra;
        }

		public List<Obra> buscarObraPorAbertas()
		{
            return lstObra;
        }	

		public List<Obra> buscarObraPorFechadas()
		{
            return lstObra;
        }						

		public List<Obra> listar()
		{
            return lstObra;
        }

		public bool remove()
		{
            return true;
        }

	}

}

