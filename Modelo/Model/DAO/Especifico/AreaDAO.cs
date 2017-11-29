using Model.Entity;
using System;
using System.Data;
using System.Collections.Generic;
using Model.DAO;
using Model.DAO.Generico;
using System.Data.SqlClient;

namespace Model.DAO.Especifico
{
	public class AreaDAO        
    {
        #region Métodos

        public List<Area> setarObjeto(SqlDataReader dr)
        {
            
            List<Area> lstArea = new List<Area>();
            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read() == true)
                    {
                        Area obj = new Area();
                        obj.id_area = Convert.ToInt32(dr["ID_AREA"].ToString());
                        obj.descricao = Convert.ToString(dr["DESCRICAO"].ToString());
                        obj.seAluga = Convert.ToBoolean(dr["RESERVA"].ToString());
                        obj.nome = Convert.ToString(dr["NOME"].ToString());
                        obj.capacMax = Convert.ToInt32(dr["CAPACIDADE_MAX"].ToString());
                        lstArea.Add(obj);
                    }
                }

            }

            catch(Exception ex)
            {
                dr.Dispose();
                throw ex;
            }

            return lstArea;
        }

        #endregion

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

        public bool cadastra(Area area)
		{
            query = null;
            try
            {
                query = "INSERT INTO AREA (NOME, DESCRICAO, RESERVA, CAPACIDADE_MAX, STS_ATIVO) VALUES ('"
                                + area.nome + "', '" + area.descricao + "', " + Convert.ToInt32(area.seAluga) + ", "
                                + (area.capacMax).ToString() + ", " + Convert.ToInt32(area.ativo) + ");";
                banco.MetodoNaoQuery(query);
                return true;
            }

            catch(Exception ex)
            {
                return false;
                throw ex;
            }
		}

		public List<Area> buscaPorNome(string nome)
		{
            query = null;
            List<Area> lstArea = new List<Area>();
            try
            {
                query = "SELECT NOME, DESCRICAO, CAPACIDADE_MAX, RESERVA FROM AREA WHERE NOME LIKE '%" + nome + "%' AND STS_ATIVO = 1 ORDER BY NOME;";
                lstArea = setarObjeto(banco.MetodoSelect(query));
            }

            catch(Exception ex)
            {
                throw ex;
            }

            return lstArea;
		}

		public List<Area> buscaPorAlugaveis(bool aluga)
		{
            query = null;
            List<Area> lstArea = new List<Area>();
            try
            {
                query = "SELECT NOME, DESCRICAO, CAPACIDADE_MAX, RESERVA FROM AREA WHERE RESERVA = " + (aluga).ToString() + " AND STS_ATIVO = 1 ORDER BY NOME;";
                lstArea = setarObjeto(banco.MetodoSelect(query));
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return lstArea;
		}

		public List<Area> busca()
		{
            query = null;
            List<Area> lstArea = new List<Area>();
            try
            {
                query = "SELECT ID_AREA, NOME, DESCRICAO, CAPACIDADE_MAX, RESERVA FROM AREA WHERE STS_ATIVO = 1 ORDER BY NOME;";
                lstArea = setarObjeto(banco.MetodoSelect(query));
            }

            catch(Exception ex)
            {
                throw ex;
            }

            return lstArea;
		}

        public bool altera(Area area)
        {
            query = null;
            try
            {
                query = "UPDATE AREA SET DESCRICAO = '" + area.descricao + "', RESERVA = " + Convert.ToInt32(area.seAluga) + ", NOME = '"
                        + area.nome + "', CAPACIDADE_MAX = " + (area.capacMax).ToString() + ", STS_ATIVO = 1 "
                        + " WHERE ID_AREA = " + (area.id_area).ToString() + ";";
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
                query = "UPDATE AREA SET STS_ATIVO = 0 WHERE ID_AREA = " + id.ToString() + ";";
                banco.MetodoNaoQuery(query);
                return true;
            }

            catch(Exception ex)
            {
                return false;
                throw ex;
            }
		}

        //public int contaArea()
        //{
        //    query = "SELECT COUNT(*) FROM AREA WHERE STS_ATIVO = 1";



        //    return 1;
        //} //Verificar...
        
        #endregion

    }
}

