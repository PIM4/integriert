using Model.Entity;
using System.Collections.Generic;

namespace Model.DAO.Especifico
{
	public class MoradorDAO
	{
        List<Morador> lstMorador = new List<Morador>();
		public bool cadastra(Morador morador)
		{
            return true;
        }

        public List<Morador> busca()
        {
            return lstMorador;
        }

		public bool remove(int id)
		{
            return true;
        }

        public bool altera(Morador morador)
        {
            return true;
        }


    }

}

