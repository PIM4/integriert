using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsFuncionarioController : Controller
    {
        // GET: Forms_funcionario
        public ActionResult FrmBuscarInterno()
        {
            return View();
        }

        public ActionResult FrmBuscarTerceiro()
        {
            return View();
        }

        public ActionResult FrmCadastrarInterno()
        {
            return View();
        }

        public ActionResult FrmCadastrarTerceiro()
        {
            return View();
        }
    }
}