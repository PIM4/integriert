using Model.Entity;
using System;
using System.Collections.Generic;
using Model.DAO.Generico;
using System.Data.SqlClient;

namespace Model.DAO.Especifico
{
	public class FornecedorDAO
	{
        #region Observações

        //Por padrão, todas as buscas serão WHERE STS_ATIVO = 1, exceto a verificação se já existe o cadastro.
        //O prof Cassiano orientou a implementar o setarObjeto() dessa forma que foi feita, pq todas as classes precisam, com parametros e objetos diferentes. Não vale o trampo de abstrair.

        #endregion

        #region Objetos

        dbBancos banco = new dbBancos();
        string query = null;

        #endregion

        #region CRUD

		public bool cadastra(Fornecedor fornecedor)
		{
            query = null;
            try
            {
                query = "INSERT INTO FORNECEDOR (RAMO_ATV, CNPJ, STS_ATIVO, RAZAO_SOCIAL) VALUES ('" +
                        fornecedor.ramo + "', '" +
                        fornecedor.cnpj + "', 1, '" +
                        fornecedor.nomeEmpresa + "';";
                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

		public List<Fornecedor> buscaPorNome(string nome)
		{
            query = null;
            List<Fornecedor> lstFornecedores = new List<Fornecedor>();
            try
            {
                query = "SELECT * FROM FORNECEDOR WHERE RAZAO_SOCIAL LIKE '%" 
                    + nome + "%' AND STS_ATIVO = 1;";
                lstFornecedores = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstFornecedores;
        }		

		public List<Fornecedor> buscaPorRamo(string ramo)
		{
            query = null;
            List<Fornecedor> lstFornecedores = new List<Fornecedor>();
            try
            {
                query = "SELECT * FROM FORNECEDOR WHERE RAMO_ATV LIKE '%"
                    + ramo + "%' AND STS_ATIVO = 1;";
                lstFornecedores = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstFornecedores;
        }		

		public List<Fornecedor> buscaPorCNPJ(string cnpj)
		{
            query = null;
            List<Fornecedor> lstFornecedores = new List<Fornecedor>();
            try
            {
                query = "SELECT * FROM FORNECEDOR WHERE CNPJ LIKE '%"
                    + cnpj + "%' AND STS_ATIVO = 1;";
                lstFornecedores = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstFornecedores;
        }

		public List<Fornecedor> busca()
		{
            query = null;
            List<Fornecedor> lstFornecedores = new List<Fornecedor>();
            try
            {
                query = "SELECT * FROM FORNECEDOR WHERE STS_ATIVO = 1;";
                lstFornecedores = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstFornecedores;
        }

        public bool altera(Fornecedor fornecedor)
        {
            query = null;
            try
            {
                query = "UPDATE FORNECEDOR SET RAMO_ATV = '" + fornecedor.ramo +
                        "', CNPJ = '" + fornecedor.cnpj + 
                        "', STS_ATIVO = 1, " +
                        " RAZAO_SOCIAL = '" + fornecedor.nomeEmpresa + 
                        "' WHERE ID_FORNECEDOR = " + fornecedor.id_fornecedor.ToString() + ";";
                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool remove(int id)
		{
            query = null;
            try
            {
                query = "UPDATE FORNECEDOR SET STS_ATIVO = 0 WHERE ID_FORNECEDOR = " + id.ToString() + ";"; 
                banco.MetodoNaoQuery(query); 
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        
        #endregion

        #region Métodos

        public List<Fornecedor> setarObjeto(SqlDataReader dr)
        {
            List<Fornecedor> lstFornecedores = new List<Fornecedor>();

            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Fornecedor obj = new Fornecedor();
                        obj.id_fornecedor = Convert.ToInt32(dr["ID_FORNECEDOR"].ToString());
                        obj.ramo = Convert.ToString(dr["RAMO_ATV"].ToString());
                        obj.cnpj = Convert.ToString(dr["CNPJ"].ToString());
                        obj.ativo = Convert.ToInt32(dr["STS_ATIVO"].ToString());
                        obj.nomeEmpresa = Convert.ToString(dr["RAZAO_SOCIAL"].ToString());

                        lstFornecedores.Add(obj);
                    }
                }
            }

            catch (Exception ex)
            {
                dr.Dispose();
                throw ex;
            }

            return lstFornecedores;
        }

        #endregion

    }

}

