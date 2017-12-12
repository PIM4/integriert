using Model.DAO.Especifico;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsCorrespondenciaController : Controller
    {
        // GET: FormsCorrespondencia
        public ActionResult frmBuscaCorrespondencia()
        {
            CorrespondenciaDAO corresDAO = new CorrespondenciaDAO();
            ViewBag.lstCorres = corresDAO.busca();
            return View();
        }
        public ActionResult frmCadastraCorrespondencia()
        {
            return View();
        }
        public ActionResult FrmAlteraCorrespondencia(Correspondencia obj)
        {
            ViewBag.obj = obj;
            return View();
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult CadastraCorrespondencia(Correspondencia obj)
        {
            CorrespondenciaDAO dao = new CorrespondenciaDAO();
            dao.cadastra(obj);
            return RedirectToAction("frmBuscaCorrespondencia");
        }
        public ActionResult CadastraContasAReceber(Correspondencia obj)
        {
            CorrespondenciaDAO dao = new CorrespondenciaDAO();
            dao.cadastra(obj);
            return RedirectToAction("frmBuscaCorrespondencia");
        }
    }
}