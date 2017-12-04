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
                query = "SELECT P.NOME, P.CPF, U.IDENTIFICACAO FROM PESSOA AS P " +
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

        public bool altera(Morador morador)
        {
            query = null;
            try
            {
                query = "UPDATE MORADOR";
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
            return true;
        }

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
                        obj.id_funcionario = Convert.ToInt32(dr["ID_FUNCIONARIO"].ToString());
                        obj.cargo.id_cargo = Convert.ToInt32(dr["ID_CARGO"].ToString());
                        obj.id_pessoa = Convert.ToInt32(dr["ID_PESSOA"].ToString());

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

        public List<Morador> setarObjetoCargo(SqlDataReader dr)
        {
            List<Morador> lstMorador = new List<Morador>();

            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Morador obj = new Morador();
                        obj.id_cargo = Convert.ToInt32(dr["ID_CARGO"].ToString());
                        obj.descricao = Convert.ToString(dr["DESCRICAO"].ToString());
                        obj.ativo = Convert.ToInt32(dr["STS_ATIVO"].ToString());

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

