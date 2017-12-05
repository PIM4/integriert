using Model.Entity;
using System.Collections.Generic;
using System;
using Model.DAO.Generico;
using System.Data.SqlClient;

namespace Model.DAO.Especifico  
{
	public class AvisoDAO
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

        public bool cadastra(Aviso aviso)
		{
            query = null;

            try
            {

                query = "INSERT INTO AVISO (TITULO, DESCRICAO, DT_AVISO, ID_COND, STS_ATIVO) VALUES ('" + aviso.titulo + "', '"
                        + aviso.descricao + "', '" 
                        + (aviso.data).ToShortDateString() + "', "
                        + (aviso.cond.id_cond).ToString() 
                        + ", 1);";

                banco.MetodoNaoQuery(query);
                return true;
            }

            catch(Exception ex)
            {
                return false;
                throw ex;
            }
		}

		public List<Aviso> buscaPorData(DateTime dtinicio, DateTime dtfinal)
		{
            query = null;
            List<Aviso> lstAviso = new List<Aviso>();
            try
            {
                query = "SELECT A.ID_AVISO, A.TITULO, A.DESCRICAO, A.DT_AVISO, A.STS_ATIVO, C.ID_COND, C.NOME_COND FROM AVISO AS A "
                        + " INNER JOIN CONDOMINIO AS C ON A.ID_COND = C.ID_COND "                     
                        + " WHERE A.STS_ATIVO = 1 AND A.DT_AVISO BETWEEN '" + dtinicio 
                        + "' AND '" + (dtfinal).ToString() + "';";        
                lstAviso = setarObjeto(banco.MetodoSelect(query));
            }

            catch(Exception ex)
            {
                throw ex;
            }

            return lstAviso;
        }

		public List<Aviso> buscaPorTitulo(string titulo)
		{
            query = null;
            List<Aviso> lstAviso = new List<Aviso>();
            try
            {
                query = "SELECT A.ID_AVISO, A.TITULO, A.DESCRICAO, A.DT_AVISO, A.STS_ATIVO, C.ID_COND, C.NOME_COND FROM AVISO AS A "
                         + " INNER JOIN CONDOMINIO AS C ON A.ID_COND = C.ID_COND "
                         + " WHERE A.STS_ATIVO = 1 AND A.TITULO LIKE '%" + titulo + "%';";   
                lstAviso = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstAviso;
        }

		public List<Aviso> buscaPorCondominio(string condominio)
		{
            query = null;
            List<Aviso> lstAviso = new List<Aviso>();
            try
            {
                query = "SELECT A.ID_AVISO, A.TITULO, A.DESCRICAO, A.DT_AVISO, A.STS_ATIVO, C.ID_COND, C.NOME_COND FROM AVISO AS A "
                        + " INNER JOIN CONDOMINIO AS C ON A.ID_COND = C.ID_COND "
                        + " WHERE A.STS_ATIVO = 1 AND C.NOME_COND LIKE '%" + condominio + "%';";   
                lstAviso = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstAviso;
        }

		public List<Aviso> busca()
		{
            query = null;
            List<Aviso> lstAviso = new List<Aviso>();
            try
            {
                query = "SELECT A.ID_AVISO, A.TITULO, A.DESCRICAO, A.DT_AVISO, A.STS_ATIVO, C.ID_COND, C.NOME_COND FROM AVISO AS A "
                        + " INNER JOIN CONDOMINIO AS C ON A.ID_COND = C.ID_COND "
                        + " WHERE A.STS_ATIVO = 1;";
                lstAviso = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstAviso;
        }

        public bool altera(Aviso aviso)
        {
            query = null;
            try
            {   
                query = "UPDATE AVISO " 
                        + " SET TITULO = '" + aviso.titulo 
                        + "', DESCRICAO = '" + aviso.descricao 
                        + "' WHERE ID_AVISO = " + (aviso.id_aviso).ToString() + ";";
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
                query = "UPDATE AVISO SET STS_ATIVO = 0 WHERE ID_AVISO = " + id.ToString() + ";";
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

        public List<Aviso> setarObjeto(SqlDataReader dr)
        {
            List<Aviso> lstAviso = new List<Aviso>();
            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Aviso obj = new Aviso();
                        obj.id_aviso = Convert.ToInt32(dr["ID_AVISO"].ToString());
                        obj.titulo = Convert.ToString(dr["TITULO"].ToString());
                        obj.descricao = Convert.ToString(dr["DESCRICAO"].ToString());
                        obj.data = Convert.ToDateTime(dr["DT_AVISO"].ToString());
                        obj.ativo = Convert.ToBoolean(dr["STS_ATIVO"].ToString());
                        obj.cond = new Condominio();
                        obj.cond.id_cond = Convert.ToInt32(dr["ID_COND"].ToString());
                        obj.cond.nome = Convert.ToString(dr["NOME_COND"].ToString());

                        lstAviso.Add(obj);
                    }
                }
            }

            catch (Exception ex)
            {
                dr.Dispose();
                throw ex;
            }

            return lstAviso;
        }

        #endregion
    }
 }

