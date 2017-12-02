using Model.Entity;
using System;
using System.Collections.Generic;

namespace Model.DAO.Especifico
{
	public class FornecedorDAO
	{
        List<Fornecedor> lstFornecedor = new List<Fornecedor>();
		public bool cadastra(Fornecedor fornecedor)
		{
            return true;
        }

		public List<Fornecedor> buscaPorNome(string nome)
		{
            return lstFornecedor;
        }		

		public List<Fornecedor> buscaPorRamo(string ramo)
		{
            return lstFornecedor;
        }		

		public List<Fornecedor> buscaPorCNPJ(string cnpj)
		{
	        return lstFornecedor;
        }

		public List<Fornecedor> busca()
		{
            return lstFornecedor;
        }

		public bool remove(int id)
		{
            return true;
        }

        public bool altera(Fornecedor fornecedor)
        {
            return true;
        }

    }

}

