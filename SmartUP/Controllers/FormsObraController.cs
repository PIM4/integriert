using Model.DAO.Especifico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsObraController : Controller
    {
        // GET: Forms_financas

        public ActionResult FrmBuscarObra()
        {
            ObraDAO ObraDAO = new ObraDAO();
            ViewBag.lstObra = ObraDAO.busca();
            return View();
        }

        public ActionResult FrmCadastrarObra()
        {
            return View();
        }
    }
}