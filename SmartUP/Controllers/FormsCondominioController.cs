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
            ViewBag.ar = area;
            return View();
        }
        public ActionResult FrmBuscarBloco()
        {
            return View();
        }
        public ActionResult FrmBuscarCondominio()
        {
            return View();
        }
        public ActionResult FrmBuscarUnidade()
        {
            return View();
        }
        public ActionResult FrmBuscarAviso()
        {
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