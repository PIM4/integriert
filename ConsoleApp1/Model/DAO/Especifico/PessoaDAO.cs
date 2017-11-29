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
                        + pessoa.nome + "', '" + pessoa.cpf + "', '" + pessoa.rg + "', '" 
                        + (pessoa.data_nasc).ToShortDateString() + "', 1)";
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
                query = "SELECT NOME, CPF, RG, DT_NASC FROM PESSOA WHERE STS_ATIVO = 1 AND RG LIKE '%" + rg + "%'";
                lstPessoa.Add(setarObjeto(banco.MetodoSelect(query)));
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
                query = "SELECT NOME, CPF, RG, DT_NASC FROM PESSOA WHERE STS_ATIVO = 1 AND NOME LIKE '%" + nome + "%'";
                lstPessoa.Add(setarObjeto(banco.MetodoSelect(query)));
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
                query = "SELECT NOME, CPF, RG, DT_NASC FROM PESSOA WHERE STS_ATIVO = 1";
                lstPessoa.Add(setarObjeto(banco.MetodoSelect(query)));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstPessoa;
        }

		public bool remove(int id)
		{
            query = null;
            try
            {
                query = "UPDATE PESSOA SET STS_ATIVO = 0 WHERE ID_PESSOA = " + id.ToString();
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

        public Pessoa setarObjeto(SqlDataReader dr)
        {
            Pessoa obj = new Pessoa();

            try
            {
                for (int idx = 0; idx < dr.FieldCount; idx++)
                {
                    dr.GetName(idx).ToString();

                    switch (dr.GetName(idx).ToUpper())
                    {
                        case "ID_PESSOA":
                            obj.id_pessoa = Convert.ToInt32(dr[idx]);
                            break;
                        case "NOME":
                            obj.nome = Convert.ToString(dr[idx]);
                            break;
                        case "CPF":
                            obj.cpf = Convert.ToString(dr[idx]);
                            break;
                        case "RG":
                            obj.rg = Convert.ToString(dr[idx]);
                            break;
                        case "DT_NASC":
                            obj.data_nasc = Convert.ToDateTime(dr[idx]);
                            break;
                    }
                }
            }

            catch (Exception ex)
            {
                dr.Dispose();
                throw ex;
            }

            return obj;
        }

        #endregion
	}

}

