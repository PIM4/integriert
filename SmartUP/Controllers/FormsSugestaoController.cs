
using Model.DAO.Especifico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsSugestaoController : Controller
    {
        // GET: FormsSugestao
        public ActionResult frmBuscaSugestao()
        {
            ReclamSugestDAO sugestDAO = new ReclamSugestDAO();
            ViewBag.lstSugest = sugestDAO.busca();
            return View();
        }

        public ActionResult frmCadastraSugestao()
        {
            return View();
        }
        public ActionResult FrmAlteraCorrespondencia(ReclamSugestDAO obj)
        {
            ViewBag.obj = obj;
            return View();
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult CadastraSugestao(ReclamSugestDAO obj)
        {
            ReclamSugestDAO dao = new ReclamSugestDAO();
           // dao.cadastra(obj);
            return RedirectToAction("frmBuscaSugestao");
        }
        public ActionResult AlteraSugestao(ReclamSugestDAO obj)
        {
            ReclamSugestDAO dao = new ReclamSugestDAO();
            //dao.altera(obj);
            return RedirectToAction("frmBuscaSugestao");
        }
    }
}