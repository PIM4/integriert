using Model.Entity;
using System.Collections.Generic;
using System;
using Model.DAO.Generico;
using System.Data;
using System.Data.SqlClient;

namespace Model.DAO.Especifico
{
	public class CondominioDAO
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

        public bool cadastra(Condominio condominio)
		{
            query = null;
            try
            {
                query = "INSERT INTO CONDOMINIO (DT_INAUGURACAO, PROPRIETARIO, CNPJ, STS_ATIVO, NOME_COND, ID_ENDERECO) VALUES ('"
                        //+ condominio.nome + "', '" 
                        + (condominio.dataInauguracao.ToString()) + "', '"
                        + condominio.proprietario + "', '" 
                        + condominio.cnpj + "', 1, '" 
                        + condominio.nome + "', " 
                        + condominio.endereco.id_endereco.ToString() + ");";
                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public List<Condominio> busca()
        {
            query = null;
            List<Condominio> lstCond = new List<Condominio>();
            try
            {

                query = "SELECT * FROM CONDOMINIO WHERE STS_ATIVO = 1;";

                lstCond = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstCond;
        }

        public bool altera(Condominio condominio)
        {
            query = null;
            try
            {
                query = "UPDATE CONDOMINIO SET " 
                        + "NOME_COND = '" + condominio.nome 
                        + "', PROPRIETARIO = '" + condominio.proprietario 
                        + "', CNPJ = '" + condominio.cnpj 
                        + "' WHERE ID_COND = " + (condominio.id_cond).ToString() + ";";
                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

		public bool remove(int id)      //Implementar opção de bkp, exclusão!
		{
            query = null;
            try
            {
                query = "UPDATE CONDOMINIO SET STS_ATIVO = 0 WHERE ID_COND = " + id.ToString() + ";";
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

        //public bool verificaCadastro()  //Verifica se ja existe algum condominio cadastrado. utilizar o COUNT()
        //{

        //    return false;
        //}

        //public List<Condominio> buscaPorNome(string nome)
        //{
        //    query = null;
        //    List<Condominio> lstCondominio = new List<Condominio>();
        //    try
        //    {
        //        query = "SELECT NOME, DT_INAUGURACAO, PROPRIETARIO, CNPJ FROM CONDOMINIO WHERE STS_ATIVO = 1 AND NOME LIKE '%"
        //            + nome + "%'";
        //        lstCondominio.Add(setarObjeto(banco.MetodoSelect(query)));
        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return lstCondominio;	
        //} //Verificar...

        //public int buscaNome()   //Método personalizado. NAO TEM QUE RETORNAR LISTA!
        //{
        //    query = null;
        //    Condominio cond = new Condominio();
        //    try
        //    {
        //        query = "SELECT NOME FROM CONDOMINIO WHERE STS_ATIVO = 1";
        //        cond = setarObjeto(banco.MetodoSelect(query));
        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return cond.id_cond;
        //}

        #endregion

        #endregion

        #region Métodos

        public List<Condominio> setarObjeto(SqlDataReader dr)
        {
            List<Condominio> lstCond = new List<Condominio>();
            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Condominio obj = new Condominio();
                        obj.id_cond = Convert.ToInt32(dr["ID_COND"].ToString());
                        obj.nome = Convert.ToString(dr["NOME_COND"].ToString());
                        obj.proprietario = Convert.ToString(dr["PROPRIETARIO"].ToString());
                        obj.cnpj = Convert.ToString(dr["CNPJ"].ToString());
                        obj.dataInauguracao = Convert.ToDateTime(dr["DT_INAUGURACAO"].ToString());
                        obj.ativo = Convert.ToBoolean(dr["STS_ATIVO"].ToString());

                        obj.endereco = new Endereco();
                        obj.endereco.id_endereco = Convert.ToInt32(dr["ID_ENDERECO"].ToString());
                        //obj.endereco.logradouro = Convert.ToString(dr[]);

                        lstCond.Add(obj);
                    }
                }
            }

            catch (Exception ex)
            {
                dr.Dispose();
                throw ex;
            }

            return lstCond;
        }

        #endregion
	}

}

