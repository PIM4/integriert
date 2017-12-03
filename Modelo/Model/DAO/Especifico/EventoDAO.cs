using Model.Entity;
using System.Collections.Generic;
using System;
using Model.DAO.Generico;
using System.Data.SqlClient;

namespace Model.DAO.Especifico
{
	public class EventoDAO
	{
        #region Observações

        //Por padrão, todas as buscas serão WHERE STS_ATIVO = 1, exceto a verificação se já existe o cadastro.
        //O prof Cassiano orientou a implementar o setarObjeto() dessa forma que foi feita, pq todas as classes precisam, com parametros e objetos diferentes. Não vale o trampo de abstrair.

        #endregion

        #region Objetos
        List<Evento> lstEvento = new List<Evento>();
        dbBancos banco = new dbBancos();
        string query = null;

        #endregion

        #region CRUD

        public bool cadastraEvento(Evento ev)
		{
            query = null;
            try
            {
                query = "INSERT INTO EVENTO (TITULO, ID_UNIDADE, STS_ATIVO, DT_EVENTO) VALUES ('"
                        + ev.descEvento + "', " 
                        + ev.unidade.id_unidade.ToString()
                        + ", 1, '"
                        + ev.data.ToShortDateString() + "';";
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            } 
		}

        public bool cadastraAreaEvento(Evento ev)
        {
            query = null;
            try
            {
                query = "INSERT INTO AREA_EVENTO (ID_EVENTO, ID_AREA, STS_ATIVO, DT_EVENTO) VALUES ("
                        + ev.id_evento.ToString() + ", "
                        + ev.area.id_area.ToString() 
                        + ", 1;";
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

		public List<Evento> buscaPorData(DateTime dt1, DateTime dt2)
		{
            query = null;
            List<Evento> lstEvento = new List<Evento>();
            try
            {
                query = "SELECT E.DT_EVENTO, E.TITULO, U.IDENTIFICACAO FROM EVENTO AS E "
                        + "INNER JOIN UNIDADE AS U ON E.ID_UNIDADE = U.ID_UNIDADE "
                        + "WHERE E.DT_EVENTO BETWEEN '" + dt1.ToString() 
                        + "' AND '" + dt2.ToString() + "' AND E.STS_ATIVO = 1;";
                lstEvento = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstEvento;
        }		

		public List<Evento> buscaPorArea(Area area)     //Verificaar
		{
            query = null;
            List<Evento> lstEvento = new List<Evento>();
            try
            {
                query = "SELECT E.DT_EVENTO, E.TITULO, U.IDENTIFICACAO FROM EVENTO AS E "
                        + "INNER JOIN UNIDADE AS U ON E.ID_UNIDADE = U.ID_UNIDADE "
                        + "";
                lstEvento = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstEvento;
        }

		public List<Evento> buscaPorResponsavel(string resp)
		{
            query = null;
            List<Evento> lstEvento = new List<Evento>();
            try
            {
                query = "SELECT E.DT_EVENTO, E.TITULO, U.IDENTIFICACAO FROM EVENTO AS E "
                        + "INNER JOIN UNIDADE AS U ON E.ID_UNIDADE = U.ID_UNIDADE "
                        + "WHERE U.IDENTIFICACAO = '" + resp + "' AND E.STS_ATIVO = 1;";
                lstEvento = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstEvento;
        }	

		//public List<Evento> buscaPorUnidade(Unidade unidade)
		//{
  //          return this.lstEvento;
  //      }			

		public List<Evento> busca()
		{
            query = null;
            List<Evento> lstEvento = new List<Evento>();
            try
            {
                query = "SELECT E.DT_EVENTO, E.TITULO, U.IDENTIFICACAO FROM EVENTO AS E "
                        + "INNER JOIN UNIDADE AS U ON E.ID_UNIDADE = U.ID_UNIDADE "
                        + "WHERE E.STS_ATIVO = 1";
                lstEvento = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstEvento;
        }

        public List<Evento> buscaAreaEvento(Evento evento)
        {
            query = null;
            List<Evento> lstEvento = new List<Evento>();
            try
            {
                query = "SELECT A.NOME FROM AREA AS A " +
                        "INNER JOIN AREA_EVENTO AS AE ON AE.ID_AREA = A.AREA" +
                        "INNER JOIN EVENTO AS E ON E.ID_EVENTO = AE.ID_EVENTO" +
                        "WHERE AE.STS_ATIVO = 1 " +
                        "AND E.ID_EVENTO = " + evento.id_evento.ToString() + "" +
                        "AND E.STS_ATIVO = 1;";
                lstEvento = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstEvento;
        }

        public bool altera(Evento evento)
        {
            query = null;
            try
            {
                query = "UPDATE EVENTO SET TITULO = '" + evento.descEvento
                        + "', DT_EVENTO = '" + evento.data.ToString() + "' "
                        + "WHERE ID_EVENTO = " + evento.id_evento.ToString() + ";";
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
                query = "UPDATE EVENTO SET STS_ATIVO = 0 WHERE ID_EVENTO = "
                        + (id).ToString() + ";";
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

        public List<Evento> setarObjeto(SqlDataReader dr)
        {
            List<Evento> lstEvento = new List<Evento>();
            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Evento obj = new Evento();

                        obj.id_evento = Convert.ToInt32(dr["ID_EVENTO"].ToString());
                        obj.descEvento = Convert.ToString(dr["TITULO"].ToString());
                        obj.data = Convert.ToDateTime(dr["DT_EVENTO"].ToString());
                        obj.ativo = Convert.ToInt32(dr["STS_ATIVO"].ToString());        //verificar

                        obj.id_area_evento = Convert.ToInt32(dr["ID_AREA_EVENTO"].ToString());

                        obj.unidade.id_unidade = Convert.ToInt32(dr["ID_UNIDADE"].ToString());
                        obj.unidade.identificacao = Convert.ToString(dr["IDENTIFICACAO"].ToString());

                        obj.area.id_area = Convert.ToInt32(dr["ID_AREA"].ToString());
                        obj.area.nome = Convert.ToString(dr["NOME"].ToString());
                    }
                }
            }

            catch (Exception ex)
            {
                dr.Dispose();
                throw ex;
            }

            return lstEvento;
        }

        #endregion

    }

}

