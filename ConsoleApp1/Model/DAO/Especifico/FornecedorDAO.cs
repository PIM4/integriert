using Model.Entity;
using System;
using System.Collections.Generic;

namespace Model.DAO.Especifico
{
	public class FornecedorDAO
	{
        List<Fornecedor> lstFornecedor = new List<Fornecedor>();
		public bool salva(Fornecedor fornecedor)
		{
            return true;
        }

		public List<Fornecedor> buscarFornecedorPorNome(string nome)
		{
            return lstFornecedor;
        }		

		public List<Fornecedor> buscarFornecedorPorRamo(string ramo)
		{
            return lstFornecedor;
        }		

		public List<Fornecedor> buscarFornecedorPorCNPJ(string cnpj)
		{
	        return lstFornecedor;
        }

		public List<Fornecedor> listaFornecedor()
		{
            return lstFornecedor;
        }

		public bool remove()
		{
            return true;
        }

	}

}

