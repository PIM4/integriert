using Model.Entity;
using System;
using System.Collections.Generic;

namespace Model.DAO.Especifico
{
	public class TelefoneDAO
	{
        List<Telefone> lstTelefone = new List<Telefone>();
		public bool cadastra(Telefone tel)
		{
            return true;
        }

		public bool remove(int id)
		{
            return true;
		}

		public List<Telefone> listaTelefone()
		{
            return this.lstTelefone;
		}

        public bool altera(Telefone tel)
        {
            return true;
        }

    }

}

