using Model.Entity;
using System.Collections.Generic;
using Model.DAO.Generico;
using System;
using System.Data.SqlClient;

namespace Model.DAO.Especifico
{
	public class VisitanteDAO
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

        List<Visitante> lstVisitante = new List<Visitante>();
        public bool cadastra(Visitante visitante)
		{
            query = null;
            try
            {
                query = "INSERT INTO VISITANTE (NOME, DOCUMENTO, IMG, STS_ATIVO) VALUES ('"
                        + visitante.nome + "', '" + visitante.rg + "', '"+ visitante.img +"', 1);";

                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

		public List<Visitante> buscaPorNome(string nome)
		{
            query = null;
            List<Visitante> lstArea = new List<Visitante>();
            try
            {
                query = "SELECT * FROM VISITANTE WHERE STS_ATIVO = 1 AND NOME like '%" + nome + "%' ORDER BY NOME;";
                lstArea = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstArea;
        }

		public List<Visitante> buscaPorRg(string rg)
		{
            query = null;
            List<Visitante> lstArea = new List<Visitante>();
            try
            {
                query = "SELECT * FROM VISITANTE WHERE STS_ATIVO = 1 AND DOCUMENTO like '%" + rg + "%' ORDER BY NOME;";
                lstArea = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstArea;
        }

		public List<Visitante> busca()
		{
            query = null;
            List<Visitante> lstArea = new List<Visitante>();
            try
            {
                query = "SELECT * FROM VISITANTE WHERE STS_ATIVO = 1 ORDER BY NOME;";
                lstArea = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstArea;
        }

        public bool altera(Visitante visitante)
        {
            query = null;
            try
            {
                query = "UPDATE VISITANTE SET NOME = '" + visitante.nome 
                        + "', DOCUMENTO = '" + visitante.rg 
                        + "', IMG = '" + visitante.img 
                        + "' WHERE ID_VISITANTE = " + visitante.id_visitante.ToString() + ";";
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
                query = "UPDATE VISITANTE SET STS_ATIVO = 0 WHERE ID_VISITANTE = " + id.ToString() + ";";
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

        public List<Visitante> setarObjeto(SqlDataReader dr)
        {
            List<Visitante> lstVisitante = new List<Visitante>();
            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read() == true)
                    {
                        Visitante obj = new Visitante();
                        obj.id_visitante = Convert.ToInt32(dr["ID_VISITANTE"].ToString());
                        obj.rg = Convert.ToString(dr["DOCUMENTO"].ToString());
                        obj.img = Convert.ToString(dr["IMG"].ToString());
                        obj.nome = Convert.ToString(dr["NOME"].ToString());
                        obj.ativo = Convert.ToBoolean(dr["STS_ATIVO"].ToString());

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

