using Model.DAO.Especifico;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsAreaController : Controller
    {
        #region AREA
        public ActionResult FrmBuscarArea()
        {
            AreaDAO areaDAO = new AreaDAO();
            ViewBag.lstArea = areaDAO.busca();
            return View();
        }
        public ActionResult FrmCadastrarArea()
        {
            return View();
        }
        public ActionResult FrmAlterarArea(Area area)
        {
            ViewBag.area = area;
            return View();
        }
        public ActionResult CadastraArea(Area area)
        {
            AreaDAO areaDAO = new AreaDAO();
            areaDAO.cadastra(area);
            return RedirectToAction("frmBuscarArea", "FormsCondominio");
        }
        #endregion
    }
}