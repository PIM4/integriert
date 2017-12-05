using Model.Entity;
using System.Collections.Generic;
using Model.DAO.Generico;
using System;
using System.Data.SqlClient;

namespace Model.DAO.Especifico
{
	public class MoradorDAO
	{
        #region Observações

        //Por padrão, todas as buscas serão WHERE STS_ATIVO = 1, exceto a verificação se já existe o cadastro.
        //O prof Cassiano orientou a implementar o setarObjeto() dessa forma que foi feita, pq todas as classes precisam, com parametros e objetos diferentes. Não vale o trampo de abstrair.
        //O ID da PESSOA será trazido na classe controller pra cadastrar aqui.

        #endregion

        #region Objetos
        dbBancos banco = new dbBancos();
        string query = null;

        #endregion

        #region CRUD

        List<Morador> lstMorador = new List<Morador>();
		public bool cadastra(Morador morador)
		{
            query = null;
            try
            {
                query = "INSERT INTO MORADOR (ID_PESSOA, ID_UNIDADE, STS_ATIVO) VALUES (" +
                        morador.id_pessoa.ToString() + ", " + 
                        morador.unidade.id_unidade.ToString() + ", 1);";
                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public List<Morador> busca()
        {
            query = null;
            List<Morador> lstMorador = new List<Morador>();
            try
            {
                query = "SELECT M.ID_MORADOR, P.ID_PESSOA, U.ID_UNIDADE, M.STS_ATIVO, P.NOME, P.CPF, U.IDENTIFICACAO FROM PESSOA AS P " +
                        "INNER JOIN MORADOR AS M ON M.ID_PESSOA = P.ID_PESSOA " +
                        "INNER JOIN UNIDADE AS U ON U.ID_UNIDADE = M.ID_UNIDADE " +
                        "WHERE M.STS_ATIVO = 1;";
                lstMorador = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstMorador;
        }

        //public bool altera(Morador morador)
        //{
        //    query = null;
        //    try
        //    {
        //        query = "UPDATE MORADOR";
        //        banco.MetodoNaoQuery(query);
        //        return true;
        //    }

        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw ex;
        //    }
        //}

        public bool remove(int id)
		{
            query = null;
            try
            {
                query = "UPDATE MORADOR SER STS_ATIVO = 0 WHERE ID_MORADOR = " + id.ToString()+ ";";
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

        public List<Morador> setarObjeto(SqlDataReader dr)
        {
            List<Morador> lstMorador = new List<Morador>();

            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Morador obj = new Morador();
                        obj.id_morador = Convert.ToInt32(dr["ID_MORADOR"].ToString());
                        obj.ativo = Convert.ToBoolean(dr["STS_ATIVO"].ToString());

                        obj.unidade = new Unidade();
                        obj.unidade.id_unidade = Convert.ToInt32(dr["ID_UNIDADE"].ToString());
                        obj.unidade.identificacao = Convert.ToString(dr["IDENTIFICACAO"].ToString());

                        obj.id_pessoa = Convert.ToInt32(dr["ID_PESSOA"].ToString());
                        obj.nome = Convert.ToString(dr["NOME"].ToString());
                        obj.cpf = Convert.ToString(dr["CPF"].ToString());
                        obj.rg = Convert.ToString(dr["RG"].ToString());

                        lstMorador.Add(obj);
                    }
                }
            }

            catch (Exception ex)
            {
                dr.Dispose();
                throw ex;
            }

            return lstMorador;
        }


        #endregion

    }

}

