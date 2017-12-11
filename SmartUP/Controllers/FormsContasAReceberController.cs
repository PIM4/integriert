using Model.DAO.Especifico;
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
        public ActionResult FrmBuscarContasAReceber()
        {
            ContaReceberDAO contaReceberDAO = new ContaReceberDAO();
            ViewBag.lstContaReceber = contaReceberDAO.busca();
            return View();
        }

        public ActionResult FrmCadastrarContasAReceber()
        {
            return View();
        }
    }
}