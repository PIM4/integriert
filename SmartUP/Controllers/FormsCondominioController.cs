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
            Area area = new Area();
            AreaDAO areaDAO = new AreaDAO();
            ViewBag.lstArea = areaDAO.busca();
            return View();
        }
        public ActionResult FrmBuscarBloco()
        {
            Bloco bloco = new Bloco();
            BlocoDAO blocoDAO = new BlocoDAO();
            ViewBag.lstBloco = blocoDAO.busca();
            return View();
        }
        public ActionResult FrmBuscarCondominio()
        {
            Condominio condominio = new Condominio();
            CondominioDAO condominioDAO = new CondominioDAO();
            ViewBag.lstCond = condominioDAO.busca();
            return View();
        }
        public ActionResult FrmBuscarUnidade()
        {
            Unidade unidade = new Unidade();
            UnidadeDAO unidadeDAO = new UnidadeDAO();
            ViewBag.lstUnidade = unidadeDAO.busca();
            return View();
        }
        public ActionResult FrmBuscarAviso()
        {
            Aviso aviso = new Aviso();
            AvisoDAO avisoDAO = new AvisoDAO();
            ViewBag.lstAviso = avisoDAO.busca();
            return View();
        }
        public ActionResult FrmCadastrarArea()
        {
            return View();
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