using Model.DAO.Especifico;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsCondominioController : Controller
    {
        #region AREA
            // GET: Forms_condominio
            public ActionResult FrmBuscarArea()
            {
                AreaDAO areaDAO = new AreaDAO();
                ViewBag.lstArea = areaDAO.busca();
                return View();
            }
            public ActionResult FrmCadastrarArea(Area area)
            {
                return View();
            }
            public ActionResult CadastraArea(Area area)
            {
                AreaDAO areaDAO = new AreaDAO();
                areaDAO.cadastra(area);
                return RedirectToAction("frmBuscarArea", "FormsCondominio");
            }
        #endregion
        
        #region Bloco
        public ActionResult FrmBuscarBloco()
        {
            BlocoDAO blocoDAO = new BlocoDAO();
            ViewBag.lstBloco = blocoDAO.busca();
            return View();
        }
        public ActionResult FrmCadastrarBloco(Bloco obj)
        {
            if(obj != null)
            {
                BlocoDAO daoBloco = new BlocoDAO();
                CondominioDAO condDAO = new CondominioDAO();
                List<Condominio> lstCond = condDAO.busca();
                List<Bloco> lstbloco = daoBloco.busca();
                foreach(Bloco bloco in lstbloco)
                {
                    if(bloco.id_bloco == obj.id_bloco)
                    {
                        foreach(Condominio cond in lstCond)
                        {
                            if(cond.id_cond == bloco.cond.id_cond)
                            {

                            }
                        }
                        ViewBag.bloco = bloco;
                        return View();
                    }
                }
            }
            CondominioDAO dao = new CondominioDAO();
            ViewBag.lstCond = dao.busca();
            return View();
        }
        public ActionResult CadastrarBloco(Bloco obj)
        {
            BlocoDAO dao = new BlocoDAO();
            dao.cadastra(obj);
            return RedirectToAction("frmBuscarBloco", "FormsCondominio");
        }
        #endregion
        
        #region Condominio
            public ActionResult FrmBuscarCondominio()
            {
                CondominioDAO condominioDAO = new CondominioDAO();
                ViewBag.lstCond = condominioDAO.busca();
                return View();
                }
            public ActionResult FrmCadastrarCondominio(Condominio obj)
            {
           
                return View();
            }
            public ActionResult CadastraCondominio(Condominio obj)
            {
                CondominioDAO dao = new CondominioDAO();
                dao.cadastra(obj);
                return RedirectToAction("frmBuscarArea", "FormsCondominio");
            }
        #endregion
        
        #region Unidade
            public ActionResult FrmBuscarUnidade()
            {
                UnidadeDAO unidadeDAO = new UnidadeDAO();
                ViewBag.lstUnidade = unidadeDAO.busca();
                return View();
            }
            public ActionResult FrmCadastrarUnidade()
            {
                PessoaDAO daoP = new PessoaDAO();
                BlocoDAO daob = new BlocoDAO();
                ViewBag.lstBloco = daob.busca();
                ViewBag.lstPessoa = daoP.busca();
                return View();
            }
            public ActionResult CadastrarUnidade(Unidade obj)
            {
                UnidadeDAO dao = new UnidadeDAO();
                dao.cadastra(obj);
                return RedirectToAction("frmCadastrarUnidade", "FormsCondominio");
            }
        #endregion

        #region Aviso
            public ActionResult FrmBuscarAviso()
            {
                AvisoDAO avisoDAO = new AvisoDAO();
                ViewBag.lstAviso = avisoDAO.busca();
                return View();
            }
            public ActionResult FrmCadastrarAviso(Bloco obj)
            {
                CondominioDAO dao = new CondominioDAO();
                ViewBag.lstCond = dao.busca();
                return View();
            }
            public ActionResult CadastrarAviso(Aviso obj)
        {
            AvisoDAO dao = new AvisoDAO();
            dao.cadastra(obj);
            return RedirectToAction("frmBuscarAviso", "FormsCondominio");
        }
        #endregion
    }
}