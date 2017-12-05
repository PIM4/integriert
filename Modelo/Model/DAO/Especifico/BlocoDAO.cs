using Model.Entity;
using System.Collections.Generic;
using Model.DAO.Generico;
using System.Data;
using System.Data.SqlClient;
using System;

namespace Model.DAO.Especifico
{
	public class BlocoDAO
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

		public bool cadastra(Bloco bloco)
		{
            query = null;
            try
            {
                query = "INSERT INTO BLOCO (IDENTIFICACAO, ID_COND, STS_ATIVO) VALUES ('"
                        + bloco.nome + "', " 
                        + (bloco.cond.id_cond).ToString() + ", 1);";
                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

		public List<Bloco> buscaPorNome(string nome)
		{
            query = null;
            List<Bloco> lstBloco = new List<Bloco>();
            try
            {
                query = "SELECT B.ID_BLOCO, B.IDENTIFICACAO, C.NOME_COND, B.STS_ATIVO, B.ID_COND FROM BLOCO AS B "
                         + " INNER JOIN CONDOMINIO AS C ON B.ID_COND = C.ID_COND "
                         + " WHERE B.STS_ATIVO = 1 AND B.IDENTIFICACAO LIKE '%" + nome + "%';";
                lstBloco = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstBloco;	
        }

		public List<Bloco> busca()
		{
            query = null;
            List<Bloco> lstBloco = new List<Bloco>();
            try
            {
                query = "SELECT B.ID_BLOCO, B.IDENTIFICACAO, B.ID_COND, C.NOME_COND , B.STS_ATIVO, B.ID_COND FROM BLOCO AS B "
                        + " INNER JOIN CONDOMINIO AS C ON C.ID_COND = B.ID_COND"
                        + " WHERE B.STS_ATIVO = 1;";
                lstBloco = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstBloco;		
        }

        public bool altera(Bloco bloco)
        {
            query = null;
            try
            {
                query = "UPDATE BLOCO SET " 
                        + " IDENTIFICACAO = '" + bloco.nome
                        + "' WHERE ID_BLOCO = " + (bloco.id_bloco).ToString() + ";";
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
                query = "UPDATE BLOCO SET STS_ATIVO = 0 WHERE ID_BLOCO = " + id.ToString() + ";";
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

        public List<Bloco> setarObjeto(SqlDataReader dr)
        {
            List<Bloco> lstBloco = new List<Bloco>();
            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Bloco obj = new Bloco();
                        
                        obj.id_bloco = Convert.ToInt32(dr["ID_BLOCO"].ToString());
                        obj.nome = Convert.ToString(dr["IDENTIFICACAO"].ToString());
                        obj.ativo = Convert.ToBoolean(dr["STS_ATIVO"].ToString());
                        obj.cond = new Condominio();
                        obj.cond.id_cond = Convert.ToInt32(dr["ID_COND"].ToString());
                        obj.cond.nome = Convert.ToString(dr["NOME_COND"].ToString());


                        lstBloco.Add(obj);
                    }
                }
            }

            catch (Exception ex)
            {
                dr.Dispose();
                throw ex;
            }

            return lstBloco;
        }

        #endregion

	}

}

