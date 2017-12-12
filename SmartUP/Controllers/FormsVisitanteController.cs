using Model.DAO.Especifico;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsVisitanteController : Controller
    {
        #region Visitante
        public ActionResult frmBuscaVisitante()
        {
            VisitanteDAO visitanteDAO = new VisitanteDAO();
            ViewBag.lstVisitante = visitanteDAO.busca();
            return View();
        }

        public ActionResult frmCadastraVisitante()
        {
            return View();
        }

        public ActionResult CadastraVisitante(Visitante obj)
        {
            VisitanteDAO dao = new VisitanteDAO();
            dao.cadastra(obj);
            return RedirectToAction("frmBuscaVisitante");
        }
    #endregion
    }
}