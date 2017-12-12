using Model.DAO.Especifico;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsEnqueteController : Controller
    {
        // GET: FormsEnquete
        public ActionResult frmBuscaEnquete()
        {
            EnquetesDAO enqueteDAO = new EnquetesDAO();
            ViewBag.lstEnquete = enqueteDAO.buscaEnquete();
            return View();
        }

        public ActionResult frmCadastraEnquete()
        {
            return View();
        }
        public ActionResult FrmAlteraEnquete(Enquete obj)
        {
            ViewBag.obj = obj;
            return View();
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult CadastraEnquete(Enquete obj)
        {
            EnquetesDAO dao = new EnquetesDAO();
            dao.cadastra(obj);
            return RedirectToAction("frmBuscaEnquete");
        }
        public ActionResult AlteraEnquete(Enquete obj)
        {
            EnquetesDAO dao = new EnquetesDAO();
            //dao.altera(obj);
            return RedirectToAction("frmBuscaEnquete");
        }
    }
}