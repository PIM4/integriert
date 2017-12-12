using Model.DAO.Especifico;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class FormsContasAPagarController : Controller
    {
        public ActionResult FrmBuscaContasAPagar()
        {
            ContaPagarDAO contaPagarDAO = new ContaPagarDAO();
            ViewBag.lstContaPagar = contaPagarDAO.buscaTipo();
            return View();
        }
        public ActionResult FrmCadastraContasAPagar()
        {
            FornecedorDAO dao = new FornecedorDAO();
            ViewBag.lstFornecedor = dao.busca();
            return View();
        }
        public ActionResult FrmAlteraContasAPagar(ContaPagar obj)
        {
            ViewBag.obj = obj;
            return View();
        }
        public ActionResult CadastraContasAPagar(ContaPagar obj)
        {
            ContaPagarDAO dao = new ContaPagarDAO();
            dao.cadastra(obj);
            return RedirectToAction("frmBuscaContasAPagar");
        }
        public ActionResult AlteraContasAPagar(ContaPagar obj)
        {
            ContaPagarDAO dao = new ContaPagarDAO();
            dao.altera(obj);
            return RedirectToAction("frmBuscaContasAPagar");
        }
    }
}