using Model.Entity;
using System.Collections.Generic;
using Model.DAO.Generico;
using System.Data;
using System.Data.SqlClient;
using System;

namespace Model.DAO.Especifico
{
	public class PessoaDAO
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

        public bool cadastra(Pessoa pessoa)
		{
            query = null;
            try
            {
                query = "INSERT INTO PESSOA (NOME, CPF, RG, DT_NASC, STS_ATIVO) VALUES ('"
                        + pessoa.nome + "', '" 
                        + pessoa.cpf + "', '" 
                        + pessoa.rg + "', '" 
                        + (pessoa.data_nasc).ToShortDateString() 
                        + "', 1);";
                banco.MetodoNaoQuery(query);
                return true;
            }

            catch(Exception ex)
            {
                return false;
                throw ex;
            }
        }

		public List<Pessoa> buscaPorRg(string rg)
		{
            query = null;
            List<Pessoa> lstPessoa = new List<Pessoa>();
            try
            {
                query = "SELECT * FROM PESSOA WHERE STS_ATIVO = 1 " +
                        "AND RG LIKE '%" + rg + "%';";
                lstPessoa = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstPessoa;
        }

		public List<Pessoa> buscaPorNome(string nome)
		{
            query = null;
            List<Pessoa> lstPessoa = new List<Pessoa>();
            try
            {
                query = "SELECT * FROM PESSOA WHERE STS_ATIVO = 1 AND NOME LIKE '%" + nome + "%';";
                lstPessoa = setarObjeto(banco.MetodoSelect(query));
            }
                
            catch (Exception ex)
            {
                throw ex;
            }

            return lstPessoa;
        }

		public List<Pessoa> busca()
		{
            query = null;
            List<Pessoa> lstPessoa = new List<Pessoa>();
            try
            {
                query = "SELECT * FROM PESSOA WHERE STS_ATIVO = 1";
                lstPessoa = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstPessoa;
        }

        public bool altera(Pessoa pessoa)
        {
            query = null;
            try
            {
                query = "UPDATE PESSOA SET NOME = '" + pessoa.nome + 
                        "', CPF = '" + pessoa.cpf + 
                        "', RG = '" + pessoa.rg +
                        "', DT_NASC = '" + pessoa.data_nasc.ToShortDateString() + 
                        "' WHERE ID_PESSOA = " + pessoa.id_pessoa.ToString() + ";";
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
                query = "UPDATE PESSOA SET STS_ATIVO = 0 WHERE ID_PESSOA = " + id.ToString() + ";";
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

        public List<Pessoa> setarObjeto(SqlDataReader dr)
        {
            List<Pessoa> lstPessoa = new List<Pessoa>();

            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Pessoa obj = new Pessoa();
                        obj.id_pessoa = Convert.ToInt32(dr["ID_PESSOA"].ToString());
                        obj.nome = Convert.ToString(dr["NOME"].ToString());
                        obj.cpf = Convert.ToString(dr["CPF"].ToString());
                        obj.rg = Convert.ToString(dr["RG"].ToString());
                        obj.data_nasc = Convert.ToDateTime(dr["DT_NASC"].ToString());
                        obj.ativo = Convert.ToBoolean(dr["STS_ATIVO"].ToString());
                        
                        lstPessoa.Add(obj);
                    }
                }
            }

            catch (Exception ex)
            {
                dr.Dispose();
                throw ex;
            }

            return lstPessoa;
        }

        #endregion
	}

}

