using Model.Entity;
using System.Collections.Generic;
using System;
using Model.DAO.Generico;
using System.Data.SqlClient;

namespace Model.DAO.Especifico
{
	public class ContaPagarDAO
    {
        #region Observações

        //Por padrão, todas as buscas serão WHERE STS_ATIVO = 1, exceto a verificação se já existe o cadastro.
        //O prof Cassiano orientou a implementar o setarObjeto() dessa forma que foi feita, pq todas as classes precisam, com parametros e objetos diferentes. Não vale o trampo de abstrair.

        #endregion

        #region Objetos

        dbBancos banco = new dbBancos();
        string query = null;

        #endregion

        #region CONTAS A PAGAR

        #region CRUD

        public bool cadastra(ContaPagar cp)
		{
            query = null;
            try
            {
                query = "INSERT INTO CONTA_PAGAR (VALOR, DT_PAGTO, ID_TIPO_CONTA, ID_FORNECEDOR, ID_COND, STS_ATIVO) VALUES ("
                        + (cp.valor).ToString() + ", '" + (cp.data).ToShortDateString() + "', " + (cp.id_tipo).ToString()
                        + ", " + (cp.fornecedor.id_fornecedor).ToString() + ", " + (cp.condominio.id_cond).ToString() + ", 1);";
                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }	
        }
        
		public List<ContaPagar> buscaPorData(DateTime dt1, DateTime dt2)
		{
            query = null;
            List<ContaPagar> lstContaPagar = new List<ContaPagar>();
            try
            {
                query = "SELECT TC.DESCRICAO, F.RAZAO_SOCIAL, CP.VALOR, CP.DT_PAGTO FROM CONTA_PAGAR AS CP "
                        + "INNER JOIN TIPO_CONTA AS TC ON CP.ID_TIPO_CONTA = TC.ID_TIPO_CONTA "
                        + "INNER JOIN FORNECEDOR AS F ON CP.ID_FORNECEDOR = F.ID_FORNECEDOR "
                        + "WHERE DT_PAGTO BETWEEN '" + (dt1).ToShortDateString() + "' AND '" + (dt2).ToShortDateString()
                        + "' AND CP.STS_ATIVO = 1;";
                lstContaPagar = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstContaPagar;
        }

		public List<ContaPagar> buscaPorValor(decimal val1, decimal val2)
		{
            query = null;
            List<ContaPagar> lstContaPagar = new List<ContaPagar>();
            try
            {
                query = "SELECT TC.DESCRICAO, F.RAZAO_SOCIAL, CP.VALOR, CP.DT_PAGTO FROM CONTA_PAGAR AS CP "
                        + "INNER JOIN TIPO_CONTA AS TC ON CP.ID_TIPO_CONTA = TC.ID_TIPO_CONTA "
                        + "INNER JOIN FORNECEDOR AS F ON CP.ID_FORNECEDOR = F.ID_FORNECEDOR "
                        + "WHERE VALOR BETWEEN '" + (val1).ToString() + "' AND '" + (val2).ToString() + "' " 
                        + "AND CP.STS_ATIVO = 1;";
                lstContaPagar = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstContaPagar;
        }

        public List<ContaPagar> buscaPorTipo(int tipo)
        {
            query = null;
            List<ContaPagar> lstContaPagar = new List<ContaPagar>();
            try
            {
                query = "SELECT TC.DESCRICAO, F.RAZAO_SOCIAL, CP.VALOR, CP.DT_PAGTO FROM CONTA_PAGAR AS CP "
                        + "INNER JOIN TIPO_CONTA AS TC ON CP.ID_TIPO_CONTA = TC.ID_TIPO_CONTA "
                        + "INNER JOIN FORNECEDOR AS F ON CP.ID_FORNECEDOR = F.ID_FORNECEDOR "
                        + "WHERE CP.STS_ATIVO = 1 AND CP.TIPO = " + (tipo).ToString() + ";";
                lstContaPagar = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstContaPagar;
        }

        //public List<ContaPagar> buscaPorFornecedor(Fornecedor fornecedor)
        //{
        //    query = null;
        //    List<ContaPagar> lstContaPagar = new List<ContaPagar>();
        //    try
        //    {
        //        query = "SELECT F.RAZAO_SOCIAL, CP.DT_PAGTO, CP.VALOR, TC.DESCRICAO FROM CONTA_PAGAR AS CP "
        //                + "INNER JOIN FORNECEDOR AS F ON F.ID_FORNECEDOR = CP.ID_FORNECEDOR "
        //                + "INNER JOIN TIPO_CONTA AS TC ON TC.ID_TIPO_CONTA = CP.ID_TIPO_CONTA "
        //                + "WHERE F.RAZAO_SOCIAL LIKE '%" + fornecedor.nomeEmpresa + "%';";
        //        lstContaPagar = setarObjeto(banco.MetodoSelect(query));
        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return lstContaPagar;
        //}

		public List<ContaPagar> buscaContaPagar()
		{
            query = null;
            List<ContaPagar> lstContaPagar = new List<ContaPagar>();
            try
            {
                query = "SELECT TC.DESCRICAO, F.RAZAO_SOCIAL, CP.VALOR, CP.DT_PAGTO FROM CONTA_PAGAR AS CP "
                        + "INNER JOIN TIPO_CONTA AS TC ON CP.ID_TIPO_CONTA = TC.ID_TIPO_CONTA "
                        + "INNER JOIN FORNECEDOR AS F ON CP.ID_FORNECEDOR = F.ID_FORNECEDOR "
                        + "WHERE CP.STS_ATIVO = 1;";
                lstContaPagar = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstContaPagar;
        }

        public bool altera(ContaPagar cp)
        {
            query = null;
            try
            {
                query = "UPDATE CONTA_PAGAR SET VALOR = " + (cp.valor).ToString() + ", DT_PAGTO = '" + (cp.data).ToShortDateString()
                        + "', ID_TIPO_CONTA = " + (cp.id_tipo).ToString() + ", ID_COND = " + (cp.condominio.id_cond).ToString() + ";";
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
                query = "UPDATE CONTA_PAGAR SET STS_ATIVO = 0 WHERE ID_CONTA_PAGAR = " + id.ToString() + ";";
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

        #endregion

        #region TIPO DE CONTA

        #region CRUD

        public List<ContaPagar> buscaTipoPorDescricao(ContaPagar tipo)
        {
            query = null;
            List<ContaPagar> lstTipos = new List<ContaPagar>();
            try
            {
                query = "SELECT DESCRICAO FROM TIPO_CONTA WHERE DESCRICAO LIKE '%" + tipo.desc_conta + "%' "
                        + " AND STS_ATIVO = 1;";
                lstTipos = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstTipos;
        }

        public List<ContaPagar> buscaTipo()
        {
            query = null;
            List<ContaPagar> lstTipos = new List<ContaPagar>();
            try
            {
                query = "SELECT DESCRICAO FROM TIPO_CONTA WHERE STS_ATIVO = 1;";
                lstTipos = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstTipos;
        }

        #endregion

        #endregion

        #region Métodos

        public List<ContaPagar> setarObjeto(SqlDataReader dr)
        {
            ContaPagar obj = new ContaPagar();
            List<ContaPagar> lstCP = new List<ContaPagar>();

            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        obj.id_cp = Convert.ToInt32(dr["ID_CONTA_PAGAR"].ToString());
                        obj.valor = Convert.ToDecimal(dr["VALOR"].ToString());
                        obj.data = Convert.ToDateTime(dr["DT_PAGTO"].ToString());

                        obj.id_tipo = Convert.ToInt32(dr["ID_TIPO_CONTA"].ToString());
                        obj.desc_conta = Convert.ToString(dr["DESCRICAO"].ToString());

                        obj.fornecedor.id_fornecedor = Convert.ToInt32(dr["ID_FORNECEDOR"].ToString());
                        obj.fornecedor.nomeEmpresa = Convert.ToString(dr["RAZAO_SOCIAL"].ToString());

                        obj.condominio.id_cond = Convert.ToInt32(dr["ID_COND"].ToString());

                        lstCP.Add(obj);
                    }
                }

                //for (int idx = 0; idx < dr.FieldCount; idx++)
                //{
                //    dr.GetName(idx).ToString();

                //    switch (dr.GetName(idx).ToUpper())
                //    {
                //        case "DESCRICAO":
                //            obj.desc_conta = Convert.ToString(dr[idx]);
                //            break;
                //        case "RAZAO_SOCIAL":
                //            obj.fornecedor.nomeEmpresa = Convert.ToString(dr[idx]);
                //            break;
                //        case "VALOR":
                //            obj.valor = Convert.ToDecimal(dr[idx]);
                //            break;
                //        case "DT_PAGTO":
                //            obj.data = Convert.ToDateTime(dr[idx]);
                //            break;
                //        case "ID_FORNECEDOR":
                //            obj.fornecedor.id_fornecedor = Convert.ToInt32(dr[idx]);
                //            break;
                //        case "ID_TIPO_CONTA":
                //            obj.id_tipo = Convert.ToInt32(dr[idx]);
                //            break;
                //    }
                //}
            }

            catch (Exception ex)
            {
                dr.Dispose();
                throw ex;
            }

            return lstCP;
        }

        #endregion
    }
}

