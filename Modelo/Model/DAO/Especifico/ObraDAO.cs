using Model.Entity;
using System.Collections.Generic;
using System;
using Model.DAO.Generico;
using System.Data.SqlClient;

namespace Model.DAO.Especifico
{
	public class ObraDAO
	{
        #region Observações

        //Por padrão, todas as buscas serão WHERE STS_ATIVO = 1, exceto a verificação se já existe o cadastro.
        //O prof Cassiano orientou a implementar o setarObjeto() dessa forma que foi feita, pq todas as classes precisam, com parametros e objetos diferentes. Não vale o trampo de abstrair.
        // lstArea apenas recebe a outra lista pra nao sair do try catch;
        #endregion

        #region Objetos

        dbBancos banco = new dbBancos();
        string query = null;

        #endregion


        List<Obra> lstObra = new List<Obra>();
        
        #region TIPO OBRA

        public bool cadastraTipoObra(Obra obra)
        {
            query = null;
            try
            {
                query = "INSERT INTO TIPO_OBRA (DESCRICAO, STS_ATIVO) VALUES ('"
                        + obra.desc_tipo + "', 1);";

                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        //public List<Obra> buscaTipoObra()
        //{
        //    query = null;
        //    List<Area> lstArea = new List<Area>();
        //    try
        //    {
        //        query = "SELECT * FROM AREA WHERE STS_ATIVO = 1 ORDER BY NOME;";
        //        lstArea = setarObjeto(banco.MetodoSelect(query));
        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return lstArea;
        //}

        public bool alteraTipoObra(Obra obra)
        {
            query = null;
            try
            {
                query = "UPDATE TIPO_OBRA SET DESCRICAO = '" + obra.desc_tipo 
                    + "' WHERE ID_TIPO_OBRA = " + obra.id_tipo_obra.ToString() + ";";

                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool removeTipoObra(int id)
        {
            query = null;
            try
            {
                query = "UPDATE TIPO_OBRA SET STS_ATIVO = 0 WHERE ID_TIPO_OBRA = " + id.ToString() + ";";

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

        #region OBRA
        public bool cadastraObra(Obra obra)
		{
            query = null;
            try
            {
                query = "INSERT INTO OBRA";

                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

		public List<Obra> buscaPorArea(Area area)
		{
            return lstObra;
        }

		public List<Obra> buscaPorTipo(string tipo)
		{
            return lstObra;
        }	
		
		public List<Obra> buscaPorData(DateTime data)
		{
            return lstObra;
        }

		public List<Obra> buscaPorAbertas()
		{
            return lstObra;
        }	

		public List<Obra> buscaPorFechadas()
		{
            return lstObra;
        }						

		public List<Obra> busca()
		{
            return lstObra;
        }

		public bool remove(int id)
		{
            return true;
        }

        public bool altera(Obra obra)
        {
            return true;
        }
        #endregion

        #region TERCEIRO OBRA

        #endregion

        #region Métodos

        public List<Obra> setarObjeto(SqlDataReader dr)
        {
            List<Obra> lstObra = new List<Obra>();
            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read() == true)
                    {
                        Obra obj = new Obra();
                        obj.id_obra = Convert.ToInt32(dr["ID_OBRA"].ToString());
                        obj.descricao_obra = Convert.ToString(dr["DESCRICAO"].ToString());
                        obj.finalizada = Convert.ToBoolean(dr["FINALIZADA"].ToString());
                        obj.dt_inicio = Convert.ToString(dr["DT_INICIO"].ToString());
                        obj.dt_previsao_termino = Convert.ToString(dr["DT_PREVISAO_TERMINO"].ToString());
                        obj.dt_termino = Convert.ToString(dr["DT_TERMINO"].ToString());
                        obj.ativo = Convert.ToBoolean(dr["STS_ATIVO"].ToString());
                        

                        obj.id_tipo_obra = Convert.ToInt32(dr["ID_TIPO_OBRA"].ToString());
                        obj.desc_tipo = Convert.ToString(dr["ID_AREA"].ToString());

                        obj.area = new Area();
                        obj.area.id_area = Convert.ToInt32(dr["ID_AREA"].ToString());



                        lstObra.Add(obj);
                    }
                }
            }

            catch (Exception ex)
            {
                dr.Dispose();
                throw ex;
            }

            return lstObra;
        }

        #endregion
    }

}

