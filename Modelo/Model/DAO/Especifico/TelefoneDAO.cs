using Model.Entity;
using System;
using System.Collections.Generic;
using Model.DAO.Generico;
using System.Data.SqlClient;

namespace Model.DAO.Especifico
{
	public class TelefoneDAO
	{
        #region Observações

        //Por padrão, todas as buscas serão WHERE STS_ATIVO = 1, exceto a verificação se já existe o cadastro.
        //O prof Cassiano orientou a implementar o setarObjeto() dessa forma que foi feita, pq todas as classes precisam, com parametros e objetos diferentes. Não vale o trampo de abstrair.

        #endregion

        #region Objetos

        dbBancos banco = new dbBancos();
        Pessoa pessoa = new Pessoa();
        string query = null;

        #endregion

        #region CRUD
        
		public bool cadastra(Telefone tel)
		{
            query = null;
            try
            {
                //tel.pessoa = new Pessoa();

                query = "INSERT INTO TELEFONE (FIXO, CELULAR, ID_PESSOA, STS_ATIVO, ID_FORNECEDOR) VALUES ('"
                        + tel.fixo + "', '" + tel.celular + "', " + tel.pessoa.id_pessoa.ToString() 
                        + ", 1, " + tel.fornecedor.id_fornecedor.ToString() + ");";
                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

		public List<Telefone> busca()
		{
            query = null;
            List<Telefone> lstTelefone = new List<Telefone>();
            try
            {
                query = "SELECT * FROM TELEFONE WHERE STS_ATIVO = 1;";
                lstTelefone = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {

                throw ex;
            }

            return lstTelefone;
        }

        public bool altera(Telefone tel)
        {
            query = null;
            try
            {
                query = "UPDATE TELEFONE SET FIXO = '" + tel.fixo 
                        + "', CELULAR = '" + tel.celular + "' WHERE ID_TELEFONE = " + tel.id_telefone.ToString() + ";";
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
                query = "UPDATE TELEFONE SET STS_ATIVO = 0 WHERE ID_TELEFONE = " + id.ToString() + ";";
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

        public List<Telefone> setarObjeto(SqlDataReader dr)
        {
            List<Telefone> lstTelefone = new List<Telefone>();
            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Telefone obj = new Telefone();
                        obj.id_telefone = Convert.ToInt32(dr["ID_TELEFONE"].ToString());
                        obj.fixo = Convert.ToString(dr["FIXO"].ToString());
                        obj.celular = Convert.ToString(dr["CELULAR"].ToString());
                        obj.ativo = Convert.ToBoolean(dr["STS_ATIVO"].ToString());

                        obj.pessoa = new Pessoa();
                        obj.pessoa.id_pessoa = Convert.ToInt32(dr["ID_PESSOA"].ToString());

                        obj.fornecedor = new Fornecedor();
                        obj.fornecedor.id_fornecedor = Convert.ToInt32(dr["ID_FORNECEDOR"].ToString());

                        lstTelefone.Add(obj);
                    }
                }
            }

            catch (Exception ex)
            {
                dr.Dispose();
                throw ex;
            }

            return lstTelefone;
        }

        #endregion
    }

}

