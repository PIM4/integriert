using Model.Entity;
using System.Collections.Generic;

namespace Model.DAO.Especifico
{
	public class TerceiroDAO
	{
        List<Terceiro> lstTerceiro = new List<Terceiro>();
		public bool cadastra(Terceiro terceiro)
		{
            return true;
		}

		public bool remove(int id)
		{
            return true;
        }

        public bool altera( Terceiro terceiro)
        {
            return true;
        }
        public List< Terceiro > busca()
        {
            
            return lstTerceiro;
        }

    }

}

