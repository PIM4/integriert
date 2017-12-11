using Model.DAO.Especifico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsContasAPagarController : Controller
    {
        public ActionResult FrmBuscarContasAPagar()
        {
            ContaPagarDAO contaPagarDAO = new ContaPagarDAO();
            ViewBag.lstContaPagar = contaPagarDAO.buscaTipo();
            return View();
        }

        public ActionResult FrmCadastrarContasAPagar()
        {
            FornecedorDAO dao = new FornecedorDAO();
            ViewBag.lstFornecedor = dao.busca();
            return View();
        }
    }
}