using Model.DAO.Especifico;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsReclamacaoController : Controller
    {
        // GET: FormsReclamacao
        public ActionResult frmBuscaReclamacao()
        {
            ReclamSugestDAO reclamDAO = new ReclamSugestDAO();
            ViewBag.lstReclam = reclamDAO.busca();
            return View();
        }

        public ActionResult frmCadastraReclamacao()
        {
            return View();
        }
        public ActionResult FrmAlteraCorrespondencia(ReclamSugest obj)
        {
            ViewBag.obj = obj;
            return View();
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult CadastraReclamacao(ReclamSugest obj)
        {
            ReclamSugestDAO dao = new ReclamSugestDAO();
            dao.cadastra(obj);
            return RedirectToAction("frmBuscaeclamacao");
        }
        public ActionResult AlteraReclamacao(ReclamSugest obj)
        {
            ReclamSugestDAO dao = new ReclamSugestDAO();
            dao.cadastra(obj);
            return RedirectToAction("frmBuscaeclamacao");
        }
    }
}