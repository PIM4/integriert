using Model.Entity;
using System.Collections.Generic;
using Model.DAO.Generico;
using System.Data.SqlClient;
using System;

namespace Model.DAO.Especifico
{
	public class UnidadeDAO
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

        List<Unidade> lstUnidade = new List<Unidade>();
		public bool cadastra(Unidade unidade)
		{
            query = null;
            try
            {
                query = "INSERT INTO UNIDADE (IDENTIFICACAO, QT_VAGAS, ID_BLOCO, ID_PESSOA, STS_ATIVO) VALUES ('"
                        + unidade.identificacao + "', " + unidade.vagas.ToString() + ", " + unidade.bloco.id_bloco.ToString() 
                        + ", " + unidade.proprietario.id_pessoa.ToString() + ", 1);";

                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

		public List<Unidade> busca()
		{
            query = null;
            List<Unidade> lstUnidade = new List<Unidade>();
            try
            {
                query = "SELECT * FROM UNIDADE WHERE STS_ATIVO = 1;";
                lstUnidade = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstUnidade;
        }

        public bool altera(Unidade unidade)
        {
            query = null;
            try
            {
                query = "UPDATE UNIDADE SET IDENTIFICACAO = '" + unidade.identificacao
                        + "', QT_VAGAS = " + unidade.vagas.ToString()
                        + " WHERE ID_UNIDADE = " + unidade.id_unidade.ToString() + ";";
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
                query = "UPDATE UNIDADE SET STS_ATIVO = 0 WHERE ID_UNIDADE = " + id.ToString() + ";";
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

        public List<Unidade> setarObjeto(SqlDataReader dr)
        {
            List<Unidade> lstUnidade = new List<Unidade>();
            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read() == true)
                    {
                        Unidade obj = new Unidade();
                        obj.id_unidade = Convert.ToInt32(dr["ID_UNIDADE"].ToString());
                        obj.identificacao = Convert.ToString(dr["IDENTIFICACAO"].ToString());
                        obj.vagas = Convert.ToInt32(dr["QT_VAGAS"].ToString());
                        obj.ativo = Convert.ToBoolean(dr["STS_ATIVO"].ToString());

                        obj.bloco = new Bloco();
                        obj.bloco.id_bloco = Convert.ToInt32(dr["ID_BLOCO"].ToString());

                        obj.proprietario = new Pessoa();
                        obj.proprietario.id_pessoa = Convert.ToInt32(dr["ID_PESSOA"].ToString());

                        lstUnidade.Add(obj);
                    }
                }
            }

            catch (Exception ex)
            {
                dr.Dispose();
                throw ex;
            }

            return lstUnidade;
        }

        #endregion
    }

}

