using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class Forms_funcionarioController : Controller
    {
        // GET: Forms_funcionario
        public ActionResult Frm_buscar_interno()
        {
            return View();
        }

        public ActionResult Frm_buscar_terceiro()
        {
            return View();
        }

        public ActionResult Frm_cadastrar_interno()
        {
            return View();
        }

        public ActionResult Frm_cadastrar_terceiro()
        {
            return View();
        }
    }
}