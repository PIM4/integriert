using Model.Entity;
using System;
using System.Collections.Generic;
using Model.DAO.Generico;
using System.Data.SqlClient;
using System.Data;

namespace Model.DAO.Especifico
{
	public class ContaReceberDAO
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

        public bool cadastra(ContaReceber cr)
		{
            query = null;
            try
            {
                query = "INSERT INTO CONTA_RECEBER (DT_CONTA_RECEBER, VALOR, ID_COND, ID_UNIDADE, STS_ATIVO) VALUES ('"
                        + (cr.data).ToShortDateString() + "', " 
                        + (cr.valor).ToString() + ", " 
                        + (cr.condominio.id_cond).ToString()  + ", " 
                        + (cr.unidade.id_unidade).ToString() + ", 1;";
                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }	
        }

		public List<ContaReceber> buscaPorValor(int v1, int v2)
		{
            query = null;
            List<ContaReceber> lstCR = new List<ContaReceber>();
            try
            {
                query = "SELECT U.IDENTIFICACAO, CR.DT_CONTA_RECEBER, CR.VALOR FROM CONTA_RECEBER AS CR "
                        + "INNER JOIN UNIDADE AS U ON U.ID_UNIDADE = CR.ID_UNIDADE "
                        + "WHERE CR.VALOR BETWEEN " + v1.ToString() + " AND " + v2.ToString() + " AND CR.STS_ATIVO = 1 ORDER BY CR.DT_PAGTO DESC;";
                lstCR = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstCR;
        }

		public List<ContaReceber> buscaPorData(DateTime dt1, DateTime dt2)
		{
            query = null;
            List<ContaReceber> lstCR = new List<ContaReceber>();
            try
            {
                query = "SELECT U.IDENTIFICACAO, CR.DT_CONTA_RECEBER, CR.VALOR FROM CONTA_RECEBER AS CR "
                        + "INNER JOIN UNIDADE AS U ON U.ID_UNIDADE = CR.ID_UNIDADE "
                        + "WHERE CR.DT_CONTA_RECEBER BETWEEN " + dt1.ToShortDateString() + " AND " + dt2.ToShortDateString() + " AND CR.STS_ATIVO = 1 ORDER BY CP.DT_CONTA_RECEBER DESC;";
                lstCR = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstCR;
        }		

		public List<ContaReceber> buscaPorUnidade(Unidade unidade)
		{
            query = null;
            List<ContaReceber> lstCR = new List<ContaReceber>();
            try
            {
                query = "SELECT U.IDENTIFICACAO, CR.DT_CONTA_RECEBER, CR.VALOR FROM CONTA_RECEBER AS CR "
                        + "INNER JOIN UNIDADE AS U ON U.ID_UNIDADE = CR.ID_UNIDADE "
                        + "WHERE CR.ID_UNIDADE = " + unidade.id_unidade.ToString() + " AND CR.STS_ATIVO = 1 ORDER BY CR.DT_CONTA_RECEBER DESC;";
                lstCR = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstCR;
        }

		public List<ContaReceber> busca()
		{
            query = null;
            List<ContaReceber> lstCR = new List<ContaReceber>();
            try
            {
                query = "SELECT U.IDENTIFICACAO, CR.DIA_PAGTO, CR.VALOR FROM CONTA_RECEBER AS CR "
                        + "INNER JOIN UNIDADE AS U ON U.ID_UNIDADE = CR.ID_UNIDADE "
                        + "WHERE CR.STS_ATIVO = 1 ORDER BY CR.DIA_PAGTO DESC;";
                lstCR = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstCR;
        }

		public bool remove(int id)
		{
            query = null;
            try
            {
                query = "UPDATE CONTA_RECEBER SET STS_ATIVO = 0 WHERE ID_CONTA_RECEBER = " + id.ToString() + ";";
                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        
        #region DSTV

        //public List<ContaReceber> buscaPorCondominio(Condominio condominio)
        //{
        //    query = null;
        //    List<ContaReceber> lstCR = new List<ContaReceber>();
        //    try
        //    {
        //        query = "SELECT TC.DESCRICAO, F.RAZAO_SOCIAL, CP.VALOR, CP.DT_PAGTO FROM CONTA_PAGAR AS CP "
        //                + "INNER JOIN TIPO_CONTA AS TC ON CP.ID_TIPO_CONTA = TC.ID_TIPO_CONTA "
        //                + "INNER JOIN FORNECEDOR AS F ON CP.ID_FORNECEDOR = F.ID_FORNECEDOR "
        //                + "WHERE  AND CP.STS_ATIVO = 1;";
        //        lstCR = setarObjeto(banco.MetodoSelect(query));
        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return lstCR;
        //}		

        #endregion

        #endregion

        #region Métodos

        public List<ContaReceber> setarObjeto(SqlDataReader dr)
        {
            List<ContaReceber> lstCR = new List<ContaReceber>();

            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ContaReceber obj = new ContaReceber();
                        obj.id_cr = Convert.ToInt32(dr["ID_CONTA_RECEBER"].ToString());
                        obj.valor = Convert.ToDecimal(dr["VALOR"].ToString());
                        obj.data = Convert.ToDateTime(dr["DT_CONTA_RECEBER"].ToString());

                        obj.unidade.id_unidade = Convert.ToInt32(dr["ID_UNIDADE"].ToString());
                        obj.unidade.identificacao = Convert.ToString(dr["IDENTIFICACAO"].ToString());

                        obj.condominio.id_cond = Convert.ToInt32(dr["ID_COND"].ToString());

                        lstCR.Add(obj);
                    }
                }
            }

            catch (Exception ex)
            {
                dr.Dispose();
                throw ex;
            }

            return lstCR;
        }

        #endregion
	}

}

