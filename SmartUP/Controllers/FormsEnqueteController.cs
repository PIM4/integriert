using Model.DAO.Especifico;
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
        public ActionResult FrmBuscarEnquete()
        {
            EnquetesDAO enqueteDAO = new EnquetesDAO();
            ViewBag.lstEnquete = enqueteDAO.buscaEnquete();
            return View();
        }

        public ActionResult FrmCadastrarEnquete()
        {
            return View();
        }
    }
}