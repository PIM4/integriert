using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class Forms_financasController : Controller
    {
        // GET: Forms_financas
        public ActionResult Frm_buscar_contas_a_pagar()
        {
            return View();
        }

        public ActionResult Frm_buscar_contas_a_receber()
        {
            return View();
        }

        public ActionResult Frm_buscar_fornecedor()
        {
            return View();
        }

        public ActionResult Frm_buscar_obra()
        {
            return View();
        }

        public ActionResult Frm_cadastrar_contas_a_pagar()
        {
            return View();
        }

        public ActionResult Frm_cadastrar_contas_a_receber()
        {
            return View();
        }

        public ActionResult Frm_cadastrar_fornecedor()
        {
            return View();
        }

        public ActionResult Frm_cadastrar_obra()
        {
            return View();
        }
    }
}