using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsEntradaESaidaController : Controller
    {
        // GET: Forms_visita
        public ActionResult FrmBuscarVisita()
        {
            return View();
        }

        public ActionResult FrmBuscarVisitante()
        {
            return View();
        }

        public ActionResult FrmCadastrarVisita()
        {
            return View();
        }

        public ActionResult FrmCadastrarVisitante()
        {
            return View();
        }
    }
}