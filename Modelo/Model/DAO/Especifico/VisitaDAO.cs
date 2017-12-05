using Model.Entity;
using System.Collections.Generic;
using System;
using Model.DAO.Generico;
using System.Data.SqlClient;

namespace Model.DAO.Especifico
{
	public class VisitaDAO
	{
        #region Observações

        //Por padrão, todas as buscas serão WHERE STS_ATIVO = 1, exceto a verificação se já existe o cadastro.
        //O prof Cassiano orientou a implementar o setarObjeto() dessa forma que foi feita, pq todas as classes precisam, com parametros e objetos diferentes. Não vale o trampo de abstrair.
        // lstArea apenas recebe a outra lista pra nao sair do try catch;
        #endregion

        #region Objetos

        dbBancos banco = new dbBancos();
        string query = null;

        #endregion

        #region CRUD

        List<Visita> lstVisita = new List<Visita>();
		public bool cadastra(Visita visita)
		{
            query = null;
            try
            {
                query = "INSERT INTO VISITA (DT_INICIO, DT_FINAL, ID_VISITANTE, ID_UNIDADE, STS_ATIVO) VALUES ('"
                        + visita.dtChegada + "', '" + visita.dtSaida
                        + "', " + visita.visitante.id_visitante.ToString() + ", "
                        + visita.unidade.id_unidade.ToString() + ", 1);";

                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

		public List<Visita> buscaPorData(string dt1, string dt2)
		{
            query = null;
            List<Visita> lstArea = new List<Visita>();
            try
            {
                query = "SELECT * FROM VISITA WHERE STS_ATIVO = 1 AND DT_INICIO BETWEEN '" + dt1 
                    + "' AND '" + dt2 + "' ORDER BY DT_INICIO;";
                lstArea = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstArea;

        }

		public List<Visita> buscaPorUnidade(Unidade unidade)
		{
            query = null;
            List<Visita> lstArea = new List<Visita>();
            try
            {
                query = "SELECT * FROM VISITA WHERE STS_ATIVO = 1 AND ID_UNIDADE = " + unidade.id_unidade.ToString() 
                        + " ORDER BY DT_INICIO;";
                lstArea = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstArea;
        }

		public List<Visita> busca()
		{
            query = null;
            List<Visita> lstArea = new List<Visita>();
            try
            {
                query = "SELECT * FROM VISITA WHERE STS_ATIVO = 1 ORDER BY DT_INICIO;";
                lstArea = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstArea;
        }

        public bool altera(Visita visita)
        {
            query = null;
            try
            {
                query = "UPDATE VISITA SET DT_FINAL = '" + visita.dtSaida.ToString() 
                        + "' WHERE ID_VISITA = " + visita.id_visita.ToString() + ";";
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
                query = "UPDATE VISITA SET STS_ATIVO = 0 WHERE ID_VISITA = " + id.ToString() + ";";
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

        public List<Visita> setarObjeto(SqlDataReader dr)
        {
            List<Visita> lstVisitante = new List<Visita>();
            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read() == true)
                    {
                        Visita obj = new Visita();
                        obj.id_visita = Convert.ToInt32(dr["ID_VISITA"].ToString());
                        obj.dtChegada = Convert.ToString(dr["DT_INICIO"].ToString());
                        obj.dtSaida = Convert.ToString(dr["DT_FINAL"].ToString());
                        obj.ativo = Convert.ToBoolean(dr["STS_ATIVO"].ToString());

                        obj.visitante = new Visitante();
                        obj.visitante.id_visitante = Convert.ToInt32(dr["ID_VISITANTE"].ToString());

                        obj.unidade = new Unidade();
                        obj.unidade.id_unidade = Convert.ToInt32(dr["ID_UNIDADE"].ToString());

                        lstVisitante.Add(obj);
                    }
                }
            }

            catch (Exception ex)
            {
                dr.Dispose();
                throw ex;
            }

            return lstVisitante;
        }

        #endregion
    }

}

