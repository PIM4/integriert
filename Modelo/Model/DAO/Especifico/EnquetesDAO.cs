using Model.Entity;
using System.Collections.Generic;
using System;
using Model.DAO.Generico;
using System.Data.SqlClient;

namespace Model.DAO.Especifico
{
	public class EnquetesDAO
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

        public bool cadastra(Enquete enquete)
		{
            query = null;
            try
            {
                query = "INSERT INTO ENQUETE (PERGUNTA, DT_INICIO, DT_FINAL, ID_COND, STS_ATIVO) VALUES ('"
                        + enquete.pergunta + "', '" 
                        + (enquete.dtInicio).ToShortDateString() + "', "
                        + (enquete.dtFim).ToShortDateString() + "', " 
                        + (enquete.condominio.id_cond).ToString()
                        + ", 1;";
                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }	
        }

        public bool cadastraAlternativas(Enquete enquete)
        {
            query = null;
            try
            {
                query = "INSERT INTO ENQUETE_ALTERNATIVAS (TEXTO, ID_ENQUETE, STS_ATIVO) VALUES ('"
                        + enquete.textoAlt + "', " 
                        + (enquete.id_enquete).ToString() 
                        + ", 1;";
                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool cadastraVoto(Enquete enquete)
        {
            query = null;
            try
            {
                query = "INSERT INTO VOTO (ID_ENQUETE, ID_ENQUETE_ALTERNATIVAS, ID_PESSOA, STS_ATIVO) VALUES ("
                        + (enquete.id_enquete).ToString() + ", " 
                        + (enquete.voto).ToString() + ", "
                        + (enquete.pessoa.id_pessoa).ToString() + ", 1);";
                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

		public List<Enquete> buscaEnquetePorData(DateTime dtInicio, DateTime dtFinal)
		{
            query = null;
            List<Enquete> lstEnquete = new List<Enquete>();
            try
            {
                query = "SELECT E.PERGUNTA, E.DT_INICIO, E.DT_FINAL, C.CONDOMINIO FROM ENQUETE AS E"
                        + " INNER JOIN CONDOMINIO AS C ON E.ID_COND = C.ID_COND"
                        + " WHERE E.STS_ATIVO = 1 AND E.DT_INICIO = '" + (dtInicio).ToShortDateString()
                        + "' AND E.DT_FINAL = '" + (dtFinal).ToShortDateString() + "';";
                lstEnquete = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstEnquete;
        }

		public List<Enquete> buscaEnquete()
		{
            query = null;
            List<Enquete> lstEnquete = new List<Enquete>();
            try
            {
                query = "SELECT E.PERGUNTA, E.DT_INICIO, E.DT_FINAL, C.NOME_COND FROM ENQUETE AS E"
                        + " INNER JOIN CONDOMINIO AS C ON E.ID_COND = C.ID_COND"
                        + " WHERE E.STS_ATIVO = 1;";
                lstEnquete = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstEnquete;
        }

        public List<Enquete> buscaAlternativas(int id)
        {
            query = null;
            List<Enquete> lstEnqueteAlt = new List<Enquete>();
            try
            {
                query = "SELECT * FROM ENQUETE_ALTERNATIVAS WHERE STS_ATIVO = 1 AND ID_ENQUETE = " 
                        + (id).ToString() + ";";
                lstEnqueteAlt = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstEnqueteAlt;
        }

        public List<Enquete> buscaVotosPorEnquete(int id)   //Verificar
        {
            query = null;
            List<Enquete> lstVoto = new List<Enquete>();
            try
            {
                query = "SELECT EA.TEXTO, ";
                lstVoto = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstVoto;
        }

        public bool alteraEnquete(Enquete enquete)
        {
            query = null;
            try
            {
                query = "UPDATE ENQUETE SET DT_FINAL = '"
                        + (enquete.dtFim).ToShortDateString() 
                        + "' WHERE ID_ENQUETE = " + (enquete.id_enquete).ToString() + ";";
                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

		public bool removeEnquete(int id)
		{
            query = null;
            try
            {
                query = "UPDATE ENQUETE SET STS_ATIVO = 0 WHERE ID_ENQUETE = "
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

        public bool removeEnqueteAlt(int id)
        {
            query = null;
            try
            {
                query = "UPDATE ENQUETE_ALTERNATIVAS SET STS_ATIVO = 0 WHERE ID_ENQUETE_ALTERNATIVAS = "
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

        public List<Enquete> setarObjeto(SqlDataReader dr)
        {
            List<Enquete> lstEnquete = new List<Enquete>();
            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Enquete obj = new Enquete();

                        obj.id_enquete = Convert.ToInt32(dr["ID_ENQUETE"].ToString());
                        obj.pergunta = Convert.ToString(dr["PERGUNTA"].ToString());
                        obj.dtInicio = Convert.ToDateTime(dr["DT_INICIO"].ToString());
                        obj.dtFim = Convert.ToDateTime(dr["DT_FINAL"].ToString());
                        obj.enq_ativo = Convert.ToInt32(dr["STS_ATIVO"].ToString());        //verificar

                        obj.id_enquete_alt = Convert.ToInt32(dr["ID_ENQUETE_ALTERNATIVAS"].ToString());
                        obj.textoAlt = Convert.ToString(dr["TEXTO"].ToString());

                        obj.id_voto = Convert.ToInt32(dr["ID_VOTO"].ToString());

                        obj.condominio.id_cond = Convert.ToInt32(dr["ID_COND"].ToString());
                    }
                }
            }

            catch (Exception ex)
            {
                dr.Dispose();
                throw ex;
            }

            return lstEnquete;
        }

        #endregion
	}

}

