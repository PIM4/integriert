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
        // GET: Forms_condominio
        public ActionResult FrmBuscarArea()
        {
            AreaDAO areaDAO = new AreaDAO();
            ViewBag.lstArea = areaDAO.busca();
            return View();
        }
        public ActionResult FrmBuscarBloco()
        {
            BlocoDAO blocoDAO = new BlocoDAO();
            ViewBag.lstBloco = blocoDAO.busca();
            return View();
        }
        public ActionResult FrmBuscarCondominio()
        {
            CondominioDAO condominioDAO = new CondominioDAO();
            ViewBag.lstCond = condominioDAO.busca();
            return View();
        }
        public ActionResult FrmBuscarUnidade()
        {
            UnidadeDAO unidadeDAO = new UnidadeDAO();
            ViewBag.lstUnidade = unidadeDAO.busca();
            return View();
        }
        public ActionResult FrmBuscarAviso()
        {
            AvisoDAO avisoDAO = new AvisoDAO();
            ViewBag.lstAviso = avisoDAO.busca();
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
        public ActionResult FrmCadastrarAviso()
        {
            return View();
        }
        public ActionResult FrmCadastrarBloco()
        {
            return View();
        }
        public ActionResult FrmCadastrarCondominio()
        {
            return View();
        }
        public ActionResult FrmCadastrarUnidade()
        {
            return View();
        }
    }
}