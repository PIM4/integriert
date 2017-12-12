using Model.DAO.Especifico;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsContasAReceberController : Controller
    {
        // GET: FormsContasAReceber
        public ActionResult frmBuscaContasAReceber()
        {
            ContaReceberDAO contaReceberDAO = new ContaReceberDAO();
            ViewBag.lstContaReceber = contaReceberDAO.busca();
            return View();
        }
        public ActionResult frmCadastraContasAReceber()
        {
            return View();
        }
        public ActionResult FrmAlteraContasAReceber(ContaReceber obj)
        {
            ViewBag.obj = obj;
            return View();
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult CadastraContasAReceber(ContaReceber obj)
        {
            ContaReceberDAO dao = new ContaReceberDAO();
            dao.cadastra(obj);
            return RedirectToAction("frmBuscaContasAPagar");
        }
    }
}