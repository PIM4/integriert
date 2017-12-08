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

		public bool cadastra(Terceiro terceiro)
		{
            query = null;
            try
            {
                terceiro.id_pessoa = dao.cadastra(terceiro.nome, terceiro.cpf, terceiro.rg, terceiro.data_nasc);
                query = "INSERT INTO TERCEIRO (ID_TIPO_SERVICO, ID_FORNECEDOR, ID_PESSOA, STS_ATIVO) VALUES (" +
                        terceiro.id_servico.ToString() + ", " + terceiro.fornecedor.id_fornecedor.ToString() +
                        ", " + terceiro.id_pessoa.ToString() + ");";

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
                        "TS.STS_ATIVO, F.RAZAO_SOCIAL, P.NOME, P.CPF, P.RG, P.DT_NASC, P.STS_ATIVO FROM " +
                        "FROM TERCEIRO AS T " +
                        "INNER JOIN TIPO_SERVICO AS TS ON TS.ID_TIPO_SERVICO = T.ID_TIPO_SERVICO " +
                        "INNER JOIN FORNECEDOR AS F ON F.ID_FORNECEDOR = T.ID_FORNECEDOR " +
                        "INNER JOIN PESSOA AS P ON P.ID_PESSOA = TERCEIRO.ID_PESSOA " +
                        "WHERE T.STS_ATIVO = 1;";
                lstTerceiro = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstTerceiro;
        }
        
        public bool altera( Terceiro terceiro)
        {
            return true;
        }

        public bool remove(int id)
        {
            return true;
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
    }

}

