using Model.Entity;
using System.Collections.Generic;
using System;
using Model.DAO.Generico;
using System.Data.SqlClient;
using System.Data;

namespace Model.DAO.Especifico
{
	public class EnderecoDAO
	{
        #region Observações

        //Por padrão, todas as buscas serão WHERE STS_ATIVO = 1, exceto a verificação se já existe o cadastro.
        //O prof Cassiano orientou a implementar o setarObjeto() dessa forma que foi feita, pq todas as classes precisam, com parametros e objetos diferentes. Não vale o trampo de abstrair.

        #endregion

        #region Objetos

        dbBancos banco = new dbBancos();
        Pessoa pessoa = new Pessoa();   //CONVERSAR COM CASSIANO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        string query = null;

        #endregion

        #region CRUD

        public bool cadastra(Endereco end)
		{
            query = null;
            try
            {
                query = "INSERT INTO ENDERECO (LOGRADOURO, NUMERO, COMPLEMENTO, BAIRRO, CIDADE, ESTADO, CEP, ID_PESSOA, STS_ATIVO, DESCRICAO) VALUES ('"
                    + end.logradouro + "', " + (end.numero).ToString() + ", '" + end.complemento + "', '" + end.bairro + "', '" + end.cidade + "', '" 
                    + end.estado + "', '" + end.cep + "', " + (end.id_pessoa).ToString() + ", " + ", 1, '" + end.descricao + "';)";
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

		public List<Endereco> buscaPorLogradouro(string logradouro, int id_pessoa)
		{
            query = null;
            List<Endereco> lstEndereco = new List<Endereco>();
            try
            {
                query = "SELECT DESCRICAO, LOGRADOURO, NUMERO, COMPLEMENTO, BAIRRO, CIDADE, ESTADO, CEP FROM ENDERECO WHERE STS_ATIVO = 1 AND LOGRADOURO LIKE '%" 
                    + logradouro + "%';";
                lstEndereco = setarObjeto(banco.MetodoSelect(query));
            }
                         
            catch (Exception ex)
            {
                throw ex;
            }

            return lstEndereco;	
        }

        public List<Endereco> buscaPorCep(string cep, int id_pessoa)
		{
            query = null;
            List<Endereco> lstEndereco = new List<Endereco>();
            try
            {
                query = "SELECT DESCRICAO, LOGRADOURO, NUMERO, COMPLEMENTO, BAIRRO, CIDADE, ESTADO, CEP FROM ENDERECO WHERE STS_ATIVO = 1 AND CEP = "
                    + cep + ";";
                lstEndereco = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstEndereco;	
        }

        public List<Endereco> buscaPorEstado(string estado, int id_pessoa)
		{
            query = null;
            List<Endereco> lstEndereco = new List<Endereco>();
            try
            {
                query = "SELECT DESCRICAO, LOGRADOURO, NUMERO, COMPLEMENTO, BAIRRO, CIDADE, ESTADO, CEP FROM ENDERECO WHERE STS_ATIVO = 1 AND ESTADO = "
                    + estado + ";";
                lstEndereco = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstEndereco;	
        }

        public List<Endereco> buscaPorCidade(string cidade, int id_pessoa)
		{
            query = null;
            List<Endereco> lstEndereco = new List<Endereco>();
            try
            {
                query = "SELECT DESCRICAO, LOGRADOURO, NUMERO, COMPLEMENTO, BAIRRO, CIDADE, ESTADO, CEP FROM ENDERECO WHERE STS_ATIVO = 1 AND CIDADE ="
                    + cidade + ";";
                lstEndereco = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstEndereco;	
        }

		public List<Endereco> busca(int id_pessoa)
		{
            query = null;
            List<Endereco> lstEndereco = new List<Endereco>();
            try
            {
                query = "SELECT DESCRICAO, LOGRADOURO, NUMERO, COMPLEMENTO, BAIRRO, CIDADE, ESTADO, CEP FROM ENDERECO WHERE STS_ATIVO = 1;";
                lstEndereco = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstEndereco;	
        }

        public bool altera(Endereco endereco)
        {
            query = null;
            try
            {
                query = "UPDATE CORRESPONDENCIA SET LOGRADOURO = '" + endereco.logradouro + "', NUMERO = " + endereco.numero.ToString()
                        + ", COMPLEMENTO = '" + endereco.complemento + "', BAIRRO = '" + endereco.bairro + "', CIDADE = '" + endereco.cidade
                        + "', ESTADO = '" + endereco.estado + "', CEP = '" + endereco.cep + "', DESCRICAO = '" + endereco.descricao + "' "
                        + " WHERE ID_ENDERECO = " + endereco.id_endereco.ToString() + ";";
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
                query = "UPDATE ENDERECO SET STS_ATIVO = 0 WHERE ID_ENDERECO = " + id.ToString() + ";";
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

        public List<Endereco> setarObjeto(SqlDataReader dr)
        {
            Endereco obj = new Endereco();
            List<Endereco> lstEndereco = new List<Endereco>();
            try
            {
                for (int idx = 0; idx < dr.FieldCount; idx++)
                {
                    dr.GetName(idx).ToString();

                    switch (dr.GetName(idx).ToUpper())
                    {
                        case "ID_ENDERECO":
                            obj.id_endereco = Convert.ToInt32(dr[idx]);
                            break;
                        case "DESCRICAO":
                            obj.descricao = Convert.ToString(dr[idx]);
                            break;
                        case "LOGRADOURO":
                            obj.logradouro = Convert.ToString(dr[idx]);
                            break;
                        case "NUMERO":
                            obj.numero = Convert.ToInt32(dr[idx]);
                            break;
                        case "COMPLEMENTO":
                            obj.complemento = Convert.ToString(dr[idx]);
                            break;
                        case "BAIRRO":
                            obj.bairro = Convert.ToString(dr[idx]);
                            break;
                        case "CIDADE":
                            obj.cidade = Convert.ToString(dr[idx]);
                            break;
                        case "ESTADO":
                            obj.estado = Convert.ToString(dr[idx]);
                            break;
                        case "CEP":
                            obj.cep = Convert.ToString(dr[idx]);
                            break;
                    }
                }
            }

            catch (Exception ex)
            {
                dr.Dispose();
                throw ex;
            }

            return lstEndereco;
        }

        #endregion
	}
}

