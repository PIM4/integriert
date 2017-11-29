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

		public bool remove()
		{
            return true;
		}

		public List<Telefone> listaTelefone()
		{
            return this.lstTelefone;
		}		

	}

}

