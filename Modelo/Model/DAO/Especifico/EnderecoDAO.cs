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
        Pessoa pessoa = new Pessoa();   
        string query = null;

        #endregion

        #region CRUD

        public bool cadastra(Endereco end)
		{
            query = null;
            try
            {
                end.pessoa = new Pessoa();
                end.fornecedor = new Fornecedor();
                query = "INSERT INTO ENDERECO (LOGRADOURO, NUMERO, COMPLEMENTO, BAIRRO, CIDADE, ESTADO, CEP, ID_PESSOA, STS_ATIVO, DESCRICAO, ID_FORNECEDOR) VALUES ('"
                        + end.logradouro + "', " 
                        + (end.numero).ToString() + ", '" 
                        + end.complemento + "', '" 
                        + end.bairro + "', '" 
                        + end.cidade + "', '" 
                        + end.estado + "', '" 
                        + end.cep + "', " 
                        + (end.pessoa.id_pessoa).ToString() + ", " 
                        + "1, '" 
                        + end.descricao + "', " 
                        + end.fornecedor.id_fornecedor.ToString() + ");";
                banco.MetodoNaoQuery(query);
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
                query = "SELECT * FROM ENDERECO WHERE STS_ATIVO = 1 AND LOGRADOURO LIKE '%" 
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
                query = "SELECT * FROM ENDERECO WHERE STS_ATIVO = 1 AND CEP = "
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
                query = "SELECT * FROM ENDERECO WHERE STS_ATIVO = 1 AND ESTADO = "
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
                query = "SELECT * FROM ENDERECO WHERE STS_ATIVO = 1 AND CIDADE ="
                        + cidade + ";";
                lstEndereco = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstEndereco;	
        }

		public List<Endereco> busca()
		{
            query = null;
            List<Endereco> lstEndereco = new List<Endereco>();
            try
            {
                query = "SELECT * FROM ENDERECO WHERE STS_ATIVO = 1;";
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
                query = "UPDATE ENDERECO SET " 
                        + " LOGRADOURO = '" + endereco.logradouro 
                        + "', NUMERO = " + endereco.numero.ToString()
                        + ", COMPLEMENTO = '" + endereco.complemento 
                        + "', BAIRRO = '" + endereco.bairro 
                        + "', CIDADE = '" + endereco.cidade
                        + "', ESTADO = '" + endereco.estado 
                        + "', CEP = '" + endereco.cep 
                        + "', DESCRICAO = '" + endereco.descricao + "' "
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
                query = "UPDATE ENDERECO SET STS_ATIVO = 0 WHERE ID_ENDERECO = " 
                        + id.ToString() + ";";
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
            List<Endereco> lstEndereco = new List<Endereco>();
            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Endereco obj = new Endereco();
                        obj.id_endereco = Convert.ToInt32(dr["ID_ENDERECO"].ToString());
                        obj.logradouro = Convert.ToString(dr["LOGRADOURO"].ToString());
                        obj.numero = Convert.ToInt32(dr["NUMERO"].ToString());
                        obj.bairro = Convert.ToString(dr["BAIRRO"].ToString());
                        obj.estado = Convert.ToString(dr["ESTADO"].ToString());
                        obj.cep = Convert.ToString(dr["CEP"].ToString());
                        obj.descricao = Convert.ToString(dr["DESCRICAO"].ToString());
                        obj.ativo = Convert.ToBoolean(dr["STS_ATIVO"].ToString());
                        obj.complemento = Convert.ToString(dr["COMPLEMENTO"].ToString());

                        obj.pessoa = new Pessoa();
                        obj.pessoa.id_pessoa = Convert.ToInt32(dr["ID_PESSOA"].ToString());

                        obj.fornecedor = new Fornecedor();
                        obj.fornecedor.id_fornecedor = Convert.ToInt32(dr["ID_FORNECEDOR"].ToString());

                        lstEndereco.Add(obj);
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

