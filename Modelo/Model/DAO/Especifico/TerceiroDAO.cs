using Model.Entity;
using System.Collections.Generic;
using Model.DAO.Generico;
using System;
using System.Data.SqlClient;

namespace Model.DAO.Especifico
{
	public class TerceiroDAO
	{
        #region Observações

        //Por padrão, todas as buscas serão WHERE STS_ATIVO = 1, exceto a verificação se já existe o cadastro.
        //O prof Cassiano orientou a implementar o setarObjeto() dessa forma que foi feita, pq todas as classes precisam, com parametros e objetos diferentes. Não vale o trampo de abstrair.
        // lstArea apenas recebe a outra lista pra nao sair do try catch;
        #endregion

        #region Objetos

        dbBancos banco = new dbBancos();
        string query = null;
        PessoaDAO dao = new PessoaDAO();

        #endregion

        #region TERCEIRO

        public bool cadastra(Terceiro terceiro)
		{
            query = null;
            try
            {
                terceiro.id_pessoa = dao.cadastra(terceiro.nome, terceiro.cpf, terceiro.rg);
                query = "INSERT INTO TERCEIRO (ID_TIPO_SERVICO, ID_FORNECEDOR, ID_PESSOA, STS_ATIVO) VALUES (" +
                        terceiro.id_servico.ToString() + ", " + terceiro.fornecedor.id_fornecedor.ToString() +
                        ", " + terceiro.id_pessoa.ToString() + ", 1);";

                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public List<Terceiro> busca()
        {
            query = null;
            List<Terceiro> lstTerceiro = new List<Terceiro>();
            try
            {
                query = "SELECT T.ID_TERCEIRO, TS.ID_TIPO_SERVICO, F.ID_FORNECEDOR, P.ID_PESSOA, TS.DESCRICAO, " +
                        "TS.STS_ATIVO, F.RAZAO_SOCIAL, P.NOME, P.CPF, P.RG, P.DT_NASC, P.STS_ATIVO " +
                        "FROM TERCEIRO AS T " +
                        "INNER JOIN TIPO_SERVICO AS TS ON TS.ID_TIPO_SERVICO = T.ID_TIPO_SERVICO " +
                        "INNER JOIN FORNECEDOR AS F ON F.ID_FORNECEDOR = T.ID_FORNECEDOR " +
                        "INNER JOIN PESSOA AS P ON P.ID_PESSOA = T.ID_PESSOA " +
                        "WHERE T.STS_ATIVO = 1;";
                lstTerceiro = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstTerceiro;
        }
        
        public bool altera(Terceiro terceiro)
        {
            query = null;
            List<Terceiro> lstTerceiro = new List<Terceiro>();
            try
            {
                query = "SELECT top 1 * FROM PESSOA WHERE ID_PESSOA = " + terceiro.id_pessoa.ToString() + ";";
                lstTerceiro = setarObjetoPessoa(banco.MetodoSelect(query));

                dao.altera(terceiro.id_pessoa, terceiro.nome, terceiro.cpf, terceiro.rg, terceiro.data_nasc);
                
                // Terceiro em si nao altera nada, o que altera mesmo é a pessoa
                //banco.MetodoNaoQuery(query);
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
                
                query = "UPDATE TERCEIRO SET STS_ATIVO = 0 WHERE ID_TERCEIRO = " + id.ToString() + ";";

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

        #region TIPO SERVIÇO

        public bool cadastraTipoServico(Terceiro terceiro)
        {
            query = null;
            try
            {
                
                query = "INSERT INTO TIPO_SERVICO (DESCRICAO, STS_ATIVO) VALUES ('" +
                        terceiro.servico + "', 1);";

                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public List<Terceiro> buscaTipoServico()
        {
            query = null;
            List<Terceiro> lstTerceiro = new List<Terceiro>();
            lstTerceiro = null;
            try
            {
                query = "SELECT * FROM TIPO_SERVICO WHERE STS_ATIVO = 1;";
                lstTerceiro = setarObjetoTipoServico(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstTerceiro;
        }

        public bool alteraTipoServico(Terceiro terceiro)
        {
            query = null;
            try
            {

                query = "UPDATE TIPO_SERVICO SET DESCRICAO = '" + terceiro.servico 
                        + "' WHERE ID_TIPO_SERVICO = " + terceiro.id_terceiro.ToString() + ";";

                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool removeTipoServico(int id)
        {
            query = null;
            try
            {

                query = "UPDATE TIPO_SERVICO SET STS_ATIVO WHERE ID_TIPO_SERVICO = " 
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
        
        public List<Terceiro> setarObjeto(SqlDataReader dr)
        {
            List<Terceiro> lstTerceiro = new List<Terceiro>();

            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Terceiro obj = new Terceiro();
                        obj.id_terceiro = Convert.ToInt32(dr["ID_TERCEIRO"].ToString());
                        obj.ativo = Convert.ToBoolean(dr["STS_ATIVO"].ToString());

                        obj.id_servico = Convert.ToInt32(dr["ID_TIPO_SERVICO"].ToString());
                        obj.servico = Convert.ToString(dr["DESCRICAO"].ToString());

                        obj.fornecedor = new Fornecedor();
                        obj.fornecedor.id_fornecedor = Convert.ToInt32(dr["ID_FORNECEDOR"].ToString());
                        obj.fornecedor.nomeEmpresa = Convert.ToString(dr["RAZAO_SOCIAL"].ToString());
                        
                        obj.id_pessoa = Convert.ToInt32(dr["ID_PESSOA"].ToString());
                        obj.nome = Convert.ToString(dr["NOME"].ToString());
                        obj.cpf = Convert.ToString(dr["CPF"].ToString());
                        obj.rg = Convert.ToString(dr["RG"].ToString());

                        lstTerceiro.Add(obj);
                    }
                }
            }

            catch (Exception ex)
            {
                dr.Dispose();
                throw ex;
            }

            return lstTerceiro;
        }

        public List<Terceiro> setarObjetoTipoServico(SqlDataReader dr)
        {
            List<Terceiro> lstTerceiro = new List<Terceiro>();

            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Terceiro obj = new Terceiro();
                        obj.id_servico = Convert.ToInt32(dr["ID_TIPO_SERVICO"].ToString());
                        obj.servico = Convert.ToString(dr["DESCRICAO"].ToString());

                       

                        lstTerceiro.Add(obj);
                    }
                }
            }

            catch (Exception ex)
            {
                dr.Dispose();
                throw ex;
            }

            return lstTerceiro;
        }

        public List<Terceiro> setarObjetoPessoa(SqlDataReader dr)
        {
            List<Terceiro> lstTerceiro = new List<Terceiro>();

            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Terceiro obj = new Terceiro();
                        obj.id_pessoa = Convert.ToInt32(dr["ID_PESSOA"].ToString());
                        obj.nome = Convert.ToString(dr["NOME"].ToString());
                        obj.cpf = Convert.ToString(dr["CPF"].ToString());
                        obj.rg = Convert.ToString(dr["RG"].ToString());
                        obj.data_nasc = Convert.ToDateTime(dr["DT_NASC"].ToString());

                        lstTerceiro.Add(obj);
                    }
                }
            }

            catch (Exception ex)
            {
                dr.Dispose();
                throw ex;
            }

            return lstTerceiro;
        }

        #endregion

        #region TERCEIRO OBRA

        //public bool cadastraTerceiroObra(Terceiro terceiro)
        //{
        //    query = null;
        //    try
        //    {
                
        //        query = "INSERT INTO TERCEIRO_OBRA (ID_TERCEIRO, ID_OBRA, STS_ATIVO) VALUES (" +
        //                terceiro.id"";

        //        banco.MetodoNaoQuery(query);
        //        return true;
        //    }

        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw ex;
        //    }
        //}

        #endregion
    }

}

