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
        public ActionResult frmBuscaArea()
        {
            AreaDAO areaDAO = new AreaDAO();
            ViewBag.lstArea = areaDAO.busca();
            return View();
        }
        public ActionResult frmCadastraArea()
        {
            return View();
        }
        public ActionResult FrmAlteraArea(Area area)
        {
            ViewBag.area = area;
            return View();
        }
        public ActionResult CadastraArea(Area area)
        {
            AreaDAO areaDAO = new AreaDAO();
            areaDAO.cadastra(area);
            return RedirectToAction("frmBuscaArea");
        }
        public ActionResult AlteraArea(Area area)
        {
            AreaDAO areaDAO = new AreaDAO();
            areaDAO.altera(area);
            return RedirectToAction("frmBuscaArea");
        }
        #endregion
    }
}