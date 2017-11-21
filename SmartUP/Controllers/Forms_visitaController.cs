using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class Forms_visitaController : Controller
    {
        // GET: Forms_visita
        public ActionResult Frm_buscar_visita()
        {
            return View();
        }

        public ActionResult Frm_buscar_visitante()
        {
            return View();
        }

        public ActionResult Frm_cadastrar_visita()
        {
            return View();
        }

        public ActionResult Frm_cadastrar_visitante()
        {
            return View();
        }
    }
}